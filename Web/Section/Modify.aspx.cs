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
namespace myhouse.Web.Section
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int sid=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(sid);
				}
			}
		}
			
	private void ShowInfo(int sid)
	{
		myhouse.BLL.SectionService bll=new myhouse.BLL.SectionService();
		myhouse.Model.Section model=bll.GetModel(sid);
		this.lblsid.Text=model.sid.ToString();
		this.txtsname.Text=model.sname;
		this.txtsdescription.Text=model.sdescription;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtsname.Text.Trim().Length==0)
			{
				strErr+="sname不能为空！\\n";	
			}
			if(this.txtsdescription.Text.Trim().Length==0)
			{
				strErr+="sdescription不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int sid=int.Parse(this.lblsid.Text);
			string sname=this.txtsname.Text;
			string sdescription=this.txtsdescription.Text;


			myhouse.Model.Section model=new myhouse.Model.Section();
			model.sid=sid;
			model.sname=sname;
			model.sdescription=sdescription;

			myhouse.BLL.SectionService bll=new myhouse.BLL.SectionService();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
