using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace N34NLog日志框架
{
	class Log4NetTest
	{
		private static ILog _logger = LogManager.GetLogger(typeof (Log4NetTest));
		public static void Main()
		{
			var path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "log4net.config");
			log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(path));

			_logger.Debug("我是测试 - Debug");
			try
			{
				Chu(0);
			}
			catch (Exception ex)
			{
				_logger.Error("出现了异常!", new Exception("不能除0啊", ex));
			}
		}

		private static void Chu(int i)
		{
			Console.WriteLine(1 / i);
		}
	}
}
