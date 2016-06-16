using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace P01Socket客户端
{
    class Program
    {
        static void Main(string[] args)
        {
            HeabSocket s = new HeabSocket();
            s.Init("127.0.0.1", "6666");
        }
    }

    public class HeabSocket
    {
        private Socket socketSend;
        private string ip;

        public void Init(string ipStr, string port)
        {
            // 创建负责通信的Socket
            socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse(ipStr);
            IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(port));
            // 获得要远程连接的服务器应用程序的IP地址和端口号
            socketSend.Connect(point);
            //ShowMsg("连接服务器成功!");

            // 处理服务器发送来的数据
            Thread th = new Thread(HandleRecieved);
            th.IsBackground = true;
            th.Start(socketSend);
        }

        /// <summary>
        /// 处理服务器发送来的数据
        /// </summary>
        /// <param name="o"></param>
        void HandleRecieved(object o)
        {
            while (true)
            {
                // 接收服务器发来的数据
                Socket socketSend = o as Socket;
                byte[] byteRec = new byte[1024 * 1024 * 20];
                int count = socketSend.Receive(byteRec);
                if (count == 0)
                {
                    break;
                }
                //string str = Encoding.UTF8.GetString(byteRec, 0, count);    // count 从0开始向后走几个
                //ShowMsg(socketSend.RemoteEndPoint + "(服务器):" + str);

                // 处理文本消息
                //if (byteRec[0] == 0)
                //{
                //    string str = Encoding.UTF8.GetString(byteRec, 1, count - 1);
                //    ShowMsg(socketSend.RemoteEndPoint + "(服务器):" + str);
                //}   // 处理文件传送
                //else if (byteRec[0] == 1)
                //{
                //    SaveFileDialog sfd = new SaveFileDialog();
                //    sfd.Title = "选择要保存的文件位置";
                //    sfd.InitialDirectory = @"C:\Users\daxiong\Desktop";
                //    sfd.Filter = "所有文件|*.*";
                //    sfd.ShowDialog(this);
                //    using (FileStream fsWrite = new FileStream(sfd.FileName, FileMode.CreateNew, FileAccess.Write))
                //    {
                //        fsWrite.Write(byteRec, 1, count - 1);
                //    }
                //    ShowMsg("成功接收来自服务器的文件!");
                //}   // 处理震动消息
                //else if (byteRec[0] == 2)
                //{
                //    for (int i = 0; i < 1000; i++)
                //    {
                //        this.Location = new Point(Location.X + 20, Location.Y + 20);
                //        this.Location = new Point(Location.X - 20, Location.Y - 20);
                //    }
                //}
            }

        }

        void ShowMsg(string str)
        {
            Console.WriteLine(str);
        }

        private void btnSend_Click(string sendStr)
        {
            string msg = sendStr;
            byte[] byteMsg = Encoding.UTF8.GetBytes(msg);
            socketSend.Send(byteMsg);
        }
    }
}
