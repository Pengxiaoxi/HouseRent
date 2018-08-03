<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="myhouse.Web.MyAdmin.AdminLogin" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="renderer" content="webkit">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <title>后台登录</title>
    <link rel="stylesheet" href="/MyAdmin/frame/layui/css/layui.css">
    <link rel="stylesheet" href="/MyAdmin/frame/static/css/style.css">
    <link rel="icon" href="/img/house.jpg"/>
</head>
<body style="background-color:#393D49">

<div class="login-main">
    <header class="layui-elip" style="color:white; font-family:STXingkai;">房屋租赁管理系统</header>
    <form class="layui-form" runat="server">
        <div class="layui-input-inline">
            <input type="text" name="name"  placeholder="用户名"     <%--required lay-verify="required"--%>
                   class="layui-input">
        </div>
        <div class="layui-input-inline">
            <input type="password" name="pass" placeholder="密码"
                   class="layui-input">
        </div>
        <div class="layui-input-inline login-btn">
            <button type="submit" class="layui-btn" style="background-color:#D7532a" >登录</button>
            <a href="/Index.aspx" style="color:white; float:right;">返回首页</a>
            <span style="color:red;"><%=ErrorMsg %></span>
        </div>
        
     </form>
</div>


<%--<script src="/MyAdmin/frame/layui/layui.js"></script>--%>
<%--<script type="text/javascript">
    layui.use(['form'], function () {

        // 操作对象
        var form = layui.form
                , $ = layui.jquery;

        // you code ...


    });
</script>--%>
</body>
</html>
