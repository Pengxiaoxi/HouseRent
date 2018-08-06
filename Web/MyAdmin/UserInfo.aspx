<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="myhouse.Web.MyAdmin.UserInfo" %>

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

    <script src="/MyAdmin/frame/layui/layui.js"></script>
    <script src="/MyAdmin/js/jquery-1.11.1.js"></script>
    <script src="js/uploadPreview.min.js"></script>
    <script src="/MyAdmin/My97DatePicker/WdatePicker.js"></script>

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

        //用户信息的修改
        function myupdate(uid, photo1, nickname, name, card, sex, regtime, email, qq, tel, type) {
            $("#uid").val(uid);
            $("#imgPr1").attr("src", photo1);
            $("#nickname").val(nickname);
            $("#name").val(name);
            $("#card").val(card);
            $("#sex").val(sex);
            $("#regtime").val(regtime);
            $("#email").val(email);
            $("#qq").val(qq);
            $("#tel").val(tel);
            $("#type").val(type);

            //赋值后重新渲染
            var form = layui.form;
            form.render();  

            layer.open({
                type: 1,
                title: '修改用户信息',
                area: ['800px', '500px'],
                offset: '20px',
                anim: 1,
                skin: "myclass",
                shade: 0.1,
                content: $("#updatehouse")
            });
        }

        //用户信息的保存
        function mysave() {
            var form = document.getElementById('fm');
            var formData = new FormData(form);
            //alert(formData);

            $.ajax({
                type: "POST",
                url: "/MyAdmin/UserInfo.aspx?flag=update",
                data: formData,
                async: false,
                cache: false,
                contentType: false,
                processData: false,
                success: function (msg) {
                    if (msg) {
                        layer.msg('该用户信息修改成功!', { icon: 1 });
                        setTimeout("window.location.reload(true)", 600);
                    }
                    else {
                        layer.msg('用户信息修改失败!', { icon: 5 })
                    }
                }
            });
        };

        //用户信息的单个删除
        function mydelete(uid) {
            layer.confirm('您确定要删除此用户及其发布所有房屋的信息吗?', { icon: 3, title: '提示' }, function (index) {
                $.post("/MyAdmin/UserInfo.aspx?flag=delete", { uid: uid }, function (result) {
                    if (result) {
                        layer.msg('有关此用户的所有信息删除成功!', { icon: 1 });
                        setTimeout("location.reload(true)", 800);
                    } else {
                        layer.msg('删除失败...', { icon: 5 });
                    }
                }, "text");
            });
        }

        //房屋信息批量删除
        function deletelist() {
            //获取勾选的check的值
            var idlist = new Array();
            $('input[name="check"]:checked').each(function () {
                idlist.push($(this).val());//向数组中添加元素  
            });

            if (idlist.length == 0) {
                layer.alert('请先选择需要删除的用户!', { icon: 5 });
                return;
            }
            var ids = idlist.join(',');//将数组元素连接起来以构建一个字符串

            layer.confirm('您确定要删除这' + idlist.length + '个用户及其发布的房屋的所有信息吗?', { icon: 3, title: '提示' }, function (index) {
                $.post("/MyAdmin/UserInfo.aspx?flag=deletelist", { ids: ids }, function (result) {
                    if (result) {
                        layer.msg('删除成功!', { icon: 1 });
                        setTimeout('window.location.reload(true)', 800);
                    }
                    else {
                        layer.msg('删除失败...', { icon: 5 });
                    }
                }, "text");
            });
        }

        //关闭弹出层
        function myclose() {
            resetValue();
            layer.closeAll();
        };

        //清空弹出层form表单中的内容
        function resetValue() {
            $("#uid").val("");
            $("#imgPr1").attr("src", "/Images/House/wu.jpg");
            $("#nickname").val("");
            $("#name").val("");
            $("#card").val("");
            $("#sex").val("");
            $("#regtime").val("");
            $("#email").val("");
            $("#qq").val("");
            $("#tel").val("");
            $("#pass").val("");
            $("#type").val("");

            //赋值后重新渲染
            var form = layui.form;
            form.render();
        };

        //图片预览
        $(function () {
            $("#simg1").uploadPreview({ Img: "imgPr1", Width: 220, Height: 200 });
        });

        //提醒选择时间时结束时间要大于起始时间
        function checktime() {
            if ($("#starttime").val() > $("#endtime").val()) {
                layer.msg('结束时间必须大于起始时间!', { icon: 5 });
            }
        };

        //图片预览
        $(function () {
            $("#simg1").uploadPreview({ Img: "imgPr1", Width: 220, Height: 200 });
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
                <input type="text" name="unickname" id="unickname" value="<%=unickname %>" placeholder="请输入用户昵称" autocomplete="off" class="layui-input" style="height:30px;width:155px; margin-left:20px; float:left;" /> 
                <div class="layui-inline" style="height:30px; width:150px;" >
                    <div class="layui-input-inline" >
                        <select name="utype">
                            <option value="">请选择用户类型</option>
                            <option value="0" <%=utype == "0" ? "selected" : "" %> >待审核</option>
                            <option value="1" <%=utype == "1" ? "selected" : "" %> >租赁者</option>
                            <option value="2" <%=utype == "2" ? "selected" : "" %> >房主</option>
                        </select>
                    </div>
                </div>
                <div class="layui-inline" style="height:30px; width:150px;">
                    <div class="layui-input-inline">      
                        <input type="text" name="starttime" id="starttime" value="<%=starttime %>" onclick="WdatePicker()" placeholder="请选择起始时间"  style="height:28px;width:120px;text-align:center; margin-left:18px;border: 1px solid #e6e6e6" /> 
                    </div>
                </div>
                <div class="layui-inline" style="height:30px; width:150px;">
                    <div class="layui-input-inline">      
                        <input type="text" name="endtime" id="endtime" value="<%=endtime %>" onclick="WdatePicker()" onblur="checktime()" placeholder="请选择结束时间"  style="height:28px;width:120px;text-align:center; margin-left:4px;border: 1px solid #e6e6e6" /> 
                    </div>
                </div>
                <div class="layui-inline" style="height:30px; width:150px;">
                    <div class="layui-input-inline" >
                        <select name="order">
                            <option value="0" <%=order == "0" ? "selected" : "" %> >最新注册</option>
                            <option value="1" <%=order == "1" ? "selected" : "" %> >最早注册</option>
                        </select>
                    </div>
                </div>
                <button id="search" type="submit" class="layui-btn layui-btn-small layui-btn-normal " >查询用户</button>
                <button type="button" class="layui-btn layui-btn-small layui-btn-normal" onclick="window.location='/MyAdmin/UserInfo.aspx'"><i class="layui-icon">&#x1002;</i>刷新</button>
            </form>     
        </div>
        <table class="layui-table" lay-even="" lay-skin="nob">
            <colgroup>
            </colgroup>
            <thead>
            <tr>
                <th></th>
                <%--<th>ID</th>--%>
                <th>昵称</th>
		        <th>姓名</th>
                <th>身份证号</th>
		        <th>性别</th>
		        <th>头像</th>
		        <th>注册时间</th>
                <th>QQ</th>
		        <th>邮箱</th>
		        <th>电话</th>
                <th>发布数</th>
                <th>收藏数</th>
		        <th>类型</th>
                <th style="text-align:center;">操作</th>
            </tr>
            </thead>
            <tbody>
                <% 
                  foreach (myhouse.Model.User user in userList)
                  {%>
                    <tr>
                        <td><input type="checkbox" name="check" value="<%=user.uid %>"/></td>
                        <%--<td><%=user.uid %></td>--%>
                        <td><%=user.unickname %></td>
                        <td><%=user.uname %></td>
                        <td><%=user.ucard %></td>
                        <td><%=user.usex %></td>
                        <td style="padding:4px; text-align:center;">
                            <img alt="" src="<%=user.uphoto %>" style="width: 60px; height: 60px; border-radius:250px;"/>
                        </td>
                        <td><%=user.uregtime %></td>
                        <td><%=user.uqq %></td>
                        <td><%=user.uemail %></td>
                        <td><%=user.utel %></td>
                        <td><%=user.publishernumber %></td>
                        <td><%=user.collectnumber %></td>
                        <%
                            if (user.utype == "0   ")
                            {
                                Response.Write("<td style='color:green'>待审核</td>");
                            }
                            else if (user.utype == "1   ")
                            {
                                Response.Write("<td style='color:dodgerblue'>租赁者</td>");
                            }
                            else if (user.utype == "2   ")
                            {
                                Response.Write("<td style='color:orangered'>房主</td>");
                            }
                            else {
                                Response.Write("<td>未知</td>");
                            }
                        %>
                        <td colspan="2" style="text-align:center;">
                            <button class="layui-btn layui-btn-small layui-btn-normal" style="margin-bottom:4px;" type="button" onclick="myupdate(<%=user.uid %>, '<%=user.uphoto %>', '<%=user.unickname %>', '<%=user.uname %>', '<%=user.ucard %>',  '<%=user.usex %>', '<%=user.uregtime %>', '<%=user.uemail %>', '<%=user.uqq %>', '<%=user.utel %>', <%=user.utype %>)">修改</button><br />
                            <button class="layui-btn layui-btn-small layui-btn-danger" type="button" onclick="mydelete(<%=user.uid %>)">删除</button>
                        </td>
                    </tr>
                <%}
                %>
            </tbody>
        </table>
        <div class="pagination alternate" style="text-align:center;">
			<ul class="clearfix">
                 <%=pageCode %>
			</ul>
		</div>

     <%--弹出层，修改用户信息--%>
        <div id="updatehouse" class="layui-elem-field layui-field-title" style="display:none;">
            <div class="layui-col-md10" style="padding-right:0px;">
                <form class="layui-form layui-form-pane" id="fm" action="/MyAdmin/UserInfo.aspx" method="post" enctype="multipart/form-data">
                    <input type="hidden" id="uid" name="uid" value=""/>

                    <div class="layui-form-item" >
                        <div class="layui-input-block" style="text-align:center; margin-top:10px;" >
                            <input type="file" name="photo1" id="simg1" style="display:none;"/>
                            <img id="imgPr1" style="width: 80px; height: 80px; border-radius:50%; " src="/Images/face/lbxx.jpg" /><br /><br />
                            <label class="fileLabel" for="simg1">修改头像</label>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">昵称</label>
                        <div class="layui-input-block">
                            <input type="text" id="nickname" name="nickname" autocomplete="off" placeholder="请输入昵称" class="layui-input"/>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">真实姓名</label>
                        <div class="layui-input-block">
                            <input type="text" id="name" name="name" autocomplete="off" placeholder="请输入真实姓名" class="layui-input"/>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">身份证号</label>
                        <div class="layui-input-block">
                            <input type="text" id="card" name="card" autocomplete="off" placeholder="请输入身份证号" class="layui-input"/>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">性别</label>
                        <div class="layui-input-block">
                            <select style="width:auto;" name="sex" id="sex" >
                                <option value="">请选择...</option>
                                <option value="男">男</option>
                                <option value="女">女</option>
                            </select>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">注册时间</label>
                        <div class="layui-input-block">
                            <input type="text" id="regtime" name="regtime" disabled="disabled" autocomplete="off" placeholder="" class="layui-input"/>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">邮箱</label>
                        <div class="layui-input-block">
                            <input type="text" id="email" name="email" autocomplete="off" placeholder="请输入邮箱" class="layui-input"/>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">联系QQ</label>
                        <div class="layui-input-block">
                            <input type="text" id="qq" name="qq" autocomplete="off" placeholder="请输入联系QQ<" class="layui-input"/>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">联系电话</label>
                        <div class="layui-input-block">
                            <input type="text" id="tel" name="tel" autocomplete="off" placeholder="请输入联系方式" class="layui-input"/>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">设置新密码</label>
                        <div class="layui-input-block">
                            <input type="text" id="pass" name="pass" autocomplete="off" placeholder="请输入新密码（不修改则不需要输入）" class="layui-input"/>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">用户类型</label>
                        <div class="layui-input-block">
                            <select style="width:auto;" name="type" id="type">
                                <option value="">请选择...</option>
                                <option value="1">租赁者</option>
                                <option value="2">房主</option>   
                                <option value="0">待审核</option>
                            </select>
                        </div>
                    </div>
                    <div class="layui-form-item" style="padding-left:110px;margin-top:40px;">
                        <input type="button" class="layui-btn layui-btn-danger" onclick="myclose()" value="取消" />
                        <input type="button" style="float:right;" class="layui-btn layui-btn-normal" onclick="mysave()" value="保存"/>
                    </div>
                </form>
            </div>
        </div> 

</body>
</html>
