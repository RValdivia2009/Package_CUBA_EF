<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="N_shipper.aspx.cs" Inherits="Package_WebApp.PagesMembers.N_shipper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <table class="style1">
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="New" runat="server" 
                        Height="23px" ImageUrl="~/Iconos/newIcon.png" onclick="ImageButton5_Click" 
                        Width="26px" />
                    &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label_Sender" runat="server" Text="id_Sender"></asp:Label>

                    &nbsp;
                    &nbsp;<asp:Panel ID="Panel1" runat="server" Width="921px">
                        &nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="19px" 
    Visible="False"></asp:TextBox>
                        &nbsp;&nbsp;
                        <asp:TextBox ID="tb_Nombre" runat="server" Width="103px" 
    placeholder="Nombre"></asp:TextBox>
                        &nbsp;&nbsp;<asp:TextBox ID="tb_Apellido" runat="server" Width="133px" 
    placeholder="Apellido"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="tb_Dir_1" runat="server" Width="145px" 
    placeholder="Direccion"></asp:TextBox>
                        &nbsp;&nbsp;<asp:TextBox ID="tb_Dir2" runat="server" 
    placeholder="Direccion 2"></asp:TextBox>
                        &nbsp;&nbsp;
                        <asp:TextBox ID="tb_telefono" runat="server" 
    placeholder="Telefono"></asp:TextBox>
                        &nbsp;&nbsp;
                        <asp:TextBox ID="tb_city" runat="server" 
    placeholder="Ciudad"></asp:TextBox>
                        &nbsp;&nbsp;
                        <asp:ImageButton ID="Save" runat="server" Height="29px" 
                            ImageUrl="~/Iconos/Save-icon.png" onclick="ImageButton6_Click" Width="30px" />
                    </asp:Panel>
                    <br />
                <asp:TextBox ID="telefono" runat="server" placeholder="No. Telefono." 
                    Height="17px" style="text-align: center" Width="92px"></asp:TextBox>
                &nbsp;
                <asp:ImageButton ID="ImageButton1" runat="server" Height="21px" 
                        ImageUrl="~/Iconos/find.png" onclick="ImageButton1_Click" Width="27px" />
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
                        BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="2" 
                        DataKeyNames="id_Sender" DataSourceID="SqlDataSource1" GridLines="Horizontal" 
                        style="font-size: xx-small" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged" Width="891px">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:CommandField ButtonType="Image" EditImageUrl="~/Iconos/edit.png" 
                                ShowEditButton="True" />
                            <asp:BoundField DataField="id_Sender" HeaderText="id" InsertVisible="False" 
                                ReadOnly="True" SortExpression="id_Sender">
                            <HeaderStyle Width="2px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Sender_Nombre" HeaderText="Nombre" 
                                SortExpression="Sender_Nombre">
                            <HeaderStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Sender_Apellido" HeaderText="Apellido" 
                                SortExpression="Sender_Apellido">
                            <HeaderStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Sender_Direcc_1" HeaderText="Direcc_1" 
                                SortExpression="Sender_Direcc_1">
                            <HeaderStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Sender_Direcc_2" HeaderText="Direcc_2" 
                                SortExpression="Sender_Direcc_2" />
                            <asp:BoundField DataField="Telefono" HeaderText="Telefono" 
                                SortExpression="Telefono" />
                            <asp:BoundField DataField="Sender_City" HeaderText="Sender_City" 
                                SortExpression="Sender_City" />
                            <asp:BoundField DataField="Sender_Phone" HeaderText="Sender_Phone" 
                                SortExpression="Sender_Phone" Visible="False" />
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
                        SelectCommand="SELECT id_Sender, Sender_Nombre, Sender_Apellido, Sender_Direcc_1, Sender_Direcc_2, Telefono, Sender_City, Sender_Phone FROM tbl_Cuba_N_Sender ORDER BY Sender_Nombre" 
                        UpdateCommand="UPDATE tbl_Cuba_N_Sender SET Sender_Nombre =@Sender_Nombre, Sender_Apellido =@Sender_Apellido, Sender_Direcc_1 =@Sender_Direcc_1, Sender_Direcc_2 =@Sender_Direcc_2, Telefono =@Telefono, Sender_City =@Sender_City, Sender_Phone = Sender_Phone where id_Sender=@id_Sender">
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
                        <UpdateParameters>
                            <asp:Parameter Name="Sender_Nombre" />
                            <asp:Parameter Name="Sender_Apellido" />
                            <asp:Parameter Name="Sender_Direcc_1" />
                            <asp:Parameter Name="Sender_Direcc_2" />
                            <asp:Parameter Name="Telefono" />
                            <asp:Parameter Name="Sender_City" />
                            <asp:Parameter Name="id_Sender" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:ImageButton ID="ImageButton2" runat="server" 
                        ImageUrl="~/Iconos/newIcon.png" onclick="ImageButton2_Click" Height="22px" 
                        Width="25px" />
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Panel ID="Panel2" runat="server" Height="124px" Width="811px">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="id_sender" runat="server" Width="42px" Visible="False"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;<asp:TextBox ID="id_provincia" runat="server" Width="42px" 
                            Visible="False"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Agregar destinatario :
                        <asp:Label ID="Label_Nombre" runat="server" Text="Label"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="ImageButton3" runat="server" Height="28px" 
                            ImageUrl="~/Iconos/Save-icon.png" onclick="ImageButton3_Click" Width="33px" />
                        &nbsp;&nbsp;
                        <asp:ImageButton ID="ImageButton4" runat="server" Height="28px" 
                            ImageUrl="~/Iconos/Cancel.png" onclick="ImageButton4_Click" Width="34px" />
                        <br />
                        <br />
                        &nbsp;&nbsp;
                        <asp:TextBox ID="tb_DestNombre" runat="server" placeholder="Nombre" 
                            Width="181px"></asp:TextBox>
                        &nbsp; &nbsp;<asp:TextBox ID="tb_DestApellido" runat="server" placeholder="Apellido" 
                            Width="181px"></asp:TextBox>
                        &nbsp;&nbsp;<asp:TextBox ID="tb_DestTelefono" runat="server" Width="181px" 
    placeholder="Telefono"></asp:TextBox>
                        &nbsp;
                        <asp:TextBox ID="tb_DestCelle" runat="server" placeholder="Calle" Width="181px"></asp:TextBox>
                        &nbsp;&nbsp;<br /> 
                        <br />
                        &nbsp;&nbsp;
                        <asp:TextBox ID="tb_DestEntreCalles" runat="server" placeholder="Entre Calles" 
                            Width="181px"></asp:TextBox>
                        &nbsp;&nbsp;
                        <asp:DropDownList ID="tb_DestProvincia" runat="server" AutoPostBack="True" 
                            Height="16px" onselectedindexchanged="tb_DestProvincia_SelectedIndexChanged" 
                            Width="181px">
                        </asp:DropDownList>
                        &nbsp;&nbsp;<asp:DropDownList ID="tb_DestMinicipio" runat="server" Height="16px" 
                            Width="181px">
                        </asp:DropDownList>
                        &nbsp;&nbsp;<asp:TextBox ID="tb_DestCI" runat="server" placeholder=" CI " Width="181px"></asp:TextBox>
&nbsp;
                        <br />
                        <br />
                    </asp:Panel>
&nbsp;&nbsp;
                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
                        BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="2" 
                        DataKeyNames="id_Destinatario" DataSourceID="SqlDataSource2" GridLines="Horizontal" 
                        style="font-size: xx-small" Width="897px">
                        <Columns>
                            <asp:CommandField ButtonType="Image" EditImageUrl="~/Iconos/edit.png" 
                                ShowEditButton="True" >
                            <HeaderStyle Width="10px" />
                            </asp:CommandField>
                            <asp:BoundField DataField="id_Destinatario" HeaderText="id" InsertVisible="False" 
                                ReadOnly="True" SortExpression="id_Destinatario">
                            <HeaderStyle Width="2px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Dest_Nombre" HeaderText="Dest_Nombre" 
                                SortExpression="Dest_Nombre">
                            </asp:BoundField>
                            <asp:BoundField DataField="Dest_Apellido" HeaderText="Dest_Apellido" 
                                SortExpression="Dest_Apellido">
                            </asp:BoundField>
                            <asp:BoundField DataField="Telefono" HeaderText="Telefono" 
                                SortExpression="Telefono">
                            </asp:BoundField>
                            <asp:BoundField DataField="Calle" HeaderText="Calle" 
                                SortExpression="Calle" />
                            <asp:BoundField DataField="Entre_Calles" HeaderText="Entre_Calles" 
                                SortExpression="Entre_Calles" />
                            <asp:BoundField DataField="Provincias" HeaderText="Provincias" 
                                SortExpression="Provincias" />
                            <asp:BoundField DataField="Municipio" HeaderText="Municipio" 
                                SortExpression="Municipio" />
                            <asp:BoundField DataField="Sender" HeaderText="Sender" 
                                SortExpression="Sender" Visible="False" />
                            <asp:BoundField DataField="CI" HeaderText="CI" SortExpression="CI" />
                            <asp:BoundField DataField="aa" HeaderText="aa" SortExpression="aa" 
                                Visible="False" />
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
                        SelectCommand="SELECT [id_Destinatario], [Dest_Nombre], [Dest_Apellido], [Telefono], [Calle], [Entre_Calles], [Provincias], [Municipio], [Sender], [CI], [aa] FROM [tbl_Cuba_N_Destinatario] WHERE ([Sender] = @Sender)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="id_sender" Name="Sender" PropertyName="Text" 
                                Type="Int32" />
                        </SelectParameters>
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
                </td>
            </tr>
            <tr>
                <td class="style2">
                </td>
            </tr>
        </table>
    </p>
</asp:Content>
