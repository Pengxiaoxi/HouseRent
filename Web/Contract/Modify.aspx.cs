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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int cid=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(cid);
				}
			}
		}
			
	private void ShowInfo(int cid)
	{
		myhouse.BLL.ContractService bll=new myhouse.BLL.ContractService();
		myhouse.Model.Contract model=bll.GetModel(cid);
		this.lblcid.Text=model.cid.ToString();
		this.lbluid.Text=model.uid.ToString();
		this.lblhid.Text=model.hid.ToString();
		this.txtcname.Text=model.cname;
		this.txtccontent.Text=model.ccontent;
		this.txtcphoto.Text=model.cphoto;
		this.txtcstatus.Text=model.cstatus.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
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
			int cid=int.Parse(this.lblcid.Text);
			int uid=int.Parse(this.lbluid.Text);
			int hid=int.Parse(this.lblhid.Text);
			string cname=this.txtcname.Text;
			string ccontent=this.txtccontent.Text;
			string cphoto=this.txtcphoto.Text;
			int cstatus=int.Parse(this.txtcstatus.Text);


			myhouse.Model.Contract model=new myhouse.Model.Contract();
			model.cid=cid;
			model.uid=uid;
			model.hid=hid;
			model.cname=cname;
			model.ccontent=ccontent;
			model.cphoto=cphoto;
			model.cstatus=cstatus;

			myhouse.BLL.ContractService bll=new myhouse.BLL.ContractService();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
