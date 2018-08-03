using System;
using System.Collections.Generic;
using System.Web;
using Util;

namespace myhouse.Web
{
    /// <summary>
    /// Login_ValidateCode 的摘要说明
    /// </summary>
    public class Login_ValidateCode : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            //创建生成2维图的对象
            MyValidate validateCode = new MyValidate();

            //调用CreateValidateCode方法,传入参数5 表示生成一个5位数的验证码
            string code = validateCode.CreateValidateCode(4);   //并且返回此验证码中的数字

            context.Session["code"] = code;    //验证码图片中的数字保存到Session会话作用域中

            validateCode.CreateValidateGraphic(code, context);  //将最终的图片输出到网页中去

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