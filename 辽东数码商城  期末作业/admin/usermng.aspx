<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="usermng.aspx.cs" Inherits="admin_usermng" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div style=" width:100%;height:auto;text-align:center">
<h1>用户列表</h1>

<hr />
         <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="delelteUser" SelectMethod="getUser" TypeName="Userinfo">
             <DeleteParameters>
                 <asp:Parameter Name="userid" Type="Int32" />
             </DeleteParameters>
         </asp:ObjectDataSource>
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Width="620px" DataKeyNames="userid" CssClass=" table table-hover text-center" AllowPaging="True" PageSize="3">
             <Columns>
                 <asp:BoundField DataField="userid" HeaderText="用户编号"  HeaderStyle-CssClass="text-center">
               
<HeaderStyle CssClass="text-center"></HeaderStyle>
               
                 </asp:BoundField>
                 <asp:BoundField DataField="username" HeaderText="用户名" HeaderStyle-CssClass="text-center" >
                
<HeaderStyle CssClass="text-center"></HeaderStyle>
                
                 </asp:BoundField>
                 <asp:BoundField DataField="email" HeaderText="邮箱" HeaderStyle-CssClass="text-center" >
                
<HeaderStyle CssClass="text-center"></HeaderStyle>
                
                 </asp:BoundField>
                 <asp:TemplateField HeaderText="用户身份">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# setpower(Eval("power").ToString()) %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:CommandField ShowDeleteButton="True" />
             </Columns>
         </asp:GridView>
         <br />
         <hr />
         <h1>管理员信息</h1>
         <hr />
        <table class="table table-bordered" style="width:600px">
            <tr>
                <td style="width:100px; background-color:aliceblue; text-align:right">用户名：</td>
                <td style="text-align:left">
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
            </tr>
             <tr>
                <td style="width:100px; background-color:aliceblue; text-align:right">密码：</td>
                <td style="text-align:left">
                    <asp:TextBox ID="TextBox1" runat="server" Width="212px"></asp:TextBox>    
                </td>
            </tr>
             <tr>
                <td style="width:100px; background-color:aliceblue; text-align:right">密码问题：</td>
                <td style="text-align:left">
                    <asp:TextBox ID="TextBox2" runat="server" Width="438px"></asp:TextBox>    
                </td>
            </tr>
             <tr>
                <td style="width:100px; background-color:aliceblue; text-align:right">问题答案：</td>
                <td style="text-align:left">
                    <asp:TextBox ID="TextBox3" runat="server" Width="438px"></asp:TextBox>    
                </td>
            </tr>
            <tr>
                <td style="width:100px; background-color:aliceblue; text-align:right">邮箱：</td>
                <td style="text-align:left">
                    <asp:TextBox ID="TextBox4" runat="server" Width="438px"></asp:TextBox>    
                </td>
            </tr>
             <tr>
                <td style="width:100px; background-color:aliceblue; text-align:right"></td>
                <td style="text-align:left">
                    <asp:Button ID="Button1" runat="server" Text="确定修改" OnClick="Button1_Click" />  
                </td>
            </tr>
        </table>
         <br />
         </div>
</asp:Content>

