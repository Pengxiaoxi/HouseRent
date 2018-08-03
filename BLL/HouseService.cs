using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using myhouse.Model;
using System.Text;
using Util;
using System.Collections;

namespace myhouse.BLL
{
	/// <summary>
	/// HouseService
	/// </summary>
	public partial class HouseService
	{
		private readonly myhouse.DAL.HouseDao dal=new myhouse.DAL.HouseDao();

        //前台每页显示的信息数量
        public int pagecount = 15;

        //后台每页显示的数量
        public int pagesize = 5;

        //审核通过的房屋信息状态
        public int hstatus = 1;
        public string orderby { get; set; }

        public HouseService()
		{}
        #region  BasicMethod

        //房屋列表分页 后台传递不同的条件查询出需要的房屋信息列表
        public List<House> FindHouseByPageWhere(string where, string order, int pagenumber, int pagecount)
        {
            DataSet ds = GetListByPage(where, order, (pagenumber - 1) * pagecount + 1, pagenumber * pagecount);

            List<House> houseList = DataTableToList(ds.Tables[0]);

            return houseList;
        }


        //房屋信息条件分页查询
        public ArrayList FindHosueListOnWhereByPage(int page, string hname, string sid, string tid, string aid, string hmode, string hstatus, string order)
        {
            //条件拼接
            StringBuilder strWhere = new StringBuilder();
            //分页链接条件
            StringBuilder param = new StringBuilder();

            if (order == null || order == "0")
            {
                orderby = "htime desc";
            }
            else if (order == "1")
            {
                orderby = "htime asc";
            }
            else if (order == "2")
            {
                orderby = "hmoney desc";
            }
            else if (order == "3")
            {
                orderby = "hmoney asc";
            }

            //分页列表条件拼接  strWhere
            strWhere.Append("htime >" + 2010);  /*生成出来的方法拼接时如果第一个为空则后面不为空and关键字报错，需要添加一个固定的第一个)*/

            if (hname != null && !"".Equals(hname))
            {
                strWhere.Append("and hname like'%" +hname+ "%'");
            }
            if (sid!= null && !"".Equals(sid))
            {
                strWhere.Append(" and sid= '" + sid + "'");
            }
            if (tid != null && !"".Equals(tid))
            {
                strWhere.Append(" and htype= '" + tid + "'");
            }
            if (aid != null && !"".Equals(aid))
            {
                strWhere.Append(" and harea= '" + aid + "'");
            }
            if (hmode != null && !"".Equals(hmode))
            {
                strWhere.Append(" and hmode= '" + hmode + "'");
            }
            if (hstatus != null && !"".Equals(hstatus))
            {
                strWhere.Append(" and hstatus= '" + hstatus + "'");
            }

            //总记录数
            int recordCount = this.GetRecordCount(strWhere.ToString());
            //防止page大于maxpage
            int maxpage;
            if (recordCount % pagesize == 0)
            {
                maxpage = recordCount / pagesize;
            }
            else
            {
                maxpage = recordCount / pagesize + 1;
            }
            if (page > maxpage)
            {
                page = maxpage;
            }

            //房屋信息
            List<House> houseList = this.FindHouseByPageWhere(strWhere.ToString(), orderby, page, pagesize);


            //分页链接条件拼接 param  注意空格
            if (order != null && !"".Equals(order))
            {
                param.Append("order=" + order);
            }
            if (hname != null && !"".Equals(hname))
            {
                param.Append("&hname=" + hname);
            }
            if (sid != null && !"".Equals(sid))
            {
                param.Append("&sid=" + sid);
            }
            if (tid != null && !"".Equals(tid))
            {
                param.Append("&htype=" + tid);
            }
            if (aid != null && !"".Equals(aid))
            {
                param.Append("&harea=" + aid  );
            }
            if (hmode != null && !"".Equals(hmode))
            {
                param.Append("&hmode=" + hmode);
            }
            if (hstatus != null && !"".Equals(hstatus))
            {
                param.Append("&hstatus=" + hstatus);
            }
            

            //分页链接
            string pageCode = PageUtil.genPagination("/MyAdmin/HouseList.aspx", recordCount, page, pagesize, param.ToString() );

            ArrayList list = new ArrayList();
            //添加到数组中
            list.Add(houseList);
            list.Add(pageCode);

            return list;
        }

        //通过外键sid删除房屋信息
        public bool DeleteBySid(int sid)
        {

            return dal.DeleteBySid(sid);
        }

        // 获得前几行数据
        public List<myhouse.Model.House> GetModelListTop(int Top, string strWhere, string filedOrder)
        {
            DataSet ds = dal.GetList(Top, strWhere, filedOrder);
            return DataTableToList(ds.Tables[0]);
        }


        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int cid,int uid,int sid,int hid)
		{
			return dal.Exists(cid,uid,sid,hid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(myhouse.Model.House model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(myhouse.Model.House model)
		{
			return dal.Update(model);
		}

        //UpdateAll  包含外键sid更新
        public bool UpdateAll(myhouse.Model.House model)
        {
            return dal.UpdateAll(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int hid)
		{
			
			return dal.Delete(hid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int cid,int uid,int sid,int hid)
		{
			
			return dal.Delete(cid,uid,sid,hid);
		}
		/// <summary>
		/// 删除多条数据
		/// </summary>
		public bool DeleteList(string hidlist )
		{
			return dal.DeleteList(hidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public myhouse.Model.House GetModel(int hid)
		{
			
			return dal.GetModel(hid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public myhouse.Model.House GetModelByCache(int hid)
		{
			
			string CacheKey = "HouseModel-" + hid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(hid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (myhouse.Model.House)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<myhouse.Model.House> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<myhouse.Model.House> DataTableToList(DataTable dt)
		{
			List<myhouse.Model.House> modelList = new List<myhouse.Model.House>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				myhouse.Model.House model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 总记录数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}


        


		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

