<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="myhouse.Web.common.Top" %>

<!DOCTYPE html>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<title>Insert title here</title>
<link href="/css/style.css" rel="stylesheet" />
    <link rel="icon" href="/img/house.jpg"/>

    <script src="../lib/jquery/1.9.1/jquery.min.js"></script>

<%--    <style>
        #menu a:active {
        border-radius: 20px;
	    text-decoration: none;
        background-color:forestgreen;
}
        .a1 {
            border-radius: 20px;
	        text-decoration: none;
            background-color:forestgreen;
        }
    </style>--%>

<script>
         //$('#menu-ul li').click(function () {
         //       var f = this;
         //       $('#menu li').each(function () { this.className = this == f ? 'menu-click' : 'menu-click' });
         //});

    //$("#menu ul li a").click(function () {
    //    var f = this;
    //    alert(f);
        
    //    $('#menu ul li a').addClass('a1');
    //});

         //var url = window.location.pathname;
         ////alert(url);
         //if (url == "/Index.aspx") {
         //    $("#a1").css("background-color", "forestgreen");
         //}
         //else if (url == "/MyHouse.aspx") {
         //    $("#a2").css("background-color", "red");
         //}
</script>

    <script type="text/javascript">
        function loginout() {
	        if (confirm("您确定要退出吗？")) {
		        window.location.href="/LoginOut.ashx";
	        }
        }

        function login(){
            var curPage = window.location.pathname;   //登录成功后跳转回当前页（不包含参数，注意防止请求参数报错）
            var param = window.location.search;    //获取后面的参数
	        window.location.href="/Login.aspx?prePage=" +curPage+param;    //跳转到目的地址并携带之前的参数
        }

    </script>
</head>

<body>
<div>
	<div id="header-wrapper">
		<div id="header" class="container">
			<div id="logo">
				<h1><a href="#">乐租房</a></h1>	
			</div>
		</div>
	</div>
	<div id="menu-wrapper">
		<div id="menu" class="container">
			<ul id="menu-ul">
				<li  class="a1"><a href="/Index.aspx">首　页</a></li>
				<li ><a href="/MyHouse.aspx">我的房屋</a></li>
				<li ><a href="/ViewAnnounce.aspx ">公告浏览</a></li>
                <li ><a href="/MyCollect.aspx">我的收藏</a></li>
				<li ><a href="/UserInfo.aspx">个人信息</a></li>
				<li ><a href="/MyAdmin/AdminLogin.aspx">后台管理</a></li>
			</ul>
		</div>
	</div>
    <div >
        <div class="announce">
            <b>最新公告：</b><a href="/ViewAnnounceDetails.aspx?aid=<%=announceList[0].aid %>" title="点击查看公告"><%=announceList[0].atitle %></a>
        </div>
        <div class="login">
            <%
                if (Session["userInfo"] == null)
                {
             %>
                <input type="button" class="login-button" onclick="login()" value="登录"/>&nbsp;
                <input type="button" class="register-button" onclick="window.location.href='/Register.aspx?flag=register' " value="注册"/>
				    <%--<a href="javascript:checkUserLogin()">个人中心</a>--%>
             <%
                }
                else
                {
             %>
                   欢迎您，<a style="color:dodgerblue;" href="/UserInfo.aspx"><%=((myhouse.Model.User)Session["userInfo"]).uname %></a>  &nbsp;
                   <input type="button" class="logout-button" onclick="loginout()" value="注销"/>&nbsp;
             <%
                 }
        %>
        </div>
    </div>
</div>
</body>
</html>