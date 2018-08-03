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
namespace myhouse.Web.Announce
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int aid=(Convert.ToInt32(Request.Params["id"]));
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
		this.txtapublisher.Text=model.apublisher;
		this.txtatime.Text=model.atime.ToString();
		this.txtatitle.Text=model.atitle;
		this.txtacontent.Text=model.acontent;
		this.txtatype.Text=model.atype;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtapublisher.Text.Trim().Length==0)
			{
				strErr+="apublisher不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtatime.Text))
			{
				strErr+="atime格式错误！\\n";	
			}
			if(this.txtatitle.Text.Trim().Length==0)
			{
				strErr+="atitle不能为空！\\n";	
			}
			if(this.txtacontent.Text.Trim().Length==0)
			{
				strErr+="acontent不能为空！\\n";	
			}
			if(this.txtatype.Text.Trim().Length==0)
			{
				strErr+="atype不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int aid=int.Parse(this.lblaid.Text);
			int wid=int.Parse(this.lblwid.Text);
			string apublisher=this.txtapublisher.Text;
			DateTime atime=DateTime.Parse(this.txtatime.Text);
			string atitle=this.txtatitle.Text;
			string acontent=this.txtacontent.Text;
			string atype=this.txtatype.Text;


			myhouse.Model.Announce model=new myhouse.Model.Announce();
			model.aid=aid;
			model.wid=wid;
			model.apublisher=apublisher;
			model.atime=atime;
			model.atitle=atitle;
			model.acontent=acontent;
			model.atype=atype;

			myhouse.BLL.AnnounceService bll=new myhouse.BLL.AnnounceService();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
