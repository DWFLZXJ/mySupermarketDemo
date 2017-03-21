<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommodityManage.aspx.cs" Inherits="mySupermarketDemo.CommodityManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body{background-image:url('Images/mybg.jpg');background-size:100% auto;text-align:center;}
        .my_content{width:600px;margin:50px auto;background-color:rgba(0,0,0,0.05); border-radius:5%;padding:20px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="my_content">
    <%--顶部的两个链接--%>
        <asp:HyperLink ID="hlCMPage" runat="server">商品管理界面</asp:HyperLink>
        <asp:HyperLink ID="hlUMPage" runat="server">用户管理界面</asp:HyperLink><br/><br/>
        <asp:Label ID="Label1" runat="server" Text="商品分类"></asp:Label>
        <asp:DropDownList ID="ddlSort" runat="server"></asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="商品名称"></asp:Label>
        <asp:TextBox ID="txtCName" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="检索" />
        <asp:Button ID="btnDelete" runat="server" Text="删除" />
        <asp:Button ID="btnAdd" runat="server" Text="新增"/>
    </div>
    </form>
</body>
</html>
