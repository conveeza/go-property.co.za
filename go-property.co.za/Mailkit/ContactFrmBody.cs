using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace go_property.co.za.Mailkit
{
    public class ContactFrmBody
    {
        public static string EmailStringContactBody(string name, string message, string email, string phone)
        {
            return $@"
                <h1>Dear Go Property!</h1>
                <p>You have received the following message from: <b>{name}</b>.</p>
                <h4>Subject: Support Message</h4>
                <p>Their Email: <b>{email}</b></p>
                <p>Their Phone: <b>{phone}</b></p>
                <h4>Message:</h4>
                <p>{message}</p>
                <br/><p>Kind Regards <br/> Go Property <br/></p>
                <img src=\""~/images/GoProplogo.png\"" alt=\""Logo\"" width=\""20%\"" />";     
        }
    }
}
