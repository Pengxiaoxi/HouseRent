<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="myhouse.Web.UserInfo" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="renderer" content="webkit">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <title>用户信息修改</title>
    <link rel="stylesheet" href="/MyAdmin/frame/layui/css/layui.css">
    <link rel="stylesheet" href="/MyAdmin/frame/static/css/style.css">
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

        //返回上一级
        function myback() {

            window.history.go(-1);

            //if (history.length > 0) {
            //    window.history.go(-1);
            //}
            //else {
            //    window.location.href = "/Index.aspx";
            //}
        }
    </script>

</head>

   <%
       if (Session["userInfo"] == null)
       {%>
            <script>
                //alert("您还未登录！")

                if (confirm("现在去登录?")) {
                    window.location.href = "/Login.aspx";
                }
                else {
                    window.location.href = "/Index.aspx";

                }
            </script>; 
     
       <%
               return;
           }
         %>

<body>
    <div>
        <div class="login-main">
            <header class="layui-elip" style="margin-top:30px; color:#D7532a; font-weight:bold;">个人信息</header>
            <p><a href="#" onclick="myback()" class="fl" style="float:right;color:#8cc051;">我不想修改了</a></p>
            <form class="layui-form" runat="server" enctype="multipart/form-data">  <%--文件上传--%>
                <div class="layui-input-inline">
                    <span>昵称:</span>
                    <input type="text" id="nickname" name="nickname" required lay-verify="required"  placeholder="昵称" disabled="disabled" value="<%=((myhouse.Model.User)Session["userInfo"]).unickname %>"  class="layui-input" onblur="checknickname(this.value)">
                    <font id="userErrorInfo1" style="color:red; float:right"></font>
                    <font id="userErrorInfo2" style="color:green; float:right;"></font>
                </div>
                <div class="layui-input-inline">
                    <span>姓名:</span>
                    <input type="text" name="name" required lay-verify="required"  placeholder="姓名" value="<%=((myhouse.Model.User)Session["userInfo"]).uname %>"  class="layui-input">
                </div>
                <div class="layui-select">
                    <%--<input type="text" name="sex" required lay-verify="required"  placeholder="性别"  class="layui-input">--%>      
                    <label style="display:inline-block; width:130px;">身份</label>  
                    <label style="display:inline-block; margin-right:0px;">
                        <select name="type" >

                            <%--需要被审核才能成为房主，0表示未审核
                                是房主则不需要在进行审核，但修改成为租赁者则需要审核即htype为0
                                --%>
                            <%
                                if (((myhouse.Model.User)Session["userInfo"]).utype == "2   ")  
                                {%>
                                    <option value="2   " <%= utype == "2   " ? "selected" : "" %> >房主</option>
                                    <option value="1   " <%= utype == "1   " ? "selected" : "" %> >租赁者</option> 
                                <%}
                                else 
                                {%>
                                    <option value="1   " <%= utype == "1   " ? "selected" : "" %> >租赁者</option>    
                                    <option value="0   " <%= utype == "0   " ? "selected" : "" %> >房主</option>
                                <%}
                            %>         
                        </select>
                    </label> 
                </div>

                <div class="layui-select">
                    <%--<input type="text" name="sex" required lay-verify="required"  placeholder="性别"  class="layui-input">--%>        
                    <label style="display:inline-block; width:130px;">性别</label>  
                    <label style="display:inline-block; margin-right:0px;">
                        <select name="sex" >
                            <%--<option value="">请选择...</option>--%>
                            <option value="男" <%= sex == "男" ? "selected" : ""%>>男</option>
                            <option value="女" <%=sex == "女" ? "selected" : ""%>>女</option>
                        </select>
                    </label> 
                </div>

                <div class="layui-input-inline"> 
                    <label class="fileLabel" for="simg" >选择头像</label>            
                        <input type="file" name="photo" id="simg" style="display:none;"/>
                        <img id="imgPr" style="width: 80px; height: 80px; border-radius:250px; " src="<%=((myhouse.Model.User)Session["userInfo"]).uphoto %>" />
                </div>
                <div class="layui-input-inline">
                    <span>身份证号:</span>  
                    <input type="text" name="card" required lay-verify="required"  placeholder="身份证号" value="<%=((myhouse.Model.User)Session["userInfo"]).ucard %>" class="layui-input">
                </div>
                <div class="layui-input-inline">
                    <input type="password" name="password1" id="password1"  placeholder="新密码...(不修改则不需要输入)"  class="layui-input">
                </div>
                <div class="layui-input-inline">
                    <input type="password" name="password2" id="password2"  placeholder="确认新密码...(不修改则不需要输入)" onblur="checkpass()" class="layui-input">
                    <font id="passerror" style="color:red; float:right"></font>
                </div>
                <div class="layui-input-inline">
                    <span>联系方式:</span> 
                    <input type="text" name="tel" required lay-verify="required" placeholder="联系电话" value="<%=((myhouse.Model.User)Session["userInfo"]).utel %>" class="layui-input">
                </div>
                <div class="layui-input-inline">
                    <span>QQ:</span> 
                    <input type="text" name="qq"  placeholder="QQ" value="<%=((myhouse.Model.User)Session["userInfo"]).uqq %>" class="layui-input">
                </div>
                <div class="layui-input-inline">
                    <span>邮箱:</span> 
                    <input type="text" name="email"   placeholder="邮箱" value="<%=((myhouse.Model.User)Session["userInfo"]).uemail %>" class="layui-input">
                </div>
                <%--<input type="hidden" name="credit" value="10"/>--%>
                <%--<input type="hidden" name="type" value="1"/>--%>

                <div class="layui-input-inline login-btn">
                    <%--<p><a href="/Login.aspx" class="fl">已有账号?</a></p>--%>
                    <p style=" text-align:center; color:red;font-size:12px;"><%=ErrorMsg %></p>
                    <button type="submit" class="layui-btn" style="background-color:#8cc051;" >保存修改</button>
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
