<%@ Page Title="" Language="C#" MasterPageFile="~/web/webmaster.master" AutoEventWireup="true" CodeFile="classlist.aspx.cs" Inherits="classlist" %>
<%@ Register Src="~/usercontrol/sort.ascx" TagPrefix="uc1" TagName="sort" %>
<%@ Register Src="~/usercontrol/selltop.ascx" TagPrefix="uc1" TagName="selltop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="clearfix"></div>
    <div class="row">
        <div class="col-md-2" style=" border-color:#FF65A0">
        <table style="width:100%;" >
          <tr>
            <td >
                <uc1:sort runat="server" ID="sort" />
            </td>
          </tr>
          <tr>
            <td>
                <uc1:selltop runat="server" ID="selltop" />
            </td>
          </tr>
      <tr>
          <td>
              <img src="adpic/news1.jpg" />
          </td>
      </tr>
        
        
        
         </table>
        </div>
        <div class="col-md-10" >
            <div style="height:41px;background-image:url(images/body/xian.jpg);"><h4 style="color:white">当前分类：<asp:Literal ID="Literal1" runat="server"></asp:Literal></h4></div>

            <asp:ListView ID="ListView1" runat="server" ItemPlaceholderID="PlaceHolder1"   
           EnableTheming="True" OnItemCommand="ListView1_ItemCommand">
        <LayoutTemplate>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder> </LayoutTemplate>
        <ItemTemplate>
       
            <table style="width:95%;border:0"  >
              <tr>
                <td style="width:22%">
                   <table  style="text-align:center;width:100px;height:100px;border:0">
                  <tbody>
                    <tr>
                      <td  style="text-align:center;background-image:url(images/136.jpg);height:140px"> 
                                 <a  title='<%#Eval("productname") %>' href='productinfo.aspx?pid=<%#Eval("productid") %>'><img src='pic/<%#Eval("imagepath").ToString() %>' width="100" height="100" border="0"/></a> 
                              </td>
                     
                    </tr>
                  </tbody>
                </table></td>
                <td style="width:35%;vertical-align:middle">
                    <table style="width:100%;border:0" >
                    <tr>
                      <td>
                        <asp:Label runat="server" ID="productid" Text='<%#Eval("productid") %>' Visible="False"></asp:Label>
                        商品名称：<a title='<%#Eval("productname") %>' href='productinfo.aspx?pid=<%#Eval("productid") %>'><%#Eval("productname") %></a></td>
                    </tr>
                    
                  </table></td>
                <td style="width:22%">
                    <table style="width:100%;border:0" >
                    <tr>
                      <td style="height:25px">市场价：<s><%#Eval("price") %></s>元 </td>
                    </tr>
                    <tr>
                      <td style="height:25px">会员价：<%#Eval("userprice") %>元 </td>
                    </tr>
                       
                  </table></td>
                <td style="width:21%; text-align:center">
                   <asp:ImageButton runat="server" ID="buyimagebutton" ImageUrl="images/buy.gif" CausesValidation="false" CommandName="buy" />
                   <br>
               </td>
              </tr>
              <tr>
                <td  style="height:1px;background-image:url(images/mingle/inbg.gif)" colspan="4" ></td>
              </tr>
            </table>
          </ItemTemplate>
    
                <EmptyDataTemplate>
                   <h4> 此分类下还没有商品</h4>
                </EmptyDataTemplate>
        </asp:ListView>
 <div style=" width:100%; margin:0 auto; text-align:center">
    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" 
        PageSize="5">
        <Fields>
            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                ShowNextPageButton="False" ShowPreviousPageButton="False" />
            <asp:NumericPagerField />
            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                ShowNextPageButton="False" ShowPreviousPageButton="False" />
        </Fields>
    </asp:DataPager>
    </div>

          </div>  
    </div>


</asp:Content>

