<%@ Page Title="" Language="C#" MasterPageFile="~/web/webmaster.master" AutoEventWireup="true" CodeFile="researchpassword.aspx.cs" Inherits="researchpassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">
        .auto-style1 {
            color: #CC9900;
        }
        .auto-style2 {
            width: 113px;
        }
        .auto-style3 {
            text-align: center;
            width: 113px;
        }
        .auto-style4 {
            text-align: right;
            width: 113px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="clearfix"></div>
    <div class="row">
        <div class="col-md-4">
           
        </div>
        <div class="col-md-4">
            <table  style="width:100%;border:0; padding:3px" class="table table-bordered">
        <tr> 
          <td ><h3>用户中心</h3></td>
        </tr>
        <tr> 
          <td>请在下面空格中分别输入您的用户名和密码提示问题答案，然后按&quot;确定&quot;。<b><font class="fontshadow" color="#ff0099"> </font><font color="#FFFFFF"><font class="fontshadow" color="#ff0099"></font></font></b></td>
        </tr>
        <tr> 
          <td style="text-align:center;vertical-align:top"> 
            <table style="width:90%;border:0;padding:2px"class="table table-bordered">
                <tr> 
                  <td   class="auto-style2" > 
                    用户名：</td>
                  <td style="vertical-align:top; text-align:left"> 
                    <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                      <asp:RequiredFieldValidator ID="usernamerfv" runat="server" ErrorMessage="*" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                      <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="检测" />
                  </td>
                </tr>
               <tr> 
                  <td  class="text-left" style="height: 25px">回答问题：</td>
                  <td class="text-left" style="height: 25px"> 
                    &nbsp;<asp:Label ID="Label1" runat="server" Text="密码提示问题"></asp:Label>
                  </td>
                </tr>
                <tr> 
                  <td  class="text-left">答&nbsp; 案：</td>
                  <td  class="text-left"> 
                      <asp:TextBox ID="TextBox2" runat="server" ValidationGroup="v2"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="passwordrfv" runat="server" ErrorMessage="*" 
                          ControlToValidate="TextBox2" ValidationGroup="v2"></asp:RequiredFieldValidator>
                  </td>
                </tr>
                <tr> 
                  <td class="auto-style4"></td>
                  <td> 
                    <table style="width:100%;border:0">
                      <tr> 
                        <td> 
                          <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="确定" 
                                ValidationGroup="v2" />
                        </td>
                        <td>&nbsp;</td>
                      </tr>
                    </table>
                  </td>
                </tr>
              
            </table>
          </td>
        </tr>
       
      </table>


        </div>
         <div class="col-md-4">
           
        </div>

    </div>

</asp:Content>

