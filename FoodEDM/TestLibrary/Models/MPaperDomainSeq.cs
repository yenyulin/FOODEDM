using System;

namespace TestLibrary.Models
{
    /// <summary>
    /// PaperDomainSeq
    /// </summary>
    public class MPaperDomainSeq
    {
        public MPaperDomainSeq() { }

        private int _PaperID;
        private string _PaperDomainID;
        private int _Seq;

        /// <summary>
        /// 論文流水號
        /// </summary>
        public int PaperID
        {
            set { _PaperID = value; }
            get { return _PaperID; }
        }

        /// <summary>
        /// 論文領域代碼
        /// </summary>
        public string PaperDomainID
        {
            set { _PaperDomainID = value; }
            get { return _PaperDomainID; }
        }

        /// <summary>
        /// 順序
        /// </summary>
        public int Seq
        {
            set { _Seq = value; }
            get { return _Seq; }
        }

    }
}
