using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace myhouse.DAL
{
	/// <summary>
	/// 数据访问类:MenusDao
	/// </summary>
	public partial class MenusDao
	{
		public MenusDao()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("mid", "t_menus"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int mid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_menus");
			strSql.Append(" where mid=@mid");
			SqlParameter[] parameters = {
					new SqlParameter("@mid", SqlDbType.Int,4)
			};
			parameters[0].Value = mid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(myhouse.Model.Menus model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_menus(");
			strSql.Append("mname,murl,mstatus)");
			strSql.Append(" values (");
			strSql.Append("@mname,@murl,@mstatus)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@mname", SqlDbType.Char,20),
					new SqlParameter("@murl", SqlDbType.VarChar,100),
					new SqlParameter("@mstatus", SqlDbType.Int,4)};
			parameters[0].Value = model.mname;
			parameters[1].Value = model.murl;
			parameters[2].Value = model.mstatus;

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
		public bool Update(myhouse.Model.Menus model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_menus set ");
			strSql.Append("mname=@mname,");
			strSql.Append("murl=@murl,");
			strSql.Append("mstatus=@mstatus");
			strSql.Append(" where mid=@mid");
			SqlParameter[] parameters = {
					new SqlParameter("@mname", SqlDbType.Char,20),
					new SqlParameter("@murl", SqlDbType.VarChar,100),
					new SqlParameter("@mstatus", SqlDbType.Int,4),
					new SqlParameter("@mid", SqlDbType.Int,4)};
			parameters[0].Value = model.mname;
			parameters[1].Value = model.murl;
			parameters[2].Value = model.mstatus;
			parameters[3].Value = model.mid;

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
		public bool Delete(int mid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_menus ");
			strSql.Append(" where mid=@mid");
			SqlParameter[] parameters = {
					new SqlParameter("@mid", SqlDbType.Int,4)
			};
			parameters[0].Value = mid;

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
		public bool DeleteList(string midlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_menus ");
			strSql.Append(" where mid in ("+midlist + ")  ");
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
		public myhouse.Model.Menus GetModel(int mid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 mid,mname,murl,mstatus from t_menus ");
			strSql.Append(" where mid=@mid");
			SqlParameter[] parameters = {
					new SqlParameter("@mid", SqlDbType.Int,4)
			};
			parameters[0].Value = mid;

			myhouse.Model.Menus model=new myhouse.Model.Menus();
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
		public myhouse.Model.Menus DataRowToModel(DataRow row)
		{
			myhouse.Model.Menus model=new myhouse.Model.Menus();
			if (row != null)
			{
				if(row["mid"]!=null && row["mid"].ToString()!="")
				{
					model.mid=int.Parse(row["mid"].ToString());
				}
				if(row["mname"]!=null)
				{
					model.mname=row["mname"].ToString();
				}
				if(row["murl"]!=null)
				{
					model.murl=row["murl"].ToString();
				}
				if(row["mstatus"]!=null && row["mstatus"].ToString()!="")
				{
					model.mstatus=int.Parse(row["mstatus"].ToString());
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
			strSql.Append("select mid,mname,murl,mstatus ");
			strSql.Append(" FROM t_menus ");
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
			strSql.Append(" mid,mname,murl,mstatus ");
			strSql.Append(" FROM t_menus ");
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
			strSql.Append("select count(1) FROM t_menus ");
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
				strSql.Append("order by T.mid desc");
			}
			strSql.Append(")AS Row, T.*  from t_menus T ");
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
			parameters[0].Value = "t_menus";
			parameters[1].Value = "mid";
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

