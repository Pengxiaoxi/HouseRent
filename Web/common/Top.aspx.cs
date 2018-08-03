using myhouse.BLL;
using myhouse.Model;
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myhouse.Web.common
{
    public partial class Top : System.Web.UI.Page
    {
        public List<Announce> announceList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            AnnounceService announceService = new AnnounceService();

            //查找最后发布的一条公告（先按照atime降序，再查出top 1）
            announceList = announceService.GetModelListTop(1, "", "atime desc");
        }
    }
}