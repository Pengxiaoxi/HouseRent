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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int wid = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					wid=(Convert.ToInt32(Request.Params["id0"]));
				}
				int sid = -1;
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					sid=(Convert.ToInt32(Request.Params["id1"]));
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(wid,sid);
			}
		}
			
	private void ShowInfo(int wid,int sid)
	{
		myhouse.BLL.ManageService bll=new myhouse.BLL.ManageService();
		myhouse.Model.Manage model=bll.GetModel(wid,sid);
		this.lblwid.Text=model.wid.ToString();
		this.lblsid.Text=model.sid.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int wid=int.Parse(this.lblwid.Text);
			int sid=int.Parse(this.lblsid.Text);


			myhouse.Model.Manage model=new myhouse.Model.Manage();
			model.wid=wid;
			model.sid=sid;

			myhouse.BLL.ManageService bll=new myhouse.BLL.ManageService();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
