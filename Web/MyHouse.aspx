<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyHouse.aspx.cs" Inherits="myhouse.Web.MyHouse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>我的房屋</title>
    <script>
        //删除房屋信息
        function mydelete(hid) {
            if (confirm("您确定要删除这条信息吗？")) {              
                $.post("/MyHouse.aspx?flag=delete", { hid: hid },
                       function (result) {
                           if (result) {
                               alert("删除成功！");
                               setTimeout("window.location.reload(true)", 500)
                           }
                           else {
                               alert("删除失败！");
                           }
                       }, "text"
                   );
            }
        }

        //修改房屋信息
        function mychange(hid) {
            window.open("/HouseModify.aspx?hid=" +hid);
        }
    </script>

    <link href="css/style.css" rel="stylesheet" />
    <link href="MyAdmin/frame/layui/css/bootstrap.min2.css" rel="stylesheet" />
    <link rel="icon" href="/img/house.jpg"/>

</head>

<body>
    <div id="header" class="wrap" style="width: 100%; margin: 0 auto;">
        <% Server.Execute("/common/Top.aspx"); %>
    </div>

    <div>
        <%--判断是否登录，是否为房主并显示不同的提示信息--%>

        <%
            if (Session["userInfo"] != null)
            {%>
            <% 
                if (((myhouse.Model.User)Session["userInfo"]).utype == "2   ")
                {%>
                <table style="width: 100%;" align="center">
						    <tr height="30" ><td style="text-indent:5;background-size:100%; border-radius:5px; " background="/images/index/3.jpg"   ><b><font color="white">❤我发布的房屋信息 |</font></b>&nbsp;&nbsp;
                                <a class="housemenu" href="/MyHouse.aspx">已审核的房屋&nbsp;&nbsp;|</a>&nbsp;&nbsp;<a class="housemenu" href="/MyHouse.aspx?flag=unreview">未审核的房屋&nbsp;&nbsp;|</a> &nbsp;&nbsp;<a class="housemenu" href="/MyHouse.aspx?flag=nopass">审核未通过的房屋</a> 
                                <input type="button" onclick="window.open('/HouseAdd.aspx')" value="发布新的房屋信息" class="newhouse" /></td>
						    </tr>

						    <tr>
							    <td>
								    <ul class="sectionlist" >
                                        <% foreach (myhouse.Model.House house in houseList)
                                            { %>
                                    
										    <li>
											    <div align="center" style="margin-top: 20px;">
												    <div><a href="/HouseDetails.aspx?hid=<%=house.hid %>"><img class="houseimg" alt="" src="<%=house.hphotoone %>"/></a></div>
												    <div style="margin: 10px auto;"><a href="/HouseDetails.aspx?hid=<%=house.hid %>" style="text-decoration:none;color:green"><font style="font-size: 30px;font-weight: bold;"><%=house.hname %></font></a></div>

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

                                                    <%--<input type="button" class="b1" " value="<%=house.hmode == 0 ? "未出租": "已出租" %>"/>--%>

                                                    <button class="b2" type="button" onclick="mychange(<%=house.hid %>)" >修改</button>
                                                    <button class="b3" type="button" onclick="mydelete(<%=house.hid %>)" >删除</button>
											    </div>
										    </li>
                                        <% }%>
								    </ul>
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
                            <p>:)快去成为房主发布你的第一条房屋信息吧.</p>
                            <p>Tips...需要等待审核通过才能够发布...</p>
                            <a href="/UserInfo.aspx" style="text-decoration:none; color:limegreen;">前往修改?</a>
                        </div>
                    <%}
                %>
                <%}
            else
                {%>
                    <div style="text-align:center;">
                        <p class="text">:)友情提示,请先登录再进行查看哦...</p>
                        <a href="/Login.aspx" style="text-decoration:none; color:limegreen;">前往登录?</a>
                    </div>
                <%}  
             %>
    </div>
</body>
</html>
