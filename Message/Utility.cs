using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;
using System.Data;
using FISCA.Data;
using System.Text.RegularExpressions;

namespace DailyPerformanceWarningModule
{
    public class Utility
    {
        public static string ConfigXMLFileName = "";
        private static QueryHelper qh = new QueryHelper();

        public static XDocument LoadConfigXML()
        {
            XDocument xmlDoc = null;
            try
            {
                string ePaperDir = $"{Application.StartupPath}\\ePapers";
                ConfigXMLFileName = ePaperDir + "\\config.xml";
                DirectoryInfo di;
                // 檢查 ePaper資料夾不存在建立
                if (!Directory.Exists(ePaperDir))
                {
                    di = Directory.CreateDirectory(ePaperDir);
                }
                else
                {
                    di = new DirectoryInfo(ePaperDir);
                }

                // 檢查設定檔是否存在
                if (File.Exists(ConfigXMLFileName))
                {
                    xmlDoc = XDocument.Load(ConfigXMLFileName);
                    var ep = xmlDoc.Element("ePapers");
                    // 不存在
                    if (ep.Attribute("LoadManager") == null)
                    {
                        ep.SetAttributeValue("LoadManager", true);
                    }

                }
                else
                {
                    // 不存在載入預設
                    XElement epapers = new XElement("ePapers");
                    epapers.SetAttributeValue("LoadManager", true);
                    xmlDoc = new XDocument(epapers);
                }

                // 資料檢查與依建立時間排序
                if (xmlDoc.Element("ePapers") != null)
                {
                    int count = xmlDoc.Element("ePapers").Elements().Count();
                    if (count > 0)
                    {
                        // 依建立時間排序
                        List<XElement> elm = (from data in xmlDoc.Element("ePapers").Elements() orderby DateTime.Parse(data.Attribute("Timestmp").Value) descending select data).ToList();

                        // xmlDoc.Element("ePapers").RemoveAll();
                        xmlDoc.Element("ePapers").Elements("ePaper").Remove();
                        xmlDoc.Element("ePapers").Add(elm);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("config檔讀取失敗,", ex.Message);
            }
            return xmlDoc;
        }


        /// <summary>
        /// 新增電子報表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="overview"></param>
        /// <param name="metadata"></param>
        /// <param name="viewer_type"></param>
        /// <param name="school_year"></param>
        /// <param name="semester"></param>
        /// <returns></returns>
        public static string AddElectronicPaper(string name, string overview, string metadata, string viewer_type, string school_year, string semester)
        {
            string ePaperID = "";
            try
            {
                string sqlStr = $"INSERT INTO electronic_paper(name,timestamp,overview,metadata,viewer_type,school_year,semester) VALUES('{name}',now(),'{overview}','{metadata}','{viewer_type}',{school_year},{semester}) RETURNING id;";


                DataTable dt = qh.Select(sqlStr);
                if (dt.Rows.Count > 0)
                {
                    ePaperID = dt.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("新增電子報表發生錯誤," + ex.Message);
            }

            return ePaperID;
        }

        /// <summary>
        /// 新增電子報表項目
        /// </summary>
        /// <param name="ref_epaper_id"></param>
        /// <param name="format"></param>
        /// <param name="content"></param>
        /// <param name="metadata"></param>
        /// <param name="viewer_id"></param>
        public static void AddPaperItem(string ref_epaper_id, string format, string content, string metadata, string viewer_id)
        {
            try
            {
                string sqlStr = $"INSERT INTO paper_item(ref_epaper_id,format,content,metadata,viewer_id) VALUES({ref_epaper_id},'{format}','{content}','{metadata}',{viewer_id}) RETURNING id;";

                qh.Select(sqlStr);
            }
            catch (Exception ex)
            {
                throw new Exception("新增電子報表項目發生錯誤," + ex.Message);
            }
        }

        /// <summary>
        /// 是否有符合
        /// Prefix{xxxxx}之字串
        /// </summary>
        /// <param name="Text">待檢查字串</param>
        public static string MatchText(string Text, string RegexName)
        {
            //可輸入0~9 a~z A~Z
            //Regex rx = new Regex(@"學號\{([0-9a-zA-Z]+)\}"); @"系統編號\{([0-9a-zA-Z]+)\}"
            string RegexFormat = RegexName + @"\{([0-9a-zA-Z]+)\}";
            Regex rx = new Regex(RegexFormat);

            Match ch = rx.Match(Text);
            if (ch.Success)
            {
                Group g = ch.Groups[1];
                return g.Value;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 是否有符合
        /// Prefix{xxxxx}之字串
        /// </summary>
        /// <param name="Text">待檢查字串</param>
        public static string MatchXlsxText(string Text)
        {
            //可輸入0~9 a~z A~Z
            //Regex rx = new Regex(@"學號\{([0-9a-zA-Z]+)\}"); @"系統編號\{([0-9a-zA-Z]+)\}"
            string RegexFormat = @"\{([0-9a-zA-Z]+)\}";
            Regex rx = new Regex(RegexFormat);

            Match ch = rx.Match(Text);
            if (ch.Success)
            {
                Group g = ch.Groups[1];
                return g.Value;
            }
            else
            {
                return "";
            }
        }

    }
}
