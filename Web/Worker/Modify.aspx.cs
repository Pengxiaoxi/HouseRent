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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace myhouse.Web.Worker
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int wid=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(wid);
				}
			}
		}
			
	private void ShowInfo(int wid)
	{
		myhouse.BLL.WorkerService bll=new myhouse.BLL.WorkerService();
		myhouse.Model.Worker model=bll.GetModel(wid);
		this.lblwid.Text=model.wid.ToString();
		this.txtwname.Text=model.wname;
		this.txtwsex.Text=model.wsex;
		this.txtwphoto.Text=model.wphoto;
		this.lblwcard.Text=model.wcard;
		this.txtwpassword.Text=model.wpassword;
		this.txtwtel.Text=model.wtel;
		this.txtwemail.Text=model.wemail;
		this.txtwadress.Text=model.wadress;
		this.txtwtype.Text=model.wtype;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtwname.Text.Trim().Length==0)
			{
				strErr+="wname不能为空！\\n";	
			}
			if(this.txtwsex.Text.Trim().Length==0)
			{
				strErr+="wsex不能为空！\\n";	
			}
			if(this.txtwphoto.Text.Trim().Length==0)
			{
				strErr+="wphoto不能为空！\\n";	
			}
			if(this.txtwpassword.Text.Trim().Length==0)
			{
				strErr+="wpassword不能为空！\\n";	
			}
			if(this.txtwtel.Text.Trim().Length==0)
			{
				strErr+="wtel不能为空！\\n";	
			}
			if(this.txtwemail.Text.Trim().Length==0)
			{
				strErr+="wemail不能为空！\\n";	
			}
			if(this.txtwadress.Text.Trim().Length==0)
			{
				strErr+="wadress不能为空！\\n";	
			}
			if(this.txtwtype.Text.Trim().Length==0)
			{
				strErr+="wtype不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int wid=int.Parse(this.lblwid.Text);
			string wname=this.txtwname.Text;
			string wsex=this.txtwsex.Text;
			string wphoto=this.txtwphoto.Text;
			string wcard=this.lblwcard.Text;
			string wpassword=this.txtwpassword.Text;
			string wtel=this.txtwtel.Text;
			string wemail=this.txtwemail.Text;
			string wadress=this.txtwadress.Text;
			string wtype=this.txtwtype.Text;


			myhouse.Model.Worker model=new myhouse.Model.Worker();
			model.wid=wid;
			model.wname=wname;
			model.wsex=wsex;
			model.wphoto=wphoto;
			model.wcard=wcard;
			model.wpassword=wpassword;
			model.wtel=wtel;
			model.wemail=wemail;
			model.wadress=wadress;
			model.wtype=wtype;

			myhouse.BLL.WorkerService bll=new myhouse.BLL.WorkerService();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
