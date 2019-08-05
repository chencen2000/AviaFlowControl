using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AviaFlowControl
{
    class OEControl
    {
        static TcpClient client = null;
        static NetworkStream ns = null;
        public OEControl(IPAddress ip=null, int port=6290)
        {
            client = new TcpClient();
            IPAddress sip = ip == null ? IPAddress.Loopback : ip;
            client.Connect(sip, port);
            ns = client.GetStream();
        }
        public static bool connect(int port=6290, IPAddress ip = null)
        {
            bool ret = false;
            Program.logIt("[OEControl]: connect: ++");
            try
            {
                client = new TcpClient();
                client.Connect(ip == null ? IPAddress.Loopback : ip, port);
                ns = client.GetStream();
                ret = true;
            }
            catch (Exception ex)
            {
                Program.logIt($"[OEControl]: connect: {ex.Message}");
            }
            Program.logIt($"[OEControl]: connect: -- ret={ret}");
            return ret;
        }
        public static void disconnect()
        {
            Program.logIt("[OEControl]: disconnect: ++");
            if (client != null && ns!=null)
            {
                try
                {
                    ns.Close();
                    client.Close();
                }
                catch (Exception) { }
                finally
                {
                    ns = null;
                    client = null;
                }
            }
            Program.logIt("[OEControl]: disconnect: --");
        }
        public static bool start()
        {
            bool ret = false;
            Program.logIt("[OEControl]: start: ++");
            if (client != null && ns != null && client.Connected)
            {
                try
                {
                    string cmd = "Start\n";
                    byte[] data = System.Text.Encoding.UTF8.GetBytes(cmd);
                    ns.Write(data, 0, data.Length);
                    data = new byte[1024];
                    int read = ns.Read(data, 0, data.Length);
                    string res = System.Text.Encoding.UTF8.GetString(data, 0, read);
                    Program.logIt($"[OEControl]: start: response: {res}");
                    // str should be "ACK Start"
                    if (string.Compare(res, $"ACK {cmd}", true) == 0)
                        ret = true;
                }
                catch (Exception ex)
                {
                    Program.logIt($"[OEControl]: start: {ex.Message}");
                }
            }
            Program.logIt($"[OEControl]: start: -- ret={ret}");
            return ret;
        }
        public static bool stop()
        {
            bool ret = false;
            Program.logIt("[OEControl]: stop: ++");
            if (client != null && ns != null && client.Connected)
            {
                try
                {
                    string cmd = "Stop\n";
                    byte[] data = System.Text.Encoding.UTF8.GetBytes(cmd);
                    ns.Write(data, 0, data.Length);
                    data = new byte[1024];
                    int read = ns.Read(data, 0, data.Length);
                    string res = System.Text.Encoding.UTF8.GetString(data, 0, read);
                    Program.logIt($"[OEControl]: stop: response: {res}");
                    // str should be "ACK Start"
                    if (string.Compare(res, $"ACK {cmd}", true) == 0)
                        ret = true;
                }
                catch (Exception ex)
                {
                    Program.logIt($"[OEControl]: stop: {ex.Message}");
                }
            }
            Program.logIt($"[OEControl]: stop: -- ret={ret}");
            return ret;
        }
        public static bool load()
        {
            bool ret = false;
            Program.logIt("[OEControl]: load: ++");
            // load will return after the phone has been inplace
            if (client != null && ns != null && client.Connected)
            {
                try
                {
                    string cmd = "Load\n";
                    byte[] data = System.Text.Encoding.UTF8.GetBytes(cmd);
                    ns.Write(data, 0, data.Length);
                    data = new byte[1024];
                    int read = ns.Read(data, 0, data.Length);
                    string res = System.Text.Encoding.UTF8.GetString(data, 0, read);
                    Program.logIt($"[OEControl]: load: response: {res}");
                    // str should be "ACK Start"
                    if (string.Compare(res, $"ACK {cmd}", true) == 0)
                        ret = true;
                }
                catch (Exception ex)
                {
                    Program.logIt($"[OEControl]: load: {ex.Message}");
                }
            }
            Program.logIt($"[OEControl]: load: -- ret={ret}");
            return ret;
        }
        public static bool unload()
        {
            bool ret = false;
            Program.logIt("[OEControl]: unload: ++");
            if (client != null && ns != null && client.Connected)
            {
                try
                {
                    string cmd = "Unload\n";
                    byte[] data = System.Text.Encoding.UTF8.GetBytes(cmd);
                    ns.Write(data, 0, data.Length);
                    data = new byte[1024];
                    int read = ns.Read(data, 0, data.Length);
                    string res = System.Text.Encoding.UTF8.GetString(data, 0, read);
                    Program.logIt($"[OEControl]: unload: response: {res}");
                    // str should be "ACK Start"
                    if (string.Compare(res, $"ACK {cmd}", true) == 0)
                        ret = true;
                }
                catch (Exception ex)
                {
                    Program.logIt($"[OEControl]: unload: {ex.Message}");
                }
            }
            Program.logIt($"[OEControl]: unload: -- ret={ret}");
            return ret;
        }
        public static bool scan()
        {
            bool ret = false;
            Program.logIt("[OEControl]: scan: ++");
            if (client != null && ns != null && client.Connected)
            {
                try
                {
                    string cmd = "Scan\n";
                    byte[] data = System.Text.Encoding.UTF8.GetBytes(cmd);
                    ns.Write(data, 0, data.Length);
                    data = new byte[1024];
                    int read = ns.Read(data, 0, data.Length);
                    string res = System.Text.Encoding.UTF8.GetString(data, 0, read);
                    Program.logIt($"[OEControl]: scan: response: {res}");
                    // str should be "ACK Start"
                    if (string.Compare(res, $"ACK {cmd}", true) == 0)
                        ret = true;
                }
                catch (Exception ex)
                {
                    Program.logIt($"[OEControl]: scan: {ex.Message}");
                }
            }
            Program.logIt($"[OEControl]: scan: -- ret={ret}");
            return ret;
        }
    }
}
