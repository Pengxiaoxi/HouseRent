using System;
namespace myhouse.Model
{
	/// <summary>
	/// Menus:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Menus
	{
		public Menus()
		{}
		#region Model
		private int _mid;
		private string _mname;
		private string _murl;
		private int? _mstatus;
		/// <summary>
		/// 
		/// </summary>
		public int mid
		{
			set{ _mid=value;}
			get{return _mid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mname
		{
			set{ _mname=value;}
			get{return _mname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string murl
		{
			set{ _murl=value;}
			get{return _murl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? mstatus
		{
			set{ _mstatus=value;}
			get{return _mstatus;}
		}
		#endregion Model

	}
}

