<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="测试._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
    <asp:GridView ID="gv" runat="server" EnableModelValidation="True">
        <Columns>
            <asp:TemplateField HeaderText="发发发">
                <ItemTemplate>
                    <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
            
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </form>
</body>
</html>
