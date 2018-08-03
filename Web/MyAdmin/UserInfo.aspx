<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="myhouse.Web.MyAdmin.UserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="frame/layui/css/layui.css" rel="stylesheet" />
    <link href="frame/static/css/style.css" rel="stylesheet" />

    <style>
         #d1 .layui-input, .layui-select{
            height:30px;
        }
    </style>

    <script src="/MyAdmin/frame/layui/layui.js"></script>
    <script src="/MyAdmin/js/jquery-1.11.1.js"></script>
    <script src="/MyAdmin/My97DatePicker/WdatePicker.js"></script>   <%--时间选择器--%>

    <%--判断是否在框架（/MyAdmin/Default.aspx）中打开--%>
    <script>
        var url = parent.location.pathname;
        if(url != '/MyAdmin/Default.aspx')
        {
            window.location.href = "/MyAdmin/AdminLogin.aspx";
        }

        //在 layui 中使用 layer  打开弹出层！！！
        layui.use('layer', function () {
            var layer = layui.layer;
        });

        //layui中下拉框不显示，需要声明该表单
        layui.use('form', function () {
            var form = layui.form;
            form.render();
        });

    </script>

</head>
<body>
    
        <fieldset class="layui-elem-field layui-field-title" style="margin-top: 10px;">
            <legend>用户信息管理</legend>
        </fieldset>
        <div style="text-align:left;height:30px; padding:0;" >        
            <form class="layui-form" runat="server" style="height:30px;" id="d1">
                <button class="layui-btn layui-btn-small layui-btn-danger" type="button" style="float:left;" onclick="deletelist()"><i class="layui-icon">&#xe640;</i>批量删除</button>&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="text" name="hname" id="uname" value="" placeholder="请输入用户昵称或姓名" autocomplete="off" class="layui-input" style="height:30px;width:155px; margin-left:20px; float:left;" /> 
                <div class="layui-inline" style="height:30px; width:150px;" >
                    <div class="layui-input-inline" >
                        <select name="utype">
                            <option value="">请选择用户类型</option>
                            <option value="0">待审核</option>
                            <option value="1">租赁者</option>
                            <option value="2">房主</option>
                        </select>
                    </div>
                </div>
                <div class="layui-inline" style="height:30px; width:150px;">
                    <div class="layui-input-inline">      
                        <input type="text" name="starttime" value="" onclick="WdatePicker()" placeholder="请选择起始时间"  style="height:28px;width:120px;text-align:center; margin-left:18px;border: 1px solid #e6e6e6" /> 
                    </div>
                </div>
                <div class="layui-inline" style="height:30px; width:150px;">
                    <div class="layui-input-inline">      
                        <input type="text" name="endtime" value="" onclick="WdatePicker()" placeholder="请选择结束时间"  style="height:28px;width:120px;text-align:center; margin-left:4px;border: 1px solid #e6e6e6" /> 
                    </div>
                </div>
                <button id="search" type="submit" class="layui-btn layui-btn-small layui-btn-normal " >查询用户</button>
            </form>     
        </div>
        <table class="layui-table" lay-even="" lay-skin="nob">
            <colgroup>
            </colgroup>
            <thead>
            <tr>
                <th></th>
                <th>昵称</th>
		        <th>真实姓名</th>
		        <th>性别</th>
		        <th>头像</th>
		        <th>注册时间</th>
		        <th>邮箱</th>
		        <th>联系电话</th>
		        <th>用户类型</th>
                <th style="text-align:center;">操作</th>
            </tr>
            </thead>
            <tbody>
                <tr style="text-align:center;">
                    <td><input type="checkbox" name="check" value=""/></td>
                    <td>贤心</td>
                    <td>66</td>
                    <td>男</td>
                    <td style="padding:4px; text-align:center;">
                        <img alt="" src="/images/face/lbxx.jpg" style="width: 60px; height: 60px; border-radius:250px;">
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td colspan="2" style="text-align:center;">
                        <button class="layui-btn layui-btn-small layui-btn-normal">修改</button>
                        <button class="layui-btn layui-btn-small layui-btn-danger ">删除</button>
                    </td>
                </tr>
            </tbody>
        </table>
</body>
</html>
