using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AconvGUI {
    static class Program {

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main() {


                var asm = Assembly.LoadFrom("AconvAI.dll");       // アセンブリの読み込み
                var module = asm.GetModule("AconvAI.dll");        // アセンブリからモジュールを取得
                var User = module.GetType("AconvAI.User");    // 利用するクラス(or 構造体)を取得

                if (User != null) {
                    // CSharpDll.Personクラスをインスタンス化.
                    // コンストラクタへ引数を渡すことも可能.
                    dynamic test0 = Activator.CreateInstance(User);
                }


            testUser test1 = new testUser();
            testUser test2 = new testUser();
            testUser test3 = new testUser();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
}
