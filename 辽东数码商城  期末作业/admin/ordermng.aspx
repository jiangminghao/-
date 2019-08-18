<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="ordermng.aspx.cs" Inherits="admin_ordermng" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ul id="myTab" class="nav nav-tabs">
   <li >
      <a href="#home" data-toggle="tab">
         交易完成订单
      </a>
   </li>
   <li><a href="#wait" data-toggle="tab">等待发货订单</a></li>
   <li><a href="#fh" data-toggle="tab">已发货订单</a></li>
    <li><a href="#qr" data-toggle="tab">已确认发货订单</a></li>
</ul>
<div id="myTabContent" class="tab-content">
   <div class="tab-pane fade in active" id="home">
      <h3>已完成交易订单</h3>
       <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1" OnItemDataBound="ListView1_ItemDataBound"  >
                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    <div style="">
                                  <asp:DataPager ID="DataPager1" runat="server" PageSize="1">
                             <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                           </Fields>
                    </asp:DataPager>
                            </div>
                </LayoutTemplate>
                <ItemTemplate>
                     <table class="table table-condensed">
                       <tr style="background-color:aliceblue">
                           <td><%#Eval("ordertime") %>  &nbsp;&nbsp;订单号：<asp:Label ID="Label1" runat="server" Text='<%#Eval("orderid") %>'></asp:Label></td>
                           <td>总价：<%#Eval("orderprice") %></td>
                       </tr>
                         <tr style="background-color:aliceblue">
                             <td>用户名：<%#Eval("username") %>;收货人姓名：<%#Eval("acceptname") %></td>
                             <td>地址：<%#Eval("address") %></td>
                         </tr>
                          <tr style="background-color:aliceblue">
                             <td>邮编：<%#Eval("postalcode") %>;电话：<%#Eval("phone") %></td>
                             <td>邮寄方式：<%#Eval("delivery")%>;支付方式：<%#Eval("payment") %></td>
                         </tr>
                        <tr>
                            <asp:ListView ID="ListView2" runat="server" ItemPlaceholderID="itemPlaceholder1">
                                <LayoutTemplate>
                                <asp:PlaceHolder ID="itemPlaceholder1" runat="server"></asp:PlaceHolder>
                                </LayoutTemplate> 
                                <ItemTemplate>
                                    <table  style="text-align:center;width:90%;border:0">
                                      <tr>
                                          <td style="width:120px"> <img src='../pic/<%#Eval("imagepath").ToString() %>' width="100" height="100" border="0"/> 
                                          </td> 
                                          <td style="vertical-align:middle;text-align:left">
                                            <%#Eval("pid") %>  <%#Eval("productname") %>
                                          </td>
                                           <td style="vertical-align:middle;text-align:left">
                                             数量：<%#Eval("cnt") %>价格：<%#Eval("userprice") %>元</td>
                                       </tr>
                                        </table>
                                </ItemTemplate>
                            </asp:ListView>
                        </tr>
                    </table>
                </ItemTemplate>
          
            </asp:ListView>
       <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="selectorderlist" TypeName="order">
           <SelectParameters>
               <asp:Parameter DefaultValue="4" Name="state" Type="Int32" />
           </SelectParameters>
       </asp:ObjectDataSource>
       <br />
       
   </div>
   <div class="tab-pane fade" id="wait">
     <h3>等待发货订单订单</h3>
       <asp:ListView ID="ListView3" runat="server" DataSourceID="ObjectDataSource2" OnItemCommand="ListView3_ItemCommand" OnItemDataBound="ListView3_ItemDataBound"  >
           <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    <div style="">
                                  <asp:DataPager ID="DataPager1" runat="server" PageSize="1">
                             <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                           </Fields>
                    </asp:DataPager>
                            </div>
                </LayoutTemplate>
                <ItemTemplate>
                     <table class="table table-condensed">
                       <tr style="background-color:aliceblue">
                           <td><%#Eval("ordertime") %>  &nbsp;&nbsp;订单号：<asp:Label ID="Label1" runat="server" Text='<%#Eval("orderid") %>'></asp:Label></td>
                           <td>总价：<%#Eval("orderprice") %><asp:Button ID="Button1" runat="server" Text="发货"  CommandName="fahuo" CommandArgument='<%#Eval("orderid") %>'/>
                           </td>
                       </tr>
                         <tr style="background-color:aliceblue">
                             <td>用户名：<%#Eval("username") %>;收货人姓名：<%#Eval("acceptname") %></td>
                             <td>地址：<%#Eval("address") %></td>
                         </tr>
                          <tr style="background-color:aliceblue">
                             <td>邮编：<%#Eval("postalcode") %>;电话：<%#Eval("phone") %></td>
                             <td>邮寄方式：<%#Eval("delivery")%>;支付方式：<%#Eval("payment") %></td>
                         </tr>
                        <tr>
                            <asp:ListView ID="ListView2" runat="server" ItemPlaceholderID="itemPlaceholder1">
                                <LayoutTemplate>
                                <asp:PlaceHolder ID="itemPlaceholder1" runat="server"></asp:PlaceHolder>
                                </LayoutTemplate> 
                                <ItemTemplate>
                                    <table  style="text-align:center;width:90%;border:0">
                                      <tr>
                                          <td style="width:120px"> <img src='../pic/<%#Eval("imagepath").ToString() %>' width="100" height="100" border="0"/> 
                                          </td> 
                                          <td style="vertical-align:middle;text-align:left">
                                            <%#Eval("pid") %>  <%#Eval("productname") %>
                                          </td>
                                           <td style="vertical-align:middle;text-align:left">
                                             数量：<%#Eval("cnt") %>价格：<%#Eval("userprice") %>元</td>
                                       </tr>
                                        </table>
                                </ItemTemplate>
                            </asp:ListView>
                        </tr>
                    </table>
                </ItemTemplate>
       </asp:ListView>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="selectorderlist" TypeName="order">
           <SelectParameters>
               <asp:Parameter DefaultValue="1" Name="state" Type="Int32" />
           </SelectParameters>
       </asp:ObjectDataSource>

   </div>
   <div class="tab-pane fade" id="fh">
     
     <h3>已发货订单</h3>
       <asp:ListView ID="ListView4" runat="server" DataSourceID="ObjectDataSource3"  OnItemDataBound="ListView3_ItemDataBound">
           <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    <div style="">
                                  <asp:DataPager ID="DataPager1" runat="server" PageSize="1">
                             <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                           </Fields>
                    </asp:DataPager>
                            </div>
                </LayoutTemplate>    
            <ItemTemplate>
                     <table class="table table-condensed">
                       <tr style="background-color:aliceblue">
                           <td><%#Eval("ordertime") %>  &nbsp;&nbsp;订单号：<asp:Label ID="Label1" runat="server" Text='<%#Eval("orderid") %>'></asp:Label></td>
                           <td>总价：<%#Eval("orderprice") %></td>
                       </tr>
                         <tr style="background-color:aliceblue">
                             <td>用户名：<%#Eval("username") %>;收货人姓名：<%#Eval("acceptname") %></td>
                             <td>地址：<%#Eval("address") %></td>
                         </tr>
                          <tr style="background-color:aliceblue">
                             <td>邮编：<%#Eval("postalcode") %>;电话：<%#Eval("phone") %></td>
                             <td>邮寄方式：<%#Eval("delivery")%>;支付方式：<%#Eval("payment") %></td>
                         </tr>
                        <tr>
                            <asp:ListView ID="ListView2" runat="server" ItemPlaceholderID="itemPlaceholder1">
                                <LayoutTemplate>
                                <asp:PlaceHolder ID="itemPlaceholder1" runat="server"></asp:PlaceHolder>
                                </LayoutTemplate> 
                                <ItemTemplate>
                                    <table  style="text-align:center;width:90%;border:0">
                                      <tr>
                                          <td style="width:120px"> <img src='../pic/<%#Eval("imagepath").ToString() %>' width="100" height="100" border="0"/> 
                                          </td> 
                                          <td style="vertical-align:middle;text-align:left">
                                            <%#Eval("pid") %>  <%#Eval("productname") %>
                                          </td>
                                           <td style="vertical-align:middle;text-align:left">
                                             数量：<%#Eval("cnt") %>价格：<%#Eval("userprice") %>元</td>
                                       </tr>
                                        </table>
                                </ItemTemplate>
                            </asp:ListView>
                        </tr>
                    </table>
                </ItemTemplate>

       </asp:ListView>
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="selectorderlist" TypeName="order">
           <SelectParameters>
               <asp:Parameter DefaultValue="2" Name="state" Type="Int32" />
           </SelectParameters>
       </asp:ObjectDataSource>

   </div>
     <div class="tab-pane fade" id="qr">
     <h3>已确认发货订单</h3>
          <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="selectorderlist" TypeName="order">
           <SelectParameters>
               <asp:Parameter DefaultValue="3" Name="state" Type="Int32" />
           </SelectParameters>
       </asp:ObjectDataSource>
         <asp:ListView ID="ListView5" runat="server" DataSourceID="ObjectDataSource4" OnItemCommand="ListView5_ItemCommand"  OnItemDataBound="ListView3_ItemDataBound">
             <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    <div style="">
                                  <asp:DataPager ID="DataPager1" runat="server" PageSize="1">
                             <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                           </Fields>
                    </asp:DataPager>
                            </div>
                </LayoutTemplate>  
              <ItemTemplate>
                     <table class="table table-condensed">
                       <tr style="background-color:aliceblue">
                           <td><%#Eval("ordertime") %>  &nbsp;&nbsp;订单号：<asp:Label ID="Label1" runat="server" Text='<%#Eval("orderid") %>'></asp:Label></td>
                           <td>总价：<%#Eval("orderprice") %><asp:Button ID="Button1" runat="server" Text="完成交易"  CommandName="ok" CommandArgument='<%#Eval("orderid") %>'/>
                           </td>
                       </tr>
                         <tr style="background-color:aliceblue">
                             <td>用户名：<%#Eval("username") %>;收货人姓名：<%#Eval("acceptname") %></td>
                             <td>地址：<%#Eval("address") %></td>
                         </tr>
                          <tr style="background-color:aliceblue">
                             <td>邮编：<%#Eval("postalcode") %>;电话：<%#Eval("phone") %></td>
                             <td>邮寄方式：<%#Eval("delivery")%>;支付方式：<%#Eval("payment") %></td>
                         </tr>
                        <tr>
                            <asp:ListView ID="ListView2" runat="server" ItemPlaceholderID="itemPlaceholder1">
                                <LayoutTemplate>
                                <asp:PlaceHolder ID="itemPlaceholder1" runat="server"></asp:PlaceHolder>
                            
                            </div>
                                </LayoutTemplate> 
                                <ItemTemplate>
                                    <table  style="text-align:center;width:90%;border:0">
                                      <tr>
                                          <td style="width:120px"> <img src='../pic/<%#Eval("imagepath").ToString() %>' width="100" height="100" border="0"/> 
                                          </td> 
                                          <td style="vertical-align:middle;text-align:left">
                                            <%#Eval("pid") %>  <%#Eval("productname") %>
                                          </td>
                                           <td style="vertical-align:middle;text-align:left">
                                             数量：<%#Eval("cnt") %>价格：<%#Eval("userprice") %>元</td>
                                       </tr>
                                        </table>
                                </ItemTemplate>
                            </asp:ListView>
                        </tr>
                    </table>
                </ItemTemplate>


         </asp:ListView>
   </div>
</div>
    <script src="../js/jquery-1.11.1.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script>
        $(function () {
            $('#myTab a:last').tab('show')
        })
</script>


</asp:Content>

