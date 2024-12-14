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
    class FileZipUnzipUtil
    {
        public static string FILE_PUBLIC_TAIL = ".zpf";
        public static bool zipFiles(List<string> files, string savePath, string saveFileName)
        {
            DirectoryInfo pdir = new DirectoryInfo(savePath);
            if (!pdir.Exists)
            {
                pdir.Create();
            }
            string saveName = pdir.FullName + "\\" + saveFileName + FILE_PUBLIC_TAIL;
            FileStream fos = new FileStream(saveName, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(fos);
            byte[] headBytes=Encoding.UTF8.GetBytes(FILE_PUBLIC_TAIL);
            writer.Write(headBytes);
            writer.Flush();
            foreach (string pfile in files)
            {
                zipFileInto(pfile, "", fos);
            }
            int endLenTag=-1;
            writer.Write(endLenTag);
            fos.Close();
            return true;
        }
        private static void zipFileInto(string path, string relativePath, FileStream fos)
        {
            FileInfo pfile = new FileInfo(path);
            DirectoryInfo pdir = new DirectoryInfo(path);
            if (!pfile.Exists && !pdir.Exists)
            {
                return;
            }
            if (pfile.Exists)
            {
                FileInfo cFile=new FileInfo(path);
                string sFileName = relativePath + "\\" + cFile.Name;
                if (relativePath.Length==0)
                {
                    sFileName = cFile.Name;
                }
                long sLen = cFile.Length;
                byte[] sNameBytes = Encoding.UTF8.GetBytes(sFileName);
                int sNameLen = sNameBytes.Length;
                FileStream fis = new FileStream(cFile.FullName, FileMode.Open);
                BinaryWriter writer = new BinaryWriter(fos);

                writer.Write(sNameLen);
                writer.Write(sNameBytes);
                writer.Write(sLen);
                writer.Flush();

                int bt=-1;
                while ((bt = fis.ReadByte()) != -1)
                {
                    fos.WriteByte((byte)bt);
                }
                fis.Close();
            }
            if (pdir.Exists)
            {
                DirectoryInfo[] subDirs = pdir.GetDirectories();
                FileInfo[] subFiles = pdir.GetFiles();
                string nextRelativePath=relativePath + "\\" + pdir.Name;
                if (relativePath.Length == 0)
                {
                    nextRelativePath = pdir.Name;
                }
                foreach (FileInfo mf in subFiles)
                {
                    zipFileInto(mf.FullName, nextRelativePath, fos);
                }
                foreach (DirectoryInfo md in subDirs)
                {
                    zipFileInto(md.FullName, nextRelativePath, fos);
                }
            }
            
        }

        public static bool unzipFile(string zipedFile, string savePath)
        {
            FileInfo pfile = new FileInfo(zipedFile);
            if (!pfile.Exists)
            {
                return false;
            }
            FileStream fis = new FileStream(pfile.FullName, FileMode.Open);
            byte[] headBytes = Encoding.UTF8.GetBytes(FILE_PUBLIC_TAIL);
            byte[] rdHeadBytes=new byte[headBytes.Length];
            fis.Read(rdHeadBytes, 0, rdHeadBytes.Length);
            string rdHead = Encoding.UTF8.GetString(rdHeadBytes, 0, rdHeadBytes.Length);
            if (FILE_PUBLIC_TAIL.CompareTo(rdHead)!=0)
            {
                return false;
            }

            DirectoryInfo saveDir=new DirectoryInfo(savePath);
            if(!saveDir.Exists){
                saveDir.Create();
            }

            BinaryReader reader = new BinaryReader(fis);
            int nameLen = -1;
            while ((nameLen = reader.ReadInt32()) != -1)
            {
                byte[] fname=reader.ReadBytes(nameLen);
                string cfileName = Encoding.UTF8.GetString(fname, 0, fname.Length);
                long cfileLen = reader.ReadInt64();
                string saveFileName = saveDir.FullName + "\\" + cfileName;
                FileInfo saveFile = new FileInfo(saveFileName);
                if (!saveFile.Directory.Exists)
                {
                    saveFile.Directory.Create();
                }
                FileStream fos = new FileStream(saveFile.FullName,FileMode.Create);
                long psize = 0;
                while (psize < cfileLen)
                {
                    fos.WriteByte(reader.ReadByte());
                    psize++;
                }
                fos.Close();
            }

            reader.Close();
            fis.Close();
            return true;
        }

       
    }
}
