using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace N32WebUi.Helper
{
    /// <summary>
    /// 网站操作上下文
    /// </summary>
    public class OperateContext
    {
        public static N32IBLL.IBllSession bllSession = N32DI.SpringHelper.GetObject<N32IBLL.IBllSession>("BLLSession");
    }
}
