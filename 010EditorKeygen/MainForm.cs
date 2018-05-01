using System;
using System.Windows.Forms;

namespace _010EditorKeygen
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void GenKey()
		{
			textBox2.Text = Keygen.MakeKey(textBox1.Text, Convert.ToUInt32(numericUpDown1.Value));
		}

		private void button1_Click(object sender, EventArgs e)
		{
			
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			GenKey();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			GenKey();
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			GenKey();
		}
	}
}
