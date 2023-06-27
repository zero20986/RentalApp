<%@ Page Title="Car page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCars.aspx.cs" Inherits="TheRideYouRentApp.frmCars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Cars Editing</h1>
    <div style="display: flex; flex-direction: column;">
    <asp:Label ID="lblCarNo" runat="server" Text="Car Number :"></asp:Label>
    <asp:TextBox ID="txtCarNo" runat="server" Text=""></asp:TextBox>
  
    <asp:Label ID="lblMakeCode" runat="server" Text="Car Make Code :"></asp:Label>
    <asp:TextBox ID="txtMakeCode" runat="server" Text=""></asp:TextBox>
   
    <asp:Label ID="lblBodyTypeCode" runat="server" Text="Car Body Type Code :"></asp:Label>
    <asp:TextBox ID="txtBodyTypeCode" runat="server" Text=""></asp:TextBox>
    
    <asp:Label ID="lblModel" runat="server" Text="Car Model :"></asp:Label>
    <asp:Textbox ID="txtModel" runat="server" Text=""></asp:Textbox>

    <asp:Label ID="lblKilosTravelled" runat="server" Text="Killometers Travelled :"></asp:Label>
    <asp:TextBox ID="txtKilosTravelled" runat="server" Text=""></asp:TextBox>
    
    <asp:Label ID="lblServiceKilos" runat="server" Text="Service Killometers :"></asp:Label>
    <asp:TextBox ID="txtServiceKilos" runat="server" Text=""></asp:TextBox>
    
    <asp:Label ID="lblAvailability" runat="server" Text="Available :"></asp:Label>
    <asp:TextBox ID="txtAvailability" runat="server" Text=""></asp:TextBox>
   
    <asp:Label ID="lblRentalFee" runat="server" Text="Rental Fee :"></asp:Label>
    <asp:TextBox ID="txtRentalFee" runat="server" Text=""></asp:TextBox>
        </div>
    <div style="display: flex; flex-direction: row;">
        <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" CssClass="btn btn-Primary" BorderColor="Black" />
        <asp:Button ID="btnRead" runat="server" Text="Read" OnClick="btnRead_Click" CssClass="btn btn-Primary" BorderColor="Black" />
        </div>
    <asp:Label ID="lblUpdate" runat="server" Text="Select Car To Update :"></asp:Label>
        <asp:DropDownList ID="ddlUpdateCarNo" runat="server" OnSelectedIndexChanged="ddlUpdateCarNo_SelectedIndexChanged" ></asp:DropDownList>
    <asp:Label ID="lblFieldUpdate" runat="server" Text="Select Field To Update :"></asp:Label>
     <asp:DropDownList ID="ddlUpdate" runat="server" OnLoad="ddlUpdate_Load">
     </asp:DropDownList>
    <br />
    <asp:Label ID="lblUpdateMessage" runat="server" Text="Enter new Value :"></asp:Label>
    <asp:TextBox ID="txtUpdate" runat="server" Text=""></asp:TextBox>
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="btn btn-Primary" BorderColor="Black" />
    <br />
    <asp:Label ID="lblDeleteCar" runat="server" Text="Select Car ID to Delete car"></asp:Label>
        <asp:DropDownList ID="ddlDelete" runat="server" OnSelectedIndexChanged="ddlDelete_SelectedIndexChanged"></asp:DropDownList>
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="btn btn-Primary" BorderColor="Black" />
    <br />
    <asp:GridView ID="dgvCar" width= "1200" runat="server"></asp:GridView>
    </asp:Content>
