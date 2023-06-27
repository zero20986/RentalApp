<%@ Page Title="Login Page" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="TheRideYouRentApp.frmLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Login Page</h1>
    <asp:Label ID="lblEmail" runat="server" Text="Inspector email"></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server" Text="" OnTextChanged="txtEmail_TextChanged"></asp:TextBox>
    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="txtPassword" TextMode ="Password" runat="server" Text=""></asp:TextBox>
    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
    <asp:Label ID="lblResult" runat="server" Visible="false" Text=""></asp:Label>
    </asp:Content>
