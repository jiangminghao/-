<%@ Page Title="" Language="C#" MasterPageFile="~/web/webmaster.master" AutoEventWireup="true" CodeFile="userinfo.aspx.cs" Inherits="userinfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="clearfix"></div>
    <div class="row">
        <div class="col-md-3" style=" border-color:#FF65A0;>
<div style=" width:100%; height:auto; margin:0 auto;  float:right; text-align:center">
    <span style="font-size: large">修改个人资料</span><br />
    <table style="width: 100%;text-align:center">
        <tr>
            <td style="text-align: right; width: 50px">
                用户名</td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 50px">
                邮箱</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 50px">
                密码问题</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 50px">
                问题答案</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 50px">
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="确定" />
            &nbsp;
                <asp:Button ID="Button2" runat="server" Text="修改密码" OnClick="Button2_Click" />
            </td>
        </tr>
    </table>
    <br />
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <span style="font-size: large">修改密码</span><br />
        <table style="width: 100%;text-align:center">
        <tr>
            <td style="text-align: right; width: 50px">
                旧密码</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 50px">
                新密码</td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 50px; height: 23px;">
                确认密码</td>
            <td style="height: 23px">
                <asp:TextBox ID="TextBox6" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 50px">
                &nbsp;</td>
            <td>
                <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="确定" />
                
            </td>
        </tr>
    </table>
    </asp:Panel>
</div>
            
      
        </div>
        <div class="col-md-7">
        <div style="height:41px;background-image:url(images/body/xian.jpg)"><h3 style="color:white">已购买到的商品</h3></div>
            <asp:ListView ID="ListView1" runat="server" OnItemDataBound="ListView1_ItemDataBound" OnItemCommand="ListView1_ItemCommand"  DataSourceID="ObjectDataSource1">
                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                   
                </LayoutTemplate>
                <ItemTemplate>
                    <table class="table table-condensed">
                       <tr style="background-color:aliceblue">
                           <td><%#Eval("ordertime") %>  &nbsp;&nbsp;订单号：<%#Eval("orderid") %></td>
                           <td>总价：<%#Eval("orderprice") %></td>
                           <td>
                               <asp:Label ID="Label3" runat="server" Text='<%#Eval("state") %>' Visible="false"></asp:Label>
                               <asp:Button ID="qrsh" runat="server" Text="确认收货" CommandArgument='<%#Eval("orderid") %>' CommandName="qrsh" />
                               <asp:Button ID="ddfh" runat="server" Text="等待发货"  CommandName="ddfh" Enabled="false"/>
                                <asp:Button ID="qxdd" runat="server" Text="取消订单" CommandArgument='<%#Eval("orderid") %>' CommandName="qxdd"/>
                                <asp:Button ID="hfdd" runat="server" Text="恢复订单" CommandArgument='<%#Eval("orderid") %>' CommandName="hfdd"/>
                                <asp:Button ID="wcjy" runat="server" Text="完成交易"  Enabled="false"/>
                               <asp:Label ID="Label2" runat="server" Text='<%#Eval("orderid") %>' Visible="false"></asp:Label>
                           </td>
                       </tr>
                        <tr>
                            <asp:ListView ID="ListView2" runat="server" ItemPlaceholderID="itemPlaceholder1">
                                <LayoutTemplate>
                                <asp:PlaceHolder ID="itemPlaceholder1" runat="server"></asp:PlaceHolder>
                                </LayoutTemplate> 
                                <ItemTemplate>
                                    <table  style="text-align:center;width:90%;border:0">
                                      <tr>
                                          <td style="width:120px">  <a  title='<%#Eval("productname") %>' href='productinfo.aspx?pid=<%#Eval("pid") %>'>
                                              <img src='pic/<%#Eval("imagepath").ToString() %>' width="100" height="100" border="0"/></a> 
                                          </td> 
                                          <td style="vertical-align:middle;text-align:left">
                                              <a title='<%#Eval("productname") %>' href='productinfo.aspx?pid=<%#Eval("pid") %>'><%#Eval("productname") %></a>
                                          </td>
                                           <td style="vertical-align:middle;text-align:left">
                                             数量：<%#Eval("cnt") %></td>
                                       </tr>
                                        </table>
                                </ItemTemplate>
                            </asp:ListView>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:ListView>
            <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="1">
                <Fields>
                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                </Fields>
            </asp:DataPager>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getordersbyuserid" TypeName="order">
                <SelectParameters>
                    <asp:Parameter Name="userid" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div> 
        </div>
     
    

</asp:Content>

