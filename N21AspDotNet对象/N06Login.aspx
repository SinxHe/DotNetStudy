<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="N06Login.aspx.cs" Inherits="N21AspDotNet对象.N06Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!-- saved from url=(0035)http://www.800kb.com/ClientManager/ -->
<html xmlns="http://www.w3.org/1999/xhtml"><head><meta http-equiv="Content-Type" content="text/html; charset=GBK"><title>
	网站管理后台登录
</title><link href="N06Images/style.css" rel="stylesheet" type="text/css">
    <style type="text/css">
    <!--
    body {
	    margin-top: 150px;
    }
    -->
    </style>
    <script src="Scripts/jquery-1.7.1.js"></script>
    <script type="text/javascript">
        $(function() {
            $("#Image1").click(function() {
                var url = $(this).attr("src");
                url += "1"; // 如果url地址一样的话浏览器可能会从缓存中取
                $(this).attr("src", url);
            });
        });
    </script>
</head>
<body>
    <%--aspx页面必须有一个form表单, 并且表单必须runat = "server"--%>
    <form name="form1" method="post" runat="server" id="form1">
    <div>
    <table width="549" height="287" border="0" align="center" cellpadding="0" cellspacing="0" background="N06Images/login_bg.jpg">
      <tbody><tr>
        <td width="23"><img src="N06Images/login_leftbg.jpg" width="23" height="287"></td>
        <td width="503" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tbody><tr>
            <td width="49%" valign="bottom"><table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
              <tbody><tr>
                <td height="100" valign="top" class="login_text"><div align="left">
                    网站后台管理系统</div></td>
              </tr>
              <tr>
                <td><div align="right"><img src="N06Images/login_img.jpg" width="104" height="113"></div></td>
              </tr>
            </tbody></table></td>
            <td width="2%"><img src="N06Images/login_line.jpg" width="6" height="287"></td>
            <td width="49%"><div align="right">
              <table width="223" border="0" cellspacing="0" cellpadding="0">
                <tbody><tr>
                  <td><img src="N06Images/login_tit.jpg" width="223" height="30"></td>
                </tr>
                <tr>
                  <td><table width="100%" border="0" cellspacing="10" cellpadding="0">
                    <tbody><tr>
                      <td width="28%"><div align="left">用户名：</div></td>
                      <td width="72%"><div align="left"><span class="style1">
                          <input name="txtClientID" type="text" id="txtClientID" class="form2" style="height:15px;width:140px;" value="<%=StrUserName %>">
                      </span></div></td>
                    </tr>
                    <tr>
                      <td><div align="left">密&nbsp;&nbsp;码：</div></td>
                      <td><div align="left"><span class="style1">
                          <input name="txtPassword" type="password" id="txtPassword" class="form2" style="height:15px;width:140px;"></span></div></td>
                    </tr>
                    <tr>
                      <td><div align="left">验证码：</div></td>
                      <td><div align="left">
                          <img id="Image1" src="ValidateCodeImageHandler.ashx?id=1" style="border-width:0px;">&nbsp;</div></td>
                    </tr>
                    <tr>
                      <td><div align="left">验证码：</div></td>
                      <td><div align="left"><span class="style1">
                          <input name="txtCode" type="text" size="8" id="txtCode" class="form2" style="height:15px;"></span></div></td>
                    </tr>
                  </tbody></table></td>
                </tr>
                <tr>
                  <td align="center"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tbody><tr>
                      <td><div align="center"><a href="http://www.800kb.com/ClientManager/#"></a></div></td>
                      <td><div align="center">
                          <input type="image" name="btnLogin" id="btnLogin" src="N06Images/login_menu2.jpg" style="border-width:0px;"><a href="http://www.800kb.com/ClientManager/#"></a></div></td>
                    </tr>
                  </tbody></table>
                      <strong><span style="color: #3180b7">辽ICP备10012593号</span></strong></td>
                </tr>
              </tbody></table>
            </div></td>
          </tr>
        </tbody></table></td>
        <td width="23"><img src="N06Images/login_rigbg.jpg" width="23" height="287"></td>
      </tr>
    </tbody></table>
    </div>
    </form>
</body></html>
<%=StrScript %>