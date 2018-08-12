<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAnnounce.aspx.cs" Inherits="myhouse.Web.ViewAnnounce" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>公告</title>

<link href="css/style-announce.css" rel="stylesheet" />
<link href="MyAdmin/frame/layui/css/bootstrap.min2.css" rel="stylesheet" />
    <link rel="icon" href="/img/house.jpg"/>


</head>

<body>

    <div id="header" class="wrap" style="width: 100%; margin: 0 auto;">
        <% Server.Execute("/common/Top.aspx"); %>     <%--Execute是从当前页面转移到指定页面，并将执行返回到当前页面--%>
    </div>

    <div>
        <div class="news_contact">
        	  <ul>
                  <%foreach (myhouse.Model.Announce announce in announceList)
                      {  %>
                  
                  <%
                      if (announce.atype == "1   ")
                      {%><li>
                            <p>
        	  			        <a style="color:orangered;" href="/ViewAnnounceDetails.aspx?aid=<%=announce.aid %>" ><%=announce.atitle %></a>
        	  			        <span><%=announce.atime %></span> 
        	  		        </p></li>
                      <%}
                      else
                      {%><li>
                            <p>
        	  			        <a href="/ViewAnnounceDetails.aspx?aid=<%=announce.aid %>" ><%=announce.atitle %></a>
        	  			        <span><%=announce.atime %></span> 
        	  		        </p></li>
                      <%}
                       %>
                 </li>
                <%
                    }%>
              </ul>

                <label style="float:right; color:orangered; width:100px;">共<%=Announcerecord %>条</label>
         </div>
         <%--分页--%>
         <div class="pagination alternate" style="position:absolute; left:35%;">
			  <ul class="clearfix">
                     <%=pageCode %>
			  </ul>
		 </div>       
    </div>
</body>
</html>

