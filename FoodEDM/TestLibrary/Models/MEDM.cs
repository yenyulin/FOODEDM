using System;

namespace TestLibrary.Models
{
    /// <summary>
    /// EDM
    /// </summary>
    public class MEDM
    {
        public MEDM() { }

        private string _MemberID;
        private string _NameC;
        private string _Email;
        private bool _IsSend;

        /// <summary>
        /// 客戶ID
        /// </summary>
        public string MemberID
        {
            set { _MemberID = value; }
            get { return _MemberID; }
        }

        /// <summary>
        /// 中文名稱
        /// </summary>
        public string NameC
        {
            set { _NameC = value; }
            get { return _NameC; }
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
        /// 
        /// </summary>
        public bool IsSend
        {
            set { _IsSend = value; }
            get { return _IsSend; }
        }

    }
}
