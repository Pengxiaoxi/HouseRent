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

    //添加员工信息-打开弹出层
    function myadd()
    {
        layer.open({
            type: 1,
            title: '添加员工信息',
            area: ['800px', '500px'],
            offset: '20px',
            anim: 1,
            skin: "myclass",
            shade: 0.1,
            content: $("#updateworker")
        });
    }

    //修改员工信息-给表单赋值并打开弹出层
    function myupdate(wid,name, sex, card, tel, email, adress, type, simg) {
        $("#wid").val(wid)
        $("#name").val(name);
        $("#sex").val(sex);
        $("#card").val(card);
        $("#newpass").val("");
        $("#newpass2").val("");
        $("#tel").val(tel);
        $("#email").val(email);
        $("#adress").val(adress);
        $("#type").val(type);
        $("#imgPr").attr("src", simg);

        var form = layui.form;
        form.render();   //表单重新渲染

        layer.open({
            type: 1,
            title: '添加员工信息',
            area: ['800px', '500px'],
            offset: '20px',
            anim: 1,
            skin: "myclass",
            shade: 0.1,
            content: $("#updateworker")
        });
    }

    //保存员工信息
    function mysave()
    {
        if ($("#name").val() == "" || $("#card").val() == "") {
            layer.msg('请填写员工的相关信息!!!', { icon: 5 });
        }
        else {
            var form = document.getElementById('fm');
            var formData = new FormData(form);
            //alert(formData);

            $.ajax({
                type: "POST",
                url: "/MyAdmin/WorkerList.aspx?flag=addorupdate",
                data: formData,
                async: true,
                cache: false,
                contentType: false,
                processData: false,
                success: function (msg) {
                    if (msg) {
                        layer.msg('该员工信息保存成功!', { icon: 1 });
                        setTimeout("window.location.reload(true)", 600);
                    }
                    else {
                        layer.msg('该员工信息保存失败!', { icon: 5 })
                    }
                }
            });
        }
    }

    //单个删除员工信息
    function mydelete(wid)
    {
        layer.confirm('您确定要删除此员工的信息吗?', { icon: 3, title: '提示' }, function (index) {
            $.post("/MyAdmin/WorkerList.aspx?flag=delete", { wid: wid }, function (result) {
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

    //批量删除员工信息
    function deletelist() {
        //获取勾选的check的值
        var idlist = new Array();
        $('input[name="check"]:checked').each(function () {
            idlist.push($(this).val());//向数组中添加元素  
        });

        if (idlist.length == 0) {
            layer.alert('请先选择需要删除的员工!', { icon: 5 });
            return;
        }
        var ids = idlist.join(',');//将数组元素连接起来以构建一个字符串

        layer.confirm('您确定要删除这' + idlist.length + '个员工的所有信息吗?', { icon: 3, title: '提示' }, function (index) {
            $.post("/MyAdmin/WorkerList.aspx?flag=delete", { ids: ids }, function (result) {
                if (result) {
                    layer.msg('删除成功!', { icon: 1 });
                    setTimeout('window.location.reload(true)', 500);
                }
                else {
                    layer.msg('删除失败...', { icon: 5 });
                }
            }, "text");
        });
    }

    //检查身份证号是否已存在
    function checkcard()
    {
        var cardId = $("#card").val();

        $.post("/MyAdmin/WorkerList.aspx?flag=check", { cardId: cardId }, function (result) {
            if (result == "True") {
                layer.alert('该身份证号已存在!!!', { icon: 5 });
            }
            else {
            }
        }, "text");
    }

    //关闭弹出层
    function myclose() {
        resetValue();
        layer.closeAll();
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
        $("#imgPr").attr("src", "/Images/House/wu.jpg");
        $("#simg").val("")

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
            <form class="layui-form" runat="server" style="height:30px;" id="d1">         
                <button class="layui-btn layui-btn-small layui-btn-danger" type="button" style="float:left;" onclick="deletelist()"><i class="layui-icon">&#xe640;</i>批量删除</button>&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="text" name="wname" id="wname" value="<%=name %>" placeholder="请输入员工姓名" autocomplete="off" class="layui-input" style="height:30px;width:130px; margin-left:20px; float:left;" />          
                <div class="layui-inline" style="height:30px; width:100px; margin-right:10px;" >
                    <div class="layui-input-inline" onblur="return decide()">
                        <select name="peopletype" id="peopletype" >
                            <option value="">全部人员</option>
                            <option value="8" <%=type == "8" ? "selected" : "" %>  >管理员</option>
                            <option value="1" <%=type == "1" ? "selected" : "" %>  >员工</option>
                        </select>
                    </div>
                </div>
                <div class="layui-inline" style="height:30px; width:100px;" >
                    <div class="layui-input-inline" >
                        <select name="permission" id="permission" >
                            <option value="">权限选择</option>
                            <option value="0" <%=permission == "0" ? "selected" : "" %> >权限一</option>
                            <option value="1" <%=permission == "1" ? "selected" : "" %> >权限二</option>
                            <option value="2" <%=permission == "2" ? "selected" : "" %> >权限三</option>
                        </select>
                    </div>
                </div>
                <div class="layui-inline" style="height:30px; width:100px;">
                        <div class="layui-input-inline" >
                            <select name="order">
                                <option value="0" <%=order == "0" ? "selected" : "" %> >编号升序</option>
                                <option value="1" <%=order == "1" ? "selected" : "" %> >编号降序</option>
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
                <th>类别</th>
                <th style="text-align:center;">操作</th>
            </tr>
            </thead>
            <tbody>
                <% 
                    foreach(myhouse.Model.Worker worker in workerList)
                 {%>        
                    <tr >
                        <td><input type="checkbox" name="check" value="<%=worker.wid %>"/></td>
                        <td><%=worker.wid %></td>
                        <td><%=worker.wname %></td>
                        <td><%=worker.wsex %></td>
                        <td><%=worker.wcard%></td>
                        <td><%=worker.wtel %></td>
                        <td><%=worker.wemail %></td>
                        <td><%=worker.wadress %></td>
                        <td style="padding:4px; text-align:center;">
                            <img alt="" src="<%=worker.wphoto %>" style="width: 80px; height: 80px; border-radius:50%;">
                        </td>
                        <%--<td><i style="color:dodgerblue;">√</i></td>--%>

                        <%
                            if (worker.wtype == "0   "){%>
                                <td><i class="layui-icon" style="font-size: 30px; color:limegreen;">&#xe605;</i></td>
                                <td></td>
                                <td></td>
                            <%}
                            else if(worker.wtype == "1   ") {%>
                                <td></td>
                                <td><i class="layui-icon" style="font-size: 30px; color:limegreen;">&#xe605;</i></td>
                                <td></td>
                                
                            <%}
                            else if(worker.wtype == "2   ") {%>
                                <td></td>
                                <td></td>
                                <td><i class="layui-icon" style="font-size: 30px; color:limegreen;">&#xe605;</i></td>
                            <%}
                            else if(worker.wtype == "8   ") {%>
                                <td><i class="layui-icon" style="font-size: 30px; color:limegreen;">&#xe605;</i></td>
                                <td><i class="layui-icon" style="font-size: 30px; color:limegreen;">&#xe605;</i></td>
                                <td><i class="layui-icon" style="font-size: 30px; color:limegreen;">&#xe605;</i></td>
                            <%}
                        %>

                        <%
                            if (worker.wtype == "8   ")
                            {%>
                                <td style='color:orangered'>管理员</td>
                            <%}
                            else
                            {%>
                                <td style='color:dodgerblue'>员工</td>
                             <%}
                        %>
                        
                        <td style="text-align:center; padding:0;">
                             <button id="myupdate" class="layui-btn layui-btn-small layui-btn-normal" style="margin-bottom:4px;" onclick="myupdate(<%=worker.wid %>, '<%=worker.wname %>', '<%=worker.wsex %>', '<%=worker.wcard %>', '<%=worker.wtel %>', '<%=worker.wemail %>', '<%=worker.wadress %>', <%=worker.wtype %>, '<%=worker.wphoto %>')">修改</button><br />
                             <button class="layui-btn layui-btn-small layui-btn-danger" onclick="mydelete(<%=worker.wid %>)">删除</button>                       
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

        <%--弹出层，修改员工信息与权限--%>
        <div id="updateworker" class="layui-elem-field layui-field-title" style="display:none;">
            <div class="layui-col-md10" style="padding-right:0px;">
                <form class="layui-form layui-form-pane" id="fm" action="/MyAdmin/WorkerList.aspx" method="post" enctype="multipart/form-data">
                    <input type="hidden" name="wid" id="wid" value=""/>
                     <div class="layui-form-item">
                        <div class="layui-input-block" style="width:200px; margin-left:50%;">
                            <input type="file" name="photo" id="simg" style="display:none;"/>
                            <img id="imgPr" style="width: 80px; height: 80px; border-radius:50%; " src="/Images/face/xi.jpg" /><br /><br />
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
                                <option value="男  ">男</option>
                                <option value="女  ">女</option>
                            </select>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">身份证号</label>
                        <div class="layui-input-block">
                            <input type="text" name="card" id="card" autocomplete="off" value="" class="layui-input" onblur="checkcard()" />
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">密码</label>

                        <div class="layui-input-block">
                            <input onfocus="this.type='password'" name="newpass" id="newpass" autocomplete="off" placeholder="需要更改则输入，否则无需输入(添加员工需要输入密码)" autocomplete="off" value="" class="layui-input"/>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">确认密码</label>

                        <div class="layui-input-block">
                            <input onfocus="this.type='password'"  name="newpass2" id="newpass2" onblur="checkpass()" autocomplete="off" placeholder="需要更改则输入，否则无需输入(添加员工需要输入密码)" autocomplete="off" value="" class="layui-input"/>
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
                        <label class="layui-form-label">权限管理</label>
                        <div class="layui-input-block">
                            <select name="type" id="type" >
                                <option value="0">权限一（仅审核)</option>
                                <option value="1">权限二（审核+修改）</option>
                                <option value="2">权限三（审核+修改+删除）</option>
                                <option value="8">管理员</option>
                            </select>
                        </div>
                    </div>
                    
                    <%--<div class="layui-form-item" pane="">
                        <label class="layui-form-label">开关-开</label>
                        <div class="layui-input-block">
                            <input type="checkbox" name="open" id="c1" lay-skin="switch" lay-filter="switchTest" onclick="check()" title="开关"/>
                        </div>
                    </div>
                    <div class="layui-form-item" pane="">
                        <label class="layui-form-label">开关-开</label>
                        <div class="layui-input-block">
                            <input type="checkbox"  name="open" id="c2" lay-skin="switch" lay-filter="switchTest" onclick="check()" title="开关"/>
                        </div>
                    </div>
                    <div class="layui-form-item" pane="">
                        <label class="layui-form-label">开关-开</label>
                        <div class="layui-input-block">
                            <input type="checkbox"name="open" id="c3" lay-skin="switch" lay-filter="switchTest" onclick="check()" title="开关"/>
                        </div>
                    </div>--%>
                    <div class="layui-form-item" style="padding-left:110px;">
                        <input type="button" class="layui-btn layui-btn-danger" style="border-radius:10px" onclick="myclose()" value="取消" />
                        <input type="button" style="float:right; border-radius:10px" class="layui-btn layui-btn-normal" onclick="mysave()" value="保存"/>
                    </div>
                </form>
            </div>
        </div> 

</body>
</html>

<script>
    //$(document).ready(function () {
    //    $("#fm").find('input[type=checkbox]').bind("click", function () {
    //        $("#fm").find('input[type=checkbox]').not(this).attr("checked", false);
    //    });
    //    alert(123);
    //});
    
    //var flag = true;
    //function check()
    //{
    //    var c1 = document.getElementById("c1")
    //    var c2 = document.getElementById("c2")
    //    var c3 = document.getElementById("c3")

    //    if (c1.checked == true) {
    //        c2.checked = false;
    //        c3.checked = false;
    //    }
    //    else if (c2.checked == true) {
    //        c1.checked = false;
    //        c3.checked = false;
    //    }
    //    else if (c3.checked == true) {
    //        c1.checked = false;
    //        c2.checked = false;
    //    }
    //}

    //form.rende()

    ////监听指定开关
    //form.on('switch(switchTest)', function (data) {
    //    layer.msg('开关checked：' + (this.checked ? 'true' : 'false'), {
    //        offset: '6px'
    //    });
    //    layer.tips('温馨提示：请注意开关状态的文字可以随意定义，而不仅仅是ON|OFF', data.othis)
    //});

    //控件复选框只能选择一项
    //jQuery(document).ready(function () {
    //    jQuery("#fm input[type='checkbox']").click(function () {
    //        if (jQuery(this).attr("checked") == true) {
    //            jQuery("#fm input[type='checkbox']").attr("checked", false);
    //            jQuery(this).attr("checked", true);
    //        }
    //    });
    //});

</script>
