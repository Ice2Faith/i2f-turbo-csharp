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
    class IFEOManage
    {
        public class IFEOItem
        {
            public string parentKey;
            public string keyName;
            public string debugger;
        }
        public static string IFEO_ROOT_REG_KEY = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options";
        public static RegistryKey getRootKey()
        {
            return Registry.LocalMachine;
        }
        public static RegistryKey getManageRootKey()
        {
            RegistryKey rk = getRootKey();
            return rk.OpenSubKey(IFEO_ROOT_REG_KEY,true);
        }
        public static void closeKey(RegistryKey key)
        {
            key.Close();
        }
        public static List<IFEOItem> getAll()
        {
            RegistryKey root = getManageRootKey();
            List<IFEOItem> ret = new List<IFEOItem>();
            
            string[] subKeys=root.GetSubKeyNames();

            foreach(string subKey in subKeys){
                IFEOItem item = new IFEOItem();
                item.parentKey = IFEO_ROOT_REG_KEY;
                item.keyName = subKey;

                RegistryKey prk= root.OpenSubKey(subKey);
                string prkVal=prk.GetValue("Debugger", "") as string;
                item.debugger = prkVal;

                prk.Close();

                ret.Add(item);
            }

            closeKey(root);
            return ret;
        }
        public static bool add(string name, string val)
        {
            if (name == null || val == null)
            {
                return false;
            }
            name = name.Trim();
            val = val.Trim();
            if (name.Length == 0 || val.Length == 0)
            {
                return false;
            }
            if (!name.EndsWith(".exe", true, null))
            {
                name = name + ".exe";
            }
            if (val[0] != '\"')
            {
                val="\"" + val + "\"";
            }
            if (!val.EndsWith(" /z"))
            {
                val = val+ " /z";
            }
           
            RegistryKey root = getManageRootKey();

            try
            {
                RegistryKey pk = root.CreateSubKey(name);
                pk.SetValue("Debugger", val);
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
            if (!name.EndsWith(".exe", true, null))
            {
                name = name + ".exe";
            }

            RegistryKey root = getManageRootKey();

            try
            {
                RegistryKey pk = root.CreateSubKey(name);
                pk.DeleteValue("Debugger");
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
            if (!name.EndsWith(".exe", true, null))
            {
                name = name + ".exe";
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
