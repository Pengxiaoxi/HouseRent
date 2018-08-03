using System;
namespace myhouse.Model
{
	/// <summary>
	/// Announce:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Announce
	{
		public Announce()
		{}
		#region Model
		private int _aid;
		private int _wid;
		private string _apublisher;
		private DateTime? _atime;
		private string _atitle;
		private string _acontent;
		private string _atype;

        public Worker worker { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int aid
		{
			set{ _aid=value;}
			get{return _aid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string apublisher
		{
			set{ _apublisher=value;}
			get{return _apublisher;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? atime
		{
			set{ _atime=value;}
			get{return _atime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string atitle
		{
			set{ _atitle=value;}
			get{return _atitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string acontent
		{
			set{ _acontent=value;}
			get{return _acontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string atype
		{
			set{ _atype=value;}
			get{return _atype;}
		}
		#endregion Model

	}
}

