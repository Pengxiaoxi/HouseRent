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
        public string type { get; set; }   //接收的前台的type
        public string permission { get; set; }
        public string order { get; set; }
        public string wtype { get; set; }  //传入后台的用户类型（权限）


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
            
            if (IsPostBack)
            {
                name = Request.Form["wname"];
                type = Request.Form["peopletype"];   //8 管理员   1员工
                permission = Request.Form["permission"];
                order = Request.Form["order"];          
            }
            else
            {
                name = Request.QueryString["wname"];
                type = Request.QueryString["peopletype"];   //8 管理员   1员工
                permission = Request.QueryString["permission"];
                order = Request.QueryString["order"];
            }

            //管理员，选择员工+权限， 未选择人员类型+权限
            if (type == "8")
            {
                wtype = "8";
            }
            else if (type == "1")  //员工，不同的权限对应不同的员工类型
            {
                if (permission == "0")
                {
                    wtype = "0";
                }
                else if (permission == "1")
                {
                    wtype = "1";
                }
                else if (permission == "2")
                {
                    wtype = "2";
                }
                else
                {
                    wtype = "6";  //全部员工
                }
            }
            else
            {
                if (permission == "0")
                {
                    wtype = "0";
                }
                else if (permission == "1")
                {
                    wtype = "1";
                }
                else if (permission == "2")
                {
                    wtype = "2";
                }
            }

            ArrayList list = workerService.FindWorkerByPageOnWhere(page, name, wtype, order);

            workerList = (List<Worker>)list[0];
            pageCode = list[1].ToString();
        }

        //添加或更新员工信息
        protected void addorupdate()
        {
            int wid;
            if (!Int32.TryParse(Request["wid"], out wid))    //wid是否存在
            {
                wid = 0;
            }

            Worker worker = new Worker();
            worker.wid = wid;

        }

        //单个删除与批量删除员工
        protected void deleteworker()
        {
            string ids = Request["ids"];
            //单个删除
            if (ids == null)
            {
                int wid = Int32.Parse(Request["wid"]);

                if (workerService.Delete(wid))
                {
                    Response.Write(true);
                    Response.End();
                }
                else
                {
                    Response.Write(false);
                    Response.End();
                }
            }
            else  //批量删除
            {
                if (workerService.DeleteList(ids))
                {
                    Response.Write(true);
                    Response.End();
                }
                else
                {
                    Response.Write(false);
                    Response.End();
                }
            }
        }
    }
}