using System;
using System.Collections.Generic;
using System.Web;

namespace myhouse.Web
{
    /// <summary>
    /// LoginOut 的摘要说明
    /// </summary>
    public class LoginOut : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            if (context.Session["userInfo"] != null)
            {
                //清除Session
                context.Session["userInfo"] = null;

                //清除cookie
                context.Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
                context.Response.Cookies["userpass"].Expires = DateTime.Now.AddDays(-1);

                context.Response.Redirect("/Index.aspx");
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