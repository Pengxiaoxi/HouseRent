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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int mid=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(mid);
				}
			}
		}
			
	private void ShowInfo(int mid)
	{
		myhouse.BLL.MenusService bll=new myhouse.BLL.MenusService();
		myhouse.Model.Menus model=bll.GetModel(mid);
		this.lblmid.Text=model.mid.ToString();
		this.txtmname.Text=model.mname;
		this.txtmurl.Text=model.murl;
		this.txtmstatus.Text=model.mstatus.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			int mid=int.Parse(this.lblmid.Text);
			string mname=this.txtmname.Text;
			string murl=this.txtmurl.Text;
			int mstatus=int.Parse(this.txtmstatus.Text);


			myhouse.Model.Menus model=new myhouse.Model.Menus();
			model.mid=mid;
			model.mname=mname;
			model.murl=murl;
			model.mstatus=mstatus;

			myhouse.BLL.MenusService bll=new myhouse.BLL.MenusService();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
