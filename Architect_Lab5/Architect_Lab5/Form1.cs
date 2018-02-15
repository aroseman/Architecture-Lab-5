using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Architect_Lab5
{
    public partial class Form1 : Form
    {
        List<string> lines = new List<string>();
        public Form1()
        {
            InitializeComponent();

            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                comboBox1.Items.Clear();


                using (StreamReader r = new StreamReader(f.OpenFile()))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        comboBox1.Items.Add(line);

                    }
                }
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string fullClassName = "Architect_Lab5." + comboBox1.SelectedItem;
            Type type = Type.GetType(fullClassName);
            Module m = (Module)Activator.CreateInstance(type);
            m.Do();
        }
    }
}
