<%@ Page Title="Recipes" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="recipes.aspx.cs" Inherits="comp2084_clarkson.recipes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Recipes</h1>
    <a href ="recipe-details.aspx">Add a recipe</a>

    <asp:GridView runat="server" ID="grdRecipes" CssClass="table table-striped table table-hover" 
        AutoGenerateColumns="false" OnRowDeleting="grdRecipes_RowDeleting" DataKeyNames="RecipeID">

         <Columns>
            <asp:BoundField DataField="RecipeID" HeaderText="ID" Visible="false" />
            <asp:BoundField DataField="RecipeName" HeaderText="Recipe Name" />
         </Columns>

    </asp:GridView>

</asp:Content>