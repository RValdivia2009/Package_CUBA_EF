<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            font: normal 11px verdana;
            padding-left: 31%;
            padding-top: 12%;
        }

        #tblEmpDetails {
            width: 500px;
            border: 1px solid black;
            padding: 0px;
            margin: 0px;
            border-collapse: collapse;
        }

            #tblEmpDetails td {
                padding: 5px;
            }

        .normalRow {
            background-color: #EFEFEF;
        }



        .altRow {
            background-color: #EEEEEE;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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

        <hr />

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
                <td>
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
                            <%#Eval("Name") %>
                        </td>
                        <td>
                            <%#Eval("Email") %>
                        </td>
                        <td>
                            <%#Eval("Age") %>
                        </td>
                        <td>
                            <%#Eval("Salary") %>
                        </td>




    <%--                    <td>
                            <%--//==== Here we have used CommandName property to distinguish which button is 
                        clicked and we have passed our primary key to CommandArgument property. ====//--%>
                            <asp:ImageButton ID="imgBtnEdit" CommandName="Edt" ToolTip="Edit a record." CommandArgument='<%#Eval("Id") %>' runat="server" ImageUrl="edit.png" />
                            <asp:ImageButton ToolTip="Delete a record." OnClientClick="javascript:return confirm('Are you sure to delete record?')" ID="imgBtnDelete" CommandName="Del" CommandArgument='<%#Eval("Id") %>' runat="server" ImageUrl="delete.png"></asp:ImageButton>
--%>
                        </td>
                    </tr>

                </ItemTemplate>
            </asp:ListView>

        </table>
    </form>
</body>
</html>
