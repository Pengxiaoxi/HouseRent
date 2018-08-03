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
namespace myhouse.Web.Housetype
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
					int tid=(Convert.ToInt32(strid));
					ShowInfo(tid);
				}
			}
		}
		
	private void ShowInfo(int tid)
	{
		myhouse.BLL.HousetypeService bll=new myhouse.BLL.HousetypeService();
		myhouse.Model.Housetype model=bll.GetModel(tid);
		this.lbltid.Text=model.tid.ToString();
		this.lblttype.Text=model.ttype.ToString();
		this.lbltcontent.Text=model.tcontent;

	}


    }
}
