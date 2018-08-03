using myhouse.BLL;
using myhouse.Model;
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myhouse.Web
{
    public partial class ViewAnnounceDetails : System.Web.UI.Page
    {
        public Announce announce { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            int aid = Int32.Parse(Request["aid"]);

            AnnounceService announceService = new AnnounceService();
            WorkerService workerService = new WorkerService();

            announce = announceService.GetModel(aid);

            //查询公告发布人
            announce.worker = workerService.GetModel(announce.wid);
        }
    }
}