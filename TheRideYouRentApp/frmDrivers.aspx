<%@ Page Title="Driver Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDrivers.aspx.cs" Inherits="TheRideYouRentApp.frmDrivers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Driver Editing</h1>
    <div style="display: flex; flex-direction: column;">  
    <asp:Label ID="lblDriverID" runat="server" Text="Driver ID :"></asp:Label>
    <asp:TextBox ID="txtDriverID" runat="server" Text=""></asp:TextBox>

    <asp:Label ID="lblName" runat="server" Text="Driver Name :"></asp:Label>
    <asp:TextBox ID="txtName" runat="server" Text=""></asp:TextBox>
   
    <asp:Label ID="lblSurname" runat="server" Text="Driver surname :"></asp:Label>
    <asp:TextBox ID="txtSurname" runat="server" Text=""></asp:TextBox>
    
    <asp:Label ID="lblAddress" runat="server" Text="Driver address :"></asp:Label>
    <asp:Textbox ID="txtAddress" runat="server" Text=""></asp:Textbox>

    <asp:Label ID="lblEmail" runat="server" Text="Driver Email :"></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server" Text=""></asp:TextBox>
    
    <asp:Label ID="lblMobile" runat="server" Text="Driver Phone number :"></asp:Label>
    <asp:TextBox ID="txtMobile" runat="server" Text=""></asp:TextBox>
    
        </div>
    <div style="display: flex; flex-direction: row;">
        <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" CssClass="btn btn-Primary" BorderColor="Black" />
        <asp:Button ID="btnRead" runat="server" Text="Read" OnClick="btnRead_Click" CssClass="btn btn-Primary" BorderColor="Black" />
        </div>
    <asp:Label ID="lblUpdate" runat="server" Text="Select Driver To Update :"></asp:Label>
        <asp:DropDownList ID="ddlUpdateDriverID" runat="server" OnSelectedIndexChanged="ddlUpdateDriverID_SelectedIndexChanged" ></asp:DropDownList>
    <asp:Label ID="lblFieldUpdate" runat="server" Text="Select Field To Update :"></asp:Label>
     <asp:DropDownList ID="ddlUpdate" runat="server" OnLoad="ddlUpdate_Load">
     </asp:DropDownList>
    <br />
    <asp:Label ID="lblUpdateMessage" runat="server" Text="Enter new Value :"></asp:Label>
    <asp:TextBox ID="txtUpdate" runat="server" Text=""></asp:TextBox>
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="btn btn-Primary" BorderColor="Black" />
    <br />
    <asp:Label ID="lblFieldDelete" runat="server" Text="Select Driver ID to Delete"></asp:Label>
        <asp:DropDownList ID="ddlDelete" runat="server" OnSelectedIndexChanged="ddlDelete_SelectedIndexChanged"></asp:DropDownList>
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="btn btn-Primary" BorderColor="Black" />
    <br />
    <asp:GridView ID="dgvDriver" width= "1200" runat="server"></asp:GridView>
</asp:Content>
