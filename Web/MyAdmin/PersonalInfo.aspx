<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonalInfo.aspx.cs" Inherits="myhouse.Web.MyAdmin.PersonalInfo" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="renderer" content="webkit">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <title></title>
    <link rel="stylesheet" href="/MyAdmin/frame/layui/css/layui.css">
    <link rel="stylesheet" href="/MyAdmin/frame/static/css/style.css">

<style type="text/css">

html,body{margin:0;
          padding:0;
          overflow-x:hidden
}
        .fileLabel{
          display: inline-block;
          width:80px;
          height: 30px;
          text-align: center;
          border: 1px solid #8cc051;
          border-radius: 5px;
          background-color:#009688;
          cursor: pointer;
          color:white;
        }
</style>
    <script src="js/jquery-1.11.1.js"></script>
    <script src="js/uploadPreview.min.js"></script>

    <%--判断是否在框架（/MyAdmin/Default.aspx）中打开--%>
    <script>
        var url = parent.location.pathname;
        if(url != '/MyAdmin/Default.aspx')
        {
            window.location.href = "/MyAdmin/AdminLogin.aspx";
        }

    </script>

<script>
    //头像预览
    $(function () {
        $("#simg").uploadPreview({ Img: "imgPr", Width: 220, Height: 200 });
    });

    //检查两次密码是否一致
    function checkpass()
    { 
        if ($("#newpass").val() != $("#newpass2").val())
        {
            layer.msg('两次输入的密码不一致，请重新输入!', { icon: 5 });
            $("#newpass").focus();
        }
    }

    //jQuery ajax提交form表单    此种方法无法传递文件！！！
    //function save()
    //{
    //    $.post("/MyAdmin/PersonalInfo.aspx", $("#fm").serialize(), function (result) {
    //        if (result) {
    //            layer.msg('个人信息修改成功!', { icon: 1 });
    //            setTimeout("window.location.reload(true)", 600);
    //        }
    //        else {
    //            layer.msg('个人信息修改失败!', { icon: 5 })
    //        }
    //    }, "text")
    //}

    //ajax提交form表单  可以提交文件
    function save() {
        //var form = $("#fm");
        var form = document.getElementById('fm');
        var formData = new FormData(form);
        //alert(formData);

        $.ajax({
            type: "POST",
            url: "/MyAdmin/PersonalInfo.aspx",
            data: formData,
            async: false,
            cache: false,
            contentType: false,
            processData: false,
            success: function (msg) {
                if (msg) {
                    layer.msg('个人信息修改成功!', { icon: 1 });
                    setTimeout("window.location.reload(true)", 600);
                }
                else {
                    layer.msg('个人信息修改失败!', { icon: 5 })
                }
            }
        });
    }

</script>

</head>
<body class="body">

    <%--<%
        if (Session["adminInfo"] == null)
        {%>
            <script>
                layer.alert('登录过期！请重新登录...', { icon: 1 });
                setTimeout("window.location.href = '/MyAdmin/AdminLogin.aspx'", 800);
            </script>
        <%}
        else
        {%>
            
        <%}
    %>--%>

<form class="layui-form layui-form-pane" id="fm" runat="server" enctype="multipart/form-data">
     <div class="layui-form-item">
        <div class="layui-input-block" style="left:36%;">
            <input type="file" name="photo" id="simg" style="display:none;"/>
            <img id="imgPr" style="width: 80px; height: 80px; border-radius:50%; " src="<%=((myhouse.Model.Worker)Session["adminInfo"]).wphoto %>" /><br /><br />
            <label class="fileLabel" for="simg">选择头像</label>
        </div>
    </div>
    <div class="layui-form-item">
        <label class="layui-form-label">姓名</label>

        <div class="layui-input-block">
            <input type="text" name="name" lay-verify="required" disabled="disabled" autocomplete="off" value="<%=((myhouse.Model.Worker)Session["adminInfo"]).wname %>"
                   class="layui-input" >
        </div>
    </div>
    <div class="layui-form-item">
        <label class="layui-form-label">性别</label>
        <div class="layui-input-block">
            <select name="sex" >
                <option value="男" <%=((myhouse.Model.Worker)Session["adminInfo"]).wsex == "男" ? "selected" : "" %> >男</option>
                <option value="女" <%=((myhouse.Model.Worker)Session["adminInfo"]).wsex == "女" ? "selected" : "" %> >女</option>
            </select>
        </div>
    </div>
    <div class="layui-form-item">
        <label class="layui-form-label">身份证号</label>
        <div class="layui-input-block">
            <input type="text" name="card" required lay-verify="required" autocomplete="off" value="<%=((myhouse.Model.Worker)Session["adminInfo"]).wcard %>"
                   class="layui-input">
        </div>
    </div>
<%--    <div class="layui-form-item">
        <label class="layui-form-label">输入旧密码</label>

        <div class="layui-input-block">
            <input type="password" name="oldpass" autocomplete="off" value=""
                   class="layui-input">
        </div>
    </div>--%>
    <div class="layui-form-item">
        <label class="layui-form-label">新密码</label>

        <div class="layui-input-block">
            <input type="password" name="newpass" id="newpass" placeholder="需要更改则输入，否则无需输入..." autocomplete="off" value=""
                   class="layui-input">
        </div>
    </div>
    <div class="layui-form-item">
        <label class="layui-form-label">确认新密码</label>

        <div class="layui-input-block">
            <input type="password" name="newpass2" id="newpass2" onblur="checkpass()" placeholder="需要更改则输入，否则无需输入..." autocomplete="off" value=""
                   class="layui-input">
        </div>
    </div>
    <div class="layui-form-item">
        <label class="layui-form-label">联系电话</label>

        <div class="layui-input-block">
            <input type="text" name="tel" required lay-verify="required" autocomplete="off" value="<%=((myhouse.Model.Worker)Session["adminInfo"]).wtel %>"
                   class="layui-input">
        </div>
    </div>
    <div class="layui-form-item">
        <label class="layui-form-label">邮箱</label>

        <div class="layui-input-block">
            <input type="text" name="email" autocomplete="off" value="<%=((myhouse.Model.Worker)Session["adminInfo"]).wemail %>"
                   class="layui-input">
        </div>
    </div>
     <div class="layui-form-item">
        <label class="layui-form-label">家庭住址</label>

        <div class="layui-input-block">
            <input type="text" name="adress" required lay-verify="required" autocomplete="off" value="<%=((myhouse.Model.Worker)Session["adminInfo"]).wadress %>"
                   class="layui-input">
        </div>
    </div>
    <div class="layui-form-item" style="text-align:center;">
        <button class="layui-btn" type="button" style="border-radius:10px;" onclick="save()" >保存信息</button>
    </div>
</form>

<script src="/MyAdmin/frame/layui/layui.js" charset="utf-8"></script>

<script type="text/javascript">
    layui.use(['form', 'layedit', 'laydate', 'element'], function () {
        var form = layui.form
                , layer = layui.layer
                , layedit = layui.layedit
                , laydate = layui.laydate
                , element = layui.element;
    });
</script>
</body>
</html>
