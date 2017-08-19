<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LUIS_Inventario.aspx.cs" Inherits="Package_WebApp.PagesMembers.LUIS_Inventario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .style11
        {
            width: 661px;
        }
        .style6
        {
            font-size: small;
        }
        .style14
        {
            width: 656px;
        }
        .style9
        {
            font-weight: normal;
            color: #000000;
        }
        .style3
        {
            width: 597px;
        }
        .style16
        {
            width: 331px;
            height: 22px;
        }
        .style17
        {
            width: 290px;
            height: 22px;
        }
        .style18
        {
            width: 345px;
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        <table class="style1">
            <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<span style="color: #993300"><strong><span 
                        style="font-size: medium; text-align: left"><span 
                        style="text-decoration: underline"><em>Scanning packages&nbsp;&nbsp;</em></span></span></strong></span></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <table style="width: 100%; height: 302px;">
                        <tr>
                            <td class="style11" colspan="2" 
                                style="border-left: 1px solid #0000FF; border-right: 1px solid #0000FF; border-top: 1px solid #0000FF; font-weight: 700;" 
                                valign="top">
                                <span style="color: #993300">&nbsp; <span class="style25">
                                <asp:TextBox ID="Despacho" runat="server" ontextchanged="Despacho_TextChanged " 
                                    placeholder="No de Manif." 
                                    style="color: #800000; font-weight: 700; font-size: medium; text-align: center" 
                                    Width="114px"></asp:TextBox>
                                </span>&nbsp;
                                <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" 
                                    ImageUrl="~/Iconos/checkmark.png" onclick="ImageButton1_Click" Width="30px" />
                                &nbsp;&nbsp;&nbsp;</span>&nbsp;
                                <asp:HyperLink ID="HyperLink1" runat="server" 
                                    NavigateUrl="~/PagesMembers/Reports/LUIS_Manif_Report1.aspx">Imprimir Manifiesto</asp:HyperLink>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" 
                                    Font-Size="X-Small" ForeColor="Red" onclick="LinkButton2_Click" 
                                    OnClientClick="return confirm('¿Esta seguro de eliminar este registro?');">ELIMINAR MANIFIESTO SELECTED</asp:LinkButton>
                            </td>
                            <td rowspan="4" 
                                style="border-right: 1px solid #0000FF; border-top: 1px solid #0000FF; border-bottom: 1px solid #0000FF; font-weight: 700; " 
                                valign="top">
                                <span style="color: #993300"><span style="font-size: medium; text-align: left">&nbsp;<span 
                                    style="color: #000000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span><span style="color: #000000">
                                <span class="style6" style="text-align: left">Rapack No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; No Paquete:</span></span></span><br />
                                &nbsp;&nbsp;<span style="color: #000000">&nbsp;<asp:TextBox ID="Repack" runat="server" 
                                    Height="19px" Width="35px"></asp:TextBox>
                                &nbsp;&nbsp;
                                <asp:TextBox ID="Trackeo" runat="server" AutoPostBack="True" Height="19px" 
                                    ontextchanged="Trackeo_TextChanged" Width="127px"></asp:TextBox>
                                &nbsp;&nbsp;
                                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                                    style="font-weight: 700; color: #800000" Text="Load" Width="64px" />
                                &nbsp;&nbsp;<asp:Button ID="Unload" runat="server" onclick="Unload_Click" 
                                    style="font-weight: 700; color: #800000" Text="Unload" />
                                &nbsp;&nbsp; </span>
                                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                                    style="font-weight: 700; color: #FF0000" Text="Unload ALL" Width="88px" />
                                &nbsp; <strong><span class="style14"><span class="style16">
                                <asp:ImageButton ID="ImageButtonExcel" runat="server" Height="40px" 
                                    ImageUrl="~/Iconos/Excel.jpg" onclick="ImageButtonExcel_Click" 
                                    style="margin-left: 0px; text-align: center;" Width="40px" />
                                </span></span></strong>
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="style9">Paq</span><span 
                                    style="color: #993300">:&nbsp;<span class="style25"><span __designer:mapid="60" 
                                    class="style3">
                                <asp:Label ID="T_Paquetes1" runat="server" CssClass="style7" Text="Label"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span>
                                <br />
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                    CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="Black" 
                                    GridLines="Horizontal" onrowdatabound="GridView2_RowDataBound" 
                                    onselectedindexchanged="GridView2_SelectedIndexChanged" ShowFooter="True" 
                                    style="font-size: x-small" Width="521px" AllowSorting="True">
                                    <Columns>
                                        <asp:BoundField DataField="Paquete" HeaderText="Paquete" 
                                            SortExpression="Paquete" />
                                        <asp:BoundField DataField="Peso" HeaderText="Peso" SortExpression="Peso" />
                                        <asp:BoundField DataField="Envio" HeaderText="Envio" SortExpression="Envio" />
                                        <asp:BoundField DataField="Inv" SortExpression="Inv" HeaderText="Inv">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DireccionRem" HeaderText="DireccionRem" 
                                            SortExpression="DireccionRem" />
                                        <asp:BoundField DataField="Repack" HeaderText="Repack" 
                                            SortExpression="Repack" />
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
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:DB_82130_itndatabaseConnectionString %>" 
                                    
                                    SelectCommand="SELECT Paquete, Peso, Envio, Inv, DireccionRem, Repack FROM LUIS_Scanning WHERE (Inv = @Inv) AND (DireccionRem = @DireccionRem) ORDER BY Paquete">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="1" Name="Inv" Type="Int32" />
                                        <asp:ControlParameter ControlID="id_Despacho" Name="DireccionRem" 
                                            PropertyName="Text" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <br />
                                <asp:Image ID="Image2" runat="server" Height="26px" style="text-align: left" 
                                    Visible="False" Width="201px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style17" style="border-right: 1px solid #0000FF; font-weight: 700;" 
                                valign="top">
                                <asp:Panel ID="Panel1" runat="server" Height="18px" Width="300px">
                                    <span class="style9">Paq</span><span style="color: #993300">:&nbsp;<span 
                                        class="style25"><span class="style3"><asp:Label ID="T_Paquetes" 
                                        runat="server" CssClass="style7" Text="Label"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><span class="style25"><span class="style3">
                                    <span class="style9">Peso</span><span style="color: #993300">:
                                    <asp:Label ID="T_Peso" runat="server" CssClass="style7" Text="Label"></asp:Label>
                                    &nbsp; </span><span class="style9">Kg</span><span style="color: #993300"> -
                                    <asp:Label ID="T_PesoLb" runat="server" CssClass="style7" Text="Label"></asp:Label>
                                    </span></span></span><span style="color: #993300">&nbsp;</span><span class="style9">Lbs&nbsp;&nbsp;
                    <br />
                                    </span>
                                </asp:Panel>
                            </td>
                            <td class="style18" style="border-right: 1px solid #0000FF; font-weight: 700;" 
                                valign="top">
                                <asp:LinkButton ID="linkEliminar" runat="server" CommandName="Delete" 
                                    Font-Size="X-Small" ForeColor="Red" onclick="linkEliminar_Click" 
                                    OnClientClick="return confirm('¿Esta seguro de eliminar este registro?');">ELIMINAR REGISTRO SELECCTED </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td class="style11" colspan="2" 
                                style="border-left: 1px solid #0000FF; border-right: 1px solid #0000FF; font-weight: 700;" 
                                valign="top">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                    CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" 
                                    GridLines="Horizontal" Height="183px" onrowdatabound="GridView1_RowDataBound" 
                                    onselectedindexchanged="GridView1_SelectedIndexChanged1" ShowFooter="True" 
                                    style="font-size: x-small" Width="479px">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True">
                                        <ControlStyle Font-Size="X-Small" />
                                        <ItemStyle Font-Size="Small" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="Paquete" HeaderText="Paquete" 
                                            SortExpression="Paquete">
                                        <HeaderStyle Width="120px" />
                                        <ItemStyle Font-Size="X-Small" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Peso" HeaderText="Peso" SortExpression="Peso">
                                        <HeaderStyle Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Envio" HeaderText="Envio" SortExpression="Envio">
                                        <HeaderStyle Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DireccionRem" HeaderText="Manifiesto" 
                                            SortExpression="DireccionRem" />
                                        <asp:BoundField DataField="Inv" SortExpression="Inv">
                                        <ControlStyle Width="5px" />
                                        <FooterStyle Width="5px" />
                                        <HeaderStyle Width="2px" />
                                        <ItemStyle ForeColor="White" Width="5px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Check">
                                            <ItemTemplate>
                                                <asp:Image ID="ImgSemaforo" runat="server" CausesValidation="False" />
                                            </ItemTemplate>
                                            <ControlStyle Height="15px" Width="15px" />
                                            <ItemStyle Font-Size="XX-Small" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="id_Paquete" InsertVisible="False" ReadOnly="True" 
                                            SortExpression="id_Paquete">
                                        <HeaderStyle Width="3px" />
                                        <ItemStyle ForeColor="White" />
                                        </asp:BoundField>
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
                            </td>
                        </tr>
                        <tr>
                            <td class="style11" colspan="2" 
                                style="border-left: 1px solid #0000FF; border-right: 1px solid #0000FF; border-bottom: 1px solid #0000FF; font-weight: 700;" 
                                valign="top">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:DB_82130_itndatabaseConnectionString %>" 
                                    DeleteCommand="DELETE FROM LUIS_Scanning" 
                                    SelectCommand="SELECT Paquete, Peso, Envio, DireccionRem, Inv, id_Paquete FROM LUIS_Scanning WHERE (DireccionRem = @DireccionRem)">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="id_Despacho" Name="DireccionRem" 
                                            PropertyName="Text" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <span style="color: #993300">
                                <br />
                                <asp:TextBox ID="id_Despacho" runat="server" Width="68px"></asp:TextBox>
                                <asp:TextBox ID="id_Unload" runat="server" Visible="False" Width="68px"></asp:TextBox>
                                <asp:TextBox ID="id_PaqNo" runat="server" Visible="False"></asp:TextBox>
                                &nbsp;</span>&nbsp; <span style="color: #993300">
                                <asp:TextBox ID="id_paq_ToDelete" runat="server" Visible="False" Width="82px"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button5" runat="server" onclick="Button5_Click" Text="Button" />
                                </span>
                            </td>
                        </tr>
                    </table>
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
    </p>
</asp:Content>
