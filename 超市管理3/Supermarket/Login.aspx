<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Supermarket.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
<head runat="server">
    <title></title>
    <script type="text/javascript" language="javascript">
        function chec() {
            var user = $("#tbUserName").val();
            var pass = $("#tbPassword").val();
            if (user == '') {
                alert("请输入用户名！");
                return false;
            }
            if (pass == '') {
                alert("请输入密码！");
                return false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lbUserName" Text="用户名：" runat="server"></asp:Label>
        <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>
        <asp:Label ID="lbPassword" Text="密码：" runat="server"></asp:Label>
        <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
        <asp:Button ID="btnLogin" Text="登录" runat="server" 
            OnClientClick="return chec()" onclick="btnLogin_Click" />
    </div>
    </form>
</body>
</html>
