<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cuba_PackageTarifas.aspx.cs" Inherits="Package_WebApp.Cuba_PackageTarifas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style3
    {
        height: 12px;
    }
    .style7
    {
        height: 169px;
    }
    .style8
    {
        color: #800000;
    }
        .style16
        {
            font-size: small;
            text-decoration: underline;
        }
        .style18
        {
            width: 36px;
            height: 169px;
        }
        .style19
        {
            width: 36px;
        }
        .style21
        {
            height: 169px;
            width: 360px;
        }
        .style22
        {
            width: 360px;
        }
        .style23
        {
            font-size: small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
    <tr>
        <td class="style18" valign="top">
            </td>
        <td class="style21" valign="top">
            <br />
&nbsp;<span class="style8"><strong><span 
                class="style16"><em>Miscelaneas<br />
            </em></span></strong></span><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" 
                        BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="2" 
                        DataKeyNames="id_Tarif_Micelaneos" DataSourceID="SqlDataSource1" GridLines="Horizontal" 
                        style="font-size: xx-small" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged" 
                Width="314px">
                <Columns>
                    <asp:CommandField ButtonType="Image" CancelImageUrl="~/Iconos/Cancel.png" 
                        EditImageUrl="~/Iconos/edit.png" ShowEditButton="True" 
                        UpdateImageUrl="~/Iconos/Ok-icon.png">
                    <ControlStyle Height="18px" Width="18px" />
                    <HeaderStyle Width="30px" />
                    </asp:CommandField>
                    <asp:BoundField DataField="id_Tarif_Micelaneos" InsertVisible="False" 
                        ReadOnly="True" SortExpression="id_Tarif_Micelaneos">
                    <HeaderStyle Width="3px" />
                    <ItemStyle ForeColor="White" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Zona" HeaderText="Zona" SortExpression="Zona">
                    <ControlStyle Font-Size="X-Small" Width="30px" />
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Font-Bold="True" Width="30px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="M_Rate" HeaderText="M_Rate" SortExpression="M_Rate">
                    <ControlStyle Font-Size="X-Small" Width="40px" />
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Width="40px" />
                    </asp:BoundField>
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:DB_82130_itndatabaseConnectionString %>" 
                InsertCommand="INSERT INTO tbl_Cuba_N_Tarif_Miscelaneos(id_Tarif_Micelaneos, Zona, M_Rate) VALUES (@id_Tarif_Micelaneos, @Zona, @M_Rate)" 
                SelectCommand="SELECT id_Tarif_Micelaneos, Zona, M_Rate FROM tbl_Cuba_N_Tarif_Miscelaneos" 
                UpdateCommand="UPDATE tbl_Cuba_N_Tarif_Miscelaneos SET Zona = @Zona, M_Rate = @M_Rate WHERE (id_Tarif_Micelaneos = @id_Tarif_Micelaneos)">
                <InsertParameters>
                    <asp:Parameter Name="id_Tarif_Micelaneos" />
                    <asp:Parameter Name="Zona" />
                    <asp:Parameter Name="M_Rate" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Zona" />
                    <asp:Parameter Name="M_Rate" />
                    <asp:Parameter Name="id_Tarif_Micelaneos" />
                </UpdateParameters>
            </asp:SqlDataSource>
            </td>
        <td class="style7" valign="top">
            <strong><em>
            <span class="style8">
            <span class="style16">
            <br />
            Duraderos</span><span class="style23">&nbsp;&nbsp; </span>
            <asp:DropDownList ID="Drop_Zonas" runat="server" AutoPostBack="True" 
                Font-Bold="True" Height="16px" 
                onselectedindexchanged="Drop_Zonas_SelectedIndexChanged" Width="92px">
            </asp:DropDownList>
            <br />
            </span></em></strong>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" 
                        BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="2" 
                        DataKeyNames="id_tarif_Duraderos" DataSourceID="SqlDataSource2" GridLines="Horizontal" 
                        style="font-size: xx-small" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged" 
                Width="501px">
                <Columns>
                    <asp:CommandField ButtonType="Image" CancelImageUrl="~/Iconos/Cancel.png" 
                        EditImageUrl="~/Iconos/edit.png" ShowEditButton="True" 
                        UpdateImageUrl="~/Iconos/Ok-icon.png">
                    <ControlStyle Height="15px" Width="15px" />
                    <HeaderStyle Width="20px" />
                    </asp:CommandField>
                    <asp:BoundField DataField="id_tarif_Duraderos" InsertVisible="False" 
                        ReadOnly="True" SortExpression="id_tarif_Duraderos" 
                        HeaderText="id_tarif_Duraderos" Visible="False">
                    </asp:BoundField>
                    <asp:BoundField DataField="Zonas" HeaderText="Zonas" SortExpression="Zonas" 
                        ReadOnly="True">
                    <ControlStyle Width="10px" />
                    <HeaderStyle Width="15px" />
                    <ItemStyle HorizontalAlign="Center" Width="10px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Desde" HeaderText="Desde" SortExpression="Desde">
                    <ControlStyle Width="42px" />
                    <HeaderStyle Width="25px" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Hasta" HeaderText="Hasta" SortExpression="Hasta">
                    <ControlStyle Width="42px" />
                    <HeaderStyle Width="25px" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="D_Costo" HeaderText="Costo/Lb" 
                        SortExpression="D_Costo">
                    <ControlStyle Width="42px" />
                    <HeaderStyle Width="25px" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="D_Rate" HeaderText="Precio/Lb" 
                        SortExpression="D_Rate">
                    <ControlStyle Width="42px" />
                    <HeaderStyle Width="25px" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
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
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:DB_82130_itndatabaseConnectionString %>" 
                SelectCommand="SELECT id_tarif_Duraderos, Zonas, Desde, Hasta, D_Costo, D_Rate FROM tbl_Cuba_N_tarif_Duraderos WHERE (Zonas = @mZona)" 
                
                UpdateCommand="UPDATE tbl_Cuba_N_tarif_Duraderos SET D_Rate = @D_Rate, Desde = @Desde, Hasta = @Hasta, D_Costo = @D_Costo WHERE (id_tarif_Duraderos = @id_tarif_Duraderos)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Drop_Zonas" DefaultValue="A1" Name="mZona" 
                        PropertyName="SelectedValue" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="D_Rate" />
                    <asp:Parameter Name="Desde" />
                    <asp:Parameter Name="Hasta" />
                    <asp:Parameter Name="D_Costo" />
                    <asp:Parameter Name="id_tarif_Duraderos" />
                </UpdateParameters>
            </asp:SqlDataSource>
            </td>
    </tr>
    <tr>
        <td class="style19">
            &nbsp;</td>
        <td class="style22">
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
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
