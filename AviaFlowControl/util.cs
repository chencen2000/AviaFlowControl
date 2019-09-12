using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AviaFlowControl
{
    class util
    {
        public static Tuple<bool, string> found_CH340_port()
        {
            bool ret = false;
            string rets = string.Empty;
            Program.logIt("found_CH340_port: ++");
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\CH341SER_A64\Enum");
                if (key != null)
                {
                    object o = key.GetValue("count");
                    if (o != null && o.GetType() == typeof(Int32))
                    {
                        int cnt = (int)o;
                        if (cnt == 1)
                        {
                            o = key.GetValue("0");
                            if (o != null && o.GetType() == typeof(string))
                            {
                                RegistryKey k = Registry.LocalMachine.OpenSubKey($@"SYSTEM\CurrentControlSet\Enum\{o.ToString()}\Device Parameters");
                                if (k != null)
                                {
                                    o = k.GetValue("Portname");
                                    if (o != null && o.GetType() == typeof(string))
                                    {
                                        ret = true;
                                        rets = o.ToString();
                                    }
                                    k.Close();
                                }
                            }
                        }
                        else if (cnt == 0)
                        {
                            Program.logIt($"found_CH340_port: no comport on system");
                        }
                        else
                            Program.logIt($"found_CH340_port: more than one comport on system");
                    }
                    key.Close();
                }
            }
            catch (Exception) { }
            Program.logIt($"found_CH340_port: -- ret={ret} port={rets}");
            return new Tuple<bool, string>(ret, rets);
        }
        public static Tuple<bool, Color> read_color()
        {
            Program.logIt("read_color: ++");
            bool done = false;
            Color c = Color.Empty;
            Tuple<bool, string> comport = found_CH340_port();
            if (comport.Item1)
            {
                Regex regx = new Regex(@"^R: (\d+) G: (\d+) B: (\d+)\s*$");
                SerialPort sp= new SerialPort();
                sp.PortName = comport.Item2;
                sp.BaudRate = 9600;
                sp.Parity = Parity.None;
                sp.DataBits = 8;
                sp.StopBits = StopBits.One;
                sp.ReadTimeout = SerialPort.InfiniteTimeout;
                sp.Open();
                if (sp.IsOpen)
                {
                    sp.DiscardInBuffer();
                    
                    string s = sp.ReadLine();
                    Program.logIt($"first: {s}");
                    //while (string.Compare(s, "Found Sensor\r") != 0)
                    //{
                    //    s = sp.ReadLine();
                    //} 
                    
                    //System.Threading.Thread.Sleep(1000);
                    // led on
                    sp.Write(new byte[] { 0xff }, 0, 1);
                    s = sp.ReadLine();
                    //System.Threading.Thread.Sleep(200);
                    while (sp.IsOpen && !done)
                    {
                        s = sp.ReadLine();
                        Match m = regx.Match(s);
                        if (m.Success)
                        {
                            int r, g, b;
                            if(Int32.TryParse(m.Groups[1].Value, out r) && Int32.TryParse(m.Groups[2].Value, out g) && Int32.TryParse(m.Groups[3].Value, out b))
                            {
                                if (r != 0 && g != 0 && b != 0 && r == c.R && g == c.G && b == c.B)
                                {
                                    done = true;
                                }
                                else
                                {
                                    c = Color.FromArgb(r, g, b);
                                }
                            }
                        }
                    }
                    sp.Write(new byte[] { 0x00 }, 0, 1);
                    //System.Threading.Thread.Sleep(200);
                    s = sp.ReadLine();
                    sp.Close();
                }
            }
            Program.logIt($"read_color: -- ret={done}, color={c}");
            return new Tuple<bool, Color>(done, c);
        }
        public static Tuple<bool, SizeF> get_current_device_size()
        {
            bool ret = false;
            SizeF sz = SizeF.Empty;
            utility.IniFile ini = new utility.IniFile(System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "aviaDevice.ini"));
            string s = ini.GetString("device", "size", "");
            if(!string.IsNullOrEmpty(s))
            {
                string[] xy = s.Split(',');
                if (xy.Length > 1)
                {
                    float x;
                    float y;
                    if(float.TryParse(xy[0], out x) && float.TryParse(xy[1], out y))
                    {
                        ret = true;
                        sz = new SizeF(x, y);
                    }
                }
            }
            return new Tuple<bool, SizeF>(ret, sz);
        }
        public static Tuple<bool, Dictionary<string,SizeF>> get_all_device_size()
        {
            bool ret = false;
            Dictionary<string, SizeF> data = new Dictionary<string, SizeF>();
            utility.IniFile ini = new utility.IniFile(System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "aviaDevice.ini"));
            Dictionary<string, string> models = ini.GetSectionValues("models");
            foreach(KeyValuePair<string,string> kvp in models)
            {
                ret = true;
                string[] xy = kvp.Value.Split(',');
                if (xy.Length > 1)
                {
                    float x;
                    float y;
                    if (float.TryParse(xy[0], out x) && float.TryParse(xy[1], out y))
                    {
                        data.Add(kvp.Key, new SizeF(x,y));
                    }
                }
            }
            return new Tuple<bool, Dictionary<string, SizeF>>(ret, data);
        }
    }
}
