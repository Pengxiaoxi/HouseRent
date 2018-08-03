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
namespace myhouse.Web.Area
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int areaid=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(areaid);
				}
			}
		}
			
	private void ShowInfo(int areaid)
	{
		myhouse.BLL.AreaService bll=new myhouse.BLL.AreaService();
		myhouse.Model.Area model=bll.GetModel(areaid);
		this.lblareaid.Text=model.areaid.ToString();
		this.txtareaname.Text=model.areaname;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtareaname.Text.Trim().Length==0)
			{
				strErr+="areaname不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int areaid=int.Parse(this.lblareaid.Text);
			string areaname=this.txtareaname.Text;


			myhouse.Model.Area model=new myhouse.Model.Area();
			model.areaid=areaid;
			model.areaname=areaname;

			myhouse.BLL.AreaService bll=new myhouse.BLL.AreaService();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
