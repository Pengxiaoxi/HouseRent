using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myhouse.Web.MyAdmin
{
    public partial class WorkerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminInfo"] == null)
            {
                Response.Redirect("/MyAdmin/AdminLogin.aspx");
            }

            string flag = Request["flag"];
            if (flag == null || "".Equals(flag))
            {
                this.showworker();
            }
            else if (flag == "addorupdate")
            {
                this.addorupdate();
            }
            else if (flag == "delete")
            {
                this.deleteworker();  
            }
        }

        //条件分页查询显示员工信息
        protected void showworker()
        {

        }

        //添加或更新员工信息
        protected void addorupdate()
        {

        }

        //单个删除与批量删除员工
        protected void deleteworker()
        {

        }
    }
}