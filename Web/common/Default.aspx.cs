using myhouse.BLL;
using myhouse.Model;
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myhouse.Web.common
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Section> sectionList { get; set; }

        public List<House> houseList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            SectionService sectionService = new SectionService();
            HouseService houseService = new HouseService();
            AreaService areaService = new AreaService();

            //板块列表
            sectionList = sectionService.GetModelList("");

            //封装house列表到section.houselist
            foreach (Section section in sectionList)
            {
                //当前板块最新发布的前10条信息  时间倒叙   未审核的不显示
                section.houseList = houseService.GetModelListTop(10, "sid= '"+ section.sid +"' and hstatus = '"+ houseService.hstatus +"'", "htime desc");

                //封装房屋地区到house,area下
                foreach (House house in section.houseList)
                {
                    int areaid = (int)house.harea;
                    house.area = areaService.GetModel(areaid);
                }
            }
        }
    }
}