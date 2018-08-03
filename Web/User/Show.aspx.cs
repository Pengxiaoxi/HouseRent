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
namespace myhouse.Web.User
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
					int uid=(Convert.ToInt32(strid));
					ShowInfo(uid);
				}
			}
		}
		
	private void ShowInfo(int uid)
	{
		myhouse.BLL.UserService bll=new myhouse.BLL.UserService();
		myhouse.Model.User model=bll.GetModel(uid);
		this.lbluid.Text=model.uid.ToString();
		this.lblunickname.Text=model.unickname;
		this.lbluname.Text=model.uname;
		this.lblusex.Text=model.usex;
		this.lbluphoto.Text=model.uphoto;
		this.lblucard.Text=model.ucard;
		this.lblucardphoto.Text=model.ucardphoto;
		this.lblupassword.Text=model.upassword;
		this.lblutel.Text=model.utel;
		this.lbluqq.Text=model.uqq;
		this.lbluemail.Text=model.uemail;
		this.lbluregtime.Text=model.uregtime.ToString();
		this.lblucredit.Text=model.ucredit;
		this.lblutype.Text=model.utype;

	}


    }
}
