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
	/// WorkerService
	/// </summary>
	public partial class WorkerService
	{
		private readonly myhouse.DAL.WorkerDao dal=new myhouse.DAL.WorkerDao();
		public WorkerService()
		{}
        #region  BasicMethod

        public int pagesize = 5;   //每页5条数据

        public string orderby;

        int admintype = 8;   //管理员用户类型
        int workertype = 1;  //员工

        //条件分页查询员工信息+排序方式
        public ArrayList FindWorkerByPageOnWhere(int page, string name, string type, string order)
        {
            StringBuilder strWhere = new StringBuilder();
            StringBuilder param = new StringBuilder();
            
            if (order == "0" || order == null)
            {
                order = "0";
                orderby = "wid asc";
            }
            else if (order == "1")
            {
                orderby = "wid desc";
            }

            strWhere.Append("wid >" + 0);
            if (name != null && !"".Equals(name))
            {
                strWhere.Append("and wname='"+name+"'");
            }
            if (type != null && !"".Equals(type))
            {
                //type为8，查询出管理员否则查出其他的不同类型的员工的
                if (type == "8")
                {
                    strWhere.Append("and wtype='" + type + "'");
                }
                else if (type == "6")    //全部员工
                {
                    strWhere.Append("and wtype !='" + admintype + "'");
                }
                else
                {
                    strWhere.Append("and wtype ='" + type + "'");
                }
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

            DataSet ds = this.GetListByPage(strWhere.ToString(), orderby, (page-1) * pagesize +1, page * pagesize);
            List<Worker> workerList = DataTableToList(ds.Tables[0]);

            param.Append("order="+order);
            if (name != null && !"".Equals(name))
            {
                param.Append("&name="+name);
            }
            if (type != null && !"".Equals(type))
            {
                //管理员则只需要传递一个peopletype,当type为员工时则需要将permission的值进行传递判断是选择的哪一个权限
                if (type == "8")
                {
                    param.Append("&peopletype=" + type);
                }
                else if (type == "6")
                {
                    param.Append("&peopletype=" + workertype);
                }
                else
                {
                    param.Append("&peopletype=" + workertype);
                    param.Append("&permission=" + type);
                }
            }
            string pageCode = PageUtil.genPagination("/MyAdmin/WorkerList.aspx", record, page, pagesize, param.ToString());

            ArrayList list = new ArrayList();
            list.Add(workerList);
            list.Add(pageCode);

            return list;
        }

        //添加或修改根据wid>0则更新方法，反之添加
        public bool addorupdate(Worker worker)
        {
            if (worker.wid > 0)
            {
                return this.Update(worker);
            }
            else
            {
                if (this.Add(worker) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
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
		public bool Exists(string wcard,int wid)
		{
			return dal.Exists(wcard,wid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(myhouse.Model.Worker model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(myhouse.Model.Worker model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int wid)
		{
			
			return dal.Delete(wid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string wcard,int wid)
		{
			
			return dal.Delete(wcard,wid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string widlist )
		{
			return dal.DeleteList(widlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public myhouse.Model.Worker GetModel(int wid)
		{
			
			return dal.GetModel(wid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public myhouse.Model.Worker GetModelByCache(int wid)
		{
			
			string CacheKey = "WorkerModel-" + wid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(wid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (myhouse.Model.Worker)objModel;
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
		public List<myhouse.Model.Worker> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<myhouse.Model.Worker> DataTableToList(DataTable dt)
		{
			List<myhouse.Model.Worker> modelList = new List<myhouse.Model.Worker>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				myhouse.Model.Worker model;
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

