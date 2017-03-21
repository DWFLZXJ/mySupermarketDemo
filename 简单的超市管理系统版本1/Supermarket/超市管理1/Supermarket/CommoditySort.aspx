<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommoditySort.aspx.cs" Inherits="Supermarket.CommoditySort" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body{background-color:#646464;color:White;}
        .mycontent{width:600px;margin:50px auto;}
        a{color:White;}
        #gvCommodity{border:1px solid black;width:600px;}
        #buttonSearch,#butttonDelete,#buttonAdd{display: inline-block;outline: none;cursor: pointer;text-align: center;
	text-decoration: none;font: 14px/100% Arial, Helvetica, sans-serif;padding: 2px 10px;
	text-shadow: 0 1px 1px rgba(0,0,0,.3);-webkit-border-radius: .5em; -moz-border-radius: .5em;
	border-radius: 0em;-webkit-box-shadow: 0 1px 2px rgba(0,0,0,.2);-moz-box-shadow: 0 1px 2px rgba(0,0,0,.2);
	box-shadow: 0 1px 2px rgba(0,0,0,.2);}
    
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mycontent">
    <a href="CommoditySortManage.aspx">商品分类管理</a>
    <a href="UsersManage.aspx">用户信息管理</a><br/><br/>
    <asp:Label ID="labelSort" Text="商品分类：" runat="server"></asp:Label>
    <asp:DropDownList ID="dropDownListEvents" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="SortName" 
            DataValueField="SortName" AutoPostBack="True" 
            onselectedindexchanged="dropDownListEvents_SelectedIndexChanged">
    
        <asp:ListItem>酒水</asp:ListItem>
        <asp:ListItem>家居</asp:ListItem>
        <asp:ListItem>生活用品</asp:ListItem>

    </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SupermarketConnectionString %>" 
            SelectCommand="SELECT [SortName] FROM [CommoditySort]"></asp:SqlDataSource>
    <asp:Label ID="labelCommedityName" Text="商品名称：" runat="server"></asp:Label>
    <asp:TextBox ID="textSearch" runat="server"></asp:TextBox>
    <asp:Button ID="buttonSearch" runat="server" Text="检索" 
            onclick="buttonSearch_Click" />
    <asp:Button ID="butttonDelete" runat="server" Text="删除" 
            onclick="butttonDelete_Click" />
    <asp:Button ID="buttonAdd" runat="server" Text="新增" onclick="buttonAdd_Click1" />
    
    
    <br/><br/><br/>

        <asp:GridView ID="gvCommodity" runat="server" AutoGenerateColumns="False">
            <Columns>
               
               <%-- <asp:HyperLinkField DataTextField="CommodityName" HeaderText="商品名称" 
                  NavigateUrl='<%#"CommodityAdd.aspx?name="+DataBinder.Eval(Container.DataItem,"CommodityName")%> ' 
                  />--%>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbSelection" runat="server" AutoPostBack="True" />
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField HeaderText="商品名称">
                    <ItemTemplate>
                        <asp:HyperLink ID="Commodity" runat="server"  NavigateUrl='<%#"CommodityAdd.aspx?name="+DataBinder.Eval(Container.DataItem,"CommodityName")%> '><%# Eval("CommodityName") %></asp:HyperLink>
                        <%--<asp:HyperLink ID="hl" NavigateUrl='<%#"CommodityAdd.aspx?name="+DataBinder.Eval(Container.CommodityName,"商品名称")%> '
                        runat="server" Text="<%# Eval("CommodityName") %>"></asp:HyperLink>--%>
                    </ItemTemplate>
                </asp:TemplateField>
               
                <asp:BoundField DataField="SortName" HeaderText="类别名称" />
                <asp:BoundField DataField="CommodityPrice" HeaderText="价格" />
                <asp:CheckBoxField DataField="IsDiscount" HeaderText="是否打折" />
                <asp:BoundField DataField="ReducedPrice" HeaderText="打折价格" />
                <asp:BoundField DataField="CommodityID" HeaderText="CommodityID" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>


