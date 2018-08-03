using System;
using System.Collections.Generic;

namespace myhouse.Model
{
	/// <summary>
	/// House:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class House
	{
		public House()
		{}
		#region Model
		private int _hid;
		private int _cid;
		private int _uid;
		private int _sid;
		private string _hname;
		private string _hdescription;
		private string _hmoney;
		private int? _htype;
		private string _hphotoone;
		private string _hphototwo;
		private string _hphotothree;
		private string _hphotofour;
		private string _hfloor;
		private string _hsize;
		private int? _harea;
		private string _hcommunity;
		private string _hadress;
		private DateTime? _htime;
		private int? _hmode;
		private int? _hstatus;

        public Area area { get; set; }
        public User userinfo { get; set; }
        public Contract contract { get; set; }
        public Housetype housetype { get; set; }
        public Section section { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int hid
		{
			set{ _hid=value;}
			get{return _hid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int sid
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hname
		{
			set{ _hname=value;}
			get{return _hname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hdescription
		{
			set{ _hdescription=value;}
			get{return _hdescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hmoney
		{
			set{ _hmoney=value;}
			get{return _hmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? htype
		{
			set{ _htype=value;}
			get{return _htype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hphotoone
		{
			set{ _hphotoone=value;}
			get{return _hphotoone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hphototwo
		{
			set{ _hphototwo=value;}
			get{return _hphototwo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hphotothree
		{
			set{ _hphotothree=value;}
			get{return _hphotothree;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hphotofour
		{
			set{ _hphotofour=value;}
			get{return _hphotofour;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hfloor
		{
			set{ _hfloor=value;}
			get{return _hfloor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hsize
		{
			set{ _hsize=value;}
			get{return _hsize;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? harea
		{
			set{ _harea=value;}
			get{return _harea;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hcommunity
		{
			set{ _hcommunity=value;}
			get{return _hcommunity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hadress
		{
			set{ _hadress=value;}
			get{return _hadress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? htime
		{
			set{ _htime=value;}
			get{return _htime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? hmode
		{
			set{ _hmode=value;}
			get{return _hmode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? hstatus
		{
			set{ _hstatus=value;}
			get{return _hstatus;}
		}
		#endregion Model

	}
}

