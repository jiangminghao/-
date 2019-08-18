<%@ Page Title="" Language="C#" MasterPageFile="~/web/webmaster.master" AutoEventWireup="true" CodeFile="question.aspx.cs" Inherits="question" %>
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
            <div style="height:41px;background-image:url(images/body/xian.jpg);"><h3 style="color:white">常见问题</h3></div>
            <h3>如何提现支付宝的钱？</h3>
            <p>亲，在电脑端登录支付宝，点击【我的支付宝】—【账户余额】—【转出（提现）】，输入提现金额，点击【下一步】即可完成提现</p>
            <img src="images/cjwt.jpg" />
            <p>*温馨提醒：
提现的金额不可大于支付宝账户余额的金额哦。
如果以上内容未解决您的问题，请点此联系在线客服为您解答。</p>
            </div>
        </div>
</asp:Content>

