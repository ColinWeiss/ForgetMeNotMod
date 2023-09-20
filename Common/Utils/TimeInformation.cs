using System;
using System.Net;

namespace ForgetMeNot.Common.Utils
{ 

    public class TimeInformation
    {
  
        public static string GetNetDateTime( )
        {
            WebRequest request = null;
            WebResponse response = null;
            WebHeaderCollection headerCollection = null;
            string datetime = string.Empty;
            string result;
            try
            {
                request = WebRequest.Create( "https://www.baidu.com" );
                request.Timeout = 3000;
                request.Credentials = CredentialCache.DefaultCredentials;
                response = request.GetResponse( );
                headerCollection = response.Headers;
                foreach( string h in headerCollection.AllKeys )
                {
                    bool flag = h == "Date";
                    if( flag )
                    {
                        datetime = headerCollection[h];
                    }
                }
                result = datetime;
            }
            catch( Exception )
            {
                throw new Exception( "请检查你的网络, 并且再次加载Mod. ( Check your WLAN please , and reload this Mod. )" );
            }
            finally
            {
                bool flag2 = request != null;
                if( flag2 )
                {
                    request.Abort( );
                }
                bool flag3 = response != null;
                if( flag3 )
                {
                    response.Close( );
                }
                bool flag4 = headerCollection != null;
                if( flag4 )
                {
                    headerCollection.Clear( );
                }
            }
            return result;
        }


        public static DateTime Now;
    }
}
