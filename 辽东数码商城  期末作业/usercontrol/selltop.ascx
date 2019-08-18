<%@ Control Language="C#" AutoEventWireup="true" CodeFile="selltop.ascx.cs" Inherits="usercontrol_selltop" %>
<table style="width:180px;border:0">
  <tr>
    <td><div style="text-align:center"><img src="images/body/xiaoshou.jpg" width="183" height="43" /></div></td>
  </tr>
  <tr>
    <td style="vertical-align:top" >
      <asp:Repeater runat="server" ID="selltoprepeater">
          <ItemTemplate>
              <table style="width:100%">
                  <tr>
                     <td style="height:20px;text-align:left">
                       
                       <img src="images/body/dian2.gif" />
                       <a title='<%#Eval("productname") %>' href='productinfo.aspx?pid=<%#Eval("productid") %>'> 
                       <%#strtool.LeftTitle(Eval("productname").ToString(), 18)%>  
                        <font color="red">
                           ￥<%#Eval("price") %>
                        </font>
                        </a>
                     </td>
                  </tr>
              </table>
          </ItemTemplate>
      </asp:Repeater>
   </td>
  </tr>
</table>