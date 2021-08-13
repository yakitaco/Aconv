using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatCtl
{
    public class chatCtl
    {
        public delegate void TimeEventHandler(object sender, string e);

        static List<Action<int, int, string>> cbList = new List<Action<int, int, string>>();
        static chatCtl instance = new chatCtl();

        static int id = 0;

        public static chatCtl connect(out int _tid, int gid) {
            cbList.Add(null);
            _tid = id++;
            return instance;
        }

        public void disconnect(int _tid) {
            cbList[_tid] = null;
        }

        public void sendMsg(int _tid, int _mtype, int _mid, string msg) {
            for (int i = 0; i < cbList.Count; i++) {
                if ((i != _tid) && (cbList[i] != null)) {
                    cbList[i](_tid, _mtype, msg);
                }
            }
        }

        public void recvMsg(Action<int, int, string> callback, int _tid) {
            cbList[_tid] = callback;
        }
    }
}
