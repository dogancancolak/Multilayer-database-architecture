using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using EL;
using System.Data;

namespace Food_Order_Website
{
    public partial class Purchase : System.Web.UI.Page
    {
        string submittedFilePath =
        Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FoodOrderWebsiteLogFile.txt.";
        protected void Page_Load(object sender, EventArgs e)
        {
            EClient usr = (EClient)Session["user"];
            if (usr!=null)
            {
                PurchaseGrid.DataSource = BLLPurchase.GetPurchase_ClientID(usr.id);
                using (System.IO.StreamWriter file =
                                new System.IO.StreamWriter(submittedFilePath, true))
                {
                    file.WriteLine("[" + DateTime.Now + "] DB PURCHASE PULLED");
                }
                PurchaseGrid.DataBind();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}