using myhouse.BLL;
using myhouse.Model;
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;

namespace myhouse.Web.MyAdmin
{
    public partial class SectionList : System.Web.UI.Page
    {
        public List<Section> sectionList { get; set; }
        public string pageCode { get; set; }
        public int sid { get; set; }

        SectionService sectionService = new SectionService();
        HouseService houseService = new HouseService();

        Section section = new Section();

        protected void Page_Load(object sender, EventArgs e)
        {
            string flag = Request["flag"];
            if (flag == null || "".Equals(flag))
            {
                this.showSection();
            }
            else if (flag == "addup")
            {
                this.addorupdateSection();
            }
            else if (flag == "delete")
            {
                this.deleteSection();
            }
            else if (flag == "deletelist")
            {
                this.deleteSectionList();
            }
        }

        //分页显示所有房屋板块信息
        protected void showSection()
        {
            int page = 1;
            if (!Int32.TryParse(Request["page"], out page))
            {
                page = 1;
            }

            int Record = sectionService.GetRecordCount("");
            int maxpage = 0;
            if (Record % sectionService.pagesize == 0)
            {
                maxpage = Record / sectionService.pagesize ;
            }
            else
            {
                maxpage = Record / sectionService.pagesize +1;
            }
            if (page > maxpage)
            {
                page = maxpage;
            }
            sectionList = sectionService.FindSectionByPage("", "sid asc", page);

            pageCode = PageUtil.genPagination("/MyAdmin/SectionList.aspx", Record, page, sectionService.pagesize, "");   //分页

            //保存每个板块下房屋数
            foreach (Section section in sectionList)
            {
                section.housecount = houseService.GetRecordCount("sid= " + section.sid);
            }
        }

        //增加或更新房屋板块信息
        protected void addorupdateSection()
        {
            int sid;
            if (!Int32.TryParse(Request["sid"], out sid))
            {
                sid = 0;
            }
            section.sid = sid;
            section.sname = Request["sname"];
            section.sdescription = Request["sdescription"];

            if (sectionService.saveorupdate(section))
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

        //单个板块及其下房屋信息删除(先根据板块id删除所有该板块下房屋信息再通过sid删除该板块)
        protected void deleteSection()
        {
            sid = Int32.Parse(Request["sid"]);
            //先判断当前板块下是否存在房屋，存在则删除否则直接删除板块
            if (houseService.GetRecordCount("sid= " + sid) > 0){
                if (houseService.DeleteBySid(sid)){
                    if (sectionService.Delete(sid)){
                        Response.Write(true);
                        Response.End();
                    }
                    else {
                        Response.Write(false);
                        Response.End();
                    }
                }
                else{
                    Response.Write(false);
                    Response.End();
                }
            }
            else{
                if (sectionService.Delete(sid)){
                    Response.Write(true);
                    Response.End();
                }
                else{
                    Response.Write(false);
                    Response.End();
                }
            }
        }

        //批量删除板块及其下房屋信息
        protected void deleteSectionList()
        {
            string ids = Request["ids"];

            string[] id = ids.Split(',');   //通过','切割ids  1,2   存入数组id

            //删除所有房屋信息
            for (int i = 0; i < id.Length; i++)
            {
                houseService.DeleteBySid(Int32.Parse(id[i]));
            }

            //删除所有板块信息
            if (sectionService.DeleteList(ids))
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