﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HouseDetails.aspx.cs" Inherits="myhouse.Web.HouseDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>房屋详情</title>
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/static/h-ui.admin/css/style.css" rel="stylesheet" />
    
    <script src="/MyAdmin/js/jquery-1.11.1.js"></script>
    <script src="/MyAdmin/frame/layui/layui.js"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/api?key=olGdVWrNbUSZLxTNnppasdzz6Sw845D6&v=1.1&services=true"></script>
    <script type="text/javascript" src="/MyAdmin/js/jquery-1.11.1.js"></script>

    <style type="text/css">
        div,ul,li,a,img{margin:0;padding:0;}

        html,body{margin:0;padding:0;}
        .iw_poi_title {color:#CC5522;font-size:14px;font-weight:bold;overflow:hidden;padding-right:13px;white-space:nowrap}
        .iw_poi_content {font:12px arial,sans-serif;overflow:visible;padding-top:4px;white-space:-moz-pre-wrap;word-wrap:break-word}
    </style>

    <script>
        //返回
        function back()
        {
            window.history.back();
        }

        //在 layui 中使用 layer 
        layui.use('layer', function () {
            var layer = layui.layer;
        });

        //收藏功能
        function mycollect(hid) {
            //var hid = document.getElementById("collect").innerHTML;
            //alert(hid);
            var strSession = "<%=Session["userInfo"]%>".toString();
            if (strSession == "") {
                layer.alert("请先登录!");
            }
            else {
                $.post("/HouseDetails.aspx?flag=collect", { hid: hid }, function (result) {
                    //alert(result);
                    if (result == "True") {
                        document.getElementById("collect").innerHTML = "已收藏"
                        layer.msg("收藏成功!", { icon: 1 });
                    } else {                
                        document.getElementById("collect").innerHTML = "未收藏"
                        layer.msg("取消收藏成功!", { icon: 1 })
                    }
                });
            }
        };

        //举报房屋信息打开弹出层
        function reporthouse(hid)
        {
            var strSession = "<%=Session["userInfo"]%>".toString();
            if (strSession == "") {
                layer.alert("请先登录!", { icon: 5 });
            }
            else {
                $("#hid").val(hid);

                layer.open({
                    type: 1,
                    title: '提示：',
                    area: ['600px', '300px'],
                    offset: '150px',
                    anim: 1,
                    skin: "myclass",
                    shade: 0.1,
                    content: $("#reportdiv"),
                    end: function () {
                        $("#reportdiv").hide();
                    },
                });
            }           
        }

        //提交举报信息
        function myreport()
        {
            if ($("#reportcontent").val() == "") {
                layer.msg('请先填写举报原因...', { icon: 5 });
            }
            else {
                layer.confirm('您确定要举报此条房屋信息吗?', { icon: 3, title: '提示' }, function (index) {
                    $.post("/HouseDetails.aspx?flag=report", $("#fm").serialize(), function (result) {
                        if (result) {
                            layer.msg('举报成功！', { icon: 1 });
                            setTimeout("location.reload(true)", 500);  //延迟800ms执行
                        }
                        else {
                            layer.msg('举报信息提交遇到点问题，再试试吧...', { icon: 5 });
                        }
                    }, "text");
                });
            }
        }

        //关闭弹出层
        function myclose() {
            //resetValue();
            $("#hid").val("");
            $("#reportcontent").val("");

            //var form = layui.form;
            //form.render();   //表单重新渲染

            layer.closeAll();
        };

    </script>
</head>

<body>

    <div id="header" class="wrap" style="width: 100%; margin: 0 auto;">
        <% Server.Execute("/common/Top.aspx"); %>
    </div>

<form id="form1" runat="server">
    <div style="width:auto; height:auto;">
		<div class="details">
            <%--房屋图片轮播--%>
            <div id="container">
                <%--<b style="left:10px; color:limegreen;">房屋图片</b>--%>
                <ul class="pic">
                    <li><a href="javascript:;"><img src="<%=house.hphotoone %>" alt="pic1"/></a></li>
                    <li><a href="javascript:;"><img src="<%=house.hphototwo %>" alt="pic2"/></a></li>
                    <li><a href="javascript:;"><img src="<%=house.hphotothree %>" alt="pic3"/></a></li>
                    <li><a href="javascript:;"><img src="<%=house.hphotofour %>" alt="pic1"/></a></li>
                </ul>
            </div>
					<div class="details-font">
                        <div class="details-href"> 
                            <b style="text-decoration:none; color:green;"><font style="font-size: 30px;font-weight: bold;"><%=house.hname %></font>&nbsp;&nbsp;
                            <button type="button" class="details-report" id="report" onclick="reporthouse(<%=house.hid %>)">举报</button>
                            </b>
                        </div>

                        <div class="details-b">
                            <strong>房屋屋主：</strong><font style="color:orangered"><%=house.userinfo.uname %></font><br />
                            <strong>联系方式：</strong><a><%=house.userinfo.utel %></a><br /> 
                            <strong>房屋类型：</strong><%=housetype %><br /> 
                            <strong>所在板块：</strong><%=housesection %><br /> 
                            <strong>房屋大小：</strong><%=house.hsize %>平方米<br />
                            <strong>房屋租金：</strong><font style="color:orangered"><%=house.hmoney %>￥</font><br /> 
                            <strong>房屋楼层：</strong><%=house.hfloor %>楼<br /> 
                            <strong>所在小区：</strong><%=house.hcommunity %><br /> 
                            <strong>所在地区：</strong><%=housearea %><br />
                            <strong>详细地址：</strong><%=house.hadress %><br />
                            <strong>发布时间：</strong><font style="color:orangered"><%=house.htime %></font><br /> 
                            <strong>房屋描述：</strong><%=house.hdescription %><br /> 
                            <% 
                            if (house.contract == null)
                                {%>
                                <button type="button" class="details-back" style="float:left;" id="collect" onclick="mycollect(<%=house.hid %>)">未收藏</button>
                            <%}
                            else
                            {%>
                                <button type="button" class="details-back" style="float:left;" id="collect" onclick="mycollect(<%=house.hid %>)">已收藏</button>
                                <%}
                            %>
                            <input class="details-back" type="button" onclick="back()" value="返回"/>
                        </div>
					</div>           
		</div>
         <!--百度地图容器-->
        <%--<p>团城山至尊门第</p>--%>
        <div class="details-map" id="dituContent"></div>

        <div>
             <input type="hidden" id="houseadress" value="<%=houseadress %>"/>
             <input type="hidden" id="housecommunity" value="<%=housecommunity %>"/>
        </div>

        <div class="recommend">
            <div class="r1" style="width:80px;">
                <a>猜你喜欢</a> 
            </div>
            <div class="details-img">
                <ul>
                    <%
                        foreach (myhouse.Model.House tj in tjhouse)
                        {%>
                            <li>
                                <div style="">
                                    <a href="HouseDetails.aspx?hid=<%=tj.hid %>"><img alt="" src="<%=tj.hphotoone %>" /></a>
                                </div>
                            </li>
                        <%}
                    %> 
                    <li>
                        <div style="">
                            <% 
                                if (tjhouse.Count == 0)
                                {%>
                                    <b style="font-size:20px; ">&nbsp;&nbsp;:)暂无推荐...</b>
                                <%}
                            %>    
                        </div>
                    </li>
                </ul>
			</div>
        </div>         
     </div>
</form>
    <%--举报div弹出--%>
    <div id="reportdiv" style="display:none;">
      <form action="/HouseDetails.aspx" method="post" id="fm">
        <h3 style="text-align:center;">举报房屋信息</h3>
		<div style="text-align:center;">
			<label>请输入举报原因：</label>
			<div >
				<input type="hidden" id="hid" name="hid" value=""/>
                <textarea style="width:450px;height:100px;" name="reportcontent" id="reportcontent"></textarea>
			</div>
		</div>
          <div style="margin:0 70px;">
              <button type="button" class="details-back" style="float:left;" onclick="myclose()">取消</button>
              <button type="button" class="details-back" style="background-color:orangered;" onclick="myreport()" >举报</button>
          </div>
      </form>
    </div>


    <%--地图--%>
    <script type="text/javascript">
    //创建和初始化地图函数：
    function initMap(){
        createMap();//创建地图
        setMapEvent();//设置地图事件
        addMapControl();//向地图添加控件
    }
    
    //=========
    // 创建地址解析器实例
    var myGeo = new BMap.Geocoder();
    // 将地址解析结果显示在地图上,并调整地图视野
    myGeo.getPoint($("#houseadress").val(), function (point) {
        if (point) {
            map.centerAndZoom(point, 15);
            map.addOverlay(new BMap.Marker(point));

            var marker = new BMap.Marker(point);  // 创建标注
            map.addOverlay(marker);              // 将标注添加到地图中

            var label = new BMap.Label($("#housecommunity").val(), { offset: new BMap.Size(10, -50) });
            label.setStyle({  //文字标签样式
                color: "white",
                background: "orangered",
                fontSize: "16px",
                height: "20px",
                lineHeight: "20px",
                fontFamily: "微软雅黑"
            });
            marker.setLabel(label);

            var circle = new BMap.Circle(point, 240, { strokeColor: "limegreen", strokeWeight: 1, strokeStyle: 'solid', fillColor: "limegreen", fillOpacity: 0.1 });  //设置覆盖物的颜色边框透明度等
            map.addOverlay(circle);            //增加圆
            hideOver();

        } else {
            //alert("您选择地址没有解析到结果!");
            alert("地址有点问题暂时没有地图信息!");
        }
    }, "黄石市");
    //=========

    //创建地图函数：
    function createMap(){
        var map = new BMap.Map("dituContent");//在百度地图容器中创建一个地图
        var point = new BMap.Point(115.03,30.20);//定义一个中心点坐标（黄石）
        map.centerAndZoom(point,16);//设定地图的中心点和坐标并将地图显示在地图容器中
        window.map = map;//将map变量存储在全局  
    }
    
    //地图事件设置函数：
    function setMapEvent(){
        map.enableDragging();//启用地图拖拽事件，默认启用(可不写)
        map.enableScrollWheelZoom();//启用地图滚轮放大缩小
        map.enableDoubleClickZoom();//启用鼠标双击放大，默认启用(可不写)
        map.enableKeyboard();//启用键盘上下左右键移动地图
    }
    
    //地图控件添加函数：
    function addMapControl(){
        //向地图中添加缩放控件
	var ctrl_nav = new BMap.NavigationControl({anchor:BMAP_ANCHOR_TOP_LEFT,type:BMAP_NAVIGATION_CONTROL_SMALL});
	map.addControl(ctrl_nav);
        //向地图中添加缩略图控件
	var ctrl_ove = new BMap.OverviewMapControl({anchor:BMAP_ANCHOR_BOTTOM_RIGHT,isOpen:0});
	map.addControl(ctrl_ove);
        //向地图中添加比例尺控件
	var ctrl_sca = new BMap.ScaleControl({anchor:BMAP_ANCHOR_BOTTOM_LEFT});
	map.addControl(ctrl_sca);
    }
    initMap();//创建和初始化地图
</script>

</body>
</html>
