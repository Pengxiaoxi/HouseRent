<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HouseList.aspx.cs" Inherits="myhouse.Web.MyAdmin.HouseList" %>

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

        //房屋信息修改弹出层
        function myupdate(hid,hname,htype,sid, hsize,hfloor,hmoney,hcommunity,harea,hadress,hdescription,photo1,photo2,photo3,photo4,hmode,hstatus)
        {
            //alert(hid);
            $("#hid").val(hid);
            $("#name").val(hname);
            $("#section").val(sid);
            $("#tid").val(htype);
            $("#size").val(hsize);
            $("#floor").val(hfloor);
            $("#money").val(hmoney);
            $("#community").val(hcommunity);
            $("#area").val(harea);
            $("#adress").val(hadress);
            $("#description").val(hdescription);
            $("#imgPr1").attr("src", photo1);
            $("#imgPr2").attr("src", photo2);
            $("#imgPr3").attr("src", photo3);
            $("#imgPr4").attr("src", photo4);
            $("#status").val(hstatus);
            $("#mode").val(hmode);
            $("#housephoto1").val(photo1);
            $("#housephoto2").val(photo2);
            $("#housephoto3").val(photo3);
            $("#housephoto4").val(photo4);

            var form = layui.form;
            form.render();   //表单重新渲染

            layer.open({
                type: 1,
                title: '发布公告信息',
                area: ['800px', '500px'],
                offset: '20px',
                anim: 1,
                skin: "myclass",
                shade: 0.1,
                content: $("#updatehouse")
            });
        }

        //房屋信息的保存
        function mysave()
        {
            var form = document.getElementById('fm');
            var formData = new FormData(form);

            $.ajax({
                type: "POST",
                url: "/MyAdmin/HouseList.aspx?flag=update",
                data: formData,
                async: false,
                cache: false,
                contentType: false,
                processData: false,
                success: function (msg) {
                    if (msg) {
                        layer.msg('该房屋信息修改成功!', { icon: 1 });
                        setTimeout("window.location.reload(true)", 600);
                    }
                    else {
                        layer.msg('房屋信息修改失败!', { icon: 5 })
                    }
                }
            });
        }

        //房屋信息的单个删除
        function mydelete(hid) {
            layer.confirm('您确定要删除这条房屋信息吗？', { icon: 3, title: '提示' }, function (index) {
                $.post("/MyAdmin/HouseList.aspx?flag=delete", { hid: hid }, function (result) {
                    if (result) {
                        layer.msg('房屋信息删除成功!', { icon: 1 });
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
                layer.alert('请先选择需要删除的数据!', { icon: 5 });
                return;
            }

            var ids = idlist.join(',');//将数组元素连接起来以构建一个字符串

            layer.confirm('您确定要删除这' + idlist.length + '个房屋信息吗?', { icon: 3, title: '提示' }, function (index) {
                $.post("/MyAdmin/HouseList.aspx?flag=delete", { ids: ids }, function (result) {
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

        //员工审核单个信息
        function myreview(hid)
        {
            layer.confirm('您确定要允许此条信息通过审核吗?', { icon: 3, title: '提示' }, function (index) {
                $.post("/MyAdmin/HouseList.aspx?flag=review", { hid: hid }, function (result) {
                    if (result) {
                        layer.msg('审核通过!', { icon: 1 });
                        setTimeout("location.reload(true)", 800);
                    } else {
                        layer.msg('审核失败...', { icon: 5 });
                    }
                }, "text");
            });
        }
        //不允通过审核
        function mynoreview(hid) {
            layer.confirm('您确定要不允许此条信息通过审核吗?', { icon: 3, title: '提示' }, function (index) {
                $.post("/MyAdmin/HouseList.aspx?flag=review&param=no", { hid: hid }, function (result) {
                    if (result) {
                        layer.msg('此房屋未通过审核!', { icon: 1 });
                        setTimeout("location.reload(true)", 800);
                    } else {
                        layer.msg('审核失败...', { icon: 5 });
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
            $("#name").val("");
            $("#section").val("");
            $("#tid").val("");
            $("#size").val("");
            $("#floor").val("");
            $("#money").val("");
            $("#community").val("");
            $("#area").val("");
            $("#adress").val("");
            $("#description").val("");
            $("#imgPr1").attr("src", "/Images/House/wu.jpg");
            $("#imgPr2").attr("src", "/Images/House/wu.jpg");
            $("#imgPr3").attr("src", "/Images/House/wu.jpg");
            $("#imgPr4").attr("src", "/Images/House/wu.jpg");
            $("#status").val("");
            $("#mode").val("");

            var form = layui.form;
            form.render();   //表单重新渲染
        }

        //图片预览
        $(function () {
            $("#simg1").uploadPreview({ Img: "imgPr1", Width: 220, Height: 200 });
            $("#simg2").uploadPreview({ Img: "imgPr2", Width: 220, Height: 200 });
            $("#simg3").uploadPreview({ Img: "imgPr3", Width: 220, Height: 200 });
            $("#simg4").uploadPreview({ Img: "imgPr4", Width: 220, Height: 200 });

        });
    </script>

</head>

<body>
        <fieldset class="layui-elem-field layui-field-title" style="margin-top: 10px;">
            <legend>房屋信息管理</legend>
        </fieldset>
        <div style="text-align:left;height:30px; padding:0;" >        
            <form class="layui-form" runat="server" style="height:30px;" id="d1">
                <% 
                    if (((myhouse.Model.Worker)Session["adminInfo"]).wtype == "8   " ||((myhouse.Model.Worker)Session["adminInfo"]).wtype == "2   ")
                    {%>
                        <button class="layui-btn layui-btn-small layui-btn-danger" type="button" style="float:left;" onclick="deletelist()"><i class="layui-icon">&#xe640;</i>批量删除</button>&nbsp;&nbsp;&nbsp;&nbsp;
                    <%}
                    else
                    {%>
                        <button class="layui-btn layui-btn-small layui-btn-normal" type="button" style="float:left;">请选择条件进行查询</button>
                    <%}
                %>
                
                <input type="text" name="hname" id="hname" value="<%=hname %>" placeholder="请输入房屋名称" autocomplete="off" class="layui-input" style="height:30px;width:113px; margin-left:20px;margin-right:10px; float:left;" /> 
                <div class="layui-inline" style="height:30px; width:140px;" >
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
                </div>
                <div class="layui-inline" style="height:30px; width:140px;">
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
                </div>
                <div class="layui-inline" style="height:30px; width:112px;">
                    <div class="layui-input-inline" >
                        <select name="harea">
                            <option value="">请选择地区</option>
                            <%
                                foreach (myhouse.Model.Area area in areaList )
                                {%>
                                    <option value="<%=area.areaid %>" <%=harea == area.areaid.ToString() ? "selected" : "" %> ><%=area.areaname %></option>
                                <%}
                            %>
                        </select>
                    </div>
                </div>        
                <div class="layui-inline" style="height:30px; width:140px;" >
                    <div class="layui-input-inline" >
                        <select name="hmode">
                            <option value="">请选择是否出租</option>
                            <option value="0" <%=hmode == "0" ? "selected" : "" %> >未出租</option>
                            <option value="1" <%=hmode == "1" ? "selected" : "" %> >已出租</option>
                        </select>
                    </div>
                </div>
                <div class="layui-inline" style="height:30px; width:140px;" >
                    <div class="layui-input-inline" >
                        <select name="hstatus"  >
                            <option value="">请选择房屋状态</option>
                            <option value="0" <%=hstatus == "0" ? "selected" : "" %> >未审核</option>
                            <option value="1" <%=hstatus == "1" ? "selected" : "" %> >已审核</option>
                            <option value="2" <%=hstatus == "2" ? "selected" : "" %> >不合法</option>
                        </select>
                    </div>
                </div>
                <div class="layui-inline" style="height:30px; width:100px;" >
                    <div class="layui-input-inline" >
                        <select name="order">
                            <option value="0" <%=order == "0" ? "selected" : "" %> >最新发布</option>
                            <option value="1" <%=order == "1" ? "selected" : "" %> >最早发布</option>
                            <option value="2" <%=order == "2" ? "selected" : "" %> >租金最高</option>
                            <option value="3" <%=order == "3" ? "selected" : "" %> >租金最低</option>
                        </select>
                    </div>
                </div>
                <button id="search" type="submit" class="layui-btn layui-btn-small layui-btn-normal " ><i class="layui-icon">&#xe615;</i>查询</button>
                <%--<button type="button" class="layui-btn layui-btn-small layui-btn-normal" onclick="window.location='/MyAdmin/HouseList.aspx'"><i class="layui-icon">&#x1002;</i>刷新</button>--%>
            </form>     
        </div>

        <table class="layui-table" lay-even="" lay-skin="nob">
            <thead>
            <tr style="text-align:center;">
                <th></th>
                <th>ID</th>
		        <th>名称</th>
		        <th>类型</th>
                <th>所属板块</th>
                <th>面积</th>
		        <th>楼层</th>
                <th>租金</th>
		        <th>小区</th>  
		        <th>地区</th>
		        <th>详细地址</th>
                <th>描述</th>
                <th>发布时间</th>
                <th>发布人</th>
                <th>图片</th>
                <th>是否出租</th>
                <th>信息状态</th>
                <th style="text-align:center;">操作</th>
            </tr>
            </thead>
            <tbody>
                <% 
                 foreach (myhouse.Model.House house in houseList)
                 {%>        
                    <tr >
                        <td><input type="checkbox" name="check" value="<%=house.hid %>"/></td>
                        <td><%=house.hid %></td>
                        <td><%=house.hname %></td>
                        <td><%=house.housetype.ttype %></td>
                        <td><%=house.section.sname %></td>
                        <td><%=house.hsize %></td>
                        <td><%=house.hfloor %></td>
                        <td><%=house.hmoney %></td>
                        <td><%=house.hcommunity %></td>
                        <td><%=house.area.areaname %></td>
                        <td><%=house.hadress %></td>
                        <td><%=house.hdescription %></td>
                        <td><%=house.htime %></td>
                        <td><%=house.userinfo.uname %></td>
                        <td style="padding:4px; text-align:center;">
                            <img alt="" src="<%=house.hphotoone %>" style="width: 80px; height: 80px; border-radius:2px;">
                        </td>
                        <%
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
                        %>

                        <td style="text-align:center; padding:0;">
                            <%
                                if (((myhouse.Model.Worker)Session["adminInfo"]).wtype == "0   ")
                                {%>
                                    <%if (house.hstatus == 0)
                                        {%>
                                        <button class="layui-btn layui-btn-small layui-btn-normal" style="margin-bottom:4px;width:68px;" onclick="myreview(<%=house.hid %>)">通过</button><br />
                                        <button class="layui-btn layui-btn-small layui-btn-danger" style="width:68px;" onclick="mynoreview(<%=house.hid %>)">不通过</button>
                                    <% }
                                        else
                                        {%>
                                        <button class="layui-btn layui-btn-small layui-btn-disabled" style="width:68px;">禁用</button>
                                        <%}
                                      %>
                                    
                                <%}
                                else if(((myhouse.Model.Worker)Session["adminInfo"]).wtype == "1   ")
                                {%>
                                    <button id="" class="layui-btn layui-btn-small layui-btn-normal" style="margin-bottom:4px;" onclick="myupdate(<%=house.hid %>, '<%=house.hname %>', <%=house.htype %>, <%=house.sid %>, '<%=house.hsize %>', '<%=house.hfloor %>', '<%=house.hmoney %>', '<%=house.hcommunity %>', <%=house.harea %>, '<%=house.hadress %>', '<%=house.hdescription %>', '<%=house.hphotoone %>', '<%=house.hphototwo %>', '<%=house.hphotothree %>', '<%=house.hphotofour %>', <%=house.hmode %>, <%=house.hstatus %>)">修改</button><br />
                                <%}
                                else if(((myhouse.Model.Worker)Session["adminInfo"]).wtype == "2   " || ((myhouse.Model.Worker)Session["adminInfo"]).wtype == "8   ")
                                {%>
                                    <button id="myupdate" class="layui-btn layui-btn-small layui-btn-normal" style="margin-bottom:4px;" onclick="myupdate(<%=house.hid %>, '<%=house.hname %>', <%=house.htype %>, <%=house.sid %>, '<%=house.hsize %>', '<%=house.hfloor %>', '<%=house.hmoney %>', '<%=house.hcommunity %>', <%=house.harea %>, '<%=house.hadress %>', '<%=house.hdescription %>', '<%=house.hphotoone %>', '<%=house.hphototwo %>', '<%=house.hphotothree %>', '<%=house.hphotofour %>', <%=house.hmode %>, <%=house.hstatus %>)">修改</button><br />
                                    <button class="layui-btn layui-btn-small layui-btn-danger" onclick="mydelete(<%=house.hid %>)">删除</button>
                                <%}
                                else
                                {%>
                                    <button class="layui-btn layui-btn-small layui-btn-disabled">禁用</button>
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

            <%--弹出层，修改房屋信息--%>
        <div id="updatehouse" class="layui-elem-field layui-field-title" style="display:none;">
            <div class="layui-col-md10" style="padding-right:0px;">
                <form class="layui-form layui-form-pane" id="fm" action="/MyAdmin/HouseList.aspx" method="post" enctype="multipart/form-data">

                    <input type="hidden" id="hid" name="hid" value=""/>

                    <div class="layui-form-item">
                        <label class="layui-form-label">房屋名称</label>
                        <div class="layui-input-block">
                            <input type="text" id="name" name="name" autocomplete="off" placeholder="请输入房屋名称" class="layui-input"/>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">房屋板块</label>
                        <div class="layui-input-block">
                            <select name="section" id="section">
                                <%
                                    foreach (myhouse.Model.Section section in sectionList)
                                    {%>
                                        <option value="<%=section.sid%>"><%=section.sname %></option>
                                    <%}
                                %>
                            </select>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">房屋类型</label>
                        <div class="layui-input-block">
                            <select style="width:auto;" name="tid" id="tid">
                                <option value="">请选择房屋类型</option>
                                <%
                                    foreach (myhouse.Model.Housetype housetype in hyList)
                                    {%>
                                        <option value="<%=housetype.tid %>"><%=housetype.ttype %></option>
                                    <%}
                                %>
                            </select>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">房屋面积</label>
                        <div class="layui-input-block">
                            <input type="text" id="size" name="size" autocomplete="off" placeholder="请输入房屋面积" class="layui-input"/>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">房屋楼层</label>
                        <div class="layui-input-block">
                            <input type="text" id="floor" name="floor" autocomplete="off" placeholder="请输入房屋楼层" class="layui-input"/>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">房屋租金</label>
                        <div class="layui-input-block">
                            <input type="text" id="money" name="money" autocomplete="off" placeholder="请输入房屋租金" class="layui-input"/>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">所在小区</label>
                        <div class="layui-input-block">
                            <input type="text" id="community" name="community" autocomplete="off" placeholder="请输入所在小区" class="layui-input"/>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">所在地区</label>
                        <div class="layui-input-block">
                            <select style="width:auto;" name="area" id="area">
                                <option value="">请选择地区</option>
                            <%
                                foreach (myhouse.Model.Area area in areaList )
                                {%>
                                    <option value="<%=area.areaid %>"><%=area.areaname %></option>
                                <%}
                            %>
                            </select>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">详细地址</label>
                        <div class="layui-input-block">
                            <input type="text" id="adress" name="adress" autocomplete="off" placeholder="请输入详细地址" class="layui-input"/>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">房屋描述</label>
                        <div class="layui-input-block">
                            <textarea name="description" id="description" placeholder="请输入房屋描述" class="layui-input" style="height:120px;"></textarea>
                        </div>
                    </div>
                    <div class="layui-form-item" >
                        <div class="layui-input-block" style="float:left;" >
                            <input type="file" name="photo1" id="simg1" style="display:none;"/>
                            <img id="imgPr1" style="width: 80px; height: 80px; border-radius:10px; " src="/Images/House/wu.jpg" /><br /><br />
                            <label class="fileLabel" for="simg1">图片一</label>
                        </div>
                        <div class="layui-input-block" style="float:left;margin-left:69px;">
                            <input type="file" name="photo2" id="simg2" style="display:none;"/>
                            <img id="imgPr2" style="width: 80px; height: 80px; border-radius:10px; " src="/Images/House/wu.jpg" /><br /><br />
                            <label class="fileLabel" for="simg2">图片二</label>
                        </div>
                        <div class="layui-input-block" style="float:left; margin-left:69px;">
                            <input type="file" name="photo3" id="simg3" style="display:none;"/>
                            <img id="imgPr3" style="width: 80px; height: 80px; border-radius:10px; " src="/Images/House/wu.jpg" /><br /><br />
                            <label class="fileLabel" for="simg3">图片三</label>
                        </div>
                        <div class="layui-input-block" style="float:left; margin-left:69px;">
                            <input type="file" name="photo4" id="simg4" style="display:none;"/>
                            <img id="imgPr4" style="width: 80px; height: 80px; border-radius:10px; " src="/Images/House/wu.jpg" /><br /><br />
                            <label class="fileLabel" for="simg4">图片四</label>
                        </div>
                    </div>
                    <input type="hidden" id="housephoto1" name="housephoto1" value="" />
                    <input type="hidden" id="housephoto2" name="housephoto2" value=""/>
                    <input type="hidden" id="housephoto3" name="housephoto3" value=""/>
                    <input type="hidden" id="housephoto4" name="housephoto4" value=""/>

                    <div class="layui-form-item">
                        <label class="layui-form-label">是否审核</label>
                        <div class="layui-input-block">
                            <select style="width:auto;" name="status" id="status">
                                <option value="">请选择...</option>
                                <option value="0">待审核</option>
                                <option value="1">已审核</option>
                                <option value="2">不合法</option>
                            </select>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">是否出租</label>
                        <div class="layui-input-block">
                            <select style="width:auto;" name="mode" id="mode">
                                <option value="">请选择...</option>
                                <option value="0">未出租</option>
                                <option value="1">已出租</option>
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
