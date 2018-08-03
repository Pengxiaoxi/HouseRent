<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="myhouse.Web.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>首页</title>
    <link rel="icon" href="/img/house.jpg"/>
</head>
<body>
    <div id="header" class="wrap" style="width: 100%; margin: 0 auto;">
        <% Server.Execute("/common/Top.aspx"); %>     <%--Execute是从当前页面转移到指定页面，并将执行返回到当前页面--%>
    </div>

    <div id="content" style="width: 100%; margin: 0 auto;">
        <% Server.Execute("/common/Default.aspx"); %>
    </div>

    <div id="footer" style="width: 100%; margin: 0 auto;">
        <% Server.Execute("/common/Footer.aspx"); %>
    </div>

</body>
</html>
