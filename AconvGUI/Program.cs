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

            
            c = new chatCtl();
            testUser test1 = new testUser();
            Task.Run(() => {
                test1.main();
            });
            testUser test2 = new testUser();
            Task.Run(() => {
                test1.main();
            });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
}
