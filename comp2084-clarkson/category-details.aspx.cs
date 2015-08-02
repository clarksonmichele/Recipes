using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference the db model to connect to sql server
using comp2084_clarkson.Models;

namespace comp2084_clarkson
{
    public partial class category_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if loading for the first time check the url
            if (!IsPostBack)
            {
                //if there is an ID look up the selected category
                if (!String.IsNullOrEmpty(Request.QueryString["CategoryID"])) {
                    GetCategory();
                }
             }
        }

        protected void GetCategory()
        { 
            //look up the selected category and populate the form
            using (DefaultConnection db = new DefaultConnection())
            {
                //store the ID in a variable
                Int32 CategoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);

                //look up which category
                Category objC = (from c in db.Categories
                                 where c.CategoryID == CategoryID
                                 select c).FirstOrDefault();

                //pre populate the form fields
                txtName.Text = objC.CategoryName;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //connect to database
            using (DefaultConnection db = new DefaultConnection())
            { 
                //create a new category in memory
                Category objC = new Category();

                //Int32 CategoryID = 0;

                //try to find the url
                if (!string.IsNullOrEmpty(Request.QueryString["CategoryID"]))
                {
                    //get the ID
                    Int32 CategoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);

                    //see which category it is
                    objC = (from c in db.Categories
                            where c.CategoryID == CategoryID
                            select c).FirstOrDefault();
                }

                //fill the properties of the new category we are adding
                objC.CategoryName = txtName.Text;

                //add it if there is no id found call the add function
                if (String.IsNullOrEmpty(Request.QueryString["CategoryID"]))
                {
                   db.Categories.Add(objC);
                }
                
                //save the new category
                db.SaveChanges();

                //redirect to the categories list page
                Response.Redirect("categories.aspx");
            }
        }
    }
}