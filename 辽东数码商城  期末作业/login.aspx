<%@ Page Title="" Language="C#" MasterPageFile="~/web/webmaster.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

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
        .auto-style5 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 41.66666667%;
            left: 3px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="clearfix"></div>
    <div class="row">
        <div class="auto-style5">
            <table style="width:100%;border:0; padding:3px; class="table table-bordered">
        <tr> 
          <td ><h3>如果您
            未注册</h3></td>
        </tr>
        <tr> 
          <td  class="text-center" >&nbsp;</td>
        </tr>
        <tr> 
          <td class="text-center">请点击下面的按钮进行免费注册：</td>
        </tr>
        <tr> 
          <td class="text-center"><a href="regist.aspx"><img src="images/register_b.gif" width="127" height="28" /></a></td>
        </tr>
        <tr> 
          <td class="text-center" style="height:160px"><h2>数码专卖，给你好看！</h2>
              <p><img src="images/shuma.png" /></p>
            </td>
        </tr>
        </table>
        </div>
        <div class="col-md-5">
            <table  style="width:100%;border:0; padding:3px" class="table table-bordered">
        <tr> 
          <td ><h3>如果您已注册</h3></td>
        </tr>
        <tr> 
          <td>请在下面空格中分别输入您的用户名和密码，然后按&quot;<span class="auto-style1">登录</span>&quot;</td>
        </tr>
        <tr> 
          <td style="text-align:center;vertical-align:top"> 
            <table style="width:90%;border:0;padding:2px"class="table table-bordered">
                <tr> 
                  <td   class="auto-style2" > 
                    用户名：</td>
                  <td style="vertical-align:top; text-align:left"> 
                    <input name="username" id="username" runat="server" style="width: 138px" />
                      <asp:RequiredFieldValidator ID="usernamerfv" runat="server" ErrorMessage="*" ControlToValidate="username"></asp:RequiredFieldValidator>
                  </td>
                </tr>
                <tr> 
                  <td class="auto-style3">密　码：</td>
                  <td class="text-left"> 
                    <input runat="server" name="password" type="password" id="password" size="20"  style="width: 138px"/>
                    <asp:RequiredFieldValidator ID="passwordrfv" runat="server" ErrorMessage="*" ControlToValidate="password"></asp:RequiredFieldValidator>
                  </td>
                </tr>
                <tr>
                  <td class="auto-style3">验证码：</td>
                  <td class="text-left">
                      <asp:TextBox runat="server" ID="checkCokdeTb" Width="80px"></asp:TextBox>
                      <img src="validimage.aspx"    style="vertical-align: middle"/>
                      <asp:RequiredFieldValidator ID="checkCokdeTbrfv" runat="server" ErrorMessage="*" ControlToValidate="checkCokdeTb"></asp:RequiredFieldValidator>
                  </td>
                </tr>
                <tr> 
                  <td class="auto-style4"></td>
                  <td> 
                    <table style="width:100%;border:0">
                      <tr> 
                        <td> 
                          <input name="loginsubmit" type="image" class="btn btn-default" src="images/login11.gif" align="middle" width="110" height="30" id="loginsubmit" runat="server" onserverclick="loginsubmit_ServerClick" />
                        </td>
                        <td>&nbsp;</td>
                      </tr>
                    </table>
                  </td>
                </tr>
                <tr> 
                  <td class="auto-style4">&nbsp;</td>
                  <td><a href="researchpassword.aspx">忘记密码</a></td>
                </tr>
            </table>
          </td>
        </tr>
       
      </table>


        </div>
    </div>
</asp:Content>

