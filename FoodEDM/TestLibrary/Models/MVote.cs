using System;

namespace TestLibrary.Models
{
    /// <summary>
    /// Vote
    /// </summary>
    public class MVote
    {
        public MVote() { }

        private int _VoteID;
        private int _TWYear;
        private string _MemberID;
        private string _AgentMemberID;
        private string _CreateUser;
        private DateTime _CreateDate;

        /// <summary>
        /// 選票序號
        /// </summary>
        public int VoteID
        {
            set { _VoteID = value; }
            get { return _VoteID; }
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
        /// 代理會員編號
        /// </summary>
        public string AgentMemberID
        {
            set { _AgentMemberID = value; }
            get { return _AgentMemberID; }
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

    }
}
