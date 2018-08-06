using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace myhouse.DAL
{
	/// <summary>
	/// 数据访问类:UserDao
	/// </summary>
	public partial class UserDao
	{
		public UserDao()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("uid", "t_user"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ucard,int uid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_user");
			strSql.Append(" where ucard=@ucard and uid=@uid ");
			SqlParameter[] parameters = {
					new SqlParameter("@ucard", SqlDbType.Char,18),
					new SqlParameter("@uid", SqlDbType.Int,4)			};
			parameters[0].Value = ucard;
			parameters[1].Value = uid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(myhouse.Model.User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_user(");
			strSql.Append("unickname,uname,usex,uphoto,ucard,ucardphoto,upassword,utel,uqq,uemail,uregtime,ucredit,utype)");
			strSql.Append(" values (");
			strSql.Append("@unickname,@uname,@usex,@uphoto,@ucard,@ucardphoto,@upassword,@utel,@uqq,@uemail,@uregtime,@ucredit,@utype)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@unickname", SqlDbType.VarChar,20),
					new SqlParameter("@uname", SqlDbType.Char,16),
					new SqlParameter("@usex", SqlDbType.Char,2),
					new SqlParameter("@uphoto", SqlDbType.VarChar,100),
					new SqlParameter("@ucard", SqlDbType.Char,18),
					new SqlParameter("@ucardphoto", SqlDbType.VarChar,50),
					new SqlParameter("@upassword", SqlDbType.VarChar,50),
					new SqlParameter("@utel", SqlDbType.Char,13),
					new SqlParameter("@uqq", SqlDbType.Char,15),
					new SqlParameter("@uemail", SqlDbType.VarChar,30),
					new SqlParameter("@uregtime", SqlDbType.DateTime),
					new SqlParameter("@ucredit", SqlDbType.Char,8),
					new SqlParameter("@utype", SqlDbType.Char,4)};
			parameters[0].Value = model.unickname;
			parameters[1].Value = model.uname;
			parameters[2].Value = model.usex;
			parameters[3].Value = model.uphoto;
			parameters[4].Value = model.ucard;
			parameters[5].Value = model.ucardphoto;
			parameters[6].Value = model.upassword;
			parameters[7].Value = model.utel;
			parameters[8].Value = model.uqq;
			parameters[9].Value = model.uemail;
			parameters[10].Value = model.uregtime;
			parameters[11].Value = model.ucredit;
			parameters[12].Value = model.utype;

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
		public bool Update(myhouse.Model.User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_user set ");
			strSql.Append("unickname=@unickname,");
			strSql.Append("uname=@uname,");
			strSql.Append("usex=@usex,");
			strSql.Append("uphoto=@uphoto,");
            strSql.Append("ucard=@ucard,");
            strSql.Append("ucardphoto=@ucardphoto,");
			strSql.Append("upassword=@upassword,");
			strSql.Append("utel=@utel,");
			strSql.Append("uqq=@uqq,");
			strSql.Append("uemail=@uemail,");
			strSql.Append("uregtime=@uregtime,");
			strSql.Append("ucredit=@ucredit,");
			strSql.Append("utype=@utype");
			strSql.Append(" where uid=@uid");
			SqlParameter[] parameters = {
					new SqlParameter("@unickname", SqlDbType.VarChar,20),
					new SqlParameter("@uname", SqlDbType.Char,16),
					new SqlParameter("@usex", SqlDbType.Char,2),
					new SqlParameter("@uphoto", SqlDbType.VarChar,100),
					new SqlParameter("@ucardphoto", SqlDbType.VarChar,50),
					new SqlParameter("@upassword", SqlDbType.VarChar,50),
					new SqlParameter("@utel", SqlDbType.Char,13),
					new SqlParameter("@uqq", SqlDbType.Char,15),
					new SqlParameter("@uemail", SqlDbType.VarChar,30),
					new SqlParameter("@uregtime", SqlDbType.DateTime),
					new SqlParameter("@ucredit", SqlDbType.Char,8),
					new SqlParameter("@utype", SqlDbType.Char,4),
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@ucard", SqlDbType.Char,18)};
			parameters[0].Value = model.unickname;
			parameters[1].Value = model.uname;
			parameters[2].Value = model.usex;
			parameters[3].Value = model.uphoto;
			parameters[4].Value = model.ucardphoto;
			parameters[5].Value = model.upassword;
			parameters[6].Value = model.utel;
			parameters[7].Value = model.uqq;
			parameters[8].Value = model.uemail;
			parameters[9].Value = model.uregtime;
			parameters[10].Value = model.ucredit;
			parameters[11].Value = model.utype;
			parameters[12].Value = model.uid;
			parameters[13].Value = model.ucard;

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
		public bool Delete(int uid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_user ");
			strSql.Append(" where uid=@uid");
			SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.Int,4)
			};
			parameters[0].Value = uid;

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
		public bool Delete(string ucard,int uid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_user ");
			strSql.Append(" where ucard=@ucard and uid=@uid ");
			SqlParameter[] parameters = {
					new SqlParameter("@ucard", SqlDbType.Char,18),
					new SqlParameter("@uid", SqlDbType.Int,4)			};
			parameters[0].Value = ucard;
			parameters[1].Value = uid;

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
		public bool DeleteList(string uidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_user ");
			strSql.Append(" where uid in ("+uidlist + ")  ");
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
		public myhouse.Model.User GetModel(int uid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 uid,unickname,uname,usex,uphoto,ucard,ucardphoto,upassword,utel,uqq,uemail,uregtime,ucredit,utype from t_user ");
			strSql.Append(" where uid=@uid");
			SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.Int,4)
			};
			parameters[0].Value = uid;

			myhouse.Model.User model=new myhouse.Model.User();
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
		public myhouse.Model.User DataRowToModel(DataRow row)
		{
			myhouse.Model.User model=new myhouse.Model.User();
			if (row != null)
			{
				if(row["uid"]!=null && row["uid"].ToString()!="")
				{
					model.uid=int.Parse(row["uid"].ToString());
				}
				if(row["unickname"]!=null)
				{
					model.unickname=row["unickname"].ToString();
				}
				if(row["uname"]!=null)
				{
					model.uname=row["uname"].ToString();
				}
				if(row["usex"]!=null)
				{
					model.usex=row["usex"].ToString();
				}
				if(row["uphoto"]!=null)
				{
					model.uphoto=row["uphoto"].ToString();
				}
				if(row["ucard"]!=null)
				{
					model.ucard=row["ucard"].ToString();
				}
				if(row["ucardphoto"]!=null)
				{
					model.ucardphoto=row["ucardphoto"].ToString();
				}
				if(row["upassword"]!=null)
				{
					model.upassword=row["upassword"].ToString();
				}
				if(row["utel"]!=null)
				{
					model.utel=row["utel"].ToString();
				}
				if(row["uqq"]!=null)
				{
					model.uqq=row["uqq"].ToString();
				}
				if(row["uemail"]!=null)
				{
					model.uemail=row["uemail"].ToString();
				}
				if(row["uregtime"]!=null && row["uregtime"].ToString()!="")
				{
					model.uregtime=DateTime.Parse(row["uregtime"].ToString());
				}
				if(row["ucredit"]!=null)
				{
					model.ucredit=row["ucredit"].ToString();
				}
				if(row["utype"]!=null)
				{
					model.utype=row["utype"].ToString();
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
			strSql.Append("select uid,unickname,uname,usex,uphoto,ucard,ucardphoto,upassword,utel,uqq,uemail,uregtime,ucredit,utype ");
			strSql.Append(" FROM t_user ");
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
			strSql.Append(" uid,unickname,uname,usex,uphoto,ucard,ucardphoto,upassword,utel,uqq,uemail,uregtime,ucredit,utype ");
			strSql.Append(" FROM t_user ");
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
			strSql.Append("select count(1) FROM t_user ");
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
				strSql.Append("order by T.uid desc");
			}
			strSql.Append(")AS Row, T.*  from t_user T ");
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
			parameters[0].Value = "t_user";
			parameters[1].Value = "uid";
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

