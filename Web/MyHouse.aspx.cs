using myhouse.BLL;
using myhouse.Model;
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;

namespace myhouse.Web
{
    public partial class MyHouse : System.Web.UI.Page
    {
        public List<House> houseList { get; set; }

        public int page = 1;

        public string pageCode { get; set; }


        HouseService houseService = new HouseService();

        //入口方法
        protected void Page_Load(object sender, EventArgs e)
        {
            string flag = Request["flag"];   //得到参数

            if (flag == null || "".Equals(flag))
            {
                this.show();
            }
            else if (flag == "unreview")
            {
                this.showunreview();
            }
            else if (flag == "delete")
            {
                this.delete();
            }
        }


        //查询屋主所发布的已通过审核房屋的信息
        protected void show()
        {
            //判断是否满足条件，登录且用户为房主才进行房屋信息的查询
            if (Session["userInfo"] == null || ((User)Session["userInfo"]).utype != "2   ")
            {
                return;
            }
            else
            {
                int uid = ((User)Session["userInfo"]).uid;

                if (!Int32.TryParse(Request["page"], out page))
                {
                    page = 1;
                }

                //分页查询出该房主所发布的已审核的房屋的信息（发布时间倒叙）
                string param = "uid= '" + uid + "' and hstatus ='" + 1 + "'";

                houseList = houseService.FindHouseByPageWhere(param, "htime desc", page, houseService.pagecount);

                //分页链接
                pageCode = PageUtil.genPagination("/MyHouse.aspx", houseService.GetRecordCount(param), page, houseService.pagecount, param);
            }
        }


        //查询屋主所发布的未审核的房屋的信息
        protected void showunreview()
        {
            //判断是否满足条件，登录且用户为房主才进行房屋信息的查询
            if (Session["userInfo"] == null || ((User)Session["userInfo"]).utype != "2   ")
            {
                return;
            }
            else
            {
                int uid = ((User)Session["userInfo"]).uid;


                if (!Int32.TryParse(Request["page"], out page))
                {
                    page = 1;
                }

                //分页查询出该房主所发布的未审核的房屋的信息（发布时间倒叙）
                string param = "uid= '" + uid + "' and hstatus ='" + 0 + "'";

                houseList = houseService.FindHouseByPageWhere(param, "htime desc", page, houseService.pagecount);

                //分页链接
                pageCode = PageUtil.genPagination("/MyHouse.aspx", houseService.GetRecordCount(param), page, houseService.pagecount, param);
            }
        }

        //删除操作
        protected void delete()
        {
            int hid = Int32.Parse(Request["hid"]);

            if (houseService.Delete(hid))
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