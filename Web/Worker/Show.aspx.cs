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
namespace myhouse.Web.Worker
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
					int wid=(Convert.ToInt32(strid));
					ShowInfo(wid);
				}
			}
		}
		
	private void ShowInfo(int wid)
	{
		myhouse.BLL.WorkerService bll=new myhouse.BLL.WorkerService();
		myhouse.Model.Worker model=bll.GetModel(wid);
		this.lblwid.Text=model.wid.ToString();
		this.lblwname.Text=model.wname;
		this.lblwsex.Text=model.wsex;
		this.lblwphoto.Text=model.wphoto;
		this.lblwcard.Text=model.wcard;
		this.lblwpassword.Text=model.wpassword;
		this.lblwtel.Text=model.wtel;
		this.lblwemail.Text=model.wemail;
		this.lblwadress.Text=model.wadress;
		this.lblwtype.Text=model.wtype;

	}


    }
}
