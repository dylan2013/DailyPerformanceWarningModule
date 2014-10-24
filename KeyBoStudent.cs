using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DailyPerformanceWarningModule
{
	public class KeyBoStudent
	{
        public KeyBoStudent(DataRow row)
        {
            ID = "" + row["id"];
            Name = "" + row["name"];
            StudentNumber = "" + row["student_number"];
            SeatNo = "" + row["seat_no"];

            ClassID = "" + row["ref_class_id"];
            ClassName = "" + row["class_name"];
        }

        /// <summary>
        /// 缺曠比值
        /// </summary>
        public double AttendanceCount { get; set; }


        public int DemeritA { get; set; }
        public int DemeritB { get; set; }
        public int DemeritC { get; set; }

        public int MeritA { get; set; }
        public int MeritB { get; set; }
        public int MeritC { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 學生系統編號
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 學號
        /// </summary>
        public string StudentNumber { get; set; }

        /// <summary>
        /// 座號
        /// </summary>
        public string SeatNo { get; set; }

        /// <summary>
        /// 班級系統編號
        /// </summary>
        public string ClassID { get; set; }

        /// <summary>
        /// 班級名稱
        /// </summary>
        public string ClassName { get; set; }
	}
}
