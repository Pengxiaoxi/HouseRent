<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HouseList.aspx.cs" Inherits="myhouse.Web.HouseList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<%--<link href="css/bootstrap.min.css" rel="stylesheet" />--%>
    <link href="MyAdmin/frame/layui/css/bootstrap.min2.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
<script>
    function myback()
    {
        window.history.go(-1);
    }

    //function clear()
    //{
    //    $("div option:empty");
    //}

</script>


</head>

<body>
    <div id="header" class="wrap" style="width: 100%; margin: 0 auto;">
        <% Server.Execute("/common/Top.aspx"); %>     <%--Execute是从当前页面转移到指定页面，并将执行返回到当前页面--%>
    </div>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;" align="center">
						<tr height="30" ><td style="text-indent:5;background-size:100%;border-radius:5px; " background="/images/index/3.jpg"  >
                                            <b><font color="white">当前房屋板块为：❤<%=sectionname %>❤</font></b>
                                            <a onclick="myback()"  style="float:right;cursor:pointer; text-decoration:none; color:white;">返回</a>
						                 </td>
						</tr>
                        <tr class="ss">
                            <td class="search">
                                <span><a>地区:</a>
                                    <select name="harea">
                                        <option value="">所有地区</option>
                                        <% 
                                            foreach (myhouse.Model.Area area in areaList)
                                            {%>
                                               <option value="<%=area.areaid %>" <%=areaid == area.areaid.ToString() ? "selected" : "" %> > <%=area.areaname %></option>
                                            <%}
                                        %>
                                    </select>&nbsp;
                                    <a>房屋类型:</a>
                                    <select name="htype">
                                        <option value="">所有类型</option>
                                        <% 
                                            foreach (myhouse.Model.Housetype htype in hyList)
                                            {%>
                                               <option value="<%=htype.tid %>" <%=tid == htype.tid.ToString() ? "selected" : "" %> ><%=htype.ttype %></option>
                                            <%}
                                        %>
                                    </select>&nbsp;
                                    <a>房屋租金:</a>
                                    <select name="hmoney">
                                        <option value="">所有价位</option>
                                        <option <%=money == "0-300"? "selected" : "" %> >0-300</option>
                                        <option <%=money == "300-600" ? "selected" : "" %> >300-600</option>
                                        <option <%=money == "600-900" ? "selected" : "" %> >600-900</option>
                                        <option <%=money == "900-1200" ? "selected" : "" %> >900-1200</option>
                                        <option <%=money == "1200-1500" ? "selected" : "" %> >1200-1500</option>
                                        <option <%=money == "1500-2000" ? "selected" : "" %> >1500-2000</option>
                                        <option <%=money == "2000-100000" ? "selected" : "" %> >2000-100000</option>
                                    </select>
                                    <button type="submit" onclick="">查找</button>
                                    <%--<button type="button" onclick="clear()">清除选择</button>--%>
                                </span>
                                
                            </td>
                            <td class="sort">
                                <b>排序方式:&nbsp;&nbsp;<a class="current" href="/HouseList.aspx?sid=<%=sid %>">最新↓</a>&nbsp;&nbsp;
                                    <a href="/HouseList.aspx?sid=<%=sid %>&flag=moneydown">租金↓</a>&nbsp;&nbsp;
                                    <a href="/HouseList.aspx?sid=<%=sid %>&flag=moneyup">租金↑</a></b>
                            </td>
                        </tr>
						<tr>
							<div>
                                <td>
								<ul class="sectionlist" >
                                    <% foreach (myhouse.Model.House house in houseList)
                                        {%>
										<li>
											<div align="center" style="margin-top: 20px;">
												<div><a href="/HouseDetails.aspx?hid=<%=house.hid %>"><img class="houseimg" alt="" src="<%=house.hphotoone %>"></a></div>
												<div style="margin: 10px auto;"> <a href="/HouseDetails.aspx?hid=<%=house.hid %>" style="text-decoration:none; color:green"><font style="font-size: 30px;font-weight: bold;"><%=house.hname %></font></a></div>
												<font style="font-size: 12px;">地区：<%=house.area.areaname%> </font>
												<font style="font-size: 12px;">面积：<%=house.hsize %></font>
												<font style="font-size: 12px;">租金：<%=house.hmoney %></font>
											</div>
										</li>      
                                    <%} %>
								</ul>
							</td>
							</div>
						</tr>
					</table>
    </div>
    </form>

    <%--分页--%>
    <div class="pagination alternate" style="text-align:center">
        <ul class="clearfix">
            <%=pageCode %>
        </ul>     
    </div>

</body>
</html>
