<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sort.ascx.cs" Inherits="usercontrol_sort" %>
<table style="border-right: #e5e5e5 1px solid; border-top: #e5e5e5 1px solid; border-left: #e5e5e5 1px solid; border-bottom: #e5e5e5 1px solid;width:100%;border:0">
  <tbody>
    <tr>
      <td style="height:28px"><div style="text-align:center">
         
          <img src="images/body/fenlei.jpg" width="183" height="43" /></div></td>
    </tr>
    <tr>
      <td style="vertical-align:top">  
          <asp:Repeater runat="server" ID="parent" OnItemDataBound="parent_ItemDataBound">
              <ItemTemplate>
                  <table style="border:0;width:100%">
                      <tr>
                         <td  style="vertical-align:middle;text-align:left">
                            <img src='images/body/orange-bullet.gif' height='7' />
                          <font color='#FF4800'><strong>  <%#Eval("typename")%> </strong></font>
                         </td>
                      </tr>
                      <tr>
                         <td style="text-align:center" >
                            <asp:DataList runat="server" ID="child" RepeatColumns="2">
                               <ItemTemplate>
                                  <table  border="0">
                                      <tr>
                                         <td>
                                          <a title='<%#Eval("type_2name")%>' href='classlist.aspx?tid=<%#DataBinder.Eval(Container.DataItem,"typeid_2") %>'>
                                             <%#Eval("type_2name")%> &nbsp; &nbsp; &nbsp;
                                          </a>  
                                         </td>
                                      </tr>
                                  </table>
                               </ItemTemplate>
                            </asp:DataList>
                         </td>
                      </tr>
                  </table>
              </ItemTemplate>
          </asp:Repeater>
      </td>
    </tr>
  </tbody>
</table>