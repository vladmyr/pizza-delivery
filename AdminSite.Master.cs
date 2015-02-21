using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzaDelivery01 {
    public partial class AdminSite : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {

        }

        public void logOut_Click(object sender, EventArgs eventArgs) {
            Context.GetOwinContext().Authentication.SignOut();
            Session.Clear();
            Response.Redirect("/");
        }
    }
}