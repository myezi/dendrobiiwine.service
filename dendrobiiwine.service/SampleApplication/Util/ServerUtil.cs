using System;
using System.IO;

namespace SampleApplication.Util
{
    public static class ServerUtil
    {
        /// <summary>
        /// 在OWIN环境下获得系统根目录开始的映射本地目录
        /// </summary>
        /// <param name="subpath">可以用/或者\开始的子目录,不支持..;.或者~</param>
        /// <returns></returns>
        public static string MapPath(string subpath)
        {
            var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!string.IsNullOrEmpty(subpath))
            {
                char pathChar = Path.DirectorySeparatorChar;
                var subpath2 = subpath.Trim().Replace('/', pathChar).Replace('\\', pathChar);
                if (subpath2[0] == pathChar) subpath2 = subpath2.Substring(1);
                path += subpath2;
            }
            return path;
        }
    }
}