using System;

namespace TestLibrary.Models
{
    /// <summary>
    /// OnSiteRegistration
    /// </summary>
    public class MOnSiteRegistration
    {
        public MOnSiteRegistration() { }

        private int _OnSiteRegistrationID;
        private int _TWYear;
        private string _MemberID;
        private string _MemberType;
        private string _RegisterName;
        private string _Company;
        private string _PayType;
        private int _Fee2;
        private int _Fee3;
        private bool _Attend;
        private string _MealType;
        private string _CreateUser;
        private DateTime _CreateDate;
        private string _UpdateUser;
        private DateTime _UpdateDate;
        private int? _FeeID;

        /// <summary>
        /// 年會報到序號
        /// </summary>
        public int OnSiteRegistrationID
        {
            set { _OnSiteRegistrationID = value; }
            get { return _OnSiteRegistrationID; }
        }

        /// <summary>
        /// 民國
        /// </summary>
        public int TWYear
        {
            set { _TWYear = value; }
            get { return _TWYear; }
        }

        /// <summary>
        /// 會籍編號
        /// </summary>
        public string MemberID
        {
            set { _MemberID = value; }
            get { return _MemberID; }
        }

        /// <summary>
        /// 會員類別(G團體、P個人)
        /// </summary>
        public string MemberType
        {
            set { _MemberType = value; }
            get { return _MemberType; }
        }

        /// <summary>
        /// 團體會員報名者姓名
        /// </summary>
        public string RegisterName
        {
            set { _RegisterName = value; }
            get { return _RegisterName; }
        }

        /// <summary>
        /// 非會員服務單位
        /// </summary>
        public string Company
        {
            set { _Company = value; }
            get { return _Company; }
        }

         /// <summary>
        /// 繳費方式(匯款;現場;年會現場;虛擬帳戶;超商條碼;超商代碼)
        /// </summary>
        public string PayType
        {
            set { _PayType = value; }
            get { return _PayType; }
        }

        /// <summary>
        /// 常年會費
        /// </summary>
        public int Fee2
        {
            set { _Fee2 = value; }
            get { return _Fee2; }
        }

        /// <summary>
        /// 年會出席費
        /// </summary>
        public int Fee3
        {
            set { _Fee3 = value; }
            get { return _Fee3; }
        }

        /// <summary>
        /// 年會報到
        /// </summary>
        public bool Attend
        {
            set { _Attend = value; }
            get { return _Attend; }
        }

        /// <summary>
        /// 餐飲類別
        /// </summary>
        public string MealType
        {
            set { _MealType = value; }
            get { return _MealType; }
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

        /// <summary>
        /// 費用序號
        /// </summary>
        public int? FeeID
        {
            set { _FeeID = value; }
            get { return _FeeID; }
        }
    }
}
