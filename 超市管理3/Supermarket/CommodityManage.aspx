<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommodityManage.aspx.cs" Inherits="Supermarket.CommodityManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="ff" runat="server">商品分类管理</asp:HyperLink>
        <asp:HyperLink ID="HyperLink1" runat="server">用户管理</asp:HyperLink><br/>
        <asp:Label ID="lbCommoditySort" Text="商品分类" runat="server"></asp:Label>
        <asp:DropDownList ID="ddlCommoditySort" runat="server"></asp:DropDownList>
        <asp:Label ID="lbCommodityName" runat="server" Text="商品名称"></asp:Label>
        <asp:TextBox ID="tbCommodityName" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="搜索" onclick="btnSearch_Click" />
        <asp:Button ID="btnAdd" runat="server" Text="增加" onclick="btnAdd_Click"/>
        <asp:Button ID="btnDelete" runat="server" Text="删除" onclick="btnDelete_Click"/><br/>

        <asp:GridView ID="gvCommodity" runat="server" AutoGenerateColumns="False" DataKeyNames="CommodityID">
            <Columns>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbSelection" runat="server"></asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <a href='CommodityAdd.aspx?cid=<%# Eval("CommodityID") %>'><%# Eval("CommodityName") %></a>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="SortName" HeaderText="类别名称" />
                <asp:BoundField DataField="CommodityPrice" HeaderText="价格" />
                <asp:CheckBoxField DataField="IsDiscount" Text="是否打折" />
                <asp:BoundField DataField="ReducedPrice" HeaderText="打折价格"/>


            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
