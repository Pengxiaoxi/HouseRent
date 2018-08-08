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
    <link rel="icon" href="/MyAdmin/frame/static/image/code.png">
</head>
<body class="body">
    <h1 style="font-size:30px;">蛋炒饭不加蛋</h1>
<!-- 为 ECharts 准备一个具备大小（宽高）的 DOM -->
<%--<div id="main-line" style="width: 100%;height:400px;"></div>

<div id="main-bing" style="width: 100%;height:400px;"></div>--%>

<script type="text/javascript" src="/MyAdmin/frame/layui/layui.js"></script>
<script type="text/javascript" src="/MyAdmin/frame/echarts/echarts.min.js"></script>
<script type="text/javascript">

    // 基于准备好的dom，初始化echarts实例
    var myChart = echarts.init(document.getElementById('main-line'));


    // 使用刚指定的配置项和数据显示图表。
    myChart.setOption({
        title: {
            text: '信息统计'
        },
        tooltip: {},
        legend: {
            data:['数量']
        },
        xAxis: {
            data: ["衬衫","羊毛衫","雪纺衫","裤子","高跟鞋","袜子"]
        },
        yAxis: {},
        series: [{
            name: '数量',
            type: 'bar',
            data: [5, 20, 36, 10, 10, 20]
        }]
    });

    // 基于准备好的dom，初始化echarts实例
    var chart = echarts.init(document.getElementById('main-bing'));

    // 配置
    chart.setOption({
        series : [
            {
                name: '访问来源',
                type: 'pie',
                radius: '55%',
                data:[
                    {value:28, name:'搜索引擎'},
                    {value:7, name:'直接访问'},
                    {value:2, name:'邮件营销'},
                    {value:30, name:'联盟广告'},
                    {value:22, name:'视频广告'}
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
