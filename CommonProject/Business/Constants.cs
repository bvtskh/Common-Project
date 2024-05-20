using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProject.Business
{
    public static class MODULE_LOGIN
    {
        public static string MODULE_CONFIRM_TOKUSAI = "CONFIRM_TOKUSAI";
        public static string MODULE_AOI_CRM = "AOI_CRM";
        public static string MODULE_OQC_QUANLITY = "OQC_QUANLITY";
        public static string MODULE_LINE_PRODUCTION_ADD_MODEL = "LINE_PRODUCTION_ADD_MODEL";
    }

    public static class REGEDIT
    {
        public static string CommonRegeditConfig = @"SOFTWARE\CommonProject\Config";
        public static string LOCK = "";
        public static string PortName = "PortName";
        public static string SignalOK = "SignalOK";
        public static string SignalNG = "SignalNG";
    }
    public static class FTP
    {
        public static string ADDRESS = "172.28.10.17";
        public static string USER = @"VN\U34811";
        public static string PASSWORD = "hoan200794";
    }
    public static class ERROR_ID
    {
        public static int ERROR_GETDATA_NULL = 1;
    }
}
