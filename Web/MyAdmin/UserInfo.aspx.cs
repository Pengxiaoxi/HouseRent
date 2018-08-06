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
    public partial class UserInfo : System.Web.UI.Page
    {
        public string unickname { get; set; }
        public string utype { get; set; }
        public string starttime { get; set; }
        public string endtime { get; set; }
        public string order { get; set; }

        public List<User> userList { get; set; }
        public string pageCode { get; set; }


        UserService userService = new UserService();
        HouseService houseService = new HouseService();
        ContractService contractService = new ContractService();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminInfo"] == null)
            {
                Response.Redirect("/MyAdmin/AdminLogin.aspx");
            }

            string flag = Request["flag"];

            if (flag == "update")
            {
                this.updateuser();
            }
            else if (flag == "delete")
            {
                this.deleteuser();
            }
            else if (flag == "deletelist")
            {
                this.deletelist();
            }
            else if (flag == "review")
            {
                this.reviewuser();
            }
            else
            {
                this.showuser();
            }
        }

        //分页条件查询出所有用户
        protected void showuser()
        {
            //order为标识符，业务层判断排序方式
            int page = 1;
            if (!Int32.TryParse(Request["page"], out page))
            {
                page = 1;
            }

            if (IsPostBack)
            {
                unickname = Request.Form["unickname"];
                utype = Request.Form["utype"];
                starttime = Request.Form["starttime"];
                endtime = Request.Form["endtime"];
                order = Request.Form["order"];
            }
            else
            {
                unickname = Request.QueryString["unickname"];
                utype = Request.QueryString["utype"];
                starttime = Request.QueryString["starttime"];
                endtime = Request.QueryString["endtime"];
                order = Request.QueryString["order"];
            }
            ArrayList list = userService.FindUserByPageOnWhere(page, unickname, utype, starttime, endtime, order);
            //取出存储的分页列表与链接
            userList = (List<User>)list[0];
            pageCode = list[1].ToString();

            //发布数与收藏数
            foreach (User user in userList)
            {
                user.publishernumber = houseService.GetRecordCount("uid=" + user.uid);
                user.collectnumber = contractService.GetRecordCount("uid=" + user.uid);
            }


        }
        //修改后更新用户信息
        protected void updateuser()
        {
            int uid = Int32.Parse(Request["uid"]);
            User user = userService.GetModel(uid);

            string pass = Request["pass"];
            if (pass != null && !"".Equals(pass))
            {
                user.upassword = MyMd5.GetMd5String(pass);
            }

            HttpPostedFile file = Request.Files["photo1"];  //获取上传的图片

            string photo = user.uphoto;

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
            user.uphoto = photo;
            user.unickname = Request["nickname"];
            user.uname = Request["name"];
            user.ucard = Request["card"];
            user.usex = Request["sex"];
            user.uemail = Request["email"];
            user.uqq = Request["qq"];
            user.utel = Request["tel"];
            user.utype = Request["type"];

            if (userService.Update(user))
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

        //单个删除用户信息及其发布的房屋信息,用户的收藏信息也要删除
        protected void deleteuser()
        {
            int uid = Int32.Parse(Request["uid"]);
            try
            {
                contractService.DeleteByUid(uid);
                houseService.DeleteByUid(uid);

                if (userService.Delete(uid))
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
            catch (Exception)
            {
                Response.Write(false);
                Response.End();
            }
        }

        //批量删除用户信息及其发布的所有的房屋的信息
        protected void deletelist()
        {
            string ids = Request["ids"];
            string[] idlist = ids.Split(',');  //切割存放到数组
            try
            {
                for (int i = 0; i < idlist.Length; i++)
                {
                    contractService.DeleteByUid(Int32.Parse(idlist[i]));
                    houseService.DeleteByUid(Int32.Parse(idlist[i]));

                    if (userService.DeleteList(ids))
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
            catch (Exception)
            {
                Response.Write(false);
                Response.End();
            }
        }

        //员工审核用户(通过参数param判断是通过还是不通过, 不通过则为租赁者1)
        protected void reviewuser()
        {
            string param = Request["param"];

            int uid = Int32.Parse(Request["uid"]);
            User user = new User();
            user = userService.GetModel(uid);

            if (param == null || "".Equals(param)){
                user.utype = 2.ToString();
            }
            else if (param == "no"){
                user.utype = 1.ToString();
            }
            else{
                this.showuser();
            }

            if (userService.Update(user)){
                Response.Write(true);
                Response.End();
            }
            else{
                Response.Write(false);
                Response.End();
            }
        }
    }
}