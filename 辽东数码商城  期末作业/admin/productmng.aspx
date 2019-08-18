<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="productmng.aspx.cs" Inherits="admin_productmng" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div style=" width:100%;height:auto;text-align:center">
<h1>商 品 管 理</h1>

<hr />
    <asp:GridView ID="GridView1" runat="server" CellPadding="3" 
        ForeColor="Black"  AllowPaging="True"
        GridLines="Vertical" Width="700px" AutoGenerateColumns="False" 
        DataKeyNames="productid" DataSourceID="ObjectDataSource1" 
         CssClass="table table-bordered" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="left" Width="10%" />
            </asp:TemplateField>
            <asp:BoundField DataField="productname" HeaderText="商品名称" >
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="left" Width="60%" />
            </asp:BoundField>
            <asp:BoundField DataField="userprice" HeaderText="会员价">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="left" Width="20%" />
            </asp:BoundField>
            <asp:TemplateField Visible="False">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("productid") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl='<%# Eval("productid","productlist.aspx?pid={0}") %>'>详细</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="getnewproductlist" TypeName="product"></asp:ObjectDataSource>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="删除选中商品" />  
     
    <br />
    <br />
        </div>


</asp:Content>

