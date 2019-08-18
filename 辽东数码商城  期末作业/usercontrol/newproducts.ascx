<%@ Control Language="C#" AutoEventWireup="true" CodeFile="newproducts.ascx.cs" Inherits="usercontrol_newproducts" %>
<table style="width:100%;border:0;text-align:center">
  <tr>
    <td><img src="images/zuixin.jpg"  style="width:100%;height:30px;border:0" ></td>
  </tr>
  <tr>
    <td>
        <asp:DataList runat="server" ID="newproductlist" RepeatColumns="6" RepeatDirection="Horizontal" CellSpacing="5" DataSourceID="ObjectDataSource1">
            <ItemTemplate>
               <div style="text-align:left">
                        <table  style="width:142px;height:142px;padding:2px;border:0">
                          <tbody>
                            <tr> 
                              <td style="text-align:center; background-image:url(images/136.jpg);height:140px"> 
                                 <a  title='<%#Eval("productname") %>' href='productinfo.aspx?pid=<%#Eval("productid") %>'><img src='pic/<%#Eval("imagepath").ToString().Trim() %>' width="100" height="100" border="0" align="absmiddle" /></a> 
                              </td>
                            </tr>
                            <tr>
                               <td style="vertical-align:top;text-align:center">
                                  <a title='<%#Eval("productname") %>' href='productinfo.aspx?pid=<%#Eval("productid") %>'>
                                 <b>
                                    <%#strtool.LeftTitle(Eval("productname").ToString(),18) %> 
                                 </b>
                                 </a>
                                 <br />
                                 市场价：<s><%#Eval("price") %></s>元 <br />
                                 会员价：<%#Eval("userprice") %>元 <br />
                               </td>
                            </tr>
                          </tbody>
                    </table>
              </div>
            </ItemTemplate>
        </asp:DataList>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getnewproductlist"
            TypeName="product">
            <SelectParameters>
                <asp:Parameter DefaultValue="12" Name="num" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </td>
  </tr>
</table>