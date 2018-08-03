using System;
using System.Collections.Generic;

namespace myhouse.Model
{
	/// <summary>
	/// Section:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Section
	{
		public Section()
		{}
		#region Model
		private int _sid;
		private string _sname;
		private string _sdescription;

        //封装houseList到House下
        public List<House> houseList { get; set; }

        public int housecount { get; set; }

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
		public string sname
		{
			set{ _sname=value;}
			get{return _sname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sdescription
		{
			set{ _sdescription=value;}
			get{return _sdescription;}
		}
		#endregion Model

	}
}

