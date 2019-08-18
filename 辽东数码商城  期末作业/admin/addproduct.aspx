<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="addproduct.aspx.cs" Inherits="admin_addproduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style1 {
        height: 148px;
    }
    .auto-style2 {
        height: 23px;
    }
        .auto-style3 {
            height: 39px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table class="table  table-bordered" style="height:600px">
       
        <tr>
            <td >
                商品名称</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 0px" Width="296px" 
                    ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBox1" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3" >
                一级分类</td>
            <td class="auto-style3">
                <asp:DropDownList ID="DropDownList1" runat="server" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td >
                二级分类</td>
            <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:DropDownList runat="server" ID="drop2">
                    </asp:DropDownList>
                </ContentTemplate>
                    
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DropDownList1" />
                </Triggers>
                </asp:UpdatePanel>
                
            </td>
        </tr>
        <tr>
            <td >
                是否推荐</td>
            <td>
                <asp:CheckBox ID="CheckBox1" runat="server" />
            </td>
        </tr>
        <tr>
            <td >
                是否特价</td>
            <td>
                <asp:CheckBox ID="CheckBox2" runat="server" />
            </td>
        </tr>
        <tr>
            <td >
                市场价</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBox2" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td >
                会员价</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TextBox3" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td >
                特价</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                点击数</td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td >
                商品图片</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td >
                数量</td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="TextBox6" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td >
                销售量</td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" >
                商品描述</td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBox8" runat="server" Height="173px" TextMode="MultiLine" 
                    Width="391px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2" >
                </td>
            <td class="auto-style2">
                <asp:Button ID="Button1" runat="server" Text="确定" onclick="Button1_Click" />
           
               </td>
        </tr>
    </table>
</asp:Content>

