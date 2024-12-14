using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading.Tasks;

namespace 文件分析仪
{
    class FileSplitJoinUtil
    {
        public static string META_HEAD = ".msfp";

        public static string FILE_PUBLIC_TAIL = ".sfp";
        public static bool splitFile(string file, string savePath, long splitSize)
        {
            FileInfo pfile = new FileInfo(file);
            if (!pfile.Exists)
            {
                return false;
            }
            if (splitSize <= 0)
            {
                return false;
            }
            if (pfile.Length < splitSize)
            {
                return false;
            }
            DirectoryInfo pdir = new DirectoryInfo(savePath);
            if (!pdir.Exists)
            {
                pdir.Create();
            }
            return splitFileProxy(pfile, pdir, splitSize);
        }
        private static bool splitFileProxy(FileInfo file,DirectoryInfo saveDir,long splitSize){
            FileStream fis = new FileStream(file.FullName, FileMode.Open);
            int bt = -1;
            int splitFileIndex = 0;
            long cpSize = 0;
            bool createNewFile = false;
            FileStream fos = null;
            List<string> saveFiles = new List<String>();
            while ((bt = fis.ReadByte()) != -1)
            {
                if (cpSize == 0)
                {
                    createNewFile = true;
                }
                if (createNewFile)
                {
                    string fileName=file.Name + FILE_PUBLIC_TAIL + splitFileIndex;
                    string pfile = saveDir.FullName + "\\" + fileName;
                    splitFileIndex++;
                    saveFiles.Add(fileName);
                    if (fos != null)
                    {
                        fos.Close();
                    }
                    fos = new FileStream(pfile, FileMode.Create);
                    createNewFile = false;
                }

                fos.WriteByte((byte)bt);

                cpSize = (cpSize + 1) % splitSize;
            }
            if (fos != null)
            {
                fos.Close();
            }
            fis.Close();

            string metaFileName=saveDir.FullName+"\\"+file.Name+".msfp";
            FileStream fmos=new FileStream(metaFileName,FileMode.Create);
            StreamWriter writer = new StreamWriter(fmos,Encoding.UTF8);
            writer.WriteLine(META_HEAD);
            writer.WriteLine("src:" + file.Name);
            writer.WriteLine("count:" + saveFiles.Count);
            foreach (string fileName in saveFiles)
            {
                writer.WriteLine(fileName);
            }
            writer.Close();
            fmos.Close();
            return true;
        }

        public static bool joinFileRecognize(string file, string savePath)
        {
            FileInfo pfile = new FileInfo(file);
            if (!pfile.Exists)
            {
                return false;
            }
            string extension=pfile.Extension;
            if (META_HEAD.CompareTo(extension) == 0)
            {
                return joinFile(pfile.FullName,savePath);
            }
            if (extension.StartsWith(FILE_PUBLIC_TAIL))
            {
                string fileName = pfile.Name.Substring(0, pfile.Name.Length - pfile.Extension.Length) + META_HEAD;
                string metaFileName = pfile.Directory.FullName + "\\" + fileName;
                return joinFile(metaFileName, savePath);
            }
            return joinFile(pfile.FullName, savePath);
        }
        public static bool joinFile(string msfpFile, string savePath)
        {
            FileInfo file = new FileInfo(msfpFile);
            if (!file.Exists)
            {
                return false;
            }
            FileStream fmis = new FileStream(file.FullName, FileMode.Open);
            StreamReader reader = new StreamReader(fmis,Encoding.UTF8);
            string head=reader.ReadLine();
            if (META_HEAD.CompareTo(head) != 0)
            {
                return false;
            }
            string srcFileNameLine = reader.ReadLine();
            string[] srcVals = srcFileNameLine.Split(new string[] { ":" }, 2, StringSplitOptions.RemoveEmptyEntries);
            if (srcVals.Length < 2)
            {
                return false;
            }
            string srcFileName = srcVals[1];
            if (srcFileName.Length == 0)
            {
                return false;
            }

            string countLine = reader.ReadLine();
            string[] vals=countLine.Split(new string[] { ":" }, 2, StringSplitOptions.RemoveEmptyEntries);
            if (vals.Length < 2)
            {
                return false;
            }
            string countVal = vals[1];
            if (!Regex.IsMatch(countVal, "\\d+"))
            {
                return false;
            }
            int count = int.Parse(countVal);
            if (count <= 0)
            {
                return false;
            }
            List<string> splitFiles = new List<string>();
            for (int i = 0; i < count; i++)
            {
                string line=reader.ReadLine();
                string pfileName = file.Directory.FullName + "\\" + line;
                splitFiles.Add(pfileName);
            }

            reader.Close();
            fmis.Close();

            DirectoryInfo pdir=new DirectoryInfo(savePath);

            if (!pdir.Exists)
            {
                pdir.Create();
            }

            return joinFileProxy(srcFileName,splitFiles, pdir);
        }

        private static bool joinFileProxy(string srcFileName,List<string> splitFiles, DirectoryInfo saveDir)
        {
            string saveFileName=saveDir.FullName+"\\"+srcFileName;
            FileStream fos = new FileStream(saveFileName, FileMode.Create);
            foreach (string pfile in splitFiles)
            {
                FileStream fis = new FileStream(pfile, FileMode.Open);
                int bt = -1;
                while ((bt = fis.ReadByte()) != -1)
                {
                    fos.WriteByte((byte)bt);
                }
                fis.Close();
            }
            fos.Close();
            return true;
        }
    }
}
