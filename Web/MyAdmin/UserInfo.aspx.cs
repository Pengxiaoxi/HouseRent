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
            string flag = Request["flag"];

            if (flag == null || "".Equals(flag))
            {
                this.showuser();
            }
            else if (flag == "update")
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

            if (IsPostBack){
                unickname = Request.Form["unickname"];
                utype = Request.Form["utype"];
                starttime = Request.Form["starttime"];
                endtime = Request.Form["endtime"];
                order = Request.Form["order"];
            }
            else {
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

        }

        //单个删除用户信息及其发布的房屋信息,用户的收藏信息也要删除
        protected void deleteuser()
        {
            int uid = Int32.Parse(Request["uid"]);
            try
            {
                contractService.DeleteByUid(uid);
                houseService.DeleteByUid(uid);

                if (userService.Delete(uid)){
                    Response.Write(true);
                    Response.End();
                }
                else{
                    Response.Write(false);
                    Response.End();
                }
            }
            catch(Exception)
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
    }
}