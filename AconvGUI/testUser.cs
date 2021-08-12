using System;
using System.Threading;
using System.Threading.Tasks;

namespace AconvGUI {
    class testUser {

        int id;

        public testUser() {
            Task.Run(() => {
                this.main();
            });
        }

        public void main() {
            chatCtl c = chatCtl.connect(out id, 0);

            c.recvMsg(recv, id);

            for (int i = 0; i < 3; i++) {
                Thread.Sleep(5000);
                string msg = "Send Message :" + i;
                c.sendMsg(id, 0, 0, msg);
                Console.WriteLine("[SEND][" + id + "]" + msg);
            }
            c.disconnect(id);

        }

        public void recv(int rid, int msgType, string str) {
            Console.WriteLine("[RECV][" + id + "]" + str + "(rid=" + rid + ")");
        }
    }
}
