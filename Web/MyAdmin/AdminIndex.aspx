<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminIndex.aspx.cs" Inherits="myhouse.Web.MyAdmin.AdminIndex" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="renderer" content="webkit">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <title>地图插件</title>
    <link rel="stylesheet" href="/MyAdmin/frame/layui/css/layui.css">
    <link rel="stylesheet" href="/MyAdmin/frame/static/css/style.css">
    <%--<link rel="icon" href="/MyAdmin/frame/static/image/code.png">--%>
</head>
<body class="body">

<!-- 为 ECharts 准备一个具备大小（宽高）的 DOM -->
<div id="main-line" style="width: 100%;height:400px;"></div>

<div id="main-bing" style="width: 50%;height:400px; float:left;"></div>

<div id="main-bing2" style="width: 50%;height:400px; float:right;"></div>


<script type="text/javascript" src="/MyAdmin/frame/layui/layui.js"></script>
<script type="text/javascript" src="/MyAdmin/frame/echarts/echarts.min.js"></script>
<script src="/MyAdmin/js/jquery-1.11.1.js"></script>
<script type="text/javascript">

    //在 layui 中使用 layer  
    layui.use('layer', function () {
        var layer = layui.layer;
    });

    //--------------------------
    //////bar line pie  不同图形
    //--------------------------

//==============================<各板块下房屋数量统计>====================================//

    // 基于准备好的dom，初始化echarts实例
    var myChart = echarts.init(document.getElementById('main-line'));

    // 使用刚指定的配置项和数据显示图表。
    myChart.setOption({
        title: {
            text: '<各板块下房屋数量统计>'
        },
        tooltip: {},
        legend: {
            data:['数量']
        },
        xAxis: {
            data: []
        },
        yAxis: {},
        series: [{
            name: '数量',
            type: 'bar',
            data: []
        }]
    });
   
    $.ajax({
        type: "post",
        url: "/MyAdmin/AdminIndex.aspx?flag=sname",
        dataType: "JSON",
        success: function (data) {
            var varReceiver = data;
            //alert(varReceiver);

            //var varReceiver = jQuery.parseJSON(data);  
            //var varReceiver = JSON.parse(data);     //不需要转换为对象

            var varAxis = new Array();

            var varSeries = new Array();

            for (var i = 0; i < Object.keys(varReceiver).length ; i++) {
                varAxis[i] = varReceiver[i].sname;
                varSeries[i] = varReceiver[i].housecount;
            }

            //alert(varAxis);  //所有sname

            // 填入数据
            myChart.setOption({
                xAxis: {
                    data: varAxis
                },
                series: [{
                    //根据名字对应到相应的系列
                    name: '数量',
                    data: varSeries
                }]
            });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(errorThrown);
            layer.msg('数据加载失败!请刷新此页面...', { icon: 5 });
        }
    });


//==============================<用户类型统计>==================================//

    // 基于准备好的dom，初始化echarts实例
    var chart_house = echarts.init(document.getElementById('main-bing'));

    // 配置
    chart_house.setOption({
        title: {
            text: '<用户类型统计>'
        },
        series : [
            {
                name: '用户类型统计',
                type: 'pie',
                radius: '55%',
                //data:[
                //    {value:28, name:'搜索引擎'},
                //    {value:7, name:'直接访问'},
                //    {value:2, name:'邮件营销'},
                //    {value:30, name:'联盟广告'},
                //    {value:22, name:'视频广告'}
                //]
                data: [],

            }
        ]
    });

    $.ajax({
        type: "post",
        url: "/MyAdmin/AdminIndex.aspx?flag=usertype",
        dataType: "JSON",
        success: function (data) {
            //将json对象转换为字符串
            //var usertype = JSON.stringify(data);

            var res = [];
            //通过把usertype进行遍历循环来获取数据并放入Echarts中
            for (var i = 0; i < Object.keys(data).length ; i++) {
                res.push({
                    name: data[i].usertype,
                    value: data[i].usercount
                });
            }

            // 填入数据
            chart_house.setOption({
                series: [{
                    //根据名字对应到相应的系列
                    name: '用户类型统计',
                    data: res
                }]
            });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });

//======================<房屋发布统计>========================================//

    // 基于准备好的dom，初始化echarts实例
    var chart = echarts.init(document.getElementById('main-bing2'));

    // 配置
    chart.setOption({
        title: {
            text: '<房屋发布统计>'
        },
        series: [
            {
                name: '访问来源',
                type: 'pie',
                radius: '55%',
                data: [
                    { value: 28, name: '搜索引擎' },
                    { value: 7, name: '直接访问' },
                    { value: 2, name: '邮件营销' },
                    { value: 30, name: '联盟广告' },
                    { value: 22, name: '视频广告' }
                ]
            }
        ]
    });




    layui.use(['element'], function(){
        var element = layui.element
            ,$      = layui.jquery;

        // you code ...


    });
</script>
</body>
</html>
