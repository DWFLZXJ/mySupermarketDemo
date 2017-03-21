<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Supermarket._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>登录界面</title>
<script type="text/javascript">
    function login() {
        var user = document.getElementById("textUserName").value;
        var pass = document.getElementById("textPassword").value;
        if (user == '' || pass == '') {
            alert("这个不能为空的");
            return false;
        } else {
        return true;
        }
    }
</script>
<style type="text/css">
    body{background-color:#646464;}
    .my_login{width:300px;margin:100px auto;color:White}
    #buttonLogin{display: inline-block;outline: none;cursor: pointer;text-align: center;
	text-decoration: none;font: 14px/100% Arial, Helvetica, sans-serif;padding: .5em 2em .5em;
	text-shadow: 0 1px 1px rgba(0,0,0,.3);-webkit-border-radius: .5em; -moz-border-radius: .5em;
	border-radius: 0em;-webkit-box-shadow: 0 1px 2px rgba(0,0,0,.2);-moz-box-shadow: 0 1px 2px rgba(0,0,0,.2);
	box-shadow: 0 1px 2px rgba(0,0,0,.2);margin-left:100px;}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="my_login">
    <asp:Label ID="labelUserName" runat="server" Text="用户名："></asp:Label>
    <asp:TextBox ID="textUserName" runat="server"></asp:TextBox><br/><br/>
    <asp:Label ID="labelPassword" runat="server" Text="密  码 ："></asp:Label>
    <asp:TextBox ID="textPassword" runat="server"></asp:TextBox><br/><br/>
    <asp:Button ID="buttonLogin" runat="server" Text="登录" onclientclick=" return login()" 
            onclick="buttonLogin_Click"/>
    </div>
    </form>
</body>
</html>
