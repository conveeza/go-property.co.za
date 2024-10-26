using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace go_property.co.za.Mailkit
{
    public class SellConfirmationBody
    {
        public static string EmailStringSellBody(string cusName, string cusEmail, string cusPhone, string propDesc, string propBeds, string propBaths, string propAddress)
        {
            return $"<h2>Dear Go Property.</h2>" +
                $"<p>A new customer would like to list a property:</p>" +
                $"<h3>Customer Details:</h3>" +
                $"<p><b>Name: </b>{cusName}<br />  <b>Email: </b>{cusEmail}<br /> <b>Phone Number: </b>{cusPhone}</p>" +
                $"<h3>Property Details:</h3>" +
                $"<p><b>Property Description: </b>{propDesc}<br /> <b>Address: </b>{propAddress}<br /> <b>Beds: </b>{propBeds}<br />" +
                $"<b>Baths: </b>{propBaths}<br /></p>" +
                $"<br/><p>Kind Regards <br/> Go Property <br/></p>" +
                $"<img src=\"~/images/GoProplogo.png\" alt=\"Logo\" width=\"20%\"/>";
        }
    }
}