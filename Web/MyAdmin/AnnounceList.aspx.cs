using myhouse.BLL;
using myhouse.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;

namespace myhouse.Web.MyAdmin
{
    public partial class AnnounceList : System.Web.UI.Page
    {
        public List<Announce> announceList { get; set; }
        public string pageCode { get; set; }

        public int pagenumber = 1;

        public int pagesize = 10;

        public string flag { get; set; }

        public string atitle { get; set; }

        AnnounceService announceService = new AnnounceService();
        WorkerService workerService = new WorkerService();

        Announce announce = new Announce();

        StringBuilder strWhere = new StringBuilder();

        //根据不同参数执行不同操作 查询、增加和删除
        protected void Page_Load(object sender, EventArgs e)
        {
            flag = Request["flag"];

            if (flag == null || "".Equals(flag))
            {
                this.show();
            }
            else if (flag == "add")
            {
                this.add();
            }
            else if (flag == "mydelete")
            {
                this.mydelete();
            }
            else if (flag == "deletelist")
            {
                this.deletelist();
            }
        }

        //公告信息显示
        protected void show()
        {
            atitle = Request["atitle"];

            //根据公告标题进行查询
            if (atitle != null || "".Equals(atitle))
            {
                strWhere.Append("atitle like '%"+atitle+"%'");
                strWhere.Append("or acontent like '%" + atitle + "%'");
            }

            if (!Int32.TryParse(Request["page"], out pagenumber))
            {
                pagenumber = 1;
            }

            //防止删除最后一页仍然停留在最后一页
            int record = announceService.GetRecordCount(strWhere.ToString());
            int maxpage = 0;
            if (record % pagesize == 0)
            {
                maxpage = record / pagesize;
            }
            else
            {
                maxpage = record / pagesize + 1;
            }
            if (pagenumber > maxpage)
            {
                pagenumber = maxpage;
            }

            //select* from t_announce a where a.atitle like '%请选择时%';

            //公告信息分页列表
            announceList = announceService.FindAnnounceByPage(strWhere.ToString(), "atime desc", pagenumber);

            pageCode = PageUtil.genPagination("/MyAdmin/AnnounceList.aspx", record, pagenumber, pagesize, "atitle=" +atitle);

            //封装发布人信息
            foreach (Announce announce in announceList)
            {
                announce.worker = workerService.GetModel(announce.wid);
            }
        }

        //发布公告
        protected void add()
        {
            announce.atitle = Request["title"];
            announce.acontent = Request["content"];
            announce.wid = ((Worker)Session["adminInfo"]).wid;
            announce.atime = DateTime.Now;
            announce.atype = Request["type"];

            if (announceService.Add(announce) > 0)
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

        //单个的公告删除
        protected void mydelete()
        {
            int aid = Int32.Parse(Request["aid"]);
            if (announceService.Delete(aid))
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

        //公告批量删除
        protected void deletelist()
        {
            //获得公告id列表并通过 ‘，’切割存放在数组id中
            string ids = Request["ids"];

            if (announceService.DeleteList(ids))
            {
                Response.Write(true);
                Response.End();
            }
            else
            {
                Response.Write(false);
                Response.End();
            }

            //string[] id = ids.Split(',');

            //for(int i = 0; i < id.Length; i++)
            //{
            //    announceService.Delete(id[i]);
            //}
        }

    }
}