using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AconvGUI {
    class testUser {

        int id;
        public void main() {
            chatCtl c = chatCtl.connect(out id, 0);
            Console.WriteLine("[DEBUG]connect[" + id + "]");

            c.recvMsg(recv, id);

            for (int i = 0; i < 10; i++) {
                Thread.Sleep(5000);
                c.sendMsg(id, 0, "[SEND]" + i);
                Console.WriteLine("[SEND]" + i);
            }

            c.disconnect(id);

        }

        public void recv(int rid, int msgType, string str) {
            Console.WriteLine("[DEBUG][" + id + "]" + str +"("+ rid +")");
        }
    }
}
