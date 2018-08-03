using System;
namespace myhouse.Model
{
	/// <summary>
	/// Manage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Manage
	{
		public Manage()
		{}
		#region Model
		private int _wid;
		private int _sid;
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
		public int sid
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		#endregion Model

	}
}

