<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyCollect.aspx.cs" Inherits="myhouse.Web.MyCollect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>我的收藏</title>
<link href="MyAdmin/frame/layui/css/bootstrap.min2.css" rel="stylesheet" />
    <link rel="icon" href="/img/house.jpg"/>
    <script src="MyAdmin/js/jquery-1.11.1.js"></script>
    <script>
        function mycollect(hid)
        {
            $.post("/MyCollect.aspx?flag=cancelcollect", { hid: hid }, function (result) {
                if (result) {
                    alert("成功取消收藏该房屋！");
                    setTimeout('window.location.reload(true)', 800)
                }
                else {
                    alert("取消收藏失败！")
                }
            });
        }
    </script>

</head>
<body>
    <div id="header" class="wrap" style="width: 100%; margin: 0 auto;">
        <% Server.Execute("/common/Top.aspx"); %>     <%--Execute是从当前页面转移到指定页面，并将执行返回到当前页面--%>
    </div>

    <div>
        <%
            if (Session["userInfo"] != null)
            {%>
                <%
                    if (contractList != null)
                    {%>
                        <table style="width: 100%;" align="center">
						    <tr height="30" ><td style="text-indent:5;background-size:100%; border-radius:5px; " background="/images/index/3.jpg"  ><b><font color="white">❤我的收藏❤</font></b></td>
						    </tr>
						    <tr>
							    <td>
								    <div>
                                        <ul class="sectionlist">
                                            <% 
                                                foreach (myhouse.Model.Contract contract in contractList)
                                                {%>
                                                    <%
                                                    foreach (myhouse.Model.House house in contract.houseList)
                                                    {
                                                    %>
										            <li >
											            <div align="center" style="margin-top: 20px;">
												            <div><a href="/HouseDetails.aspx?hid=<%=house.hid %>" ><img class="houseimg" alt="" src="<%=house.hphotoone %>"></a></div>
												            <div style="margin: 10px auto;"> <a href="/HouseDetails.aspx?hid=<%=house.hid %>"  style="text-decoration:none; color:green"><font style="font-size: 30px;font-weight: bold;"><%=house.hname %></font></a></div>

                                                            <%
                                                            if (house.hmode == 0)
                                                            {%>
                                                                <input type="button" class="b3" " value="未出租"/>
                                                            <%}
                                                            else
                                                                {%>
                                                                    <input type="button" class="b1" " value="已出租"/>
                                                                <%}
                                                             %>

												            <button class="b2" onclick="mycollect(<%=house.hid %>)" >取消收藏</button>
											            </div>
										            </li>
                                                    <%}%>
                                           <%}
                                          %>                                 
								    </ul>
								    </div>
							    </td>
						    </tr>
					    </table>
                        <div class="pagination alternate" style="text-align:center;">
			                <ul class="clearfix">
                                 <%=pageCode %>
			                </ul>
		                </div> 
                    <%}
                    else
                     {%>
                       <div style="text-align:center;">
                            <p>您还未收藏任何房屋，快去收藏自己喜欢的房屋吧...</p>
                        </div>
                    <%}
                %>
            <%}
                else
                     {%>
                       <div style="text-align:center;">
                            <p>您还未收藏任何房屋，快去收藏自己喜欢的房屋吧...</p>
                        </div>
                    <%}          
     %>
	</div>
</body>
</html>
