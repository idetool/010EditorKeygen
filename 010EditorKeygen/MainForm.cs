using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _010EditorKeygen
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private delegate void VoidMethodDelegate();

		private void GenKey()
		{
			var t = new Task(() =>
			{
				BeginInvoke(new VoidMethodDelegate(() =>
				{
					textBox2.Text = Keygen.MakeKey(textBox1.Text, Convert.ToUInt32(numericUpDown1.Value));
				}));
			});
			t.Start();
		}

		private static void Copy2Clipboard(string str)
		{
			Clipboard.Clear();
			Clipboard.SetDataObject(str,true);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				Copy2Clipboard(textBox2.Text);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			try
			{
				GenKey();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			try
			{
				var textBytes = Encoding.UTF8.GetBytes(textBox1.Text);
				if (textBytes.Length >= 15)
				{
					textBox1.Text = Encoding.UTF8.GetString(textBytes, 0, 14);
					textBox1.SelectionStart = textBox1.Text.Length;
				}
				GenKey();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				GenKey();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
