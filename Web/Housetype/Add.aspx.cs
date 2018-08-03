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
namespace myhouse.Web.Housetype
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtttype.Text))
			{
				strErr+="ttype格式错误！\\n";	
			}
			if(this.txttcontent.Text.Trim().Length==0)
			{
				strErr+="tcontent不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int ttype=int.Parse(this.txtttype.Text);
			string tcontent=this.txttcontent.Text;

			myhouse.Model.Housetype model=new myhouse.Model.Housetype();
			model.ttype=ttype;
			model.tcontent=tcontent;

			myhouse.BLL.HousetypeService bll=new myhouse.BLL.HousetypeService();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
