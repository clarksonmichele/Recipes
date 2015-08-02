<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="categories.aspx.cs" Inherits="comp2084_clarkson.categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Categories</h1>
    <a href ="category-details.aspx">Add a new category</a>

    <asp:GridView runat="server" ID="grdCategories" CssClass="table table-striped table table-hover" 
        AutoGenerateColumns="false" OnRowDeleting="grdCategories_RowDeleting" DataKeyNames="CategoryID">

         <Columns>
            <asp:BoundField DataField="CategoryID" HeaderText="ID" />
            <asp:BoundField DataField="CategoryName" HeaderText="Name" />
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" DataNavigateUrlFields="CategoryID" 
                DataNavigateUrlFormatString="category-details.aspx?CategoryID={0}" />
            <asp:CommandField ShowDeleteButton="true" DeleteText="Delete" HeaderText="Delete" />
         </Columns>

    </asp:GridView>

</asp:Content>
