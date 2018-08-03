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
namespace myhouse.Web.Manage
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int wid = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					wid=(Convert.ToInt32(Request.Params["id0"]));
				}
				int sid = -1;
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					sid=(Convert.ToInt32(Request.Params["id1"]));
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(wid,sid);
			}
		}
		
	private void ShowInfo(int wid,int sid)
	{
		myhouse.BLL.ManageService bll=new myhouse.BLL.ManageService();
		myhouse.Model.Manage model=bll.GetModel(wid,sid);
		this.lblwid.Text=model.wid.ToString();
		this.lblsid.Text=model.sid.ToString();

	}


    }
}
