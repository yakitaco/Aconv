using ChatCtl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AconvAI
{
    public class User
    {

        public int id;

        public User() {
            Task.Run(() => {
                this.main();
            });
        }

        void Main(string[] args) {
            Console.ReadKey();
        }

        public void main() {
            chatCtl c = chatCtl.connect(out id, 0);

            c.recvMsg(recv, id);

            for (int i = 0; i < 999; i++) {
                Thread.Sleep(5000);
                string msg = "ABABAB Send Message :" + i;
                c.sendMsg(id, 0, 0, msg);
                Console.WriteLine("[SEND][" + id + "]" + msg);
                Thread.Sleep(5000);
            }
            c.disconnect(id);

        }

        public void recv(int rid, int msgType, string str) {
            Console.WriteLine("[RECV][" + id + "]" + str + "(rid=" + rid + ")");
        }

    }
}
