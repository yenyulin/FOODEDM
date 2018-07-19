using System;

namespace TestLibrary.Models
{
    /// <summary>
    /// AwardWinner
    /// </summary>
    public class MAwardWinner
    {
        public MAwardWinner() { }

        private int _AwardWinnerID;
        private int _AwardID;
        private int? _AwardTypeID;
        private int _Year;
        private string _Works;
        //private int? _WinnerID;
        private string _WinnerName;
        private Byte[] _Photo;
        private string _Contents;
        //private string _WinnerTitle;
        //private string _Experience;
        //private string _Contribution;
        //private bool? _Draft;
        private string _CreateUser;
        private DateTime _CreateDate;
        private string _LastUpdateUser;
        private DateTime _LastUpdateDate;

        /// <summary>
        /// 得獎序號
        /// </summary>
        public int AwardWinnerID
        {
            set { _AwardWinnerID = value; }
            get { return _AwardWinnerID; }
        }

        /// <summary>
        /// 獎項序號
        /// </summary>
        public int AwardID
        {
            set { _AwardID = value; }
            get { return _AwardID; }
        }

        /// <summary>
        /// 獎項類別序號
        /// </summary>
        public int? AwardTypeID
        {
            set { _AwardTypeID = value; }
            get { return _AwardTypeID; }
        }

        /// <summary>
        /// 年份
        /// </summary>
        public int Year
        {
            set { _Year = value; }
            get { return _Year; }
        }

        /// <summary>
        /// 作品
        /// </summary>
        public string Works
        {
            set { _Works = value; }
            get { return _Works; }
        }

        ///// <summary>
        ///// 獲獎者序號
        ///// </summary>
        //public int? WinnerID
        //{
        //    set { _WinnerID = value; }
        //    get { return _WinnerID; }
        //}

        /// <summary>
        /// 獲獎者姓名
        /// </summary>
        public string WinnerName
        {
            set { _WinnerName = value; }
            get { return _WinnerName; }
        }

        /// <summary>
        /// 照片
        /// </summary>
        public Byte[] Photo
        {
            set { _Photo = value; }
            get { return _Photo; }
        }

        /// <summary>
        /// 內容
        /// </summary>
        public string Contents
        {
            set { _Contents = value; }
            get { return _Contents; }
        }

        ///// <summary>
        ///// 職稱
        ///// </summary>
        //public string WinnerTitle
        //{
        //    set { _WinnerTitle = value; }
        //    get { return _WinnerTitle; }
        //}

        ///// <summary>
        ///// 經歷
        ///// </summary>
        //public string Experience
        //{
        //    set { _Experience = value; }
        //    get { return _Experience; }
        //}

        ///// <summary>
        ///// 特殊貢獻
        ///// </summary>
        //public string Contribution
        //{
        //    set { _Contribution = value; }
        //    get { return _Contribution; }
        //}

        ///// <summary>
        ///// 草稿
        ///// </summary>
        //public bool? Draft
        //{
        //    set { _Draft = value; }
        //    get { return _Draft; }
        //}

        /// <summary>
        /// 資料建立人員
        /// </summary>
        public string CreateUser
        {
            set { _CreateUser = value; }
            get { return _CreateUser; }
        }

        /// <summary>
        /// 資料建立日期
        /// </summary>
        public DateTime CreateDate
        {
            set { _CreateDate = value; }
            get { return _CreateDate; }
        }

        /// <summary>
        /// 最後修改人員
        /// </summary>
        public string LastUpdateUser
        {
            set { _LastUpdateUser = value; }
            get { return _LastUpdateUser; }
        }

        /// <summary>
        /// 最後修改日期
        /// </summary>
        public DateTime LastUpdateDate
        {
            set { _LastUpdateDate = value; }
            get { return _LastUpdateDate; }
        }

    }
}
