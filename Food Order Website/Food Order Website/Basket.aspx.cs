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
    public partial class Basket : System.Web.UI.Page
    {
        string submittedFilePath =
        Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FoodOrderWebsiteLogFile.txt.";
        string name;
        protected void Page_Load(object sender, EventArgs e)
        {
            EClient user = (EClient)Session["user"];
            if (user != null)
            {
                name = user.name;
                if (!IsPostBack)
                {
                    FillGrid();
                }

            }
            else
            {
                welc.Visible = false;
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void BasketGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)BasketGrid.Rows[e.RowIndex];
            string tempkey = row.Cells[4].Text.ToString();
            int key = Convert.ToInt32(tempkey);
            BLLBasket.DeleteBasket(key);
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(submittedFilePath, true))
            {
                file.WriteLine("["+DateTime.Now + "] DB BASKET DATA DELETED");
            }
            FillGrid();
        }
        public void FillGrid()
        {
            List<ELBasket> basket = BLLBasket.GetBasket();
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(submittedFilePath, true))
            {
                file.WriteLine("["+DateTime.Now + "] DB BASKET PULLED");
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("Ürün");
            dt.Columns.Add("Miktar");
            dt.Columns.Add("Fiyat");
            dt.Columns.Add("Numara");
            if (basket!=null)
            {
                noteID.Visible = true;
                TextBoxNoteID.Visible = true;
                payementType.Visible = true;
                acceptButtonImage.Visible = true;
                welc.Text = "Hoşgeldin " + name + " !  Sepetin tam burada !!";
                welc.Visible = true;
                foreach (ELBasket item in basket)
                {
                    DataRow dr = dt.NewRow();
                    EProduct pro = (EProduct)BLLProduct.SelectProduct(item.productId);
                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(submittedFilePath, true))
                    {
                        file.WriteLine("["+DateTime.Now + "] DB PRODUCT DATA SELECTED");
                    }
                    dr["Ürün"] = pro.ProductName;
                    dr["Miktar"] = item.productCount;
                    dr["Fiyat"] = item.productCount * pro.Price;
                    dr["Numara"] = item.id;
                    dt.Rows.Add(dr);
                }
                BasketGrid.DataSource = dt;
                BasketGrid.DataBind();
            }
            else
            {
                welc.Text = "Sepetin şu an boş";
                welc.Visible = true;
                noteID.Visible = false;
                TextBoxNoteID.Visible = false;
                payementType.Visible = false;
                acceptButtonImage.Visible = false;          
                BasketGrid.DataSource = dt;
                BasketGrid.DataBind();
            }
        }


        protected void acceptButtonImage_Click(object sender, ImageClickEventArgs e)
        {
            string productsName = "";
            decimal totalPrice = 0;
            string note;
            bool type = true;
            int ClientId = 0;
            for (int i = 0; i < BasketGrid.Rows.Count; i++)
            {
                GridViewRow row = (GridViewRow)BasketGrid.Rows[i];
                productsName += row.Cells[1].Text.ToString() + ",";
                totalPrice += Convert.ToDecimal(row.Cells[3].Text);
            }
            note = TextBoxNoteID.Text.ToString();
            if (payementType.SelectedValue.ToString() == "kredi")
            {
                type = false;
            }
            else
            {
                type = true;
            }
            EClient usr = (EClient)Session["user"];
            ClientId = usr.id;

            BLLPurchase.CreatePurchase(totalPrice, productsName, note, type, ClientId);
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(submittedFilePath, true))
            {
                file.WriteLine("[" + DateTime.Now + "] DB PURCHASE CREATED");
            }

            for (int i = 0; i < BasketGrid.Rows.Count; i++)
            {
                GridViewRow row = (GridViewRow)BasketGrid.Rows[i];
                string tempkey = row.Cells[4].Text.ToString();
                int key = Convert.ToInt32(tempkey);
                BLLBasket.DeleteBasket(key);
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(submittedFilePath, true))
                {
                    file.WriteLine("[" + DateTime.Now + "] DB BASKET DELETED");
                }
            }
            FillGrid();
            Response.Redirect("~/Purchase.aspx");
        }
    }
}