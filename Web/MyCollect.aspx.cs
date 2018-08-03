using myhouse.BLL;
using myhouse.Model;
using System;
using System.Collections;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;

namespace myhouse.Web
{
    public partial class MyCollect : System.Web.UI.Page
    {
        public List<Contract> contractList { get; set; }

        public string pageCode { get; set; }
        public int uid { get; set; }

        ContractService contractService = new ContractService();
        HouseService houseService = new HouseService();
        AreaService areaService = new AreaService();

        protected void Page_Load(object sender, EventArgs e)
        {
            string flag = Request["flag"];

            if (Session["userInfo"] == null)
            {
                return;
            }
            else
            {
                uid = ((User)Session["userInfo"]).uid;
            }

            if (flag == null || "".Equals(flag))
            {
                this.show();
            }
            else if (flag == "cancelcollect")
            {
                this.cancelcollect();
            } 
        }

        //显示收藏的房屋
        protected void show()
        {
            int page = 1;
            if (!Int32.TryParse(Request["page"], out page))
            {
                page = 1;
            }
            int maxpage;
            int record = contractService.GetRecordCount("uid=" +uid);
            if (record % houseService.pagecount == 0)
            {
                maxpage = record / houseService.pagecount;
            }
            else
            {
                maxpage = record / houseService.pagecount + 1;
            }
            if (page > maxpage)
            {
                page = maxpage;
            }

            //contractList = contractService.GetModelList("uid=" + uid);

            contractList = contractService.FindContractByPageWhere("uid=" +uid, "", page, contractService.pagecount);

            foreach (Contract contract in contractList)
            {
                //分页
                //contract.houseList = houseService.FindHouseByPageWhere("hid=" + contract.hid, "", page, houseService.pagecount );

                contract.houseList = houseService.GetModelList("hid=" + contract.hid);

                pageCode = PageUtil.genPagination("/MyCollect.aspx", record, page, houseService.pagecount, "");

                //封装房屋地区到house.area下
                foreach (House house in contract.houseList)
                {
                    int areaid = (int)house.harea;
                    house.area = areaService.GetModel((int)house.harea);
                }
            }
        }

        //取消收藏
        protected void cancelcollect()
        {
            int hid = Int32.Parse(Request["hid"]);

            contractList = contractService.GetModelList("uid= '"+uid+"' and hid=" +hid);

            if (contractService.Delete(contractList[0].cid))
            {
                Response.Write(true);
                Response.End();
            }
            else
            {
                Response.Write(true);
                Response.End();
            }
        }
    }
}