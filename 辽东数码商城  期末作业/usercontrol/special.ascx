<%@ Control Language="C#" AutoEventWireup="true" CodeFile="special.ascx.cs" Inherits="usercontrol_special" %>
<table style="width:518px;border:0;text-align:center" >
  <tr>
    <td style="text-align:left"><img src="images/tejia.jpg" width="700" height="30" border="0"  /></td>
  </tr>
  <tr>
    <td>
        <asp:DataList runat="server" ID="specialproductlist" RepeatColumns="6" RepeatDirection="Horizontal">
            <ItemTemplate>
              <div  style="text-align:left">
                        <table  style="width:140px;height:142px;padding:2px;border="0">
                          <tbody>
                            <tr> 
                              <td style="text-align:center;height:140px;background-image:url(images/136.jpg)"> 
                                 <a  title='<%#Eval("productname") %>' href='productinfo.aspx?pid=<%#Eval("productid") %>'><img src='pic/<%#Eval("imagepath").ToString() %>' width="100" height="100" border="0"/></a> 
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
                                 市场价：<s><%#Eval("price") %></s> 元 <br />
                                 特  价：<%#Eval("specialsprice") %> 元 <br />
                               </td>
                            </tr>
                          </tbody>
                    </table>
              </div>
            </ItemTemplate>
        </asp:DataList>
    </td>
  </tr>
  
</table>