using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Food_Order_Website.Models;

namespace Food_Order_Website.Account
{
    public partial class Register : Page
    {
        string submittedFilePath =
        Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FoodOrderWebsiteLogFile.txt.";
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            //var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            //IdentityResult result = manager.Create(user, Password.Text);
            //if (result.Succeeded)
            //{
            //    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
            //    //string code = manager.GenerateEmailConfirmationToken(user.Id);
            //    //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
            //    //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

            //    signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
            //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //}
            //else 
            //{
            //    ErrorMessage.Text = result.Errors.FirstOrDefault();
            //}

            if (Email.Text != null)
            {
                if (Password.Text != null)
                {
                    string Cname = name.Text.ToString();
                    string Csurname = surname.Text.ToString();
                    string Ctel = tel.Text.ToString();
                    string Cemail = Email.Text.ToString();
                    string Cpass = Password.Text.ToString();
                    string Caddr = addr.Text.ToString();
                    bool admin = false;
                    BLL.BLLClient.CreateClient(Cname,Csurname,Ctel,Cemail,Cpass,Caddr,admin);
                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(submittedFilePath, true))
                    {
                        file.WriteLine("[" + DateTime.Now + "] DB CLIENT INSERTED");
                    }
                }
            }
        }
    }
}