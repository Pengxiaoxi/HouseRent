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
	/// UserService
	/// </summary>
	public partial class UserService
	{
		private readonly myhouse.DAL.UserDao dal=new myhouse.DAL.UserDao();

        //每页大小
        public int pagesize = 10;
        public string orderby { get; set; }

        public UserService()
		{}
        #region  BasicMethod

        //后台用户信息列表条件分页查询+分页链接
        public ArrayList FindUserByPageOnWhere(int page, string unickname, string utype, string starttime, string endtime, string order)
        {
            StringBuilder strWhere = new StringBuilder();
            StringBuilder param = new StringBuilder();

            //判断排序方式
            if (order == null || order == "0")
            {
                orderby = "uregtime desc";
            }
            else if(order == "1")
            {
                orderby = "uregtime asc";
            }

            //查询条件拼接
            strWhere.Append("uid >" +0);
            if (unickname != null && !"".Equals(unickname))
            {
                strWhere.Append("and unickname like '%"+ unickname + "%'");
            }
            if (utype != null && !"".Equals(utype))
            {
                strWhere.Append("and utype=" +utype);
            }
            if (starttime != null && !"".Equals(starttime) && endtime != null && !"".Equals(endtime))
            {
                strWhere.Append("and uregtime between'" +starttime+ "'and'"+endtime+"'");
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
            //用户信息列表
            DataSet ds = this.GetListByPage(strWhere.ToString(), orderby, (page - 1)*pagesize +1, page * pagesize);
            List<User> userList = this.DataTableToList(ds.Tables[0]);

            //分页条件拼接
            if (order != null && !"".Equals(order))
            {
                param.Append("order="+order);
            }
            if (unickname != null && !"".Equals(unickname))
            {
                param.Append("&uname=" + unickname);
            }
            if (utype != null && !"".Equals(utype))
            {
                param.Append("&utype=" + utype);
            }
            if (starttime != null && !"".Equals(starttime))
            {
                param.Append("&starttime=" + starttime);
            }
            if (endtime != null && !"".Equals(endtime))
            {
                param.Append("&endtime=" + endtime);
            }

            string pageCode = PageUtil.genPagination("/MyAdmin/UserInfo.aspx", record, page, pagesize, param.ToString());

            ArrayList list = new ArrayList();

            list.Add(userList);  //0下标放用户信息列表
            list.Add(pageCode);  //1下标放分页的链接
            
            return list;
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
		public bool Exists(string ucard,int uid)
		{
			return dal.Exists(ucard,uid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(myhouse.Model.User model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(myhouse.Model.User model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int uid)
		{
			
			return dal.Delete(uid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ucard,int uid)
		{
			
			return dal.Delete(ucard,uid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string uidlist )
		{
			return dal.DeleteList(uidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public myhouse.Model.User GetModel(int uid)
		{
			
			return dal.GetModel(uid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public myhouse.Model.User GetModelByCache(int uid)
		{
			
			string CacheKey = "UserModel-" + uid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(uid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (myhouse.Model.User)objModel;
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
		public List<myhouse.Model.User> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<myhouse.Model.User> DataTableToList(DataTable dt)
		{
			List<myhouse.Model.User> modelList = new List<myhouse.Model.User>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				myhouse.Model.User model;
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

