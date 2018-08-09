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
    <h1 style="font-size:30px;">蛋炒饭不加蛋</h1>
    <input type="hidden" id="c1" value="80"/>

<!-- 为 ECharts 准备一个具备大小（宽高）的 DOM -->
<div id="main-line" style="width: 100%;height:400px;"></div>

<div id="main-bing" style="width: 50%;height:400px;"></div>

<div>
    <% 

    %>
    


</div>


<script type="text/javascript" src="/MyAdmin/frame/layui/layui.js"></script>
<script type="text/javascript" src="/MyAdmin/frame/echarts/echarts.min.js"></script>
<script src="/MyAdmin/js/jquery-1.11.1.js"></script>
<script type="text/javascript">

    // 基于准备好的dom，初始化echarts实例
    var myChart = echarts.init(document.getElementById('main-line'));

    //var newArr = new Array();
    //newArr.push($("#c1").val());

    var c1 = $("#c1").val();

    var t1 = "衬衫";

    //////bar line piek
    //-------------------------

    
 

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
            data: [t1, "羊毛衫", "雪纺衫", "裤子", "高跟鞋", "袜子", t1, "羊毛衫", "雪纺衫", "裤子", "高跟鞋", "袜子"]
        },
        yAxis: {},
        series: [{
            name: '数量',
            type: 'bar',
            data: [c1, 20, 36, 10, 10, 20, c1, 20, 36, 10, 10, 20]
        }]
    });

    $.post("/MyAdmin/AdminIndex.aspx","", function (data) {
        var varReceiver = JSON.parse(data);
        alert(varReceiver);
    }, "JSON")

    //$.ajax({
    //    type: "post",
    //    url: "/MyAdmin/AdminIndex.aspx",
    //    dataType: "json",
    //    success: function (date) {

    //        var varReceiver = data;
    //        //var varReceiver = jQuery.parseJSON(data);
    //        //var a1 = JSON.parse(data)

    //        var varAxis = new Array();
    //        //alert(data)
    //        //alert(varReceiver);

    //        var varSeries = new Array(varReceiver.Count[0].total);

    //        for (var i = 0; i < varReceiver.Count[0].total; i++) {
    //            varAxis.push(varReceiver.Rows[i].sname);
    //            varSeries[i] = varReceiver.Rows[i].housecount;
    //        }
    //        // 填入数据
    //        myChart.setOption({
    //            xAxis: {
    //                data: varAxis
    //            },
    //            series: [{
    //                //根据名字对应到相应的系列
    //                name: '数量',
    //                data: varSeries
    //            }]
    //        });
    //    },
    //    error: function (XMLHttpRequest, textStatus, errorThrown) {
    //        alert(errorThrown);
    //    }
    //});

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
