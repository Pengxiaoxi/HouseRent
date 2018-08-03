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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			if(this.txtwcard.Text.Trim().Length==0)
			{
				strErr+="wcard不能为空！\\n";	
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
			string wname=this.txtwname.Text;
			string wsex=this.txtwsex.Text;
			string wphoto=this.txtwphoto.Text;
			string wcard=this.txtwcard.Text;
			string wpassword=this.txtwpassword.Text;
			string wtel=this.txtwtel.Text;
			string wemail=this.txtwemail.Text;
			string wadress=this.txtwadress.Text;
			string wtype=this.txtwtype.Text;

			myhouse.Model.Worker model=new myhouse.Model.Worker();
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
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
