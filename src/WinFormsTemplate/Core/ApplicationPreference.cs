using System;
using Microsoft.Win32;
using System.Windows.Forms;

namespace WinFormsTemplate.Core
{
    internal class ApplicationPreference
    {
        private static string GetBaseKey()
        {
            string sVersion = Application.ProductVersion.Split(' ')[0];

            return @"Software\\" + Application.CompanyName + @"\\" + Application.ProductName + @"\\" + sVersion;
        }

        private static string GetValue(string sName, string sDefault)
        {
            try
            {
                using (RegistryKey regKey = Registry.CurrentUser.OpenSubKey(GetBaseKey()))
                {
                    if (regKey != null)
                    {
                        object oValue = regKey.GetValue(sName);

                        if (oValue != null)
                        {
                            return oValue.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log("ApplicationPreference.GetValue failed for key: " + sName, ex);
            }

            return sDefault;
        }

        private static void SetValue(string sName, string sValue)
        {
            try
            {
                using (RegistryKey regKey = Registry.CurrentUser.CreateSubKey(GetBaseKey()))
                {
                    if (regKey != null)
                    {
                        regKey.SetValue(sName, sValue);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log("ApplicationPreference.SetValue failed for key: " + sName, ex);
            }
        }

        public static string GetString(string sName, string sDefault)
        {
            return GetValue(sName, sDefault);
        }

        public static void SetString(string sName, string sValue)
        {
            SetValue(sName, sValue);
        }

        public static int GetInt(string sName, int iDefault)
        {
            string sValue = GetValue(sName, iDefault.ToString());

            if (int.TryParse(sValue, out int iResult))
            {
                return iResult;
            }

            return iDefault;
        }

        public static void SetInt(string sName, int iValue)
        {
            SetValue(sName, iValue.ToString());
        }
    }
}
