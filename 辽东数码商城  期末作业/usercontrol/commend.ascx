<%@ Control Language="C#" AutoEventWireup="true" CodeFile="commend.ascx.cs" Inherits="usercontrol_commend" %>
<div style="text-align: center">
    <table style="width: 560px">
        <tr>
            <td style="width: 100px">
                <img height="30" src="images/tuijian.jpg" width="560" /></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:DataList ID="DataList1" runat="server" DataKeyField="productid" DataSourceID="ObjectDataSource1" RepeatColumns="4" RepeatDirection="Horizontal" Width="100%">
                    <ItemTemplate>
                        <div style="text-align: left;">
                        <table  style="width: 140px; height: 142px;padding:2px;">
                            <tr>
                                <td  style="height:140px">
                                    <a title='<%#Eval("productname") %>' href='productinfo.aspx?pid=<%#Eval("productid") %>'><asp:Image ID="Image1" runat="server" Height="100" ImageUrl='<%# Eval("imagepath", "~\\pic\\{0}") %>'
                                        Width="100" /></a></td>
                            </tr>
                            <tr>
                                <td style="text-align:center;vertical-align:top">
                                <a title='<%#Eval("productname") %>' href='productinfo.aspx?pid=<%#Eval("productid") %>'>
                                 <b>
                                    <%#strtool.LeftTitle(Eval("productname").ToString(),18) %> 
                                 </b>
                                 </a>
                                 <br />
                                 市场价：<s><%#Eval("price") %></s> 元 <br />
                                 会员价：<%#Eval("userprice") %> 元 <br />
                                </td>
                            </tr>
                        </table>
                        </div>
                        
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getrecommendedproductlist"
                    TypeName="product">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="8" Name="num" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</div>
