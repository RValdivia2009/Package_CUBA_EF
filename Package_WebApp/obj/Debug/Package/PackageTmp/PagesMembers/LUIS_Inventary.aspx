<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LUIS_Inventary.aspx.cs" Inherits="Package_WebApp.PagesMembers.LUIS_Inventary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .style3
        {
            color: #800000;
        }
        </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
<table class="style1">
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;&nbsp;&nbsp;&nbsp; <span class="style3"><strong>No Manifiesto o Inventario<br />
            </strong></span>&nbsp; &nbsp;&nbsp;&nbsp; <span class="style25">&nbsp;<asp:TextBox ID="TextBoxDest" 
                runat="server" 
                style="color: #800000; font-weight: 700; font-size: large; text-align: center" 
                Width="205px"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" Width="828px" Height="65px">
                &nbsp;&nbsp;
                <asp:FileUpload ID="FileUpload1" runat="server" Height="22px" Width="209px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="style25">
                <asp:Button ID="Button2" runat="server" Height="20px" onclick="Button2_Click1" 
                    style="color: #990000; font-weight: 700" Text="Upload" Width="83px" />
                </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="style25"><asp:Button ID="insert" runat="server" 
                    Height="21px" onclick="insert_Click" style="font-weight: 700; color: #FF0000" 
                    Text="Insert" Width="126px" />
                <asp:Button ID="cancel" runat="server" Height="21px" onclick="cancel_Click" 
                    style="font-weight: 700; color: #FF0000" Text="Cancel" Width="126px" />
                </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:HyperLink runat="server" 
                    NavigateUrl="~/PagesMembers/LUIS_Inventario.aspx">Hacer Inventario</asp:HyperLink>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="style25"><br /> &nbsp;&nbsp;<strong><span class="style6">( *.xls or 
                xlsx files only )</span></strong> </span>&nbsp;&nbsp;<asp:Label ID="Label3" 
                    runat="server" style="color: #FF3300; font-weight: 700; font-size: medium;" 
                    Text="Label"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </asp:Panel>
            </span>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <span class="style25"><span __designer:mapid="60" class="style3">&nbsp;<asp:Panel 
                ID="Panel2" runat="server" Width="822px">
                <span class="style25">&nbsp; &nbsp; &nbsp;<span class="style3">Total de Paquetes:&nbsp;&nbsp;
                <asp:Label ID="T_Paquetes" runat="server" CssClass="style4" 
                    style="font-size: large" Text="Label"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Peso total:&nbsp;
                <asp:Label ID="T_Peso" runat="server" CssClass="style4" 
                    style="font-size: large" Text="Label"></asp:Label>
                &nbsp; Kg&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="T_PesoLb" runat="server" CssClass="style4" 
                    style="font-size: large" Text="Label"></asp:Label>
                &nbsp;Lbs.&nbsp; </span></span>
            </asp:Panel>
            </span></span></td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:GridView ID="GridView1" runat="server" 
                onrowdatabound="GridView1_RowDataBound" ShowFooter="True" Width="833px">
            </asp:GridView>
        </td>
    </tr>
</table>
<br />
<asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
<asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
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
</asp:Content>
