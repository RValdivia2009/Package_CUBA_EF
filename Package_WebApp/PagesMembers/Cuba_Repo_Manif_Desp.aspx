<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cuba_Repo_Manif_Desp.aspx.cs" Inherits="Package_WebApp.PageAdmin.Cuba_Repo_Manif_Desp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style4
        {
            width: 211px;
        }
        .style5
        {
            width: 142px;
        }
        .style6
        {
            width: 36px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <table class="style1" style="width: 319%; height: 486px;">
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                <span class="style4"><strong><em>
                <asp:DropDownList ID="tb_ManifiestoIMP" runat="server" AutoPostBack="True" 
                    Height="21px" onselectedindexchanged="tb_ManifiestoIMP_SelectedIndexChanged" 
                    style="font-size: x-small; font-weight: 700; color: #800000; font-family: 'Arial Black'" 
                    Width="156px">
                </asp:DropDownList>
&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButtonMani" runat="server" Height="27px" 
                    ImageUrl="~/Iconos/printer.png" onclick="ImageButtonMani_Click" Width="27px" />
                </em></strong></span>
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                <span class="style4"><strong><em>
                <asp:DropDownList ID="tb_AWB" runat="server" AutoPostBack="True" Height="19px" 
                    onselectedindexchanged="tb_AWB_SelectedIndexChanged" 
                    style="font-size: x-small; font-weight: 700; color: #800000; font-family: 'Arial Black'" 
                    Width="154px">
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButtonMani0" runat="server" Height="27px" 
                    ImageUrl="~/Iconos/printer.png" onclick="ImageButtonMani0_Click" Width="27px" />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                </em></strong></span>
            </td>
        </tr>
    </table>
    <p>
                                </p>
</asp:Content>

