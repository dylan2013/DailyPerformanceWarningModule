using FISCA.DSAUtil;
using FISCA.Presentation.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DailyPerformanceWarningModule
{
    static public class tool
    {

        static public FISCA.Data.QueryHelper _Q = new FISCA.Data.QueryHelper();
        static public FISCA.UDT.AccessHelper _A = new FISCA.UDT.AccessHelper();
        static public string SPstudentConfigList = "特殊學生表現_缺曠累積名單";
        /// <summary>
        /// 確認[字串]是否為[布林值]
        /// </summary>
        static public bool ParseBool(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                bool x = false;
                if (bool.TryParse(p, out x))
                {
                    return bool.Parse(p);
                }
            }

            return false;
        }

        static public int SortStudent(KeyBoStudent K1, KeyBoStudent K2)
        {
            string a = K1.ClassName.PadLeft(10, '0');
            string b = K2.ClassName.PadLeft(10, '0');

            a += K1.SeatNo.PadLeft(5, '0');
            b += K2.SeatNo.PadLeft(5, '0');

            return a.CompareTo(b);
        }

        /// <summary>
        /// 取得缺曠類別比例 一般:1 其它:0.5
        /// </summary>
        static public Dictionary<string, double> GetPeriodConfig()
        {
            //取得每日節次對照表(設定畫面)
            List<string> list = GetPeriodList();

            K12.Data.Configuration.ConfigData cd = K12.Data.School.Configuration[tool.SPstudentConfigList];

            Dictionary<string, double> ConfigByName = new Dictionary<string, double>();

            if (cd.Count != 0)
            {
                foreach (string each in list) //對缺曠假別做連集,預設為1
                {
                    if (cd.Contains(each))
                    {
                        if (doubleCheck(cd[each]))
                        {
                            ConfigByName.Add(each, double.Parse(cd[each]));
                        }
                        else
                        {
                            //MsgBox.Show(each + "之權重設定目前[" + cd[each] + "],是錯誤狀態,已預設為1");

                            ConfigByName.Add(each, 1);
                        }
                    }
                    else
                    {
                        ConfigByName.Add(each, 1);
                    }
                }
            }
            else //如果沒有設定
            {
                foreach (string each in list)
                {
                    ConfigByName.Add(each, 1);
                }
            }

            return ConfigByName;

        }

        static public bool doubleCheck(string txt)
        {
            double NowValue;
            if (!double.TryParse(txt, out NowValue))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 更新設定檔類內容
        /// </summary>
        static public void Update(DSRequest request)
        {
            CallService("SmartSchool.Config.UpdateList", request);
        }

        /// <summary>
        /// 呼叫Service
        /// </summary>
        /// <param name="service"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        static public DSResponse CallService(string service, DSRequest req)
        {
            return FISCA.Authentication.DSAServices.CallService(service, req);
        }

        /// <summary>
        /// 確認[字串]是否為[數字]
        /// </summary>
        static public int ParseInt(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                int x = 0;
                if (int.TryParse(p, out x))
                {
                    return int.Parse(p);
                }
            }

            return 0;
        }

        public static Dictionary<string, string> GetPeriodDic()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            List<K12.Data.PeriodMappingInfo> PeriodList = K12.Data.PeriodMapping.SelectAll();

            foreach (K12.Data.PeriodMappingInfo info in PeriodList)
            {
                if (!dic.ContainsKey(info.Name))
                {
                    dic.Add(info.Name, info.Type);
                }
            }
            return dic;

        }

        public static List<string> GetPeriodList()
        {
            List<string> list = new List<string>();
            List<K12.Data.PeriodMappingInfo> PeriodList = K12.Data.PeriodMapping.SelectAll();

            foreach (K12.Data.PeriodMappingInfo info in PeriodList)
            {
                if (!list.Contains(info.Type))
                {
                    list.Add(info.Type);
                }
            }

            list.Sort();
            return list;
        }

        /// <summary>
        /// 傳入數值,進行功過換算
        /// </summary>
        /// <param name="x">大功/大過</param>
        /// <param name="y">小功/小過</param>
        /// <param name="z">嘉獎/警告</param>
        /// <param name="t">True功FALSE過</param>
        /// <returns></returns>
        public static int GetBalance(int x, int y, int z, bool t)
        {
            int xx;
            if (t)
                xx = (y * Run.r.MeritBToMeritC.Value) + ((x * Run.r.MeritAToMeritB.Value) * Run.r.MeritBToMeritC.Value) + z;
            else
                xx = (y * Run.r.DemeritBToDemeritC.Value) + ((x * Run.r.DemeritAToDemeritB.Value) * Run.r.DemeritBToDemeritC.Value) + z;

            return xx;
        }

        /// <summary>
        /// 取得狀態為 一般,輟學 學生清單
        /// </summary>
        public static Dictionary<string, KeyBoStudent> GetStudentList()
        {
            Dictionary<string, KeyBoStudent> dic = new Dictionary<string, KeyBoStudent>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select student.id,student.name,student.student_number,student.seat_no,student.ref_class_id,class.class_name from student ");
            sb.Append("left join class on student.ref_class_id=class.id ");
            sb.Append("where student.status in (1,2)");

            DataTable dt = tool._Q.Select(sb.ToString());
            foreach (DataRow row in dt.Rows)
            {
                KeyBoStudent stud = new KeyBoStudent(row);

                if (!dic.ContainsKey(stud.ID))
                {
                    dic.Add(stud.ID, stud);
                }
            }

            return dic;
        }
    }
}
