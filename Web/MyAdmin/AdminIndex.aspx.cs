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


            if (IsPostBack)    //housecount
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
                        ht.Add("sectionname", sectionList[i].sname);
                        ht.Add("housecount", "" + sectionList[i].housecount + "");
                    }
                    else
                    {
                        ht.Add("sectionname", sectionList[i].sname);
                        ht.Add("housecount", "0");
                    }

                    housecountlist.Add(ht);
                }

                JavaScriptSerializer ser = new JavaScriptSerializer();

                jsonStr = ser.Serialize(housecountlist);

                //string s1 =

                Response.Write(jsonStr);

                Response.End();
            }




                //}
                //else
                //{
                //    Response.Write(jsonStr);
                //}


                //if (IsPostBack)
                //{
                //    string json = "{";

                //    sectionList = sectionService.GetModelList("");

                //    foreach (Section section in sectionList)
                //    {
                //        section.housecount = houseService.GetRecordCount("sid =" + section.sid);
                //    }

                //    for (int i = 0; i < sectionList.Count; i++)
                //    {
                //        if (sectionList[i].housecount > 0)
                //        {
                //            json += "\"" + sectionList[i].sname + "\":\"" + sectionList[i].housecount + "\",";
                //        }
                //        else
                //        {
                //            json += "\"" + sectionList[i].sname + "\":\"" + 0 + "\",";
                //        }
                //        json = json.Substring(0, json.Length - 1);
                //        json += "}";
                //        try
                //        {
                //            Response.Write(json);
                //            Response.End();
                //        }
                //        catch (Exception)
                //        {
                //        }
                //    }
                //    //else
                //    //{
                //    //    Response.Write("NO");
                //    //    Response.End();
                //    //}
                //}
                //else
                //{

                //}

            }
        }
}