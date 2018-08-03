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
namespace myhouse.Web.House
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int hid=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(hid);
				}
			}
		}
			
	private void ShowInfo(int hid)
	{
		myhouse.BLL.HouseService bll=new myhouse.BLL.HouseService();
		myhouse.Model.House model=bll.GetModel(hid);
		this.lblhid.Text=model.hid.ToString();
		this.lblcid.Text=model.cid.ToString();
		this.lbluid.Text=model.uid.ToString();
		this.lblsid.Text=model.sid.ToString();
		this.txthname.Text=model.hname;
		this.txthdescription.Text=model.hdescription;
		this.txthmoney.Text=model.hmoney;
		this.txthtype.Text=model.htype.ToString();
		this.txthphotoone.Text=model.hphotoone;
		this.txthphototwo.Text=model.hphototwo;
		this.txthphotothree.Text=model.hphotothree;
		this.txthphotofour.Text=model.hphotofour;
		this.txthfloor.Text=model.hfloor;
		this.txthsize.Text=model.hsize;
		this.txtharea.Text=model.harea.ToString();
		this.txthcommunity.Text=model.hcommunity;
		this.txthadress.Text=model.hadress;
		this.txthtime.Text=model.htime.ToString();
		this.txthmode.Text=model.hmode.ToString();
		this.txthstatus.Text=model.hstatus.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txthname.Text.Trim().Length==0)
			{
				strErr+="hname不能为空！\\n";	
			}
			if(this.txthdescription.Text.Trim().Length==0)
			{
				strErr+="hdescription不能为空！\\n";	
			}
			if(this.txthmoney.Text.Trim().Length==0)
			{
				strErr+="hmoney不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txthtype.Text))
			{
				strErr+="htype格式错误！\\n";	
			}
			if(this.txthphotoone.Text.Trim().Length==0)
			{
				strErr+="hphotoone不能为空！\\n";	
			}
			if(this.txthphototwo.Text.Trim().Length==0)
			{
				strErr+="hphototwo不能为空！\\n";	
			}
			if(this.txthphotothree.Text.Trim().Length==0)
			{
				strErr+="hphotothree不能为空！\\n";	
			}
			if(this.txthphotofour.Text.Trim().Length==0)
			{
				strErr+="hphotofour不能为空！\\n";	
			}
			if(this.txthfloor.Text.Trim().Length==0)
			{
				strErr+="hfloor不能为空！\\n";	
			}
			if(this.txthsize.Text.Trim().Length==0)
			{
				strErr+="hsize不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtharea.Text))
			{
				strErr+="harea格式错误！\\n";	
			}
			if(this.txthcommunity.Text.Trim().Length==0)
			{
				strErr+="hcommunity不能为空！\\n";	
			}
			if(this.txthadress.Text.Trim().Length==0)
			{
				strErr+="hadress不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txthtime.Text))
			{
				strErr+="htime格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txthmode.Text))
			{
				strErr+="hmode格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txthstatus.Text))
			{
				strErr+="hstatus格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int hid=int.Parse(this.lblhid.Text);
			int cid=int.Parse(this.lblcid.Text);
			int uid=int.Parse(this.lbluid.Text);
			int sid=int.Parse(this.lblsid.Text);
			string hname=this.txthname.Text;
			string hdescription=this.txthdescription.Text;
			string hmoney=this.txthmoney.Text;
			int htype=int.Parse(this.txthtype.Text);
			string hphotoone=this.txthphotoone.Text;
			string hphototwo=this.txthphototwo.Text;
			string hphotothree=this.txthphotothree.Text;
			string hphotofour=this.txthphotofour.Text;
			string hfloor=this.txthfloor.Text;
			string hsize=this.txthsize.Text;
			int harea=int.Parse(this.txtharea.Text);
			string hcommunity=this.txthcommunity.Text;
			string hadress=this.txthadress.Text;
			DateTime htime=DateTime.Parse(this.txthtime.Text);
			int hmode=int.Parse(this.txthmode.Text);
			int hstatus=int.Parse(this.txthstatus.Text);


			myhouse.Model.House model=new myhouse.Model.House();
			model.hid=hid;
			model.cid=cid;
			model.uid=uid;
			model.sid=sid;
			model.hname=hname;
			model.hdescription=hdescription;
			model.hmoney=hmoney;
			model.htype=htype;
			model.hphotoone=hphotoone;
			model.hphototwo=hphototwo;
			model.hphotothree=hphotothree;
			model.hphotofour=hphotofour;
			model.hfloor=hfloor;
			model.hsize=hsize;
			model.harea=harea;
			model.hcommunity=hcommunity;
			model.hadress=hadress;
			model.htime=htime;
			model.hmode=hmode;
			model.hstatus=hstatus;

			myhouse.BLL.HouseService bll=new myhouse.BLL.HouseService();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
