using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.admin.Code
{
    public class SessionHelper
    {
        public static void setSession(UserSession userSession)
        {
            HttpContext.Current.Session.Add("LoginSession",userSession);
        }
        public static UserSession getSession()
        {
            return HttpContext.Current.Session["LoginSession"] as UserSession;
        }
    }
}