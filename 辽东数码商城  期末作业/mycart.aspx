<%@ Page Title="" Language="C#" MasterPageFile="~/web/webmaster.master" AutoEventWireup="true" CodeFile="mycart.aspx.cs" Inherits="mycart" %>
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
        <div class="col-md-10">
            <div style="height:41px;background-image:url(images/body/xian.jpg)"><h4 style="color:white">购物车</h4></div>


<table style="width:90%;border:0;text-align:center;padding:2px;background-color:#f1f1f1" >
  <tr style="background-color:#f1f1f1; text-align:center">
    <td style="width:25%"  >商品名称</td>
    <td style="width:15%" >单价</td>
    <td style="width:15%" >数量</td>
    <td style="width:15%" >总价</td>
    <td style="width:10%" >删除</td>
  </tr>
  </table>
   <asp:Repeater runat="server" ID="cartrepeater" OnItemDataBound="cartrepeater_ItemDataBound" OnItemCommand="cartrepeater_ItemCommand">
       <ItemTemplate>
          <table style="width:90%;border:0;text-align:center;padding:2px; background-color:#f1f1f1">
          <tr style="background-color:white; text-align:center">
            <td style="width:25%" >
                <asp:Label runat="server" ID="productidlabel" Text='<%#Eval("productid") %>'></asp:Label>
               <%#Eval("productname") %>
            </td>
            <td style="width:15%" >
               <asp:Label runat="server" ID="pricelabel"></asp:Label>   
            </td>
            <td style="width:15%" >
               <asp:TextBox runat="server" ID="counttb" Width="30px"></asp:TextBox>
            </td>
            <td style="width:15%" >
                <asp:Label runat="server" ID="countpricelabel"></asp:Label>  
            </td>
            <td style="width:10%" >
               <asp:ImageButton runat="server" ID="deletebt" ImageUrl="images/trash.gif" CausesValidation="false" CommandName="deletecart" />
            </td>
          </tr>
          </table>
       </ItemTemplate>
   </asp:Repeater>
   <table style="width:90%;border:0;text-align:center;padding:2px; background-color:#f1f1f1">
      <tr style="background-color:#ffffff">
        <td  style="height:30px;text-align:center" colspan=5  > 购物车里有商品：<span style="color:red" ><asp:Literal runat="server" ID="counttypelieteral" ></asp:Literal> </span> 种　总数：<font color=red> <asp:Literal runat="server" ID="countnumlieteral" ></asp:Literal> </font> 件　共计：<font color=red> <asp:Literal runat="server" ID="countpricelieral"></asp:Literal> </font> 元　</td>
      </tr>
      <tr style="background-color:#ffffff">
                    <td  style="text-align:center;height:50px" colspan="5">
                    <input class="go-wenbenkuang" type="button" name="imageField12" value="继续购物" onclick="window.location.href = 'default.aspx'" id="Button1"/>
					<asp:Button runat="server" CssClass="go-wenbenkuang" ID="updatecount" Text="修改数量" OnClick="updatecount_Click" />
                    <asp:Button runat="server" CssClass="go-wenbenkuang" ID="clearcount" Text="清空购物车" OnClick="clearcount_Click" />
                    <asp:Button runat="server" ID="orderbt" CssClass="go-wenbenkuang" Text="去收银台" OnClick="orderbt_Click" />
                    </td>
                  </tr>
                  <tr style="background-color:#ffffff">
                    <td  colspan="5" style="padding-left: 20px;text-align:left;height:60px"> · 如果您想继续购物，请点选继续购物<br>
                      · 如果您想更新已在购物车内的产品，请先修改，然后点选修改数量<br>
                      · 如果您想全部取消已订购在购物车中的产品，请点选清空购物车<br>
                      · 如果您满意您所购买的产品，请点选去收银台(会员须先登陆，非会员须先免费注册成为会员)<br/>                    </td>
                  </tr>
  </table>
   
             </div>

          </div>  
   
</asp:Content>

