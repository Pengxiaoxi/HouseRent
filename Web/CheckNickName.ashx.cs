using myhouse.BLL;
using myhouse.Model;
using System;
using System.Collections.Generic;
using System.Web;

namespace myhouse.Web
{
    /// <summary>
    /// CheckNickName 的摘要说明
    /// </summary>
    public class CheckNickName : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string nickname = context.Request["nickName"];

            UserService userService = new UserService();

            List<User> userinfo = userService.GetModelList("unickname= '" +nickname+ "'");

            if (userinfo.Count > 0)
            {
                context.Response.Write(false);
            }
            else
            {
                context.Response.Write(true);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}