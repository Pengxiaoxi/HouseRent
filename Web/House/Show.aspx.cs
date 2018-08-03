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
namespace myhouse.Web.House
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
					int hid=(Convert.ToInt32(strid));
					ShowInfo(hid);
				}
			}
		}
		
	private void ShowInfo(int hid)
	{
		myhouse.BLL.HouseService bll=new myhouse.BLL.HouseService();
		myhouse.Model.House model=bll.GetModel(hid);
		this.lblhid.Text=model.hid.ToString();
		this.lblcid.Text=model.cid.ToString();
		this.lbluid.Text=model.uid.ToString();
		this.lblsid.Text=model.sid.ToString();
		this.lblhname.Text=model.hname;
		this.lblhdescription.Text=model.hdescription;
		this.lblhmoney.Text=model.hmoney;
		this.lblhtype.Text=model.htype.ToString();
		this.lblhphotoone.Text=model.hphotoone;
		this.lblhphototwo.Text=model.hphototwo;
		this.lblhphotothree.Text=model.hphotothree;
		this.lblhphotofour.Text=model.hphotofour;
		this.lblhfloor.Text=model.hfloor;
		this.lblhsize.Text=model.hsize;
		this.lblharea.Text=model.harea.ToString();
		this.lblhcommunity.Text=model.hcommunity;
		this.lblhadress.Text=model.hadress;
		this.lblhtime.Text=model.htime.ToString();
		this.lblhmode.Text=model.hmode.ToString();
		this.lblhstatus.Text=model.hstatus.ToString();

	}


    }
}
