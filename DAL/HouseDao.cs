using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace myhouse.DAL
{
	/// <summary>
	/// 数据访问类:HouseDao
	/// </summary>
	public partial class HouseDao
	{
		public HouseDao()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("cid", "t_house"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int cid,int uid,int sid,int hid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_house");
			strSql.Append(" where cid=@cid and uid=@uid and sid=@sid and hid=@hid ");
			SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@sid", SqlDbType.Int,4),
					new SqlParameter("@hid", SqlDbType.Int,4)			};
			parameters[0].Value = cid;
			parameters[1].Value = uid;
			parameters[2].Value = sid;
			parameters[3].Value = hid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(myhouse.Model.House model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_house(");
			strSql.Append("cid,uid,sid,hname,hdescription,hmoney,htype,hphotoone,hphototwo,hphotothree,hphotofour,hfloor,hsize,harea,hcommunity,hadress,htime,hmode,hstatus)");
			strSql.Append(" values (");
			strSql.Append("@cid,@uid,@sid,@hname,@hdescription,@hmoney,@htype,@hphotoone,@hphototwo,@hphotothree,@hphotofour,@hfloor,@hsize,@harea,@hcommunity,@hadress,@htime,@hmode,@hstatus)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@sid", SqlDbType.Int,4),
					new SqlParameter("@hname", SqlDbType.VarChar,30),
					new SqlParameter("@hdescription", SqlDbType.VarChar,200),
					new SqlParameter("@hmoney", SqlDbType.VarChar,10),
					new SqlParameter("@htype", SqlDbType.Int,4),
					new SqlParameter("@hphotoone", SqlDbType.VarChar,200),
					new SqlParameter("@hphototwo", SqlDbType.VarChar,200),
					new SqlParameter("@hphotothree", SqlDbType.VarChar,200),
					new SqlParameter("@hphotofour", SqlDbType.VarChar,200),
					new SqlParameter("@hfloor", SqlDbType.Char,4),
					new SqlParameter("@hsize", SqlDbType.Char,4),
					new SqlParameter("@harea", SqlDbType.Int,4),
					new SqlParameter("@hcommunity", SqlDbType.VarChar,100),
					new SqlParameter("@hadress", SqlDbType.VarChar,200),
					new SqlParameter("@htime", SqlDbType.DateTime),
					new SqlParameter("@hmode", SqlDbType.Int,4),
					new SqlParameter("@hstatus", SqlDbType.Int,4)};
			parameters[0].Value = model.cid;
			parameters[1].Value = model.uid;
			parameters[2].Value = model.sid;
			parameters[3].Value = model.hname;
			parameters[4].Value = model.hdescription;
			parameters[5].Value = model.hmoney;
			parameters[6].Value = model.htype;
			parameters[7].Value = model.hphotoone;
			parameters[8].Value = model.hphototwo;
			parameters[9].Value = model.hphotothree;
			parameters[10].Value = model.hphotofour;
			parameters[11].Value = model.hfloor;
			parameters[12].Value = model.hsize;
			parameters[13].Value = model.harea;
			parameters[14].Value = model.hcommunity;
			parameters[15].Value = model.hadress;
			parameters[16].Value = model.htime;
			parameters[17].Value = model.hmode;
			parameters[18].Value = model.hstatus;

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
		public bool Update(myhouse.Model.House model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_house set ");
			strSql.Append("hname=@hname,");
			strSql.Append("hdescription=@hdescription,");
			strSql.Append("hmoney=@hmoney,");
			strSql.Append("htype=@htype,");
			strSql.Append("hphotoone=@hphotoone,");
			strSql.Append("hphototwo=@hphototwo,");
			strSql.Append("hphotothree=@hphotothree,");
			strSql.Append("hphotofour=@hphotofour,");
			strSql.Append("hfloor=@hfloor,");
			strSql.Append("hsize=@hsize,");
			strSql.Append("harea=@harea,");
			strSql.Append("hcommunity=@hcommunity,");
			strSql.Append("hadress=@hadress,");
			strSql.Append("htime=@htime,");
			strSql.Append("hmode=@hmode,");
			strSql.Append("hstatus=@hstatus");
			strSql.Append(" where hid=@hid");
			SqlParameter[] parameters = {
					new SqlParameter("@hname", SqlDbType.VarChar,30),
					new SqlParameter("@hdescription", SqlDbType.VarChar,200),
					new SqlParameter("@hmoney", SqlDbType.VarChar,10),
					new SqlParameter("@htype", SqlDbType.Int,4),
					new SqlParameter("@hphotoone", SqlDbType.VarChar,200),
					new SqlParameter("@hphototwo", SqlDbType.VarChar,200),
					new SqlParameter("@hphotothree", SqlDbType.VarChar,200),
					new SqlParameter("@hphotofour", SqlDbType.VarChar,200),
					new SqlParameter("@hfloor", SqlDbType.Char,4),
					new SqlParameter("@hsize", SqlDbType.Char,4),
					new SqlParameter("@harea", SqlDbType.Int,4),
					new SqlParameter("@hcommunity", SqlDbType.VarChar,100),
					new SqlParameter("@hadress", SqlDbType.VarChar,200),
					new SqlParameter("@htime", SqlDbType.DateTime),
					new SqlParameter("@hmode", SqlDbType.Int,4),
					new SqlParameter("@hstatus", SqlDbType.Int,4),
					new SqlParameter("@hid", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@sid", SqlDbType.Int,4)};
			parameters[0].Value = model.hname;
			parameters[1].Value = model.hdescription;
			parameters[2].Value = model.hmoney;
			parameters[3].Value = model.htype;
			parameters[4].Value = model.hphotoone;
			parameters[5].Value = model.hphototwo;
			parameters[6].Value = model.hphotothree;
			parameters[7].Value = model.hphotofour;
			parameters[8].Value = model.hfloor;
			parameters[9].Value = model.hsize;
			parameters[10].Value = model.harea;
			parameters[11].Value = model.hcommunity;
			parameters[12].Value = model.hadress;
			parameters[13].Value = model.htime;
			parameters[14].Value = model.hmode;
			parameters[15].Value = model.hstatus;
			parameters[16].Value = model.hid;
			parameters[17].Value = model.cid;
			parameters[18].Value = model.uid;
			parameters[19].Value = model.sid;

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

        //UpdateAll 包含外键更新
        public bool UpdateAll(myhouse.Model.House model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_house set ");
            strSql.Append("hname=@hname,");
            strSql.Append("hdescription=@hdescription,");
            strSql.Append("hmoney=@hmoney,");
            strSql.Append("htype=@htype,");
            strSql.Append("hphotoone=@hphotoone,");
            strSql.Append("hphototwo=@hphototwo,");
            strSql.Append("hphotothree=@hphotothree,");
            strSql.Append("hphotofour=@hphotofour,");
            strSql.Append("hfloor=@hfloor,");
            strSql.Append("hsize=@hsize,");
            strSql.Append("harea=@harea,");
            strSql.Append("hcommunity=@hcommunity,");
            strSql.Append("hadress=@hadress,");
            strSql.Append("htime=@htime,");
            strSql.Append("hmode=@hmode,");
            strSql.Append("hstatus=@hstatus,");
            strSql.Append("sid=@sid");           /*外键sid更新*/
            strSql.Append(" where hid=@hid");
            SqlParameter[] parameters = {
                    new SqlParameter("@hname", SqlDbType.VarChar,30),
                    new SqlParameter("@hdescription", SqlDbType.VarChar,200),
                    new SqlParameter("@hmoney", SqlDbType.VarChar,10),
                    new SqlParameter("@htype", SqlDbType.Int,4),
                    new SqlParameter("@hphotoone", SqlDbType.VarChar,200),
                    new SqlParameter("@hphototwo", SqlDbType.VarChar,200),
                    new SqlParameter("@hphotothree", SqlDbType.VarChar,200),
                    new SqlParameter("@hphotofour", SqlDbType.VarChar,200),
                    new SqlParameter("@hfloor", SqlDbType.Char,4),
                    new SqlParameter("@hsize", SqlDbType.Char,4),
                    new SqlParameter("@harea", SqlDbType.Int,4),
                    new SqlParameter("@hcommunity", SqlDbType.VarChar,100),
                    new SqlParameter("@hadress", SqlDbType.VarChar,200),
                    new SqlParameter("@htime", SqlDbType.DateTime),
                    new SqlParameter("@hmode", SqlDbType.Int,4),
                    new SqlParameter("@hstatus", SqlDbType.Int,4),
                    new SqlParameter("@hid", SqlDbType.Int,4),
                    new SqlParameter("@cid", SqlDbType.Int,4),
                    new SqlParameter("@uid", SqlDbType.Int,4),
                    new SqlParameter("@sid", SqlDbType.Int,4)};
            parameters[0].Value = model.hname;
            parameters[1].Value = model.hdescription;
            parameters[2].Value = model.hmoney;
            parameters[3].Value = model.htype;
            parameters[4].Value = model.hphotoone;
            parameters[5].Value = model.hphototwo;
            parameters[6].Value = model.hphotothree;
            parameters[7].Value = model.hphotofour;
            parameters[8].Value = model.hfloor;
            parameters[9].Value = model.hsize;
            parameters[10].Value = model.harea;
            parameters[11].Value = model.hcommunity;
            parameters[12].Value = model.hadress;
            parameters[13].Value = model.htime;
            parameters[14].Value = model.hmode;
            parameters[15].Value = model.hstatus;
            parameters[16].Value = model.hid;
            parameters[17].Value = model.cid;
            parameters[18].Value = model.uid;
            parameters[19].Value = model.sid;

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
        public bool Delete(int hid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_house ");
			strSql.Append(" where hid=@hid");
			SqlParameter[] parameters = {
					new SqlParameter("@hid", SqlDbType.Int,4)
			};
			parameters[0].Value = hid;

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

        // 通过外键sid删除数据     
        public bool DeleteBySid(int sid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_house ");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
                    new SqlParameter("@sid", SqlDbType.Int,4)
            };
            parameters[0].Value = sid;

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

        // 通过外键uid删除数据(删除该用户发布的所有房屋信息)
        public bool DeleteByUid(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_house ");
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
        public bool Delete(int cid,int uid,int sid,int hid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_house ");
			strSql.Append(" where cid=@cid and uid=@uid and sid=@sid and hid=@hid ");
			SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@sid", SqlDbType.Int,4),
					new SqlParameter("@hid", SqlDbType.Int,4)			};
			parameters[0].Value = cid;
			parameters[1].Value = uid;
			parameters[2].Value = sid;
			parameters[3].Value = hid;

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
		public bool DeleteList(string hidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_house ");
			strSql.Append(" where hid in ("+hidlist + ")  ");
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
		public myhouse.Model.House GetModel(int hid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 hid,cid,uid,sid,hname,hdescription,hmoney,htype,hphotoone,hphototwo,hphotothree,hphotofour,hfloor,hsize,harea,hcommunity,hadress,htime,hmode,hstatus from t_house ");
			strSql.Append(" where hid=@hid");
			SqlParameter[] parameters = {
					new SqlParameter("@hid", SqlDbType.Int,4)
			};
			parameters[0].Value = hid;

			myhouse.Model.House model=new myhouse.Model.House();
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
		public myhouse.Model.House DataRowToModel(DataRow row)
		{
			myhouse.Model.House model=new myhouse.Model.House();
			if (row != null)
			{
				if(row["hid"]!=null && row["hid"].ToString()!="")
				{
					model.hid=int.Parse(row["hid"].ToString());
				}
				if(row["cid"]!=null && row["cid"].ToString()!="")
				{
					model.cid=int.Parse(row["cid"].ToString());
				}
				if(row["uid"]!=null && row["uid"].ToString()!="")
				{
					model.uid=int.Parse(row["uid"].ToString());
				}
				if(row["sid"]!=null && row["sid"].ToString()!="")
				{
					model.sid=int.Parse(row["sid"].ToString());
				}
				if(row["hname"]!=null)
				{
					model.hname=row["hname"].ToString();
				}
				if(row["hdescription"]!=null)
				{
					model.hdescription=row["hdescription"].ToString();
				}
				if(row["hmoney"]!=null)
				{
					model.hmoney=row["hmoney"].ToString();
				}
				if(row["htype"]!=null && row["htype"].ToString()!="")
				{
					model.htype=int.Parse(row["htype"].ToString());
				}
				if(row["hphotoone"]!=null)
				{
					model.hphotoone=row["hphotoone"].ToString();
				}
				if(row["hphototwo"]!=null)
				{
					model.hphototwo=row["hphototwo"].ToString();
				}
				if(row["hphotothree"]!=null)
				{
					model.hphotothree=row["hphotothree"].ToString();
				}
				if(row["hphotofour"]!=null)
				{
					model.hphotofour=row["hphotofour"].ToString();
				}
				if(row["hfloor"]!=null)
				{
					model.hfloor=row["hfloor"].ToString();
				}
				if(row["hsize"]!=null)
				{
					model.hsize=row["hsize"].ToString();
				}
				if(row["harea"]!=null && row["harea"].ToString()!="")
				{
					model.harea=int.Parse(row["harea"].ToString());
				}
				if(row["hcommunity"]!=null)
				{
					model.hcommunity=row["hcommunity"].ToString();
				}
				if(row["hadress"]!=null)
				{
					model.hadress=row["hadress"].ToString();
				}
				if(row["htime"]!=null && row["htime"].ToString()!="")
				{
					model.htime=DateTime.Parse(row["htime"].ToString());
				}
				if(row["hmode"]!=null && row["hmode"].ToString()!="")
				{
					model.hmode=int.Parse(row["hmode"].ToString());
				}
				if(row["hstatus"]!=null && row["hstatus"].ToString()!="")
				{
					model.hstatus=int.Parse(row["hstatus"].ToString());
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
			strSql.Append("select hid,cid,uid,sid,hname,hdescription,hmoney,htype,hphotoone,hphototwo,hphotothree,hphotofour,hfloor,hsize,harea,hcommunity,hadress,htime,hmode,hstatus ");
			strSql.Append(" FROM t_house ");
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
			strSql.Append(" hid,cid,uid,sid,hname,hdescription,hmoney,htype,hphotoone,hphototwo,hphotothree,hphotofour,hfloor,hsize,harea,hcommunity,hadress,htime,hmode,hstatus ");
			strSql.Append(" FROM t_house ");
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
			strSql.Append("select count(1) FROM t_house ");
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
				strSql.Append("order by T.hid desc");
			}
			strSql.Append(")AS Row, T.*  from t_house T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
                strSql.Append(" WHERE " + strWhere);
                //strSql.Append(strWhere);
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
			parameters[0].Value = "t_house";
			parameters[1].Value = "hid";
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

