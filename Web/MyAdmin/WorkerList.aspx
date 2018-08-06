<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkerList.aspx.cs" Inherits="myhouse.Web.MyAdmin.WorkerList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

<link href="frame/layui/css/layui.css" rel="stylesheet" />
<link href="frame/static/css/style.css" rel="stylesheet" />
<link href="frame/layui/css/bootstrap.min2.css" rel="stylesheet" />

<style>
        #d1 .layui-input, .layui-select{
            height:30px;
        }
        .fileLabel{
          display: inline-block;
          width:80px;
          height: 25px;
          text-align: center;
          border: 1px solid #8cc051;
          border-radius: 5px;
          background-color:dodgerblue;
          cursor: pointer;
          color:white;
        }
    </style>

<script src="/MyAdmin/js/jquery-1.11.1.js"></script>
<script src="/MyAdmin/frame/layui/layui.js"></script>
<script src="js/uploadPreview.min.js"></script>


<script>
    var url = parent.location.pathname;
    if (url != '/MyAdmin/Default.aspx') {
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

    //头像预览
    $(function () {
        $("#simg").uploadPreview({ Img: "imgPr", Width: 220, Height: 200 });
    });

    //检查两次密码是否一致
    function checkpass() {
        if ($("#newpass").val() != $("#newpass2").val()) {
            layer.msg('两次输入的密码不一致，请重新输入!', { icon: 5 });
            $("#newpass").focus();
        }
    }

    //添加员工信息
    function myadd()
    {
        layer.open({
            type: 1,
            title: '修改员工信息',
            area: ['800px', '500px'],
            offset: '20px',
            anim: 1,
            skin: "myclass",
            shade: 0.1,
            content: $("#updateworker")
        });


    }

    //修改员工信息
    function myupdate()
    {



        layer.open({
            type: 1,
            title: '修改员工信息',
            area: ['800px', '500px'],
            offset: '20px',
            anim: 1,
            skin: "myclass",
            shade: 0.1,
            content: $("#updateworker")
        });
    }

    //关闭弹出层
    function myclose() {
        resetValue();
        //layer.closeAll();
    };

    //清空弹出层form表单中的内容
    function resetValue() {
        $("#name").val("");
        $("#sex").val("");
        $("#card").val("");
        $("#newpass").val("");
        $("#newpass2").val("");
        $("#tel").val("");
        $("#email").val("");
        $("#adress").val("");
        $("#type").val("");
        $("#simg").attr("src", "/Images/House/wu.jpg");

        var form = layui.form;
        form.render();   //表单重新渲染
    }

</script>


</head>
<body>
    <fieldset class="layui-elem-field layui-field-title" style="margin-top: 10px;">
            <legend>员工信息管理</legend>
        </fieldset>
        <div style="text-align:left;height:30px; padding:0;" >        
            <form class="layui-form" action="/MyAdmin/WorkerList.aspx" method="post" style="height:30px;" id="d1">         
                <button class="layui-btn layui-btn-small layui-btn-danger" type="button" style="float:left;" onclick="deletelist()"><i class="layui-icon">&#xe640;</i>批量删除</button>&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="text" name="hname" id="hname" value="" placeholder="请输入员工姓名" autocomplete="off" class="layui-input" style="height:30px;width:130px; margin-left:20px; float:left;" /> 
                <div class="layui-inline" style="height:30px; width:120px;" >
                    <div class="layui-input-inline" >
                        <select name="sid">
                            <option value="">所有权限</option>
                            <option value="0">权限一</option>
                            <option value="1">权限二</option>
                            <option value="2">权限三</option>
                        </select>
                    </div>
                </div>
                <div class="layui-inline" style="height:30px; width:120px; margin-right:10px;" >
                    <div class="layui-input-inline" >
                        <select name="order">
                            <option value=""  >全部人员</option>
                            <option value="0"  >管理员</option>
                            <option value="1"  >员工</option>
                        </select>
                    </div>
                </div>
                <button id="search" type="submit" class="layui-btn layui-btn-small layui-btn-normal " ><i class="layui-icon">&#xe615;</i>查询</button>
                <button type="button" class="layui-btn layui-btn-small layui-btn-normal" onclick="window.location='/MyAdmin/WorkerList.aspx'"><i class="layui-icon">&#x1002;</i>刷新</button>
                <button id="add" type="button" class="layui-btn layui-btn-small layui-btn-normal" onclick="myadd()" ><i class="layui-icon">&#xe61f;</i>添加员工</button>
                <input type="text" value="权限一:仅审核 | 权限二:审核+修改 | 权限三:审核+修改+删除" disabled="disabled"  class="layui-input" style="height:30px;width:380px; float:right; border:none; border-bottom:1px solid;" /> 
            </form>     
        </div>

        <table class="layui-table" lay-even="" lay-skin="nob">
            <thead>
            <tr style="text-align:center;">
                <th></th>
                <th>员工编号</th>
		        <th>姓名</th>
		        <th>性别</th>
                <th>身份证号</th>
		        <th>联系电话</th>
                <th>邮箱</th>
		        <th>地址</th>  
		        <th>头像</th>
		        <th>权限一</th>
                <th>权限二</th>
                <th>权限三</th>
                <th style="text-align:center;">操作</th>
            </tr>
            </thead>
            <tbody>
                <% 
                
                 {%>        
                    <tr >
                        <td><input type="checkbox" name="check" value=""/></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td style="padding:4px; text-align:center;">
                            <img alt="" src="" style="width: 80px; height: 80px; border-radius:2px;">
                        </td>
                        <%--<%
                            if (house.hmode == 1){%>
                                <td style="color:limegreen">已出租</td>
                            <%}
                            else {%>
                                <td style="color:orangered">未出租</td>
                            <%}
                        %>
                        <%
                            if (house.hstatus == 1){%>
                                <td style="color:limegreen">已审核</td>
                            <%}
                            else if(house.hstatus == 0) {%>
                                <td style="color:dodgerblue">待审核</td>
                            <%}
                            else if(house.hstatus == 2){%>
                                <td style="color:orangered">不合法</td>
                            <%}
                        %>--%>

                        <td style="text-align:center; padding:0;">
                             <button id="myupdate" class="layui-btn layui-btn-small layui-btn-normal" style="margin-bottom:4px;" onclick="myupdate()">修改</button><br />
                             <button class="layui-btn layui-btn-small layui-btn-danger" onclick="mydelete()">删除</button>                       
                        </td>
                    </tr>
                <%}
                  %>
            </tbody>
        </table>
        <div class="pagination alternate" style="text-align:center;">
			<ul class="clearfix">
                 <%--<%=pageCode %>--%>
			</ul>
		</div>

        <%--弹出层，修改员工信息与权限--%>
        <div id="updateworker" class="layui-elem-field layui-field-title" style="display:none;">
            <div class="layui-col-md10" style="padding-right:0px;">
                <form class="layui-form layui-form-pane" id="fm" runat="server" enctype="multipart/form-data">
                     <div class="layui-form-item">
                        <div class="layui-input-block" style="width:200px; margin-left:46%;">
                            <input type="file" name="photo" id="simg" style="display:none;"/>
                            <img id="imgPr" style="width: 80px; height: 80px; border-radius:50%; " src="" /><br /><br />
                            <label class="fileLabel" for="simg">选择头像</label>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">姓名</label>
                        <div class="layui-input-block">
                            <input type="text" name="name" id="name" lay-verify="required" autocomplete="off" value="" class="layui-input" />
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">性别</label>
                        <div class="layui-input-block">
                            <select name="sex" id="sex">
                                <option value="男"  >男</option>
                                <option value="女"  >女</option>
                            </select>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">身份证号</label>
                        <div class="layui-input-block">
                            <input type="text" name="card" id="card"  autocomplete="off" value="" class="layui-input"/>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">新密码</label>

                        <div class="layui-input-block">
                            <input type="password" name="newpass" id="newpass" placeholder="需要更改则输入，否则无需输入..." autocomplete="off" value="" class="layui-input"/>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">确认新密码</label>

                        <div class="layui-input-block">
                            <input type="password" name="newpass2" id="newpass2" onblur="checkpass()" placeholder="需要更改则输入，否则无需输入..." autocomplete="off" value="" class="layui-input"/>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">联系电话</label>

                        <div class="layui-input-block">
                            <input type="text" name="tel" id="tel" autocomplete="off" value=""class="layui-input"/>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">邮箱</label>

                        <div class="layui-input-block">
                            <input type="text" name="email" id="email" autocomplete="off" value=""class="layui-input"/>
                        </div>
                    </div>
                     <div class="layui-form-item">
                        <label class="layui-form-label">家庭住址</label>

                        <div class="layui-input-block">
                            <input type="text" name="adress" id="adress" autocomplete="off" value=""class="layui-input"/>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">员工权限</label>
                        <div class="layui-input-block">
                            <select name="type" id="type" >
                                <option value="0">权限一（仅审核)</option>
                                <option value="1">权限二（审核+修改）</option>
                                <option value="2">权限三（审核+修改+删除）</option>
                            </select>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">开关-默认关</label>
                        <div class="layui-input-block">
                            <input type="checkbox" name="close" lay-skin="switch" lay-text="ON|OFF"/>
                        </div>
                    </div>
                    <div class="layui-form-item" style="padding-left:110px;">
                        <input type="button" class="layui-btn layui-btn-danger" style="border-radius:10px" onclick="myclose()" value="取消" />
                        <input type="button" style="float:right; border-radius:10px" class="layui-btn layui-btn-normal" onclick="mysave()" value="保存"/>
                    </div>
                </form>
            </div>
        </div> 

</body>
</html>
