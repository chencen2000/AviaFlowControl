using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AviaFlowControl
{
    public partial class ModelPicker : UserControl
    {
        public ModelPicker()
        {
            InitializeComponent();
        }

        private void ModelPicker_Load(object sender, EventArgs e)
        {
            this.listView1.View = View.LargeIcon;
            this.listView1.LargeImageList = new ImageList();
            this.listView1.LargeImageList.ImageSize = new Size(250, 250);
            this.listView1.LargeImageList.ColorDepth = ColorDepth.Depth32Bit;
            //Task.Run(() => 
            //{
            //    test();
            //});
            test_1();
        }
        void test_1()
        {
            List<Dictionary<string, object>> models = null;
            try
            {
                string s = System.IO.File.ReadAllText("avia_models.json");
                var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
                models = jss.Deserialize<List<Dictionary<string, object>>>(s);
            }
            catch (Exception) { }
            if (models != null)
            {
                string dir = System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "images", "models");
                foreach(var model in models)
                {
                    if (model.ContainsKey("image") && model["image"]!=null)
                    {
                        string s = System.IO.Path.Combine(dir, model["image"].ToString());
                        if (System.IO.File.Exists(s))
                        {
                            Image bp = Bitmap.FromFile(s);
                            this.listView1.LargeImageList.Images.Add(model["image"].ToString(), bp);
                            string gs = $"{model["Brand"]} {model["Model Name"]}";
                            ListViewItem lvi = new ListViewItem($"{gs} {model["Color"]}", model["image"].ToString());
                            ListViewGroup lvg = new ListViewGroup(gs);
                            lvg.Name = gs;
                            if (!listView1.Groups.Contains(lvg))
                                listView1.Groups.Add(lvg);
                            lvi.Group = listView1.Groups[gs];
                            listView1.Items.Add(lvi);
                        }
                    }
                }
            }
        }
        void test()
        {
            //List<ListViewItem> items = new List<ListViewItem>();
#if true
            this.listView1.LargeImageList = new ImageList();
            this.listView1.LargeImageList.ImageSize = new Size(250, 250);
            this.listView1.LargeImageList.ColorDepth = ColorDepth.Depth32Bit;
#else
            this.Invoke(new Action(() => {
                this.listView1.LargeImageList = new ImageList();
                this.listView1.LargeImageList.ImageSize = new Size(250, 250);
                this.listView1.LargeImageList.ColorDepth = ColorDepth.Depth32Bit;
            }));
#endif
            string dir = @"C:\Tools\avia\images\models\Back Images\iPhone";
            int idx = 0;
            foreach (string fn in System.IO.Directory.GetDirectories(dir))
            {
                ListViewGroup lvg = new ListViewGroup(System.IO.Path.GetFileName(fn));
                lvg.Name = System.IO.Path.GetFileName(fn);
                listView1.Groups.Add(lvg);
            }

            foreach (string fn in System.IO.Directory.GetFiles(dir, "*.jpg", System.IO.SearchOption.AllDirectories))
            {
                Image bp = Bitmap.FromFile(fn);
                //bp.Tag = System.IO.Path.GetFileNameWithoutExtension(fn);
#if true
                this.listView1.LargeImageList.Images.Add(bp);
                ListViewItem lvi = new ListViewItem(System.IO.Path.GetFileNameWithoutExtension(fn), idx++);
                lvi.Group = listView1.Groups[System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(fn))];
                listView1.Items.Add(lvi);
#else
                this.Invoke(new Action(() => {
                    this.listView1.LargeImageList.Images.Add(bp);
                    ListViewItem lvi = new ListViewItem(System.IO.Path.GetFileNameWithoutExtension(fn), idx++);
                    lvi.Group = listView1.Groups[System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(fn))];
                    listView1.Items.Add(lvi);
                }));
#endif
            }
            //for(int i=0; i<this.listView1.LargeImageList.Images.Count; i++)
            //{
            //    Image img = listView1.LargeImageList.Images[i];
            //    ListViewItem lvi = new ListViewItem(img.Tag.ToString(), i);
            //    listView1.Items.Add(lvi);
            //}
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListView1_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
