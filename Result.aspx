<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Result.aspx.cs" Inherits="Result" %>

<asp:Content ID="resultContent" ContentPlaceHolderID="myContent" Runat="Server">
    <h3>Match Results</h3>
   
    <p>
    <asp:GridView ID="gameGrid" runat="server" AutoGenerateColumns="False" AllowSorting="True" OnSorting="gameGrid_Sorting" OnSelectedIndexChanged="GridView_SelectedIndexChanged" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
        <Columns>
            <asp:TemplateField HeaderText="Date" SortExpression="matchdate">
                <ItemTemplate>
                    <asp:label id="dateLbl" runat="server" text='<%#Bind("matchdate","{0:yy/MM/dd}") %>' ></asp:label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:label id="eidLateLbl" runat="server" text='<%#Bind("matchdate") %>'></asp:label>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Host Club">
                <ItemTemplate>
                    <asp:label id="hostClubLbl" runat="server" text='<%#Bind("hostClub") %>'></asp:label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:label id="eidHostLbl" runat="server" text='<%#Bind("hostClub") %>'></asp:label>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Goals">
                <ItemTemplate>
                    <asp:label id="resultLbl" runat="server" text='<%#Bind("result") %>'></asp:label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="eidResultTB" runat="server" text='<%#Bind("result") %>' ></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Guest Club">
                <ItemTemplate>
                    <asp:label id="guestClubLbl" runat="server" text='<%#Bind("guestClub") %>'></asp:label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:label id="eidGuestClubLbl" runat="server" text='<%#Bind("guestClub") %>'></asp:label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField CommandName="Select" Text="Select" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#487575" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#275353" />
    </asp:GridView>
    </p>
    <p>
            <asp:DetailsView ID="gameDetail" runat="server" OnModeChanging="DetailsView_ModeChanging" OnItemUpdating="DetailsView_ItemUpdating" Height="50px" Width="250px" AutoGenerateRows="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                <EditRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <Fields>
            <asp:TemplateField HeaderText="Date">
                <EditItemTemplate><asp:Label ID="editDateLbl" runat="server" Text='<%# Bind("matchdate","{0:yy/MM/dd}") %>'></asp:Label></EditItemTemplate>
                <InsertItemTemplate><asp:Label ID="insertDateLbl" runat="server" Text='<%# Bind("matchdate","{0:yy/MM/dd}") %>'></asp:Label></InsertItemTemplate>
                <ItemTemplate><asp:Label ID="dateLbl" runat="server" Text='<%# Bind("matchdate","{0:yy/MM/dd}") %>' ></asp:Label></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Host Club">
                <EditItemTemplate><asp:Label ID="editHostLbl" runat="server" Text='<%# Bind("hostClub") %>'></asp:Label></EditItemTemplate>
                <InsertItemTemplate><asp:Label ID="insertHostLbl" runat="server" Text='<%# Bind("hostClub") %>'></asp:Label></InsertItemTemplate>
                <ItemTemplate><asp:Label ID="hostLbl" runat="server" Text='<%# Bind("hostClub") %>'></asp:Label></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Guest Club">
                <EditItemTemplate><asp:Label ID="editGuestLbl" runat="server" Text='<%# Bind("guestClub") %>'></asp:Label></EditItemTemplate>
                <InsertItemTemplate><asp:Label ID="insertGuestLbl" runat="server" Text='<%# Bind("guestClub") %>'></asp:Label></InsertItemTemplate>
                <ItemTemplate><asp:Label ID="guestLbl" runat="server" Text='<%# Bind("guestClub") %>'></asp:Label></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Goals">
                <EditItemTemplate><asp:TextBox ID="editResultTB" runat="server" Text='<%# Bind("result") %>'></asp:TextBox></EditItemTemplate>
                <InsertItemTemplate> <asp:TextBox ID="insertResultTB" runat="server" Text='<%# Bind("result") %>'></asp:TextBox></InsertItemTemplate>
                <ItemTemplate><asp:Label ID="resultLbl" runat="server" Text='<%# Bind("result") %>'></asp:Label></ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
        </Fields>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
    </asp:DetailsView>
    </p>
    <asp:Label id="msgLbl" runat="server" ></asp:Label>
</asp:Content>

