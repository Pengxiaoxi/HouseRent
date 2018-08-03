<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="myhouse.Web.Register" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="renderer" content="webkit">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <title>用户注册</title>
    <link rel="stylesheet" href="/MyAdmin/frame/layui/css/layui.css">
    <link rel="stylesheet" href="/MyAdmin/frame/static/css/style.css">
    <%--<link rel="icon" href="/MyAdmin/frame/static/image/code.png">--%>
    <link rel="icon" href="/img/house.jpg"/>

    <style type="text/css">
        /*注册时头像上传按钮*/
.fileLabel{
          display: inline-block;
          width:100px;
          height: 36px;
          line-height: 40px;
          text-align: center;
          border: 1px solid #8cc051;
          border-radius: 5px;
          color:white;
          background-color:#8cc051;
          cursor: pointer;
          margin-right:80px;
        }

    </style>

    <script src="MyAdmin/js/jquery-1.11.1.js"></script>
    <script src="MyAdmin/js/uploadPreview.min.js"></script>

     
    <script>
        //头像预览
        $(function () {
            $("#simg").uploadPreview({ Img: "imgPr", Width: 220, Height: 200 });
        });

        //检查用户名是否已存在
        function checknickname(nickname)
        {
            //var nickname = $("#nickname").val();
            //alert(nickname);
            $.post("/CheckNickName.ashx", { nickName: nickname },
			function (result) {
			    //alert(result);
			    if (result == "False") {
			        $("#userErrorInfo2").html(null); 
			        $("#userErrorInfo1").html("用户名已存在，请选择一个新的昵称！");
			        
			        $("#nickname").focus();
			    } else {
			        $("#userErrorInfo1").html(null);
			        $("#userErrorInfo2").html("用户名可以使用！");
			    }
			}
	        );
        }

        //检查两次输入的密码是否正确
        function checkpass()
        {
            var pass1 = $("#password1").val();
            var pass2 = $("#password2").val();

            if (pass2 != pass1) {
                $("#passerror").html("两次密码不一样,请重新输入...");
            }
            else {
                $("#passerror").html(null);
            }

        }
    </script>

</head>
<body>
    <div >
        <div class="login-main" >
            <header class="layui-elip" style="margin-top:30px; color:#D7532a; font-weight:bold;">欢迎注册</header>

            <form class="layui-form" runat="server" enctype="multipart/form-data">  <%--文件上传--%>
                <div class="layui-input-inline">
                    <input type="text" id="nickname" name="nickname" required lay-verify="required"  placeholder="昵称"  class="layui-input" onblur="checknickname(this.value)">
                    <font id="userErrorInfo1" style="color:red; float:right"></font>
                    <font id="userErrorInfo2" style="color:green; float:right;"></font>
                </div>
                <div class="layui-input-inline">
                    <input type="text" name="name" required lay-verify="required"  placeholder="姓名"  class="layui-input">
                </div>
                <div class="layui-select">
                    <%--<input type="text" name="sex" required lay-verify="required"  placeholder="性别"  class="layui-input">--%>        
                    <label style="display:inline-block; width:130px;">身份</label>  
                    <label style="display:inline-block; margin-right:0px;">
                        <select name="type" >
                            <option value="1">租赁者</option>
                            <option value="0">房主</option>     <%--需要被审核才能成为房主，0表示未审核--%>
                        </select>
                    </label> 
                </div>

                <div class="layui-select">
                    <%--<input type="text" name="sex" required lay-verify="required"  placeholder="性别"  class="layui-input">--%>        
                    <label style="display:inline-block; width:130px;">性别</label>  
                    <label style="display:inline-block; margin-right:0px;">
                        <select name="sex" >
                            <option value="">请选择...</option>
                            <option value="男">男</option>
                            <option value="女">女</option>
                        </select>
                    </label> 
                </div>
           
                <div class="layui-input-inline"> 
                    <label class="fileLabel" for="simg" >选择头像</label>            
                        <input type="file" name="photo" id="simg" style="display:none;"/>
                        <img id="imgPr" style="width: 80px; height: 80px; border-radius:250px; " src="/Images/face/lbxx.jpg" />
                </div>
                <div class="layui-input-inline">
                    <input type="text" name="card" required lay-verify="required"  placeholder="身份证号" class="layui-input">
                </div>
                <div class="layui-input-inline">
                    <input type="password" name="password1" id="password1" required lay-verify="required" placeholder="密码" class="layui-input">
                </div>
                <div class="layui-input-inline">
                    <input type="password" name="password2" id="password2" required lay-verify="required" placeholder="确认密码" onblur="checkpass()" class="layui-input">
                    <font id="passerror" style="color:red; float:right"></font>
                </div>
                <div class="layui-input-inline">
                    <input type="text" name="tel" required lay-verify="required" placeholder="联系电话" class="layui-input">
                </div>
                <div class="layui-input-inline">
                    <input type="text" name="qq"  placeholder="QQ" class="layui-input">
                </div>
                <div class="layui-input-inline">
                    <input type="text" name="email"   placeholder="邮箱" class="layui-input">
                </div>
                <%--<input type="hidden" name="credit" value="10"/>--%>
                <%--<input type="hidden" name="type" value="1"/>--%>

                <div class="layui-input-inline login-btn">
                    <p><a href="/Login.aspx" class="fl">已有账号?</a></p>
                    <button type="submit" class="layui-btn" style="background-color:#8cc051;" >注册</button>
                </div>
                <hr/>

            </form>
        </div>
    </div>


<script src="/MyAdmin/frame/layui/layui.js"></script>

<script type="text/javascript">
    layui.use(['form'], function () {

        // 操作对象
        var form = layui.form
                , $ = layui.jquery;

        // you code ...


    });
</script>

</body>
</html>

