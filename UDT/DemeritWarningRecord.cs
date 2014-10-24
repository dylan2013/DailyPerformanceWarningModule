using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;

namespace DailyPerformanceWarningModule
{
    [TableName("daily.warning.demerit.record")]
    class DemeritWarningRecord : ActiveRecord
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

        ///// <summary>
        ///// 大過支數
        ///// </summary>
        //[Field(Field = "demerit_a", Indexed = true)]
        //public string DemeritA { get; set; }

        ///// <summary>
        ///// 小過支數
        ///// </summary>
        //[Field(Field = "demerit_b", Indexed = true)]
        //public string DemeritB { get; set; }

        /// <summary>
        /// 警告支數
        /// </summary>
        [Field(Field = "demerit_c", Indexed = true)]
        public int DemeritC { get; set; }
    }
}
