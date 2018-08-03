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
namespace myhouse.Web.Announce
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
					int aid=(Convert.ToInt32(strid));
					ShowInfo(aid);
				}
			}
		}
		
	private void ShowInfo(int aid)
	{
		myhouse.BLL.AnnounceService bll=new myhouse.BLL.AnnounceService();
		myhouse.Model.Announce model=bll.GetModel(aid);
		this.lblaid.Text=model.aid.ToString();
		this.lblwid.Text=model.wid.ToString();
		this.lblapublisher.Text=model.apublisher;
		this.lblatime.Text=model.atime.ToString();
		this.lblatitle.Text=model.atitle;
		this.lblacontent.Text=model.acontent;
		this.lblatype.Text=model.atype;

	}


    }
}
