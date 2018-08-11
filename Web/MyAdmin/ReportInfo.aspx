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
        function myreview(hid) {
            layer.confirm('您确定要设置此房屋为不合法吗?', { icon: 3, title: '提示' }, function (index) {
                $.post("/MyAdmin/ReportInfo.aspx?flag=ok", { hid: hid }, function (result) {
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
        function mynoreview(hid) {
            layer.confirm('您确定要设置此举报信息为不属实吗?', { icon: 3, title: '提示' }, function (index) {
                $.post("/MyAdmin/ReportInfo.aspx?flag=notok", { hid: hid }, function (result) {
                    if (result) {
                        layer.msg('设置成功!', { icon: 1 });
                        setTimeout("location.reload(true)", 800);
                    } else {
                        layer.msg('设置成功...', { icon: 5 });
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
                    
                <input type="text" name="hid" id="hid" value="" placeholder="请输入房屋ID" autocomplete="off" class="layui-input" style="height:30px;width:113px; margin-left:20px;margin-right:10px; float:left;" /> 
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
                            <option value="0">未处理</option>
                            <option value="1">属实信息</option>                  
                            <option value="2">不属实</option>                  
                        </select>
                    </div>
                </div>
                <div class="layui-inline" style="height:30px; width:140px;" >
                    <div class="layui-input-inline" >
                        <select name="order">
                            <option value="0">最新举报信息</option>
                            <option value="1">最早举报信息</option>
                            <option value="2">房屋ID排序</option>
                            <%--<option value="3">发布人排序</option>--%>
                            <option value="3">举报人排序</option>
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
                        <td><input type="checkbox" name="check" value="<%=contract.cid %>"/></td>
                        <td><%=contract.cid %></td>
                        <td><%=contract.house.hname %></td>
                        <td><%=contract.house.housetype.ttype %></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td style="padding:4px; text-align:center;">
                            <img alt="" src="" style="width: 80px; height: 80px; border-radius:2px;">
                        </td>
                        <td></td>
                        <td style="text-align:center;">
                            <button class="layui-btn layui-btn-small layui-btn-normal" style="margin-bottom:4px;width:68px;" onclick="mytrue()">属实</button><br />
                            <button class="layui-btn layui-btn-small layui-btn-danger" style="width:68px;" onclick="myfalse()">不属实</button>
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
