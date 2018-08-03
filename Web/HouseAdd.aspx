<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HouseAdd.aspx.cs" Inherits="myhouse.Web.HouseAdd" %>

<!DOCTYPE HTML>
<html>
<head>
<meta charset="utf-8">
<meta name="renderer" content="webkit|ie-comp|ie-stand">
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
<meta http-equiv="Cache-Control" content="no-siteapp" />
<!--[if lt IE 9]>
<script type="text/javascript" src="lib/html5shiv.js"></script>
<script type="text/javascript" src="lib/respond.min.js"></script>
<![endif]-->
<link rel="stylesheet" type="text/css" href="static/h-ui/css/H-ui.min.css" />
<link rel="stylesheet" type="text/css" href="static/h-ui.admin/css/H-ui.admin.css" />
<link rel="stylesheet" type="text/css" href="lib/Hui-iconfont/1.0.8/iconfont.css" />
<link rel="stylesheet" type="text/css" href="static/h-ui.admin/skin/default/skin.css" id="skin" />
    <link href="static/h-ui.admin/css/style.css" rel="stylesheet" />
<!--[if IE 6]>
<script type="text/javascript" src="lib/DD_belatedPNG_0.0.8a-min.js" ></script>
<script>DD_belatedPNG.fix('*');</script>
<![endif]-->
<title>发布新的房屋租赁信息</title>
<link href="lib/webuploader/0.1.5/webuploader.css" rel="stylesheet" type="text/css" />
    
</head>

<body>

<div id="header"  style="width: 100%; margin: 0 auto;">
        <% Server.Execute("/common/Top.aspx"); %>     <%--Execute是从当前页面转移到指定页面，并将执行返回到当前页面--%>
</div>

<div class="page-container">
	<form class="form form-horizontal"  runat="server" enctype="multipart/form-data">
        <h1 style="text-align:center;color:limegreen;">添加房屋信息</h1>
		<div class="row cl">
			<label class="form-label col-xs-4 col-sm-2"><span class="c-red">*</span>房屋名称：</label>
			<div class="formControls col-xs-8 col-sm-9">
				<input type="text" class="input-text" value="" placeholder="" id="" name="hname">
			</div>
		</div>
        <div class="row cl">
			<label class="form-label col-xs-4 col-sm-2"><span class="c-red">*</span>房屋板块：</label>
			<div class="formControls col-xs-8 col-sm-9">
				<span class="select-box">
				<select name="sid" class="select">
                    <option value="">请选择...</option>
                    <%
                        foreach (myhouse.Model.Section section in sectionList)
                        {%>
                            <option value="<%=section.sid %>"><%=section.sname %></option>
                        <%}
                    %>
				</select>
				</span>
			</div>
		</div>
        <div class="row cl">
			<label class="form-label col-xs-4 col-sm-2"><span class="c-red">*</span>房屋类型：</label>
			<div class="formControls col-xs-8 col-sm-9">
				<span class="select-box">
				<select name="htype" class="select">
                    <option value="">请选择...</option>
                    <%
                        foreach (myhouse.Model.Housetype housetype in hyList)
                        {%>
                            <option value="<%=housetype.tid %>"><%=housetype.ttype %></option>
                        <%}

                    %>
				</select>
				</span>
			</div>
		</div>
		<div class="row cl">
			<label class="form-label col-xs-4 col-sm-2">房屋面积 m²：</label>
			<div class="formControls col-xs-8 col-sm-9">
				<input type="text" class="input-text" value="" placeholder="" id="" name="hsize">
			</div>
		</div>
		
		<div class="row cl">
			<label class="form-label col-xs-4 col-sm-2">房屋楼层：</label>
			<div class="formControls col-xs-8 col-sm-9">
				<input type="text" class="input-text" value="" placeholder="" id="" name="hfloor">
			</div>
		</div>
        <div class="row cl">
			<label class="form-label col-xs-4 col-sm-2">房屋租金：</label>
			<div class="formControls col-xs-8 col-sm-9">
				<input type="text" class="input-text" value="" placeholder="" id="" name="hmoney">
			</div>
		</div>
        
        <div class="row cl">
			<label class="form-label col-xs-4 col-sm-2">所在小区：</label>
			<div class="formControls col-xs-8 col-sm-9">
				<input type="text" class="input-text" value="" placeholder="" id="" name="hcommunity">
			</div>
		</div>
        <div class="row cl">
			<label class="form-label col-xs-4 col-sm-2"><span class="c-red">*</span>所在地区：</label>
			<div class="formControls col-xs-8 col-sm-9">
				<span class="select-box">
				<select name="harea" class="select">
					<option value="">请选择...</option>
                     <%
                        foreach (myhouse.Model.Area area in areaList)
                        {%>
                            <option value="<%=area.areaid %>"><%=area.areaname %></option>
                        <%}

                    %>
					
				</select>
				</span>
			</div>
		</div>

        <div class="row cl">
			<label class="form-label col-xs-4 col-sm-2">详细地址：</label>
			<div class="formControls col-xs-8 col-sm-9">
				<input type="text" class="input-text" value="" placeholder="" id="" name="hadress">
			</div>
		</div>

        <div class="row cl">
			<label class="form-label col-xs-4 col-sm-2">房屋描述：</label>
			<div class="formControls col-xs-8 col-sm-9">
				<%--<input type="text" class="input-text" value="" placeholder="" id="" name="">--%>
                <textarea name="hdescription" id="content"  cols="50" class="input-text" style="height:80px;" ></textarea>
			</div>
		</div>

		
		<div class="row cl">   
            <label class="form-label col-xs-4 col-sm-2">房屋图片：</label>            
		</div>

        <div style="margin-left:240px; width:auto;float:left; margin-bottom:30px;">
            <div style="float:left;">
                <input type="file" name="photo1" id="simg" style="display:none;"/>
                <img id="imgPr" style="width: 120px; height: 120px; border-radius:10px; " src="/img/wu.jpg" /><br /><br />
                <label class="fileLabel" for="simg" style="margin-left:20px;">主图</label>
            </div>
            <div style="float:left;">
                <input type="file" name="photo2" id="simg2" style="display:none;"/>
                <img id="imgPr2" style="width: 120px; height: 120px;  border-radius:10px; " src="/img/wu.jpg" /><br /><br />
                <label class="fileLabel" for="simg2" style="margin-left:20px;">图2</label>
            </div>
            <div style="float:left;">
                <input type="file" name="photo3" id="simg3" style="display:none;"/>
                <img id="imgPr3" style="width: 120px; height: 120px;  border-radius:10px; " src="/img/wu.jpg" /><br /><br />
                <label class="fileLabel" for="simg3" style="margin-left:20px;">图3</label>
            </div>
            <div style="float:right;">
                <input type="file" name="photo4" id="simg4" style="display:none;"/>
                <img id="imgPr4" style="width: 120px; height: 120px;  border-radius:10px; " src="/img/wu.jpg" /><br /><br />
                <label class="fileLabel" for="simg4" style="margin-left:20px;">图4</label>
            </div>
        </div>
        <input name="hmode" type="hidden" value="1"/> <%--房屋未出租--%>
        <input name="hstatus" type="hidden" value="0"/> <%--房屋信息未审核--%>

		<div class="row cl">
			<div class="col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-2">
				<input type="submit"; class="btn btn-primary radius" style="background-color:limegreen; border-color:white;" value="保存并提交审核" />
				<button onclick="myback()" class="btn btn-default radius" type="button">&nbsp;&nbsp;取消&nbsp;&nbsp;</button>
			</div>
		</div>
	</form>
</div>


<!--_footer 作为公共模版分离出去-->
<script type="text/javascript" src="lib/jquery/1.9.1/jquery.min.js"></script> 
<script type="text/javascript" src="lib/layer/2.4/layer.js"></script>
<script type="text/javascript" src="static/h-ui/js/H-ui.min.js"></script> 
<script type="text/javascript" src="static/h-ui.admin/js/H-ui.admin.js"></script> <!--/_footer /作为公共模版分离出去-->

<!--请在下方写此页面业务相关的脚本-->
<script type="text/javascript" src="lib/jquery.validation/1.14.0/jquery.validate.js"></script> 
<script type="text/javascript" src="lib/jquery.validation/1.14.0/validate-methods.js"></script> 
<script type="text/javascript" src="lib/jquery.validation/1.14.0/messages_zh.js"></script> 
<script type="text/javascript" src="lib/webuploader/0.1.5/webuploader.min.js"></script> 
<script src="MyAdmin/js/uploadPreview.min.js"></script>

<script type="text/javascript">
    function myback()
    {
        //关闭当前页面
        window.close();  
    }

    $(function () {
        $("#simg").uploadPreview({ Img: "imgPr", Width: 220, Height: 200 });
        $("#simg2").uploadPreview({ Img: "imgPr2", Width: 220, Height: 200 });
        $("#simg3").uploadPreview({ Img: "imgPr3", Width: 220, Height: 200 });
        $("#simg4").uploadPreview({ Img: "imgPr4", Width: 220, Height: 200 });

    });
</script>


<style type="text/css">
        .fileLabel{
          display: inline-block;
          width:80px;
          height: 30px;
          text-align: center;
          border: 1px solid #8cc051;
          border-radius: 5px;
          background-color:limegreen;
          cursor: pointer;
          margin-right:80px;
          color:white;
        }
    </style>

</body>
</html>
