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
    public partial class ViewAnnounce : System.Web.UI.Page
    {
        public List<Announce> announceList { get; set; }
        public int Announcerecord { get; set; }

        public string pageCode { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            AnnounceService announceService = new AnnounceService();
            //公告总数
            Announcerecord = announceService.GetRecordCount("");

            //防止请求的pagenumber非法
            int pagenumber = 1;

            if (!Int32.TryParse(Request["page"], out pagenumber))
            {
                pagenumber = 1;
            }

            //分页后的公告列表
            announceList = announceService.FindAnnounceByPage("", "atime desc", pagenumber);

            //分页
            pageCode = PageUtil.genPagination("/ViewAnnounce.aspx", Announcerecord, pagenumber, announceService.pagesize, "");

            
        }
    }
}