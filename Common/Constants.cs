using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class Constants
    {
        public static class AppSettings
        {
            public static string FILE_NAME => "appsettings.json";
            public static string ENV => "ENV";

            public static string DB_SECTION => "ConnectionStrings";

            public static string DB_CONNECTION_STRING => "ACSDB";


            public static string JWT_SECTION => "JWT";
            public static string JWT_ISSUER => "issuer";
            public static string JWT_KEY => "key";
            public static string JWT_AUDIENCE => "audience";


        }
    }
}
