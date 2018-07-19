using System;

namespace TestLibrary.Models
{
    /// <summary>
    /// Register
    /// </summary>
    public class MRegister
    {
        public MRegister() { }

        private int _RegisterID;
        private int _TWYear;
        private string _MemberID;
        private string _MemberType;
        private string _RegisterName;
        private string _TEL;
        private string _Email1;
        private string _Email2;
        private string _ZipCode;
        private string _City;
        private string _Area;
        private string _Address;
        private string _MealType;
        private DateTime _RegisterDate;
        private DateTime _UpdateDate;

        /// <summary>
        /// 報名序號
        /// </summary>
        public int RegisterID
        {
            set { _RegisterID = value; }
            get { return _RegisterID; }
        }

        /// <summary>
        /// 
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
        /// 電話
        /// </summary>
        public string TEL
        {
            set { _TEL = value; }
            get { return _TEL; }
        }

        /// <summary>
        /// 聯絡人Email
        /// </summary>
        public string Email1
        {
            set { _Email1 = value; }
            get { return _Email1; }
        }

        /// <summary>
        /// 聯絡人Email
        /// </summary>
        public string Email2
        {
            set { _Email2 = value; }
            get { return _Email2; }
        }

        /// <summary>
        /// 郵遞區號
        /// </summary>
        public string ZipCode
        {
            set { _ZipCode = value; }
            get { return _ZipCode; }
        }

        /// <summary>
        /// 城市
        /// </summary>
        public string City
        {
            set { _City = value; }
            get { return _City; }
        }

        /// <summary>
        /// 區段
        /// </summary>
        public string Area
        {
            set { _Area = value; }
            get { return _Area; }
        }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            set { _Address = value; }
            get { return _Address; }
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
        /// 報名日期
        /// </summary>
        public DateTime RegisterDate
        {
            set { _RegisterDate = value; }
            get { return _RegisterDate; }
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
