﻿using Campus.Message;
using FISCA.Presentation.Controls;
using K12.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DailyPerformanceWarningModule
{
    static public class Run
    {
        static public K12.Data.MeritDemeritReduceRecord reduce { get; set; }

        public static AttendanceConfigObj AttConfig { get; set; }
        public static DemeritConfigObj DemConfig { get; set; }

        public static BackgroundWorker BGW_Att { get; set; }
        public static DoWorkObj _do { get; set; }

        public static BackgroundWorker BGW_Dem { get; set; }

        static public void DoInBGW()
        {

            BGW_Att = new BackgroundWorker();
            BGW_Att.RunWorkerCompleted += BGW_Att_RunWorkerCompleted;
            BGW_Att.DoWork += BGW_Att_DoWork;

            BGW_Dem = new BackgroundWorker();
            BGW_Dem.RunWorkerCompleted += BGW_Dem_RunWorkerCompleted;
            BGW_Dem.DoWork += BGW_Dem_DoWork;

        }

        static void BGW_Att_DoWork(object sender, DoWorkEventArgs e)
        {
            DoWorkObj obj = new DoWorkObj();
            obj._SaveOfShow = (IsSaveOrShow)e.Argument;
            //學生ID : 學生
            obj.StudentDic = tool.GetStudentList();

            if (Permissions.缺曠預警設定權限)
            {
                Run.RunAtt(obj, obj._SaveOfShow);
            }

            e.Result = obj;
        }

        static void BGW_Att_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                if (e.Error == null)
                {
                    _do = (DoWorkObj)e.Result;

                    if (_do.AttendanceList.Count > 0)
                    {
                        Run.CompletedAtt(_do);
                    }
                    else
                    {
                        FISCA.Presentation.MotherForm.SetStatusBarMessage("缺曠預警,未取得符合標準學生!!");
                    }
                }
                else
                    MsgBox.Show("發生錯誤!!");
            }
            else
                MsgBox.Show("作業已取消!!");
        }

        static void BGW_Dem_DoWork(object sender, DoWorkEventArgs e)
        {
            DoWorkObj obj = new DoWorkObj();
            obj._SaveOfShow = (IsSaveOrShow)e.Argument;
            //學生ID : 學生
            obj.StudentDic = tool.GetStudentList();

            if (Permissions.懲戒預警設定權限)
            {
                Run.RunDem(obj, obj._SaveOfShow);
            }

            e.Result = obj;
        }

        static void BGW_Dem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                if (e.Error == null)
                {
                    _do = (DoWorkObj)e.Result;

                    if (_do.DemeritList.Count > 0)
                    {
                        Run.CompletedDem(_do);
                    }
                    else
                    {
                        FISCA.Presentation.MotherForm.SetStatusBarMessage("懲戒預警,未取得符合標準學生!!");
                    }
                }
                else
                    MsgBox.Show("發生錯誤!!");
            }
            else
                MsgBox.Show("作業已取消!!");
        }

        public static void RunAtt(DoWorkObj obj, IsSaveOrShow IsSave)
        {
            #region 取得缺曠戳記

            //系統內未存之資料
            List<AttendanceWarningRecord> InsertAttUDTList = new List<AttendanceWarningRecord>();

            //系統內需被更新之資料
            List<AttendanceWarningRecord> UpdateAttUDTList = new List<AttendanceWarningRecord>();

            //系統內學生已不需通知之內容
            List<AttendanceWarningRecord> DeleteAttUDTList = new List<AttendanceWarningRecord>();

            List<AttendanceWarningRecord> AttUDTList = tool._A.Select<AttendanceWarningRecord>();
            Dictionary<string, AttendanceWarningRecord> AttUDTDic = new Dictionary<string, AttendanceWarningRecord>();
            foreach (AttendanceWarningRecord each in AttUDTList)
            {
                if (!AttUDTDic.ContainsKey(each.RefStudentID))
                {
                    AttUDTDic.Add(each.RefStudentID, each);
                }
            }

            #endregion

            #region 實作

            AttConfig = new AttendanceConfigObj();
            AttConfig.GetConfig();

            if (AttConfig.Run || IsSave.NowRun) //是否執行
            {
                foreach (KeyBoStudent each in GetAttWainneList(AttConfig, obj).Values)
                {

                    if (IsSave.IsSave) //是否為登入模式
                    {
                        if (AttConfig.StatisticsChange)
                        {
                            #region 統計改變的學生才顯示

                            if (AttUDTDic.ContainsKey(each.ID))
                            {
                                //是否符合標準
                                if (each.AttendanceCount >= AttConfig.AttenanceCount)
                                {
                                    //如果支數與系統內目前已存不一致,才顯示
                                    if (AttUDTDic[each.ID].AttendanceCount != each.AttendanceCount)
                                    {
                                        obj.AttendanceList.Add(each.ID, each);

                                        AttUDTDic[each.ID].AttendanceCount = each.AttendanceCount;
                                        UpdateAttUDTList.Add(AttUDTDic[each.ID]);
                                    }
                                    else
                                    {
                                        //支數符合標準,但支數與"戳記"相同
                                        //不予處理
                                    }
                                }
                                else
                                {
                                    //已不符標準,則進行"戳記"刪除作業
                                    DeleteAttUDTList.Add(AttUDTDic[each.ID]);
                                }
                            }
                            else
                            {
                                //沒有記錄
                                if (each.AttendanceCount >= AttConfig.AttenanceCount)
                                {
                                    //系統內未存有此學生之提示內容
                                    obj.AttendanceList.Add(each.ID, each);

                                    AttendanceWarningRecord awR = new AttendanceWarningRecord();
                                    awR.RefStudentID = each.ID;
                                    awR.AttendanceCount = each.AttendanceCount;
                                    awR.WarningType = "缺曠";
                                    InsertAttUDTList.Add(awR);
                                }
                                else
                                {
                                    //不符標準,不需動作
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            if (each.AttendanceCount >= AttConfig.AttenanceCount)
                            {
                                obj.AttendanceList.Add(each.ID, each);
                            }
                        }
                    }
                    else
                    {
                        if (each.AttendanceCount >= AttConfig.AttenanceCount)
                        {
                            obj.AttendanceList.Add(each.ID, each);
                        }
                    }
                }
            }

            #endregion

            #region 移除或新增戳記

            if (IsSave.IsSave)
            {
                try
                {
                    if (InsertAttUDTList.Count != 0)
                        tool._A.InsertValues(InsertAttUDTList);

                    if (UpdateAttUDTList.Count != 0)
                        tool._A.UpdateValues(UpdateAttUDTList);

                    if (DeleteAttUDTList.Count != 0)
                        tool._A.DeletedValues(DeleteAttUDTList);
                }
                catch (Exception ex)
                {
                    MsgBox.Show("新增缺曠提示戳記發生錯誤\n" + ex.Message);
                }
            }

            #endregion
        }

        public static void RunDem(DoWorkObj obj, IsSaveOrShow IsSave)
        {
            //取得功過換算表,以Count預警懲戒數
            reduce = K12.Data.MeritDemeritReduce.Select();

            #region 取得懲戒戳記

            //系統內未存之資料
            List<DemeritWarningRecord> InsertDemUDTList = new List<DemeritWarningRecord>();

            //系統內需被更新之資料
            List<DemeritWarningRecord> UpdateDemUDTList = new List<DemeritWarningRecord>();

            //系統內學生已不需通知之內容
            List<DemeritWarningRecord> DeleteDemUDTList = new List<DemeritWarningRecord>();

            List<DemeritWarningRecord> DemUDTList = tool._A.Select<DemeritWarningRecord>();
            Dictionary<string, DemeritWarningRecord> DemUDTDic = new Dictionary<string, DemeritWarningRecord>();
            foreach (DemeritWarningRecord each in DemUDTList)
            {
                if (!DemUDTDic.ContainsKey(each.RefStudentID))
                {
                    DemUDTDic.Add(each.RefStudentID, each);
                }
            }

            #endregion

            #region 實作

            DemConfig = new DemeritConfigObj();
            DemConfig.GetConfig();

            //設定值先進行換算
            int Configw = tool.GetBalance(DemConfig.DemeritA, DemConfig.DemeritB, DemConfig.DemeritC, false);

            if (DemConfig.Run || IsSave.NowRun) //是否執行
            {
                foreach (KeyBoStudent each in GetDemeritWainneList(DemConfig, obj).Values)
                {
                    int x;

                    #region 是否進行功過換算

                    if (DemConfig.DemeritBalance)
                    {
                        int z = tool.GetBalance(each.DemeritA, each.DemeritB, each.DemeritC, false);
                        int y = tool.GetBalance(each.MeritA, each.MeritB, each.MeritC, true);
                        x = z - y; //大於0表示懲戒狀態(功過換算)
                    }
                    else
                    {
                        x = tool.GetBalance(each.DemeritA, each.DemeritB, each.DemeritC, false);
                    }

                    #endregion

                    if (IsSave.IsSave)
                    {
                        if (DemConfig.StatisticsChange)
                        {
                            #region 統計改變的學生才顯示

                            if (x >= Configw)
                            {
                                if (DemUDTDic.ContainsKey(each.ID))
                                {
                                    //如果支數與系統內目前已存不一致,才顯示
                                    if (DemUDTDic[each.ID].DemeritC != x)
                                    {
                                        obj.DemeritList.Add(each.ID, each);

                                        DemUDTDic[each.ID].DemeritC = x;
                                        UpdateDemUDTList.Add(DemUDTDic[each.ID]);
                                    }
                                }
                                else
                                {
                                    //系統內未存有此學生之提示內容
                                    obj.DemeritList.Add(each.ID, each);

                                    DemeritWarningRecord awR = new DemeritWarningRecord();
                                    awR.RefStudentID = each.ID;
                                    awR.DemeritC = x;
                                    awR.WarningType = "懲戒";
                                    InsertDemUDTList.Add(awR);
                                }
                            }
                            else
                            {
                                //清除當學生懲戒已低於警示標準
                                //需將其刪除
                                if (DemUDTDic.ContainsKey(each.ID))
                                {
                                    DeleteDemUDTList.Add(DemUDTDic[each.ID]);
                                }
                            }

                            #endregion
                        }
                        else
                        {
                            if (x >= Configw)
                            {
                                obj.DemeritList.Add(each.ID, each);
                            }
                        }
                    }
                    else
                    {
                        if (x >= Configw)
                        {
                            obj.DemeritList.Add(each.ID, each);
                        }
                    }
                }
            }

            #endregion

            #region 移除或新增戳記

            if (IsSave.IsSave)
            {
                try
                {
                    if (InsertDemUDTList.Count != 0)
                        tool._A.InsertValues(InsertDemUDTList);

                    if (UpdateDemUDTList.Count != 0)
                        tool._A.UpdateValues(UpdateDemUDTList);

                    if (DeleteDemUDTList.Count != 0)
                        tool._A.DeletedValues(DeleteDemUDTList);
                }
                catch (Exception ex)
                {
                    MsgBox.Show("新增懲戒提示戳記發生錯誤\n" + ex.Message);
                }
            }

            #endregion
        }

        /// <summary>
        /// 取得缺曠預警清單
        /// </summary>
        public static Dictionary<string, KeyBoStudent> GetAttWainneList(AttendanceConfigObj Config, DoWorkObj obj)
        {

            #region Att

            List<string> StudentIDList = obj.StudentDic.Keys.ToList();

            //依據設定值,取得缺曠資料
            List<AttendanceRecord> AttendanceList = new List<AttendanceRecord>();
            if (Config.SingOrAll)
            {
                AttendanceList = K12.Data.Attendance.Select(StudentIDList, null, null, null, new List<int>() { Config.SchoolYear }, new List<int>() { Config.Semester });
            }
            else
            {
                AttendanceList = K12.Data.Attendance.SelectByStudentIDs(StudentIDList);
            }

            //取得比例設定值,以Count預警缺曠數
            Dictionary<string, double> ConfigByName = tool.GetPeriodConfig();
            Dictionary<string, string> PeriodDic = tool.GetPeriodDic();

            foreach (AttendanceRecord Record in AttendanceList)
            {
                if (obj.StudentDic.ContainsKey(Record.RefStudentID))
                {
                    foreach (AttendancePeriod Period in Record.PeriodDetail)
                    {
                        if (Config.AttendanceList.Contains(Period.AbsenceType))
                        {
                            if (PeriodDic.ContainsKey(Period.Period))
                            {
                                if (ConfigByName.ContainsKey(PeriodDic[Period.Period]))
                                {
                                    obj.StudentDic[Record.RefStudentID].AttendanceCount += ConfigByName[PeriodDic[Period.Period]];
                                }
                            }
                        }
                    }
                }
            }

            #endregion

            return obj.StudentDic;
        }

        /// <summary>
        /// 取得懲戒預警內容
        /// </summary>
        public static Dictionary<string, KeyBoStudent> GetDemeritWainneList(DemeritConfigObj Config, DoWorkObj obj)
        {
            List<string> StudentIDList = obj.StudentDic.Keys.ToList();

            #region Demerit

            //依據設定值,取得統計資料
            List<DemeritRecord> DemeritList = new List<DemeritRecord>();
            if (Config.SingOrAll)
            {
                DemeritList = K12.Data.Demerit.Select(StudentIDList, null, null, null, null, new List<int>() { Config.SchoolYear }, new List<int>() { Config.Semester });
            }
            else
            {
                DemeritList = K12.Data.Demerit.SelectByStudentIDs(StudentIDList);
            }

            foreach (DemeritRecord Record in DemeritList)
            {
                if (Record.Cleared != "是")
                {
                    if (obj.StudentDic.ContainsKey(Record.RefStudentID))
                    {
                        obj.StudentDic[Record.RefStudentID].DemeritA += Record.DemeritA.Value;
                        obj.StudentDic[Record.RefStudentID].DemeritB += Record.DemeritB.Value;
                        obj.StudentDic[Record.RefStudentID].DemeritC += Record.DemeritC.Value;
                    }
                }
            }

            #endregion

            if (Config.DemeritBalance)
            {
                //不進行功過相抵,可以直接不取得獎勵資料

                #region Merit

                List<MeritRecord> MeritList = new List<MeritRecord>();
                if (Config.SingOrAll)
                {
                    MeritList = K12.Data.Merit.Select(StudentIDList, null, null, null, null, new List<int>() { Config.SchoolYear }, new List<int>() { Config.Semester });
                }
                else
                {
                    MeritList = K12.Data.Merit.SelectByStudentIDs(StudentIDList);
                }

                foreach (MeritRecord Record in MeritList)
                {
                    if (obj.StudentDic.ContainsKey(Record.RefStudentID))
                    {
                        obj.StudentDic[Record.RefStudentID].MeritA += Record.MeritA.Value;
                        obj.StudentDic[Record.RefStudentID].MeritB += Record.MeritB.Value;
                        obj.StudentDic[Record.RefStudentID].MeritC += Record.MeritC.Value;
                    }
                }

                #endregion
            }

            return obj.StudentDic;
        }


        public static void CompletedAtt(DoWorkObj _do)
        {
            #region 缺曠

            StringBuilder sb = new StringBuilder();

            List<string> StudentIDList = new List<string>();
            sb.AppendLine("以下學生已達預警標準「" + AttConfig.AttenanceCount + "」節次");
            List<KeyBoStudent> rLint = _do.AttendanceList.Values.ToList();
            rLint.Sort(tool.SortStudent);

            foreach (KeyBoStudent ke in rLint)
            {
                StudentIDList.Add(ke.ID);
                sb.AppendLine(string.Format("班級「{0}」座號「{1}」學生「{2}」缺曠節次「{3}」", ke.ClassName, ke.SeatNo, ke.Name, ke.AttendanceCount));
            }

            if (_do._SaveOfShow.IsShow)
            {
                CustomRecord cr = new CustomRecord();
                cr.Content = sb.ToString();
                cr.Title = "缺曠預警系統";
                cr.Type = Campus.Message.CrType.Type.Warning_Red;
                cr.OtherMore = new IsViewForm_Open(sb.ToString(), _do, true);

                MessageRobot.AddMessage(cr);
            }


            #endregion
        }

        public static void CompletedDem(DoWorkObj _do)
        {
            #region 懲戒

            StringBuilder sb = new StringBuilder();
            List<string> StudentIDList = new List<string>();
            sb.AppendLine("以下學生已達預警標準,大過「" + DemConfig.DemeritA + "」小過「" + DemConfig.DemeritB + "」警告「" + DemConfig.DemeritC + "」");

            List<KeyBoStudent> rLint = _do.DemeritList.Values.ToList();
            rLint.Sort(tool.SortStudent);

            foreach (KeyBoStudent student in rLint)
            {
                //是否進行功過換算
                if (DemConfig.DemeritBalance)
                {
                    int z = tool.GetBalance(student.DemeritA, student.DemeritB, student.DemeritC, false);
                    int y = tool.GetBalance(student.MeritA, student.MeritB, student.MeritC, true);
                    int x = z - y; //大於0表示懲戒狀態(功過換算)

                    //警告
                    int xx = x % Run.reduce.DemeritBToDemeritC.Value;
                    //小過
                    int yy = (x / Run.reduce.DemeritBToDemeritC.Value) % Run.reduce.DemeritAToDemeritB.Value;
                    //大過
                    int zz = (x / Run.reduce.DemeritBToDemeritC.Value) / Run.reduce.DemeritAToDemeritB.Value;

                    student.DemeritA = zz;
                    student.DemeritB = yy;
                    student.DemeritC = xx;

                    sb.AppendLine(string.Format("班級「{0}」座號「{1}」學生「{2}」大過「{3}」小過「{4}」警告「{5}」", student.ClassName, student.SeatNo, student.Name, student.DemeritA, student.DemeritB, student.DemeritC));
                }
                else
                {
                    //警告
                    int xx = student.DemeritC;
                    //小過
                    int yy = student.DemeritB;
                    //大過
                    int zz = student.DemeritA ;

                    student.DemeritA = zz;
                    student.DemeritB = yy;
                    student.DemeritC = xx;

                    sb.AppendLine(string.Format("班級「{0}」座號「{1}」學生「{2}」大過「{3}」小過「{4}」警告「{5}」", student.ClassName, student.SeatNo, student.Name, student.DemeritA, student.DemeritB, student.DemeritC));

                }

                StudentIDList.Add(student.ID);
            }

            if (_do._SaveOfShow.IsShow)
            {
                CustomRecord cr = new CustomRecord();
                cr.Content = sb.ToString();
                cr.Title = "懲戒預警系統";
                cr.Type = Campus.Message.CrType.Type.Warning_Red;
                cr.OtherMore = new IsViewForm_Open(sb.ToString(), _do, false);

                MessageRobot.AddMessage(cr);
            }

            #endregion
        }
    }

    public class IsSaveOrShow
    {
        //主要是控制已經預警過的學生
        //True : 要依據已經預警過的學生來判斷
        //False: 進進行測試,所以不處理是否預警過的問題
        /// <summary>
        /// 使否為登入模式
        /// </summary>
        public bool IsSave { get; set; }

        /// <summary>
        /// 是否顯示右下方的彈出視窗
        /// </summary>
        public bool NowRun { get; set; }

        /// <summary>
        /// 是否顯示左下訊息視窗
        /// </summary>
        public bool IsShow { get; set; }
    }
}
