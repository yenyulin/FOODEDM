using System;

namespace TestLibrary.Models
{
    /// <summary>
    /// Receipt
    /// </summary>
    public class MReceipt
    {
        public MReceipt() { }

        private int _ReceiptID;
        private int _TWYear;
        private string _MemberID;
        private string _MemberType;
        private string _ReceiptType;
        private int _Fee;
        private string _ReceivedFromAppend;
        private string _Remark;
        private string _CreateUser;
        private DateTime _CreateDate;
        private string _CancelUser;
        private DateTime? _CancelDate;
        private bool _Enable;

        /// <summary>
        /// 收據序號
        /// </summary>
        public int ReceiptID
        {
            set { _ReceiptID = value; }
            get { return _ReceiptID; }
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
        /// 付款性質
        /// </summary>
        public string ReceiptType
        {
            set { _ReceiptType = value; }
            get { return _ReceiptType; }
        }

        /// <summary>
        /// 費用
        /// </summary>
        public int Fee
        {
            set { _Fee = value; }
            get { return _Fee; }
        }

        /// <summary>
        /// 茲收到附加內容
        /// </summary>
        public string ReceivedFromAppend
        {
            set { _ReceivedFromAppend = value; }
            get { return _ReceivedFromAppend; }
        }

        /// <summary>
        /// 備註
        /// </summary>
        public string Remark
        {
            set { _Remark = value; }
            get { return _Remark; }
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
        /// 取消人員
        /// </summary>
        public string CancelUser
        {
            set { _CancelUser = value; }
            get { return _CancelUser; }
        }

        /// <summary>
        /// 取消日期
        /// </summary>
        public DateTime? CancelDate
        {
            set { _CancelDate = value; }
            get { return _CancelDate; }
        }

        /// <summary>
        /// 狀態
        /// </summary>
        public bool Enable
        {
            set { _Enable = value; }
            get { return _Enable; }
        }

    }
}
