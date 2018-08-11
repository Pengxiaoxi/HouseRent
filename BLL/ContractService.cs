using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using myhouse.Model;
using System.Collections;
using System.Text;
using Util;

namespace myhouse.BLL
{
	/// <summary>
	/// ContractService
	/// </summary>
	public partial class ContractService
	{
		private readonly myhouse.DAL.ContractDao dal=new myhouse.DAL.ContractDao();
		public ContractService()
		{}
        #region  BasicMethod

        //收藏的房屋状态 8
        public int collectstatus = 8;

        //前台每页显示的信息数量
        public int pagecount = 15;

        //后台每页显示的数量
        public int pagesize = 5;

        public string orderby { get; set; }

        //房屋列表分页 后台传递不同的条件查询出需要的房屋信息列表
        public List<Contract> FindContractByPageWhere(string where, string order, int pagenumber, int pagecount)
        {
            DataSet ds = GetListByPage(where, order, (pagenumber - 1) * pagecount + 1, pagenumber * pagecount);

            List<Contract> contractList = DataTableToList(ds.Tables[0]);

            return contractList;
        }


        //条件，排序分页查询
        public ArrayList FindReportByPageOnWhere(int page, string hid, string cstatus, string order )
        {
            //条件拼接
            StringBuilder strWhere = new StringBuilder();
            //分页链接条件
            StringBuilder param = new StringBuilder();

            if (order == null || order == "0")
            {
                orderby = "cid desc";
            }
            else if (order == "1")
            {
                orderby = "cid asc";
            }
            else if (order == "2")
            {
                orderby = "hid asc";
            }
            else if (order == "3")
            {
                orderby = "uid asc";
            }

            strWhere.Append("cstatus= "+cstatus);
            if (hid != null && !"".Equals(hid))
            {
                strWhere.Append("and hid= '" + hid + "'");
            }
            int record = this.GetRecordCount(strWhere.ToString());

            int maxpage = 1;
            if (record % pagesize == 0)
            {
                maxpage = record / pagesize;
            }
            else
            {
                maxpage = record / pagesize + 1;
            }
            if (page > maxpage)
            {
                page = maxpage;
            }

            List<Contract> contractList = this.FindContractByPageWhere(strWhere.ToString(), orderby, (page - 1) * pagesize + 1, page * pagesize);

            // 分页链接条件拼接 param 注意空格
            if (order != null && !"".Equals(order))
            {
                param.Append("order=" + order);
            }
            if (hid != null && !"".Equals(hid))
            {
                param.Append("&hid=" + hid);
            }
            if (cstatus != null && !"".Equals(cstatus))
            {
                param.Append("&cstatus=" + cstatus);
            }
            string pageCode = PageUtil.genPagination("/MyAdmin/ReportInfo.aspx",record, page, pagesize, param.ToString());

            ArrayList list = new ArrayList();

            list.Add(contractList);
            list.Add(pageCode);
            return list;
        }


        //通过外键uid删除数据
        public bool DeleteByUid(int uid)
        {
            return dal.DeleteByUid(uid);
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
		public bool Exists(int uid,int hid,int cid)
		{
			return dal.Exists(uid,hid,cid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(myhouse.Model.Contract model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(myhouse.Model.Contract model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int cid)
		{
			
			return dal.Delete(cid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int uid,int hid,int cid)
		{
			
			return dal.Delete(uid,hid,cid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string cidlist )
		{
			return dal.DeleteList(cidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public myhouse.Model.Contract GetModel(int cid)
		{
			
			return dal.GetModel(cid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public myhouse.Model.Contract GetModelByCache(int cid)
		{
			
			string CacheKey = "ContractModel-" + cid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(cid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (myhouse.Model.Contract)objModel;
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
		public List<myhouse.Model.Contract> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<myhouse.Model.Contract> DataTableToList(DataTable dt)
		{
			List<myhouse.Model.Contract> modelList = new List<myhouse.Model.Contract>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				myhouse.Model.Contract model;
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
		/// 分页获取数据列表
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

