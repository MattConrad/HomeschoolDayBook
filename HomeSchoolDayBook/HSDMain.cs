using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HomeSchoolDayBook
{
    static class HSDMain
    {
        public static string sDBDirectory;      //*has* trailing backslash.  *might* want this for db restore someday, so can't put inside CEDBHandler.
        public static string sDBFileName = "hsd_1_00.sdf";
        public static decimal dDBVersion = 1.00M;
        public static CEDBHandler CEDbH;
        public static SystemSettings SysSettings;
        public static Dictionary<string, DataTable> hashCodeTables;
        public static frmMaster fMaster;
        public static frpSplash fSplash;
        public static ComponentFactory.Krypton.Toolkit.KryptonManager kryMgr;
        
        [STAThread]
        static void Main()
        {
            try
            {
                bool bIsFirstInstance;
                System.Threading.Mutex mutex = new System.Threading.Mutex(false, "Global\\HSDExeMutex", out bIsFirstInstance);

                if (bIsFirstInstance) {
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.EnableVisualStyles();
                    fSplash = new frpSplash();
                    fSplash.Show();
                    fSplash.Refresh();

                    sDBDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)
                        + @"\HomeschoolDayBook\";

                    CEDbH = new CEDBHandler();
                    SysSettings = new SystemSettings();   //must come after CEDbH.
                    StaticMethods.InitCodeTables();
                    StaticMethods.InitPluralization();
                    Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                    fMaster = new frmMaster();         //must come just before app run--too early, lots breaks.
                    Application.Run(fMaster);
                    //note that shutdown events run from frmMaster_FormClosed.
                }
                else {
                    System.Windows.Forms.MessageBox.Show("Cannot run multiple copies of Homeschool Day Book at the same time.", "Invalid Request:");
                }
            }
            catch (Exception x)
            {
                HandleTopException(x);
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            HandleTopException(e.Exception);
        }

        private static void HandleTopException(Exception x)
        {
            try {
                System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
                string sAsmVersion = asm.GetName().Version.ToString();

                //maybe the db is broken, so we need to default-value anything from the db.
                string sLEmail = "LICENSE EMAIL N/A";
                string sLNumber = "LICENSE NUMBER N/A";

                string sErrorMsg = sAsmVersion + "\n\n"
                    + sLEmail + "  " + sLNumber + "\n\n"
                    + Environment.OSVersion.VersionString + "\n\n"
                    + x.ToString();     //x.ToString() includes inner exception info!  doh!
            }
            finally {
                MessageBox.Show("An unexpected error occurred in your application.  Homeschool Day Book will now close.\n\n"
                    + "Please send a message to info@HomeSchoolDayBook.com discussing what you were doing when the error occured.", "Fatal Error:");
                Environment.Exit(1);
            }
        }
    }
}
