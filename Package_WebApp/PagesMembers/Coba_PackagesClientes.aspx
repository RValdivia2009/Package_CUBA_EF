<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Coba_PackagesClientes.aspx.cs" Inherits="Package_WebApp.PageAdmin.Coba_PackagesClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

    .style8
    {
        color: #800000;
    }
        .style9
        {
            font-size: medium;
        }
        .style10
        {
            font-size: medium;
            text-decoration: underline;
        }
        .style11
        {
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
    <tr>
        <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label_Sender" runat="server" Text="id_Sender" Visible="False"></asp:Label>

                    &nbsp;
                    &nbsp;<asp:Panel ID="Panel1" runat="server" Width="969px" Height="65px">
                        &nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="19px" 
    Visible="False"></asp:TextBox>
                        &nbsp;&nbsp;
                        <asp:TextBox ID="tb_Nombre" runat="server" Width="125px" 
    placeholder="Nombre y Amellido"></asp:TextBox>
                        &nbsp;&nbsp; <span class="style8">
                        <asp:TextBox ID="tb_Apellido" runat="server" placeholder="Apellido" 
                            Width="113px"></asp:TextBox>
                        </span>&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="tb_Dir_1" runat="server" Width="145px" 
    placeholder="Direccion"></asp:TextBox>
                        &nbsp;&nbsp;<asp:TextBox ID="tb_Dir2" runat="server" 
    placeholder="Direccion 2" Width="117px"></asp:TextBox>
                        &nbsp;&nbsp;
                        <asp:TextBox ID="tb_telefono" runat="server" 
    placeholder="Telefono" Width="103px" Height="23px"></asp:TextBox>
                        &nbsp;&nbsp;
                        <asp:TextBox ID="tb_city" runat="server" 
    placeholder="Ciudad" Width="101px" Height="22px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="Tb_EmailSender" runat="server" Height="20px" 
                            placeholder="EMail" Width="156px"></asp:TextBox>
                        &nbsp; &nbsp; &nbsp; &nbsp; 
                        <br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton 
                            ID="ImageButton7" runat="server" Height="24px" 
                            ImageUrl="~/Iconos/Save-icon.png" onclick="ImageButton7_Click" Width="37px" />
                        <asp:ImageButton ID="ImageButton5" runat="server" Height="23px" 
                            ImageUrl="~/Iconos/Cancel.png" onclick="ImageButton5_Click1" Width="30px" />
                        <br />
                        &nbsp;&nbsp;</asp:Panel>
            <br />
            <asp:TextBox ID="telefono" runat="server" placeholder="No. Telefono." 
                    Height="17px" style="text-align: center" Width="92px"></asp:TextBox>
                &nbsp;
                <asp:ImageButton ID="ImageButton1" runat="server" Height="21px" 
                        ImageUrl="~/Iconos/find.png" onclick="ImageButton1_Click" Width="27px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; <span class="style8"><span class="style10"><strong>
                    Sender</strong></span>&nbsp;&nbsp;&nbsp;
                    <asp:ImageButton ID="New" runat="server" 
                        Height="23px" ImageUrl="~/Iconos/add_peope1.png" onclick="ImageButton5_Click" 
                        Width="26px" />
                    &nbsp;&nbsp;
                    </span><br />
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
                        BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="2" 
                        DataKeyNames="id_Sender" DataSourceID="SqlDataSource1" GridLines="Horizontal" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged" 
                        style="font-size: xx-small" Width="977px">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                            <ControlStyle ForeColor="#0033CC" />
                            <HeaderStyle Width="30px" />
                            </asp:CommandField>
                            <asp:CommandField ButtonType="Image" CancelImageUrl="~/Iconos/Cancel.png" 
                                EditImageUrl="~/Iconos/edit.png" ShowEditButton="True" 
                                UpdateImageUrl="~/Iconos/Ok-icon.png">
                            <ControlStyle Height="18px" Width="18px" />
                            <HeaderStyle Width="90px" />
                            </asp:CommandField>
                            <asp:BoundField DataField="Cod_Sender" HeaderText="Cod_Sender" 
                                ReadOnly="True" SortExpression="Cod_Sender">
                            </asp:BoundField>
                            <asp:BoundField DataField="Sender_Nombre" HeaderText="Nombre" 
                                SortExpression="Sender_Nombre">
                            <ControlStyle Width="120px" />
                            <HeaderStyle Width="80px" />
                            <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Sender_Apellido" HeaderText="Apellido" 
                                SortExpression="Sender_Apellido">
                            <ControlStyle Width="120px" />
                            <HeaderStyle Width="80px" />
                            <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Sender_Direcc_1" HeaderText="Direcc_1" 
                                SortExpression="Sender_Direcc_1">
                            <ControlStyle Width="120px" />
                            <HeaderStyle Width="140px" />
                            <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Sender_Direcc_2" HeaderText="Direcc_2" 
                                SortExpression="Sender_Direcc_2">
                            <ControlStyle Width="100px" />
                            <HeaderStyle Width="140px" />
                            <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Telefono" HeaderText="Telefono" 
                                SortExpression="Telefono">
                            <ControlStyle Width="90px" />
                            <HeaderStyle Width="50px" />
                            <ItemStyle Width="130px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Sender_City" HeaderText="Ciudad" 
                                SortExpression="Sender_City">
                            <ControlStyle Width="80px" />
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Sender_Phone" HeaderText="Sender_Phone" 
                                SortExpression="Sender_Phone" Visible="False" />
                            <asp:BoundField DataField="Sender_Email" HeaderText="Email" 
                                SortExpression="Sender_Email">
                            <ControlStyle Width="150px" />
                            <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="id_Sender" HeaderText="id" InsertVisible="False" 
                                ReadOnly="True" SortExpression="id_Sender" Visible="False">
                            <HeaderStyle Width="2px" />
                            <ItemStyle ForeColor="White" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Agencia" HeaderText="Agencia" 
                                SortExpression="Agencia">
                            <HeaderStyle Width="40px" />
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
                        DeleteCommand="DELETE FROM tbl_Cuba_N_Sender WHERE (id_Sender = @id_Sender)" 
                        InsertCommand="INSERT INTO tbl_Cuba_N_Sender(id_Sender, Sender_Nombre, Sender_Apellido, Sender_Direcc_1, Sender_Direcc_2, Telefono, Sender_City, Sender_Phone) VALUES (@id_Sender, @Sender_Nombre, @Sender_Apellido, @Sender_Direcc_1, @Sender_Direcc_2, @Telefono, @Sender_City, @Sender_Phone)" 
                        SelectCommand="SELECT id_Sender, Sender_Nombre, Sender_Apellido, Sender_Direcc_1, Sender_Direcc_2, Telefono, Sender_City, Sender_Phone, Sender_Email, Agencia, Cod_Sender FROM tbl_Cuba_N_Sender WHERE (Agencia = @MyAgen) ORDER BY Sender_Nombre" 
                        
                        
                        
                        
                        UpdateCommand="UPDATE tbl_Cuba_N_Sender SET Sender_Nombre = @Sender_Nombre, Sender_Apellido = @Sender_Apellido, Sender_Direcc_1 = @Sender_Direcc_1, Sender_Direcc_2 = @Sender_Direcc_2, Telefono = @Telefono, Sender_City = @Sender_City, Sender_Phone = Sender_Phone, Sender_Email = @Sender_Email, Agencia = @Agencia WHERE (id_Sender = @Id_Sender)">
                        <DeleteParameters>
                            <asp:Parameter Name="id_Sender" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="id_Sender" />
                            <asp:Parameter Name="Sender_Nombre" />
                            <asp:Parameter Name="Sender_Apellido" />
                            <asp:Parameter Name="Sender_Direcc_1" />
                            <asp:Parameter Name="Sender_Direcc_2" />
                            <asp:Parameter Name="Telefono" />
                            <asp:Parameter Name="Sender_City" />
                            <asp:Parameter Name="Sender_Phone" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="LabelMyAgen" Name="MyAgen" 
                                PropertyName="Text" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Sender_Nombre" />
                            <asp:Parameter Name="Sender_Apellido" />
                            <asp:Parameter Name="Sender_Direcc_1" />
                            <asp:Parameter Name="Sender_Direcc_2" />
                            <asp:Parameter Name="Telefono" />
                            <asp:Parameter Name="Sender_City" />
                            <asp:Parameter Name="Sender_Email" />
                            <asp:Parameter Name="Agencia" />
                            <asp:Parameter Name="Id_Sender" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                    <br />
                        <asp:TextBox ID="id_sender" runat="server" Width="99px" Visible="False" 
                        Height="16px"></asp:TextBox>
            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <span class="style8"><span class="style9"><strong><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                    <span class="style11">Destinatarios</span></em></strong></span>&nbsp;&nbsp;&nbsp;
                    <asp:ImageButton ID="ImageButton2" runat="server" 
                        ImageUrl="~/Iconos/add_peope2.png" onclick="ImageButton2_Click" Height="22px" 
                        Width="25px" />
                    </span>
                    &nbsp;<asp:Panel ID="Panel2" runat="server" Height="124px" Width="908px">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:TextBox ID="id_provincia" runat="server" Width="42px" 
                            Visible="False">id_Prov</asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Agregar destinatario :
                        <asp:Label ID="Label_Nombre" runat="server" Text="Label"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="ImageButton3" runat="server" Height="22px" 
                            ImageUrl="~/Iconos/Save-icon.png" onclick="ImageButton3_Click" 
                            Width="30px" />
                        &nbsp;&nbsp;
                        <asp:ImageButton ID="update" runat="server" Height="25px" 
                            ImageUrl="~/Iconos/Ok-icon.png" onclick="update_Click" Width="25px" />
                        &nbsp;
                        <asp:ImageButton ID="ImageButton4" runat="server" Height="23px" 
                            ImageUrl="~/Iconos/Cancel.png" onclick="ImageButton4_Click" Width="30px" />
                        <br />
                        <br />
                        &nbsp;
                        <asp:TextBox ID="tb_DestNombre" runat="server" placeholder="Nombre" 
                            Width="148px"></asp:TextBox>
                        &nbsp;&nbsp;<asp:TextBox ID="tb_DestApellido" runat="server" placeholder="Apellido" 
                            Width="157px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="tb_DestCelle" runat="server" placeholder="Calle" Width="178px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="tb_Numero" runat="server" placeholder=" No. " Width="29px"></asp:TextBox>
                        &nbsp;
                        <asp:TextBox ID="tb_Apto" runat="server" placeholder=" Apto. " Width="24px"></asp:TextBox>
                        &nbsp;
                        <asp:TextBox ID="tb_DestEntreCalles" runat="server" placeholder="Entre Calles" 
                            Width="150px"></asp:TextBox>
                        &nbsp;
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                        &nbsp;
                        <asp:TextBox ID="tb_DestTelefono" runat="server" placeholder="Telefono" 
                            Width="147px"></asp:TextBox>
                        &nbsp;&nbsp;
                        <asp:DropDownList ID="tb_DestProvincia" runat="server" AutoPostBack="True" 
                            Height="16px" onselectedindexchanged="tb_DestProvincia_SelectedIndexChanged" 
                            Width="157px">
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:DropDownList ID="tb_DestMinicipio" 
                            runat="server" Height="16px" 
                            Width="172px">
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="tb_DestCI" runat="server" 
                            placeholder=" CI " Width="164px"></asp:TextBox>
                        &nbsp;&nbsp;
                        <asp:TextBox ID="tb_Email" runat="server" placeholder=" Email " Width="165px" ></asp:TextBox>
                        <br />
                        <br />
            </asp:Panel>
&nbsp;&nbsp;
                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
                        BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="2" 
                        DataKeyNames="id_Destinatario" DataSourceID="SqlDataSource2" GridLines="Horizontal" 
                        style="font-size: xx-small" Width="897px" 
                        onselectedindexchanged="GridView2_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Iconos/edit.png" 
                                ShowSelectButton="True">
                            </asp:CommandField>
                            <asp:BoundField DataField="Cod_Destino" HeaderText="Cod_Destino" 
                                ReadOnly="True" SortExpression="Cod_Destino">
                            </asp:BoundField>
                            <asp:BoundField DataField="Dest_Nombre" HeaderText="Nombre" 
                                SortExpression="Dest_Nombre">
                            <HeaderStyle Width="90px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Dest_Apellido" HeaderText="Apellido" 
                                SortExpression="Dest_Apellido">
                            <HeaderStyle Width="90px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Telefono" HeaderText="Telefono" 
                                SortExpression="Telefono" >
                            <HeaderStyle Width="70px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Calle" HeaderText="Calle" 
                                SortExpression="Calle" >
                            <HeaderStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Dest_No" HeaderText="Num." SortExpression="Dest_No">
                            <HeaderStyle Width="15px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Dest_Apto" HeaderText="Apto" 
                                SortExpression="Dest_Apto">
                            <HeaderStyle Width="15px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Entre_Calles" HeaderText="Entre_Calles" 
                                SortExpression="Entre_Calles" >
                            <HeaderStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Provincias" HeaderText="Provincias" 
                                SortExpression="Provincias" >
                            <HeaderStyle Width="15px" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Municipio" HeaderText="Municipio" 
                                SortExpression="Municipio" >
                            <HeaderStyle Width="15px" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CI" HeaderText="CI" SortExpression="CI" />
                            <asp:BoundField DataField="Dest_Email" HeaderText="Email" 
                                SortExpression="Dest_Email" />
                            <asp:BoundField DataField="Sender" HeaderText="Sender" SortExpression="Sender" 
                                Visible="False" />
                            <asp:BoundField DataField="id_Destinatario" HeaderText="id" 
                                InsertVisible="False" ReadOnly="True" SortExpression="id_Destinatario" 
                                Visible="False">
                            <HeaderStyle Width="2px" />
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
                        
                        
                        SelectCommand="SELECT id_Destinatario, Dest_Nombre, Dest_Apellido, Telefono, Calle, Entre_Calles, Provincias, Municipio, Sender, CI, aa, Dest_No, Dest_Apto, Dest_Email, Cod_Destino FROM tbl_Cuba_N_Destinatario WHERE (Sender = @Sender)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="id_sender" Name="Sender" PropertyName="Text" 
                                Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="id_Destinatario" runat="server" Width="94px" Visible="False"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="nombre" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="destino" Visible="False"></asp:Label>
            &nbsp;&nbsp;
                    <asp:Label ID="LabelMyAgen" runat="server" Text="MyAgen" Visible="False"></asp:Label>
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
