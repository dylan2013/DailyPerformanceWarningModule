using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DailyPerformanceWarningModule
{
    public class DemeritConfigObj
    {
        /// <summary>
        /// 取得懲戒設定內容
        /// </summary>
        public DemeritConfigObj()
        {

        }

        public string ConfigName = "懲戒預警訊息";

        public string Config_RunDemerit = "是否執行懲戒預警";
        public string Config_StatisticsChange = "是否統計改變的學生才顯示";
        public string Config_IsSingOrAll = "單學期或所有學期";
        public string Config_SchoolYear = "學年度";
        public string Config_Semester = "學期";
        public string ConfigDemeritA = "大過";
        public string ConfigDemeritB = "小過";
        public string ConfigDemeritC = "警告";
        public string ConfigDemeritBalance = "是否進行功過相抵";
        public string ConfigMessage = "懲戒預警訊息";


        /// <summary>
        /// 設定檔
        /// </summary>
        public K12.Data.Configuration.ConfigData cd { get; set; }

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
        /// 是否統計改變的學生才顯示
        /// </summary>
        public bool StatisticsChange { get; set; }

        /// <summary>
        /// 是否進行功過相抵
        /// </summary>
        public bool DemeritBalance { get; set; }

        /// <summary>
        /// 大過
        /// </summary>
        public int DemeritA { get; set; }

        /// <summary>
        /// 小過
        /// </summary>
        public int DemeritB { get; set; }

        /// <summary>
        /// 警告
        /// </summary>
        public int DemeritC { get; set; }

        /// <summary>
        /// 懲戒預警訊息
        /// </summary>
        public string DemeritMessage { get; set; }

        /// <summary>
        /// 取得目前設定內容
        /// </summary>
        public void GetConfig()
        {
            cd = K12.Data.School.Configuration[ConfigName];

            if (!string.IsNullOrEmpty(cd[Config_RunDemerit]))
                Run = tool.ParseBool(cd[Config_RunDemerit]);
            else
                Run = false;


            //單或多學期
            if (!string.IsNullOrEmpty(cd[Config_IsSingOrAll]))
                SingOrAll = tool.ParseBool(cd[Config_IsSingOrAll]);
            else
                SingOrAll = true;

            //是否統計改變的學生才顯示
            if (!string.IsNullOrEmpty(cd[Config_StatisticsChange]))
                 StatisticsChange = tool.ParseBool(cd[Config_StatisticsChange]);
            else
                 StatisticsChange = false;

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

            //是否進行功過相抵
            if (!string.IsNullOrEmpty(cd[ConfigDemeritBalance]))
                DemeritBalance = tool.ParseBool(cd[ConfigDemeritBalance]);
            else
                DemeritBalance = true;

            //大過~警告
            DemeritA = tool.ParseInt(cd[ConfigDemeritA]);
            DemeritB = tool.ParseInt(cd[ConfigDemeritB]);
            DemeritC = tool.ParseInt(cd[ConfigDemeritC]);

            DemeritMessage = cd[ConfigMessage];

        }


        /// <summary>
        /// 將內容進行儲存
        /// </summary>
        public void SaveConfig()
        {
            cd[Config_RunDemerit] = Run.ToString();
            cd[Config_IsSingOrAll] = SingOrAll.ToString();
            cd[Config_StatisticsChange] = StatisticsChange.ToString();
            cd[Config_SchoolYear] = SchoolYear.ToString();
            cd[Config_Semester] = Semester.ToString();
            cd[ConfigDemeritA] = DemeritA.ToString();
            cd[ConfigDemeritB] = DemeritB.ToString();
            cd[ConfigDemeritC] = DemeritC.ToString();
            cd[ConfigDemeritBalance] = DemeritBalance.ToString();
            cd[ConfigMessage] = DemeritMessage;
            cd.Save();
        }
    }
}
