using System;
namespace myhouse.Model
{
	/// <summary>
	/// Area:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Area
	{
		public Area()
		{}
		#region Model
		private int _areaid;
		private string _areaname;
		/// <summary>
		/// 
		/// </summary>
		public int areaid
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string areaname
		{
			set{ _areaname=value;}
			get{return _areaname;}
		}
		#endregion Model

	}
}

