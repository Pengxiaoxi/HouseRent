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
namespace myhouse.Web.Menus
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtmname.Text.Trim().Length==0)
			{
				strErr+="mname不能为空！\\n";	
			}
			if(this.txtmurl.Text.Trim().Length==0)
			{
				strErr+="murl不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtmstatus.Text))
			{
				strErr+="mstatus格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string mname=this.txtmname.Text;
			string murl=this.txtmurl.Text;
			int mstatus=int.Parse(this.txtmstatus.Text);

			myhouse.Model.Menus model=new myhouse.Model.Menus();
			model.mname=mname;
			model.murl=murl;
			model.mstatus=mstatus;

			myhouse.BLL.MenusService bll=new myhouse.BLL.MenusService();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
