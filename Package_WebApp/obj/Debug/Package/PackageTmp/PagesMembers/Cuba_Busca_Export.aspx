<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cuba_Busca_Export.aspx.cs" Inherits="Package_WebApp.PageAdmin.Cuba_Busca_Export" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style4
        {
            width: 64px;
        }
        .style5
        {
            width: 64px;
            height: 32px;
        }
        .style6
        {
            width: 46px;
        }
        .style7
        {
            width: 482px;
        }
        .style8
        {
            color: #990000;
            font-size: small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <table class="style1" style="width: 1256%; height: 543px;">
        <tr>
            <td class="style6" valign="top">
                &nbsp;</td>
            <td colspan="2" valign="top">
                <asp:TextBox ID="Tb_AWB" runat="server" placeholder="---AWB----" Width="188px"></asp:TextBox>
&nbsp;
                <asp:ImageButton ID="ImageButton1" runat="server" Height="17px" 
                    ImageUrl="~/Iconos/find.png" onclick="ImageButton1_Click" Width="26px" />
&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;&nbsp;
                <asp:Button ID="export" runat="server" onclick="export_Click" 
                    Text="Exportar DBF" />
                <br />
            </td>
        </tr>
        <tr>
            <td class="style6" valign="top">
                &nbsp;</td>
            <td class="style7" valign="top">
                <asp:GridView ID="GridView1" runat="server" Width="453px">
                </asp:GridView>
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
                <br />
                <br />
            </td>
            <td valign="top">
                &nbsp; &nbsp;<asp:Panel ID="Panel1" runat="server" Height="164px" Width="418px">
                    &nbsp;&nbsp;<span class="style8">Se crearan</span>:
                    <asp:Label ID="Lab_Fiche" runat="server" Font-Size="Small" Text="Label"></asp:Label>
                    &nbsp;<span class="style8">ficheros DBF en:
                    <asp:Label ID="Lab_FicheZIP" runat="server" Font-Size="Small" Text="Label" 
                        ForeColor="Black"></asp:Label>
                    </span><br /> &nbsp;<asp:GridView ID="GridView2" 
                        runat="server">
                        <RowStyle Font-Size="Small" />
                    </asp:GridView>
                    <br />
                    <br />
                </asp:Panel>
            </td>
        </tr>
        </table>
    <p>
                                </p>
                            </asp:Content>

