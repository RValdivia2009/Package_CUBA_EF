<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPackage.master" AutoEventWireup="true" CodeBehind="CubaRegister.aspx.cs" Inherits="Package_WebApp.PagesMembers.CubaRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<p>
        <table>
                <tr>
                    <td><b>Name</b></td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <b>Email</b>

                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <b>Age</b></td>
                    <td>
                        <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><b>Salary</b></td>
                    <td>
                        <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button Text="Save" OnClick="btnSave_Click" ID="btnSave" runat="server" />
                        <%--//======= By default we have made update button visible false. So that
                        when ever page loads first time only save and cancel buttons are visible.--%>
                        <asp:Button Text="Update" ID="btnUpdate" OnClick="btnUpdate_Click" Visible="false" runat="server" />
                        <asp:Button Text="Cancel" ID="btnCancel" runat="server" OnClick="btnCancel_Click" />

                    </td>
                </tr>
            </table>

            </div>

           <asp:HiddenField ID="hfSelectedRecord" runat="server" />
        <table id="tblEmpDetails">
            <tr class="altRow">
                <td>
                    <b>Sno</b>
                </td>
                <td>
                    <b>Name</b>
                </td>
                <td>
                    <b>Email</b>
                </td>
                <td style="width: 65px">
                    <b>Age</b>
                </td>
                <td>
                    <b>Salary</b>
                </td>
                <td>
                    <b>Action</b>
                </td>
            </tr>
            <asp:ListView ID="lstViewEmployeeDetails" OnItemCommand="lstViewEmployeeDetails_ItemCommand" runat="server">
                <ItemTemplate>

                    <tr class="<%#(Container.DataItemIndex+1)%2==0?" altrow":"normalrow"%>">
                        <td>
                            <%#Container.DataItemIndex+1%>
                        </td>
                        <td>
                            <%#Eval("id_Cuba_Package_Main")%>
                        </td>
                        <td>
                            <%#Eval("Destinatario")%>
                        </td>
                        <td>
                            <%#Eval("Sender")%>
                        </td>
                        <td>
                            <%#Eval("Estado")%>
                        </td>
                        <td>
                            <%--//==== Here we have used CommandName property to distinguish which button is 
                            clicked and we have passed our primary key to CommandArgument property. ====//--%>
                            <asp:ImageButton ID="imgBtnEdit" CommandName="Edt" ToolTip="Edit a record." CommandArgument='<%#Eval("id_Cuba_Package_Main") %>' runat="server" ImageUrl="~/Iconos/edit.png" />
                            <asp:ImageButton ToolTip="Delete a record." OnClientClick="javascript:return confirm('Are you sure to delete record?')" ID="imgBtnDelete" CommandName="Del" CommandArgument='<%#Eval("id_Cuba_Package_Main") %>' runat="server" ImageUrl="~/Iconos/delete.png"></asp:ImageButton>

                        </td>
                    </tr>

                </ItemTemplate>
            </asp:ListView>

        </table>



        <p>
 




</asp:Content>
