<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddClub.aspx.cs" Inherits="AddClub" %>
<%@ Register TagPrefix="sp" TagName="SmartBox" Src="~/SmartBox.ascx" %>

<asp:Content ID="AddContent" ContentPlaceHolderID="myContent" Runat="Server" >
    <div id="clubDiv">
    <asp:Panel id="addclubPanel" runat="server">
    <h3>Add Club:</h3>
        <asp:Label ID="dbErrorMessage" runat="server"></asp:Label>
        <sp:SmartBox id="smart" runat="server" /> <!-- apply web user control-->
        <p>
            Registration Number:
            <asp:TextBox ID="reginumtxt" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reginumReq" runat="server" ForeColor="Red"
                ControlToValidate="reginumtxt" validationgroup="clubValidGroup"
                ErrorMessage="Registration number is required!"></asp:RequiredFieldValidator>
        </p>
        <p>
            Address:
            <asp:TextBox ID="addresstxt" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="saveBtn" SkinID="btnSkin" runat="server" Text="Save Club" OnClick="saveBtn_Click" validationgroup="clubValidGroup" />
            <asp:Button ID="cancelBtn" SkinID="btnSkin" runat="server" Text="Cancel" OnClick="cancelBtn_Click" />
        </p>
    </asp:Panel>

    <asp:Label ID="addClubLbl" runat="server" ForeColor="lightcoral"></asp:Label>
    </div>

    <div id="playerDiv">
    <asp:Panel ID="playerPanel" runat="server">
        <h3>Add player</h3>
        <p>Club Name: 
            <asp:DropDownList ID="selectClub" runat="server" />
        </p>
        <p>
            Player Name:
            <asp:TextBox ID="pnametxt" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="pnameVal" runat="server" ForeColor="Red"
                ControlToValidate="pnametxt" validationgroup="playerValidGroup"
                ErrorMessage="Name is required"></asp:RequiredFieldValidator>
        </p>
        <p>
            Date of birth: 
            <asp:TextBox ID="bdtxt" runat="server"></asp:TextBox>
            <asp:CompareValidator ID="bdVal" runat="server" validationgroup="playerValidGroup"
                ControlToValidate="bdtxt" Operator="DataTypeCheck" Type="Date" ForeColor="Red"
                ErrorMessage="Please enter a valid date"></asp:CompareValidator>
        </p>
        <p>
            Jersery Number: 
            <asp:TextBox ID="jnumtxt" runat="server"></asp:TextBox>
            <asp:RangeValidator ID="jnumCheck" runat="server" 
                ControlToValidate ="jnumtxt" Type="Integer" ForeColor="Red"
                MinimumValue="0" MaximumValue="99" validationgroup="playerValidGroup"
                ErrorMessage="Number must between 0 to 99"></asp:RangeValidator>
        </p>
        <p>
        <asp:Button ID="addPlayerBtn"  SkinID="btnSkin" runat="server" Text="Add Player" validationgroup="playerValidGroup" OnClick="addPlayerBtn_Click" />
        <asp:Button ID="cancelBtn2"  SkinID="btnSkin" runat="server" Text="Cancel" OnClick="cancelBtn2_Click"></asp:Button>
        </p>
        <p><asp:Label ID="playerlbl" runat="server" ForeColor="lightcoral"></asp:Label></p>
    </asp:Panel>
    </div>
</asp:Content>

