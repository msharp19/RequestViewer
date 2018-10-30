using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RequestResolver
{
    public class RequestUtil
    {

        public static void ResolveIP(HttpRequestBase request)
        {
            var forwardedFor = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            var userIpAddress = String.IsNullOrWhiteSpace(forwardedFor) ?
                request.ServerVariables["REMOTE_ADDR"] : forwardedFor.Split(',').Select(s => s.Trim()).First();
        }

        public static IList<KeyValuePair<string, string>> GetServerVariables(HttpRequestBase request)
        {
            var pairs = new List<KeyValuePair<string, string>>();
            var keys = request.ServerVariables.AllKeys;
            foreach (var key in keys)
            {
                pairs.Add(new KeyValuePair<string, string>(key, request.ServerVariables[key]));
            }
            return pairs;
        }

        public static GeoLocation GetGeoLocation(string strIPAddress)
        {
            IP2Location.IPResult oIPResult = new IP2Location.IPResult();
            IP2Location.Component oIP2Location = new IP2Location.Component();
            try
            {
                if (!string.IsNullOrEmpty(strIPAddress))
                {
                    oIP2Location.IPDatabasePath = @"c:\users\waili\onedrive\documents\visual studio 2015\Projects\RequestViewer\RequestResolver\IP2LOCATION-LITE-DB1.BIN";
                    oIPResult = oIP2Location.IPQuery(strIPAddress);
                    switch (oIPResult.Status.ToString())
                    {
                        case "OK":

                            return new GeoLocation()
                            {
                                City = oIPResult.City,
                                CountryShort = oIPResult.CountryShort,
                                CountryLong = oIPResult.CountryLong,
                                ZipCode = oIPResult.ZipCode,
                                DomainName = oIPResult.DomainName,
                                InternetServiceProvider = oIPResult.InternetServiceProvider,
                                Latitude = oIPResult.Latitude.ToString(),
                                Longitude = oIPResult.Longitude.ToString()
                            };
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                oIPResult = null;
                oIP2Location = null;
            }
            return null;
        }
    }
}
