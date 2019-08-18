<%@ Page Title="" Language="C#" MasterPageFile="~/web/webmaster.master" AutoEventWireup="true" CodeFile="productinfo.aspx.cs" Inherits="productinfo" %>

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
      
        
        
        
         </table>
        </div>
        <div class="col-md-10">
           <div style="height:41px;background-image:url(images/body/xian.jpg)"></div>
            <div class="container">
                <div class="row">
                    <div class="col-md-3">
                        <img  width="300" border="0" alt="商品名称：" height="300" id="IMG1" runat="server" />
                    </div>
         <div class="col-md-7" style="padding-left:40px">
                  <table style="width:100%;border:0" >
                    <tr> 
                      <td style="height:25px;text-align:center" colspan="2" >
                          <b style="color:#ff65a0">
                              <asp:Literal runat="server" ID="productnameliteral"></asp:Literal>
                          </b>
                      </td>
                    </tr>
                    <tr> 
                      <td style="width:28%">&nbsp;<img src="images/body/orange-bullet.gif" height="7" width="9"/> 商品一级分类：</td>
                      <td style="width:72%;height:22px">
                          <asp:Literal runat="server" ID="type_1nameliteral"></asp:Literal>
                      </td>
                    </tr>
                    <tr> 
                      <td>&nbsp;<img src="images/body/orange-bullet.gif" height="7" width="9"/ > 商品二级分类：</td>
                      <td style="height:22px">
                          <asp:Literal runat="server" ID="type_2nameliteral"></asp:Literal>
                      </td>
                    </tr>
                    <tr>
                      <td>&nbsp;<img src="images/body/orange-bullet.gif"height="7" width="9"/ > 商品点击数：</td>
                      <td style="height:22px">
                          <asp:Literal runat="server" ID="pointcountliteral"></asp:Literal> 次
                      </td>
                    </tr>
                    <tr> 
                      <td>&nbsp;<img src="images/body/orange-bullet.gif" height="7" width="9"/> 
                        商品数量：</td>
                      <td style="height:22px">
                         <asp:Literal runat="server" ID="countliteral"></asp:Literal> 件
                      </td>
                    　 </tr>
                    <tr> 
                      <td>&nbsp;<img src="images/body/orange-bullet.gif" height="7" width="9"/> 销售数量：</td>
                      <td style="height:22px">
                      <asp:Literal runat="server" ID="sellcountliteral"></asp:Literal> 
                         件 </td>
                    </tr>
                    <tr> 
                        <td>&nbsp;<img src="images/body/orange-bullet.gif"height="7" width="9" />市场价</td>
                        <td style="width:76%"><s> ￥<asp:Literal runat="server" ID="priceliteral"></asp:Literal> 元</s></td>
                      </tr>
                      
                      <tr> 
                        <td >&nbsp;<img src="images/body/orange-bullet.gif"height="7" width="9" />会员价：</td>
                        <td  style="color:red">
                          ￥<asp:Literal runat="server"   ID="userpriceliteral"></asp:Literal> 
                           
                          元</td>
                      </tr>
                      <tr> 
                        <td style="height: 19px" >&nbsp;<img src="images/body/orange-bullet.gif"height="7" width="9" />特价：</td>
                        <td style="height: 19px;color:red" > 
                          ￥<asp:Literal runat="server" ID="specialsliteral"></asp:Literal> 
                          元 
                         
                        </td>
                      </tr>
                  </table>
              <br />
                     <asp:ImageButton runat="server" ID="addcart" ImageUrl="images/buy1.gif" OnClick="addcart_Click"  />

         </div>

            <table  style=" BORDER-bottom:#FF67A0 1px solid; BORDER-top:#FF67A0 1px solid;BORDER-left:#FF67A0 1px solid; BORDER-right:#FF67A0 1px solid;width:100%;border:0;text-align:center">
              <tr>
              <td style="height:17px">
                 <img src="images/body/p_dtitle01.gif" width="698" height="30"/ > 
             </td>
              </tr>
            
            <tr>
              <td  style="padding-left:10px; padding-right:10px">
                <asp:Literal runat="server" ID="descriptionliteral"></asp:Literal>
              </td>
            </tr>
           
            
        </table>

                   
                </div>
            </div>
          </div>  
    </div>
</asp:Content>

