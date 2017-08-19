<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cuba_Export_Import_Agen.aspx.cs" Inherits="Package_WebApp.PagesMembers.Cuba_Export_Import_Agen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style7
        {
            font-size: small;
        }
        .style8
        {
            color: #800000;
        }
        .style6
        {
            color: #FF3300;
        }
        .style9
        {
            color: #FF0000;
            font-size: large;
        }
        .style11
        {
            width: 38px;
            height: 29px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        &nbsp;</p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;
    </p>

 <html> 
 <body> 
    
<br />
             <br />
        
        
                <div>
                    <table border="0" cellpadding="5" cellspacing="5" style="border: solid 2px Red; background-color: skyblue; width: 100%;">  
                        <tr>  
                            <td colspan="2" style="background-color: #0638B7; color: #F2EB09; font-weight: bold; font-size: 12pt; text-align: center; font-family: Verdana;">EXPORTAR ficheros para la agencia Principal</td>  
                        </tr>  
                        <tr>  
                            <td style="text-align: center;">  
                                <asp:TextBox ID="tb_AWB" runat="server" placeholder="Envio a exportar."></asp:TextBox>
                                                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                                <asp:Button ID="Button1" runat="server" Text="Exportar " OnClick="btn_Export_Click" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" 
                                 ForeColor="#FF3300" Text=".."></asp:Label>
                            </td>  
                        </tr>  
                    </table>  
               </div>
    

                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
              <div>
                    <table border="0" cellpadding="5" cellspacing="5" style="border: solid 2px Red; background-color: skyblue; width: 100%;">  
                        <tr>  
                            <td colspan="2" style="background-color: #0638B7; color: #F2EB09; font-weight: bold; font-size: 12pt; text-align: center; font-family: Verdana;">IMPORTAR ficheros en la agencia Principal</td>  
                        </tr>  
                        <tr>  
                            <td style="text-align: center;">  
                        
                                 &nbsp;&nbsp;&nbsp;&nbsp;
                          
                       
                           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                           <ContentTemplate>
                                         <asp:FileUpload ID="FileUpload1" runat="server" />
                                         <asp:Button ID="Button2" runat="server" Height="26px" onclick="Button2_Click" Text="Cargar Ficheros" Width="104px" /> &nbsp;


                                          <br />
                            </ContentTemplate>
                              <Triggers> 
                                    <asp:PostBackTrigger  ControlID  =  "Button2"  /> 
                              </Triggers > 
                            </asp:UpdatePanel>
                            
                            <asp:Panel ID="Panel1" runat="server" Height="103px">
                                       <br />
                                       <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                           <ContentTemplate>
                                               <br />
                                               &nbsp;<span class="style6"><span class="style7">&nbsp;</span><span class="style8"><span 
                                                   class="style7">Contenido a Importa</span>r -&gt;</span>&nbsp; </span>
                                               <span class="style7">
                                               <asp:Label ID="Lb_CantPaquetes" runat="server" CssClass="style6" Text="Label"></asp:Label>
                                               <span class="style6">&nbsp;</span><span class="style8">Paquetes&nbsp;&nbsp;&nbsp;&nbsp;</span></span>
                                               <span class="style7"><span class="style8">
                                               <asp:Button ID="Insert" runat="server" Height="28px" onclick="Insert_Click" 
                                                   Text="Insert" Width="138px" />
                                               </span></span>
                                               <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                                                   <ProgressTemplate>
                                                       <br />
                                                       &nbsp;&nbsp; <span class="style9">Importando ficheros a la Base de Datos. Favor Espere...<br />
                                                       <img class="style11" 
    src="../Iconos/load2.gif" />
                                                       </span><br />
                                                   </ProgressTemplate>
                                               </asp:UpdateProgress>
                                               <br />
                                           </ContentTemplate>
                                       </asp:UpdatePanel>
                                       <br />
                                       <br />
                                       &nbsp;<br />
                            </asp:Panel>
                                       <br />
                         


     

                            </td>  
                        </tr>  
                    </table>  
                     <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
              
                    </asp:UpdateProgress>
                    
                    
                    <div>
                    
                        </div>   

                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label> &nbsp;&nbsp;
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
        
                    <br />
                    &nbsp;<asp:Panel ID="Panel2" runat="server">
                        <asp:GridView ID="GridView1" runat="server" Visible="False">
                        </asp:GridView>
                        <asp:GridView ID="GridView2" runat="server" Visible="False">
                        </asp:GridView>
                        <asp:GridView ID="GridView3" runat="server" Visible="False">
                        </asp:GridView>
                        <asp:GridView ID="GridView4" runat="server" Visible="False">
                        </asp:GridView>
                        <br />
                        <br />
                    </asp:Panel>
                    <br />
              </div>
                  <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
 

</body> 
 
</html>  

</asp:Content>
