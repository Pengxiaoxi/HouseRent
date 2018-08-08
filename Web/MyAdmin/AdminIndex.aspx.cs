using myhouse.BLL;
using myhouse.Model;
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myhouse.Web.MyAdmin
{
    public partial class AdminIndex : System.Web.UI.Page
    {
        public List<Section> sectionList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminInfo"] == null)
            {
                Response.Redirect("/MyAdmin/AdminLogin.aspx");
            }

            SectionService sectionService = new SectionService();
            HouseService houseService = new HouseService();

            sectionList = sectionService.GetModelList("");

            foreach (Section section in sectionList)
            {
                section.housecount = houseService.GetRecordCount("sid =" +section.sid);
            }

            Response.Write("12");

        }
    }
}