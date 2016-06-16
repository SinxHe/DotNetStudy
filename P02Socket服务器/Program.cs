using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace P02Socket服务器
{
    class Program
    {
        static void Main(string[] args)
        {
            HeabSocket s = new HeabSocket();
            s.Init("6666");
        }
    }

    public class HeabSocket
    {
        public void Init(string port)
        {
            // 在服务器端创建一个负责监听IP地址和端口号的Socket
            Socket socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Any;   // IPAddress.Parse(txtServer.Text)
            // 创建端口号对象
            IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(port));
            // 绑定监听端口
            socketWatch.Bind(point);
            //ShowMsg("监听成功!");
            Console.WriteLine("监听成功!");
            // 设置监听队列: 在同一时刻允许最大的连接量 多出来的排队去
            socketWatch.Listen(10);
            // 等待客户端的连接
            Thread th = new Thread(LoopAccept);
            th.IsBackground = true; // 设置为后台线程
            th.Start(socketWatch);
        }

        // 负责通信的Socket(只是最后一个链接的)
        Socket socketSend;
        // 保存为所有链接过来的客户端创建的Socket
        Dictionary<string, Socket> dicSockets = new Dictionary<string, Socket>();

        /// <summary>
        /// 等待客户端的连接
        /// </summary>
        /// <param name="o"></param>
        private void LoopAccept(object o)
        {
            Socket socketWatch = o as Socket;
            while (true)
            {
                // 等待客户端的连接
                // 创建一个负责通信的Socket
                socketSend = socketWatch.Accept();
                // 存到dicSockets中
                dicSockets.Add(socketSend.RemoteEndPoint.ToString(), socketSend);
                //// 添加到下拉列表中
                //cbUsers.Items.Add(socketSend.RemoteEndPoint.ToString());
                //// 将下拉列表当前选中的更改为新加入的客户端
                //cbUsers.SelectedIndex = cbUsers.Items.Count - 1;

                ShowMsg(socketSend.RemoteEndPoint.ToString() + " : 连接成功");

                // 处理客户端发送过来的数据
                Thread th = new Thread(HandleRecieve);
                th.IsBackground = true;
                th.Start(socketSend);
            }
        }

        /// <summary>
        /// 处理客户端发送过来的数据
        /// </summary>
        /// <param name="o"></param>
        void HandleRecieve(object o)
        {
            while (true)
            {
                Socket socketSend = o as Socket;
                // 接收客户端发来的数据
                byte[] recievedByteStream = new byte[1024 * 1024 * 2];
                int count = socketSend.Receive(recievedByteStream); // 返回的是有效字节数
                if (count == 0)
                {
                    break;
                }
                string recievedString = Encoding.UTF8.GetString(recievedByteStream, 0, count);
                ShowMsg(socketSend.RemoteEndPoint + "(客户端): " + recievedString);
            }
        }

        void ShowMsg(string str)
        {
            //txtLog.AppendText(str + "\r\n");
            Console.WriteLine(str);
        }

        /// <summary>
        /// 给客户端发数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMsg_Click(string strSend)
        {
            // 把字符串转换成字节
            //string str = txtMsg.Text.Trim();
            string str = strSend;
            byte[] buffer = new byte[1024 * 1024 * 2];
            buffer = Encoding.UTF8.GetBytes(str);
            // 创建list用于添加数据首位的"协议"标识0
            List<byte> list = new List<byte>();
            //list.Add(0);    // "协议"中表示消息
            list.AddRange(buffer);
            // 发送给客户端
            //socketSend.Send(byteStr); // 这个是直接发送给最后一个链接的
            socketSend.Send(list.ToArray());
            // 发送给下拉列表中选中的客户端
            //dicSockets[cbUsers.SelectedItem.ToString()].Send(list.ToArray());
        }
    }
}
