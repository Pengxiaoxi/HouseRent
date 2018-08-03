using myhouse.BLL;
using myhouse.Model;
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;

namespace myhouse.Web.MyAdmin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        public string ErrorMsg { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string name = Request["name"];
                string pass = MyMd5.GetMd5String(MyMd5.GetMd5String(Request["pass"]));   //MD5加密两次

                WorkerService workerService = new WorkerService();

                List<Worker> workerList = workerService.GetModelList("wname='" + name +"' and wpassword = '"+ pass +"'");

                if (workerList.Count > 0)
                {
                    Session["adminInfo"] = workerList[0];

                    Response.Redirect("/MyAdmin/Default.aspx");
                }
                else
                {
                    ErrorMsg = "登录失败";
                }
            }
        }
    }
}