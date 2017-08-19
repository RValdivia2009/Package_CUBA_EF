<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cuba_PackageBusquedas.aspx.cs" Inherits="Package_WebApp.PageAdmin.Cuba_PackageBusquedas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

    .style4
    {
        height: 5px;
        width: 268435104px;
    }
    .style6
    {
        height: 20px;
        width: 268435104px;
    }
    .style7
    {
        width: 268435104px;
    }
        .style8
        {
            width: 567px;
            text-align: center;
        }
        .style9
        {
            width: 797px;
        }
        .style11
        {
            width: 263px;
        }
    .style13
    {
        padding: 0;
        border-bottom-style: solid;
        border-bottom-width: 1px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1" style="height: 695px">
        <tr>
            <td class="style13" valign="top" colspan="2">
                &nbsp;
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="telefono" Display="Dynamic" 
        ErrorMessage="Teléfono incorrecto." style="color: #FF0000; font-size: small" 
        ValidationExpression="(\(\d{3}\)\d{3}-\d{4})|(\d{10})"></asp:RegularExpressionValidator>
                <br />
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="telefono" runat="server" Height="17px" 
        ontextchanged="telefono_TextChanged" placeholder="No. Telefono." 
        style="text-align: center" Width="92px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="NoPaquete" runat="server" Height="17px" 
        ontextchanged="NoPaquete_TextChanged" placeholder="NoPaquete" 
        style="text-align: center" Width="92px"></asp:TextBox>
                &nbsp;&nbsp;
    <asp:ImageButton ID="ImageButton1" runat="server" Height="19px" 
        ImageUrl="~/Iconos/find.png" onclick="ImageButton1_Click" 
        style="margin-left: 0px" Width="26px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton 
        ID="ImageButtonWR" runat="server" Height="32px" 
        ImageUrl="~/Iconos/Document.png" onclick="ImageButtonWR_Click" 
        style="margin-top: 0px" Width="33px" />
    &nbsp;&nbsp;&nbsp;
    <asp:ImageButton ID="ImageButtonLabel" runat="server" Height="26px" 
        ImageUrl="~/Iconos/label.png" onclick="ImageButtonLabel_Click" Width="41px" />
                <br />
                </td>
        </tr>
        <tr>
            <td class="style11" valign="top">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" 
                    BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
                    DataKeyNames="id_Cuba_Package_Main" DataSourceID="SqlDataSource1" 
                    GridLines="Horizontal" onrowdatabound="GridView1_RowDataBound" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged" PageSize="20" 
                    style="font-size: xx-small; margin-right: 0px;" Width="113px">
                    <Columns>
                        <asp:TemplateField HeaderText="Est.">
                            <ItemTemplate>
                                <asp:Image ID="ImgSemaforo" runat="server" CausesValidation="False" />
                            </ItemTemplate>
                            <ControlStyle Height="13px" Width="13px" />
                            <HeaderStyle Width="4px" />
                            <ItemStyle Font-Size="XX-Small" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="id_Cuba_Package_Main" InsertVisible="False" 
                            ReadOnly="True" SortExpression="id_Cuba_Package_Main">
                        <ControlStyle Width="2px" />
                        <HeaderStyle Width="2px" />
                        <ItemStyle Font-Size="XX-Small" ForeColor="White" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WR" HeaderText="WR" SortExpression="WR">
                        <HeaderStyle Width="45px" />
                        <ItemStyle Font-Size="XX-Small" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Date" DataFormatString="{0:MM/dd/yyyy}" 
                            HeaderText="Date" SortExpression="Date">
                        <ItemStyle Font-Size="XX-Small" />
                        </asp:BoundField>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Iconos/edit.png" 
                            ShowSelectButton="True">
                        <ControlStyle Height="10px" Width="10px" />
                        <ItemStyle Font-Size="XX-Small" Height="10px" Width="10px" />
                        </asp:CommandField>
                        <asp:BoundField DataField="Estado" SortExpression="Estado">
                        <HeaderStyle Width="2px" />
                        <ItemStyle ForeColor="White" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" Height="5px" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#487575" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#275353" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DB_82130_itndatabaseConnectionString %>" 
                    
                    
                    SelectCommand="SELECT id_Cuba_Package_Main, WR, Date, Estado FROM TBL_Cuba_Package_Main ORDER BY Date DESC">
                </asp:SqlDataSource>
                <br />
                </td>
            <td class="style9" valign="top">
                <asp:Panel ID="Panel1" runat="server" Height="563px" Width="750px">
                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <table style="width: 99%">
        <tr>
            <td rowspan="3" style="text-align: left; font-size: xx-small;" 
                valign="top" class="style8">
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="WR" runat="server" 
                    style="font-weight: 700; font-size: medium; font-family: 'Arial Black'; color: #660033; text-align: right;" 
                    Text="WR"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="Edit" runat="server" Height="22px" 
                    ImageUrl="~/Iconos/edit.png" onclick="Edit_Click" Width="22px" />
&nbsp;
                <asp:ImageButton ID="update" runat="server" Height="22px" 
                    ImageUrl="~/Iconos/Ok-icon.png" onclick="update_Click" Width="22px" />
                <br />
                &nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="tb_Manifiesto" runat="server" Height="30px" 
                    style="font-size: small; font-weight: 700; color: #800000; font-family: 'Arial Black'" 
                    Width="170px">
                </asp:DropDownList>
                &nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="FechaHoy" runat="server" placeholder="FechaRegistro" 
                    style="font-size: x-small" Width="170px"></asp:TextBox>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="tb_Sender" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="tb_Sender_SelectedIndexChanged1" 
                    ontextchanged="tb_Sender_TextChanged" 
                    style="text-align: center; font-size: small" Width="170px">
                </asp:DropDownList>
                &nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="tb_Destinatario" runat="server" AutoPostBack="True" 
                    Height="16px" onselectedindexchanged="tb_Destinatario_SelectedIndexChanged" 
                    placeholder="Destinatario" style="text-align: center; font-size: small" 
                    Width="170px">
                </asp:DropDownList>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; Zona<br />
                &nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="tb_DestProvincia" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="tb_DestProvincia_SelectedIndexChanged" 
                    placeholder="Provincia" style="font-size: small" Width="170px">
                </asp:DropDownList>
&nbsp;
                <asp:TextBox ID="tb_Zona" runat="server" Font-Bold="True" ReadOnly="True" 
                    Width="16px"></asp:TextBox>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="tb_DestMinicipio" runat="server" 
                    onselectedindexchanged="tb_DestMinicipio_SelectedIndexChanged" 
                    placeholder="Municipio" style="font-size: small" Width="170px">
                </asp:DropDownList>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /> &nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="tb_TipoEntrega" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="tb_TipoEntrega_SelectedIndexChanged" 
                    placeholder="TipoEntrega" style="font-size: small" Width="170px">
                </asp:DropDownList>
                <br />
                &nbsp;&nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="tb_Estado" runat="server" Height="16px" Width="170px">
                </asp:DropDownList>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="tb_Tipo_Envio" runat="server" Height="16px" 
                    placeholder="TipoEnvio" Width="170px">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="color: #800000; font-size: x-small"><em>Lbs</em></span><span 
                    style="font-size: x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <span style="color: #800000; font-size: x-small"><em>Largo&nbsp;&nbsp;&nbsp;&nbsp; </em></span>&nbsp;
                <span style="color: #800000; font-size: x-small"><em>Ancho&nbsp;</em></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <span style="color: #800000; font-size: x-small"><em>Alto</em></span></span><br /> 
                &nbsp;&nbsp;&nbsp; <span style="font-size: x-small">
                <asp:TextBox ID="tb_Peso" runat="server" ontextchanged="tb_Peso_TextChanged" 
                    placeholder="Lbs." style="text-align: center" Width="38px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tb_Largo" runat="server" ontextchanged="tb_Largo_TextChanged" 
                    placeholder="pulg." Width="25px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tb_Ancho" runat="server" ontextchanged="tb_Ancho_TextChanged" 
                    placeholder="pulg." Width="25px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp; <span style="color: #800000; font-size: x-small"><em>
                <asp:TextBox ID="tb_Alto" runat="server" ontextchanged="tb_Alto_TextChanged" 
                    Width="25px"></asp:TextBox>
                <br />
                &nbsp;&nbsp; <em style="text-align: left">
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Vol&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Tarifa&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Precio&nbsp;&nbsp;&nbsp;
                <br />
                &nbsp;&nbsp; &nbsp;<asp:Label ID="lb_Vol" runat="server" CssClass="bold" 
                    style="color: #CC3300; font-size: small; text-align: left;">vol</asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:Label ID="lb_Rate" runat="server" CssClass="bold" 
                    style="color: #CC3300; font-size: small; text-align: center;">rate</asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lb_Precio" runat="server" CssClass="bold" 
                    style="color: #CC3300; font-size: small; text-align: center;">precio</asp:Label>
                </em>&nbsp;&nbsp;</em></span></span><br />
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tb_Notas" runat="server" Height="82px" placeholder="Notas" 
                    TextMode="MultiLine" Width="214px"></asp:TextBox>
                <br />
                <br />
                &nbsp;<span style="font-size: x-small">&nbsp;</span>&nbsp;
                <asp:ImageButton ID="Save" runat="server" Height="25px" 
                    ImageUrl="~/Iconos/Save-icon.png" onclick="Save_Click" Width="25px" />
                &nbsp; &nbsp;
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="style6" height="20" style="text-align: left; margin-left: 40px; " 
                valign="top">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="color: #990000">
                <span style="text-decoration: underline"><strong>Desglose de Articulos:</strong></span>
                </span>&nbsp;<asp:ImageButton ID="det_New" runat="server" Height="20px" 
                    ImageUrl="~/Iconos/New1.png" onclick="ImageButton4_Click" Width="20px" />
                <asp:Panel ID="Panel2" runat="server" Height="27px" Width="498px">
                    &nbsp;<asp:TextBox ID="det_Id_sender" runat="server" Height="16px" Width="29px"></asp:TextBox>
                    &nbsp;
                    <asp:TextBox ID="det_Desc" runat="server" Height="16px" 
                        placeholder="Descripcion" Width="328px"></asp:TextBox>
                    &nbsp;
                    <asp:TextBox ID="det_Cant" runat="server" Height="16px" placeholder="Cant." 
                        Width="29px"></asp:TextBox>
                    &nbsp;
                    <asp:ImageButton ID="det_Save" runat="server" Height="20px" 
                        ImageUrl="~/Iconos/Save-icon.png" onclick="det_Save_Click" Width="20px" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="style7" height="5" style="margin-left: 40px;" valign="top">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" 
                    CellPadding="4" DataKeyNames="id_Cuba_PackageMain_Detalles" 
                    DataSourceID="SqlDataSource2" GridLines="Horizontal" Height="50px" 
                    style="font-size: x-small" Width="449px" 
                    onrowdeleting="GridView2_RowDeleting" onrowupdated="GridView2_RowUpdated">
                    <Columns>
                        <asp:CommandField ButtonType="Image" CancelImageUrl="~/Iconos/Cancel.png" 
                            EditImageUrl="~/Iconos/edit.png" ShowEditButton="True" 
                            UpdateImageUrl="~/Iconos/Ok-icon.png">
                        <ControlStyle Height="13px" Width="13px" />
                        <HeaderStyle Width="50px" />
                        <ItemStyle Height="10px" Width="10px" />
                        </asp:CommandField>
                        <asp:BoundField DataField="id_Cuba_PackageMain_Detalles" HeaderText="id" 
                            InsertVisible="False" ReadOnly="True" 
                            SortExpression="id_Cuba_PackageMain_Detalles">
                        <HeaderStyle Width="2px" />
                        <ItemStyle ForeColor="White" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Cuba_Package_Main" HeaderText="Cuba_Package_Main" 
                            SortExpression="Cuba_Package_Main" Visible="False">
                        <ItemStyle ForeColor="White" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" 
                            SortExpression="Descripcion" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cant" 
                            SortExpression="Cantidad">
                        <HeaderStyle Width="10px" />
                        <ItemStyle HorizontalAlign="Right" />
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
                    SelectCommand="SELECT [id_Cuba_PackageMain_Detalles], [Cuba_Package_Main], [Descripcion], [Cantidad] FROM [TBL_Cuba_Package_Main_Detalles] WHERE ([Cuba_Package_Main] = @Cuba_Package_Main)" 
                    UpdateCommand="UPDATE TBL_Cuba_Package_Main_Detalles SET Descripcion = @Descripcion, Cantidad = @Cantidad WHERE (id_Cuba_PackageMain_Detalles = @id_Cuba_PackageMain_Detalles)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="Label1" Name="Cuba_Package_Main" 
                            PropertyName="Text" Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Descripcion" />
                        <asp:Parameter Name="Cantidad" />
                        <asp:Parameter Name="id_Cuba_PackageMain_Detalles" />
                    </UpdateParameters>
                </asp:SqlDataSource>
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
                &nbsp;&nbsp;&nbsp;
                <br />
                <br />
                &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>
    <br />
    &nbsp;&nbsp;&nbsp;
    <br />
    &nbsp;&nbsp;&nbsp;
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;<br />&nbsp;&nbsp;&nbsp;&nbsp;<br />&nbsp;&nbsp;&nbsp;&nbsp;<br />&nbsp;&nbsp;&nbsp;&nbsp;<br />&nbsp;&nbsp;&nbsp;<br /><br />&nbsp;&nbsp;&nbsp;&nbsp;<br /><br /></asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="style11" valign="top">
                &nbsp;</td>
            <td class="style9" valign="top">
                <asp:TextBox ID="id_provincia" runat="server" Visible="False" Width="67px"></asp:TextBox>
                <asp:TextBox ID="id_Destinatario" runat="server" Visible="False" Width="67px"></asp:TextBox>
                <asp:TextBox ID="id_Sender" runat="server" Visible="False" Width="67px"></asp:TextBox>
                <asp:TextBox ID="id_Municipio" runat="server" Height="22px" Visible="False" 
                    Width="76px"></asp:TextBox>
                <asp:TextBox ID="id_TipoEntrega" runat="server" Width="54px"></asp:TextBox>
                <asp:TextBox ID="TextBoxID" runat="server" Width="89px" Visible="False">WR</asp:TextBox>
                <asp:TextBox ID="filt_Manifiesto" runat="server" Width="89px" Visible="False"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Text="id_Main" Visible="False"></asp:Label>
                <asp:Label ID="Label_Sender" runat="server" Text="id_Sender" Visible="False"></asp:Label>
                </td>
        </tr>
    </table>
</asp:Content>
