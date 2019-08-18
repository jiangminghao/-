<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="feedbackshenhe.aspx.cs" Inherits="admin_feedbackshenhe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>留言管理</title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div style="margin:50px 0 0 100px;">
    <p style="font-size:18px;margin-left:20px;">留言管理>>></p><hr />
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DeleteMethod="deletefeed" SelectMethod="getfeedbacklist" 
        TypeName="Feedback" UpdateMethod="changeview">
        <DeleteParameters>
            <asp:Parameter Name="fb_id" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="fb_id" Type="String" />
            <asp:Parameter Name="isview" Type="Boolean" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1" 
        DataKeyNames="fb_id" onitemdatabound="ListView1_ItemDataBound" 
        onitemcommand="ListView1_ItemCommand" >
         <ItemTemplate>
               <asp:Label ID="fb_dateid" runat="server" Text='<%#Eval("fb_id") %>' Visible="false"></asp:Label>
                <span class="txtblue">留言日期:</span>
                <asp:Label ID="fb_dateLabel" runat="server" Text='<%# Eval("fb_date") %>' />&nbsp;&nbsp;&nbsp;&nbsp;
                 <br />
                <span class="txtblue">姓名:</span>
                <asp:Label ID="fb_nameLabel" runat="server" Text='<%# Eval("username") %>' />
                <br />
                <span class="txtblue">标题:</span>
                <asp:Label ID="fb_titleLabel" runat="server" Text='<%# Eval("fb_title") %>' />
                <br />
                <span class="txtblue">内容:</span>
                <asp:Label ID="fb_contentLabel" runat="server" 
                    Text='<%# Eval("fb_content") %>' />
                
                <br />
                <br />
            <asp:ImageButton runat="server" ID="ibtAllow"  CommandName="deny" ToolTip="允许查看" ImageUrl="~/images/yunxu.png" Height="24" Width="24" />
            <asp:ImageButton runat="server" ID="ibtDeny"  CommandName="allow" ToolTip="拒绝查看" ImageUrl="~/images/jujue.png" Height="26" Width="26" />
            <asp:ImageButton runat="server" ID="ibtDelete"  CommandName="Delete" ToolTip="删除" ImageUrl="~/images/shanchu.png" Height="24" Width="24" />
                <br />
                <br />
            </ItemTemplate>
            <LayoutTemplate>
            <div id="itemPlaceholderContainer" runat="server" style="">
                <span runat="server" id="itemPlaceholder" />
            </div>
            <div style="">
            </div>
        </LayoutTemplate>
    </asp:ListView>
    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" 
        PageSize="3">
        <Fields>
            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                ShowLastPageButton="True" />
        </Fields>
    </asp:DataPager>
</div>    <br />


</asp:Content>

