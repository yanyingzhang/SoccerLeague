<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MatchScheduling.aspx.cs" Inherits="MatchScheduling" %>

<asp:Content ID="MatchContent" ContentPlaceHolderID="myContent" Runat="Server">
    <h3>Schedule A Game</h3>
    <asp:Calendar ID="scheduleCalendar" runat="server" SelectedDate="2018-03-23" BackColor="White"
        OnSelectionChanged="scheduleCalendar_SelectionChanged" OnDayRender="scheduleCalendar_DayRender" BorderColor="White" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px" BorderWidth="1px" >
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
        <NextPrevStyle Font-Size="8pt" ForeColor="#333333" Font-Bold="True" VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" BorderColor="Black" BorderWidth="4px" />
        <TodayDayStyle BackColor="#CCCCCC" />
    </asp:Calendar>
    <asp:Label ID="timeLbl" runat="server"></asp:Label>
    <br />
    <p> Host Team: 
    <asp:DropDownList ID="hostTeam" runat="server"></asp:DropDownList></p>
    <p>Guest Team:
    <asp:DropDownList ID="guestTeam" runat="server"></asp:DropDownList></p>
    
    <asp:Button ID="scheduleBtn" SkinID="btnSkin" Width="200px" runat="server" Text="Schedule a game" OnClick="scheduleBtn_Click" />
    <p><asp:Label ID="validateLbl" runat="server" ForeColor="Red" Visible="false">Team name cannot be the same.</asp:Label></p>
    <asp:Label ID="submitError" runat="server" ></asp:Label>
    <h3>Match Schedule:</h3>
    <asp:GridView ID="gameListGrid" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
        <Columns>
            <asp:BoundField DataField="matchDate" HeaderText="Date"  DataFormatString="{0:yy/MM/dd}" />
            <asp:BoundField DataField="hostClub" HeaderText="Host" />
            <asp:BoundField DataField="guestClub" HeaderText="Guest" />
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

    <asp:Label ID="gamesList" runat="server" ></asp:Label>
</asp:Content> 