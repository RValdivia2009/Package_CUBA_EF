<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cuba_PackageManifiesto.aspx.cs" Inherits="Package_WebApp.PagesMembers.Cuba_PackageManifiesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .style6
        {
            width: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:ImageButton ID="det_New" runat="server" Height="22px" 
                                        ImageUrl="~/Iconos/New1.png" onclick="det_New_Click" Width="22px" />
&nbsp;&nbsp;&nbsp; <span class="style4"><strong><em>Manifiestos&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:DropDownList ID="tb_ManifiestoIMP" runat="server" AutoPostBack="True" 
                                        Height="22px" onselectedindexchanged="tb_ManifiestoIMP_SelectedIndexChanged" 
                                        style="font-size: x-small; font-weight: 700; color: #800000; font-family: 'Arial Black'" 
                                        Width="113px">
    </asp:DropDownList>
    </em></strong></span>&nbsp; <span class="style4"><strong><em>
    <asp:ImageButton ID="ImageButtonMani" runat="server" Height="20px" 
                                        ImageUrl="~/Iconos/Letter1.png" onclick="ImageButtonMani_Click" Width="33px" />
    </em></strong></span>&nbsp;&nbsp;&nbsp; &nbsp;<table class="style1">
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                <asp:Panel ID="Panel1" runat="server" Height="34px" Width="306px">
                                                    &nbsp;&nbsp;
                                                    <asp:TextBox ID="tb_Manifiesto" runat="server" placeholder="Manifiesto"></asp:TextBox>
                                                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                                                    <asp:ImageButton ID="ImageButton3" runat="server" Height="25px" 
                                                        ImageUrl="~/Iconos/Save-icon.png" onclick="ImageButton3_Click" Width="25px" />
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:ImageButton ID="ImageButton4" runat="server" Height="25px" 
                                                        ImageUrl="~/Iconos/Cancel.png" onclick="ImageButton4_Click" Width="25px" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                                    BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" 
                                                    CellPadding="2" DataKeyNames="id_Manifiestos" DataSourceID="SqlDataSource1" 
                                                    GridLines="Horizontal" Height="151px" 
                                                    onselectedindexchanged="GridView1_SelectedIndexChanged" ShowFooter="True" 
                                                    style="font-size: xx-small" Width="346px">
                    <Columns>
                        <asp:CommandField ButtonType="Image" CancelImageUrl="~/Iconos/Cancel.png" 
                                                            EditImageUrl="~/Iconos/edit.png" ShowEditButton="True" 
                                                            UpdateImageUrl="~/Iconos/Ok-icon.png">
                        <ControlStyle Height="18px" Width="18px" />
                        </asp:CommandField>
                        <asp:BoundField DataField="id_Manifiestos" InsertVisible="False" 
                                                            ReadOnly="True" SortExpression="id_Manifiestos">
                        <HeaderStyle Width="4px" />
                        <ItemStyle ForeColor="White" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Nom_Manifiesto" HeaderText="Manifiesto" 
                                                            SortExpression="Nom_Manifiesto">
                        <ControlStyle Width="50px" />
                        <ItemStyle Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Iconos/delete-icon.png" 
                                                            ShowDeleteButton="True">
                        <ControlStyle Height="13px" Width="13px" />
                        </asp:CommandField>
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
                                                    DeleteCommand="DELETE FROM tbl_Cuba_Manifiestos WHERE (id_Manifiestos = @id_Manifiestos)" 
                                                    InsertCommand="INSERT INTO tbl_Cuba_Manifiestos(Nom_Manifiesto, Fecha) VALUES (@Nom_Manifiesto, @Fecha)" 
                                                    SelectCommand="SELECT id_Manifiestos, Nom_Manifiesto, Fecha FROM tbl_Cuba_Manifiestos ORDER BY id_Manifiestos DESC" 
                                                    UpdateCommand="UPDATE tbl_Cuba_Manifiestos SET Nom_Manifiesto = @Nom_Manifiesto, Fecha = @Fecha WHERE (id_Manifiestos = @id_Manifiestos)">
                    <DeleteParameters>
                        <asp:Parameter Name="id_Manifiestos" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Nom_Manifiesto" />
                        <asp:Parameter Name="Fecha" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Nom_Manifiesto" />
                        <asp:Parameter Name="Fecha" />
                        <asp:Parameter Name="id_Manifiestos" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
&nbsp;&nbsp;</p>
    <p>
                                &nbsp;</p>
    <p>
                                &nbsp;</p>
    <p>
                                &nbsp;</p>
    <p>
                                &nbsp;</p>
    <p>
                                &nbsp;</p>
    <p>
                                &nbsp;</p>
    <p>
                                &nbsp;</p>
</asp:Content>
