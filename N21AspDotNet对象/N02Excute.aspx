<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="N02Excute.aspx.cs" Inherits="N21AspDotNet对象.N02Excute" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <h1>主页面</h1>
    <hr /><%--直接把内容放到前台, 有利于SEO--%>
    <% Server.Execute("N01Buffer缓冲区.aspx"); %>
    <hr /><%--不利于SEO--%>
    <iframe src="N01Buffer缓冲区.aspx"></iframe>
</body>
</html>
