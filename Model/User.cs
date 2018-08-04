using System;
namespace myhouse.Model
{
	/// <summary>
	/// User:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class User
	{
		public User()
		{}
		#region Model
		private int _uid;
		private string _unickname;
		private string _uname;
		private string _usex;
		private string _uphoto;
		private string _ucard;
		private string _ucardphoto;
		private string _upassword;
		private string _utel;
		private string _uqq;
		private string _uemail;
		private DateTime? _uregtime;
		private string _ucredit;
		private string _utype;


        //private string _publishnumber;
        //private string _collectnumber;

        //public string publishnumber
        //{
        //    set { _publishnumber=value; }
        //    get { return _publishnumber; }
        //}

        //public string collectnumber
        //{
        //    set { _collectnumber = value; }
        //    get { return _collectnumber; }
        //}

        //发布数与收藏数
        public int publishernumber { get; set; }
        public int collectnumber { get; set; }


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
		public string unickname
		{
			set{ _unickname=value;}
			get{return _unickname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string uname
		{
			set{ _uname=value;}
			get{return _uname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string usex
		{
			set{ _usex=value;}
			get{return _usex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string uphoto
		{
			set{ _uphoto=value;}
			get{return _uphoto;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ucard
		{
			set{ _ucard=value;}
			get{return _ucard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ucardphoto
		{
			set{ _ucardphoto=value;}
			get{return _ucardphoto;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string upassword
		{
			set{ _upassword=value;}
			get{return _upassword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string utel
		{
			set{ _utel=value;}
			get{return _utel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string uqq
		{
			set{ _uqq=value;}
			get{return _uqq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string uemail
		{
			set{ _uemail=value;}
			get{return _uemail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? uregtime
		{
			set{ _uregtime=value;}
			get{return _uregtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ucredit
		{
			set{ _ucredit=value;}
			get{return _ucredit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string utype
		{
			set{ _utype=value;}
			get{return _utype;}
		}
		#endregion Model

	}
}

