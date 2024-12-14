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
    class BootItemManage
    {
        public class BootItemItem
        {
            public RegistryKey rootKey;
            public string parentKey;
            public string valName;
            public string application;
        }
        public static RegistryKey[] BOOT_ITEM_ROOT_KEY_ARR = new RegistryKey[]{
            Registry.LocalMachine,
            Registry.CurrentUser,

            Registry.CurrentUser,
            Registry.LocalMachine,
            Registry.LocalMachine,
            Registry.LocalMachine,
            Registry.LocalMachine,

            Registry.LocalMachine,
	        Registry.CurrentUser,
	        Registry.LocalMachine,
	        Registry.CurrentUser,
	        Registry.LocalMachine,
	        Registry.CurrentUser,
	        Registry.LocalMachine,
	        Registry.CurrentUser,
	        Registry.LocalMachine,
	        Registry.CurrentUser,
	        Registry.LocalMachine,
	        Registry.LocalMachine,
        };
        public static string[] BOOT_ITEM_PARENT_KEY_ARR = new string[]{
            "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run",
            "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run",

            "Software\\Microsoft\\Windows NT\\CurrentVersion\\Windows\\Load",
            "SYSTEM\\CurrentControlSet\\Control\\Session Manager\\BootExecute",
            "SYSTEM\\CurrentControlSet\\Control\\Session Manager\\SetupExecute",
            "SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Execute",
            "SYSTEM\\CurrentControlSet\\Control\\Session Manager\\S0InitialCommand",

            "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce",
            "Software\\Microsoft\\Windows\\CurrentVersion\\RunOnce",
            "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon\\Userinit",
            "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\Run",
            "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\Run",
            "Software\\Microsoft\\Windows\\CurrentVersion\\RunServicesOnce",
            "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunServicesOnce",
            "Software\\Microsoft\\Windows\\CurrentVersion\\RunServices",
            "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunServices",
            "Software\\Microsoft\\Windows\\CurrentVersion\\RunOnce\\Setup",
            "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce\\Setup",
            "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnceEx",
        };
        
        public static List<BootItemItem> getAll()
        {
            List<BootItemItem> ret = new List<BootItemItem>();
            for (int i = 0; i < BOOT_ITEM_ROOT_KEY_ARR.Length;i++ ){
                RegistryKey root = BOOT_ITEM_ROOT_KEY_ARR[i];
                
                RegistryKey parent = root.OpenSubKey(BOOT_ITEM_PARENT_KEY_ARR[i], true);
                if (parent == null)
                {
                    continue;
                }
                string[] names = parent.GetValueNames();
                foreach (string name in names)
                {
                    string val = parent.GetValue(name, "") as string;
                    BootItemItem item = new BootItemItem();
                    item.rootKey = root;
                    item.parentKey = BOOT_ITEM_PARENT_KEY_ARR[i];
                    item.valName = name;
                    item.application = val;
                    ret.Add(item);
                }

                parent.Close();
               
            }

                return ret;
        }

        public static RegistryKey getDefaultRoot(){
             RegistryKey root = BOOT_ITEM_ROOT_KEY_ARR[0];
            RegistryKey parent = root.OpenSubKey(BOOT_ITEM_PARENT_KEY_ARR[0],true);
            return parent;
        }
        public static bool add(string name, string val, string args)
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

            RegistryKey root = getDefaultRoot();

           
           root.SetValue(name,val+" "+args,RegistryValueKind.String);
     

            root.Close();
            return true;
        }
        public static bool update(BootItemItem item, string val, string args)
        {
            if (val == null)
            {
                return false;
            }
            if (args == null)
            {
                args = "";
            }

            val = val.Trim();
            args = args.Trim();

            if ( val.Length == 0)
            {
                return false;
            }
            if (val[0] != '\"')
            {
                val = "\"" + val + "\"";
            }

            RegistryKey root = item.rootKey.OpenSubKey(item.parentKey, true);


            root.SetValue(item.valName, val + " " + args, RegistryValueKind.String);


            root.Close();
            return true;
        }
        public static bool empty(BootItemItem item)
        {
            RegistryKey root = item.rootKey.OpenSubKey(item.parentKey, true);

            root.SetValue(item.valName, "", RegistryValueKind.String);

            root.Close();
            return true;
        }
        public static bool del(BootItemItem item)
        {
            RegistryKey root = item.rootKey.OpenSubKey(item.parentKey, true);

            root.DeleteValue(item.valName);

            root.Close();
            return true;
        }
    
    }
}
