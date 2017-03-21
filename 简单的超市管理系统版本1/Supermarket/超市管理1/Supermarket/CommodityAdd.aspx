<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommodityAdd.aspx.cs" Inherits="Supermarket.CommodityAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<script src="http://localhost:21478/Scripts/jquery-1.4.1.js" type="text/javascript"></script>
<head runat="server">
    <title></title>
    <script type="text/javascript">
        //检查时候打折
        function che() {
            if (document.getElementById("cbIsDiscount").checked) {
                document.getElementById("textReducePrice").disabled = false;
            } else {
                document.getElementById("textReducePrice").disabled = true;
            }
        }

    </script>
    <style type="text/css">
        body{background-color:#646464;color:White;}
        .my_content{width:500px;margin:100px auto;}
        .my_footer{padding-left:50px;}
        .my_footer>input{display: inline-block;outline: none;cursor: pointer;text-align: center;
	text-decoration: none;font: 14px/100% Arial, Helvetica, sans-serif;padding: .2em 1em .2em;
	text-shadow: 0 1px 1px rgba(0,0,0,.3);-webkit-border-radius: .5em; -moz-border-radius: .5em;
	border-radius: 0em;-webkit-box-shadow: 0 1px 2px rgba(0,0,0,.2);-moz-box-shadow: 0 1px 2px rgba(0,0,0,.2);
	box-shadow: 0 1px 2px rgba(0,0,0,.2);}
	#DropDownListEvent{width:153px;heigth:22px;}
	#textReducePrice:disabled{background-color:Yellow;}
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
   
    <div class="my_content">
     <asp:Label ID="Label1" runat="server" Text="商品名称"></asp:Label>
     <asp:TextBox ID="textCommodityName" runat="server"></asp:TextBox><br/><br/>
    
        <asp:Label ID="Label2" runat="server" Text="商品分类"></asp:Label>
        <asp:DropDownList ID="DropDownListEvent" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="SortName" 
            DataValueField="SortName">
        </asp:DropDownList><br/><br/>
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SupermarketConnectionString %>" 
            SelectCommand="SELECT [SortName] FROM [CommoditySort]"></asp:SqlDataSource>
    

    <asp:Label ID="Label3" runat="server" Text="价  格 ： "></asp:Label>
    <asp:TextBox ID="textPrice" runat="server"></asp:TextBox>
    <asp:Label ID="Label4" runat="server" Text="是否打折"></asp:Label>
    <asp:CheckBox ID="cbIsDiscount" runat="server" TextAlign="Left" onclick="che()" />
   
    <br/><br />    
    <asp:Label ID="Label5" runat="server" Text="打折价格"></asp:Label>
    <asp:TextBox ID="textReducePrice" runat="server" disabled = "disabled"></asp:TextBox>
   <br/><br/>
   <div class="my_footer">
    <asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click" />
    <asp:Button ID="btnClose" runat="server" Text="关闭" onclick="btnClose_Click" />
    </div>
        </div>
    </form>
</body>
</html>
