using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BRMS.Views
{
    public partial class TenantView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rdoPerson_CheckedChanged(object sender, EventArgs e)
        {
            Response.Redirect("PersonView.aspx");
        }

        protected void rdoCompany_CheckedChanged(object sender, EventArgs e)
        {
            Response.Redirect("CompanyView.aspx");
        }
    }
}