using System;
using System.Text;

namespace Heab.WebUI
{
    /// <summary>
    /// 默认: int pageSize = 5, int currentPage = 1
    /// </summary>
    public class Pager
    {
        #region 字段: _totalCount _pageSize _currentPage _redirectTo
        private int _totalCount;   // 总的数据数
        private int _pageSize;     // 页面大小
        private int _currentPage;  // 当前页面
        #endregion
        #region 属性
        /// <summary>
        /// 当前显示页面
        /// </summary>
        public int CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; }
        }

        /// <summary>
        /// 每页条数
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value <= 0 ? 3 : value;    // 如果设定pageSize <= 0, 那么默认改成3; 
            }
        }

        /// <summary>
        /// 总的数据数
        /// </summary>
        public int TotalCount
        {
            get { return _totalCount; }
            set { _totalCount = value; }
        }

        /// <summary>
        /// 总的页面数
        /// </summary>
        public int TotalPages
        {
            get
            {
                return Math.Max((_totalCount + _pageSize - 1) / _pageSize, 1); //总页数 
            }
        }

        /// <summary>
        /// 链接的页面
        /// </summary>
        public string RedirectTo { get; set; }

        /// <summary>
        /// 获取Sql中的范围 - 首
        /// </summary>
        public string BetweenBegin
        {
            get { return ((CurrentPage - 1) * PageSize + 1).ToString(); }
        }
        /// <summary>
        /// 获取Sql中的范围 - 首
        /// </summary>
        public string BetweenEnd
        {
            get { return (CurrentPage * PageSize).ToString(); }
        }

        #endregion
        #region 构造函数
        /// <summary>
        /// 默认: int totalCount, string redirectTo = "#", int pageSize = 5, int currentPage = 1
        /// </summary>
        /// <param name="totalCount"></param>
        /// <param name="pageSize"></param>
        /// <param name="currentPage"></param>
        /// <param name="redirectTo"></param>
        public Pager(int totalCount, int pageSize = 5, int currentPage = 1, string redirectTo = "#")
        {
            this._totalCount = totalCount;
            PageSize = pageSize;
            this._currentPage = currentPage;
            this.RedirectTo = redirectTo;
        }
        #endregion
        #region 获取页面导航字符串
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ShowPageNavigate()
        {
            var output = new StringBuilder();
            if (TotalPages > 1)
            {
                // 处理首页连接是否显示
                if (_currentPage != 1)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex=1&pageSize={1}'>首页</a> ", RedirectTo, _pageSize);
                }
                // 处理上一页的连接
                if (_currentPage > 1)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>上一页</a> ", RedirectTo, _currentPage - 1, _pageSize);
                }
                else
                {
                    // output.Append("<span class='pageLink'>上一页</span>");
                }

                output.Append(" ");
                int currint = 5;
                for (int i = 0; i <= 10; i++)
                {//一共最多显示10个页码，前面5个，后面5个
                    if ((_currentPage + i - currint) >= 1 && (_currentPage + i - currint) <= TotalPages)
                    {
                        if (currint == i)
                        {//当前页处理
                            //output.Append(string.Format("[{0}]", currentPage));
                            output.AppendFormat("<a class='cpb' href='{0}?pageIndex={1}&pageSize={2}'>{3}</a> ", RedirectTo, _currentPage, _pageSize, _currentPage);
                        }
                        else
                        {//一般页处理
                            output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>{3}</a> ", RedirectTo, _currentPage + i - currint, _pageSize, _currentPage + i - currint);
                        }
                    }
                    output.Append(" ");
                }
                if (_currentPage < TotalPages)
                {//处理下一页的链接
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>下一页</a> ", RedirectTo, _currentPage + 1, _pageSize);
                }
                else
                {
                    //output.Append("<span class='pageLink'>下一页</span>");
                }
                output.Append(" ");
                if (_currentPage != TotalPages)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>末页</a> ", RedirectTo, TotalPages, _pageSize);
                }
                output.Append(" ");
            }
            output.AppendFormat("<span>第{0}页 / 共{1}页</span>", _currentPage, TotalPages);//这个统计加不加都行
            return output.ToString();
        }
        #endregion
    }
}