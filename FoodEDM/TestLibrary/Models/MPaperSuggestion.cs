using System;

namespace TestLibrary.Models
{
    /// <summary>
    /// PaperSuggestion
    /// </summary>
    public class MPaperSuggestion
    {
        public MPaperSuggestion() { }

        private int _PaperSuggestionID;
        private int _PaperID;
        private string _PaperSuggestion;
        private DateTime _CreateDate;

        /// <summary>
        /// 論文意見流水號
        /// </summary>
        public int PaperSuggestionID
        {
            set { _PaperSuggestionID = value; }
            get { return _PaperSuggestionID; }
        }

        /// <summary>
        /// 論文流水號
        /// </summary>
        public int PaperID
        {
            set { _PaperID = value; }
            get { return _PaperID; }
        }

        /// <summary>
        /// 意見
        /// </summary>
        public string PaperSuggestion
        {
            set { _PaperSuggestion = value; }
            get { return _PaperSuggestion; }
        }

        /// <summary>
        /// 建立日期
        /// </summary>
        public DateTime CreateDate
        {
            set { _CreateDate = value; }
            get { return _CreateDate; }
        }

    }
}
