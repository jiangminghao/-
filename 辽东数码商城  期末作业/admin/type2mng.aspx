<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="type2mng.aspx.cs" Inherits="admin_type2mng" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h2>二级分类列表：</h2>
          <hr /><asp:Button ID="Button1" runat="server" Text="添加新二级分类" OnClick="Button1_Click" />
        <asp:GridView ID="GridView1" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Width="699px" DataKeyNames="type2id" OnRowCommand="GridView1_RowCommand" AllowPaging="True" PageSize="6">
            <Columns>
                <asp:BoundField DataField="type1name" HeaderText="一级分类名称" />
                <asp:BoundField DataField="type2id" HeaderText="二级分类编号" />
                <asp:BoundField DataField="type2name" HeaderText="二级分类名称" />
                <asp:BoundField DataField="type1id" HeaderText="一级分类编号" Visible="False" />
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("type2id") %>' CommandName="edi">编辑</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("type2id") %>' CommandName="del" OnClientClick="confirm(&quot;确定删除吗？&quot;);">删除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getall" TypeName="type_2"></asp:ObjectDataSource>
        
    </div>
    <div id="weihu" runat="server" visible="false">
        
       
         一级分类名称：<asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="199px"></asp:DropDownList> 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        二级分类名称：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
        <asp:Button ID="Button2" runat="server" Text="确定" OnClick="Button2_Click" />
    </div>
</asp:Content>

