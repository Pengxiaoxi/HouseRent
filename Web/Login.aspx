<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="myhouse.Web.Login" %>

<!DOCTYPE html>
<html>
<head>
<title>房屋租赁管理系统登录窗口</title>
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="Shadow Login Form template Responsive, Login form web template,Flat Pricing tables,Flat Drop downs  Sign up Web Templates, Flat Web Templates, Login sign up Responsive web template, SmartPhone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<!-- Custom Theme files -->
<link href="css/style-login.css" rel="stylesheet" type="text/css" media="all" />
<!-- //Custom Theme files --> 
<!-- web font --> 
<link href="//fonts.googleapis.com/css?family=Cormorant+Garamond:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet">
<link href="//fonts.googleapis.com/css?family=Arsenal:400,400i,700,700i" rel="stylesheet">
<link rel="icon" href="/img/house.jpg"/>

<!-- //web font -->
    <script>
        //验证码
        function loadimage() {
            document.getElementById("randImage").src = "/Login_ValidateCode.ashx?d=" + Math.random();
        }

        //注册跳转
        function register()  
        {
            window.location.href="/Register.aspx"
        }

    </script>
</head>
<body>
	<!-- main --> 
	<div class="main-agileinfo slider ">
		<div class="items-group">
			<div class="item agileits-w3layouts">
				<div class="block text main-agileits"> 
					<span class="circleLight"></span> 
					<!-- login form -->
					<div class="login-form loginw3-agile"> 
						<div class="agile-row">
							<!--<h1>Shadow Login Form</h1>--> 
                            <h2>：）欢迎登录</h2>
							<div class="login-agileits-top"> 	
								<form runat="server"> 
									<p>用户名</p>
									<input type="text" class="name" name="username" />
									<p>密码</p>
									<input type="password" class="password" name="userpass" />
                                    <p>验证码</p>
                                    <input type="text" class="validate" name="validate" /><img class="validateimg" src="/Login_ValidateCode.ashx" onclick="javascript:loadimage()" title="换一张试试" name="randImage"
                                    id="randImage" border="0" align="right"/>

									<label class="anim">
										<input type="checkbox" class="checkbox" name="remember">
										<span style="color:green;">记住我?</span> 
									</label><br />
									<p style="text-align:center; color:red; font-size:16px;"><%=ErrorMsg %></p>
                                    <input type="button" class="register" value="注册" onclick="register()"> 
                                    <input type="submit"  value="登录"> 
								</form> 	
							</div> 
						</div>  
					</div>   
				</div>
				<div class="w3lsfooteragileits">
					<p> &copy; 2018-07-08. All Rights Reserved | Design by <a href="https://github.com/Pengxiaoxi">Pengxiaoxi</a></p>
				</div> 
			</div>
		</div>
	</div>	 
	<!-- //main --> 
</body>
</html>
