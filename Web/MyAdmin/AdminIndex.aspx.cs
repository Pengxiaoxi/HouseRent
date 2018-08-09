using myhouse.BLL;
using myhouse.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;

namespace myhouse.Web.MyAdmin
{
    public partial class AdminIndex : System.Web.UI.Page
    {
        public List<Section> sectionList { get; set; }

        public string jsonStr { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminInfo"] == null)
            {
                Response.Redirect("/MyAdmin/AdminLogin.aspx");
            }

            SectionService sectionService = new SectionService();
            HouseService houseService = new HouseService();

            string flag = Request["flag"];

            if (flag == "sname")
            {
                sectionList = sectionService.GetModelList("");

                foreach (Section section in sectionList)
                {
                    section.housecount = houseService.GetRecordCount("sid =" + section.sid);
                }

                ArrayList housecountlist = new ArrayList();

                for (int i = 0; i < sectionList.Count; i++)
                {
                    Hashtable ht = new Hashtable();

                    if (sectionList[i].housecount > 0)
                    {
                        ht.Add("sname", sectionList[i].sname);
                        ht.Add("housecount", "" + sectionList[i].housecount + "");
                    }
                    else
                    {
                        ht.Add("sname", sectionList[i].sname);
                        ht.Add("housecount", "0");
                    }

                    housecountlist.Add(ht);
                }

                JavaScriptSerializer ser = new JavaScriptSerializer();

                jsonStr = ser.Serialize(housecountlist);

                Response.Write(jsonStr);

                Response.End();
            }
            else
            {

            }

            //if (!IsPostBack)    //housecount
            //{
            //    sectionList = sectionService.GetModelList("");

            //    foreach (Section section in sectionList)
            //    {
            //        section.housecount = houseService.GetRecordCount("sid =" + section.sid);
            //    }

            //    ArrayList housecountlist = new ArrayList();

            //    for (int i = 0; i < sectionList.Count; i++)
            //    {
            //        Hashtable ht = new Hashtable();

            //        if (sectionList[i].housecount > 0)
            //        {
            //            ht.Add("sectionname", sectionList[i].sname);
            //            ht.Add("housecount", "" + sectionList[i].housecount + "");
            //        }
            //        else
            //        {
            //            ht.Add("sectionname", sectionList[i].sname);
            //            ht.Add("housecount", "0");
            //        }

            //        housecountlist.Add(ht);
            //    }

            //    JavaScriptSerializer ser = new JavaScriptSerializer();

            //    jsonStr = ser.Serialize(housecountlist);

            //    Response.Write(jsonStr);

            //    Response.End();
            //}

            }
        }
}