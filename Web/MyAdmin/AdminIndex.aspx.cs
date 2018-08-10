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
            else if (flag == "usertype")
            {
                this.usertypelist();
            }
            else if (flag == "housestatus")
            {
                this.housestatuslist();
            }
            else if (flag == "houseadd")
            {
                this.houseaddnumber();
            }
            else
            {
                //this.show();
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

        //=======================================
        //返回用户类别与其数量转换为json返回前台
        protected void usertypelist()
        {
            //List<User> userList = userService.GetModelList("");

            List<User> userList2 = userService.GetModelList("utype= "+0);   //待审核

            List<User> userList3 = userService.GetModelList("utype= "+1);   //租赁者

            List<User> userList4 = userService.GetModelList("utype= "+2);   //房主

            //存放用户类型及其数量
            ArrayList usertypelist = new ArrayList();

            for (int i = 0; i < 3; i++)
            {
                Hashtable ht = new Hashtable();

                //注意json的写法
                if (i == 0)
                {
                    ht.Add("usertype", "待审核"+(userList2.Count));
                    ht.Add("usercount", "" + userList2.Count + "");      
                }
                else if (i == 1)
                {
                    ht.Add("usertype", "租赁者"+(userList3.Count));
                    ht.Add("usercount", "" + userList3.Count + "");
                }
                else if (i == 2)
                {
                    ht.Add("usertype", "房主"+(userList4.Count));
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

        //================返回房屋状态列表转换为json返回前台==================//
        protected void housestatuslist()
        {
            List<House> houseList2 = houseService.GetModelList("hstatus= " + 0);   //待审核

            List<House> houseList3 = houseService.GetModelList("hstatus= " + 1);   //正常

            List<House> houseList4 = houseService.GetModelList("hstatus= " + 2);   //不合法

            //存放房屋状态及其数量
            ArrayList housestatuslist = new ArrayList();

            for (int i = 0; i < 3; i++)
            {
                Hashtable ht = new Hashtable();

                //注意json的写法
                if (i == 0)
                {
                    ht.Add("housestatus", "待审核" + (houseList2.Count));
                    ht.Add("housestatuscount", "" + houseList2.Count + "");
                }
                else if (i == 1)
                {
                    ht.Add("housestatus", "正常" + (houseList3.Count));
                    ht.Add("housestatuscount", "" + houseList3.Count + "");
                }
                else if (i == 2)
                {
                    ht.Add("housestatus", "不合法" + (houseList4.Count));
                    ht.Add("housestatuscount", "" + houseList4.Count + "");
                }
                housestatuslist.Add(ht);
            }

            //JavaScriptSerializer  生成JSON数据
            JavaScriptSerializer ser = new JavaScriptSerializer();

            jsonStr = ser.Serialize(housestatuslist);

            Response.Write(jsonStr);

            Response.End();
        }


        //================返回每日房屋添加数转换为json返回前台==================//
        protected void houseaddnumber()
        {
            string today1,today2 = "";

            List<House> houseaddcountList;

            //string today = DateTime.Now.ToString("MM'月'dd'日'");
            //string today2 = DateTime.Now.ToString("MM-dd");

            //查询昨天
            //string yestaday = DateTime.Now.AddDays(-1).ToString("MM'月'dd'日'");

            //需要将时间转换为string在进行模糊查询
            //List<House> houseaddcountList = houseService.GetModelList(" CONVERT(varchar,htime,120) like '%" + today2+"'%");

            //存放房屋状态及其数量
            ArrayList houseaddnumber = new ArrayList();

            //倒着存入数据。这样today的数据就在最后面
            for (int i = 5; i > 0; i--)
            {
                Hashtable ht = new Hashtable();

                //-i+1  把今天包括进去
                today1 = DateTime.Now.AddDays(-i+1).ToString("MM'月'dd'日'");
                today2 = DateTime.Now.AddDays(-i+1).ToString("MM-dd");
                houseaddcountList = houseService.GetModelList(" CONVERT(varchar,htime,120) like '%" + today2 + "%'");

                //注意json的写法
                ht.Add("housetime", today1);
                ht.Add("dayhousecount", "" + houseaddcountList.Count + "");

                houseaddnumber.Add(ht);
            }

            //JavaScriptSerializer  生成JSON数据
            JavaScriptSerializer ser = new JavaScriptSerializer();

            jsonStr = ser.Serialize(houseaddnumber);

            Response.Write(jsonStr);

            Response.End();
        }


        //测试
        //protected void show()
        //{
        //    string today = DateTime.Now.ToString("MM'月'dd'日'");
        //    string today2 = DateTime.Now.ToString("MM-dd");

        //    string yestaday = DateTime.Now.AddDays(-5).ToString("MM'月'dd'日'");

        //    List<House> houseaddcountList = houseService.GetModelList(" CONVERT(varchar,htime,120) like '%" + today2 + "%'");
        //    Response.Write(houseaddcountList.Count);
        //    Response.Write(today);
        //    Response.Write(yestaday);
        //}

      }
}