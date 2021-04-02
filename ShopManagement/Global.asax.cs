using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ShopManagement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        void Application_BeginRequest(object sender, EventArgs e)
        {
            try
            {
                //string CurrentExePath = Request.CurrentExecutionFilePath;
                //string CurrentPath = Request.Url.Segments.Length >= 3 ? Request.Url.Segments[0] + Request.Url.Segments[1] + Request.Url.Segments[2] : Request.CurrentExecutionFilePath;

                //if (!string.IsNullOrEmpty(CurrentPath) && CurrentPath != "/" && CurrentPath != "/Account/Login")
                //{
                //    string value = HttpContext.Current.Session["UserId"] as string;
                //    string UserId = Session["UserId"].ToString();
                //    if (!string.IsNullOrEmpty(UserId))
                //    {
                //        Utilities.User userUtility = new Utilities.User();
                //        var userInfo = userUtility.GetUserById(UserId);
                //    }                    
                //}
            }
            catch (Exception exe)
            {

            }          
        }

    }
}
