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
    public partial class categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //process the delete first and then reload the grid
            // then call the function GetCategories to populate the grid
            //saves loading the grid twice on same load of the page
            if (!IsPostBack)
            {
              GetCategories();
           }
        }

        protected void GetCategories()
        { 
            //code lives between brackets and disconnects from db when it is out of them
            //use EF to connect to the list of categories
            using (DefaultConnection db = new DefaultConnection())
            { 
            //simplified linq query
                var cats = from c in db.Categories
                           select c;

                //bind the cats to the grid
                grdCategories.DataSource = cats.ToList();
                grdCategories.DataBind();
            }
        }

        protected void grdCategories_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //identify the CategoryID from the row that we want to delete
            Int32 CategoryID = Convert.ToInt32(grdCategories.DataKeys[e.RowIndex].Values["CategoryID"]);

            //connect
            using (DefaultConnection db = new DefaultConnection())
            {
                //same as sql command (SELECT * categories WHERE CategoryID= the variable)
                //select current category into memory based on the ID
                Category objC = (from c in db.Categories
                                 where c.CategoryID == CategoryID
                                 select c).FirstOrDefault();
 
                //delete
                db.Categories.Remove(objC);
                    db.SaveChanges();

                //refresh the grid 
                    GetCategories();
            }
        }
   }
}