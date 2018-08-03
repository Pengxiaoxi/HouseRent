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
namespace myhouse.Web.Contract
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
					int cid=(Convert.ToInt32(strid));
					ShowInfo(cid);
				}
			}
		}
		
	private void ShowInfo(int cid)
	{
		myhouse.BLL.ContractService bll=new myhouse.BLL.ContractService();
		myhouse.Model.Contract model=bll.GetModel(cid);
		this.lblcid.Text=model.cid.ToString();
		this.lbluid.Text=model.uid.ToString();
		this.lblhid.Text=model.hid.ToString();
		this.lblcname.Text=model.cname;
		this.lblccontent.Text=model.ccontent;
		this.lblcphoto.Text=model.cphoto;
		this.lblcstatus.Text=model.cstatus.ToString();

	}


    }
}
