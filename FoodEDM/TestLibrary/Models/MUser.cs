using System;

namespace TestLibrary.Models
{
    /// <summary>
    /// User
    /// </summary>
    public class MUser
    {
        public MUser() { }

        private string _UserID;
        private string _UserPassword;
        private string _UserName;
        private bool _Actived;
        private string _CreateUser;
        private DateTime _CreateDate;
        private string _UpdateUser;
        private DateTime _UpdateDate;

        /// <summary>
        /// 使用者帳號
        /// </summary>
        public string UserID
        {
            set { _UserID = value; }
            get { return _UserID; }
        }

        /// <summary>
        /// 使用者密碼
        /// </summary>
        public string UserPassword
        {
            set { _UserPassword = value; }
            get { return _UserPassword; }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName
        {
            set { _UserName = value; }
            get { return _UserName; }
        }

        /// <summary>
        /// 啟用
        /// </summary>
        public bool Actived
        {
            set { _Actived = value; }
            get { return _Actived; }
        }

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
        public string UpdateUser
        {
            set { _UpdateUser = value; }
            get { return _UpdateUser; }
        }

        /// <summary>
        /// 最後修改日期
        /// </summary>
        public DateTime UpdateDate
        {
            set { _UpdateDate = value; }
            get { return _UpdateDate; }
        }

    }
}
