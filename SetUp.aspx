<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SetUp.aspx.cs" Inherits="SetTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="myContent" Runat="Server">
    <p>Please select the theme for the website.</p>
    <asp:RadioButton ID="lightTheme" runat="server" Text="Light" groupname="themeButton"/><br />
    <asp:RadioButton ID="darkTheme" runat="server" Text="Dark" groupname="themeButton"/><br />
    <asp:Button ID="Button" SkinID="btnSkin" runat="server" Text="Switch Theme" OnClick="Button_Click" />
</asp:Content>

