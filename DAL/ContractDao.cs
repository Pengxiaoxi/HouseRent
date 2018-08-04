using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace myhouse.DAL
{
	/// <summary>
	/// 数据访问类:ContractDao
	/// </summary>
	public partial class ContractDao
	{
		public ContractDao()
		{}
        #region  BasicMethod


        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("uid", "t_contract"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int uid,int hid,int cid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_contract");
			strSql.Append(" where uid=@uid and hid=@hid and cid=@cid ");
			SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@hid", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4)			};
			parameters[0].Value = uid;
			parameters[1].Value = hid;
			parameters[2].Value = cid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(myhouse.Model.Contract model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_contract(");
			strSql.Append("uid,hid,cname,ccontent,cphoto,cstatus)");
			strSql.Append(" values (");
			strSql.Append("@uid,@hid,@cname,@ccontent,@cphoto,@cstatus)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@hid", SqlDbType.Int,4),
					new SqlParameter("@cname", SqlDbType.VarChar,30),
					new SqlParameter("@ccontent", SqlDbType.VarChar,2000),
					new SqlParameter("@cphoto", SqlDbType.VarChar,50),
					new SqlParameter("@cstatus", SqlDbType.Int,4)};
			parameters[0].Value = model.uid;
			parameters[1].Value = model.hid;
			parameters[2].Value = model.cname;
			parameters[3].Value = model.ccontent;
			parameters[4].Value = model.cphoto;
			parameters[5].Value = model.cstatus;

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
		public bool Update(myhouse.Model.Contract model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_contract set ");
			strSql.Append("cname=@cname,");
			strSql.Append("ccontent=@ccontent,");
			strSql.Append("cphoto=@cphoto,");
			strSql.Append("cstatus=@cstatus");
			strSql.Append(" where cid=@cid");
			SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.VarChar,30),
					new SqlParameter("@ccontent", SqlDbType.VarChar,2000),
					new SqlParameter("@cphoto", SqlDbType.VarChar,50),
					new SqlParameter("@cstatus", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@hid", SqlDbType.Int,4)};
			parameters[0].Value = model.cname;
			parameters[1].Value = model.ccontent;
			parameters[2].Value = model.cphoto;
			parameters[3].Value = model.cstatus;
			parameters[4].Value = model.cid;
			parameters[5].Value = model.uid;
			parameters[6].Value = model.hid;

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
		public bool Delete(int cid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_contract ");
			strSql.Append(" where cid=@cid");
			SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4)
			};
			parameters[0].Value = cid;

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

        //通过外键uid删除数据
        public bool DeleteByUid(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_contract ");
            strSql.Append(" where uid=@uid");
            SqlParameter[] parameters = {
                    new SqlParameter("@uid", SqlDbType.Int,4)
            };
            parameters[0].Value = uid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int uid,int hid,int cid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_contract ");
			strSql.Append(" where uid=@uid and hid=@hid and cid=@cid ");
			SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@hid", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4)			};
			parameters[0].Value = uid;
			parameters[1].Value = hid;
			parameters[2].Value = cid;

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
		public bool DeleteList(string cidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_contract ");
			strSql.Append(" where cid in ("+cidlist + ")  ");
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
		public myhouse.Model.Contract GetModel(int cid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 cid,uid,hid,cname,ccontent,cphoto,cstatus from t_contract ");
			strSql.Append(" where cid=@cid");
			SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4)
			};
			parameters[0].Value = cid;

			myhouse.Model.Contract model=new myhouse.Model.Contract();
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
		public myhouse.Model.Contract DataRowToModel(DataRow row)
		{
			myhouse.Model.Contract model=new myhouse.Model.Contract();
			if (row != null)
			{
				if(row["cid"]!=null && row["cid"].ToString()!="")
				{
					model.cid=int.Parse(row["cid"].ToString());
				}
				if(row["uid"]!=null && row["uid"].ToString()!="")
				{
					model.uid=int.Parse(row["uid"].ToString());
				}
				if(row["hid"]!=null && row["hid"].ToString()!="")
				{
					model.hid=int.Parse(row["hid"].ToString());
				}
				if(row["cname"]!=null)
				{
					model.cname=row["cname"].ToString();
				}
				if(row["ccontent"]!=null)
				{
					model.ccontent=row["ccontent"].ToString();
				}
				if(row["cphoto"]!=null)
				{
					model.cphoto=row["cphoto"].ToString();
				}
				if(row["cstatus"]!=null && row["cstatus"].ToString()!="")
				{
					model.cstatus=int.Parse(row["cstatus"].ToString());
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
			strSql.Append("select cid,uid,hid,cname,ccontent,cphoto,cstatus ");
			strSql.Append(" FROM t_contract ");
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
			strSql.Append(" cid,uid,hid,cname,ccontent,cphoto,cstatus ");
			strSql.Append(" FROM t_contract ");
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
			strSql.Append("select count(1) FROM t_contract ");
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
				strSql.Append("order by T.cid desc");
			}
			strSql.Append(")AS Row, T.*  from t_contract T ");
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
			parameters[0].Value = "t_contract";
			parameters[1].Value = "cid";
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

