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
namespace myhouse.Web.User
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int uid=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(uid);
				}
			}
		}
			
	private void ShowInfo(int uid)
	{
		myhouse.BLL.UserService bll=new myhouse.BLL.UserService();
		myhouse.Model.User model=bll.GetModel(uid);
		this.lbluid.Text=model.uid.ToString();
		this.txtunickname.Text=model.unickname;
		this.txtuname.Text=model.uname;
		this.txtusex.Text=model.usex;
		this.txtuphoto.Text=model.uphoto;
		this.lblucard.Text=model.ucard;
		this.txtucardphoto.Text=model.ucardphoto;
		this.txtupassword.Text=model.upassword;
		this.txtutel.Text=model.utel;
		this.txtuqq.Text=model.uqq;
		this.txtuemail.Text=model.uemail;
		this.txturegtime.Text=model.uregtime.ToString();
		this.txtucredit.Text=model.ucredit;
		this.txtutype.Text=model.utype;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtunickname.Text.Trim().Length==0)
			{
				strErr+="unickname不能为空！\\n";	
			}
			if(this.txtuname.Text.Trim().Length==0)
			{
				strErr+="uname不能为空！\\n";	
			}
			if(this.txtusex.Text.Trim().Length==0)
			{
				strErr+="usex不能为空！\\n";	
			}
			if(this.txtuphoto.Text.Trim().Length==0)
			{
				strErr+="uphoto不能为空！\\n";	
			}
			if(this.txtucardphoto.Text.Trim().Length==0)
			{
				strErr+="ucardphoto不能为空！\\n";	
			}
			if(this.txtupassword.Text.Trim().Length==0)
			{
				strErr+="upassword不能为空！\\n";	
			}
			if(this.txtutel.Text.Trim().Length==0)
			{
				strErr+="utel不能为空！\\n";	
			}
			if(this.txtuqq.Text.Trim().Length==0)
			{
				strErr+="uqq不能为空！\\n";	
			}
			if(this.txtuemail.Text.Trim().Length==0)
			{
				strErr+="uemail不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txturegtime.Text))
			{
				strErr+="uregtime格式错误！\\n";	
			}
			if(this.txtucredit.Text.Trim().Length==0)
			{
				strErr+="ucredit不能为空！\\n";	
			}
			if(this.txtutype.Text.Trim().Length==0)
			{
				strErr+="utype不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int uid=int.Parse(this.lbluid.Text);
			string unickname=this.txtunickname.Text;
			string uname=this.txtuname.Text;
			string usex=this.txtusex.Text;
			string uphoto=this.txtuphoto.Text;
			string ucard=this.lblucard.Text;
			string ucardphoto=this.txtucardphoto.Text;
			string upassword=this.txtupassword.Text;
			string utel=this.txtutel.Text;
			string uqq=this.txtuqq.Text;
			string uemail=this.txtuemail.Text;
			DateTime uregtime=DateTime.Parse(this.txturegtime.Text);
			string ucredit=this.txtucredit.Text;
			string utype=this.txtutype.Text;


			myhouse.Model.User model=new myhouse.Model.User();
			model.uid=uid;
			model.unickname=unickname;
			model.uname=uname;
			model.usex=usex;
			model.uphoto=uphoto;
			model.ucard=ucard;
			model.ucardphoto=ucardphoto;
			model.upassword=upassword;
			model.utel=utel;
			model.uqq=uqq;
			model.uemail=uemail;
			model.uregtime=uregtime;
			model.ucredit=ucredit;
			model.utype=utype;

			myhouse.BLL.UserService bll=new myhouse.BLL.UserService();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
