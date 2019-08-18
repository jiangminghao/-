<%@ Page Title="" Language="C#" MasterPageFile="~/web/webmaster.master" AutoEventWireup="true" CodeFile="checkout.aspx.cs" Inherits="checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
      <style>
        .leftcol {
            width: 20%;
            text-align: center;
            vertical-align: middle;
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <br />
     <br />
         结算步骤 ：1 <span style="font-weight:bold">订单填写</span>  ----> 2 成功提交订单&nbsp;
         <br />
         <br />
    <div style="width:90%; border-width:2px; font-size:12px; vertical-align:middle; border-color:#ff65a0; border-style:solid">
      <table style="width:90%;border:0; border-bottom-color:white;">
      <tr>
        <td colspan="2" style="text-align:center;height:30px;vertical-align:middle;font-size:16px;font-weight:bold">
          
          收货人信息
            
        </td>
      </tr>
      <tr>
        <td class="leftcol">
           收货人
        </td>
        <td style="width:80%;text-align:left;height: 30px">
           <asp:TextBox runat="Server" ID="acceptnametb"></asp:TextBox>
           <asp:RequiredFieldValidator runat="server" ID="acceptnametbrfv" ControlToValidate="acceptnametb" ErrorMessage="请输入收货人" Display="dynamic"></asp:RequiredFieldValidator>
        </td>
      </tr>
      <tr>
        <td class="leftcol">
           收货详细地址
        </td>
        <td style="width:80%;text-align:left;height: 30px">
           <asp:TextBox runat="server" ID="addresstb" Width="400px"></asp:TextBox>
           <asp:RequiredFieldValidator runat="server" ID="addresstbrfv" ControlToValidate="addresstb" ErrorMessage="请输入收货详细地址" Display="dynamic"></asp:RequiredFieldValidator>
        </td>
      </tr>
      <tr>
        <td class="leftcol">
           邮政编码
        </td>
        <td style="width:80%;text-align:left;height: 30px">
            <asp:TextBox runat="server" ID="postalcodetb"></asp:TextBox>
         <asp:RequiredFieldValidator runat="server" ID="postalcodetbrfv" ControlToValidate="postalcodetb" ErrorMessage="请输入邮政编码" Display="dynamic"></asp:RequiredFieldValidator>
          <asp:RegularExpressionValidator runat="server" ID="postalcodetbrev" ControlToValidate="postalcodetb"
              ErrorMessage="邮政编码格式错误" Display="dynamic" ValidationExpression="^[1-9][0-9]{5}$"></asp:RegularExpressionValidator>
        </td>
      </tr>
      <tr>
        <td class="leftcol">
            联系电话
        </td>
        <td style="width:80%;text-align:left;height: 30px">
            <asp:TextBox runat="server" ID="phonetb"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="phonetbrfv" ControlToValidate="phonetb" ErrorMessage="请输入联系电话" Display="dynamic"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator runat="server" ID="phonetbrev" ControlToValidate="phonetb"
              ErrorMessage="联系电话格式错误" Display="dynamic" ValidationExpression="(\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$"></asp:RegularExpressionValidator>
        </td>
      </tr>
      <tr>
        <td colspan="2" style="text-align:center; vertical-align:middle;height:30px;font-size:16px; font-weight:bold">
           
             送货方式
           
        </td>
      </tr>
      <tr>
        <td colspan="2" style="text-align:center; vertical-align:middle">
            <asp:RadioButtonList ID="deliverylist" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="true" Text="普通快递送货上门(支持货到付款)"></asp:ListItem>
                <asp:ListItem Text="普通邮递(不支持货到付款)"></asp:ListItem>
                <asp:ListItem Text="邮件特快专递(不支持货到付款)"></asp:ListItem>
            </asp:RadioButtonList>
            
        </td>
      </tr>
      <tr>
          <td colspan="2" style="text-align:center; vertical-align:middle;height:30px;font-size:16px; font-weight:bold">
            
             付款方式
          
          </td>
      </tr>
      <tr>
        <td colspan="2" style="text-align:center;vertical-align:middle">
             <asp:RadioButtonList ID="paymentlist" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="工商银行"></asp:ListItem>
                <asp:ListItem Text="建设银行"></asp:ListItem>
                <asp:ListItem Text="农业银行"></asp:ListItem>
                <asp:ListItem Text="交通银行"></asp:ListItem>
                 <asp:ListItem Selected="true" Text="货到付款"></asp:ListItem>
                 <asp:ListItem Text="支付宝"></asp:ListItem>
                 <asp:ListItem Text="财富通"></asp:ListItem>
            </asp:RadioButtonList>
            
        </td>
      </tr>
      <tr>
         <td colspan="2" style="text-align:center;vertical-align:middle;height:40px;color:red">
            
                 请认真检查订单是否完整填写和填写正确再提交订单,以免造成不必要的麻烦
             
         </td>
      </tr>
      <tr>
        <td colspan="2"style="text-align:center;vertical-align:middle;height:40px;">
            <asp:Button ID="addorderbt" runat="server" CssClass="go-wenbenkuang" Text="确认订单信息并提交订单" OnClick="addorderbt_Click" />
            <input type="button" value="返回购物车" class="go-wenbenkuang" onclick="window.location.href = 'mycart.aspx'" />
        </td>
      </tr>
    </table>
    <br />
    </div>
   </div>
</asp:Content>

