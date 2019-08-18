<%@ Page Title="" Language="C#" MasterPageFile="~/web/webmaster.master" AutoEventWireup="true" CodeFile="regist.aspx.cs" Inherits="regist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width:95%;text-align:center;border:1px; border-bottom-color:#CCCCCC;font-size:12px">
        <tr>
          <td style="background-color:#FFFFFF;border-bottom-color:#FFFFFF">
             <table style="width:100%;border:0" >
              <tr>
                <td  class="text-center"><p style="color:#FF3300"><b>请您详细填写您的信息<br/>
                  您的个人信息对外保密。(带<span class=" text-danger"> *</span>  号为必填项) </b></p>
                    
                      <table style="width:85%;border:0;padding:2px; background-color:#e1e1e1;text-align:center">
                        <tr>
                          <td style="height:15px;background-color:#f1f1f1;font-weight:bold;color:#FF3300" colspan="3" >用户注册 </td>
                        </tr>
                        <tr style="background-color:#FFFFFF" >
                          <td style="width:35%; text-align:center">用 户 名：</td>
                          <td  style="text-align:left">
                               <span style="font-weight:bold;color:#FF3300">*</span>
                              <asp:TextBox ID="usrernameTb" runat="server"></asp:TextBox>
                              
                              <asp:RequiredFieldValidator ID="usernameRFV" runat="server" ControlToValidate="usrernameTb" Display="Dynamic" ErrorMessage="请输入用户名"></asp:RequiredFieldValidator>
                              <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                              
                               <asp:Button ID="Button1" runat="server" Text="检查用户名" OnClick="Button1_Click"  ValidationGroup="tt"/>
                              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                 <ContentTemplate>
                                     <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                   </ContentTemplate>
                    
                                <Triggers>
                                      <asp:AsyncPostBackTrigger ControlID="Button1" />
                               </Triggers>
                            </asp:UpdatePanel>
                             
                         </td>

                        </tr>
                          <tr style="background-color:#FFFFFF" >
                          <td style="width:35%; text-align:center">密　　码：</td>
                          <td  style="text-align:left">
                               <span style="font-weight:bold;color:#FF3300">*</span>
                              <asp:TextBox ID="passwordTb" runat="server" TextMode="Password"></asp:TextBox>
                              <asp:RequiredFieldValidator ControlToValidate="passwordTb" ID="passwordRFV" Display="dynamic" runat="server" ErrorMessage="请输入密码"></asp:RequiredFieldValidator></td>

                        </tr>
                         <tr style="background-color:#FFFFFF" >
                          <td style="width:35%; text-align:center">确认密码：</td>
                          <td  style="text-align:left">
                               <span style="font-weight:bold;color:#FF3300">*</span>
                              <asp:TextBox ID="repasswordTb" runat="server" TextMode="Password"></asp:TextBox>
                              <asp:CompareValidator ID="comparepassword" Display="Dynamic" ControlToCompare="passwordTb" ControlToValidate="repasswordTb" runat="server" ErrorMessage="两次输入密码不一致"></asp:CompareValidator></td>
                        </tr>
                         <tr style="background-color:#FFFFFF" >
                          <td style="width:35%; text-align:center">电子邮箱：</td>
                          <td  style="text-align:left">
                               <span style="font-weight:bold;color:#FF3300">*</span>
                              <asp:TextBox ID="emailTb" runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="emailRFV" Display="dynamic" ControlToValidate="emailTb" runat="server" ErrorMessage="请输入电子邮箱"></asp:RequiredFieldValidator>
                              <asp:RegularExpressionValidator ID="emailREV" Display="dynamic" ControlToValidate="emailTb" runat="server" ErrorMessage="电子邮箱格式错误" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>

                        </tr>
                          <tr style="background-color:#FFFFFF" >
                          <td style="width:35%; text-align:center">密码问题：</td>
                          <td  style="text-align:left">
                               <span style="font-weight:bold;color:#FF3300">*</span>
                             <asp:TextBox ID="questionTb" runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="questionRFV" Display="dynamic" ControlToValidate="questionTb" runat="server" ErrorMessage="请输入密码问题"></asp:RequiredFieldValidator></td>

                        </tr>
                          <tr style="background-color:#FFFFFF" >
                          <td style="width:35%; text-align:center">问题答案：</td>
                          <td  style="text-align:left">
                               <span style="font-weight:bold;color:#FF3300">*</span>
                             <asp:TextBox ID="answerTb" runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="answerRFV" Display="dynamic" ControlToValidate="answerTb" runat="server" ErrorMessage="请输入问题答案"></asp:RequiredFieldValidator></td>

                        </tr>             
              </table>
                 
              </td>
              </tr>
              </table>
              </td>
              </tr>
              <tr>
                 <td class="text-center">
                 <br />
                     <asp:Button ID="registBt" runat="server" Text="注册新用户" OnClick="registBt_Click" />
                    <input type="button" value="返回首页" onclick="window.location.href = 'default.aspx'" />
                 </td>
              </tr>
              </table>


</asp:Content>

