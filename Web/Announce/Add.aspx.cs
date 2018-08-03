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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtwid.Text))
			{
				strErr+="wid格式错误！\\n";	
			}
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
			int wid=int.Parse(this.txtwid.Text);
			string apublisher=this.txtapublisher.Text;
			DateTime atime=DateTime.Parse(this.txtatime.Text);
			string atitle=this.txtatitle.Text;
			string acontent=this.txtacontent.Text;
			string atype=this.txtatype.Text;

			myhouse.Model.Announce model=new myhouse.Model.Announce();
			model.wid=wid;
			model.apublisher=apublisher;
			model.atime=atime;
			model.atitle=atitle;
			model.acontent=acontent;
			model.atype=atype;

			myhouse.BLL.AnnounceService bll=new myhouse.BLL.AnnounceService();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
