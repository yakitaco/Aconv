using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AconvGUI {
    static class Program {
        static chatCtl c;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main() {

            testUser test1 = new testUser();
            testUser test2 = new testUser();
            testUser test3 = new testUser();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
}
