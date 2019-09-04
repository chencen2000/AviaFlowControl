using System.IO;
//#r "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.1\System.Web.Extensions.dll"
Directory.SetCurrentDirectory(@"C:\projects\avia\AviaFlowControl\AviaFlowControl");
string s = System.IO.File.ReadAllText("avia_models.json");
var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
var data = jss.Deserialize<List<Dictionary<string, object>>>(s);
Print(data);
var szgroup = data.GroupBy(d => d["Size"]);
foreach(var v in szgroup)
{
    Print(v.Key);
    foreach (var vv in v)
        Print(vv);
}