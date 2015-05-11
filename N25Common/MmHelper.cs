using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Memcached.ClientLibrary;

namespace N25Common
{
    public partial class MmHelper
    {
        private readonly MemcachedClient _client;
        public MmHelper()
        {
            // 获取配置文件中的服务器Ip地址群
            string[] ips = System.Configuration.ConfigurationManager.AppSettings["MemcachedServers"].Split(',');
            // 初始化Sock对象池
            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(ips);
            pool.Initialize();
            // 创建客户端连接
            _client = new MemcachedClient();
            _client.EnableCompression = true;   // 使用压缩
        }

        public bool Set(string guid, object value, DateTime expiryTime)
        {
            return _client.Set(guid, value, expiryTime);
        }

        public object Get(string guid)
        {
            return _client.Get(guid);
        }
    }
}
