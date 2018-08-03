using System;
namespace myhouse.Model
{
	/// <summary>
	/// Worker:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Worker
	{
		public Worker()
		{}
		#region Model
		private int _wid;
		private string _wname;
		private string _wsex;
		private string _wphoto;
		private string _wcard;
		private string _wpassword;
		private string _wtel;
		private string _wemail;
		private string _wadress;
		private string _wtype;
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
		public string wname
		{
			set{ _wname=value;}
			get{return _wname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string wsex
		{
			set{ _wsex=value;}
			get{return _wsex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string wphoto
		{
			set{ _wphoto=value;}
			get{return _wphoto;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string wcard
		{
			set{ _wcard=value;}
			get{return _wcard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string wpassword
		{
			set{ _wpassword=value;}
			get{return _wpassword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string wtel
		{
			set{ _wtel=value;}
			get{return _wtel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string wemail
		{
			set{ _wemail=value;}
			get{return _wemail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string wadress
		{
			set{ _wadress=value;}
			get{return _wadress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string wtype
		{
			set{ _wtype=value;}
			get{return _wtype;}
		}
		#endregion Model

	}
}

