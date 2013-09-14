using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Data.OracleClient;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MetroUITest
{
    public partial class Form1 : MetroForm
    {
        public static string NewLine = "\r\n";
        public static string TempleteFileDir = "c:/ttt/mmszgwjjmkdmry"; //妈妈说这个文件夹名肯定没人用
        public static Boolean debug = false;
        
        public const string ENV_EXPORT = "export";
        public const string ENV_IMPORT = "import";
        public static string env = ENV_EXPORT;

        public static string DB_SID = "";
        public static string DB_USER = "";
        public static string DB_PASSWORD = "";
        public static string DATA_DIR = "";
        public static string EXPORT_DAYS = "1";

        public static string FTP_IP = "";
        public static string FTP_USER = "";
        public static string FTP_PASSWORD = "";
        public static string FTP_DIR = "";

        static log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Form1()
        {
            InitializeComponent();

            Form1.initData();

            this.progressBar1.Hide();

            this.ftpDirTxt.Text = FTP_DIR;
            this.ftpIpTxt.Text = FTP_IP;
            this.ftpPasswordTxt.Text = FTP_PASSWORD;
            this.ftpUserTxt.Text = FTP_USER;

            this.dbPasswordTxt.Text = DB_PASSWORD;
            this.dbSidTxt.Text = DB_SID;
            this.dbUserTxt.Text = DB_USER;

            if (env.StartsWith(ENV_EXPORT)) //导出环境
            {
                this.importDataBtn.Visible = false;
                
            }
            else 
            {
                this.exportDataBtn.Visible = false;
            }
        }

        public Form1(string[] args)
        {
            InitializeComponent();

            Form1.initData();

            this.progressBar1.Hide();

            this.ftpDirTxt.Text = FTP_DIR;
            this.ftpIpTxt.Text = FTP_IP;
            this.ftpPasswordTxt.Text = FTP_PASSWORD;
            this.ftpUserTxt.Text = FTP_USER;

            this.dbPasswordTxt.Text = DB_PASSWORD;
            this.dbSidTxt.Text = DB_SID;
            this.dbUserTxt.Text = DB_USER;

            if (env.StartsWith(ENV_EXPORT)) //导出环境
            {
                this.importDataBtn.Visible = false;
                this.backgroundExportData(true);
            }
            else
            {
                this.exportDataBtn.Visible = false;
                this.backgroundImportData(true);
            }

            ////////////////////////////////////////////////////////
            this.systemWarnLbl.Visible = true;



        }

        private static void initData()
        {
            env = ConfigUtil.getConfig("env") + ".";
            debug = Boolean.Parse(ConfigUtil.getConfig("debug"));
            if (!debug && Directory.Exists(TempleteFileDir))
            {
                Directory.Delete(TempleteFileDir, true);
            }            
            Directory.CreateDirectory(TempleteFileDir);

            DB_SID = ConfigUtil.getConfig(env + "db.sid");
            DB_USER = ConfigUtil.getConfig(env + "db.user");
            DB_PASSWORD = ConfigUtil.getConfig(env + "db.password");
            DATA_DIR = ConfigUtil.getConfig(env + "data_dir");
            if (!Directory.Exists(DATA_DIR))
            {
                Directory.CreateDirectory(DATA_DIR);
            }
            if (ConfigUtil.getConfig("env").Equals("export"))
            {
                EXPORT_DAYS = ConfigUtil.getConfig(env + "export_days");
            }
            

            FTP_IP = ConfigUtil.getConfig(env + "ftp.ip");
            FTP_USER = ConfigUtil.getConfig(env + "ftp.user");
            FTP_PASSWORD = ConfigUtil.getConfig(env + "ftp.password");
            FTP_DIR = ConfigUtil.getConfig(env + "ftp.dir");
        }
            
        private void button1_Click(object sender, EventArgs e)
        {
            backgroundExportData(false);
        }

        private void backgroundExportData(bool isBackground)
        {
            //添加当前主线程名称“main” 
            //CurrentThread.Name = "MainThread";
            //定义一个变量准备接收子线程返回值 
            int iResult = 0;
            //在线程委托中再定义一个委托在新委托中调用方法void Add(int q)。 
            Thread t = new Thread(new ThreadStart(delegate { iResult = exportData(); }));
            //   t.Name = "NodeThread";
            //开始新线程 
            t.Start();

            this.progressBar1.Show();
            this.exportDataBtn.Text = "请稍等...";
            this.exportDataBtn.Enabled = false;
            
            //设置一个循环来等待子线程结束 
            while (t.ThreadState != System.Threading.ThreadState.Stopped)
            {
                //    this.progressBar1.Value = (new Random(100)).Next(1,99);
                System.Windows.Forms.Application.DoEvents();
                t.Join(10);
            }

            this.exportDataBtn.Text = "导出";
            this.exportDataBtn.Enabled = true;
            this.progressBar1.Hide();

            if (!isBackground)
            {
                MessageBox.Show("导出成功 ！", "提示");
            }
           

            //Thread.CurrentThread.Name = "main";
            //Thread t = new Thread(new ThreadStart(delegate { Add(1000); }));

            //t.Name = "子线程";

            //t.Start();

            //Debug.WriteLine(Thread.CurrentThread.Name);

            if (isBackground)
            {
           //     System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }


        /// <summary>
        /// 获取当前目录
        /// </summary>
        /// <returns></returns>
        public static string getCurrentDir()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        private void createBatScriptBtn_Click(object sender, EventArgs e)
        {
            createScriptFile();
            string zipFileName = DATA_DIR + "/zjs_data_" + DateTime.Now.ToString("yyyy-MM-dd") + ".zip";
            if (File.Exists(zipFileName))
            {
                File.Delete(zipFileName);
            }
            exportDataFile(zipFileName);
        }

        private int exportData()
        {
            createScriptFile();
            string zipFileName = DATA_DIR + "/zjs_data_" + DateTime.Now.ToString("yyyy-MM-dd") + ".zip";
            if (File.Exists(zipFileName))
            {
                File.Delete(zipFileName);
            }
            exportDataFile(zipFileName);

            if (!debug)
            {
                Directory.Delete(TempleteFileDir, true);
            }
            return 1;
        } 

        private void exportDataFile(string zipFileName)
        {
            List<String> tableList = ConfigUtil.getList(env + "table");
            List<string> fileList = new List<string>();
            for (int i = 0, length = tableList.Count; i < length; i++)
            {
                string tableName = tableList[i];
                log.Info("正在导出表 " + tableName + "...");
                string sqlFilePath = getSqlFilePath(tableName);
                string dataFilePath = getDataFilePath(tableName);
                exportDataFile(sqlFilePath,dataFilePath);
                log.Info("已成功导出表 " + tableName + "数据");
                fileList.Add(dataFilePath);
            }
            string fileName = getFileName(zipFileName);
            log.Info("正在创建压缩包" + fileName + "...");
            ZipUtil.ZipFile(fileList, zipFileName);
            log.Info("压缩包" + fileName + "创建完成");
            
            uploadDataFile(zipFileName);
        }

        private void uploadDataFile(string zipFileName)
        {
            string fileName = getFileName(zipFileName);
            log.Info("正在上传数据包" + fileName + "...");
            FTPClient ftpClient = new FTPClient(FTP_IP, FTP_USER, FTP_PASSWORD);
            ftpClient.fileUpload(zipFileName, FTP_DIR, fileName);
            log.Info("上传数据包" + fileName + "完成");
        }

        /// <summary>
        /// 创建导出SQL文件列表
        /// </summary>
        private void createScriptFile()
        {
            List<String> tableList = ConfigUtil.getList(env + "table");
            string table = "";
            string selectInsertSql = "";
            for (int i = 0, length = tableList.Count; i < length; i++)
            {
                table = tableList[i];
                selectInsertSql = Constraint.getInsertSql(table);
                createScriptFile(table, selectInsertSql,EXPORT_DAYS);
            }
        }

       　/// <summary>
       　/// 创建单个文件
       　/// </summary>
       　/// <param name="tableName"></param>
       　/// <param name="selectInsertSql"></param>
        private void createScriptFile(string tableName, string selectInsertSql,string exportDays)
        {
            //创建导出脚本
            string exportBeginDateStr = this.exportBeginDate.Text;
            string exportEndDateStr = this.exportEndDate.Text;
           

            string conditionStr = "  where createtime>=to_date(''exportBeginDate'',''yyyy-MM-dd'')  and createtime< (to_date(''exportEndDate'',''yyyy-MM-dd'')+1) ; ";
            conditionStr = conditionStr.Replace("exportBeginDate", exportBeginDateStr).Replace("exportEndDate", exportEndDateStr);
            if (tableName.Equals("kss"))
            {
                conditionStr = " ;";
            }

            selectInsertSql = selectInsertSql.Replace("exportBeginDate", exportBeginDateStr).Replace("exportEndDate", exportEndDateStr);
            string s1 = selectInsertSql;
            string s2 = "";
            string s3 = "";

            tableName = tableName.ToLower();
            if (tableName.Equals("jbxx") || tableName.Equals("jkqk"))
            {
                int length = selectInsertSql.Length;
                s1 = selectInsertSql.Substring(0, (int)(length / 3));
                s2 = selectInsertSql.Substring((int)(length / 3), (int)(length / 3));
                s3 = selectInsertSql.Substring((int)(length / 3) * 2, length - (int)(length / 3) * 2);
            }

            string script = "set pagesize 0 " + NewLine +
                            "set feedback off  " + NewLine +
                            "set flush off  " + NewLine +
                            "set termout off " + NewLine +
                            "set linesize 32767  " + NewLine +
                            "set serveroutput off " + NewLine +
                            "set heading off  " + NewLine +
                            "select 'delete from " + tableName + conditionStr + "' from dual ;" + NewLine +
                            s1 + NewLine +             
                            s2 + NewLine +
                            s3 + NewLine +
                            "select ' commit;' from dual;";

            string filePath = getSqlFilePath(tableName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
           // File.WriteAllText(filePath, script, Encoding.UTF8); 
            FileUtil.CreateFile(filePath, script);
        }

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="tableName"></param>
        private void exportDataFile(string sqlFilePath, string dataFilePath)
        {
            string processName = "sqlplus.exe";
            string param = " -s " + DB_USER + "/" + DB_PASSWORD + "@" + DB_SID + " < " + sqlFilePath + " > " + dataFilePath;
            executeProcess(processName, param);
        }

        /// <summary>
        /// 执行进程
        /// </summary>
        /// <param name="processName"></param>
        /// <param name="param"></param>
        private void executeProcess(string processName,string param)
        {
            //MessageBox.Show(processName + "  " + param);
            //Process proc;
            //proc = Process.Start(processName, param);
            //proc.Dispose();

            //实例一个process类
            Process process = new Process();
            //设定程序名
            process.StartInfo.FileName = "cmd.exe";
            //关闭Shell的使用
            process.StartInfo.UseShellExecute = false;
            //重新定向标准输入，输入，错误输出
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            //设置cmd窗口不显示
            process.StartInfo.CreateNoWindow = true;
            //开始
            process.Start();
            //输入命令，退出
            process.StandardInput.WriteLine(processName + "  " + param);
            process.StandardInput.WriteLine("exit");
            //获取结果
            string strRst = process.StandardOutput.ReadToEnd();
            if (debug)
            {
                log.Info(strRst);
            }
            //显示结果到RichTextBox
            //this.richTextBox1.Text = strRst;

        }

        /// <summary>
        /// SQL文件路径
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private string getSqlFilePath(string tableName)
        {
            return TempleteFileDir + "/" + tableName + "_templet.sql";
        }

        /// <summary>
        /// 数据文件路径
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private string getDataFilePath(string tableName)
        {
            return TempleteFileDir + "/" + tableName + "_data.sql";
        }

        private void importDataBtn_Click(object sender, EventArgs e)
        {
            backgroundImportData(false);
        }

        private void backgroundImportData(bool isBackground)
        {
            int iResult = 0;
            //在线程委托中再定义一个委托在新委托中调用方法void Add(int q)。 
            Thread t = new Thread(new ThreadStart(delegate { iResult = importData(); }));
            //   t.Name = "NodeThread";
            //开始新线程 
            t.Start();
            if (!isBackground)
            {
                this.progressBar1.Show();
                this.importDataBtn.Text = "请稍等...";
                this.importDataBtn.Enabled = false;
            }

            //设置一个循环来等待子线程结束 
            while (t.ThreadState != System.Threading.ThreadState.Stopped)
            {
                System.Windows.Forms.Application.DoEvents();
                t.Join(10);
            }

            if (!isBackground)
            {
                this.importDataBtn.Text = "导出";
                this.importDataBtn.Enabled = true;
                this.progressBar1.Hide();
                MessageBox.Show("导入成功","提示");
            }

            if (isBackground)
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }

        /// <summary>
        /// 数据导入
        /// 1、FTP下载文件，如果是列表顺序下载
        /// 2、解压缩包
        /// 3、遍历文件，执行导入
        /// 4、删除压缩包
        /// 5、删除FTP文件
        /// 6、重复2操作
        /// </summary>
        private int importData()
        {
            FTPClient ftpClient = new FTPClient(FTP_IP, FTP_USER, FTP_PASSWORD);
            string[] fileList = ftpClient.GetFileList(FTP_DIR);
            string compressFilePath = "";
            foreach (string compressFileName in fileList)
            {
                if (compressFileName.LastIndexOf("zip") == -1)
                {
                    continue;
                }
                compressFilePath = DATA_DIR + "/" + compressFileName;
                if (File.Exists(compressFilePath))
                {
                    File.Delete(compressFilePath);
                }
                bool succ = ftpClient.fileDownload(compressFilePath, FTP_DIR, compressFileName);
                if (!succ)
                {
                    log.Error("数据包" + compressFileName + "下载失败。");
                    continue;
                }

                string zipFileDir = compressFileName.Substring(0, compressFileName.IndexOf("."));
                string decompressDir = DATA_DIR + "/" + zipFileDir;
                if (Directory.Exists(decompressDir))
                {
                    Directory.Delete(decompressDir, true);
                }
                log.Info("正在解压缩数据包" + decompressDir);
                ZipUtil.UnzipFile(compressFilePath, decompressDir);

                //依次导入文件包
                string[] dataFileList = Directory.GetFiles(decompressDir);
                foreach (string dataFile in dataFileList)
                {
                    execSQLFile(dataFile);
                }
                //删除解压缩的文件夹
                if (Directory.Exists(decompressDir))
                {
                    Directory.Delete(decompressDir, true);
                    log.Info("本地数据包解压缩目录删除成功（" + compressFileName + ")");
                }
                //删除压缩包
                if (File.Exists(compressFilePath))
                {
                    File.Delete(compressFilePath);
                    log.Info("本地下载的数据包删除成功（" + compressFileName + ")");
                }
                //删除FTP上的压缩包
                ftpClient.fileDelete(FTP_DIR, compressFileName);
                log.Info("FTP压缩包删除成功（" + compressFileName + ")");
            }
            return 1;
        }

        private static void execSQLFile(string filePath)
        {
            // 读取文件的源路径及其读取流
             StreamReader srReadFile = new StreamReader(filePath, System.Text.Encoding.Default);
            string sql = "";
            bool isComplete = false;
            DBUtil dbUtil = new DBUtil(DB_SID, DB_USER, DB_PASSWORD);
            try
            {
                dbUtil.Open();
                OracleConnection con = dbUtil.getConnection();
                // 读取流直至文件末尾结束
                while (!srReadFile.EndOfStream)
                {
                    string strReadLine = srReadFile.ReadLine().Trim(); //读取每行数据
                    if (strReadLine.Equals(string.Empty))
                    {
                        continue;
                    }
                    if (strReadLine.StartsWith("insert") || strReadLine.StartsWith("delete") || strReadLine.StartsWith("update"))
                    {
                        if (!sql.Trim().Equals(""))
                        {
                            sql = sql.EndsWith(";") ? sql.Substring(0, sql.LastIndexOf(";")) : sql;
                         //   log.Info("SQL:" + sql);
                            dbUtil.ExecuteSql(con, sql);
                        }
                        sql = strReadLine;
                    }
                    else if (strReadLine.Equals("commit;"))
                    {
                        continue;
                    }
                    else
                    {
                        sql += strReadLine;
                    }

                    Console.WriteLine(strReadLine); //屏幕打印每行数据
                }
                if (!sql.Trim().Equals(""))
                {
                    sql = sql.EndsWith(";") ? sql.Substring(0, sql.LastIndexOf(";")) : sql;
               //     log.Info("SQL:" + sql);
                    dbUtil.ExecuteSql(con, sql);
                }
                
            }
            catch (Exception ex)
            {
                log.Error("数据库执行失败" + ex.Message);
            }
            finally
            {
                dbUtil.Close();
            }
            
            // 关闭读取流文件
            srReadFile.Close();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //string exportBeginDateStr = this.exportBeginDate.Text;
            //string exportEndDateStr = this.exportEndDate.Text;


            //string conditionStr = "  where createtime>=to_date('exportBeginDate','yyyy-MM-dd')  and createtime< (to_date('exportEndDate','yyyy-MM-dd')+1) ; ";

            //conditionStr = conditionStr.Replace("exportBeginDate", exportBeginDateStr).Replace("exportEndDate", exportEndDateStr);

            //string str = "11111422223e333";

            //int length = str.Length;
            //string s1 = str.Substring(0, (int)(length / 3));
            //string s2 = str.Substring((int)(length / 3), (int)(length / 3));
            //string s3 = str.Substring((int)(length / 3) * 2, length - (int)(length / 3)*2);
            //MessageBox.Show(s1+"  " + s2 +"  "+ s3);

       //     string str = "d:/abc/xx/mm.txt";
           // MessageBox.Show(getFileName(str));

         //   getFtpFileList();
         //   testFTP();


            DBUtil dbUtil = new DBUtil(DB_SID, DB_USER, DB_PASSWORD);
            try
            {
                MessageBox.Show(DB_SID + "   " + DB_USER + "   " + DB_PASSWORD);
                dbUtil.GetRecordCount("select * from jbxx");
                MessageBox.Show("数据库执行成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库执行失败" + ex.Message);
            }

        }

        private static void testFTP()
        {
            FTPClient ftpClient = new FTPClient(FTP_IP, FTP_USER, FTP_PASSWORD);
            ftpClient.fileUpload("D:/ttt/zjs_data_2013-09-04.zip", FTP_DIR, "zjs_data_2013-09-04.zip");
        }

        private static void getFtpFileList()
        {
            FTPClient ftpClient = new FTPClient(FTP_IP, FTP_USER, FTP_PASSWORD);
            string[] fileList = ftpClient.GetFileList(FTP_DIR);
            string filePath = "";
            foreach(string fileName in fileList)
            {
                if (fileName.LastIndexOf("zip") == -1) 
                {
                    continue;
                }
                filePath = DATA_DIR + "/" + fileName;
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                bool succ = ftpClient.fileDownload(filePath, FTP_DIR, fileName);
                if (!succ)
                {
                    log.Error("数据包" + fileName + "下载失败。");
                    continue;
                }
                ZipUtil.UnzipFile(filePath, DATA_DIR);
            }
        }

        private static string getFileName(string filePath)
        {
            string[] fileArray = filePath.Split('/');
            return fileArray[fileArray.Length - 1];
        }

        private static bool uploadToFTP(string localFile,string ftpFileName)
        {
            FTPClient ftpClient = new FTPClient(FTP_IP,FTP_USER,FTP_PASSWORD);
            return ftpClient.fileUpload(new FileInfo(localFile),FTP_DIR,ftpFileName);
        }

        private void configTestBtn_Click(object sender, EventArgs e)
        {
            configTest(true);
        }

        /// <summary>
        /// 配置检测
        /// </summary>
        /// <param name="isWarn"></param>
        private void configTest(bool isWarn)
        {
            try
            {
                log.Info("测试数据库配置是否正确。");
                DBUtil dbUtil = new DBUtil(DB_SID, DB_USER, DB_PASSWORD);
                dbUtil.ExecuteSql("select * from dual");
                log.Info("数据库配置正确。");

                log.Info("测试FTP是否配置正确");
                FTPClient ftpClient = new FTPClient(FTP_IP, FTP_USER, FTP_PASSWORD);
                string testFile = "log4net.dll";
                log.Info("测试FTP上传是否可用");
                bool succ = ftpClient.fileUpload(testFile, FTP_DIR, testFile);
                if (succ)
                {
                    log.Info("测试FTP上传可用");
                }
                else
                {
                    log.Info("测试FTP上传不可用");
                    MessageBox.Show("FTP文件上传文件无权限");
                }

                log.Info("测试FTP删除是否可用");
                succ = ftpClient.fileDelete(FTP_DIR, testFile);
                if (succ)
                {
                    log.Info("测试FTP文件删除可用");
                }
                else
                {
                    log.Info("测试FTP文件删除不可用");
                    MessageBox.Show("FTP删除无权限");
                }
                log.Info("自检完毕，一切都配置OK！");
                if (isWarn)
                {
                    MessageBox.Show("自检完毕，一切都配置OK！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("自检失败：" + ex.Message);
                log.Error("自检失败：" + ex.Message);
            }
        }
    }
}
