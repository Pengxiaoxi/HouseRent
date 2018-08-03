using myhouse.BLL;
using myhouse.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;

namespace myhouse.Web
{
    public partial class HouseList : System.Web.UI.Page
    {
        public List<House> houseList{ get; set; }

        public string sectionname { get; set; }
        public string pageCode { get; set; }
        public int sid;
        public int page = 1;
        public string flag;

        HouseService houseService = new HouseService();
        AreaService areaService = new AreaService();
        HousetypeService hyService = new HousetypeService();
        SectionService sectionService = new SectionService();

        //条件拼接
        StringBuilder strWhere = new StringBuilder();

        //分页链接条件
        StringBuilder param = new StringBuilder();
        public List<Area> areaList { get; set; }
        public List<Housetype> hyList { get; set; }
        public string areaid { get; set; }
        public string tid { get; set; }
        public string money { get; set; }
        public string min { get; set; }
        public string max { get; set; }

        public int hstatus = 1;    //正常的房屋的状态

        public int maxpage = 0;

        public int recordcount;


        protected void Page_Load(object sender, EventArgs e)
        {
            //防止sid非法
            if (!Int32.TryParse(Request["sid"], out sid))
            {
                sid = 1;
            }
             
            //当前房屋板块名
            sectionname = sectionService.GetModel(sid).sname;

            //地区与房屋类型选择
            areaList = areaService.GetModelList("");
            hyList = hyService.GetModelList("");

            //防止请求的page非法
            if (!Int32.TryParse(Request["page"], out page))
            {
                page = 1;
            }

            //获取条件进行条件语句拼接和回显(form表单提交的参数查询，get方式提交的方便分页和回显)
            if (IsPostBack)
            {
                areaid = Request.Form["harea"];
                tid = Request.Form["htype"];
                money = Request.Form["hmoney"];
            }
            else
            {
                areaid = Request.QueryString["harea"];
                tid = Request.QueryString["htype"];
                money = Request.QueryString["hmoney"];
            }

            //将租金900-1200根据"-"分割并存放在数组中，取出即为最小值与最大值
            if (money != null && !"".Equals(money))
            {
                string[] mArray = money.Split('-');
                min = mArray[0];
                max = mArray[1];
            }

            //分页列表条件拼接  strWhere
            if (sid.ToString() != "")
            {
                strWhere.Append("sid= '" + sid + "'");
            }
            if (areaid != null && !"".Equals(areaid))
            {
                strWhere.Append(" and harea= '" + areaid + "'");
            }
            if (tid != null && !"".Equals(tid))
            {
                strWhere.Append(" and htype= '" + tid + "'");
            }
            if (min != null && !"".Equals(min) && max != null && !"".Equals(max))
            {
                strWhere.Append(" and hmoney between '" + min + "' and '" + max + "'");
            }
            if (sid.ToString() != "")
            {
                strWhere.Append(" and hstatus= '" + hstatus + "'");
            }

            //获取信息的排序方式
            flag = Request["flag"];

            //分页链接条件拼接 param  注意空格
            if (sid.ToString() != "")
            {
                param.Append("sid="+sid );
            }
            if (areaid != null && !"".Equals(areaid))
            {
                param.Append("&harea="+areaid );
            }
            if (tid != null && !"".Equals(tid))
            {
                param.Append("&htype="+tid );
            }
            if (min != null && !"".Equals(min) && max != null && !"".Equals(max))
            {
                param.Append("&hmoney="+min+"-"+max);
            }
            if (sid.ToString() != "")
            {
                param.Append("&hstatus="+hstatus );
            }
            if (flag != null && !"".Equals(flag))
            {
                param.Append("&flag="+flag);
            }

            //根据不同条件查询出的信息的最大数，然后判断page与最大页的大小，防止最后一页为空
            recordcount = houseService.GetRecordCount(strWhere.ToString());
            if (recordcount % houseService.pagecount == 0)
            {
                maxpage = recordcount / houseService.pagecount;
            }
            else
            {
                maxpage = recordcount / houseService.pagecount + 1;
            }

            if (page > maxpage)
            {
                page = maxpage;
            }

            //通过页面传递的不同参数执行不同的操作   未审核房屋信息不查询
            if (flag == null || "".Equals(flag))
            {
                //默认发布时间倒序
                houseList = houseService.FindHouseByPageWhere(strWhere.ToString(), "htime desc", page, houseService.pagecount);
            }
            else if(flag == "moneydown")
            {
                //房屋租金从高到低  
                houseList = houseService.FindHouseByPageWhere(strWhere.ToString(), "hmoney desc", page, houseService.pagecount);
            }
            else if (flag == "moneyup")
            {
                //房屋租金从低到高 
                houseList = houseService.FindHouseByPageWhere(strWhere.ToString(), "hmoney asc", page, houseService.pagecount);
            }

            //分页链接
            pageCode = PageUtil.genPagination("/HouseList.aspx", recordcount, page, houseService.pagecount, param.ToString());

            //封装房屋地区到house,area下
            foreach (House house in houseList)
            {
                house.area = areaService.GetModel((int)house.harea);
            }
        }

        ////默认发布时间倒序  未审核房屋信息不查询
        //protected void showbytime()
        //{
        //    //条件分页查询出房屋信息
        //    houseList = houseService.FindHouseByPageWhere(strWhere.ToString(), "htime desc", page);
        //    //分页链接
        //    pageCode = PageUtil.genPagination("/HouseList.aspx", recordcount, page, houseService.pagecount, param.ToString());
        //}

        ////房屋租金从高到低  未审核房屋信息不查询
        //protected void showbymoneydown()
        //{
        //    //条件分页查询出房屋信息
        //    houseList = houseService.FindHouseByPageWhere(strWhere.ToString(), "hmoney desc", page);
            
        //    pageCode = PageUtil.genPagination("/HouseList.aspx", recordcount, page, houseService.pagecount, param.ToString());
        //}

        ////房屋租金从低到高  未审核房屋信息不查询
        //protected void showbymoneyup()
        //{
        //    //条件分页查询出房屋信息
        //    houseList = houseService.FindHouseByPageWhere(strWhere.ToString(), "hmoney asc", page);
           
        //    pageCode = PageUtil.genPagination("/HouseList.aspx", recordcount, page, houseService.pagecount, param.ToString());
        //}
    }
}