using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace myhouse.Web.Section
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int sid=(Convert.ToInt32(strid));
					ShowInfo(sid);
				}
			}
		}
		
	private void ShowInfo(int sid)
	{
		myhouse.BLL.SectionService bll=new myhouse.BLL.SectionService();
		myhouse.Model.Section model=bll.GetModel(sid);
		this.lblsid.Text=model.sid.ToString();
		this.lblsname.Text=model.sname;
		this.lblsdescription.Text=model.sdescription;

	}


    }
}
