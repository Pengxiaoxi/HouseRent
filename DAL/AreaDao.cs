using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace myhouse.DAL
{
	/// <summary>
	/// 数据访问类:AreaDao
	/// </summary>
	public partial class AreaDao
	{
		public AreaDao()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("areaid", "t_area"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int areaid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_area");
			strSql.Append(" where areaid=@areaid");
			SqlParameter[] parameters = {
					new SqlParameter("@areaid", SqlDbType.Int,4)
			};
			parameters[0].Value = areaid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(myhouse.Model.Area model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_area(");
			strSql.Append("areaname)");
			strSql.Append(" values (");
			strSql.Append("@areaname)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@areaname", SqlDbType.Char,20)};
			parameters[0].Value = model.areaname;

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
		public bool Update(myhouse.Model.Area model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_area set ");
			strSql.Append("areaname=@areaname");
			strSql.Append(" where areaid=@areaid");
			SqlParameter[] parameters = {
					new SqlParameter("@areaname", SqlDbType.Char,20),
					new SqlParameter("@areaid", SqlDbType.Int,4)};
			parameters[0].Value = model.areaname;
			parameters[1].Value = model.areaid;

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
		public bool Delete(int areaid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_area ");
			strSql.Append(" where areaid=@areaid");
			SqlParameter[] parameters = {
					new SqlParameter("@areaid", SqlDbType.Int,4)
			};
			parameters[0].Value = areaid;

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
		public bool DeleteList(string areaidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_area ");
			strSql.Append(" where areaid in ("+areaidlist + ")  ");
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
		public myhouse.Model.Area GetModel(int areaid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 areaid,areaname from t_area ");
			strSql.Append(" where areaid=@areaid");
			SqlParameter[] parameters = {
					new SqlParameter("@areaid", SqlDbType.Int,4)
			};
			parameters[0].Value = areaid;

			myhouse.Model.Area model=new myhouse.Model.Area();
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
		public myhouse.Model.Area DataRowToModel(DataRow row)
		{
			myhouse.Model.Area model=new myhouse.Model.Area();
			if (row != null)
			{
				if(row["areaid"]!=null && row["areaid"].ToString()!="")
				{
					model.areaid=int.Parse(row["areaid"].ToString());
				}
				if(row["areaname"]!=null)
				{
					model.areaname=row["areaname"].ToString();
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
			strSql.Append("select areaid,areaname ");
			strSql.Append(" FROM t_area ");
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
			strSql.Append(" areaid,areaname ");
			strSql.Append(" FROM t_area ");
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
			strSql.Append("select count(1) FROM t_area ");
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
				strSql.Append("order by T.areaid desc");
			}
			strSql.Append(")AS Row, T.*  from t_area T ");
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
			parameters[0].Value = "t_area";
			parameters[1].Value = "areaid";
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

