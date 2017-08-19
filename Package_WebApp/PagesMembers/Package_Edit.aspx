<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPackage.master" AutoEventWireup="true" CodeBehind="Package_Edit.aspx.cs" Inherits="Package_WebApp.PagesMembers.Package_Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style3">
        <tr>
            <td class="style9">
                <strong><em>Edicion</em></strong></td>
        </tr>
        <tr>
            <td class="style13">
                <table style="width:100%;">
                    <tr>
                        <td class="style66" width="80">
                                &nbsp;</td>
                        <td class="style133">
                            <asp:TextBox ID="ID_Package" runat="server" Width="63px" Height="20px" 
                                    style="font-weight: 700; font-size: medium; font-family: 'Arial Black'; text-align: center"></asp:TextBox>
                        </td>
                        <td class="style129" colspan="2">
                                Date:</td>
                        <td class="style66" style="width: 0">
                            <asp:TextBox ID="Fecha" runat="server" ontextchanged="date_TextChanged" 
                                    Width="127px" EnableViewState="False"></asp:TextBox>
                        </td>
                        <td class="style128">
                            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" 
                                    Width="45px" />
                        </td>
                        <td class="style51" colspan="2" rowspan="5" width="50">
                                &nbsp;</td>
                        <td class="style51" rowspan="5" valign="top">
                            <asp:Calendar ID="Calendar1" runat="server" 
                                    onselectionchanged="Calendar1_SelectionChanged" Height="70px" 
                                    BackColor="White" BorderColor="#999999" CellPadding="4" 
                                    DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
                                    Width="100px">
                                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                <NextPrevStyle VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#808080" />
                                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                <SelectorStyle BackColor="#CCCCCC" />
                                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <WeekendDayStyle BackColor="#FFFFCC" />
                            </asp:Calendar>
                        </td>
                        <td class="style33" colspan="2" rowspan="2">
                                &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style66" width="80">
                                Tracking:</td>
                        <td class="style133">
                            <asp:TextBox ID="Tracking" runat="server" Width="152px" Height="20px"></asp:TextBox>
                        </td>
                        <td class="style129" colspan="2">
                                Notas:</td>
                        <td class="style66" colspan="2">
                            <asp:TextBox ID="Nota" runat="server" Width="158px" Height="20px" 
                                    style="text-align: left"></asp:TextBox>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="style99" width="80">
                                Shipper:</td>
                        <td class="style134">
                            <asp:DropDownList ID="shipper" runat="server" CssClass="style127" Height="17px" 
                                    Width="156px">
                            </asp:DropDownList>
&nbsp;</td>
                        <td class="style130" colspan="2">
                                Estado:</td>
                        <td class="style66" colspan="2">
                            <asp:DropDownList ID="estado" runat="server" CssClass="style127" Height="16px" 
                                    Width="166px">
                            </asp:DropDownList>
                        </td>
                        <td class="style67" colspan="2" rowspan="6">
                                &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style118" width="80">
                                Destination:</td>
                        <td class="style135">
                            <asp:DropDownList ID="destino" runat="server" AutoPostBack="True" 
                                    CssClass="style127" Height="16px" 
                                    onselectedindexchanged="destino_SelectedIndexChanged" Width="156px">
                            </asp:DropDownList>
&nbsp;</td>
                        <td class="style131" colspan="2">
                                &nbsp;</td>
                        <td class="style118" colspan="2">
                            <asp:Button ID="Guardar" runat="server" onclick="Guardar_Click" 
                                    Text="Guardar" Width="73px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style66" width="80">
                                Cosignee:</td>
                        <td class="style133">
                            <asp:DropDownList ID="cosignee" runat="server" CssClass="style127" 
                                    Height="16px" Width="156px">
                            </asp:DropDownList>
&nbsp;</td>
                        <td class="style129" colspan="2">
                                &nbsp;</td>
                        <td class="style66" colspan="2">
                            <asp:Button ID="Update" runat="server" onclick="Update_Click" Text="Update" 
                                    Width="74px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style123" width="80">
                            <br />
                        </td>
                        <td class="style136">
                            <br />
                        </td>
                        <td class="style132" colspan="2">
                        </td>
                        <td class="style123" colspan="2">
                            <asp:Button ID="Nuevo" runat="server" onclick="Nuevo_Click" Text="Nuevo" 
                                    Width="75px" />
                        </td>
                        <td class="style124" colspan="3" width="600">
                                &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style125" colspan="7">
                                &nbsp;</td>
                        <td class="style126" colspan="2">
                            <asp:TextBox ID="TextBox1" runat="server" Height="16px" Visible="False" 
                                    Width="31px"></asp:TextBox>
                            <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Button" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style79" colspan="9">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                    AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" 
                                    GridLines="None" Width="888px" Font-Size="Smaller" 
                                    onpageindexchanging="GridView1_PageIndexChanging" PageSize="5" 
                                    onselectedindexchanged="GridView1_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                            </asp:GridView>
                                &nbsp;&nbsp;
                                <asp:Button ID="btnActualizar" runat="server" onclick="btnActualizar_Click1" 
                                    Text="Actualizar" Width="67px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style14" colspan="3">
                                &nbsp;</td>
                        <td class="style14" colspan="3">
                                &nbsp;</td>
                        <td class="style55" colspan="4">
                                &nbsp;</td>
                        <td class="style60">
                                &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style14" colspan="3">
                                &nbsp;</td>
                        <td class="style14" colspan="3">
                                &nbsp;</td>
                        <td class="style55" colspan="4">
                                &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style14" colspan="3">
                                &nbsp;</td>
                        <td class="style14" colspan="3">
                                &nbsp;</td>
                        <td class="style55" colspan="4">
                                &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
