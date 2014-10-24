using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DailyPerformanceWarningModule
{
    class Permissions
    {
        public static string 缺曠預警設定 { get { return "DailyPerformanceWarningModule.缺曠警示設定"; } }
        public static bool 缺曠預警設定權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[缺曠預警設定].Executable;
            }
        }

        public static string 懲戒預警設定 { get { return "DailyPerformanceWarningModule.懲戒預警設定"; } }
        public static bool 懲戒預警設定權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[懲戒預警設定].Executable;
            }
        }
    }
}
