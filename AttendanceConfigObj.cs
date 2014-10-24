using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DailyPerformanceWarningModule
{

    public class AttendanceConfigObj
    {
        /// <summary>
        /// 取得缺曠設定內容
        /// </summary>
        public AttendanceConfigObj()
        {

        }

        public string ConfigName = "缺曠預警訊息";

        public string Config_RunAttendance = "是否執行缺曠預警";
        public string Config_IsSingOrAll = "單學期或所有學期";
        public string Config_SchoolYear = "學年度";
        public string Config_Semester = "學期";
        public string Config_AttendanceCount = "缺曠累積節次";
        public string Config_AttendanceName = "累積缺曠名稱";

        /// <summary>
        /// 設定檔
        /// </summary>
        public K12.Data.Configuration.ConfigData cd { get; set; }

        public List<string> AttendanceList { get; set; }

        /// <summary>
        /// 確認執行
        /// </summary>
        public bool Run { get; set; }

        /// <summary>
        /// 學年度
        /// </summary>
        public int SchoolYear { get; set; }

        /// <summary>
        /// 學期
        /// </summary>
        public int Semester { get; set; }

        /// <summary>
        /// 列印單一或多個學期
        /// </summary>
        public bool SingOrAll { get; set; }

        /// <summary>
        /// 缺曠別數
        /// </summary>
        public int AttenanceCount { get; set; }

        /// <summary>
        /// 取得目前設定內容
        /// </summary>
        public void GetConfig()
        {
            cd = K12.Data.School.Configuration[ConfigName];

            if (!string.IsNullOrEmpty(cd[Config_RunAttendance]))
                Run = tool.ParseBool(cd[Config_RunAttendance]);
            else
                Run = false;


            //單或多學期
            if (!string.IsNullOrEmpty(cd[Config_IsSingOrAll]))
                SingOrAll = tool.ParseBool(cd[Config_IsSingOrAll]);
            else
                SingOrAll = true;

            //學年度
            if (!string.IsNullOrEmpty(cd[Config_SchoolYear]))
                SchoolYear = tool.ParseInt(cd[Config_SchoolYear]);
            else
                SchoolYear = int.Parse(K12.Data.School.DefaultSchoolYear);

            //學期
            if (!string.IsNullOrEmpty(cd[Config_Semester]))
                Semester = tool.ParseInt(cd[Config_Semester]);
            else
                Semester = int.Parse(K12.Data.School.DefaultSemester);

            //取得缺曠節次
            AttenanceCount = tool.ParseInt(cd[Config_AttendanceCount]);

            //取得缺曠別內容
            if (!string.IsNullOrEmpty(cd[Config_AttendanceName]))
            {
                string[] SList = cd[Config_AttendanceName].Split(',');
                AttendanceList = SList.ToList();
            }
            else
            {
                AttendanceList = new List<string>();
            }
        }

        /// <summary>
        /// 將內容進行儲存
        /// </summary>
        public void SaveConfig()
        {
            cd[Config_RunAttendance] = Run.ToString();
            cd[Config_IsSingOrAll] = SingOrAll.ToString();
            cd[Config_SchoolYear] = SchoolYear.ToString();
            cd[Config_Semester] = Semester.ToString();
            cd[Config_AttendanceCount] = AttenanceCount.ToString();
            cd[Config_AttendanceName] = string.Join(",", AttendanceList);
            cd.Save();
        }
    }
}
