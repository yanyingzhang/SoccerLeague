<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ClubDetails.aspx.cs" Inherits="ClubDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="myContent" Runat="Server">
    <h3>Club Details:</h3>
    <p>
        <asp:Label ID="dbErrorLabel" runat="server"></asp:Label>
        <asp:Label ID="deleteLabel" runat="server"></asp:Label>
        <asp:GridView ID="clubDetailInfo" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
            <Columns>
                <asp:BoundField DataField="cname" HeaderText="Club" />
                <asp:BoundField DataField="ccity" HeaderText="City" />
                <asp:BoundField DataField="cnumber" HeaderText="Registration Number" />
                <asp:BoundField DataField="caddress" HeaderText="Address" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    </p>
    <asp:Button ID="backBtn" runat="server"   PostBackUrl="~/Clubs.aspx" Text="Back to club list" />
    <asp:Button ID="deleteClubBtn" runat="server" Text="Delete this club" OnClick="deleteClubBtn_Click" />
    <h3>Player List</h3>
    <p>
        <asp:GridView ID="playerGrid" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="playerGrid_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" >
          <Columns>
            <asp:BoundField DataField="playername" HeaderText="Name" />
            <asp:BoundField DataField="birthday" HeaderText="Birthday" />
            <asp:BoundField DataField="jnumber" HeaderText="Jersery Number" />
            <asp:ButtonField CommandName="Select" Text="Select" />
          </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
      </p>  
    <asp:DetailsView ID="playDetail" AutoGenerateRows="False" OnModeChanging="playDetail_ModeChanging" OnItemUpdating="playDetail_ItemUpdating" runat="server" Height="50px" Width="360px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
        <EditRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <Fields>
            <asp:TemplateField HeaderText="Name">
                <EditItemTemplate><asp:TextBox ID="editName" runat="server" Text='<%# Bind("playername") %>'></asp:TextBox></EditItemTemplate>
                <InsertItemTemplate><asp:TextBox ID="insertName" runat="server" Text='<%# Bind("playername") %>'></asp:TextBox></InsertItemTemplate>
                <ItemTemplate><asp:Label ID="nameLbl" runat="server" Text='<%# Bind("playername") %>'></asp:Label></ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Birthday">
                <EditItemTemplate><asp:TextBox ID="editBirthday" runat="server" Text='<%# Bind("birthday") %>'></asp:TextBox> </EditItemTemplate>
                <InsertItemTemplate><asp:TextBox ID="insertBirthday" runat="server" Text='<%# Bind("birthday") %>'></asp:TextBox> </InsertItemTemplate>
                <ItemTemplate><asp:Label ID="birthdayLbl" runat="server" Text='<%# Bind("birthday") %>'></asp:Label></ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Jersery Number">
                <EditItemTemplate><asp:TextBox ID="editJnumber" runat="server" Text='<%# Bind("jnumber") %>'>  </asp:TextBox></EditItemTemplate>
                <InsertItemTemplate><asp:TextBox ID="insertJnumber" runat="server" Text='<%# Bind("jnumber") %>'>  </asp:TextBox></InsertItemTemplate>
                <ItemTemplate><asp:Label ID="jnumLbl" runat="server" Text='<%# Bind("jnumber") %>'></asp:Label></ItemTemplate>
            </asp:TemplateField>

            <asp:CommandField ShowEditButton="True" />
        </Fields>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <HeaderTemplate>
            <%# Eval("playername") %>
        </HeaderTemplate>

        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />

    </asp:DetailsView>

    <asp:Label ID="ErrorLbl" runat="server"></asp:Label>
</asp:Content>

