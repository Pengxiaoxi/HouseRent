using System;
using System.Collections.Generic;

using System.Text;


namespace Util
{
    public class PageUtil
    {
        public static string genPagination(string targetUrl, long totalNum, int currentPage, int pageSize, string param)
        {
            //求出最大页
            long totalPage = totalNum % pageSize == 0 ? totalNum / pageSize : totalNum / pageSize + 1;
            StringBuilder pageCode = new StringBuilder();
            if (totalPage == 0)
            {
                return "满足当前条件的房屋暂时还没有，请重新选择条件...";
            }
            else
            {

                if (currentPage == 1)
                {

                    pageCode.Append("<li class=disabled><a>首页</a></li>");
                }
                else
                {
                    pageCode.Append("<li><a href='" + targetUrl + "?page=1&" + param + "'>首页</a></li>");
                }

                if (currentPage == 1)
                {
                    pageCode.Append("<li class=disabled><a>上一页</a></li>");
                }
                else
                {
                    pageCode.Append("<li><a href='" + targetUrl + "?page=" + (currentPage - 1) + "&" + param + "'>上一页</a></li>");
                }

                for (int i = currentPage - 2; i <= currentPage + 2; i++)
                {
                    if (i < 1 || i > totalPage)
                    {
                        continue;
                    }
                    if (i == currentPage)
                    {
                        pageCode.Append("<li class=active><a>" + i + "</a></li>");
                    }
                    else
                    {
                        pageCode.Append("<li><a href='" + targetUrl + "?page=" + i + "&" + param + "'>" + i + "</a></li>");
                    }
                }

                if (currentPage == totalPage)
                {
                    pageCode.Append("<li class=disabled><a>下一页</a></li>");
                }
                else
                {
                    pageCode.Append("<li><a href='" + targetUrl + "?page=" + (currentPage + 1) + "&" + param + "'>下一页</a></li>");
                }

                if (currentPage == totalPage)
                {
                    pageCode.Append("<li class=disabled><a>尾页</a></li>");
                }
                else
                {
                    pageCode.Append("<li><a href='" + targetUrl + "?page=" + totalPage + "&" + param + "'>尾页</a></li>");
                }
            }
            return pageCode.ToString();
        }

    }
}
