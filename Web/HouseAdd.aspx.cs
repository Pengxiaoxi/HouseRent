using myhouse.BLL;
using myhouse.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myhouse.Web
{
    public partial class HouseAdd : System.Web.UI.Page
    {
        public List<Section> sectionList { get; set; }
        public List<Housetype> hyList { get; set; }
        public List<Area> areaList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //防止直接打开此页面进行发布
            if (Session["userInfo"] == null)
            {
                Response.Redirect("/Index.aspx");
            }
            else 
            {
                if (((User)Session["userInfo"]).utype != "2   ")
                {
                    Response.Redirect("/MyHouse.aspx");
                }
                else
                {
                    this.add();
                }
            }

        }


        //房屋信息添加方法
        protected void add()
        {
            if (IsPostBack)
            {
                HttpFileCollection files = HttpContext.Current.Request.Files;  //多文件上传

                string photo1 = "", photo2 = "", photo3 = "", photo4 = "";

                string[] photo = { photo1, photo2, photo3, photo4};

                //通过for循环判断并存储所有上传的图片
                for (int i = 0; i < files.Count; i++)
                {
                    if (files[i] != null && !files[i].FileName.Equals(""))
                    {    //判断文件是否为空

                        string fileName = files[i].FileName;   //得到上传图片的文件名字

                        string ext = Path.GetExtension(fileName);   //得到上传图片的文件扩展名

                        if (ext == ".jpg" || ext == ".gif" || ext == ".png" || ext == ".jpeg" || ext == ".JPG" || ext == ".bmp") //设定文件的类型
                        {
                            string newFileNames = Guid.NewGuid().ToString() + ext;

                            string fileSavePath = Request.MapPath("/HousePhoto/" + newFileNames);   //保存路径HousePhoto

                            photo[i] = "/HousePhoto/" + newFileNames;

                            files[i].SaveAs(fileSavePath);   //保存图片到服务器指定的目录中去
                        }
                        else
                        {
                            photo[i] = "/Images/House/wu.jpg";  //默认头像
                        }
                    }
                    else
                    {
                        photo[i] = "/Images/House/wu.jpg";
                    }
                }

                HouseService houseService = new HouseService();
                House house = new House();

                house.uid = ((User)Session["userInfo"]).uid;
                house.hname = Request["hname"];
                house.sid = Int32.Parse(Request["sid"]);
                house.htype = Int32.Parse(Request["htype"]);
                house.hsize = Request["hsize"];
                house.hfloor = Request["hfloor"];
                house.hmoney = Request["hmoney"];
                house.hcommunity = Request["hcommunity"];
                house.harea = Int32.Parse(Request["harea"]);
                house.hadress = Request["hadress"];
                house.hdescription = Request["hdescription"];
                house.hphotoone = photo[0];
                house.hphototwo = photo[1];
                house.hphotothree = photo[2];
                house.hphotofour = photo[3];

                house.htime = DateTime.Now;
                house.hmode = Int32.Parse(Request["hmode"]);
                house.hstatus= Int32.Parse(Request["hstatus"]);

                if (houseService.Add(house) > 0)
                {
                    Response.Redirect("/MyHouse.aspx");
                }
                else
                {
                    Response.Write("<script>alter(发布失败！)</script>");    
                }
            }
            else
            {
                SectionService sectionService = new SectionService();
                HousetypeService hyService = new HousetypeService();
                AreaService areaSevice = new AreaService();

                sectionList = sectionService.GetModelList("");
                hyList = hyService.GetModelList("");
                areaList = areaSevice.GetModelList("");
            }
        }
    }
}