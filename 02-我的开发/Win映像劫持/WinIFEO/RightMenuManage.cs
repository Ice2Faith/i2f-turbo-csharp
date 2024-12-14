using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Collections;

using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace WinIFEO
{
    class RightMenuManage
    {
        public class RightMenuItem
        {
            public string parentKey;
            public string keyName;
            public string command;
        }
        public static string RIGHT_MENU_ROOT_REG_KEY = "Directory\\Background\\shell";
        public static RegistryKey getRootKey()
        {
            return Registry.ClassesRoot;
        }
        public static RegistryKey getManageRootKey()
        {
            RegistryKey rk = getRootKey();
            return rk.OpenSubKey(RIGHT_MENU_ROOT_REG_KEY, true);
        }
        public static void closeKey(RegistryKey key)
        {
            key.Close();
        }
        public static List<RightMenuItem> getAll()
        {
            RegistryKey root = getManageRootKey();
            List<RightMenuItem> ret = new List<RightMenuItem>();
            
            string[] subKeys=root.GetSubKeyNames();

            foreach(string subKey in subKeys){
                RightMenuItem item = new RightMenuItem();
                item.parentKey = RIGHT_MENU_ROOT_REG_KEY;
                item.keyName = subKey;

                RegistryKey prk= root.OpenSubKey(subKey);


                try
                {
                    RegistryKey prkCmd = prk.OpenSubKey("command");
                    string prkCmdVal = prkCmd.GetValue("", "") as string;
                    item.command = prkCmdVal;
                    prkCmd.Close();
                }
                catch (Exception)
                {
                    item.command = "";
                }

               
                prk.Close();

                ret.Add(item);
            }

            closeKey(root);
            return ret;
        }

        public static bool add(string name, string val,string args)
        {
            if (name == null || val == null)
            {
                return false;
            }
            if (args == null)
            {
                args = "";
            }
            
            name = name.Trim();
            val = val.Trim();
            args = args.Trim();

            if (name.Length == 0 || val.Length == 0)
            {
                return false;
            }
            if (val[0] != '\"')
            {
                val = "\"" + val + "\"";
            }

            RegistryKey root = getManageRootKey();

            try
            {
                RegistryKey pk = root.CreateSubKey(name);
                pk.SetValue("icon", val + ",0");

                RegistryKey pkCmd=pk.CreateSubKey("command");
                pkCmd.SetValue("", val+" "+args,RegistryValueKind.String);
                pkCmd.Close();
               
                pk.Close();
            }
            catch (Exception)
            {
                return false;
            }

            closeKey(root);
            return true;
        }
        public static bool empty(string name)
        {
            if (name == null)
            {
                return false;
            }
            
            name = name.Trim();
            

            if (name.Length == 0 )
            {
                return false;
            }

            RegistryKey root = getManageRootKey();

            try
            {
                RegistryKey pk = root.CreateSubKey(name);

                RegistryKey pkCmd = pk.CreateSubKey("command");
                pkCmd.SetValue("", "", RegistryValueKind.String);
                pkCmd.Close();

                pk.Close();
            }
            catch (Exception)
            {
                return false;
            }

            closeKey(root);
            return true;
        }
        public static bool del(string name)
        {
            if (name == null)
            {
                return false;
            }

            name = name.Trim();


            if (name.Length == 0)
            {
                return false;
            }

            RegistryKey root = getManageRootKey();

            try
            {
                root.DeleteSubKeyTree(name, false);
            }
            catch (Exception)
            {
                return false;
            }

            closeKey(root);
            return true;
        }
    }
}
