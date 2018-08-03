using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace myhouse.DAL
{
	/// <summary>
	/// 数据访问类:AnnounceDao
	/// </summary>
	public partial class AnnounceDao
	{
		public AnnounceDao()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("wid", "t_announce"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int wid,int aid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_announce");
			strSql.Append(" where wid=@wid and aid=@aid ");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@aid", SqlDbType.Int,4)			};
			parameters[0].Value = wid;
			parameters[1].Value = aid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(myhouse.Model.Announce model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_announce(");
			strSql.Append("wid,apublisher,atime,atitle,acontent,atype)");
			strSql.Append(" values (");
			strSql.Append("@wid,@apublisher,@atime,@atitle,@acontent,@atype)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@apublisher", SqlDbType.Char,10),
					new SqlParameter("@atime", SqlDbType.DateTime),
					new SqlParameter("@atitle", SqlDbType.VarChar,50),
					new SqlParameter("@acontent", SqlDbType.VarChar,1000),
					new SqlParameter("@atype", SqlDbType.Char,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.apublisher;
			parameters[2].Value = model.atime;
			parameters[3].Value = model.atitle;
			parameters[4].Value = model.acontent;
			parameters[5].Value = model.atype;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(myhouse.Model.Announce model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_announce set ");
			strSql.Append("apublisher=@apublisher,");
			strSql.Append("atime=@atime,");
			strSql.Append("atitle=@atitle,");
			strSql.Append("acontent=@acontent,");
			strSql.Append("atype=@atype");
			strSql.Append(" where aid=@aid");
			SqlParameter[] parameters = {
					new SqlParameter("@apublisher", SqlDbType.Char,10),
					new SqlParameter("@atime", SqlDbType.DateTime),
					new SqlParameter("@atitle", SqlDbType.VarChar,50),
					new SqlParameter("@acontent", SqlDbType.VarChar,1000),
					new SqlParameter("@atype", SqlDbType.Char,4),
					new SqlParameter("@aid", SqlDbType.Int,4),
					new SqlParameter("@wid", SqlDbType.Int,4)};
			parameters[0].Value = model.apublisher;
			parameters[1].Value = model.atime;
			parameters[2].Value = model.atitle;
			parameters[3].Value = model.acontent;
			parameters[4].Value = model.atype;
			parameters[5].Value = model.aid;
			parameters[6].Value = model.wid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int aid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_announce ");
			strSql.Append(" where aid=@aid");
			SqlParameter[] parameters = {
					new SqlParameter("@aid", SqlDbType.Int,4)
			};
			parameters[0].Value = aid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int wid,int aid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_announce ");
			strSql.Append(" where wid=@wid and aid=@aid ");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@aid", SqlDbType.Int,4)			};
			parameters[0].Value = wid;
			parameters[1].Value = aid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string aidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_announce ");
			strSql.Append(" where aid in ("+aidlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public myhouse.Model.Announce GetModel(int aid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 aid,wid,apublisher,atime,atitle,acontent,atype from t_announce ");
			strSql.Append(" where aid=@aid");
			SqlParameter[] parameters = {
					new SqlParameter("@aid", SqlDbType.Int,4)
			};
			parameters[0].Value = aid;

			myhouse.Model.Announce model=new myhouse.Model.Announce();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public myhouse.Model.Announce DataRowToModel(DataRow row)
		{
			myhouse.Model.Announce model=new myhouse.Model.Announce();
			if (row != null)
			{
				if(row["aid"]!=null && row["aid"].ToString()!="")
				{
					model.aid=int.Parse(row["aid"].ToString());
				}
				if(row["wid"]!=null && row["wid"].ToString()!="")
				{
					model.wid=int.Parse(row["wid"].ToString());
				}
				if(row["apublisher"]!=null)
				{
					model.apublisher=row["apublisher"].ToString();
				}
				if(row["atime"]!=null && row["atime"].ToString()!="")
				{
					model.atime=DateTime.Parse(row["atime"].ToString());
				}
				if(row["atitle"]!=null)
				{
					model.atitle=row["atitle"].ToString();
				}
				if(row["acontent"]!=null)
				{
					model.acontent=row["acontent"].ToString();
				}
				if(row["atype"]!=null)
				{
					model.atype=row["atype"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select aid,wid,apublisher,atime,atitle,acontent,atype ");
			strSql.Append(" FROM t_announce ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" aid,wid,apublisher,atime,atitle,acontent,atype ");
			strSql.Append(" FROM t_announce ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM t_announce ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.aid desc");
			}
			strSql.Append(")AS Row, T.*  from t_announce T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "t_announce";
			parameters[1].Value = "aid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

