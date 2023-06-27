<%@ Page Title="Return Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReturns.aspx.cs" Inherits="TheRideYouRentApp.frmReturns" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Rentals Editing</h1>
    <div style="display: flex; flex-direction: column;">
    <asp:Label ID="lblReturnID" runat="server" Text="Return Id :"></asp:Label>
    <asp:TextBox ID="txtReturnID" runat="server" Text=""></asp:TextBox>
  
    <asp:Label ID="lblRentalID" runat="server" Text="Rental ID :"></asp:Label>
    <asp:TextBox ID="txtRentalId" runat="server" Text=""></asp:TextBox>
   
    <asp:Label ID="lblInspectorNo" runat="server" Text="Inspector number :"></asp:Label>
    <asp:TextBox ID="txtInspectorNo" runat="server" Text=""></asp:TextBox>
    
    <asp:Label ID="lblOverDays" runat="server" Text="Over Days :"></asp:Label>
    <asp:Textbox ID="txtOverDays" runat="server" Text=""></asp:Textbox>

    <asp:Label ID="lblFineAmount" runat="server" Text="Fine Amount :"></asp:Label>
    <asp:TextBox ID="txtFineAmount" runat="server" Text=""></asp:TextBox>
    
    <asp:Label ID="lblReturnDate" runat="server" Text="Return Date :"></asp:Label>
    <asp:TextBox ID="txtReturnDate" runat="server" Text=""></asp:TextBox>
    
        </div>
  
    <div style="display: flex; flex-direction: row;">
        <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" CssClass="btn btn-Primary" BorderColor="Black" />
        <asp:Label ID="lblRetrieve" runat="server" Text="Enter which Return to retrieve : "></asp:Label>
        <asp:TextBox ID="txtRetrieve" runat="server" Text=""></asp:TextBox>
        <asp:Button ID="btnRetrieve" runat="server" Text="Retrieve" OnClick="btnRetrieve_Click" CssClass="btn btn-Primary" BorderColor="Black" />
        </div>
    <asp:GridView ID="dgvCar" width= "1200" runat="server"></asp:GridView>
</asp:Content>
