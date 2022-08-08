using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;

namespace Dto.Concrete.Apartment.Message
{
    public class MessageModel :IDto
    {
        public string FromUser { get; set; }
        public string ToUser { get; set; }
        public string MessageText { get; set; }
        public DateTime Sent { get; set; }

    }
}
