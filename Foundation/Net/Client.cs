using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;

namespace Foundation.Net
{
    public class Client
    {
        public enum State
        {
            /// <summary>
            /// 断开连接
            /// </summary>
            Disconnect,
            /// <summary>
            /// 连接中
            /// </summary>
            Connect,
        }
        /// <summary>
        /// 接受数据回调
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="size"></param>
        public delegate void BufferCallback(byte[] buffer, int size);
        /// <summary>
        /// 状态改变回调
        /// </summary>
        /// <param name="state"></param>
        public delegate void StateCallback(State state);
        /// <summary>
        /// 客户端连接
        /// </summary>
        private TcpClient _client;
        /// <summary>
        /// 接收数据回调
        /// </summary>
        private BufferCallback _onReceiveDataCallBack;
        /// <summary>
        /// 状态改变回调
        /// </summary>
        private StateCallback _onStateChangedCallBack;
        // 状态
        private State _status;

        /// <summary>
        /// 读取流大小
        /// </summary>
        public const int ReadBufferSize = 1024;

        public bool IsConnected
        {
            get
            {
                try
                {
                    if (_status == State.Connect)
                    {
                        return _client.Connected;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (SocketException e)
                {
                    return false;
                }
            }
        }

        public BufferCallback ReceiveDataCallback
        {
            get
            {
                return _onReceiveDataCallBack;
            }
            set
            {
                _onReceiveDataCallBack = value;
            }
        }

        public StateCallback StateChangedCallback
        {
            get
            {
                return _onStateChangedCallBack;
            }
            set
            {
                _onStateChangedCallBack = value;
            }
        }

        public State Status
        {
            get
            {
                return _status;
            }
            internal set
            {
                _status = value;
                RunStateChangedCallback(_status);
            }
        }

        public Client()
        {
            _client = new TcpClient();
        }

        private void RunReceiveDataCallback(byte[] buffer, int size)
        {
            if (_onReceiveDataCallBack != null)
            {
                _onReceiveDataCallBack(buffer, size);
            }
        }

        private void RunStateChangedCallback(State state)
        {
            if (_onStateChangedCallBack != null)
            { 
                _onStateChangedCallBack(state);
            }
        }

        public void Connect(string host, int port, int timeOut = 2000)
        {
            try
            {
                _client.ReceiveTimeout = timeOut;
                _client.BeginConnect(host, port, (IAsyncResult result) =>
                {
                    if (result.IsCompleted)
                    {
                        TcpClient client = (TcpClient)result.AsyncState;
                        if (client.Connected)
                        {
                            Status = State.Connect;
                        }
                        else
                        {
                            Status = State.Disconnect;
                        }
                    }
                }, _client);
            }
            catch (SocketException e)
            {
                Status = State.Disconnect;
            }
        }

        public void Disconnect()
        {
            if (!IsConnected)
            {
                return;
            }
            _client.EndConnect(null);
            Status = State.Disconnect;
        }

        public void Send(byte[] buffer)
        {
            try
            {
                if (!IsConnected)
                {
                    return;
                }
                _client.GetStream().BeginWrite(buffer, 0, buffer.Length, null, null);
            }
            catch (SocketException e)
            {
            }
           
        }

        public void Close()
        {
            _client.Close();
        }

        public void Listen()
        {
            Thread thread = new Thread(() =>
            {
                this.Update();
            });
            thread.Start();
        }

        protected void Update()
        {
            byte[] buffer = new byte[ReadBufferSize];
            while (true)
            {
                if (!IsConnected)
                {
                    RunReceiveDataCallback(null, -1);
                    break;
                }

                try
                {
                    int size = _client.GetStream().Read(buffer, 0, buffer.Length);
                    if (size > 0)
                    {
                        RunReceiveDataCallback(buffer, size);
                    }
                }
                catch (SocketException e)
                {
                }                
            }
        }
    }
}
