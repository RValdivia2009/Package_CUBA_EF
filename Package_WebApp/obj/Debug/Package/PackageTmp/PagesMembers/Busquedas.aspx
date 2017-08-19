<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Busquedas.aspx.cs" Inherits="Package_WebApp.PagesMembers.Busquedas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="width: 89%">
    <tr>
        <td colspan="5" style="border-style: solid; border-width: 1px" valign="middle">
            <br />
&nbsp;&nbsp;
            <asp:CheckBox ID="checkFechas" runat="server" AutoPostBack="True" 
                oncheckedchanged="CheckBox1_CheckedChanged" 
                style="font-weight: 700; color: #990000" Text="Do you want date select??" />
            &nbsp;&nbsp; <span style="color: #800000">Date from</span>&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="f_desde" runat="server" Height="17px" Width="93px"></asp:TextBox>
&nbsp;<span style="color: #800000">Date to:</span>&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="f_hasta" runat="server" Height="17px" Width="89px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton1" runat="server" Height="31px" 
                                ImageUrl="~/Iconos/Busca-icon.png" onclick="ImageButton1_Click" 
                        Width="31px" />
                            
            &nbsp;&nbsp;
                            
            <strong><span class="style14"><span class="style16">
            <asp:ImageButton ID="ImageButtonExcel" runat="server" Height="31px" 
                ImageUrl="~/Iconos/Excel.jpg" onclick="ImageButtonExcel_Click" 
                style="margin-left: 0px; text-align: center;" Width="31px" />
            </span></span></strong>
                            
            <br />
        </td>
    </tr>
    <tr>
        <td valign="top" colspan="6">
        </td>
    </tr>
    <tr>
        <td valign="top" class="style9">
            Destination:<br />
            <asp:DropDownList ID="tb_Sender" runat="server" Height="16px" Width="142px">
            </asp:DropDownList>
        </td>
        <td valign="top" class="style17">
            &nbsp;&nbsp;&nbsp;
            Telefono:<br />
            &nbsp;&nbsp;
            <asp:TextBox ID="telefono" runat="server" placeholder="No. Telefono." 
                    Height="14px" style="text-align: center" Width="111px" 
                    ontextchanged="telefono_TextChanged" Font-Size="X-Small"></asp:TextBox>
        </td>
        <td valign="top" class="style10">
&nbsp; Estado:&nbsp;<br />
            &nbsp;<asp:DropDownList ID="tb_Estado" runat="server" Height="16px" 
                Width="133px">
            </asp:DropDownList>
        </td>
        <td valign="top" class="style15">
&nbsp;&nbsp;Tipo de Envio:&nbsp;&nbsp;<br />
            <asp:DropDownList ID="tb_Tipo_Envio" runat="server" Height="16px" Width="156px">
            </asp:DropDownList>
        &nbsp;</td>
        <td valign="top" class="style18">
            &nbsp;&nbsp;&nbsp;&nbsp;
            AWB:<br />
            &nbsp;&nbsp;
            <asp:TextBox ID="TextBoxAWB" runat="server" Width="109px" Height="14px"></asp:TextBox>
                            
                    <br />
        &nbsp;
        </td>
        <td valign="middle" class="style12">
                            
                    &nbsp;
                                        
                    </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="5" style="border-top-style: solid; border-top-width: 1px">
            <asp:GridView ID="GridView1" runat="server" style="font-size: xx-small" 
                Width="977px" Height="65px">
            </asp:GridView>
            <br />
        </td>
    </tr>
    <tr>
        <td colspan="5">
            <br />
                    <asp:TextBox ID="id_Sender" runat="server" Width="67px" 
                        Height="14px" Visible="False"></asp:TextBox>
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
    </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .style9
        {
            width: 71px;
        }
        .style10
        {
            width: 147px;
        }
        .style12
        {
            width: 77px;
        }
        .style15
        {
            width: 91px;
        }
        .style14
        {
            width: 74px;
        }
        .style16
        {
            width: 146px;
        }
        .style17
        {
            width: 153px;
        }
        .style18
        {
        }
    </style>
</asp:Content>

