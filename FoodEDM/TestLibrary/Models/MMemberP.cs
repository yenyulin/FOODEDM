using System;

namespace TestLibrary.Models
{
    /// <summary>
    /// MemberP
    /// </summary>
    public class MMemberP
    {
        public MMemberP() { }

        private string _MemberPID;
        private string _MemberPassword;
        private string _NameC;
        private string _NameE;
        private string _Email;
        private string _PID;
        private DateTime? _Birthday;
        private DateTime _RegisterDate;
        private string _Sex;
        private string _Native;
        private string _MemberClass;
        private string _SchoolConsent;
        private string _StudentIDCard;
        private string _StudentIDCardFileType;
        private string _School;
        private string _CollegeDepartment;
        private string _Education;
        private string _Job;
        private string _JobTitle;
        private bool _Student;
        private string _Mobile;
        private string _TEL;
        private string _FAX;
        private string _ZipCodeH;
        private string _CityH;
        private string _AreaH;
        private string _AddressH;
        private string _ZipCode;
        private string _City;
        private string _Area;
        private string _Address;
        private string _Memo;
        private string _Status;
        private bool _EDM;
        private string _CreateUser;
        private DateTime _CreateDate;
        private string _UpdateUser;
        private DateTime _UpdateDate;

        /// <summary>
        /// 會籍編號
        /// </summary>
        public string MemberPID
        {
            set { _MemberPID = value; }
            get { return _MemberPID; }
        }

        /// <summary>
        /// 密碼
        /// </summary>
        public string MemberPassword
        {
            set { _MemberPassword = value; }
            get { return _MemberPassword; }
        }

        /// <summary>
        /// 中文姓名
        /// </summary>
        public string NameC
        {
            set { _NameC = value; }
            get { return _NameC; }
        }

        /// <summary>
        /// 英文姓名
        /// </summary>
        public string NameE
        {
            set { _NameE = value; }
            get { return _NameE; }
        }

        /// <summary>
        /// Email
        /// </summary>
        public string Email
        {
            set { _Email = value; }
            get { return _Email; }
        }

        /// <summary>
        /// 身份證號
        /// </summary>
        public string PID
        {
            set { _PID = value; }
            get { return _PID; }
        }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday
        {
            set { _Birthday = value; }
            get { return _Birthday; }
        }

        /// <summary>
        /// 入會日期
        /// </summary>
        public DateTime RegisterDate
        {
            set { _RegisterDate = value; }
            get { return _RegisterDate; }
        }

        /// <summary>
        /// 性別
        /// </summary>
        public string Sex
        {
            set { _Sex = value; }
            get { return _Sex; }
        }

        /// <summary>
        /// 籍貫
        /// </summary>
        public string Native
        {
            set { _Native = value; }
            get { return _Native; }
        }

        /// <summary>
        /// 會員類別(學生、普通、永久)
        /// </summary>
        public string MemberClass
        {
            set { _MemberClass = value; }
            get { return _MemberClass; }
        }

        /// <summary>
        /// 學校同意書
        /// </summary>
        public string SchoolConsent
        {
            set { _SchoolConsent = value; }
            get { return _SchoolConsent; }
        }

        /// <summary>
        /// 學生證正反面影印本
        /// </summary>
        public string StudentIDCard
        {
            set { _StudentIDCard = value; }
            get { return _StudentIDCard; }
        }

        /// <summary>
        /// 學生證正反面影印本 檔案類型
        /// </summary>
        public string StudentIDCardFileType
        {
            set { _StudentIDCardFileType = value; }
            get { return _StudentIDCardFileType; }
        }

        /// <summary>
        /// 學校
        /// </summary>
        public string School
        {
            set { _School = value; }
            get { return _School; }
        }

        /// <summary>
        /// 科系
        /// </summary>
        public string CollegeDepartment
        {
            set { _CollegeDepartment = value; }
            get { return _CollegeDepartment; }
        }

        /// <summary>
        /// 學歷(高中、專科、學士、碩士、博士)
        /// </summary>
        public string Education
        {
            set { _Education = value; }
            get { return _Education; }
        }

        /// <summary>
        /// 服務單位
        /// </summary>
        public string Job
        {
            set { _Job = value; }
            get { return _Job; }
        }

        /// <summary>
        /// 職稱
        /// </summary>
        public string JobTitle
        {
            set { _JobTitle = value; }
            get { return _JobTitle; }
        }

        /// <summary>
        /// 學生身份
        /// </summary>
        public bool Student
        {
            set { _Student = value; }
            get { return _Student; }
        }

        /// <summary>
        /// 手機
        /// </summary>
        public string Mobile
        {
            set { _Mobile = value; }
            get { return _Mobile; }
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
        /// 傳真
        /// </summary>
        public string FAX
        {
            set { _FAX = value; }
            get { return _FAX; }
        }

        /// <summary>
        /// 郵遞區號-永久
        /// </summary>
        public string ZipCodeH
        {
            set { _ZipCodeH = value; }
            get { return _ZipCodeH; }
        }

        /// <summary>
        /// 城市-永久
        /// </summary>
        public string CityH
        {
            set { _CityH = value; }
            get { return _CityH; }
        }

        /// <summary>
        /// 區段-永久
        /// </summary>
        public string AreaH
        {
            set { _AreaH = value; }
            get { return _AreaH; }
        }

        /// <summary>
        /// 地址-永久
        /// </summary>
        public string AddressH
        {
            set { _AddressH = value; }
            get { return _AddressH; }
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
        /// 備註
        /// </summary>
        public string Memo
        {
            set { _Memo = value; }
            get { return _Memo; }
        }

        /// <summary>
        /// 狀態(待核准、待繳費、正常、退會、失聯)
        /// </summary>
        public string Status
        {
            set { _Status = value; }
            get { return _Status; }
        }

        /// <summary>
        /// 是否訂閱電子報
        /// </summary>
        public bool EDM
        {
            set { _EDM = value; }
            get { return _EDM; }
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
