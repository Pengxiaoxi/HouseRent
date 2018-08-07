using myhouse.BLL;
using myhouse.Model;
using System;
using System.Collections;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myhouse.Web.MyAdmin
{
    public partial class WorkerList : System.Web.UI.Page
    {
        WorkerService workerService = new WorkerService();

        public List<Worker> workerList { get; set; }

        public string pageCode { get; set; }

        public string name { get; set; }
        public string type { get; set; }
        public string permission { get; set; }
        public string order { get; set; }


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
            int page;
            if (!Int32.TryParse(Request["page"], out page))
            {
                page = 1;
            }
            name = Request["wname"];
            type = Request["peopletype"];   //8 管理员   1员工
            permission = Request["permission"];
            order = Request["order"];

            string wtype;

            if (type == "1")
            {
                if (permission == "0") {
                    type = "0";
                }
                else if (permission == "1") {
                    type = "1";
                }
                else if (permission == "2") {
                    type = "2";
                }
            }


            ArrayList list = workerService.FindWorkerByPageOnWhere(page, name, type, order);

            workerList = (List<Worker>)list[0];
            pageCode = list[1].ToString();
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