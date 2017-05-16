using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL;
using BLL;

namespace Food_Order_Website
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string submittedFilePath =
        Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FoodOrderWebsiteLogFile.txt.";
        protected void Page_Load(object sender, EventArgs e)
        {
            EClient usr = (EClient)Session["user"];
            if (usr==null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (usr.isAdmin)
                {
                    if (!IsPostBack)
                    {
                        FillProductView();
                        FillClientView();
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        protected void AdminProductGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)AdminProductGrid.Rows[e.RowIndex];
            Label LabelID = (Label)row.FindControl("Label1");
            BLLProduct.DeleteProduct(Convert.ToInt32(LabelID.Text));
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(submittedFilePath, true))
            {
                file.WriteLine("["+DateTime.Now + "] DB PRODUCT DELETED");
            }
            FillProductView();
            feedbackProduct.Text = "Records Deleted Succesfully !!!";
            feedbackProduct.Visible = true;
        }
        protected void InsertProduct_Click(object sender, EventArgs e)
        {
            string name = ((TextBox)AdminProductGrid.FooterRow.FindControl("TextBoxInsertProductName")).Text.ToString();
            int cat = Convert.ToInt32(((DropDownList)AdminProductGrid.FooterRow.FindControl("DropDownListInsertCategory")).SelectedItem.Text.ToString());
            decimal price = Convert.ToDecimal(((TextBox)AdminProductGrid.FooterRow.FindControl("TextBoxInsertPrice")).Text.ToString());
            bool stock = ((CheckBox)AdminProductGrid.FooterRow.FindControl("TextBoxInsertStock")).Checked;
            string desc = ((TextBox)AdminProductGrid.FooterRow.FindControl("TextBoxInsertDescription")).Text.ToString();

            BLLProduct.CreateProduct(name, cat, price, stock, desc);
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(submittedFilePath, true))
            {
                file.WriteLine("["+DateTime.Now + "] DB PRODUCT INSERTED");
            }
            FillProductView();
            feedbackProduct.Text = "Record Added Succesfully !!!";
            feedbackProduct.Visible = true;
        }

        protected void AdminProductGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            AdminProductGrid.EditIndex = e.NewEditIndex;
            FillProductView();
            feedbackProduct.Text = "Editing...";
            feedbackProduct.Visible = true;
        }

        protected void AdminProductGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)AdminProductGrid.Rows[e.RowIndex];
            Label LabelID = (Label)row.FindControl("LabelProductID");
            TextBox TxtName = (TextBox)row.FindControl("TextBoxProductName");
            DropDownList DropDownListCategory = (DropDownList)row.FindControl("DropDownListCategories");
            TextBox TextBoxPrice = (TextBox)row.FindControl("TextBoxPrice");
            CheckBox CheckBoxStock = (CheckBox)row.FindControl("CheckBoxStock");
            TextBox TextBoxDescription = (TextBox)row.FindControl("TextBoxDescription");

            BLLProduct.UpdateProduct(new EProduct
            {
                ProductID = Convert.ToInt32(LabelID.Text.ToString()),
                ProductName = TxtName.Text.ToString(),
                CategoryID = Convert.ToInt32(DropDownListCategory.SelectedItem.Text.ToString()),
                Price = Convert.ToDecimal(TextBoxPrice.Text.ToString()),
                Stock = CheckBoxStock.Checked,
                Description = TextBoxDescription.Text.ToString()
            });
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(submittedFilePath, true))
            {
                file.WriteLine("["+DateTime.Now + "] DB PRODUCT UPDATED");
            }
            AdminProductGrid.EditIndex = -1;
            FillProductView();
            feedbackProduct.Text = "Records Updated Succesfully !!!";
            feedbackProduct.Visible = true;
        }

        protected void AdminProductGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            AdminProductGrid.EditIndex = -1;
            FillProductView();
            feedbackProduct.Text = "Edit Canceled";
            feedbackProduct.Visible = true;
        }
        protected void FillProductView()
        {
            AdminProductGrid.DataSource = BLLProduct.GetProduct();
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(submittedFilePath, true))
            {
                file.WriteLine("["+DateTime.Now + "] DB PRODUCT DATA PULLED");
            }
            AdminProductGrid.DataBind();
        }

        protected void FillClientView()
        {
            AdminUserGrid.DataSource = BLLClient.GetClients();
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(submittedFilePath, true))
            {
                file.WriteLine("["+DateTime.Now + "] DB CLIENT DATA PULLED");
            }
            AdminUserGrid.DataBind();
        }

        protected void InsertUser_Click(object sender, EventArgs e)
        {
            string name = ((TextBox)AdminUserGrid.FooterRow.FindControl("TextBoxInsertName")).Text.ToString();
            string surname = ((TextBox)AdminUserGrid.FooterRow.FindControl("TextBoxInsertSurname")).Text.ToString();
            string telephone = ((TextBox)AdminUserGrid.FooterRow.FindControl("TextBoxInsertTelephone")).Text.ToString();
            string email = ((TextBox)AdminUserGrid.FooterRow.FindControl("TextBoxInsertEmail")).Text.ToString();
            string pass = ((TextBox)AdminUserGrid.FooterRow.FindControl("TextBoxInsertPassword")).Text.ToString();
            string addr = ((TextBox)AdminUserGrid.FooterRow.FindControl("TextBoxInsertAddress")).Text.ToString();
            bool admin = ((CheckBox)AdminUserGrid.FooterRow.FindControl("CheckBoxInsertIsAdmin")).Checked;

            BLLClient.CreateClient(name, surname, telephone, email, pass, addr, admin);
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(submittedFilePath, true))
            {
                file.WriteLine("["+DateTime.Now + "] DB CLIENT INSERTED");
            }
            FillClientView();
            feedbackUser.Text = "Record Added !!!";
            feedbackUser.Visible = true;
        }

        protected void AdminUserGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            AdminUserGrid.EditIndex = e.NewEditIndex;
            FillClientView();
            feedbackUser.Text = "Editing...";
            feedbackUser.Visible = true;
        }

        protected void AdminUserGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)AdminUserGrid.Rows[e.RowIndex];
            Label LabelID = (Label)row.FindControl("LabelID");
            BLLClient.DeleteClient(Convert.ToInt32(LabelID.Text));
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(submittedFilePath, true))
            {
                file.WriteLine("["+DateTime.Now + "] DB CLIENT DELETED");
            }
            FillClientView();
            feedbackUser.Text = "Row Deleted Successfully !!!";
            feedbackUser.Visible = true;

        }

        protected void AdminUserGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)AdminUserGrid.Rows[e.RowIndex];
            Label LabelID = (Label)row.FindControl("LabelEditID");
            TextBox TxtName = (TextBox)row.FindControl("TextBoxEditName");
            TextBox TxtSurname = (TextBox)row.FindControl("TextBoxEditSurname");
            TextBox TxtTelephone = (TextBox)row.FindControl("TextBoxEditTelephone");
            TextBox TxtEmail = (TextBox)row.FindControl("TextBoxEditEmail");
            TextBox TxtPass = (TextBox)row.FindControl("TextBoxEditPassword");
            TextBox TxtAddr = (TextBox)row.FindControl("TextBoxEditAddress");
            CheckBox ChxAdmin = (CheckBox)row.FindControl("CheckBoxEditIsAdmin");

            BLLClient.UpdateClient(new EClient
            {
                id = Convert.ToInt32(LabelID.Text.ToString()),
                name = TxtName.Text.ToString(),
                surname = TxtSurname.Text.ToString(),
                telephone = TxtTelephone.Text.ToString(),
                email = TxtEmail.Text.ToString(),
                password = TxtPass.Text.ToString(),
                address = TxtAddr.Text.ToString(),
                isAdmin = ChxAdmin.Checked
            });
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(submittedFilePath, true))
            {
                file.WriteLine("["+DateTime.Now + "] DB CLIENT UPDATED");
            }
            AdminUserGrid.EditIndex = -1;
            FillClientView();
            feedbackUser.Text = "Records Updated Succesfully !!!";
            feedbackUser.Visible = true;
        }

        protected void AdminUserGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            AdminUserGrid.EditIndex = -1;
            FillClientView();
            feedbackProduct.Text = "Edit Canceled";
            feedbackProduct.Visible = true;
        }
    }
}