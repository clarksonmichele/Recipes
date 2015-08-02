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
    public partial class recipe_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if it is loading for the first time check the url
            if (!IsPostBack)
            {
                //if there is an ID look up the selected recipe
                if (!String.IsNullOrEmpty(Request.QueryString["RecipeID"]))
                {
                    GetRecipe();
                }
            }
        }

        protected void GetRecipe()
        {
            //look up the selected recipe and populate the form
            using (DefaultConnection db = new DefaultConnection())
            {
                //store the ID in a variable
                Int32 RecipeID = Convert.ToInt32(Request.QueryString["RecipeID"]);

                //look up the recipe
                Recipe objR = (from r in db.Recipes
                                 where r.RecipeID == RecipeID
                                 select r).FirstOrDefault();

                //pre populate our form fields
                txtName.Text = objR.RecipeName;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
             //connect to database
            using (DefaultConnection db = new DefaultConnection())
            { 
                //create a new recipe in the memory
                Recipe objR = new Recipe();

                //check for the url
                if (!string.IsNullOrEmpty(Request.QueryString["RecipeID"]))
                {
                    //get the ID
                    Int32 RecipeID = Convert.ToInt32(Request.QueryString["RecipeID"]);

                    //check recipe
                    objR = (from r in db.Recipes
                            where r.RecipeID == RecipeID
                            select r).FirstOrDefault();
                }

                //fill the properties of the new recipe
                objR.RecipeName = txtName.Text;

                //add it - if no id found call the add function
                if (String.IsNullOrEmpty(Request.QueryString["RecipeID"]))
                {
                   db.Recipes.Add(objR);
                }
                
                //save new recipe on db
                db.SaveChanges();

                //redirect user to the recipes page
                Response.Redirect("recipes.aspx");
            }
        }
    }
}