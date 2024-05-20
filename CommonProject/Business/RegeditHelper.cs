using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProject.Business
{
    public static class RegeditHelper
    {
        public static void WriteRegistry(string path, string keyName, string content)
        {
            var key = Registry.CurrentUser.CreateSubKey(path);
            if (!string.IsNullOrEmpty(keyName))
            {
                key.SetValue(keyName, content);
                key.Close();
            }
        }

        public static string GetValueRegistryKey(string path, string keyName)
        {
            try
            {
                var key = Registry.CurrentUser.CreateSubKey(path);
                string value = null;
                if (key is object)
                {
                    if (key.GetValue(keyName) is object)
                    {
                        value = key.GetValue(keyName).ToString();
                        key.Close();
                        return value;
                    }
                }

                return null;
            }
            catch (Exception)
            {

                return null;
            }

        }

    }
}
