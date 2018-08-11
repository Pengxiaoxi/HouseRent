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
        public Contract contract { get; set; }
        public House house { get; set; }
        public string pageCode { get; set; }
        public string hid { get; set; }
        public string cstatus { get; set; }  //举报信息状态
        public string order { get; set; }

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
            //查询与分页条件分开获取
            if (IsPostBack)
            {
                hid = Request.Form["hid"];
                cstatus = Request.Form["cstatus"];
                order = Request.Form["order"];
            }
            else
            {
                hid = Request.QueryString["hid"];
                cstatus = Request.QueryString["cstatus"];
                order = Request.QueryString["order"];
            }
            //调用获取arraylist
            ArrayList list = contractService.FindReportByPageOnWhere(page, hid, cstatus, order);
            //取出信息列表与分页链接
            reportList = (List<Contract>)list[0];
            pageCode = list[1].ToString();

            //封装信息
            foreach (Contract contract in reportList)
            {
                contract.house = houseService.GetModel(contract.hid);
                contract.user = userService.GetModel(contract.uid);

                contract.house.housetype = hyService.GetModel((int)contract.house.htype);
                contract.house.section = sectionService.GetModel(contract.house.sid);
                contract.house.userinfo = userService.GetModel(contract.house.uid);
            }
        }

        //举报信息属实则设置房屋为不合法，修改举报信息状态为属实
        protected void reorttrue()
        {
            int cid = Int32.Parse(Request["cid"]);
            int hid = Int32.Parse(Request["hid"]);

            try
            {
                //更新此房屋的状态与举报信息状态
                contract = contractService.GetModel(cid);
                contract.cstatus = 1;

                house = houseService.GetModel(hid);
                house.hstatus = 2;

                contractService.Update(contract);
                houseService.Update(house);
                Response.Write(true);
                Response.End();
            }
            catch (Exception)
            {
                Response.Write(false);
                Response.End();
                throw;
            }
        }

        //举报信息不属实  修改举报信息状态为不属实
        protected void reportfalse()
        {
            string ids = Request["ids"];

            if (ids == null || "".Equals(ids))
            {
                int cid = Int32.Parse(Request["cid"]);

                try
                {//修改举报信息状态为不属实2
                    contract = contractService.GetModel(cid);
                    contract.cstatus = 2;

                    contractService.Update(contract);
                    Response.Write(true);
                    Response.End();
                }
                catch (Exception)
                {
                    Response.Write(false);
                    Response.End();
                    throw;
                }
            }
            else {
                try
                {
                    string[] idlist = ids.Split(',');

                    for (int i = 0; i < idlist.Length; i++)
                    {
                        int cid = Int32.Parse(idlist[i]);
                        contract = contractService.GetModel(cid);
                        contract.cstatus = 2;
                        contractService.Update(contract);   
                    }
                    Response.Write(true);
                    Response.End();
                }
                catch (Exception)
                {
                    Response.Write(false);
                    Response.End();
                    throw;
                }

            }
        }
    }
}