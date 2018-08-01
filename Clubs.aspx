<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Clubs.aspx.cs" Inherits="Clubs" %>

<asp:Content ID="ClubsContent" ContentPlaceHolderID="myContent" Runat="Server">
    <h3>List of Clubs:</h3>
    <asp:GridView ID="clubGrid" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="clubGrid_SelectedIndexChanged" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
        <Columns>
            <asp:BoundField DataField="cname" HeaderText="Club" />
            <asp:BoundField DataField="ccity" HeaderText="City" />
            <asp:ButtonField CommandName="select" Text="Select"/>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle ForeColor="#333333" BackColor="White" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#487575" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#275353" />
    </asp:GridView>
        <asp:label ID="dbErrorLabel" runat="server"></asp:label>
</asp:Content>

