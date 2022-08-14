using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bussiness.Abstracts;
using Bussiness.Abstracts.Apartment;
using Bussiness.Configuration.Constants;
using Core.Entity.Concrete;
using Core.Service.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Dto.Concrete.User;
using Entity.Concrete.MsSql;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Bussiness.Concrete.Apartment
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IOperationClaimService _operationClaimService;
        private readonly IService<Manager, int> _managerService;
        private readonly IService<Tenant, int> _residentService;
        private readonly IDistributedCache _distributedCache;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;


        public AuthService(IMapper mapper, ITokenHelper tokenHelper, IUserService userService, IService<Manager, int> managerService, IOperationClaimService operationClaimService, IService<Tenant, int> residentService, IDistributedCache distributedCache)
        {
            _mapper = mapper;
            _userService = userService;
            _tokenHelper = tokenHelper;
            _managerService = managerService;
            _operationClaimService = operationClaimService;
            _residentService = residentService;
            _distributedCache = distributedCache;
        }

        public async Task<IDataResult<AccessToken>> Login(UserForLogin userForLogin)
        {
            /// Eğer kullanıcının daha önce giriş yapmış ve token oluşturmuşsa cachedeki bilgiler kullanılarak db de işlem yapılması engellendir
            /// eğer token rediste yok veya expire süresi bitmiş ise yenişi sqlden alınarak redis bilgileri tazelenir.
            /// 
            var user = await _userService.GetByEmail(userForLogin.Email);

            var isVerified =HashingHelper.VerifyPasswordHash(userForLogin.Password, user.Data.Pasword.PasswordHash,
                user.Data.Pasword.PasswordSalt);

            if (isVerified)
            {
                AccessToken accessToken = null;
                var accesTokenJson = _distributedCache.GetString($"USR_{user.Data.Id}");
                if (!string.IsNullOrWhiteSpace(accesTokenJson))
                    accessToken = JsonConvert.DeserializeObject<AccessToken>(accesTokenJson);

                if (accessToken == null || accessToken.Expiration <= DateTime.Now)
                {
                    var userOpertaitonClaims = await _operationClaimService.GetUserClaims(user.Data.Id);
                    accessToken = _tokenHelper.CreateToken(user.Data, userOpertaitonClaims.Data);
                    var accessTokenJson = JsonConvert.SerializeObject(accessToken);
                    _distributedCache.SetString($"USR_{user.Data.Id}", accessTokenJson);
                }

                return new SuccessDataResult<AccessToken>(accessToken);
            }

            return new ErrorDataResult<AccessToken>("Login failed");
        }

        public async Task<IDataResult<AccessToken>> ManagerRegister(ManagerForRegister managerForRegister)
        {
            /// Öncelikle user oluşturulur ve şifresi haşlenderek şifre atanır, oluşturulan kullanıcı yeni oluşturulacak Managere atanır.
            /// İşlemler başarılı olursa manager-user için roller oluşturulur ve (2 numaralı rol atanır) ve token oluşturulur.
            /// User credentionları redis sunucusunda saklanır.

            #region ManagerRegister

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(managerForRegister.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = managerForRegister.Email,
                Firstname = managerForRegister.Firstname,
                Lastname = managerForRegister.Lastname,
                Pasword = new Password()
                {
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                },
                Status = true
            };
            var operationClaims = _operationClaimService.Where(w => w.Id == (int)UserType.Manager).ToList();

            await _userService.AddAsync(user);

            _operationClaimService.SetUserClaim(user.Id, operationClaims);
            var manager = new Manager()
            {
                User = user,
                Username = managerForRegister.Username
            };
            await _managerService.AddAsync(manager);
            var accessToken = _tokenHelper.CreateToken(user, operationClaims);

            #endregion

            #region Cache

            #endregion

            return new SuccessDataResult<AccessToken> { Data = accessToken };
        }

        public async Task<IDataResult<AccessToken>> ChangePassword(int id, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = await _userService.GetByIdAsync(id);
            user.Data.Pasword.PasswordHash = passwordHash;
            user.Data.Pasword.PasswordSalt = passwordSalt;
            user.Data.Active = true;
            _userService.Update(user.Data);

            var operationClaims = _operationClaimService.Where(w => w.Id == (int)UserType.Tenant).ToList();
            var accessToken = _tokenHelper.CreateToken(user.Data, operationClaims);
            return new SuccessDataResult<AccessToken>() {Data = accessToken};
        }

        //public async Task<IDataResult<AccessToken>> TenantRegister(TenantForRegister tenantForRegister)
        //{
        //    /// Öncelikle user oluşturulur ve şifresi haşlenderek şifre atanır, oluşturulan kullanıcı yeni oluşturulacak Tenant atanır.
        //    /// İşlemler başarılı olursa tenant-user için roller oluşturulur ve (3 numaralı rol atanır) ve token oluşturulur.
        //    /// User credentionları redis sunucusunda saklanır.

        //    #region TenantRegister

        //    byte[] passwordHash, passwordSalt;
        //    HashingHelper.CreatePasswordHash(tenantForRegister.Password, out passwordHash, out passwordSalt);
        //    var user = new User
        //    {
        //        Email = tenantForRegister.Email,
        //        Firstname = tenantForRegister.Firstname,
        //        Lastname = tenantForRegister.Lastname,
        //        Pasword = new Password()
        //        {
        //            PasswordHash = passwordHash,
        //            PasswordSalt = passwordSalt,
        //        },
        //        Status = true
        //    };
        //    var operationClaims = _operationClaimService.Where(w => w.Id == (int)UserType.Tenant).ToList();
        //    _operationClaimService.SetUserClaim(user.Id, operationClaims);
        //    var resident = new Tenant()
        //    {
        //        User = user,
        //        IdentityNumber = tenantForRegister.IdentityNumber,
        //        HasACar = tenantForRegister.HasACar,
        //        Phone = tenantForRegister.Phone,
        //        Plate = tenantForRegister.Plate,
        //    };
        //    await _residentService.AddAsync(resident);
        //    var accessToken = _tokenHelper.CreateToken(user, operationClaims);

        //    #endregion

        //    #region RedisCahce
        //    _distributedCache.SetString($"USR_{user.Id}",accessToken.ToString());

        //    #endregion
        //    return new SuccessDataResult<AccessToken> { Data = accessToken };
        //}
    }
}
