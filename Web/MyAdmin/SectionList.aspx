<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SectionList.aspx.cs" Inherits="myhouse.Web.MyAdmin.SectionList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link href="frame/layui/css/layui.css" rel="stylesheet" />
    <link href="frame/static/css/style.css" rel="stylesheet" />
    <link href="frame/layui/css/bootstrap.min2.css" rel="stylesheet" />

    <script src="/MyAdmin/js/jquery-1.11.1.js"></script>
    <script src="/MyAdmin/frame/layui/layui.js"></script>

    <%--判断是否在框架（/MyAdmin/Default.aspx）中打开--%>
    <script>
        var url = parent.location.pathname;
        if (url != '/MyAdmin/Default.aspx') {
            window.location.href = "/MyAdmin/AdminLogin.aspx";
        }

        //在 layui 中使用 layer  打开弹出层！！！
        layui.use('layer', function () {
            var layer = layui.layer;

            $("#add").click(function () {
                //打开弹出层 类型，宽度，弹出动画，内容等
                layer.open({
                    type: 1,
                    title: '添加新的房屋板块',
                    area: ['660px', '400px'],
                    offset: 'auto',
                    anim: 1,
                    skin: "myclass",
                    shade: 0,
                    content: $("#section")
                });
            });

            //$("#update").click(function () {
            //    //打开弹出层 类型，宽度，弹出动画，内容等
            //    layer.open({
            //        type: 1,
            //        title: '修改房屋板块信息',
            //        area: ['660px', '400px'],
            //        offset: 'auto',
            //        anim: 1,
            //        skin: "myclass",
            //        shade: 0,
            //        content: $("#section")
            //    });
            //});
        });

        //添加新板块(先判断是否为空)
        function mypublish() {
            if ($("#sname").val() == "" || $("#sdescription").val() == "") {
                layer.msg('请先填写板块的名称与描述!!!', { icon: 5 });
            }
            else {
                //alert($("#fm").serialize());
                $.post("/MyAdmin/SectionList.aspx?flag=addup", $("#fm").serialize(), function (result) {
                    if (result) {
                        layer.msg('房屋板块保存成功！', { icon: 1 });
                        setTimeout("location.reload(true)", 800);  //延迟800ms执行
                    }
                    else {
                        layer.msg('房屋板块信息保存遇到点问题，再试试吧...', { icon: 5 });
                    }
                }, "text");
            }
        }

        //板块单个删除
        function mydelete(sid) {
            layer.confirm('您确定要删除这个板块和板块下的所有房屋吗？', { icon: 3, title: '提示' }, function (index) {
                $.post("/MyAdmin/SectionList.aspx?flag=delete", { sid: sid }, function (result) {
                    if (result) {
                        layer.msg('该板块以及该板块下所有房屋删除成功!', { icon: 1 });
                        setTimeout("location.reload(true)", 800);

                    } else {
                        layer.msg('删除失败...', { icon: 5 });
                    }
                }, "text");
            });
        }

        //板块批量删除
        function deletelist() {
            //获取勾选的check的值
            var idlist = new Array();
            $('input[name="check"]:checked').each(function () {
                idlist.push($(this).val());//向数组中添加元素  
            });

            if (idlist.length == 0) {
                layer.alert('请先勾选需要删除的数据!', { icon: 5 });
                return;
            }
            var ids = idlist.join(',');//将数组元素连接起来以构建一个字符串

            layer.confirm('您确定要删除这' + idlist.length + '个板块吗?', { icon: 3, title: '提示' }, function (index) {
                $.post("/MyAdmin/SectionList.aspx?flag=deletelist", { ids: ids }, function (result) {
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

        //板块信息修改
        function myupdate(sid, sname, sdescription) {
            $("#sid").val(sid);
            $("#sname").val(sname);
            $("#sdescription").val(sdescription);
            //alert(sid);
            //打开修改弹出层
            layer.open({
                type: 1,
                title: '修改房屋板块信息',
                area: ['660px', '400px'],
                offset: 'auto',
                anim: 1,
                skin: "myclass",
                shade: 0,
                content: $("#section")
            });

        }

        //关闭弹出层
        function myclose() {
            resetValue();
            layer.closeAll();
        };

        //清空弹出层form表单中的内容
        function resetValue() {
            $("#sname").val("");
            $("#sdescription").val("");
        }
    </script>

</head>

<%
    if (Session["adminInfo"] == null)
    {
        Response.Redirect("/MyAdmin/AdminLogin.aspx");
    }
%>

<body>
    <fieldset class="layui-elem-field layui-field-title" style="margin-top: 10px;">
        <legend>房屋板块管理</legend>
    </fieldset>

    <div style="text-align: left;">
        <button class="layui-btn layui-btn-small layui-btn-danger" onclick="deletelist()"><i class="layui-icon">&#xe640;</i>批量删除</button>
        <button id="add" class="layui-btn layui-btn-small layui-btn-normal" style="float: right;">新增板块</button>
    </div>

    <table class="layui-table" lay-even="" lay-skin="nob">
        <colgroup>
            <col width="100" />
        </colgroup>
        <thead>
            <tr>
                <th></th>
                <th>板块编号</th>
                <th>板块名称</th>
                <th>板块描述</th>
                <th>房屋数</th>
                <th style="text-align: center;">操作</th>
            </tr>
        </thead>
        <tbody>
            <% 
                foreach (myhouse.Model.Section section in sectionList)
                {%>
            <tr>
                <td>
                    <input type="checkbox" name="check" value="<%=section.sid %>" /></td>
                <td><%=section.sid %></td>
                <td><%=section.sname %></td>
                <td><%=section.sdescription %></td>
                <td><%=section.housecount %></td>
                <td colspan="2" style="text-align: center;">
                    <button id="update" class="layui-btn layui-btn-small layui-btn-normal" onclick="myupdate(<%=section.sid %>, '<%=section.sname %>', '<%=section.sdescription %>')">修改</button>
                    <button class="layui-btn layui-btn-small layui-btn-danger" onclick="mydelete(<%=section.sid %>)">删除</button>
                </td>
            </tr>
            <%}
            %>
        </tbody>
    </table>
    <div class="pagination alternate" style="text-align: center;">
        <ul class="clearfix">
            <p><%=pageCode %></p>
        </ul>
    </div>

    <%--弹出层，板块发布与修改--%>
    <div id="section" class="layui-elem-field layui-field-title" style="display: none;">
        <div class="layui-col-md10" style="padding-right: 0px;">
            <form class="layui-form layui-form-pane" id="fm" runat="server">
                <input type="hidden" id="sid" name="sid" />
                <div class="layui-form-item">
                    <label class="layui-form-label">板块名称</label>
                    <div class="layui-input-block">
                        <input type="text" id="sname" name="sname" autocomplete="off" placeholder="请输入板块名称" class="layui-input" />
                    </div>
                </div>
                <div class="layui-form-item">
                    <label class="layui-form-label">板块描述</label>
                    <div class="layui-input-block">
                        <textarea name="sdescription" id="sdescription" placeholder="请输入板块描述" class="layui-input" style="height: 120px;"></textarea>
                    </div>
                </div>
                <div class="layui-form-item" style="padding-left: 110px; margin-top: 40px;">
                    <input type="button" class="layui-btn layui-btn-danger" onclick="myclose()" value="取消" />
                    <input type="button" style="float: right;" class="layui-btn layui-btn-normal" onclick="mypublish()" value="保存" />
                </div>
            </form>
        </div>
    </div>

</body>
</html>
