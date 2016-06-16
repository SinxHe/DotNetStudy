<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="N04EditNewsFrame.aspx.cs" Inherits="N23异步.N04EditNewsFrame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/jquery-1.7.1.js"></script>
    <script type="text/javascript">
        $(function () {
        });
   
        function submitFrm() {
            //alert("我是子容器");
            //让下面的表单整体的异步的提交到后台。
            var postData = $("#form1").serializeArray();
            $.post("N04UpdateNews.ashx", postData, function (data) {
                if (data == "ok") {
                    //修改成功
                    //关闭父容器的对话框，刷新父容器的表格。
                    window.parent.window.afterEditSuccess();
                }else {
                    alert("败了啊");
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="hidden" name="hidId" value="<%= dr["ID"] %>" />
            <table>
                <tr>
                    <td>新闻标题:</td>
                    <td>
                        <input type="text" name="title" value="<%= dr["title"] %>" />
                    </td>
                </tr>
                <tr>
                    <td>新闻发布人:</td>
                    <td>
                        <input type="text" name="people" value="<%= dr["people"] %>" />
                    </td>
                </tr>
                <tr>
                    <td>新闻内容:</td>
                    <td>
                        <textarea name="txtEditContent" cols="50" rows="10">
                        <%= dr["content"] %>
                    </textarea>
                    </td>
                </tr>

            </table>

        </div>
    </form>
</body>
</html>
