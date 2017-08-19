<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PackageGeneral.aspx.cs" Inherits="Package_WebApp.PagesMembers.PackageGeneral" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style3" style="width: 1224px">
        <tr>
            <td class="style9" colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9" colspan="2">
                <asp:Button ID="Button_first" runat="server" Text="First" 
                    onclick="Button_first_Click" />
&nbsp;&nbsp;&nbsp;<asp:Button ID="Button_preview" runat="server" Text="Preview" Width="48px" 
                    onclick="Button_preview_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Text="i  de  n"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button_Next" runat="server" Text="Next" 
                    onclick="Button_Next_Click" />
&nbsp;&nbsp;
                <asp:Button ID="Button_last" runat="server" Text="Last" 
                    onclick="Button_last_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Guardar" runat="server" onclick="Guardar_Click" 
                                    Text="Guardar" Width="73px" />
                <asp:Button ID="Update" runat="server" onclick="Update_Click" Text="Update" 
                                    Width="74px" />
                <asp:Button ID="Nuevo" runat="server" onclick="Nuevo_Click" Text="Nuevo" 
                                    Width="75px" />
                            &nbsp;
                <asp:Button ID="edit" runat="server" onclick="edit_Click" Text="Edit" 
                    Width="61px" />
                &nbsp;&nbsp;<asp:Button ID="Cancel" runat="server" onclick="Cancel_Click" Text="Cancel" 
                                Width="78px" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;
                </td>
            <td class="style9" style="text-align: left" valign="top">
                &nbsp;<asp:Label ID="WR" runat="server" 
                    style="font-weight: 700; font-size: x-large; font-family: 'Arial Black'; color: #660033" 
                    Text="WR"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style9" style="width: 851px">
                &nbsp;</td>
            <td class="style9" style="width: 834px" colspan="2">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td class="style13" colspan="3">
                <table style="width:100%;">
                    <tr>
                        <td class="style66" width="80" 
                            style="border-top-style: solid; border-top-width: 1px; padding: 0">
                                &nbsp;</td>
                        <td class="style133" 
                            style="padding: 0; width: 161px; text-align: right; color: #660033; border-top-style: solid; border-top-width: 1px;">
                            <strong>General:</strong></td>
                        <td style="padding: 0; width: 54px; border-top-style: solid; border-top-width: 1px;">
                                &nbsp;</td>
                        <td style="padding: 0; width: 197px; border-top-style: solid; border-top-width: 1px;">
                                &nbsp;</td>
                        <td class="style66" style="width: 29px" rowspan="13">
                            &nbsp;</td>
                        <td valign="middle">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <span style="color: #660033"><strong>Commodities:</strong></span>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style66" width="80" 
                            style="border-left-style: solid; border-left-width: 1px; padding: 0">
                                &nbsp;</td>
                        <td class="style133" style="width: 161px">
                            &nbsp;</td>
                        <td style="width: 54px">
                                &nbsp;</td>
                        <td style="padding: 1px 4px; width: 197px">
                                &nbsp;</td>
                        <td valign="middle">
                            Descripcion:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            Tracking</td>
                    </tr>
                    <tr>
                        <td class="style66" width="80" 
                            style="border-left-style: solid; border-left-width: 1px; padding: 0">
                                Tracking:</td>
                        <td class="style133" style="width: 161px">
                            <asp:TextBox ID="Tracking" runat="server" Width="188px" Height="16px"></asp:TextBox>
                        </td>
                        <td style="width: 54px">
                                Date:</td>
                        <td style="padding: 1px 4px; width: 197px">
                            <asp:TextBox ID="Fecha" runat="server" ontextchanged="date_TextChanged" 
                                    Width="131px" EnableViewState="False" Height="18px"></asp:TextBox>
                        &nbsp;
                            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" 
                                    Width="45px" Height="18px" />
                        </td>
                        <td valign="middle">
                            <asp:TextBox ID="Text_Desc" runat="server" Height="16px" Width="210px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextTracking" runat="server" Height="16px" Width="206px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="80" 
                            
                            style="border-left-style: solid; border-left-width: 1px; padding: 0; height: 2px;">
                        </td>
                        <td class="style133" style="width: 161px; height: 2px;">
                        </td>
                        <td style="width: 54px; height: 2px;">
                        </td>
                        <td style="padding: 1px 4px; width: 197px; height: 2px;">
                        </td>
                        <td valign="middle" style="height: 2px">
                        </td>
                    </tr>
                    <tr>
                        <td class="style66" width="80" 
                            style="border-left-style: solid; border-left-width: 1px; padding: 0">
                                Shipper:</td>
                        <td class="style133" style="width: 161px">
                            <asp:DropDownList ID="shipper" runat="server" CssClass="style127" Height="16px" 
                                    Width="196px">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 54px">
                                Notas:</td>
                        <td style="padding: 1px 4px; width: 197px">
                                &nbsp;<asp:TextBox ID="Nota" runat="server" Width="185px" Height="17px" 
                                    style="text-align: left"></asp:TextBox>
                        </td>
                        <td valign="middle">
                            PCs:&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextPcs" runat="server" Height="16px" Width="34px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp; Weight:
                            <asp:TextBox ID="TextWeight" runat="server" Height="16px" Width="37px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim (L x W x H)&nbsp;&nbsp;
                            <asp:TextBox ID="TextLong" runat="server" Height="16px" Width="23px"></asp:TextBox>
&nbsp;&nbsp;
                            <asp:TextBox ID="TextBoxWide" runat="server" Height="16px" Width="23px"></asp:TextBox>
&nbsp;&nbsp;
                            <asp:TextBox ID="TextHigh" runat="server" Height="16px" Width="23px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="80" 
                            style="border-left-style: solid; border-left-width: 1px; padding: 0">
                        </td>
                        <td class="style133" style="width: 161px; ">
                        </td>
                        <td style="width: 54px; ">
                        </td>
                        <td style="padding: 1px 4px; width: 197px; ">
                        </td>
                        <td valign="middle">
                        </td>
                    </tr>
                    <tr>
                        <td class="style66" width="80" 
                            style="height: 21px; border-left-style: solid; border-left-width: 1px; padding: 0">
                                Destination:</td>
                        <td class="style133" style="width: 161px; height: 21px;">
                            <asp:DropDownList ID="destino" runat="server" AutoPostBack="True" 
                                    CssClass="style127" Height="16px" 
                                    onselectedindexchanged="destino_SelectedIndexChanged" Width="196px">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 54px; height: 21px;">
                                Estado:</td>
                        <td style="padding: 1px 4px; width: 197px; height: 21px;">
                            <asp:DropDownList ID="estado" runat="server" CssClass="style127" Height="16px" 
                                    Width="189px">
                            </asp:DropDownList>
                        </td>
                        <td style="height: 21px" valign="middle">
                            Value:
                            <asp:TextBox ID="TextValue" runat="server" Height="17px" Width="46px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TotalValue:
                            <asp:TextBox ID="TextTValue" runat="server" Height="17px" Width="47px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="80" 
                            style="border-left-style: solid; border-left-width: 1px; padding: 0">
                        </td>
                        <td class="style133" style="width: 161px; ">
                        </td>
                        <td style="width: 54px; ">
                        </td>
                        <td style="padding: 1px 4px; width: 197px; ">
                        </td>
                        <td valign="middle">
                        </td>
                    </tr>
                    <tr>
                        <td width="80" 
                            style="border-left-style: solid; border-left-width: 1px; padding: 0">
                                Cosignee:</td>
                        <td class="style133" style="width: 161px; ">
                            <asp:DropDownList ID="cosignee" runat="server" CssClass="style127" 
                                    Height="17px" Width="196px" AutoPostBack="True" 
                                onselectedindexchanged="cosignee_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 54px; ">
                        </td>
                        <td style="padding: 1px 4px; width: 197px; ">
                        </td>
                        <td rowspan="5" valign="top">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                                GridLines="None" Width="619px" style="font-size: x-small" 
                                onselectedindexchanged="GridView1_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" >
                                    <HeaderStyle Width="25px" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="Package_Main" HeaderText="Package_Main" 
                                        SortExpression="Package_Main" Visible="False" />
                                    <asp:BoundField DataField="id_WR" HeaderText="WR" SortExpression="id_WR" 
                                        Visible="False" />
                                    <asp:BoundField DataField="Descrip" HeaderText="Descrip" 
                                        SortExpression="Descrip" >
                                    <HeaderStyle Width="150px" Wrap="True" />
                                    <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Tracking" HeaderText="Tracking" 
                                        SortExpression="Tracking" >
                                    <HeaderStyle Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Quantity" HeaderText="PCs" 
                                        SortExpression="Quantity" >
                                    <HeaderStyle Width="8px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Weight" HeaderText="Weight" 
                                        SortExpression="Weight" >
                                    <HeaderStyle Width="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Long" HeaderText="Long" SortExpression="Long" >
                                    <HeaderStyle Width="8px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Wide" HeaderText="Wide" SortExpression="Wide" >
                                    <HeaderStyle Width="8px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="High" HeaderText="High" SortExpression="High" >
                                    <HeaderStyle Width="8px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Value" HeaderText="Val" SortExpression="Value" >
                                    <HeaderStyle Width="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalValue" HeaderText="TotlVal" 
                                        SortExpression="TotalValue" >
                                    <HeaderStyle Width="15px" />
                                    </asp:BoundField>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ITN_DataBaseConnectionString2 %>" 
                                SelectCommand="SELECT [Package_Main], [Tracking], [id_WR], [Long], [Wide], [High], [Weight], [Quantity], [Value], [TotalValue], [Descrip] FROM [TBL_Package_Main_Detalles] WHERE ([id_WR] = @id_WR)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="WR" Name="id_WR" PropertyName="Text" 
                                        Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td width="80" 
                            style="border-left-style: solid; border-left-width: 1px; padding: 0">
                        </td>
                        <td class="style133" style="width: 161px; ">
                        </td>
                        <td style="width: 54px; ">
                        </td>
                        <td style="padding: 1px 4px; width: 197px; ">
                        </td>
                    </tr>
                    <tr>
                        <td class="style66" width="80" 
                            style="height: 21px; border-left-style: solid; border-left-width: 1px; padding: 0">
                            Location:</td>
                        <td class="style133" style="width: 161px; height: 21px;">
                            <asp:DropDownList ID="location" runat="server" Width="196px" Height="16px" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 54px; height: 21px;">
                                &nbsp;</td>
                        <td style="padding: 1px 4px; width: 197px; height: 21px;">
                                &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style66" width="80" 
                            style="height: 21px; border-left-style: solid; border-left-width: 1px; padding: 0">
                            &nbsp;</td>
                        <td class="style133" 
                            style="padding: 0; width: 161px; height: 21px; border-bottom-style: groove; border-bottom-width: 1px;">
                            &nbsp;</td>
                        <td style="padding: 0; width: 54px; height: 21px; border-bottom-style: groove; border-bottom-width: 1px;">
                            &nbsp;</td>
                        <td style="padding: 1px 4px; width: 197px; height: 21px;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style66" width="80" 
                            
                            style="height: 21px; border-left-style: solid; border-left-width: 1px; padding: 0" 
                            colspan="4">
&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style14" colspan="6">
                            <asp:TextBox ID="TextBoxDest" runat="server" Height="19px" 
                                    Width="29px">Dest</asp:TextBox>
                        &nbsp;
                                <asp:TextBox ID="TextBoxPosition" runat="server" Height="18px" 
                                    Width="35px"></asp:TextBox>
                        &nbsp;
                            <asp:TextBox ID="TextBoxCnee" runat="server" Height="18px" Width="28px">Cnee</asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextBoxID" runat="server" Width="89px">WR</asp:TextBox>
&nbsp;&nbsp;
                            <asp:Button ID="Button3" runat="server" onclick="Button3_Click1" 
                    Text="Button" Height="19px" />
                        &nbsp;&nbsp;
                            <asp:TextBox ID="ID_Package" runat="server" Width="63px" Height="20px" 
                                    style="font-size: x-small; font-family: Arial; text-align: center">ID_Package</asp:TextBox>
&nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
