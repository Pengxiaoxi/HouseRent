using myhouse.BLL;
using myhouse.Model;
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;

namespace myhouse.Web
{
    public partial class Login : System.Web.UI.Page
    {
        public string ErrorMsg { get; set; }

        public string prePage { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //获取目的地址，方便login后直接跳转
            prePage = Request["prePage"];

            if (prePage == null)
            {
                prePage = "Index.aspx";
            }


            if (IsPostBack)
            {
                if (checkValidate())
                {
                    login();
                }
                else
                {
                    ErrorMsg = "验证码错误！";
                }
            }
            else
            {
                checkCookie();
            }
        }

        //登录方法
        protected void login()
        {
            string username = Request["username"];
            string userpass = MyMd5.GetMd5String(Request["userpass"]);  //Md5加密

            UserService userService = new UserService();

            List<User> userList = userService.GetModelList("unickname= '" + username + "' and upassword= '" + userpass + "'");

            if (userList.Count > 0)
            {
                Session["userInfo"] = userList[0];   //存入Session

                if (!string.IsNullOrEmpty(Request["remember"]))
                {
                    //创建cookie
                    HttpCookie cookie1 = new HttpCookie("username", username);
                    HttpCookie cookie2 = new HttpCookie("userpass", userpass);

                    //设置cookie过期时间
                    cookie1.Expires = DateTime.Now.AddDays(3);
                    cookie2.Expires = DateTime.Now.AddDays(3);

                    //将cookie保存到电脑硬盘
                    Response.Cookies.Add(cookie1);
                    Response.Cookies.Add(cookie2);
                }

                Response.Redirect(prePage);
            }
            else
            {
                ErrorMsg = "登录失败，请检查用户名及密码.";
            }
        }

        //检查cookie是否正确
        protected void checkCookie()
        {
            if (Request.Cookies["username"] != null && Request.Cookies["userpass"] != null)
            {
                string username = Request.Cookies["username"].Value;
                string userpass = Request.Cookies["userpass"].Value;

                UserService userService = new UserService();

                List<User> userList = userService.GetModelList("unickname= '" + username + "' and upassword= '" + userpass + "'");

                if (userList.Count > 0)
                {
                    Session["userInfo"] = userList[0];
                    Response.Redirect(prePage);
                }
                else
                {
                    //cookie信息错误清除cookie
                    Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["userpass"].Expires = DateTime.Now.AddDays(-1);
                }
            }

        }

        //检查验证码是否正确
        protected bool checkValidate()
        {
            string validate = Request["validate"];

            if (validate == Session["code"].ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}