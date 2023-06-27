<%@ Page Title="Inspector page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmInspector.aspx.cs" Inherits="TheRideYouRentApp.frmInspector" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Inspecter Editing</h1>
    <div style="display: flex; flex-direction: column;">
    <asp:Label ID="lblInspectorNo" runat="server" Text="Inspecter Number :"></asp:Label>
    <asp:TextBox ID="txtInspectorNo" runat="server" Text=""></asp:TextBox>
  
    <asp:Label ID="lblName" runat="server" Text="Inspecter Name :"></asp:Label>
    <asp:TextBox ID="txtName" runat="server" Text=""></asp:TextBox>
   
    <asp:Label ID="lblSurname" runat="server" Text="Inspecter Surname :"></asp:Label>
    <asp:TextBox ID="txtSurname" runat="server" Text=""></asp:TextBox>
    
    <asp:Label ID="lblEmail" runat="server" Text="Inspecter Email :"></asp:Label>
    <asp:Textbox ID="txtEmail" runat="server" Text=""></asp:Textbox>

    <asp:Label ID="lblMobile" runat="server" Text="Inspecter Phone Number :"></asp:Label>
    <asp:TextBox ID="txtMobile" runat="server" Text=""></asp:TextBox>
    
    <asp:Label ID="lblPassword" runat="server" Text="Inspecter Password :"></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server" TextMode ="Password" Text=""></asp:TextBox>
    
        </div>

    <div style="display: flex; flex-direction: row;">

        <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" CssClass="btn btn-Primary" BorderColor="Black" />

        <asp:Button ID="btnRead" runat="server" Text="Read" OnClick="btnRead_Click" CssClass="btn btn-Primary" BorderColor="Black" />
        </div>
    <asp:Label ID="lblUpdate" runat="server" Text="Select Inspecter To Update :"></asp:Label>
    <asp:DropDownList ID="ddlUpdateInspecterNo" runat="server" OnSelectedIndexChanged="ddlUpdateInspecterNo_SelectedIndexChanged" ></asp:DropDownList>
    
    <asp:Label ID="lblFieldUpdate" runat="server" Text="Select Field To Update :"></asp:Label>
     <asp:DropDownList ID="ddlUpdate" runat="server" OnLoad="ddlUpdate_Load">
     </asp:DropDownList>
    <br />
    <asp:Label ID="lblUpdateMessage" runat="server" Text="Enter new Value :"></asp:Label>
    <asp:TextBox ID="txtUpdate" runat="server" Text=""></asp:TextBox>
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="btn btn-Primary" BorderColor="Black" />
    <br />
    <asp:Label ID="lblDelete" runat="server" Text="Select Inspecter ID to delete inspecter"></asp:Label>
        <asp:DropDownList ID="ddlDelete" runat="server" OnSelectedIndexChanged="ddlDelete_SelectedIndexChanged"></asp:DropDownList>
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="btn btn-Primary" BorderColor="Black" />
    <br />
    <asp:GridView ID="dgvCar" width= "1200" runat="server"></asp:GridView>
</asp:Content>
