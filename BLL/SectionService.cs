using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using myhouse.Model;
namespace myhouse.BLL
{
	/// <summary>
	/// SectionService
	/// </summary>
	public partial class SectionService
	{
		private readonly myhouse.DAL.SectionDao dal=new myhouse.DAL.SectionDao();
		public SectionService()
		{}
        #region  BasicMethod
        //每页大小
        public int pagesize = 10; 

        //分页查询房屋板块
        public List<Section> FindSectionByPage(string strWhere, string order, int pageNumber)
        {
            DataSet ds = this.GetListByPage(strWhere, order, (pageNumber - 1) * pagesize, pageNumber * pagesize);

            List<Section> sectionList = DataTableToList(ds.Tables[0]);

            return sectionList;
        }


        //房屋板块的保存或更新
        public bool saveorupdate(myhouse.Model.Section section)
        {
            if (section.sid > 0)
            {
                return this.Update(section);
            }
            else
            {
                if (this.Add(section) > 0)
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
		public bool Exists(int sid)
		{
			return dal.Exists(sid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(myhouse.Model.Section model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(myhouse.Model.Section model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int sid)
		{
			
			return dal.Delete(sid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string sidlist )
		{
			return dal.DeleteList(sidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public myhouse.Model.Section GetModel(int sid)
		{
			
			return dal.GetModel(sid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public myhouse.Model.Section GetModelByCache(int sid)
		{
			
			string CacheKey = "SectionModel-" + sid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(sid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (myhouse.Model.Section)objModel;
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
		public List<myhouse.Model.Section> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<myhouse.Model.Section> DataTableToList(DataTable dt)
		{
			List<myhouse.Model.Section> modelList = new List<myhouse.Model.Section>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				myhouse.Model.Section model;
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

