using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BS.webServer
{
    public class ThreadParameter
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////// Property
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 컨텍스트 - Context

        /// <summary>
        /// 컨텍스트
        /// </summary>
        public HttpListenerContext Context { get; set; }

        #endregion
        #region 스레드 - Thread

        /// <summary>
        /// 스레드
        /// </summary>
        public Thread Thread { get; set; }

        #endregion
    }
}
