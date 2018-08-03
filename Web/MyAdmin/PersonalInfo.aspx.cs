using myhouse.BLL;
using myhouse.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;

namespace myhouse.Web.MyAdmin
{
    public partial class PersonalInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                WorkerService workerService = new WorkerService();

                Worker worker = new Worker();

                HttpPostedFile file = Request.Files["photo"];  //获取上传的图片

                string photo = ((Worker)Session["adminInfo"]).wphoto;

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
                    else
                    { }
                }
                else
                { }

                int wid = ((Worker)Session["adminInfo"]).wid;

                worker = workerService.GetModel(wid);

                worker.wphoto = photo;
                worker.wsex = Request["sex"];
                worker.wcard = Request["card"];
                worker.wtel = Request["tel"];
                worker.wemail = Request["email"];
                worker.wadress = Request["adress"];

                string pass = Request["newpass2"];

                if (pass != "")
                {
                    worker.wpassword = MyMd5.GetMd5String(MyMd5.GetMd5String(pass));
                }

                //修改成功返回true，否则返回false
                if (workerService.Update(worker))
                {
                    Session["adminInfo"] = worker;
                    Response.Write(true);
                    Response.End();
                }
                else
                {
                    Response.Write(false);
                    Response.End();
                }
            }
            else
            
                if (Session["adminInfo"] == null)
                {
                    Response.Redirect("/MyAdmin/AdminLogin.aspx");
                }
            }           
        }
}
