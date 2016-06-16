<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="N01动态页面类的位置.aspx.cs" Inherits="N22页面生命周期.N01动态页面类的位置" Trace="true" %>
<%@ Import Namespace="System.Reflection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <% Response.Write("代码页面类位置: " + Assembly.GetExecutingAssembly().Location); %>
    </div>
    </form>
</body>
</html>
