using myhouse.BLL;
using myhouse.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;

namespace myhouse.Web.MyAdmin
{
    public partial class AdminIndex : System.Web.UI.Page
    {
        public string jsonStr { get; set; }

        SectionService sectionService = new SectionService();
        HouseService houseService = new HouseService();
        UserService userService = new UserService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminInfo"] == null)
            {
                Response.Redirect("/MyAdmin/AdminLogin.aspx");
            }

            string flag = Request["flag"];
    
            if (flag == "sname")
            {
                this.housecountlist();
            }
            else if(flag == "usertype")
            {
                this.usertypelist();
            }
            else if (flag == "houseadd")
            {

            }
        }

        //返回房屋板块与板块下房屋数量集合转换为json返回前台
        protected void housecountlist()
        {
            List<Section> sectionList = new List<Section>();
            sectionList = sectionService.GetModelList("");

            foreach (Section section in sectionList)
            {
                section.housecount = houseService.GetRecordCount("sid =" + section.sid);
            }
            //存放板块名与房屋数
            ArrayList housecountlist = new ArrayList();

            for (int i = 0; i < sectionList.Count; i++)
            {
                Hashtable ht = new Hashtable();

                //注意json的写法
                if (sectionList[i].housecount > 0)
                {
                    ht.Add("sname", sectionList[i].sname);
                    ht.Add("housecount", "" + sectionList[i].housecount + "");
                }
                else
                {
                    ht.Add("sname", sectionList[i].sname);
                    ht.Add("housecount", "0");
                }

                housecountlist.Add(ht);
            }

            //JavaScriptSerializer  生成JSON数据
            JavaScriptSerializer ser = new JavaScriptSerializer();

            jsonStr = ser.Serialize(housecountlist);

            Response.Write(jsonStr);

            Response.End();
        }

        //返回用户类别与其数量转换为json返回前台
        protected void usertypelist()
        {
            List<User> userList = userService.GetModelList("");

            List<User> userList2 = userService.GetModelList("utype= "+0);   //待审核

            List<User> userList3 = userService.GetModelList("utype= "+1);   //租赁者

            List<User> userList4 = userService.GetModelList("utype= "+2);   //房主

            //存放用户类型及其数量
            ArrayList usertypelist = new ArrayList();

            //Hashtable ht = new Hashtable();

            //ht.Add("usertype", "待审核");
            //ht.Add("housecount", "" + userList2.Count + "");
            //ht.Add("usertype", "租赁者");
            //ht.Add("housecount", "" + userList3.Count + "");
            //ht.Add("usertype", "房主");
            //ht.Add("housecount", "" + userList4.Count + "");

            //usertypelist.Add(ht);

            //for (int i = 0; i < userList.Count; i++)
            //{
            //    Hashtable ht = new Hashtable();

            //    //注意json的写法
            //    if (userList[i].utype == "0   ")
            //    {
            //        ht.Add("usertype", "待审核");
            //        ht.Add("housecount", "" + userList2.Count + "");
            //    }
            //    else if (userList[i].utype == "1   ")
            //    {
            //        ht.Add("usertype", "租赁者");
            //        ht.Add("housecount", "" + userList3.Count + "");
            //    }
            //    else if (userList[i].utype == "2   ")
            //    {
            //        ht.Add("usertype", "房主");
            //        ht.Add("housecount", "" + userList4.Count + "");
            //    }
            //    usertypelist.Add(ht);
            //}

            for (int i = 0; i < 3; i++)
            {
                Hashtable ht = new Hashtable();

                //注意json的写法
                if (i == 0)
                {
                    ht.Add("usertype", "待审核");
                    ht.Add("usercount", "" + userList2.Count + "");      
                }
                else if (i == 1)
                {
                    ht.Add("usertype", "租赁者");
                    ht.Add("usercount", "" + userList3.Count + "");
                }
                else if (i == 2)
                {
                    ht.Add("usertype", "房主");
                    ht.Add("usercount", "" + userList4.Count + "");
                }
                usertypelist.Add(ht);
            }


            //JavaScriptSerializer  生成JSON数据
            JavaScriptSerializer ser = new JavaScriptSerializer();

            jsonStr = ser.Serialize(usertypelist);

            Response.Write(jsonStr);

            Response.End();
        }


      }
}