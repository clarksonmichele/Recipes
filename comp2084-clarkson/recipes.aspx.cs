using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//a reference so the we can use EF (the bridge) for the database
using comp2084_clarkson.Models;

namespace comp2084_clarkson
{
    public partial class recipes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //call the function GetRecipes to populate the grid
            GetRecipes();
        }

        protected void GetRecipes()
        {
            //code lives between brackets and disconnects from db when it is out of them
            //use EF to connect to the list of recipes
            using (DefaultConnection db = new DefaultConnection())
            {
                //simplified linq query
                var recs = from r in db.Recipes
                           select r;

                //bind the cats to the grid
                grdRecipes.DataSource = recs.ToList();
                grdRecipes.DataBind();
            }
        }

      //  protected void grdRecipes_RowDeleting(object sender, GridViewDeleteEventArgs e)
       // {

       // }
    }
}