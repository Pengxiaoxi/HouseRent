using myhouse.BLL;
using myhouse.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;

namespace myhouse.Web
{
    public partial class UserInfo : System.Web.UI.Page
    {
        public string sex { get; set; }
        public string utype { get; set; }
        public string ErrorMsg { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                UserService userService = new UserService();

                HttpPostedFile file = Request.Files["photo"];  //获取上传的图片

                string photo = ((User)Session["userInfo"]).uphoto;

                if (file != null && !file.FileName.Equals(""))
                {    //判断文件是否为空

                    string fileName = file.FileName;   //得到上传图片的文件名字

                    string ext = Path.GetExtension(fileName);   //得到上传图片的文件扩展名

                    if (ext == ".jpg" || ext == ".gif" || ext == ".png" || ext == ".jpeg" || ext == ".JPG" || ext == ".bmp") //设定文件的类型
                    {
                        string newFileNames = Guid.NewGuid().ToString() + ext;

                        string fileSavePath = Request.MapPath("/Images/face/" + newFileNames);

                        photo = "/Images/face/" + newFileNames;

                        file.SaveAs(fileSavePath);   //保存图片到服务器指定的目录中去
                    }                  
                }

                int uid = ((User)Session["userInfo"]).uid;
                User user = new User();
                user = userService.GetModel(uid);

                user.unickname = ((User)Session["userInfo"]).unickname;
                user.uname = Request["name"];
                user.utype = Request["type"];
                user.usex = Request["sex"];
                user.uphoto = photo;
                user.ucard = Request["card"];
                user.utel = Request["tel"];
                user.uqq = Request["qq"];
                user.uemail = Request["email"];

                //判断是否更改密码
                if (!"".Equals(Request["password1"]) && Request["password1"] !=null)
                {
                    user.upassword = MyMd5.GetMd5String(Request["password1"]);
                }
                else
                {
                    user.upassword = ((User)Session["userInfo"]).upassword;
                }

                //更新方法
                if (userService.Update(user))
                {
                    Session["userInfo"] = user;

                    Response.Redirect("/Index.aspx");
                }
                else
                {
                    ErrorMsg = "修改失败！";
                }
            }
            else
            {
                if (Session["userInfo"] != null)
                {
                    //页面选择显示用户类别，性别
                    utype = ((User)Session["userInfo"]).utype;
                    sex = ((User)Session["userInfo"]).usex;
                }
            }
        }
    }
}