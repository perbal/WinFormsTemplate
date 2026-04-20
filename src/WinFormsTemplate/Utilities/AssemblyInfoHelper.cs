using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace WinFormsTemplate.Utilities
{
    internal class AssemblyInfoHelper
    {
        public static string GetCopyright()
        {
            Assembly aAssembly = Assembly.GetExecutingAssembly();

            object[] aAttributes = aAssembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);

            if (aAttributes.Length > 0)
            {
                AssemblyCopyrightAttribute acaAttribute = (AssemblyCopyrightAttribute)aAttributes[0];

                return acaAttribute.Copyright;
            }

            return string.Empty;
        }

        public static string GetMajorDotMinorVersion()
        {
            string sVersion = Application.ProductVersion.Split(' ')[0];
            string[] sSub = sVersion.Split('.');
            string sMinor = "00";

            if (int.TryParse(sSub[1], out int iMinor))
            {
                sMinor = iMinor.ToString("D2");
            }

            return sSub[0] + "." + sMinor;
        }
    }
}
