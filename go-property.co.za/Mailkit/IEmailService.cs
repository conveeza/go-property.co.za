using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace go_property.co.za.Mailkit
{
    public interface IEmailService
    {
        void SendEmail(EmailModel emailModel);
    }
}