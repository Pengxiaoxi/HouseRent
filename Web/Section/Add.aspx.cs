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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			string sname=this.txtsname.Text;
			string sdescription=this.txtsdescription.Text;

			myhouse.Model.Section model=new myhouse.Model.Section();
			model.sname=sname;
			model.sdescription=sdescription;

			myhouse.BLL.SectionService bll=new myhouse.BLL.SectionService();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
