<%@ Page Title="" Language="C#" MasterPageFile="~/web/webmaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Src="usercontrol/special.ascx" TagName="special" TagPrefix="uc5" %>
<%@ Register Src="usercontrol/commend.ascx" TagName="commend" TagPrefix="uc6" %>
<%@ Register Src="usercontrol/hottop.ascx" TagName="hottop" TagPrefix="uc7" %>

<%@ Register Src="usercontrol/newproducts.ascx" TagName="newproducts" TagPrefix="uc4" %>

<%@ Register Src="usercontrol/sort.ascx" TagName="sort" TagPrefix="uc2" %>
<%@ Register Src="usercontrol/selltop.ascx" TagName="selltop" TagPrefix="uc3" %>

<%@ Register Src="usercontrol/research.ascx" TagName="research" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <div class="clearfix"></div>
    <div class="row">
        <div class="col-md-2" style=" border-color:darkslategray">
        <table style="width:100%;" >
          <tr>
            <td >
                <uc1:research ID="Research1" runat="server" />
              
            </td>
          </tr>
          <tr>
            <td>
                <uc2:sort ID="Sort1" runat="server" />
            </td>
          </tr>
      
          <tr>
            <td >
                <uc3:selltop ID="Selltop1" runat="server" />
            </td>
          </tr>
         <tr><td> 
            <img src="../adpic/news1.jpg" />
                <img src="../adpic/news2.jpg" />&nbsp;
                <img src="../adpic/news3.jpg" />

             </td></tr>
        
         </table>
        </div>
        <div class="col-md-10">
            <div>
            <uc4:newproducts ID="Newproducts1" runat="server" /></div>
            <hr />
            <div>
            <uc5:special ID="Special1" runat="server" /></div>
            <hr />
            <div class="container" >
                <div class="row">
                  <div class="col-md-7">
                     <uc6:commend ID="Commend1" runat="server" />
            </div>
                    <div class="col-md-3">
            <uc7:hottop ID="Hottop1" runat="server" />
</div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>

