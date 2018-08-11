<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportInfo.aspx.cs" Inherits="myhouse.Web.MyAdmin.ReportInfo" %>

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

    <script>
        //在 layui 中使用 layer  
        layui.use('layer', function () {
            var layer = layui.layer;
        });

        //layui中下拉框不显示，需要声明该表单
        layui.use('form', function () {
            var form = layui.form;
            form.render();
        });


        //举报信息属实操作
        function mytrue(cid, hid) {
            layer.confirm('您确定要设置此房屋为不合法吗?', { icon: 3, title: '提示' }, function (index) {
                $.post("/MyAdmin/ReportInfo.aspx?flag=ok", {cid:cid, hid: hid }, function (result) {
                    if (result) {
                        layer.msg('设置成功!', { icon: 1 });
                        setTimeout("location.reload(true)", 800);
                    } else {
                        layer.msg('设置失败...', { icon: 5 });
                    }
                }, "text");
            });
        }

        //举报信息不属实操作
        function myfalse(cid) {
            layer.confirm('您确定要设置此举报信息为不属实吗?', { icon: 3, title: '提示' }, function (index) {
                $.post("/MyAdmin/ReportInfo.aspx?flag=notok", { cid: cid }, function (result) {
                    if (result) {
                        layer.msg('设置成功!', { icon: 1 });
                        setTimeout("location.reload(true)", 500);
                    } else {
                        layer.msg('设置成功...', { icon: 5 });
                    }
                }, "text");
            });
        }

        //举报信息不属实批量操作
        function deletelist() {
            //获取勾选的check的值
            var idlist = new Array();
            $('input[name="check"]:checked').each(function () {
                idlist.push($(this).val());//向数组中添加元素  
            });

            if (idlist.length == 0) {
                layer.alert('请先选择不属实的举报信息!', { icon: 5 });
                return;
            }
            var ids = idlist.join(',');//将数组元素通过,连接起来以构建一个字符串

            layer.confirm('您确定要设置这' + idlist.length + '个举报信息为不属实吗?', { icon: 3, title: '提示' }, function (index) {
                $.post("/MyAdmin/ReportInfo.aspx?flag=notok", { ids: ids }, function (result) {
                    if (result) {
                        layer.msg('设置成功!', { icon: 1 });
                        setTimeout('window.location.reload(true)', 500);
                    }
                    else {
                        layer.msg('设置失败...', { icon: 5 });
                    }
                }, "text");
            });
        }

    </script>


</head>
<body>
        <fieldset class="layui-elem-field layui-field-title" style="margin-top: 10px;">
            <legend>举报信息管理</legend>
        </fieldset>
        <div style="text-align:left;height:30px; padding:0;" >        
            <form class="layui-form" runat="server" style="height:30px;" id="d1">
                 
                 <button class="layui-btn layui-btn-small layui-btn-danger" type="button" style="float:left;" onclick="deletelist()"><i class="layui-icon">&#xe640;</i>多个不属实</button>&nbsp;&nbsp;&nbsp;&nbsp;
                    
                <input type="text" name="hid" id="hid" value="<%=hid %>" placeholder="请输入房屋ID" autocomplete="off" class="layui-input" style="height:30px;width:113px; margin-left:20px;margin-right:10px; float:left;" /> 
                <%--<div class="layui-inline" style="height:30px; width:140px;" >
                    <div class="layui-input-inline" >
                        <select name="sid">
                            <option value="">请选择房屋板块</option>
                            <%
                                foreach (myhouse.Model.Section section in sectionList)
                                {%>
                                    <option value="<%=section.sid %>   " <%=sid == section.sid.ToString() ? "selected" : "" %> ><%=section.sname %></option>
                                <%}
                            %>
                        </select>
                    </div>
                </div>--%>
                <%--<div class="layui-inline" style="height:30px; width:140px;">
                    <div class="layui-input-inline" >
                        <select name="htype">
                            <option value="">请选择房屋类型</option>
                            <%
                                foreach (myhouse.Model.Housetype housetype in hyList)
                                {%>
                                    <option value="<%=housetype.tid %>" <%=htype == housetype.tid.ToString() ? "selected" : "" %> ><%=housetype.ttype %></option>
                                <%}
                            %>
                        </select>
                    </div>
                </div>--%>
                <div class="layui-inline" style="height:30px; width:140px;" >
                    <div class="layui-input-inline" >
                        <select name="cstatus">
                            <option value="0" <%=cstatus == "0" ? "selected" : "" %> >未处理</option>
                            <option value="1" <%=cstatus == "1" ? "selected" : "" %> >属实信息</option>                  
                            <option value="2" <%=cstatus == "2" ? "selected" : "" %> >不属实</option>                  
                        </select>
                    </div>
                </div>
                <div class="layui-inline" style="height:30px; width:140px;" >
                    <div class="layui-input-inline" >
                        <select name="order">
                            <option value="0" <%=order == "0" ? "selected" : "" %> >最新举报信息</option>
                            <option value="1" <%=order == "1" ? "selected" : "" %> >最早举报信息</option>
                            <option value="2" <%=order == "2" ? "selected" : "" %> >房屋ID排序</option>
                            <option value="3" <%=order == "3" ? "selected" : "" %> >举报人排序</option>
                        </select>
                    </div>
                </div>
                <button type="submit" class="layui-btn layui-btn-small layui-btn-normal" id="search" style="margin-left:10px;" ><i class="layui-icon">&#xe615;</i>查询</button>
                <button type="button" class="layui-btn layui-btn-small layui-btn-normal" onclick="window.location='/MyAdmin/ReportInfo.aspx'"><i class="layui-icon">&#x1002;</i>刷新</button>
            </form>     
        </div>

        <table class="layui-table" lay-even="" lay-skin="nob">
            <thead>
            <tr style="text-align:center;">
                <th></th>
                <th>房屋ID</th>
		        <th>房屋名</th>
		        <th>类型</th>
                <th>所属板块</th>
                <th>描述</th>
                <th>发布时间</th>
                <th>发布人</th>
                <th>图片</th>
                <th>举报人</th>
                <th>举报原因</th>
                <th style="text-align:center;">操作</th>
            </tr>
            </thead>
            <tbody>
                <% 
                    foreach (myhouse.Model.Contract contract in reportList)
                    {%>        
                    <tr >
                        <td><input type="checkbox" name="check" id="check" value="<%=contract.cid %>"/></td>
                        <td><%=contract.house.hid %></td>
                        <td><a href="/HouseDetails.aspx?hid=<%=contract.house.hid %>" target="_blank"><%=contract.house.hname %></a></td>
                        <td><%=contract.house.housetype.ttype %></td>
                        <td><%=contract.house.section.sname %></td>
                        <td><%=contract.house.hdescription %></td>
                        <td><%=contract.house.htime %></td>
                        <td><%=contract.house.userinfo.uname %></td>
                        <td style="padding:4px; text-align:center;">
                            <img alt="" src="<%=contract.house.hphotoone %>" style="width: 80px; height: 80px; border-radius:2px;"/>
                        </td>
                        <td><%=contract.user.uname %></td>
                        <td><%=contract.ccontent %></td>
                        <td style="text-align:center;">
                            <%
                                if (contract.cstatus == 0)
                                {%>
                                    <button class="layui-btn layui-btn-small layui-btn-normal" style="margin-bottom:4px;width:68px;" onclick="mytrue(<%=contract.cid %>, <%=contract.hid %>)">属实</button><br />
                                    <button class="layui-btn layui-btn-small layui-btn-danger" style="width:68px;" onclick="myfalse(<%=contract.cid %>)">不属实</button>
                                <%}
                                else
                                {%>
                                    <button class="layui-btn layui-btn-small layui-btn-disabled" style="width:68px;">禁用</button>
                                <%}
                            %>
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

</body>
</html>
