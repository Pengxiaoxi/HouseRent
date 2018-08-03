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
namespace myhouse.Web.Contract
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtuid.Text))
			{
				strErr+="uid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txthid.Text))
			{
				strErr+="hid格式错误！\\n";	
			}
			if(this.txtcname.Text.Trim().Length==0)
			{
				strErr+="cname不能为空！\\n";	
			}
			if(this.txtccontent.Text.Trim().Length==0)
			{
				strErr+="ccontent不能为空！\\n";	
			}
			if(this.txtcphoto.Text.Trim().Length==0)
			{
				strErr+="cphoto不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtcstatus.Text))
			{
				strErr+="cstatus格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int uid=int.Parse(this.txtuid.Text);
			int hid=int.Parse(this.txthid.Text);
			string cname=this.txtcname.Text;
			string ccontent=this.txtccontent.Text;
			string cphoto=this.txtcphoto.Text;
			int cstatus=int.Parse(this.txtcstatus.Text);

			myhouse.Model.Contract model=new myhouse.Model.Contract();
			model.uid=uid;
			model.hid=hid;
			model.cname=cname;
			model.ccontent=ccontent;
			model.cphoto=cphoto;
			model.cstatus=cstatus;

			myhouse.BLL.ContractService bll=new myhouse.BLL.ContractService();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
