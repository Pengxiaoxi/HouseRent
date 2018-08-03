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
namespace myhouse.Web.Menus
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
					int mid=(Convert.ToInt32(strid));
					ShowInfo(mid);
				}
			}
		}
		
	private void ShowInfo(int mid)
	{
		myhouse.BLL.MenusService bll=new myhouse.BLL.MenusService();
		myhouse.Model.Menus model=bll.GetModel(mid);
		this.lblmid.Text=model.mid.ToString();
		this.lblmname.Text=model.mname;
		this.lblmurl.Text=model.murl;
		this.lblmstatus.Text=model.mstatus.ToString();

	}


    }
}
