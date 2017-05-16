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
    public partial class Products : System.Web.UI.Page
    {
        string submittedFilePath =
        Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FoodOrderWebsiteLogFile.txt.";
        protected void Page_Load(object sender, EventArgs e)
        {
            EClient user = (EClient)Session["user"];
            if (user != null)
            {
                welc.Text = "Hoşgeldin " + user.name + " !  İşte Yemeklerimiz";
                welc.Visible = true;
                if (!IsPostBack)
                {
                    ProductGrid.DataSource = BLLProduct.SelectProduct_Category(1);
                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(submittedFilePath, true))
                    {
                        file.WriteLine("["+DateTime.Now + "] DB PRODUCTS SELECTED BY CATEGORY");
                    }
                    ProductGrid.DataBind();
                    aperatifGrid.DataSource = BLLProduct.SelectProduct_Category(2);
                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(submittedFilePath, true))
                    {
                        file.WriteLine("["+DateTime.Now + "] DB PRODUCTS SELECTED BY CATEGORY");
                    }
                    aperatifGrid.DataBind();
                    IcecekGrid.DataSource = BLLProduct.SelectProduct_Category(3);
                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(submittedFilePath, true))
                    {
                        file.WriteLine("["+DateTime.Now + "] DB PRODUCTS SELECTED BY CATEGORY");
                    }
                    IcecekGrid.DataBind();
                    tatlıGrid.DataSource = BLLProduct.SelectProduct_Category(4);
                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(submittedFilePath, true))
                    {
                        file.WriteLine("["+DateTime.Now + "] DB PRODUCTS SELECTED BY CATEGORY");
                    }
                    tatlıGrid.DataBind();

                }

            }
            else
            {
                welc.Visible = false;
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void GoButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (i==0)
                {
                    for (int j = 0; j < ProductGrid.Rows.Count; j++)
                    {
                        GridViewRow row = ProductGrid.Rows[j];
                        int count = Convert.ToInt32(((TextBox)row.FindControl("TextBoxOrderCount")).Text.ToString());
                        if (count > 0)
                        {
                            EClient usr = (EClient)Session["user"];
                            int client = usr.id;
                            int product = Convert.ToInt32(((Label)row.FindControl("Label1")).Text.ToString());
                            BLLBasket.AddItem(client, product, count);
                            using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(submittedFilePath, true))
                            {
                                file.WriteLine("["+DateTime.Now + "] DB BASKET DATA INSERTED");
                            }
                            feedback.Text = "Ürününüz Sepete başarıyla eklendi !!!";
                            feedback.Visible = true;
                            ((TextBox)row.FindControl("TextBoxOrderCount")).Text = "0";
                        }

                    }
                }
                else if (i==1)
                {
                    for (int j = 0; j < aperatifGrid.Rows.Count; j++)
                    {
                        GridViewRow row = aperatifGrid.Rows[j];
                        int count = Convert.ToInt32(((TextBox)row.FindControl("aperatifCount")).Text.ToString());
                        if (count > 0)
                        {
                            EClient usr = (EClient)Session["user"];
                            int client = usr.id;
                            int product = Convert.ToInt32(((Label)row.FindControl("Label2")).Text.ToString());
                            BLLBasket.AddItem(client, product, count);
                            using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(submittedFilePath, true))
                            {
                                file.WriteLine("["+DateTime.Now + "] DB BASKET DATA INSERTED");
                            }
                            feedback.Text = "Ürününüz Sepete başarıyla eklendi !!!";
                            feedback.Visible = true;
                            ((TextBox)row.FindControl("aperatifCount")).Text = "0";
                        }

                    }
                }
                else if (i == 2)
                {
                    for (int j = 0; j < IcecekGrid.Rows.Count; j++)
                    {
                        GridViewRow row = IcecekGrid.Rows[j];
                        int count = Convert.ToInt32(((TextBox)row.FindControl("IcecekCount")).Text.ToString());
                        if (count > 0)
                        {
                            EClient usr = (EClient)Session["user"];
                            int client = usr.id;
                            int product = Convert.ToInt32(((Label)row.FindControl("Label6")).Text.ToString());
                            BLLBasket.AddItem(client, product, count);
                            using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(submittedFilePath, true))
                            {
                                file.WriteLine("["+DateTime.Now + "] DB BASKET DATA INSERTED");
                            }
                            feedback.Text = "Ürününüz Sepete başarıyla eklendi !!!";
                            feedback.Visible = true;
                            ((TextBox)row.FindControl("IcecekCount")).Text = "0";
                        }

                    }
                }
                else if (i == 3)
                {
                    for (int j = 0; j < tatlıGrid.Rows.Count; j++)
                    {
                        GridViewRow row = tatlıGrid.Rows[j];
                        int count = Convert.ToInt32(((TextBox)row.FindControl("tatlıCount")).Text.ToString());
                        if (count > 0)
                        {
                            EClient usr = (EClient)Session["user"];
                            int client = usr.id;
                            int product = Convert.ToInt32(((Label)row.FindControl("Label10")).Text.ToString());
                            BLLBasket.AddItem(client, product, count);
                            using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(submittedFilePath, true))
                            {
                                file.WriteLine("["+DateTime.Now + "] DB BASKET DATA INSERTED");
                            }
                            feedback.Text = "Ürününüz Sepete başarıyla eklendi !!!";
                            feedback.Visible = true;
                            ((TextBox)row.FindControl("tatlıCount")).Text = "0";
                        }

                    }
                }
            }
        }
    }
}