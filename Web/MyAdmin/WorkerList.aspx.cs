using myhouse.BLL;
using myhouse.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;

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
            else if (flag == "check")
            {
                this.checkcradId();
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
            if (!Int32.TryParse(Request["wid"], out wid))    //wid是否存在 wid>0修改，否则添加
            {
                wid = 0;
            }
            Worker worker = new Worker();

            if (wid > 0)
            {
                worker = workerService.GetModel(wid);
            }
            else
            {
                worker.wphoto = "/Images/face/xi.jpg";
            }

            HttpPostedFile file = Request.Files["photo"];  //获取上传的图片

            string photo = worker.wphoto;

            if (file != null && !file.FileName.Equals(""))  //判断文件是否为空
            {
                string fileName = file.FileName;            //获取上传文件的文件名
                string ext = Path.GetExtension(fileName);   //得到上传的文件的扩展名

                if (ext == ".jpg" || ext == ".gif" || ext == ".png" || ext == "jpeg" || ext == ".JPG")  //判断文件类型是否符合要求
                {
                    string newFileNames = Guid.NewGuid().ToString() + ext;            //随机产生一个新的文件名

                    photo = "/Images/face/" + newFileNames;     //photo存储路径+新文件名

                    string fileSavePath = Request.MapPath("/Images/face/" + newFileNames);   //请求文件的相对路径

                    file.SaveAs(fileSavePath);     //将文件保存
                }
            }

            string pass = Request["newpass2"];
            if (pass != "")
            {
                worker.wpassword = MyMd5.GetMd5String(MyMd5.GetMd5String(pass));
            }

            worker.wid = wid;
            worker.wphoto = photo;
            worker.wname = Request["name"];
            worker.wsex = Request["sex"];
            worker.wcard = Request["card"];
            worker.wtel = Request["tel"];
            worker.wemail = Request["email"];
            worker.wadress = Request["adress"];
            worker.wtype = Request["type"];

            if (workerService.addorupdate(worker))
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

        //检查身份证号是否存在(存在则返回true)
        protected void checkcradId()
        {
            string cardId = Request["cardId"];
            //string cardId = Convert.ToString(Request["cardId"]);
            workerList = workerService.GetModelList("wcard= "+cardId);

            if (workerList.Count > 0)
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