<%@ Page Title="Home page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmMainMenu.aspx.cs" Inherits="TheRideYouRentApp.frmMainMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblCars" runat="server" Text="Cars"></asp:Label>
    <br />
    <asp:Button ID="btnCarsEdit" runat="server" Text="Edit" OnClick="btnCarsEdit_Click"/>
    <br />
    <asp:Label ID="lblInspectors" runat="server" Text="Inspectors"></asp:Label>
    <br />
    <asp:Button ID="btnInspectorsEdit" runat="server" Text="Edit" OnClick="btnInspectorsEdit_Click"/>
    <br />
    <asp:Label ID="lblDrivers" runat="server" Text="Drivers"></asp:Label>
    <br />
    <asp:Button ID="btnDriversEdit" runat="server" Text="Edit" OnClick="btnDriversEdit_Click"/>
    <br />
    <asp:Label ID="lblReturns" runat="server" Text="Returns"></asp:Label>
    <br />
    <asp:Button ID="btnReturnsEdit" runat="server" Text="Edit" OnClick="btnReturnsEdit_Click" />
    <br />
    <asp:Label ID="lblRentals" runat="server" Text="Rentals"></asp:Label>
    <br />
    <asp:Button ID="btnRentalsEdit" runat="server" Text="Edit" OnClick="btnRentalsEdit_Click" />
</asp:Content>
