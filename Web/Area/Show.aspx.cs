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
namespace myhouse.Web.Area
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
					int areaid=(Convert.ToInt32(strid));
					ShowInfo(areaid);
				}
			}
		}
		
	private void ShowInfo(int areaid)
	{
		myhouse.BLL.AreaService bll=new myhouse.BLL.AreaService();
		myhouse.Model.Area model=bll.GetModel(areaid);
		this.lblareaid.Text=model.areaid.ToString();
		this.lblareaname.Text=model.areaname;

	}


    }
}
