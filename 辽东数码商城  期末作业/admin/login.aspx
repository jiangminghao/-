<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="admin_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <!-- Bootstrap -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="../js/html5shiv.min.js"></script>
      <script src="../js/respond.min.js"></script>
    <![endif]-->
    <style>
        #main{
            padding-top:300px;
        }
        .tab1{
            width:200px;
        }
        .tab2{
           width:300px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
 <div class="container">
     <div class="row text-center">
         <div class="col-md-3"></div>
         
            <div class="col-md-9  " id="main">
               
                <table class="table table-bordered" style="width:500px">
                 
                   
                    <tr>
                        
                        <td class="tab1 text-right">
                            &nbsp;用户名：</td>
                        <td class="tab2 text-left">

                            <asp:TextBox ID="TextBox1" runat="server" Width="220px" placeholder="请输入用户名"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                          <td class="tab1 text-right">

                              密码：</td>
                        <td class="tab2 text-left">

                            <asp:TextBox ID="TextBox2" runat="server" Width="215px" TextMode="Password"  placeholder="请输入密码"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                          <td class="tab1">

                        </td>
                        <td class="tab2 text-left">

                            <asp:Button ID="Button1" CssClass="btn-default btn-primary" runat="server" Text="确定" Width="99px" OnClick="Button1_Click" />

                        </td>
                    </tr>
                </table>

            </div>
      </div>
    </div>
    
    </form>
</body>
</html>
