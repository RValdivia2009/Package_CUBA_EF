﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rep_WareHouseReceive.aspx.cs" Inherits="Package_WebApp.PagesMembers.Reports.WareHouseReceive" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="TextBoxManif" runat="server"></asp:TextBox>
    
        &nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    
        <br />
    
    </div>
        
         <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="589px">
        </rsweb:ReportViewer>
    
        



    </form>
</body>
</html>
