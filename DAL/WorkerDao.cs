using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace myhouse.DAL
{
	/// <summary>
	/// 数据访问类:WorkerDao
	/// </summary>
	public partial class WorkerDao
	{
		public WorkerDao()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("wid", "t_worker"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string wcard,int wid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_worker");
			strSql.Append(" where wcard=@wcard and wid=@wid ");
			SqlParameter[] parameters = {
					new SqlParameter("@wcard", SqlDbType.Char,20),
					new SqlParameter("@wid", SqlDbType.Int,4)			};
			parameters[0].Value = wcard;
			parameters[1].Value = wid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(myhouse.Model.Worker model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_worker(");
			strSql.Append("wname,wsex,wphoto,wcard,wpassword,wtel,wemail,wadress,wtype)");
			strSql.Append(" values (");
			strSql.Append("@wname,@wsex,@wphoto,@wcard,@wpassword,@wtel,@wemail,@wadress,@wtype)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wname", SqlDbType.Char,12),
					new SqlParameter("@wsex", SqlDbType.Char,4),
					new SqlParameter("@wphoto", SqlDbType.VarChar,100),
					new SqlParameter("@wcard", SqlDbType.VarChar,20),
					new SqlParameter("@wpassword", SqlDbType.VarChar,50),
					new SqlParameter("@wtel", SqlDbType.Char,13),
					new SqlParameter("@wemail", SqlDbType.VarChar,30),
					new SqlParameter("@wadress", SqlDbType.VarChar,50),
					new SqlParameter("@wtype", SqlDbType.Char,4)};
			parameters[0].Value = model.wname;
			parameters[1].Value = model.wsex;
			parameters[2].Value = model.wphoto;
			parameters[3].Value = model.wcard;
			parameters[4].Value = model.wpassword;
			parameters[5].Value = model.wtel;
			parameters[6].Value = model.wemail;
			parameters[7].Value = model.wadress;
			parameters[8].Value = model.wtype;

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
		public bool Update(myhouse.Model.Worker model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_worker set ");
			strSql.Append("wname=@wname,");
			strSql.Append("wsex=@wsex,");
			strSql.Append("wphoto=@wphoto,");
			strSql.Append("wpassword=@wpassword,");
			strSql.Append("wtel=@wtel,");
			strSql.Append("wemail=@wemail,");
			strSql.Append("wadress=@wadress,");
			strSql.Append("wtype=@wtype");
			strSql.Append(" where wid=@wid");
			SqlParameter[] parameters = {
					new SqlParameter("@wname", SqlDbType.Char,12),
					new SqlParameter("@wsex", SqlDbType.Char,4),
					new SqlParameter("@wphoto", SqlDbType.VarChar,100),
					new SqlParameter("@wpassword", SqlDbType.VarChar,50),
					new SqlParameter("@wtel", SqlDbType.Char,13),
					new SqlParameter("@wemail", SqlDbType.VarChar,30),
					new SqlParameter("@wadress", SqlDbType.VarChar,50),
					new SqlParameter("@wtype", SqlDbType.Char,4),
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@wcard", SqlDbType.VarChar,20)};
			parameters[0].Value = model.wname;
			parameters[1].Value = model.wsex;
			parameters[2].Value = model.wphoto;
			parameters[3].Value = model.wpassword;
			parameters[4].Value = model.wtel;
			parameters[5].Value = model.wemail;
			parameters[6].Value = model.wadress;
			parameters[7].Value = model.wtype;
			parameters[8].Value = model.wid;
			parameters[9].Value = model.wcard;

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
		public bool Delete(int wid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_worker ");
			strSql.Append(" where wid=@wid");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4)
			};
			parameters[0].Value = wid;

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
		public bool Delete(string wcard,int wid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_worker ");
			strSql.Append(" where wcard=@wcard and wid=@wid ");
			SqlParameter[] parameters = {
					new SqlParameter("@wcard", SqlDbType.Char,20),
					new SqlParameter("@wid", SqlDbType.Int,4)			};
			parameters[0].Value = wcard;
			parameters[1].Value = wid;

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
		public bool DeleteList(string widlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_worker ");
			strSql.Append(" where wid in ("+widlist + ")  ");
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
		public myhouse.Model.Worker GetModel(int wid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 wid,wname,wsex,wphoto,wcard,wpassword,wtel,wemail,wadress,wtype from t_worker ");
			strSql.Append(" where wid=@wid");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4)
			};
			parameters[0].Value = wid;

			myhouse.Model.Worker model=new myhouse.Model.Worker();
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
		public myhouse.Model.Worker DataRowToModel(DataRow row)
		{
			myhouse.Model.Worker model=new myhouse.Model.Worker();
			if (row != null)
			{
				if(row["wid"]!=null && row["wid"].ToString()!="")
				{
					model.wid=int.Parse(row["wid"].ToString());
				}
				if(row["wname"]!=null)
				{
					model.wname=row["wname"].ToString();
				}
				if(row["wsex"]!=null)
				{
					model.wsex=row["wsex"].ToString();
				}
				if(row["wphoto"]!=null)
				{
					model.wphoto=row["wphoto"].ToString();
				}
				if(row["wcard"]!=null)
				{
					model.wcard=row["wcard"].ToString();
				}
				if(row["wpassword"]!=null)
				{
					model.wpassword=row["wpassword"].ToString();
				}
				if(row["wtel"]!=null)
				{
					model.wtel=row["wtel"].ToString();
				}
				if(row["wemail"]!=null)
				{
					model.wemail=row["wemail"].ToString();
				}
				if(row["wadress"]!=null)
				{
					model.wadress=row["wadress"].ToString();
				}
				if(row["wtype"]!=null)
				{
					model.wtype=row["wtype"].ToString();
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
			strSql.Append("select wid,wname,wsex,wphoto,wcard,wpassword,wtel,wemail,wadress,wtype ");
			strSql.Append(" FROM t_worker ");
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
			strSql.Append(" wid,wname,wsex,wphoto,wcard,wpassword,wtel,wemail,wadress,wtype ");
			strSql.Append(" FROM t_worker ");
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
			strSql.Append("select count(1) FROM t_worker ");
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
				strSql.Append("order by T.wid desc");
			}
			strSql.Append(")AS Row, T.*  from t_worker T ");
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
			parameters[0].Value = "t_worker";
			parameters[1].Value = "wid";
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

