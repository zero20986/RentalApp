<%@ Page Title="Rental Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRentals.aspx.cs" Inherits="TheRideYouRentApp.frmRentals" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Rentals Editing</h1>
    <div style="display: flex; flex-direction: column;">
    <asp:Label ID="lblRentalID" runat="server" Text="Rental Id :"></asp:Label>
    <asp:TextBox ID="txtRentalId" runat="server" Text=""></asp:TextBox>
  
    <asp:Label ID="lblCarNo" runat="server" Text="Car Number :"></asp:Label>
    <asp:TextBox ID="txtCarno" runat="server" Text=""></asp:TextBox>
   
    <asp:Label ID="lblDriverID" runat="server" Text="Driver ID :"></asp:Label>
    <asp:TextBox ID="txtDriverID" runat="server" Text=""></asp:TextBox>
    
    <asp:Label ID="lblInspectorNo" runat="server" Text="Inspector Number :"></asp:Label>
    <asp:Textbox ID="txtInspectorNo" runat="server" Text=""></asp:Textbox>

    <asp:Label ID="lblStart" runat="server" Text="Start Date :"></asp:Label>
    <asp:TextBox ID="txtStart" runat="server" Text=""></asp:TextBox>
    
    <asp:Label ID="lblEnd" runat="server" Text="End Date :"></asp:Label>
    <asp:TextBox ID="txtEnd" runat="server" Text=""></asp:TextBox>
    
        </div>
  
    <div style="display: flex; flex-direction: row;">
        <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" CssClass="btn btn-Primary" BorderColor="Black" />
        <asp:Label ID="lblRetrieve" runat="server" Text="Enter which Rental to retrieve : "></asp:Label>
        <asp:TextBox ID="txtRetrieve" runat="server" Text=""></asp:TextBox>
        <asp:Button ID="btnRetrieve" runat="server" Text="Retrieve" OnClick="btnRetrieve_Click" CssClass="btn btn-Primary" BorderColor="Black" />
        <asp:Label ID="lblCal" runat="server" Text="Calculate the penalty fee on a rental that was returned late."></asp:Label>
         <asp:Button ID="btnCal" runat="server" Text="Calculate" OnClick="btnCal_Click" CssClass="btn btn-Primary" BorderColor="Black" />
        </div>
    <asp:GridView ID="dgvCar" width= "1200" runat="server"></asp:GridView>
</asp:Content>
