using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;

namespace DailyPerformanceWarningModule
{
    [TableName("daily.warning.attendance.record")]
    class AttendanceWarningRecord : ActiveRecord
    {
        /// <summary>
        /// 學生系統編號
        /// </summary>
        [Field(Field = "ref_student_id", Indexed = true)]
        public string RefStudentID { get; set; }

        /// <summary>
        /// 預警類別
        /// </summary>
        [Field(Field = "warning_type", Indexed = true)]
        public string WarningType { get; set; }

        /// <summary>
        /// 缺曠支數
        /// </summary>
        [Field(Field = "attendance_count", Indexed = true)]
        public double AttendanceCount { get; set; }
    }
}
