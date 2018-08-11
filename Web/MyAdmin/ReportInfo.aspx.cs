using myhouse.BLL;
using myhouse.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myhouse.Web.MyAdmin
{
	public partial class ReportInfo : System.Web.UI.Page
	{
        public List<Section> sectionList { get; set; }
        public List<Housetype> hyList { get; set; }
        public List<Contract> reportList { get; set; }
        public string pageCode { get; set; }

        public string hid { get; set; }
        //public string sid { get; set; }
        //public string htype { get; set; }
        public string cstatus { get; set; }  //举报信息状态
        public string order { get; set; }
        //public string orderby { get; set; }

        HouseService houseService = new HouseService();
        SectionService sectionService = new SectionService();
        HousetypeService hyService = new HousetypeService();
        UserService userService = new UserService();
        ContractService contractService = new ContractService();

        protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["adminInfo"] == null)
            {
                Response.Redirect("/MyAdmin/AdminLogin.aspx");
            }

            string flag = Request["flag"];
            if (flag == null || "".Equals(flag))
            {
                this.showreporte();
            }
            else if(flag == "ok")
            {
                this.reorttrue();
            }
            else if(flag == "notok")
            {
                this.reportfalse();
            }
        }

        //添加分页查询被举报的信息（若房屋已处理设置为不合法，则不再显示此房屋的相关信息）
        protected void showreporte()
        {
            sectionList = sectionService.GetModelList("");
            hyList = hyService.GetModelList("");

            int page = 1;
            if (!Int32.TryParse(Request["page"], out page))
            {
                page = 1;
            }

            if (IsPostBack)
            {
                hid = Request["hid"];
                cstatus = Request["cststus"];
                order = Request["order"];
            }
            else
            {
                hid = Request["hid"];
                cstatus = Request["cststus"];
                order = Request["order"];
            }

            ArrayList list = contractService.FindReportByPageOnWhere(page, hid, cstatus, order);

            reportList = (List<Contract>)list[0];
            pageCode = list[1].ToString();

            foreach (Contract contract in reportList)
            {
                contract.house = houseService.GetModel(contract.uid);
                contract.user = userService.GetModel(contract.uid);
            }
        }

        //举报信息属实则设置房屋为不合法，修改举报信息状态为属实
        protected void reorttrue()
        {

        }

        //举报信息不属实  修改举报信息状态为不属实
        protected void reportfalse()
        {

        }


    }
}