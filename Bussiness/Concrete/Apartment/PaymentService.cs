using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Bussiness.Abstracts.Apartment;
using Core.Constants;
using Core.Utilities.Results;
using Dto.Concrete.CreditCard;
using Dto.Concrete.Payment.CreditCard;
using Dto.Concrete.Payment.Payment;
using Dto.Concrete.Payment.Transaction;
using Entity.Mongo;
using Newtonsoft.Json;

namespace Bussiness.Concrete.Apartment
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;
        private readonly IBillService _billService;

        public PaymentService(IBillService billService)
        {
            _billService = billService;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Config.PaymentServiceUrl);
        }

        public async Task<IDataResult<Transaction>> Pay(PaymentCreateDto paymentCreateDto)
        {
            var bill = await _billService.GetWithDetails(paymentCreateDto.BillId);

            #region GetCreditCardFromPS

            HttpResponseMessage cardResponseMessage = await _httpClient.GetAsync($"api/Account/GetCardWithDetails/{paymentCreateDto.CreditCardId}");

            var cardString = await cardResponseMessage.Content.ReadAsStringAsync();
            CreditCardModelDto card = JsonConvert.DeserializeObject<SuccessDataResult<CreditCardModelDto>>(cardString).Data;

            #endregion

            TransactionCreateDto transactionCreateDto = new TransactionCreateDto
            {
                Firstname = bill.Data.Firstname,
                Lastname = bill.Data.Firstname,
                Amount = bill.Data.Amount,
                Month = card.Month,
                Number = card.Number,
                Year = card.Year,
                Cvv = card.Cvv,
                PaymentDetails = bill.Data.BillType,
                
            };

            #region PaymentServis
            var strRegister = JsonConvert.SerializeObject(transactionCreateDto);
            var data = new StringContent(strRegister, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync($"api/Transaction/Pay", data);


            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = await httpResponseMessage.Content.ReadAsStringAsync();

                var transaction = JsonConvert.DeserializeObject<SuccessDataResult<Transaction>>(result);

                if (transaction.Success)
                {
                    return transaction;
                }

                return new ErrorDataResult<Transaction>() {Data = null};
            }
            #endregion

            throw new NotImplementedException();

        }

    }
}
