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
    public partial class HouseModify : System.Web.UI.Page
    {
        public House house { get; set; }
        public List<Section> sectionList { get; set; }
        public List<Housetype> hyList { get; set; }
        public List<Area> areaList { get; set; }

        //选择框默认显示
        public int hid { get; set; }
        public int hmode { get; set; }
        public int sid { get; set; }
        public int htype { get; set; }
        public int areaid { get; set; }

        HouseService houseService = new HouseService();

        protected void Page_Load(object sender, EventArgs e)
        {
            SectionService sectionService = new SectionService();
            HousetypeService hyService = new HousetypeService();
            AreaService areaSevice = new AreaService();

            sectionList = sectionService.GetModelList("");
            hyList = hyService.GetModelList("");
            areaList = areaSevice.GetModelList("");

            hid = Int32.Parse(Request["hid"]);

            house = houseService.GetModel(hid);

            hmode = (int)house.hmode;

            sid = house.sid;

            htype = (int)house.htype;

            areaid = (int)house.harea;

            if (IsPostBack)
            {
                this.update();
            }
        }

        //更新房屋信息
        protected void update()
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;  //多文件上传

            //string photo1 = "", photo2 = "", photo3 = "", photo4 = "";

            //string photo1 = Request.MapPath(house.hphotoone);
            //string photo2 = Request.MapPath(house.hphotoone);
            //string photo3 = Request.MapPath(house.hphotoone);
            //string photo4 = Request.MapPath(house.hphotoone);

            //string photo4 = OpenFile(house.hphotoone).ToString();

            string photo1 = Request["housephoto1"];
            string photo2 = Request["housephoto2"];
            string photo3 = Request["housephoto3"];
            string photo4 = Request["housephoto4"];

            string[] photo = { photo1, photo2, photo3, photo4 };   //存放四个房屋图片

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
                        //photo[i] = files[i].FileName; //默认头像
                    }
                }
                else
                {
                    //photo[i] = files[i].FileName;
                }
            }

            house = houseService.GetModel(hid);

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

            //house.htime = DateTime.Now;
            house.hmode = Int32.Parse(Request["hmode"]);
            house.hstatus = Int32.Parse(Request["hstatus"]);

            if (houseService.UpdateAll(house))
            {
                Response.Redirect("/MyHouse.aspx");
            }
            else
            {
                Response.Write("<script>alter(修改失败！)</script>");
            }
        }
    }
}