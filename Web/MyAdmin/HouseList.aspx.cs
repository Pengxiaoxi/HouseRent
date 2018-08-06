using myhouse.BLL;
using myhouse.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myhouse.Web.MyAdmin
{  
    public partial class HouseList : System.Web.UI.Page
    {
        HouseService houseService = new HouseService();
        SectionService sectionService = new SectionService();
        HousetypeService hyService = new HousetypeService();
        AreaService areaService = new AreaService();
        UserService userService = new UserService();

        public List<Section> sectionList { get; set; }
        public List<Housetype> hyList { get; set; }
        public List<Area> areaList { get; set; }
        public List<House> houseList { get; set; }
        public string pageCode { get; set; }
        public string hname { get; set; }
        public string sid { get; set; }
        public string htype { get; set; }
        public string harea { get; set; }
        public string hmode { get; set; }
        public string hstatus { get; set; }
        public string order { get; set; }
        public string orderby { get; set; }

        //页面载入事件
        protected void Page_Load(object sender, EventArgs e)
        {
            string flag = Request["flag"];

            if (flag == null || "".Equals(flag)) {
                this.showhouse();
            }
            else if (flag == "update") {
                this.updatehouse();
            }
            else if (flag == "delete") {
                this.deletehouse();
            }
            else if (flag == "deletelist") {
                this.deletelist();
            }
        }

        //条件分页查询
        protected void showhouse()
        {
            sectionList = sectionService.GetModelList("");
            hyList = hyService.GetModelList("");
            areaList = areaService.GetModelList("");

            //分页参数分开获取post提交的查询条件与get提交分页参数
            if (IsPostBack){
                hname = Request.Form["hname"];
                sid = Request.Form["sid"];
                htype = Request.Form["htype"];
                harea = Request.Form["harea"];
                hmode = Request.Form["hmode"];
                hstatus = Request.Form["hstatus"];
                order = Request.Form["order"];
            }
            else{
                hname = Request.QueryString["hname"];
                sid = Request.QueryString["sid"];
                htype = Request.QueryString["htype"];
                harea = Request.QueryString["harea"];
                hmode = Request.QueryString["hmode"];
                hstatus = Request.QueryString["hstatus"];
                order = Request.QueryString["order"];
            }

            if (order == null || order == "0")
            {
                order = 0.ToString();
            }

            int page = 1;
            if (!Int32.TryParse(Request["page"], out page))
            {
                page = 1;
            }
            //传递参数获取房屋列表和分页链接
            ArrayList arraylist = houseService.FindHosueListOnWhereByPage(page, hname, sid, htype, harea, hmode, hstatus, order);

            //从动态数组中取出
            houseList = (List<House>)arraylist[0];
            pageCode = arraylist[1].ToString();

            //封装房屋板块,房屋类型,房屋地区到房屋model下
            foreach (House house in houseList)
            {
                house.area = areaService.GetModel((int)house.harea);
                house.housetype = hyService.GetModel((int)house.htype);
                house.section = sectionService.GetModel((int)house.sid);
            }
        }

        //更新房屋信息
        protected void updatehouse()
        {
            int hid = Int32.Parse(Request["hid"]);

            //try
            //{
            //    hid = Int32.Parse(Request["hid"]);
            //}
            //catch (Exception){
            //    Response.Write(false);
            //    Response.End();
            //    return;
            //}

            House house = houseService.GetModel(hid);

            HttpFileCollection files = HttpContext.Current.Request.Files;  //多文件上传

            //数组存放原来的房屋图片信息
            string[] photo = {Request["housephoto1"], Request["housephoto2"], Request["housephoto3"], Request["housephoto4"] };

            for (int i = 0; i < files.Count; i++)
            {
                if (files[i] != null && !"".Equals(files[i]))
                {
                    string fileName = files[i].FileName;   //得到上传的文件的名字
                    string ext = Path.GetExtension(fileName);  //得到其扩展名

                    if (ext == ".jpg" || ext == ".gif" || ext == ".png" || ext == ".jpeg" || ext == ".JPG" || ext == ".bmp")  //设定文件的类型
                    {
                        string newFileNames = Guid.NewGuid().ToString() + ext;   //新文件名（防止重复名字）
                        string fileSavePath = Request.MapPath("/HousePhoto/" + newFileNames);
                        photo[i] = "/HousePhoto/" + newFileNames;   //将新的房屋图片存放在photo[]中

                        files[i].SaveAs(fileSavePath);    //保存
                    }
                }
            }
            house.hname = Request["name"];
            house.sid = Int32.Parse(Request["section"]);
            house.htype = Int32.Parse(Request["tid"]);
            house.hsize = Request["size"];
            house.hfloor = Request["floor"];
            house.hmoney = Request["money"];
            house.hcommunity = Request["community"];
            house.harea = Int32.Parse(Request["area"]);
            house.hadress = Request["adress"];
            house.hdescription = Request["description"];
            house.hstatus = Int32.Parse(Request["status"]);
            house.hmode = Int32.Parse(Request["mode"]);
            house.hphotoone = photo[0];
            house.hphototwo = photo[1];
            house.hphotothree = photo[2];
            house.hphotofour = photo[3];

            //更新（包括外键sid）
            if (houseService.UpdateAll(house))
            {
                Response.Write(true);
                Response.End();
            }
            else
            {
                Response.Write(true);
                Response.End();
            }

        }

        //单个删除房屋信息
        protected void deletehouse()
        {
            int hid = Int32.Parse(Request["hid"]);
            if (houseService.Delete(hid))
            {
                Response.Write(true);
                Response.End();
            }
            else
            {
                Response.Write(true);
                Response.End();
            }
        }

        //批量删除房屋信息
        protected void deletelist()
        {
            string ids = Request["ids"];
            if (houseService.DeleteList(ids))
            {
                Response.Write(true);
                Response.End();
            }
            else
            {
                Response.Write(true);
                Response.End();
            }
        }

    }
}