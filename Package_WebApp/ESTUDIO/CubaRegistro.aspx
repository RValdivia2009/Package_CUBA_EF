<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPackage.master" AutoEventWireup="true" CodeBehind="CubaRegistro.aspx.cs" Inherits="Package_WebApp.ESTUDIO.CubaRegistro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="width: 100%">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                     <%--//==== Here we have used CommandName property to distinguish which button is 
                            clicked and we have passed our primary key to CommandArgument property. ====//--%>
                            <asp:ImageButton ID="imgBtnEdit" CommandName="Edt" ToolTip="Edit a record." CommandArgument='<%#Eval("id_Cuba_Package_Main") %>' runat="server" ImageUrl="~/Iconos/edit.png" />
                            <asp:ImageButton ToolTip="Delete a record." OnClientClick="javascript:return confirm('Are you sure to delete record?')" ID="imgBtnDelete" CommandName="Del" CommandArgument='<%#Eval("id_Cuba_Package_Main") %>' runat="server" ImageUrl="~/Iconos/delete.png"></asp:ImageButton>
                
                
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:ListView ID="ListView2" runat="server" DataSourceID="SqlDataSource1">
                    <AlternatingItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Label ID="WRLabel" runat="server" Text='<%# Eval("WR") %>' />
                            </td>
                            <td>
                                <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <EditItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                                    Text="Update" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                    Text="Cancel" />
                            </td>
                            <td>
                                <asp:TextBox ID="WRTextBox" runat="server" Text='<%# Bind("WR") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="DateTextBox" runat="server" Text='<%# Bind("Date") %>' />
                            </td>
                        </tr>
                    </EditItemTemplate>
                    <EmptyDataTemplate>
                        <table runat="server" style="">
                            <tr>
                                <td>
                                    No data was returned.</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <InsertItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                                    Text="Insert" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                    Text="Clear" />
                            </td>
                            <td>
                                <asp:TextBox ID="WRTextBox" runat="server" Text='<%# Bind("WR") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="DateTextBox" runat="server" Text='<%# Bind("Date") %>' />
                            </td>
                        </tr>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Label ID="WRLabel" runat="server" Text='<%# Eval("WR") %>' />
                            </td>
                            <td>
                                <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table ID="itemPlaceholderContainer" runat="server" border="0" style="">
                                        <tr runat="server" style="">
                                            <th runat="server">
                                                WR</th>
                                            <th runat="server">
                                                Date</th>
                                        </tr>
                                        <tr ID="itemPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server" style="">
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <SelectedItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Label ID="WRLabel" runat="server" Text='<%# Eval("WR") %>' />
                            </td>
                            <td>
                                <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                            </td>
                        </tr>
                    </SelectedItemTemplate>
                </asp:ListView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DB_82130_itndatabaseConnectionString %>" 
                    SelectCommand="SELECT [WR], [Date] FROM [TBL_Cuba_Package_Main]">
                </asp:SqlDataSource>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>
