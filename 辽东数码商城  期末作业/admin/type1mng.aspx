<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="type1mng.aspx.cs" Inherits="admin_type1mng" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div>
        <h1>一级分类列表：</h1>
        <br />
        <hr />
        <asp:GridView ID="GridView1"  CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Width="448px" DataKeyNames="typeid_1">
            <Columns>
                <asp:BoundField DataField="typeid_1" HeaderText="一级分类编号" ReadOnly="True" />
                <asp:BoundField DataField="typename" HeaderText="一级分类名称" />
                <asp:CommandField HeaderText="操作" ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
        </asp:GridView>

        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getall" TypeName="type_1" DeleteMethod="deletetype_1" UpdateMethod="updatetype_1">
            <DeleteParameters>
                <asp:Parameter Name="typeid_1" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="typeid_1" Type="Int32" />
                <asp:Parameter Name="typename" Type="String" />
            </UpdateParameters>
        </asp:ObjectDataSource>

    </div> 
    <div>

        输入一级分类名：<asp:TextBox ID="TextBox1" runat="server" placeholer="输入新的一级分类"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" />
    </div>
</asp:Content>

