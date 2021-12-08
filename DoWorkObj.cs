using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DailyPerformanceWarningModule
{
    public class DoWorkObj
    {
        /// <summary>
        /// 缺曠清單
        /// </summary>
        public Dictionary<string, KeyBoStudent> AttendanceList { get; set; }

        /// <summary>
        /// 懲戒清單
        /// </summary>
        public Dictionary<string, KeyBoStudent> DemeritList { get; set; }

        /// <summary>
        /// 學生個人資料清單
        /// </summary>
        public Dictionary<string, KeyBoStudent> StudentDic { get; set; }

        /// <summary>
        /// 及時設定
        /// </summary>
        public  IsSaveOrShow _SaveOfShow { get; set; }

        public DoWorkObj()
        {
            AttendanceList = new Dictionary<string, KeyBoStudent>();
            DemeritList = new Dictionary<string, KeyBoStudent>();
            StudentDic = new Dictionary<string, KeyBoStudent>();
        }
    }
}
