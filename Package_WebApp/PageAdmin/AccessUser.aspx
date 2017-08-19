<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterAdmin.master" AutoEventWireup="true" CodeBehind="AccessUser.aspx.cs" Inherits="Package_WebApp.PageAdmin.AccessUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 82%">
    <tr>
        <td rowspan="6" style="width: 27px" valign="top">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:GridView ID="GridView1" runat="server" 
                onselectedindexchanged="GridView1_SelectedIndexChanged" Width="274px" 
                style="font-size: x-small">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </td>
        <td rowspan="6" style="width: 10px">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="bold" style="color: #993300; " valign="top">
            <strong>User:<br />
            <br />
            Rule:</strong></td>
        <td valign="top">
            <asp:TextBox ID="TextBox_User" runat="server" Width="191px" ReadOnly="True"></asp:TextBox>
            &nbsp;&nbsp;
            <br />
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                style="color: #990000; font-weight: 700">
                <asp:ListItem>Usuario</asp:ListItem>
                <asp:ListItem>Admin</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td valign="top">
            &nbsp;</td>
        <td valign="top">
            <asp:Button ID="Update" runat="server" onclick="Update_Click" 
                Text="Assign Role" style="color: #990000; font-weight: 700" />
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Delete" runat="server" 
                onclick="Delete_Click" Text="Delete Role" 
                Width="86px" style="color: #FF0000; font-weight: 700" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
    </tr>
    <tr>
        <td rowspan="3">
        &nbsp;&nbsp;&nbsp;
            </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="TextBox_ID_User" runat="server" ReadOnly="True" 
                Visible="False" Width="233px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="TextBox_IdRol" runat="server" Visible="False" Width="229px"></asp:TextBox>
            <asp:Label ID="LabelUser" runat="server" Text="Label" Visible="False"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>
