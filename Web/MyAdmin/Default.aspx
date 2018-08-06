<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="myhouse.Web.MyAdmin.Default" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="renderer" content="webkit">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <title>房屋租赁管理系统后台管理</title>
    <link rel="stylesheet" href="frame/layui/css/layui.css">
    <link rel="stylesheet" href="./frame/static/css/style.css">
    <link rel="icon" href="/img/house.jpg"/>
</head>
<body>

<!-- layout admin -->
<div class="layui-layout layui-layout-admin"> <!-- 添加skin-1类可手动修改主题为纯白，添加skin-2类可手动修改主题为蓝白 -->
    <!-- header -->
    <div class="layui-header my-header">
        
        <div class="my-header-btn">
            <button class="layui-btn layui-btn-small btn-nav" style="background-color:limegreen; "><i class="layui-icon">&#xe65f;</i></button>
        </div>
        <a href="#">
            <!--<img class="my-header-logo" src="" alt="logo">-->
            <div class="my-header-logo">房屋租赁管理系统后台</div>
        </a>

        <!-- 顶部右侧添加选项卡监听 -->
        <ul class="layui-nav my-header-user-nav" lay-filter="side-top-right">
            <%--<li class="layui-nav-item"><a href="javascript:;" class="pay" href-url="">支持作者</a></li>--%>
            <li class="layui-nav-item">
                <a class="name" href="javascript:;"><i class="layui-icon">&#xe629;</i>主题</a>
                <dl class="layui-nav-child">
                    <dd data-skin="0"><a href="javascript:;">默认</a></dd>
                    <dd data-skin="1"><a href="javascript:;">纯白</a></dd>
                    <dd data-skin="2"><a href="javascript:;">蓝白</a></dd>
                </dl>
            </li>
            <li class="layui-nav-item">
                <a href="/MyAdmin/PersonalInfo.aspx?wid=" target="iframe" class="name"><img src="<%=((myhouse.Model.Worker)Session["adminInfo"]).wphoto %>" style="border-radius:50%;" alt="logo">&nbsp;
                    <% 
                        if (((myhouse.Model.Worker)Session["adminInfo"]).wtype == "8   " )
                        {%>
                            <font style="color:orangered;">【管理员】
                                &nbsp;
                                <%=((myhouse.Model.Worker)Session["adminInfo"]).wname %>
                            </font>
                        <%}
                        else
                        {%>
                            
                            <font style="color:limegreen;">【员工】
                                &nbsp;
                                <%=((myhouse.Model.Worker)Session["adminInfo"]).wname %>
                            </font>
                            
                        <%}
                    %>                  
                </a>
                <dl class="layui-nav-child">
                    <dd><a href="/MyAdmin/AdminLoginout.ashx"><i class="layui-icon">&#x1006;</i>安全退出</a></dd>
                </dl>
            </li>
            <%--<li>
                <form class="layui-form">
                    <div class="layui-form-item">
                        <label class="layui-form-label">开关-默认开</label>
                        <div class="layui-input-block">
                            <input type="checkbox" checked="" name="open" lay-skin="switch" lay-filter="switchTest" lay-text="ON|OFF">
                        </div>
                    </div>
                 </form>
            </li>--%>
        </ul>

    </div>
    <!-- side -->

    <div class="layui-side my-side">
        <div class="layui-side-scroll">
            
            <ul class="layui-nav layui-nav-tree" >    <%--lay-filter="side-main"--%>

                <%
                    foreach (myhouse.Model.Menus menu in menuList)
                    {%>
                        <li class="layui-nav-item  layui-nav-itemed">
                            <a href="<%=menu.murl %>" target="iframe"><i class="layui-icon">&#xe620;</i><%=menu.mname %></a>  <%--在框架中打开--%>
                        </li>
                    <%}
                %>
            </ul>

        </div>
    </div>

    <!-- body -->  <%--iframe 元素会创建包含另外一个文档的内联框架（即行内框架）。--%>
    <div class="layui-body my-body">
         <div class="layui-tab layui-tab-card my-tab" lay-filter="card" lay-allowClose="true">
            <div class="layui-tab-content">
                <div class="layui-tab-item layui-show">
                    <iframe id="iframe" src="/MyAdmin/AdminIndex.aspx" frameborder="0" name="iframe"></iframe>
                </div>
            </div>
        </div>
    </div>
    <!-- body -->

    <!-- footer -->
    <div class="layui-footer my-footer">
        <p style="margin-top:10px;">Copyright © 2018-7 <a href="https://github.com/Pengxiaoxi">Pengxiaoxi</a> Inc.  All rights reserved</p>
    </div>
    <!-- footer -->

</div>

<!-- pay -->
<%--<div class="my-pay-box none">
    <div><img src="./frame/static/image/zfb.png" alt="支付宝"><p>支付宝</p></div>
    <div><img src="./frame/static/image/wx.png" alt="微信"><p>微信</p></div>
</div>--%>


<script type="text/javascript" src="frame/layui/layui.js"></script>
<script type="text/javascript" src="./frame/static/js/vip_comm.js"></script>

<%--<script type="text/javascript">
layui.use(['layer','vip_nav'], function () {

    // 操作对象
    var layer       = layui.layer
        ,vipNav     = layui.vip_nav
        ,$          = layui.jquery;

    // 顶部左侧菜单生成 [请求地址,过滤ID,是否展开,携带参数]
    vipNav.top_left('./json/nav_top_left.json','side-top-left',false);
    // 主体菜单生成 [请求地址,过滤ID,是否展开,携带参数]
    vipNav.main('./json/nav_main.json','side-main',true);

    // you code ...


});
</script>--%>
</body>
</html>