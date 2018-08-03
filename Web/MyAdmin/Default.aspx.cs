using myhouse.BLL;
using myhouse.Model;
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myhouse.Web.MyAdmin
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Menus> menuList { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminInfo"] == null)
            {
                Response.Redirect("/MyAdmin/AdminLogin.aspx");
            }
            else if (((Worker)Session["adminInfo"]).wtype == "0   ")
            {
                MenusService menuService = new MenusService();

                //员工菜单列表
                menuList = menuService.GetModelList("mstatus=" +0);
            }
            else if (((Worker)Session["adminInfo"]).wtype == "8   ")
            {
                MenusService menuService = new MenusService();

                //管理员菜单列表
                menuList = menuService.GetModelList("mstatus=" + 8);
            }
        }
    }
}