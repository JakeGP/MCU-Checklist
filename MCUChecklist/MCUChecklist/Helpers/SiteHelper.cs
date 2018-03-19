using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MCUChecklist.Helpers
{
    public class SiteHelper
    {
        public static bool CheckIfSessionExpired(HttpRequestBase request)
        {
            if (request.Cookies[".ASPXAUTH"] != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(request.Cookies[".ASPXAUTH"].Value);
                return ticket.Expired;
            }
            return true;
        }
    }
}