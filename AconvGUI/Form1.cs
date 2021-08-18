using ChatCtl;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace AconvGUI {
    public partial class Form1 : Form {
        int id = -1;
        chatCtl c;

        public Form1() {
            c = chatCtl.connect(out id, 0);
            c.recvMsg(recv, id);
            InitializeComponent();

            listBox1.Items.Add("[" + id + "]" + textBox4.Text);
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            c.sendMsg(id, 0, 0, textBox2.Text);
            textBox1.AppendText("[SEND]" + textBox2.Text + Environment.NewLine);
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Chat AI Library(*.dll)|*.dll";
            if (ofd.ShowDialog() == DialogResult.OK) {
                //DLLを読込
                var asm = Assembly.LoadFrom(ofd.FileName);       // アセンブリの読み込み
                var module = asm.GetModule(System.IO.Path.GetFileName(ofd.FileName));        // アセンブリからモジュールを取得
                string str = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName);
                var User = module.GetType(str + ".User");    // 利用するクラス(or 構造体)を取得

                if (User != null) {
                    // CSharpDll.Personクラスをインスタンス化.
                    // コンストラクタへ引数を渡すことも可能.
                    dynamic test0 = Activator.CreateInstance(User);
                    listBox1.Items.Add("[" + test0.id + "]" + str);
                } else {
                    MessageBox.Show("No data.");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            // 自分自身は削除できない
            if ((listBox1.SelectedIndex > 0) && (listBox1.SelectedIndex < listBox1.Items.Count)) {
                //c.indiDisconnect();
                string[] arrs = listBox1.SelectedItem.ToString().Substring(1).Split(']');
                MessageBox.Show( "Id " + arrs[0] +  " delete.");
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                int numVal = Int32.Parse(arrs[0]);
                c.delete(numVal);
            }
        }

        delegate void delegate1(int rid, int msgType, string str);
        public void recv(int rid, int msgType, string str) {
            Invoke(new delegate1(FormAddMsg), rid, msgType, str);
        }

        public void FormAddMsg(int rid, int msgType, string str) {
            textBox1.AppendText("[RECV][" + rid + "]" + str + Environment.NewLine);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void textBox4_TextChanged(object sender, EventArgs e) {
            listBox1.Items[0] = "[" + id + "]" + textBox4.Text;
        }
    }
}
