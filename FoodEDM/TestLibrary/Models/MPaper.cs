using System;

namespace TestLibrary.Models
{
    /// <summary>
    /// Paper
    /// </summary>
    public class MPaper
    {
        public MPaper() { }

        private int _PaperID;
        private int _TWYear;
        private string _PaperTitle;
        private string _PaperAuthor;
        private string _Company;
        private string _SummaryC;
        private string _SummaryE;
        private string _MemberType;
        private string _MemberID;
        private string _Tel1;
        private string _Tel2;
        private string _Ext;
        private string _Fax1;
        private string _Fax2;
        private string _Email;
        private DateTime? _UploadDate;
        private string _PublishType;
        private string _PaperDomainID;
        private bool _Publish;
        private string _FileExtension;
        private string _Examine;
        private DateTime? _ExamineDate;
        private string _PaperNo;

        /// <summary>
        /// 論文流水號
        /// </summary>
        public int PaperID
        {
            set { _PaperID = value; }
            get { return _PaperID; }
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
        /// 論文題目
        /// </summary>
        public string PaperTitle
        {
            set { _PaperTitle = value; }
            get { return _PaperTitle; }
        }

        /// <summary>
        /// 作者
        /// </summary>
        public string PaperAuthor
        {
            set { _PaperAuthor = value; }
            get { return _PaperAuthor; }
        }

        /// <summary>
        /// 服務機關
        /// </summary>
        public string Company
        {
            set { _Company = value; }
            get { return _Company; }
        }

        /// <summary>
        /// 中文摘要
        /// </summary>
        public string SummaryC
        {
            set { _SummaryC = value; }
            get { return _SummaryC; }
        }

        /// <summary>
        /// 英文摘要
        /// </summary>
        public string SummaryE
        {
            set { _SummaryE = value; }
            get { return _SummaryE; }
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
        /// 聯絡人會籍編號
        /// </summary>
        public string MemberID
        {
            set { _MemberID = value; }
            get { return _MemberID; }
        }

        /// <summary>
        /// 聯絡電話區碼
        /// </summary>
        public string Tel1
        {
            set { _Tel1 = value; }
            get { return _Tel1; }
        }

        /// <summary>
        /// 聯絡電話
        /// </summary>
        public string Tel2
        {
            set { _Tel2 = value; }
            get { return _Tel2; }
        }

        /// <summary>
        /// 分機
        /// </summary>
        public string Ext
        {
            set { _Ext = value; }
            get { return _Ext; }
        }

        /// <summary>
        /// 傳真號碼區碼
        /// </summary>
        public string Fax1
        {
            set { _Fax1 = value; }
            get { return _Fax1; }
        }

        /// <summary>
        /// 傳真號碼
        /// </summary>
        public string Fax2
        {
            set { _Fax2 = value; }
            get { return _Fax2; }
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
        /// 上傳日期
        /// </summary>
        public DateTime? UploadDate
        {
            set { _UploadDate = value; }
            get { return _UploadDate; }
        }

        /// <summary>
        /// 論文發表方式(壁報展示,口頭發表)
        /// </summary>
        public string PublishType
        {
            set { _PublishType = value; }
            get { return _PublishType; }
        }

        /// <summary>
        /// 論文組別代碼
        /// </summary>
        public string PaperDomainID
        {
            set { _PaperDomainID = value; }
            get { return _PaperDomainID; }
        }

        /// <summary>
        /// 是否向媒體發表
        /// </summary>
        public bool Publish
        {
            set { _Publish = value; }
            get { return _Publish; }
        }

        /// <summary>
        /// 副檔名
        /// </summary>
        public string FileExtension
        {
            set { _FileExtension = value; }
            get { return _FileExtension; }
        }

        /// <summary>
        /// 審核狀態(未審核、不通過、通過)
        /// </summary>
        public string Examine
        {
            set { _Examine = value; }
            get { return _Examine; }
        }

        /// <summary>
        /// 審核日期
        /// </summary>
        public DateTime? ExamineDate
        {
            set { _ExamineDate = value; }
            get { return _ExamineDate; }
        }

        /// <summary>
        /// 論文編號
        /// </summary>
        public string PaperNo
        {
            set { _PaperNo = value; }
            get { return _PaperNo; }
        }

    }
}
