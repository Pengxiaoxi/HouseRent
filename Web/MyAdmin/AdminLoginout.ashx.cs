using System;
using System.Collections.Generic;
using System.Web;

namespace myhouse.Web.MyAdmin
{
    /// <summary>
    /// AdminLoginout 的摘要说明
    /// </summary>
    public class AdminLoginout : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            context.Session["adminInfo"] = null;

            context.Response.Redirect("/Index.aspx");
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