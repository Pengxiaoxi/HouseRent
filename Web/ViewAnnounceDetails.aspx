<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAnnounceDetails.aspx.cs" Inherits="myhouse.Web.ViewAnnounceDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/style-announce.css" rel="stylesheet" />

    <script>
        function back()
        {
            window.history.go(-1);
        }
    </script>

</head>
<body>

    <div id="header" class="wrap" style="width: 100%; margin: 0 auto;">
        <% Server.Execute("/common/Top.aspx"); %>     <%--Execute是从当前页面转移到指定页面，并将执行返回到当前页面--%>
    </div>

     	<div class="newssub_big">
    	<div class="newssub_content">
        	<div class="newssub_content_top">
                <h2><%=announce.atitle %></h2>
                <div class="newssub_title mt10 mb10">
            	    <span>发布日期：<font style="color:orangered;"><%=announce.atime %></font> &nbsp;&nbsp;&nbsp;&nbsp;发布人：[<font style="color:orangered;"><%=announce.worker.wname %></font>]&nbsp;
                        <%
                            if (announce.atype == "1   ")
                            {%>
                                <font style="color:orangered;">重要通知</font>
                            <%}
                            
                             %>
            	    </span>
                    <br />
                    <br />
                    <%--<div class="newssub_share">
                	    <i>分享到：</i>
                        <ul>
                            <li><a href=""><img src="/img/share_wb.png"></a></li>
                            <li><a href=""><img src="/img/share_wx.png"></a></li>
                            <li><a href=""><img src="/img/qqzoom.png"></a></li>
                            <div class="clear"></div>
                        </ul>
                    </div><div class="clear"></div>--%>
                </div>
           </div>
            <div class="news_news mt20 pb30">
            	<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%=announce.acontent %></p>

            </div>
        </div>
    </div>
 
 	<div class="column_big mb10 mt10">
    	<div class="column">
        	<p><a onclick="back()" class="column_right">>>返回</a>
            <div class="clear"></div>
            </p>
        </div>
    </div>
</body>
</html>
