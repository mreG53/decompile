using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public class Form1 : Form
	{
		private IContainer components = null;

		private Button tempSil;

		private Label label53;

		private OpenFileDialog openFileDialog1;

		private Button recentDelete;

		private Label label1;

		private ProgressBar progressBar1;

		private Timer timer1;

		public Form1()
		{
			this.InitializeComponent();
		}

		public static string BytesToString(long byteCount)
		{
			string[] strArrays = new string[] { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
			long ınt64 = Math.Abs(byteCount);
			int ınt32 = Convert.ToInt32(Math.Floor(Math.Log((double)ınt64, 1024)));
			double num = Math.Round((double)ınt64 / Math.Pow(1024, (double)ınt32), 1);
			double num1 = (double)Math.Sign(ınt64) * num;
			string str = string.Concat(num1.ToString(), strArrays[ınt32]);
			return str;
		}


		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		public static long FolderSizeCalculation(string yol)
		{
			long length = (long)0;
			string[] files = Directory.GetFiles(yol, "*.*", SearchOption.AllDirectories);
			for (int i = 0; i < (int)files.Length; i++)
			{
				length += (new FileInfo(files[i])).Length;
			}
			return length;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.label53.Visible = false;
			this.label53.ForeColor = Color.Red;
			this.label1.MaximumSize = new System.Drawing.Size(350, 500);
			this.label1.ForeColor = Color.Green;
			this.label1.Text = "%0";
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		}

		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tempSil = new System.Windows.Forms.Button();
            this.label53 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.recentDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tempSil
            // 
            this.tempSil.Location = new System.Drawing.Point(40, 7);
            this.tempSil.Name = "tempSil";
            this.tempSil.Size = new System.Drawing.Size(169, 65);
            this.tempSil.TabIndex = 0;
            this.tempSil.Text = "Temp Sil";
            this.tempSil.UseVisualStyleBackColor = true;
            this.tempSil.Click += new System.EventHandler(this.tempSil_Click);
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(1, 197);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(24, 13);
            this.label53.TabIndex = 1;
            this.label53.Text = "text";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // recentDelete
            // 
            this.recentDelete.Location = new System.Drawing.Point(40, 120);
            this.recentDelete.Name = "recentDelete";
            this.recentDelete.Size = new System.Drawing.Size(169, 71);
            this.recentDelete.TabIndex = 6;
            this.recentDelete.Text = "Recent Sil";
            this.recentDelete.UseVisualStyleBackColor = true;
            this.recentDelete.Click += new System.EventHandler(this.recentDelete_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(40, 91);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(169, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 213);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.recentDelete);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.tempSil);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DWTFD";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private void recentDelete_Click_1(object sender, EventArgs e)
		{
			this.progressBar1.Value = 0;
			this.timer1.Enabled = true;
			MessageBox.Show("Son önizleme dosyaları silindi.", "Recent Files", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			Form1.RecentDocsHelpers.ClearAll();
			Form1.RecentDocsHelpers.AddFile("c:\\temp\\sample.json");
		}

		private void tempSil_Click(object sender, EventArgs e)
		{
			this.progressBar1.Value = 0;
			this.timer1.Enabled = true;
			string str = "C:\\Windows\\Temp";
			string tempPath = Path.GetTempPath();
			long ınt64 = Form1.FolderSizeCalculation(str);
			long ınt641 = Form1.FolderSizeCalculation(tempPath);
			
			string[] files = Directory.GetFiles(str);
			string[] directories = Directory.GetDirectories(str);
			string[] strArrays = Directory.GetFiles(tempPath);
			string[] directories1 = Directory.GetDirectories(tempPath);
			string[] strArrays1 = directories;
			for (int i = 0; i < (int)strArrays1.Length; i++)
			{
				string str1 = strArrays1[i];
				try
				{
					Directory.Delete(str1, true);
				}
				catch (Exception exception1)
				{
					Exception exception = exception1;
					this.label53.Visible = true;
					this.label53.MaximumSize = new System.Drawing.Size(275, 20);
					this.label53.Text = string.Concat("Dosyalar silindi, Sistemde çalışan dosyalar silinmedi. Dosya Adı : ", str1, "Hata : ", exception.Message);
				}
			}
			string[] strArrays2 = files;
			for (int j = 0; j < (int)strArrays2.Length; j++)
			{
				string str2 = strArrays2[j];
				try
				{
					File.Delete(str2);
				}
				catch (Exception exception3)
				{
					Exception exception2 = exception3;
					this.label53.Visible = true;
					this.label53.MaximumSize = new System.Drawing.Size(275, 20);
					this.label53.Text = string.Concat("Dosyalar silindi, Sistemde çalışan dosyalar silinmedi. Dosya Adı : ", str2, "Hata : ", exception2.Message);
				}
			}
			string[] strArrays3 = strArrays;
			for (int k = 0; k < (int)strArrays3.Length; k++)
			{
				string str3 = strArrays3[k];
				try
				{
					File.Delete(str3);
				}
				catch (Exception exception5)
				{
					Exception exception4 = exception5;
					this.label53.Visible = true;
					this.label53.MaximumSize = new System.Drawing.Size(275, 20);
					this.label53.Text = string.Concat("Dosyalar silindi, Sistemde çalışan dosyalar silinmedi. Dosya Adı : ", str3, "Hata : ", exception4.Message);
				}
			}
			string[] strArrays4 = directories1;
			for (int l = 0; l < (int)strArrays4.Length; l++)
			{
				string str4 = strArrays4[l];
				try
				{
					Directory.Delete(str4, true);
				}
				catch (Exception exception7)
				{
					Exception exception6 = exception7;
					this.label53.Visible = true;
					this.label53.MaximumSize = new System.Drawing.Size(275, 20);
					this.label53.Text = string.Concat("Dosyalar silindi, Sistemde çalışan dosyalar silinmedi. Dosya Adı : ", str4, "Hata : ", exception6.Message);
				}
			}
			string str5 = "C:\\Windows\\prefetch";
			string[] files1 = Directory.GetFiles(str5);
			string[] directories2 = Directory.GetDirectories(str5);
			string[] strArrays5 = files1;
			for (int m = 0; m < (int)strArrays5.Length; m++)
			{
				string str6 = strArrays5[m];
				try
				{
					File.Delete(str6);
				}
				catch (Exception exception9)
				{
					Exception exception8 = exception9;
					this.label53.Visible = true;
					this.label53.MaximumSize = new System.Drawing.Size(275, 20);
					this.label53.Text = string.Concat("Dosyalar silindi, Sistemde çalışan dosyalar silinmedi. Dosya Adı : ", str6, "Hata : ", exception8.Message);
				}
			}
			string[] strArrays6 = directories2;
			for (int n = 0; n < (int)strArrays6.Length; n++)
			{
				string str7 = strArrays6[n];
				try
				{
					Directory.Delete(str7, true);
				}
				catch (Exception exception11)
				{
					Exception exception10 = exception11;
					this.label53.Visible = true;
					this.label53.MaximumSize = new System.Drawing.Size(275, 20);
					this.label53.Text = string.Concat("Dosyalar silindi, Sistemde çalışan dosyalar silinmedi. Dosya Adı : ", str7, "Hata : ", exception10.Message);
				}
			}
            MessageBox.Show(string.Concat("Bulunan dosya boyutu :", Form1.BytesToString(ınt64 + ınt641)), "Dosya Boyutu", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

		private void timer1_Tick(object sender, EventArgs e)
		{
			this.progressBar1.Increment(20);
			Label label = this.label1;
			int value = this.progressBar1.Value;
			label.Text = string.Concat("%", value.ToString());
			if (this.progressBar1.Value == 100)
			{
				this.timer1.Stop();
			}
		}

		public static class RecentDocsHelpers
		{
			public static void AddFile(string path)
			{
				Form1.RecentDocsHelpers.SHAddToRecentDocs(Form1.RecentDocsHelpers.ShellAddToRecentDocsFlags.PathW, path);
			}

			public static void ClearAll()
			{
				Form1.RecentDocsHelpers.SHAddToRecentDocs(Form1.RecentDocsHelpers.ShellAddToRecentDocsFlags.Pidl, null);
			}

			[DllImport("shell32.dll", CharSet=CharSet.Unicode, ExactSpelling=false)]
			private static extern void SHAddToRecentDocs(Form1.RecentDocsHelpers.ShellAddToRecentDocsFlags flag, string path);

			public enum ShellAddToRecentDocsFlags
			{
				Pidl = 1,
				Path = 2,
				PathW = 3
			}
		}
    }
}