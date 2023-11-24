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

		private Button filePath;

		private TextBox pathText;

		private Button deleteBtn;

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

		private void deleteBtn_Click(object sender, EventArgs e)
		{
			this.progressBar1.Value = 0;
			this.timer1.Enabled = true;
			if (this.pathText.Text != "")
			{
				string text = this.pathText.Text;
				string[] files = Directory.GetFiles(text);
				string[] directories = Directory.GetDirectories(text);
				string[] strArrays = files;
				for (int i = 0; i < (int)strArrays.Length; i++)
				{
					string str = strArrays[i];
					try
					{
						File.Delete(str);
					}
					catch (Exception exception1)
					{
						Exception exception = exception1;
						this.label53.Visible = true;
						this.label53.MaximumSize = new System.Drawing.Size(275, 20);
						this.label53.Text = string.Concat("Dosyalar silindi, Sistemde çalışan dosyalar silinmedi. Dosya Adı : ", str, "Hata : ", exception.Message);
					}
				}
				string[] strArrays1 = directories;
				for (int j = 0; j < (int)strArrays1.Length; j++)
				{
					string str1 = strArrays1[j];
					try
					{
						Directory.Delete(str1, true);
					}
					catch (Exception exception3)
					{
						Exception exception2 = exception3;
						this.label53.Visible = true;
						this.label53.MaximumSize = new System.Drawing.Size(275, 20);
						this.label53.Text = string.Concat("Dosyalar silindi, Sistemde çalışan dosyalar silinmedi. Dosya Adı : ", str1, "Hata : ", exception2.Message);
					}
				}
				MessageBox.Show("İşlem başarılı.", "Recent Files", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				MessageBox.Show("Lütfen dosya yolu seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void filePath_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.ShowDialog();
			this.pathText.Text = folderBrowserDialog.SelectedPath.ToString();
			folderBrowserDialog.SelectedPath.ToString();
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
			if (MessageBox.Show("Dosya yolu el ile değiştirilsin mi? İlk defa çalıştırıyorsanız 'Hayır' seçeneğini işaretleyin.", "Path", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
			{
				this.pathText.ReadOnly = true;
			}
			else
			{
				this.pathText.ReadOnly = false;
			}
			this.label53.Visible = false;
			this.label53.ForeColor = Color.Red;
			this.label1.MaximumSize = new System.Drawing.Size(350, 500);
			this.label1.ForeColor = Color.Green;
			this.label1.Text = "Windows çöp dosyaları; Recent, Temporary Files ve Prefetch olarak adlandırılır. Bu dosyaları silmek bilgisayarınızda yer açma, az da olsa hızlandırma ve bilgisayarınıza önem vermenizi sağlar. Soldaki 'Temp sil' ve 'Recent Sil' butonları ile bilgisayarınızdaki tüm çöp dosyalarını silebilirsiniz.";
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form1));
			this.tempSil = new Button();
			this.label53 = new Label();
			this.openFileDialog1 = new OpenFileDialog();
			this.filePath = new Button();
			this.pathText = new TextBox();
			this.deleteBtn = new Button();
			this.recentDelete = new Button();
			this.label1 = new Label();
			this.progressBar1 = new ProgressBar();
			this.timer1 = new Timer(this.components);
			base.SuspendLayout();
			this.tempSil.Location = new Point(15, 7);
			this.tempSil.Name = "tempSil";
			this.tempSil.Size = new System.Drawing.Size(169, 65);
			this.tempSil.TabIndex = 0;
			this.tempSil.Text = "Temp Sil";
			this.tempSil.UseVisualStyleBackColor = true;
			this.tempSil.Click += new EventHandler(this.tempSil_Click);
			this.label53.AutoSize = true;
			this.label53.Location = new Point(12, 75);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(24, 13);
			this.label53.TabIndex = 1;
			this.label53.Text = "text";
			this.openFileDialog1.FileName = "openFileDialog1";
			this.filePath.Location = new Point(499, 7);
			this.filePath.Name = "filePath";
			this.filePath.Size = new System.Drawing.Size(75, 23);
			this.filePath.TabIndex = 3;
			this.filePath.Text = "Dosya Seç";
			this.filePath.UseVisualStyleBackColor = true;
			this.filePath.Click += new EventHandler(this.filePath_Click);
			this.pathText.BackColor = SystemColors.WindowFrame;
			this.pathText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162);
			this.pathText.ForeColor = Color.Red;
			this.pathText.Location = new Point(205, 7);
			this.pathText.Name = "pathText";
			this.pathText.Size = new System.Drawing.Size(288, 20);
			this.pathText.TabIndex = 4;
			this.deleteBtn.Location = new Point(499, 36);
			this.deleteBtn.Name = "deleteBtn";
			this.deleteBtn.Size = new System.Drawing.Size(75, 23);
			this.deleteBtn.TabIndex = 5;
			this.deleteBtn.Text = "Sil";
			this.deleteBtn.UseVisualStyleBackColor = true;
			this.deleteBtn.Click += new EventHandler(this.deleteBtn_Click);
			this.recentDelete.Location = new Point(15, 91);
			this.recentDelete.Name = "recentDelete";
			this.recentDelete.Size = new System.Drawing.Size(169, 71);
			this.recentDelete.TabIndex = 6;
			this.recentDelete.Text = "Recent Sil";
			this.recentDelete.UseVisualStyleBackColor = true;
			this.recentDelete.Click += new EventHandler(this.recentDelete_Click_1);
			this.label1.AutoSize = true;
			this.label1.Location = new Point(202, 91);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "label1";
			this.progressBar1.Location = new Point(205, 36);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(288, 23);
			this.progressBar1.TabIndex = 8;
			this.timer1.Tick += new EventHandler(this.timer1_Tick);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(588, 167);
			base.Controls.Add(this.progressBar1);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.recentDelete);
			base.Controls.Add(this.deleteBtn);
			base.Controls.Add(this.pathText);
			base.Controls.Add(this.filePath);
			base.Controls.Add(this.label53);
			base.Controls.Add(this.tempSil);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Form1";
			this.Text = "Delete Windows Trash Files and Directories";
			base.Load += new EventHandler(this.Form1_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
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
			MessageBox.Show(string.Concat("Bulunan dosya boyutu :", Form1.BytesToString(ınt64 + ınt641)), "Dosya Boyutu", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
			MessageBox.Show("İşlem başarılı.", "Temporary Files", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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