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
namespace myhouse.Web.Manage
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
			if(!PageValidate.IsNumber(txtsid.Text))
			{
				strErr+="sid格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int wid=int.Parse(this.txtwid.Text);
			int sid=int.Parse(this.txtsid.Text);

			myhouse.Model.Manage model=new myhouse.Model.Manage();
			model.wid=wid;
			model.sid=sid;

			myhouse.BLL.ManageService bll=new myhouse.BLL.ManageService();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
