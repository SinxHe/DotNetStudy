<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="N01基础.aspx.cs" Inherits="N20WebForm.N01基础" %>

<%--生成一个类, 父类是N20WebForm.N01基础--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%= this.Str1 %><br />
            <%--<%= str %> can't access private here --%>
        </div>
    </form>
</body>
</html>
