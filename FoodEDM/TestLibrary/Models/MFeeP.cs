using System;

namespace TestLibrary.Models
{
    /// <summary>
    /// FeeP
    /// </summary>
    public class MFeeP
    {
        public MFeeP() { }

        private int _FeePID;
        private string _MemberPID;
        private int _TWYear;
        private string _PayType;
        private int _Fee1;
        private int _Fee2;
        private int _Fee3;
        private DateTime _PayDate;
        private int? _OrderID;
        private string _Remark;

        /// <summary>
        /// FeeP序號
        /// </summary>
        public int FeePID
        {
            set { _FeePID = value; }
            get { return _FeePID; }
        }

        /// <summary>
        /// 會籍編號
        /// </summary>
        public string MemberPID
        {
            set { _MemberPID = value; }
            get { return _MemberPID; }
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
        /// 繳費方式(匯款;現場;年會現場;虛擬帳戶;超商條碼;超商代碼)
        /// </summary>
        public string PayType
        {
            set { _PayType = value; }
            get { return _PayType; }
        }

        /// <summary>
        /// 入會費
        /// </summary>
        public int Fee1
        {
            set { _Fee1 = value; }
            get { return _Fee1; }
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
        /// 繳費日期
        /// </summary>
        public DateTime PayDate
        {
            set { _PayDate = value; }
            get { return _PayDate; }
        }

        /// <summary>
        /// 金流繳費紀錄序號
        /// </summary>
        public int? OrderID
        {
            set { _OrderID = value; }
            get { return _OrderID; }
        }

        /// <summary>
        /// 備註
        /// </summary>
        public string Remark
        {
            set { _Remark = value; }
            get { return _Remark; }
        }

    }
}
