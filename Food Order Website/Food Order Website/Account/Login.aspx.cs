using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Food_Order_Website.Models;
using EL;
using BLL;

namespace Food_Order_Website.Account
{
    public partial class Login : Page
    {
        string submittedFilePath =
        Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FoodOrderWebsiteLogFile.txt.";
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
            
        }

        public void LogIn(object sender, EventArgs e)
        {
            EClient usr = BLLClient.GetUser(Email.Text.ToString(), Password.Text.ToString());

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(submittedFilePath, true))
            {
                file.WriteLine("["+DateTime.Now + "] DB CLIENT VALIDATION");
            }

            if (usr != null)
            {
                Session["user"] = usr;
                if (usr.isAdmin)
                {
                    Response.Redirect("~/AdminPage.aspx");
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
                
            }
            else
            {
                emailpassError.Visible = true;
                Email.Text = "";
                Password.Text = "";
            }
        }
    }
}