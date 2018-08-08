<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="myhouse.Web.common.Default" %>

<!DOCTYPE html>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<title>Insert title here</title>
</head>
<body>
	<div>
        <table border="0" width="100%" cellspacing="0" cellpadding="0" style="margin-top: 8;">
		
        <%foreach (myhouse.Model.Section section in sectionList)
            {  %>
			<tr>
				<td>
					<table style="width: 100%;" align="center">
                        <%
                            if (section.houseList.Count > 0)
                            {%>
                                <tr height="30" ><td style="text-indent:5;background-size:100%; border-radius:5px; " background="/images/index/3.jpg"  ><b><font color="white">❤<%=section.sname %>❤</font></b><a style="position:absolute; right:2px; text-decoration:none;color:white" href="/HouseList.aspx?sid=<%=section.sid %>">浏览更多</a></td>
                            <%}
                        %>
						
						</tr>
						<tr>
							<td>
								<div>
                                    <ul class="sectionlist">
                                        <%foreach (myhouse.Model.House house in section.houseList)
                                            {  %>
										<li >
											<div align="center" style="margin-top: 20px;">
												<div><a href="/HouseDetails.aspx?hid=<%=house.hid %>" ><img class="houseimg" alt="" src="<%=house.hphotoone %>"></a></div>
												<div style="margin: 10px auto;"> <a href="/HouseDetails.aspx?hid=<%=house.hid %>"  style="text-decoration:none; color:green"><font style="font-size: 30px;font-weight: bold;"><%=house.hname %></font></a></div>
												<font style="font-size: 12px;">地区：<%=house.area.areaname%> </font>
												<font style="font-size: 12px;">面积：<%=house.hsize %></font>
												<font style="font-size: 12px;">租金：<%=house.hmoney %></font>
											</div>
										</li>
                                    <%
                                       }  %>
								</ul>
								</div>
							</td>
						</tr>
                        <%
                            if (section.houseList.Count > 0)
                            {%>
                                <tr height="25"><td style="text-indent:10"><font color="#F9F9F9)">详细介绍：<%=section.sdescription %></font></td></tr>
                            <%}
                        %>
						
					</table>
				</td>
			</tr>
            <%
               } %>
        
	    </table>
	</div>
</body>
</html>
