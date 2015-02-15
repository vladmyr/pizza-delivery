using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using PizzaDelivery01.App_Start;
using PizzaDelivery01.Data.Initializer;
using PizzaDelivery01.Entity.Context;

namespace PizzaDelivery01
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            WebApiConfig.Register(GlobalConfiguration.Configuration);

            //initialize database
            Database.SetInitializer(new ProductDatabaseInitializer());
        }
    }
}