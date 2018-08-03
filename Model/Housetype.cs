using System;
namespace myhouse.Model
{
	/// <summary>
	/// Housetype:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Housetype
	{
		public Housetype()
		{}
		#region Model
		private int _tid;
		private string _ttype;
		private string _tcontent;
		/// <summary>
		/// 
		/// </summary>
		public int tid
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ttype
		{
			set{ _ttype=value;}
			get{return _ttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tcontent
		{
			set{ _tcontent=value;}
			get{return _tcontent;}
		}
		#endregion Model

	}
}

