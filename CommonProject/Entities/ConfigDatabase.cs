using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProject.Entities
{
     // Cách gọi
    //SQLHelper.ConnectString(new SMTConfig());
    public abstract class ConfigDatabase
    {
        public string SERVER_NAME = "";
        public string USERNAME_DB = "";
        public string PASSWORD_DB = "";
        public string DATABASE = "";
        public int TIME_OUT = 3;
        public abstract string ConnectString();
    }
    public class UMESConfig : ConfigDatabase
    {
        public UMESConfig()
        {
            SERVER_NAME = "172.28.10.8";
            USERNAME_DB = "sa";
            PASSWORD_DB = "$umcevn123";
            DATABASE = "UMC_MESDB_TEST";
        }

        public override string ConnectString()
        {
            SERVER_NAME = "172.28.10.8";
            USERNAME_DB = "sa";
            PASSWORD_DB = "$umcevn123";
            DATABASE = "UMC_MESDB_TEST";
            return string.Format("Server={0};Database={1};User Id={2};Password = {3}; ;Connection Timeout={4}",
              SERVER_NAME, DATABASE, USERNAME_DB,
              PASSWORD_DB, TIME_OUT);
        }
    }
    public class GAConfig : ConfigDatabase
    {
        public override string ConnectString()
        {
            SERVER_NAME = @"172.28.10.11\UMCVNHR01";
            USERNAME_DB = "sa";
            PASSWORD_DB = "s@1234";
            DATABASE = "GA_UMC";
            return string.Format("Server={0};Database={1};User Id={2};Password = {3}; ;Connection Timeout={4}",
              SERVER_NAME, DATABASE, USERNAME_DB,
              PASSWORD_DB, TIME_OUT);
        }
    }

    public class SMTConfig : ConfigDatabase
    {
        public override string ConnectString()
        {
            SERVER_NAME = @"172.28.10.17";
            USERNAME_DB = "sa";
            PASSWORD_DB = "umc@2019";
            DATABASE = "SMT";
            return string.Format("Server={0};Database={1};User Id={2};Password = {3}; ;Connection Timeout={4}",
              SERVER_NAME, DATABASE, USERNAME_DB,
              PASSWORD_DB, TIME_OUT);
        }
    }
    public class UsapConfig : ConfigDatabase
    {
        public override string ConnectString()
        {
            SERVER_NAME = @"172.28.10.9";
            USERNAME_DB = "sa";
            PASSWORD_DB = "$umcevn123";
            DATABASE = "UMC3000";
            return string.Format("Server={0};Database={1};User Id={2};Password = {3}; ;Connection Timeout={4}",
              SERVER_NAME, DATABASE, USERNAME_DB,
              PASSWORD_DB, TIME_OUT);
        }
    }

    public class DeviceControl : ConfigDatabase
    {
        public override string ConnectString()
        {
            SERVER_NAME = @"172.28.10.17";
            USERNAME_DB = "sa";
            PASSWORD_DB = "umc@2019";
            DATABASE = "DeviceControl";
            return string.Format("Server={0};Database={1};User Id={2};Password = {3}; ;Connection Timeout={4}",
              SERVER_NAME, DATABASE, USERNAME_DB,
              PASSWORD_DB, TIME_OUT);
        }
    }


    public class OvertimeConfig : ConfigDatabase
    {
        public override string ConnectString()
        {
            SERVER_NAME = @"172.28.10.28";
            USERNAME_DB = "sa";
            PASSWORD_DB = "umc@123";
            DATABASE = "Overtime";
            return string.Format("Server={0};Database={1};User Id={2};Password = {3}; ;Connection Timeout={4}",
              SERVER_NAME, DATABASE, USERNAME_DB,
              PASSWORD_DB, TIME_OUT);
        }
    }

    public class KittingConfig : ConfigDatabase
    {
        public override string ConnectString()
        {
            SERVER_NAME = @"172.28.10.28";
            USERNAME_DB = "sa";
            PASSWORD_DB = "umc@123";
            DATABASE = "KittingManagement";
            return string.Format("Server={0};Database={1};User Id={2};Password = {3}; ;Connection Timeout={4}",
              SERVER_NAME, DATABASE, USERNAME_DB,
              PASSWORD_DB, TIME_OUT);
        }
    }

}
