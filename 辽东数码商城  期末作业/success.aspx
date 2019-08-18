<%@ Page Title="" Language="C#" MasterPageFile="~/web/webmaster.master" AutoEventWireup="true" CodeFile="success.aspx.cs" Inherits="success" %>
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
            <div style="height:41px;background-image:url(images/body/xian.jpg)"></div>

          <h3>恭喜你！！订单提交成功</h3>
            <input type="button" value="返回首页继续购物" class="btn btn-danger" onclick="window.location.href = 'default.aspx'" />
    </div>

           
    </div>
</asp:Content>

