<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="category-details.aspx.cs" Inherits="comp2084_clarkson.category_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>List of Categories</h1>
    
    <div class="form-group">
        <label for="txtName" class="col-sm-2">Name:</label>
        <asp:TextBox ID="txtName" runat="server" MaxLength="100" required />
    </div>
    <div  class="col-sm-offset-2">
        <asp:Button ID="btnSave" runat="server" Text="SAVE" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>

</asp:Content>
