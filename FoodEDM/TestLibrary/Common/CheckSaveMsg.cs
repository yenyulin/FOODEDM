using System;

namespace TestLibrary.Common
{
    public class CheckSaveMsg
    {
        private bool _Check;
        private bool _Save;
        private string _Msg;

        private string _ReturnValue;
        public CheckSaveMsg()
        {
            _Check = true;
            _Save = false;
            _Msg = "";
            _ReturnValue = "";
        }

        /// <summary>
        /// 輸入確認
        /// </summary>
        public bool Check
        {
            get { return _Check; }
            set { _Check = value; }
        }

        /// <summary>
        /// 儲存確認
        /// </summary>
        public bool Save
        {
            get { return _Save; }
            set { _Save = value; }
        }

        /// <summary>
        /// 訊息
        /// </summary>
        public string Msg
        {
            get { return _Msg; }
            set { _Msg = value; }
        }

        /// <summary>
        /// 回傳值
        /// </summary>
        public string ReturnValue
        {
            get { return _ReturnValue; }
            set { _ReturnValue = value; }
        }
    }
}