<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnnounceList.aspx.cs" Inherits="myhouse.Web.MyAdmin.AnnounceList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <link href="/MyAdmin/frame/layui/css/layui.css" rel="stylesheet" />
    <link href="/MyAdmin/frame/static/css/style.css" rel="stylesheet" />
    <link href="/MyAdmin/frame/layui/css/bootstrap.min2.css" rel="stylesheet" />  <%--分页样式--%>

    <script src="/MyAdmin/js/jquery-1.11.1.js"></script>
    <script src="/MyAdmin/frame/layui/layui.js"></script>

    <style>
        th {
            min-width:28px;
        }
    </style>

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

            //layer.msg('hello  999');
            //layer.alert('发布成功！', { icon: 1 });
            //layer.msg('不开心。。', { icon: 5 });


            $("#publish").click(function () {
                //打开弹出层 类型，宽度，弹出动画，内容等
                layer.open({
                    type: 1,
                    title: '发布公告信息',
                    area: ['660px', '400px'],
                    offset: '100px',
                    anim: 1,
                    skin: "myclass",
                    shade: 0,
                    content: $("#addannounce")
                });
            });
        });

        //layui下拉框不显示，需要声明该表单
        layui.use('form', function () {
            var form = layui.form;
            form.render();
        });

        //发布公告(先判断是否为空)
        function mypublish()
        {
            if ($("#title").val() == "" || $("#content").val() == "") {
                layer.msg('请先填写公告的标题与内容!!!', { icon: 5 });
            }
            else {
                $.post("/MyAdmin/AnnounceList.aspx?flag=add", $("#fm").serialize(), function (result) {
                    if (result) {
                        layer.msg('发布成功！', { icon: 1 });
                        setTimeout("location.reload(true)", 800);  //延迟800ms执行
                    }
                    else {
                        layer.msg('发布遇到点问题，再试试吧...', { icon: 5 });
                    }
                }, "text");
            }  
        }

        //单个删除公告
        function mydelete(aid)
        {
            layer.confirm('您确定要删除这条公告吗？', { icon: 3, title: '提示' }, function (index) {
                $.post("/MyAdmin/AnnounceList.aspx?flag=mydelete", { aid: aid }, function (result) {
                    if (result) {
                        layer.msg('删除成功！', { icon: 1 });
                        setTimeout("location.reload(true)", 800);  //延迟800ms执行
                    }
                    else {
                        layer.msg('删除遇到点问题，再试试吧...', { icon: 5 });
                    }
                }, "text");
            });
        }

        //批量删除公告
        function deletelist() {
            var idlist = new Array();
            //获取勾选的checkbox的值val=aid
            $('input[name="check"]:checked').each(function(){
                idlist.push($(this).val());
            });

            if (idlist.length == 0) {
                layer.alert('请选择要删除的数据...', { icon: 5 });
                return;
            }

            var ids = idlist.join(',');
            //alert(ids);
            layer.confirm('您确定要删除这' + idlist.length + '条数据吗?', { icon: 3, title: '提示' }, function (index) {
                $.post("/MyAdmin/AnnounceList.aspx?flag=deletelist", { ids: ids }, function (result) {
                    if (result) {
                        layer.msg('公告已成功删除！', { icon: 1 });
                        setTimeout("location.reload(true)", 800);
                    } else {
                        layer.alert('公告删除失败...', { icon: 5 });
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
            $("#title").val("");
            $("#content").val("");
        }


    </script>

</head>
<body>
        <fieldset class="layui-elem-field layui-field-title" style="margin-top: 10px;">
            <legend>公告管理</legend>
        </fieldset>

        <div style="text-align:left;">
            <button class="layui-btn layui-btn-small layui-btn-danger" onclick="deletelist()"><i class="layui-icon">&#xe640;</i>批量删除</button>&nbsp;&nbsp;&nbsp;&nbsp;
            <div class="layui-input-inline">
                <form action="/MyAdmin/AnnounceList.aspx" method="post" class="layui-form">
                    <table>
                        <tr>
                            <td>
                              <input type="text" name="atitle" id="atitle" value="<%=atitle %>" placeholder="请输入公告标题" autocomplete="off" class="layui-input" style="height:30px;width:130px; margin-right:6px;" /> 
                            </td>
                            <td>
                              <button id="search" type="submit" class="layui-btn layui-btn-small layui-btn-normal " ><i class="layui-icon">&#xe615;</i>查找公告</button>
                            </td>
                         </tr>
                     </table>
                </form> 
            </div>
            <button type="button" class="layui-btn layui-btn-small layui-btn-normal" onclick="window.location='/MyAdmin/AnnounceList.aspx'"><i class="layui-icon">&#x1002;</i>刷新</button>
            <button id="publish" class="layui-btn layui-btn-small layui-btn-normal " style="float:right;"><i class="layui-icon">&#xe61f;</i>发布通知</button>
        </div>
               
        <table class="layui-table" lay-even="" lay-skin="nob" id="table">    <%--nob无边框--%>
            <colgroup>    <%--设置行宽--%>
                <col width="5"/>
                <col width="60"/>
            </colgroup>
            <thead>
            <tr>
                <th><i class=""></i></th>
                <th>编号</th>
		        <th>标题</th>
		        <th>内容</th>
		        <th>发布时间</th>
		        <th>发布人</th>
                <th>类型</th>
                <th style="text-align:center;">操作</th>
            </tr>
            </thead>
            <tbody>
                <% 
                    foreach (myhouse.Model.Announce announce in announceList)
                    {%>
                <tr>
                    <td><input type="checkbox" name="check" value="<%=announce.aid %>"/></td>
                    <td><%=announce.aid %></td>
                    <td><%=announce.atitle %></td>
                    <td><%=announce.acontent %></td>
                    <td><%=announce.atime %></td>
                    <td><%=announce.worker.wname %></td>
                    <%
                        if (announce.atype == "1   ")
                        {%>
                            <td style="color:orangered;">重要</td>
                        <%}
                        else
                        {%>
                            <td style="color:limegreen;">普通</td>                            
                        <%}
                    %>
                    
                    <td style="text-align:center;">
                        <button class="layui-btn layui-btn-small layui-btn-danger" onclick="mydelete(<%=announce.aid %>)">删除</button>
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
        
        <%--弹出层，发布公告--%>
        <div id="addannounce" class="layui-elem-field layui-field-title" style="display:none;">
            <div class="layui-col-md10" style="padding-right:0px;">
                <form class="layui-form layui-form-pane" id="fm" runat="server">
                    <div class="layui-form-item">
                        <label class="layui-form-label">公告标题</label>
                        <div class="layui-input-block">
                            <input type="text" id="title" name="title" autocomplete="off" placeholder="请输入公告标题" class="layui-input"/>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">公告内容</label>
                        <div class="layui-input-block">
                            <textarea name="content" id="content" placeholder="请输入公告内容" class="layui-input" style="height:120px;"></textarea>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">公告类型</label>
                        <div class="layui-input-block">
                            <select style="width:auto;" name="type">
                                <option value="0">普通</option>
                                <option value="1">重要</option>
                            </select>
                        </div>
                    </div>
                    <div class="layui-form-item" style="padding-left:110px;margin-top:40px;">
                        <input type="button" class="layui-btn layui-btn-danger" onclick="myclose()" value="取消" />
                        <input type="button" style="float:right;" class="layui-btn layui-btn-normal" onclick="mypublish()" value="发布"/>
                    </div>
                </form>
            </div>
        </div>   
</body>
</html>

