using Campus.Message;
using FISCA;
using FISCA.Presentation;
using FISCA.Presentation.Controls;
using K12.BusinessLogic;
using K12.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPerformanceWarningModule
{
    public class Program
    {
        [MainMethod()]
        public static void Main()
        {
            UDTConfig();

            //功能載入後,直接去系統取得相關資料
            //並且透過通知機制 顯示相關內容於畫面上
            Run.DoInBGW();

            if (Permissions.缺曠預警設定權限)
                Run.BGW_Att.RunWorkerAsync(true);

            if (Permissions.懲戒預警設定權限)
                Run.BGW_Dem.RunWorkerAsync(true);


            RibbonBarItem item = FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "基本設定"];
            item["設定"].Image = Properties.Resources.sandglass_unlock_64;
            item["設定"].Size = RibbonBarButton.MenuButtonSize.Large;
            item["設定"]["缺曠預警設定"].Enable = Permissions.缺曠預警設定權限;
            item["設定"]["缺曠預警設定"].Click += delegate
            {
                AttendanceForm con = new AttendanceForm();
                con.ShowDialog();
            };

            item["設定"]["懲戒預警設定"].Enable = Permissions.懲戒預警設定權限;
            item["設定"]["懲戒預警設定"].Click += delegate
            {
                DemeritForm con = new DemeritForm();
                con.ShowDialog();
            };


            FISCA.Permission.Catalog TestCatalog3 = FISCA.Permission.RoleAclSource.Instance["學務作業"]["功能按鈕"];
            TestCatalog3.Add(new FISCA.Permission.RibbonFeature(Permissions.缺曠預警設定, "缺曠預警設定"));
            TestCatalog3.Add(new FISCA.Permission.RibbonFeature(Permissions.懲戒預警設定, "懲戒預警設定"));
        }

        private static void UDTConfig()
        {
            #region 處理UDT Table沒有的問題

            K12.Data.Configuration.ConfigData cd = K12.Data.School.Configuration["缺曠懲戒預警UDT載入設定"];
            bool checkClubUDT = false;

            string name = "預警UDT是否已載入_20140903";
            //如果尚無設定值,預設為
            if (string.IsNullOrEmpty(cd[name]))
            {
                cd[name] = "false";
            }

            //檢查是否為布林
            bool.TryParse(cd[name], out checkClubUDT);

            if (!checkClubUDT)
            {
                tool._A.Select<AttendanceWarningRecord>("UID = '00000'");
                tool._A.Select<DemeritWarningRecord>("UID = '00000'");

                cd[name] = "true";
                cd.Save();
            }

            #endregion
        }
    }
}
