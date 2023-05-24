using System.IO;
namespace TextEditor
{
    public partial class Form1 : Form
    {
        bool f_open, f_save;
        private object keyData;
        bool da;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            openFileToolStripMenuItem.Click += new EventHandler(button1_Click);
            saveFileToolStripMenuItem.Click += new EventHandler(button2_Click);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            f_open = false;
            f_save = false;
            label1.Text = "-";
            richTextBox1.Text = "";
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Control & e.KeyCode == Keys.S)
            {
                da = false;
            }
            if (e.Control & e.KeyCode == Keys.O)
            {
                da = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.Text = openFileDialog1.FileName;
                f_open = true;
                f_save = false;
                richTextBox1.Clear();
                StreamReader sr = File.OpenText(openFileDialog1.FileName);
                string line = null;
                line = sr.ReadLine();
                while (line != null)
                {
                    richTextBox1.AppendText(line);
                    richTextBox1.AppendText("\r\n");
                    line = sr.ReadLine();
                }
                sr.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!f_open) return;
            if (f_save) return;
            StreamWriter sw = File.CreateText(openFileDialog1.FileName);
            string line;
            for (int i = 0; i < richTextBox1.Lines.Length; i++)
            {
                line = richTextBox1.Lines[i].ToString();
                sw.WriteLine(line);
            }
            sw.Close();
            MessageBox.Show("Ôàéë ñîõðàíåí");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            f_save = false;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void îòêðûòüÔàéëToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ñîõðàíèòüÔàéëToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}