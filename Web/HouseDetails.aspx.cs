﻿using myhouse.BLL;
using myhouse.Model;
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myhouse.Web
{
    public partial class HouseDetails : System.Web.UI.Page
    {
        public House house { get; set; }
        public string housetype { get; set; }
        public string housearea { get; set; }
        public string housesection { get; set; }
        public string houseadress { get; set; }
        public string housecommunity { get; set; }
        public List<House> tjhouse { get; set; }
        public List<Contract> contractList { get; set; }

        HouseService houseService = new HouseService();
        UserService userService = new UserService();
        HousetypeService hyService = new HousetypeService();
        AreaService areaService = new AreaService();
        SectionService sectionService = new SectionService();
        ContractService contractService = new ContractService();

        public int hid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Int32.TryParse(Request["hid"], out hid))
            {
                Response.Redirect("/Index.aspx");
            }

            string flag = Request["flag"];
            if (flag == "collect")
            {
                this.collect();
            }
            else if (flag == "report")
            {
                this.report();
            }
            else {
                this.housedetailsshow();
            }
        }

        //show
        protected void housedetailsshow()
        {
            //查询出与该房屋有关的信息
            house = houseService.GetModel(hid);

            house.userinfo = userService.GetModel(house.uid);

            housetype = hyService.GetModel((int)house.htype).ttype.ToString();

            housearea = areaService.GetModel((int)house.harea).areaname;

            housesection = sectionService.GetModel(house.sid).sname;
            //房屋所在小区与地址，地图使用
            houseadress = house.hadress;
            housecommunity = house.hcommunity;


            if (Session["userInfo"] != null)
            {
                int uid = ((User)Session["userInfo"]).uid;
                contractList = contractService.GetModelList("uid='" + uid + "' and hid=" + hid);
                if (contractList.Count == 0)
                {
                    house.contract = null;
                }
                else
                {
                    house.contract = contractList[0];
                }
            }

            //推荐房屋查询
            string hmoney = house.hmoney;
            int htype = (int)house.htype;

            tjhouse = houseService.GetModelListTop(4, "hmoney='" + hmoney + "' and htype='" + htype + "' and hid !='" + hid + "' and hstatus =" + 1, "htime desc");
        }

        //收藏功能
        protected void collect()
        {
            int uid = ((User)Session["userInfo"]).uid;

            contractList = contractService.GetModelList("uid='" + uid + "' and hid='" + hid + "' and cstatus= '"+contractService.collectstatus+"'" );

            //不存在则执行添加方法，已存在则取消收藏执行删除方法
            if (contractList.Count == 0)
            {
                Contract contract = new Contract();
                contract.hid = hid;
                contract.uid = uid;
                contract.cstatus = contractService.collectstatus;
                if (contractService.Add(contract) > 0)
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
            else
            {
                int cid = contractList[0].cid;
                if (contractService.Delete(cid))
                {
                    Response.Write(false);
                    Response.End();
                }
                else
                {
                    Response.Write(true);
                    Response.End();
                }
            }
        }


        //举报功能
        protected void report()
        {
            Contract contract = new Contract();

            contract.uid = ((User)Session["userInfo"]).uid;
            contract.hid = Int32.Parse(Request["hid"]);
            contract.ccontent = Request["reportcontent"];
            contract.cstatus = 0;   //举报信息

            if (contractService.Add(contract) > 0)
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