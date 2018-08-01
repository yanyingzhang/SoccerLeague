<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SmartBox.ascx.cs" Inherits="AddItem" %>

<p>
<asp:Label ID="clubNameLbl" runat="server" Text="Club Name: "></asp:Label>
<asp:TextBox ID="cnametxt" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="cnameReq" runat="server" ForeColor="Red"
                ControlToValidate="cnametxt" validationgroup="clubValidGroup"
                ErrorMessage="Club name is required!"></asp:RequiredFieldValidator>
</p>
<p>
<asp:Label ID="clubCityLbl" runat="server" Text="Club City: "></asp:Label>
<asp:TextBox ID="citytxt" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="cityReq" runat="server" ForeColor="Red"
                ControlToValidate="citytxt" validationgroup="clubValidGroup"
                ErrorMessage="Club city is required!"></asp:RequiredFieldValidator>
</p>