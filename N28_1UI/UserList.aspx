<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="N28_1UI.UserList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <thead>
                    <tr>
                        <td>Id</td>
                        <td>姓名</td>
                        <td>登录名</td>
                        <td>时间</td>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptUserList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("uId") %></td>
                                <td><%#Eval("uName") %></td>
                                <td><%#Eval("uLoginName") %></td>
                                <td><%#Eval("uAddtime") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
