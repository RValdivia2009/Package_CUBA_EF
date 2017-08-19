<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PackageRegistro_EF.aspx.cs" Inherits="Package_WebApp.PagesMembers.PackageRegistro_EF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <style type="text/css">
        .style4
        {
        }
        .style5
        {
    }
    .style6
    {
            width: 335px;
            border-bottom-style: solid;
            border-bottom-width: 1px;
            height: 13px;
        }
    .style7
    {
        height: 13px;
    }
        .style10
        {
            height: 13px;
            border-bottom-style: solid;
            border-bottom-width: 1px;
        }
    .style11
    {
        text-align: left;
            width: 335px;
        }
        .style14
        {
            height: 278px;
        }
        .style22
        {
            width: 46px;
        }
        .style23
        {
            text-align: center;
        }
        .style24
        {
            width: 249px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <p>
        <table class="style1">
            
            <tr>
                <td>
                    <asp:TextBox ID="telefono" runat="server" placeholder="No. Telefono." 
                    Height="17px" style="text-align: center" Width="92px" 
                    ontextchanged="telefono_TextChanged"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton3" runat="server" Height="19px" 
        ImageUrl="~/Iconos/find.png" 
        style="margin-left: 0px" Width="26px" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="telefono" Display="Dynamic" 
                    ErrorMessage="Teléfono incorrecto." style="color: #FF0000; font-size: small" 
                    ValidationExpression="(\(\d{3}\)\d{3}-\d{4})|(\d{10})"></asp:RegularExpressionValidator>
                    <br />
                </td>
                <td valign="top" colspan="4">
                    &nbsp;&nbsp;
                    <asp:TextBox ID="NoPaquete" runat="server" Height="17px" 
                                placeholder="NoPaquete" style="text-align: center" Width="112px"></asp:TextBox>
                            <asp:ImageButton ID="ImageButton2" runat="server" Height="19px" 
                                ImageUrl="~/Iconos/find.png" onclick="ImageButton1_Click" 
                                style="margin-left: 0px" Width="26px" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <span style="color: #990000" __designer:mapid="aa">
                    <strong __designer:mapid="ac"><span __designer:mapid="ab">
                                <asp:ImageButton 
                    ID="ImageButtonMani" runat="server" Height="18px" 
                    ImageUrl="~/Iconos/Letter1.png" onclick="ImageButtonMani_Click" 
                    Width="26px" Visible="False" />
                    &nbsp; </span></strong></span>&nbsp;<span style="color: #990000" __designer:mapid="aa"><strong __designer:mapid="ac"><span 
                        __designer:mapid="ab"><asp:ImageButton 
                    ID="ButtonWR" runat="server" Height="26px" 
                    ImageUrl="~/Iconos/Document.png" onclick="ButtonWR_Click" 
                    Width="28px" style="margin-top: 0px" />
                &nbsp;
                <asp:ImageButton 
                    ID="ButtonListaE" runat="server" Height="26px" 
                    ImageUrl="~/Iconos/aduana.png" onclick="ButtonListaE_Click" 
                    Width="28px" style="margin-top: 0px" />
                &nbsp; <asp:ImageButton ID="Btton_Recivos" runat="server" Height="28px" 
                        ImageUrl="~/Iconos/Gente.png" onclick="Btton_Recivos_Click" Width="28px" />
                    &nbsp;
                    <asp:ImageButton ID="ImageButton5" runat="server" Height="28px" 
                        ImageUrl="~/Iconos/bill.png" onclick="ImageButton5_Click" Width="28px" />
&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="tb_FechaComprobante" runat="server" Height="16px" 
                        Width="85px"></asp:TextBox>
                 &nbsp;
                    <asp:ImageButton ID="ImageButton6" runat="server" Height="23px" 
                        ImageUrl="~/Iconos/bill.png" onclick="ImageButton6_Click" Width="28px" />
&nbsp;
                <asp:ImageButton 
                    ID="ImageButtonLabel" runat="server" Height="26px" 
                    ImageUrl="~/Iconos/label.png" onclick="ImageButtonLabel_Click" 
                    Width="26px" />
                                </span></strong>
                                </span>&nbsp;<span style="color: #990000" __designer:mapid="aa"><strong __designer:mapid="ac"><span __designer:mapid="ab">&nbsp;&nbsp; </span></strong></span></td>
            </tr>
            
            <tr>
                <td class="style6">
                    &nbsp;&nbsp;<asp:Button ID="AgreraPak" runat="server" onclick="AgreraPak_Click" 
                           style="color: #990000; font-style: italic; text-decoration: underline; font-weight: 700; font-size: x-small" 
                           Text="Agregar paquete" Font-Size="Small" ForeColor="Red" Height="21px"  
                        Width="235px" />
                            <br />
                            </td>
                            <td class="style10" colspan="4">
                                &nbsp;</td>
                               <td class="style7">
                               </td>
                               </tr>
   
                                <tr>
                                <td class="style11" valign="top">

                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="WR" runat="server" 
                                    style="font-weight: 700; font-size: medium; font-family: 'Arial Black'; color: #660033; text-align: right;" 
                                    Text="WR" Font-Bold="False"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="Edit" runat="server" Height="25px" 
                                    ImageUrl="~/Iconos/edit.png" onclick="Edit_Click" 
                                    Width="25px" />
                              &nbsp;&nbsp;&nbsp;
                                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="agencia" runat="server" ForeColor="#FF3300" Text="Label"></asp:Label>
                                &nbsp;<asp:TextBox ID="FechaHoy" runat="server" placeholder="FechaRegistro" 
                                    style="font-size: x-small" Width="61px" Height="16px"></asp:TextBox>
                                    <br />
                                <br />
                                &nbsp;&nbsp;
                                <asp:DropDownList ID="tb_Manifiesto" runat="server" Height="25px" 
                                    style="font-size: small; font-weight: 700; color: #800000; font-family: 'Arial Black'" 
                                    Width="170px">
                                </asp:DropDownList>
                                &nbsp;
                                <br />
                                &nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <br />
                                &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="tb_Sender" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="tb_Sender_SelectedIndexChanged1" 
                                    ontextchanged="tb_Sender_TextChanged" 
                                    style="text-align: center; font-size: small" Width="170px">
                                </asp:DropDownList>
                                &nbsp;&nbsp;

                                <br />
                                <br />
                                &nbsp;&nbsp;&nbsp;<asp:DropDownList 
                                        ID="tb_Destinatario" runat="server" AutoPostBack="True" 
                                    Height="16px" onselectedindexchanged="tb_Destinatario_SelectedIndexChanged" 
                                    placeholder="Destinatario" style="text-align: center; font-size: small" 
                                    Width="170px" ontextchanged="tb_Destinatario_TextChanged">
                                </asp:DropDownList>
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; Zona&nbsp; 
                                <br />
                                &nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="tb_DestProvincia" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="tb_DestProvincia_SelectedIndexChanged" 
                                    placeholder="Provincia" style="font-size: small" Width="145px" 
                                    Height="18px">
                                </asp:DropDownList>
                                &nbsp;
                                <asp:TextBox ID="tb_Zona" runat="server" Width="14px" Font-Bold="True" 
                                    ReadOnly="True"></asp:TextBox>
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
                                    placeholder="TipoEntrega" style="font-size: small" 
                                    Width="170px">
                                </asp:DropDownList>
                                <br />
                                &nbsp;&nbsp;
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="tb_Estado" runat="server" Height="16px" 
                                 Width="170px">
                                </asp:DropDownList>
                                <br />
                                <br />
                                &nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="tb_Tipo_Envio" runat="server" Height="16px" Width="170px" 
                                    placeholder="TipoEnvio" AutoPostBack="True" 
                                    onselectedindexchanged="tb_Tipo_Envio_SelectedIndexChanged">
                                </asp:DropDownList>
                                <br />
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                <span style="color: #800000; font-size: x-small">
                                <em>Lbs</em></span><span 
                                    style="font-size: x-small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <span style="color: #800000; font-size: x-small">
                                <em>Largo&nbsp;&nbsp;&nbsp;&nbsp; </em></span>&nbsp;
                                <span style="color: #800000; font-size: x-small">
                                <em>Ancho&nbsp;</em></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <span style="color: #800000; font-size: x-small">
                                <em>Alto</em></span></span><br />&nbsp;&nbsp;&nbsp;&nbsp;
                                <span style="font-size: x-small">
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
                                <br />
                                    <em style="text-align: left">&nbsp;&nbsp;
                                &nbsp; Vol&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Tarifa&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Precio&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 
                                    Desc.&nbsp; &nbsp; &nbsp; Total&nbsp;&nbsp;&nbsp;
                                <br />
                                    &nbsp;<asp:Label ID="lb_Vol" 
                                runat="server" CssClass="bold" 
                                    style="color: #CC3300; font-size: small; text-align: left;">vol</asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                <asp:Label ID="lb_Rate" runat="server" CssClass="bold" 
                                    style="color: #CC3300; font-size: small; text-align: center;">rate</asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lb_Precio" 
                                    runat="server" CssClass="bold" 
                                    style="color: #CC3300; font-size: small; text-align: center;">precio</asp:Label>
                                </em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="tb_Desc" runat="server" Height="18px" 
                                        ontextchanged="tb_Desc_TextChanged" Width="39px">0.00</asp:TextBox>
&nbsp;&nbsp;<em style="text-align: left"><asp:Label ID="lb_Total" 
                                    runat="server" CssClass="bold" 
                                    style="color: #CC3300; font-size: small; text-align: center;">total</asp:Label>
                                </em>
                                <br />
                                &nbsp;FormaPago&nbsp;
                                <asp:DropDownList ID="tb_FormaPago" runat="server" Height="16px" Width="72px" 
                                    placeholder="TipoEnvio" AutoPostBack="True" Font-Size="Small" 
                                        ontextchanged="tb_FormaPago_TextChanged">
                                </asp:DropDownList>
                                &nbsp;&nbsp; <asp:ImageButton ID="update" runat="server" Height="25px" 
                                    ImageUrl="~/Iconos/Ok-icon.png" onclick="update_Click" Width="25px" />
                                    &nbsp;<asp:ImageButton ID="Save" runat="server" Height="25px" 
                                    ImageUrl="~/Iconos/Save-icon.png" onclick="Save_Click" Width="25px" />
                                &nbsp;<asp:ImageButton ID="Cancel_Main" runat="server" Height="23px" ImageUrl="~/Iconos/Cancel.png" onclick="Cancel_Main_Click1" Width="30px" />
                                    <br />
                                    <br />
                                <asp:TextBox ID="tb_Notas" runat="server" Height="82px" placeholder="Notas" 
                                        TextMode="MultiLine" Width="222px"></asp:TextBox>
                                <br />
                    
                  
                    
                    
                    
                    
                    </em></span></span>
                                </td>
                <td valign="top" class="style24">
                    &nbsp; <span style="color: #990000" __designer:mapid="aa">
                    <strong __designer:mapid="ac">
                    <span style="text-decoration: underline" __designer:mapid="ab">
                    Desglose de Articulos:</span></strong>
                                </span>&nbsp;<br />
                    <asp:Panel ID="Panel2" runat="server" Height="26px" Width="506px">
                                    <asp:TextBox ID="det_Id_sender" runat="server" Height="16px" Visible="False" 
                                        Width="29px"></asp:TextBox>
                                    &nbsp;
                                    <asp:TextBox ID="det_Desc" runat="server" Height="16px" 
                                        placeholder="Descripcion" Width="294px"></asp:TextBox>
                                    &nbsp;
                                    <asp:TextBox ID="det_Cant" runat="server" Height="16px" placeholder="Cant." 
                                        Width="29px"></asp:TextBox>
                                    &nbsp;
                                    <asp:ImageButton ID="det_Save" runat="server" Height="20px" 
                                        ImageUrl="~/Iconos/Save-icon.png" onclick="det_Save_Click" Width="20px" />
                                    &nbsp;&nbsp;
                                    <asp:ImageButton ID="Calcel_Detalles" runat="server" Height="23px" 
                                        ImageUrl="~/Iconos/Cancel.png" onclick="Calcel_Detalles_Click" Width="30px" />
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
                                </asp:Panel>
&nbsp;<br />
                    <asp:Panel ID="Panel_Mise_Detalle" runat="server" Height="224px" Width="543px">
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" 
                        BorderColor="#336666" BorderStyle="None" 
    BorderWidth="1px" CellPadding="4" 
                        DataKeyNames="id_Cuba_PackageMain_Detalles" DataSourceID="SqlDataSource2" 
                        ForeColor="Black" GridLines="Horizontal" Height="77px" 
                        style="font-size: x-small" Width="545px" 
                        onrowdeleted="GridView2_RowDeleted" 
    onrowupdated="GridView2_RowUpdated">
                            <Columns>
                                <asp:CommandField ButtonType="Image" CancelImageUrl="~/Iconos/Cancel.png" 
                                EditImageUrl="~/Iconos/edit.png" ShowEditButton="True" 
                                UpdateImageUrl="~/Iconos/Ok-icon.png">
                                <ControlStyle Height="15px" Width="15px" />
                                <HeaderStyle Width="40px" />
                                <ItemStyle Height="10px" Width="10px" />
                                </asp:CommandField>
                                <asp:BoundField DataField="id_Cuba_PackageMain_Detalles" 
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
                                <ControlStyle Width="25px" />
                                <HeaderStyle Width="10px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="Valor">
                                <ControlStyle Width="40px" />
                                <HeaderStyle Width="15px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Modelo" HeaderText="Modelo" SortExpression="Modelo">
                                <ControlStyle Width="70px" />
                                <ItemStyle Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca">
                                <ControlStyle Width="70px" />
                                <ItemStyle Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Serie" HeaderText="Serie" SortExpression="Serie">
                                <ControlStyle Width="70px" />
                                <ItemStyle Width="50px" />
                                </asp:BoundField>
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Iconos/delete.png" 
                                    ShowDeleteButton="True">
                                <ControlStyle Height="13px" Width="13px" />
                                <HeaderStyle Width="20px" />
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:DB_82130_itndatabaseConnectionString %>" 
                        DeleteCommand="DELETE FROM TBL_Cuba_Package_Main_Detalles WHERE (id_Cuba_PackageMain_Detalles = @id_Cuba_PackageMain_Detalles)" 
                        SelectCommand="SELECT id_Cuba_PackageMain_Detalles, Cuba_Package_Main, Descripcion, Cantidad, Valor, WR, Modelo, Marca, Serie FROM TBL_Cuba_Package_Main_Detalles WHERE (WR = @WR)" 
                        
    
                            
                            
                            UpdateCommand="UPDATE TBL_Cuba_Package_Main_Detalles SET Descripcion = @Descripcion, Cantidad = @Cantidad, Valor = @Valor, Modelo = @Modelo, Marca = @Marca, Serie = @Serie WHERE (id_Cuba_PackageMain_Detalles = @id_Cuba_PackageMain_Detalles)">
                            <DeleteParameters>
                                <asp:Parameter Name="id_Cuba_PackageMain_Detalles" />
                            </DeleteParameters>
                            <SelectParameters>
                                <asp:ControlParameter ControlID="WR" Name="WR" 
                                PropertyName="Text" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="Descripcion" />
                                <asp:Parameter Name="Cantidad" />
                                <asp:Parameter Name="Valor" />
                                <asp:Parameter Name="Modelo" />
                                <asp:Parameter Name="Marca" />
                                <asp:Parameter Name="Serie" />
                                <asp:Parameter Name="id_Cuba_PackageMain_Detalles" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                            Text="Agregar Duraderos?" Width="156px" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="det_New" runat="server" onclick="det_New_Click1" 
                            Text="Agregar Miselaneos?" Width="156px" />
                        &nbsp;
                        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Bolsa" />
                        <br />
                    </asp:Panel>
                    <asp:Panel ID="Panel_Dura_Detalle" runat="server" Height="422px" Width="549px">
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="DropAduanaClase" runat="server" AutoPostBack="True" 
                            Font-Size="XX-Small" Height="16px" 
                            onselectedindexchanged="DropAduanaClase_SelectedIndexChanged" Width="256px">
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="tb_AduanaArticulo" runat="server" Width="130px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="DuraBusca" runat="server" Height="24px" 
                            ImageUrl="~/Iconos/find.png" onclick="DuraBusca_Click" Width="36px" />
                        &nbsp;&nbsp;
                        <asp:ImageButton ID="Calcel_DetallesDura" runat="server" Height="23px" 
                            ImageUrl="~/Iconos/Cancel.png" onclick="Calcel_DetallesDura_Click" 
                            Width="30px" />
                        <br />
                        <br />
                        <asp:GridView ID="GridView3" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" DataKeyNames="id_Aduana" 
                            DataSourceID="SqlDataSource3" Font-Size="XX-Small" Height="16px" 
                            onselectedindexchanged="GridView3_SelectedIndexChanged" PageSize="15" 
                            style="margin-left: 5px" Width="542px">
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Iconos/Ok-icon.png" 
                                    ShowSelectButton="True">
                                <ControlStyle Height="14px" Width="14px" />
                                <HeaderStyle Width="40px" />
                                </asp:CommandField>
                                <asp:BoundField DataField="Clase" HeaderText="Clase" SortExpression="Clase" 
                                    Visible="False">
                                <ItemStyle Font-Size="XX-Small" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Articulos" HeaderText="Articulos" 
                                    SortExpression="Articulos" />
                                <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="Valor" >
                                <HeaderStyle Width="35px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Cant" HeaderText="Cant" SortExpression="Cant" >
                                <HeaderStyle Width="35px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_Aduana" InsertVisible="False" ReadOnly="True" 
                                    SortExpression="id_Aduana" Visible="False">
                                <HeaderStyle Width="2px" />
                                <ItemStyle ForeColor="White" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CAPITULOS" HeaderText="CAPITULOS" 
                                    SortExpression="CAPITULOS" Visible="False" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:DB_82130_itndatabaseConnectionString %>" 
                            
                            SelectCommand="SELECT CAPITULOS, Clase, Articulos, Valor, Cant, id_Aduana FROM tbl_Cuba_Aduana WHERE (Clase = @Clase) ORDER BY Clase">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="DropAduanaClase" Name="Clase" 
                                    PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        &nbsp;
                        <br />
                    </asp:Panel>
                    &nbsp;
                    &nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblMensajeError" runat="server" ForeColor="Red" 
                        Text="Label"></asp:Label>
                            </td>
                <td valign="top" class="style14">
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;
                            <br />
                    <br />
                            </td>
                <td valign="top" class="style14">
                    <br />
                    <br />
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
                        onselectedindexchanged="CheckBoxList1_SelectedIndexChanged" Width="99px" 
                        BorderColor="#336666" BorderStyle="Solid" BorderWidth="1px">
                        <asp:ListItem>Sender</asp:ListItem>
                        <asp:ListItem>Destinatario</asp:ListItem>
                    </asp:CheckBoxList>
                    <br />
                            </td>
                <td valign="top" class="style14">
                    <br />
                    <br />
                    <asp:ImageButton ID="ImageButton4" runat="server" Height="46px" 
                        ImageUrl="~/Iconos/Mail_1.png" onclick="ImageButton4_Click" Width="44px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                <td class="style22">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style23" colspan="5">
                    &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="id_provincia0" runat="server" Width="67px" 
                        Height="14px" Visible="False"></asp:TextBox>
                &nbsp;
                <asp:TextBox ID="id_provincia" runat="server" Width="67px" 
                        Height="14px" Visible="False"></asp:TextBox>
                &nbsp;&nbsp;<asp:TextBox ID="id_Destinatario" runat="server" Width="67px" 
                        Height="14px" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="id_Sender" runat="server" Width="67px" 
                        Height="14px" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="id_Municipio" runat="server" Height="14px" Width="76px" 
                        Visible="False"></asp:TextBox>
                <asp:TextBox ID="id_TipoEntrega" runat="server" Width="54px" ForeColor="Black" 
                        Height="14px" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="TextBoxID" runat="server" Width="70px" 
                        Height="16px" Visible="False">WR</asp:TextBox>
                    <asp:TextBox 
                    ID="filt_Manifiesto" runat="server" Width="64px" Height="16px" Visible="False"></asp:TextBox>
                &nbsp;&nbsp;<asp:TextBox ID="id_formaPago" runat="server" Height="16px" 
                        Width="41px" Visible="False"></asp:TextBox>
&nbsp;<asp:Label ID="Label1" 
                    runat="server" Text="id_Main" ForeColor="Black" Visible="False"></asp:Label>

                <asp:Label ID="Label_Sender" runat="server" Text="id_Sender" ForeColor="Black" 
                        Visible="False"></asp:Label>

                <asp:Label ID="id_Detalle" runat="server" Text="id_Detalle" ForeColor="Black" 
                        Visible="False"></asp:Label>

                    &nbsp;</td>
                <td class="style22">
                    &nbsp;</td>
            </tr>
            </table>
    </p>
</asp:Content>

