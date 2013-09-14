using System;
using System.Collections.Generic;
using System.Text;
using Ionic.Zip;

namespace MetroUITest
{
    class ZipUtil
    {
        /// <summary>
        /// 压缩文件列表
        /// </summary>
        /// <param name="fileList">文件列表</param>
        /// <param name="zipFileName">压缩包名称</param>
        public static void ZipFile(List<string> fileList,string zipFileName)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AddFiles(fileList,@"\");
                zip.Save(zipFileName);
            }
        }

        /// <summary>
        /// 压缩单个文件
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="zipFileName">压缩包名称</param>
        public static void ZipFile(string fileName,string zipFileName)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AddFile(fileName);
                zip.Save(zipFileName);
            }
        }

        /// <summary>
        /// 解压缩包
        /// </summary>
        /// <param name="fileName">压缩包名称</param>
        /// <param name="outDir">解压缩路径</param>
        public static void UnzipFile(string fileName,string outDir)
        {
            using (ZipFile zip = new ZipFile(fileName))
            {
                zip.ExtractAll(outDir, ExtractExistingFileAction.OverwriteSilently);
            }
        }
    }
}
    