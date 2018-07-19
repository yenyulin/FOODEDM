using System;

namespace TestLibrary.Models
{
    /// <summary>
    /// MemberG
    /// </summary>
    public class MMemberG
    {
        public MMemberG() { }

        private string _MemberGID;
        private string _MemberGassword;
        private string _CompanyID;
        private string _NameC;
        private string _MemberClass;
        private string _TEL;
        private string _FAX;
        private DateTime _RegisterDate;
        private string _ZipCode;
        private string _City;
        private string _Area;
        private string _Address;
        private string _ContactName;
        private string _ContactTitle;
        private string _ContactTEL;
        private string _ContactMobile;
        private string _ContactEmail;
        private string _AgentName;
        private string _AgentTitle;
        private string _AgentTEL;
        private string _AgentMobile;
        private string _AgentEmail;
        private string _Memo;
        private string _Status;
        private bool _EDM;
        private string _CreateUser;
        private DateTime _CreateDate;
        private string _UpdateUser;
        private DateTime _UpdateDate;
        private string _JobContent;

        /// <summary>
        /// 會籍編號
        /// </summary>
        public string MemberGID
        {
            set { _MemberGID = value; }
            get { return _MemberGID; }
        }

        /// <summary>
        /// 密碼
        /// </summary>
        public string MemberGassword
        {
            set { _MemberGassword = value; }
            get { return _MemberGassword; }
        }

        /// <summary>
        /// 統一編號
        /// </summary>
        public string CompanyID
        {
            set { _CompanyID = value; }
            get { return _CompanyID; }
        }

        /// <summary>
        /// 名稱
        /// </summary>
        public string NameC
        {
            set { _NameC = value; }
            get { return _NameC; }
        }

        /// <summary>
        /// 會籍類別(甲、乙)
        /// </summary>
        public string MemberClass
        {
            set { _MemberClass = value; }
            get { return _MemberClass; }
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
        /// 入會日期
        /// </summary>
        public DateTime RegisterDate
        {
            set { _RegisterDate = value; }
            get { return _RegisterDate; }
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
        /// x聯絡人姓名
        /// </summary>
        public string ContactName
        {
            set { _ContactName = value; }
            get { return _ContactName; }
        }

        /// <summary>
        /// 聯絡人職稱
        /// </summary>
        public string ContactTitle
        {
            set { _ContactTitle = value; }
            get { return _ContactTitle; }
        }

        /// <summary>
        /// 聯絡人電話
        /// </summary>
        public string ContactTEL
        {
            set { _ContactTEL = value; }
            get { return _ContactTEL; }
        }

        /// <summary>
        /// 聯絡人手機
        /// </summary>
        public string ContactMobile
        {
            set { _ContactMobile = value; }
            get { return _ContactMobile; }
        }

        /// <summary>
        /// 聯絡人Email
        /// </summary>
        public string ContactEmail
        {
            set { _ContactEmail = value; }
            get { return _ContactEmail; }
        }

        /// <summary>
        /// 代表人姓名
        /// </summary>
        public string AgentName
        {
            set { _AgentName = value; }
            get { return _AgentName; }
        }

        /// <summary>
        /// 代表人職稱
        /// </summary>
        public string AgentTitle
        {
            set { _AgentTitle = value; }
            get { return _AgentTitle; }
        }

        /// <summary>
        /// 代表人電話
        /// </summary>
        public string AgentTEL
        {
            set { _AgentTEL = value; }
            get { return _AgentTEL; }
        }

        /// <summary>
        /// 代表人手機
        /// </summary>
        public string AgentMobile
        {
            set { _AgentMobile = value; }
            get { return _AgentMobile; }
        }

        /// <summary>
        /// 代表人Email
        /// </summary>
        public string AgentEmail
        {
            set { _AgentEmail = value; }
            get { return _AgentEmail; }
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
        /// 狀態(待核准、待繳費、正常、退會)
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

        /// <summary>
        /// 業務內容概要
        /// </summary>
        public string JobContent
        {
            set { _JobContent = value; }
            get { return _JobContent; }
        }

    }
}
