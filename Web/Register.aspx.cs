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
    public partial class Register : System.Web.UI.Page
    {
        public string nickname { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string sex { get; set; }
        public string card { get; set; }
        public string tel { get; set; }
        public string qq { get; set; }
        public string email { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                HttpPostedFile file = Request.Files["photo"];  //获取上传的图片

                string photo = "";

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
                    else
                    {
                        photo = "/Images/face/lbxx.jpg";  //默认头像
                    }
                }
                else
                {
                    photo = "/Images/face/lbxx.jpg";
                }

                nickname = Request["nickname"];
                name = Request["name"];
                type = Request["type"];
                sex = Request["sex"];
                card = Request["card"];
                tel = Request["tel"];
                qq = Request["qq"];
                email = Request["email"];

                User user = new User();

                user.unickname = nickname;
                user.uname = name;
                user.utype = type;
                user.usex = sex;
                user.uphoto = photo;
                user.ucard = card;
                user.utel = tel;
                user.uqq = qq;
                user.uemail = email;
                user.upassword = MyMd5.GetMd5String(Request["password1"]);   //密码加密
                user.uregtime = DateTime.Now;
                user.ucredit = 10.ToString();

                UserService userService = new UserService();

                //调用Add方法
                if (userService.Add(user) > 0)
                {
                    Session["userInfo"] = user;
                    Response.Redirect("/Index.aspx");

                }
                else
                {
                    Response.Write("<script>alert(注册失败！)</script>");
                }
            }
        }
    }
}