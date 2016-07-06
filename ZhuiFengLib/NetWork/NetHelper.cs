using System.Linq;
using System.Net;

namespace ZhuiFengLib.NetWork
{
    internal class NetHelper
    {
    }

    public static class GetIp
    {
        static GetIp()
        {
            var hostName = Dns.GetHostName(); //本机名
            var addressList = Dns.GetHostAddresses(hostName); //会返回所有地址，包括IPv4和IPv6
            foreach (var ip in addressList.Where(ip => IsValidIpAddess(ip.ToString())))
            {
                _ipaddress = ip;
                _networkSegment = ip.ToString().Split('.')[2];
                return;
            }
        }

        private static IPAddress _ipaddress;
        private static string _networkSegment;
        // private static string _mac = string.Empty;

        /// <summary>
        /// IP地址
        /// </summary>
        public static IPAddress IpAddress => _ipaddress;

        /// <summary>
        /// MAC地址
        /// </summary>
       // public static string Mac => _mac;

        /// <summary>
        /// 网咯段
        /// </summary>
        public static string NetworkSegment => _networkSegment;

        /// <summary>
        /// 是否是办公室IP
        /// </summary>
        public static bool CheckIsOffice => (_networkSegment == "0" || _networkSegment == "1" ? true : false);

        /// <summary>
        /// 验证是否为IP地址
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        private static bool IsValidIpAddess(string ip)
        {
            const string pattern = @"^((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))$";

            return System.Text.RegularExpressions.Regex.IsMatch(ip, pattern);
        }
    }
}