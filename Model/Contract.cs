using System;
using System.Collections.Generic;

namespace myhouse.Model
{
	/// <summary>
	/// Contract:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Contract
	{
		public Contract()
		{}
		#region Model
		private int _cid;
		private int _uid;
		private int _hid;
		private string _cname;
		private string _ccontent;
		private string _cphoto;
		private int? _cstatus;

        public List<House> houseList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// 
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
		public int hid
		{
			set{ _hid=value;}
			get{return _hid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cname
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ccontent
		{
			set{ _ccontent=value;}
			get{return _ccontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cphoto
		{
			set{ _cphoto=value;}
			get{return _cphoto;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? cstatus
		{
			set{ _cstatus=value;}
			get{return _cstatus;}
		}
		#endregion Model

	}
}

