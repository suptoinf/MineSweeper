using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace MineSweeper
{
	public partial class Form1 : Form
	{
		Mine mine;
		private enum Difficulty
		{
			simple = 0,
			middle = 1,
			difficult = 2
		}

		Difficulty difficulty = Difficulty.simple;

		private List<MyButton> ButtonList = new List<MyButton>();
		private MyButton btns = new MyButton();
		Label TimeSpent = new Label();
		Label MineRemian = new Label();
		PictureBox TimeImage = new PictureBox();
		PictureBox MineImage = new PictureBox();
		//private int RemainingSafe;
		//private int BoomedMine;
		private bool IsFailed;

		private int remainingSafe;
		public int RemainingSafe
		{
			get { return remainingSafe; }
			set
			{
				if (value != remainingSafe)
				{
					remainingSafe = value;
					ChangeValue();
				}
			}
		}

		private int boomedMine;
		public int BoomedMine
		{
			get => boomedMine;
			set
			{
				if (value != boomedMine)
				{
					boomedMine = value;
					ChangeValue();
				}
				boomedMine = value;
			}
		}

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			IsFailed = false;
			mine = new Mine();
			RemainingSafe = mine.Columns * mine.Rows - mine.MineCount;
			BoomedMine = 0;
			AddButton(mine.Rows, mine.Columns);
		}

		private void NewGame_Click(object sender, EventArgs e)
		{
			timer1.Enabled = false;
			switch (difficulty)
			{
				case Difficulty.simple:
					TenMine_Click(sender, e);
					break;
				case Difficulty.middle:
					FortyMine_Click(sender, e);
					break;
				case Difficulty.difficult:
					NinetyNineMine_Click(sender, e);
					break;
			}
		}

		private void TenMine_Click(object sender, EventArgs e)
		{
			timer1.Enabled = false;
			difficulty = Difficulty.simple;
			IsFailed = false;
			mine = new Mine();
			RemainingSafe = mine.Columns * mine.Rows - mine.MineCount;
			BoomedMine = 0;
			RemoveButton();
			AddButton(mine.Rows, mine.Columns);
		}

		private void FortyMine_Click(object sender, EventArgs e)
		{
			timer1.Enabled = false;
			difficulty = Difficulty.middle;
			IsFailed = false;
			mine = new Mine(16, 16, 40);
			RemainingSafe = mine.Columns * mine.Rows - mine.MineCount;
			BoomedMine = 0;
			RemoveButton();
			AddButton(mine.Rows, mine.Columns);
		}

		private void NinetyNineMine_Click(object sender, EventArgs e)
		{
			timer1.Enabled = false;
			difficulty = Difficulty.difficult;
			IsFailed = false;
			mine = new Mine(16, 30, 99);
			RemainingSafe = mine.Columns * mine.Rows - mine.MineCount;
			BoomedMine = 0;
			RemoveButton();
			AddButton(mine.Rows, mine.Columns);
		}

		private void Exit_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void Help_Click(object sender, EventArgs e)
		{
			MessageBox.Show("数字代表周围的雷数，点到雷即为失败，开始你的扫雷之旅吧");
		}

		private void About_Click(object sender, EventArgs e)
		{
			MessageBox.Show("此程序为SuptoInf版权所有");
		}

		private void RemoveButton()
		{
			foreach (Control button in ButtonList)
			{
				if (button is Button)
				{
					Controls.Remove(button);
				}
			}
			ButtonList.Clear();
			Controls.Remove(TimeSpent);
			Controls.Remove(MineRemian);
			Controls.Remove(TimeImage);
			Controls.Remove(MineImage);
		}

		private void AddButton(int rows, int columns)
		{
			for (int i = 0; i < columns * rows; i++)
			{
				btns = new MyButton();
				btns.Name = string.Format("{0}", i);
				btns.Text = "";
				btns.Font = new Font("Calibli", 15F);
				btns.ForeColor = Color.BlueViolet;
				btns.Location = new Point(40 * (i % columns), i / columns * 40 + menuStrip1.Height);
				btns.Size = new Size(40, 40);
				btns.FlatAppearance.BorderColor = Color.White;
				btns.FlatStyle = FlatStyle.Flat;
				btns.BackColor = Color.Gray;
				this.Controls.Add(btns);
				btns.Click += new EventHandler(btns_Click);
				btns.MouseDown += new MouseEventHandler(btns_MouseDown);
				btns.DoubleClick += Btns_DoubleClick;
				btns.TextChanged += Btns_TextChanged;
				ButtonList.Add(btns);
			}
			TimeImage = new PictureBox();
			//TimeImage.Image = Image.FromFile("钟表.png");
			TimeImage.Image = Properties.Resources.钟表;
			TimeImage.Size = new Size(40, 40);
			TimeImage.SizeMode = PictureBoxSizeMode.StretchImage;
			TimeImage.Location = new Point(30, 40 * rows + menuStrip1.Height + 10);
			Controls.Add(TimeImage);

			TimeSpent = new Label();
			TimeSpent.BackColor = Color.Gray;
			TimeSpent.Text = "0";
			TimeSpent.Location = new Point(80, 40 * rows + menuStrip1.Height + 10);
			TimeSpent.Size = new Size(80, 40);
			TimeSpent.Font = new Font("Arial", 20F);
			TimeSpent.ForeColor = Color.White;
			TimeSpent.TextAlign = ContentAlignment.MiddleCenter;
			TimeSpent.BorderStyle = BorderStyle.FixedSingle;
			Controls.Add(TimeSpent);

			MineRemian = new Label();
			MineRemian.BackColor = Color.Gray;
			MineRemian.Text = mine.MineCount.ToString();
			MineRemian.Location = new Point((columns - 4) * 40, 40 * rows + menuStrip1.Height + 10);
			MineRemian.Size = new Size(80, 40);
			MineRemian.Font = new Font("Arial", 20F);
			MineRemian.ForeColor = Color.White;
			MineRemian.TextAlign = ContentAlignment.MiddleCenter;
			MineRemian.BorderStyle = BorderStyle.FixedSingle;
			Controls.Add(MineRemian);

			MineImage = new PictureBox();
			//MineImage.Image = Image.FromFile("地雷.png");
			MineImage.Image = Properties.Resources.地雷;
			MineImage.Size = new Size(40, 40);
			MineImage.SizeMode = PictureBoxSizeMode.StretchImage;
			MineImage.Location = new Point((columns - 4) * 40 + 90, 40 * rows + menuStrip1.Height + 10);
			Controls.Add(MineImage);
		}

		private void Btns_DoubleClick(object sender, EventArgs e)
		{
			MyButton button = (MyButton)sender;
			int index = Convert.ToInt32(button.Name);
			int columns = mine.Columns;
			int rows = mine.Rows;
			int num = -1;
			int count = 0;
			try
			{
				num = Convert.ToInt32(button.Text);
			}
			catch (Exception)
			{

			}

			for (int i = -1; i <= 1; i++)
			{
				if ((index / columns == 0 && i == -1) || (index / columns == rows - 1 && i == 1))
				{
					continue;
				}
				for (int j = -1; j <= 1; j++)
				{
					if ((index % columns == 0 && j == -1) || (index % columns == columns - 1 && j == 1))
					{
						continue;
					}
					if (ButtonList[index + columns * i + j].Text == "🚩")
					{
						count++;
					}
				}
			}
			if (num == count)
			{
				if (index / columns == 0)
				{
					if (index == 0)
					{
						ClickButton(ButtonList[index + 1]);
						ClickButton(ButtonList[index + columns]);
						ClickButton(ButtonList[index + columns + 1]);
					}
					else if (index == columns - 1)
					{
						ClickButton(ButtonList[index - 1]);
						ClickButton(ButtonList[index + columns]);
						ClickButton(ButtonList[index + columns - 1]);
					}
					else
					{
						ClickButton(ButtonList[index - 1]);
						ClickButton(ButtonList[index + 1]);
						ClickButton(ButtonList[index + columns - 1]);
						ClickButton(ButtonList[index + columns]);
						ClickButton(ButtonList[index + columns + 1]);
					}
				}
				else if (index / columns == rows - 1)
				{
					if (index == (rows - 1) * columns)
					{
						ClickButton(ButtonList[index + 1]);
						ClickButton(ButtonList[index - columns]);
						ClickButton(ButtonList[index - columns + 1]);
					}
					else if (index == rows * columns - 1)
					{
						ClickButton(ButtonList[index - 1]);
						ClickButton(ButtonList[index - columns]);
						ClickButton(ButtonList[index - columns - 1]);
					}
					else
					{
						ClickButton(ButtonList[index - columns - 1]);
						ClickButton(ButtonList[index - columns]);
						ClickButton(ButtonList[index - columns + 1]);
						ClickButton(ButtonList[index - 1]);
						ClickButton(ButtonList[index + 1]);
					}
				}
				else if (index % columns == 0)
				{
					ClickButton(ButtonList[index - columns]);
					ClickButton(ButtonList[index - columns + 1]);
					ClickButton(ButtonList[index + 1]);
					ClickButton(ButtonList[index + columns]);
					ClickButton(ButtonList[index + columns + 1]);
				}
				else if (index % columns == columns - 1)
				{
					ClickButton(ButtonList[index - columns - 1]);
					ClickButton(ButtonList[index - columns]);
					ClickButton(ButtonList[index - 1]);
					ClickButton(ButtonList[index + columns - 1]);
					ClickButton(ButtonList[index + columns]);
				}
				else
				{
					ClickButton(ButtonList[index - columns - 1]);
					ClickButton(ButtonList[index - columns]);
					ClickButton(ButtonList[index - columns + 1]);
					ClickButton(ButtonList[index - 1]);
					ClickButton(ButtonList[index + 1]);
					ClickButton(ButtonList[index + columns - 1]);
					ClickButton(ButtonList[index + columns]);
					ClickButton(ButtonList[index + columns + 1]);
				}
			}
		}

		private void Btns_TextChanged(object sender, EventArgs e)
		{
			MyButton button = (MyButton)sender;
			switch (button.Text)
			{
				default:
					break;
				case "0":
					button.Text = "";
					break;
				case "1":
					button.ForeColor = Color.FromArgb(0x414fbd);
					break;
				case "2":
					button.ForeColor = Color.FromArgb(0x1A6901);
					break;
				case "3":
					button.ForeColor = Color.FromArgb(0xAC0602);
					break;
				case "4":
					button.ForeColor = Color.FromArgb(0x01017F);
					break;
				case "5":
					button.ForeColor = Color.FromArgb(0x7D0101);
					break;
				case "6":
					button.ForeColor = Color.FromArgb(0x0A7880);
					break;
				case "🚩":
					button.ForeColor = Color.Red;
					break;
				case "❓":
					button.ForeColor = Color.White;
					break;
			}
		}

		private void ChangeValue()
		{
			if (RemainingSafe == 0 && BoomedMine == mine.MineCount)
			{
				MessageBox.Show("遗憾，你失败了");
			}
		}

		private void btns_Click(object sender, EventArgs e)
		{
			MyButton button = (MyButton)sender;
			if (button.Text == "🚩" || button.Text == "❓")
			{
				return;
			}
			if (!timer1.Enabled && !IsFailed)
			{
				timer1.Enabled = true;
			}
			button.Click -= btns_Click;
			button.IsClicked = true;
			int index = Convert.ToInt32(button.Name);
			int columns = mine.Columns;
			int rows = mine.Rows;
			int Count = 0;
			if (mine.MineFlag[index % columns, index / columns])
			{
				if (!IsFailed)
				{
					timer1.Enabled = false;
					//MessageBox.Show("失败");
					IsFailed = true;
				}
				//IsFailed = true;
				BoomedMine++;
				button.BackgroundImage = Properties.Resources.地雷红;
				button.BackgroundImageLayout = ImageLayout.Stretch;
				button.BackColor = Color.White;
				button.FlatAppearance.BorderColor = Color.Gray;
				foreach (MyButton item in ButtonList)
				{
					if (item.Text == "🚩" || item.Text == "❓")
					{
						item.Text = "";
					}
					//item.PerformClick();
					ClickButton(item);
				}
			}
			else
			{
				for (int i = -1; i <= 1; i++)
				{
					if ((index / columns == 0 && i == -1) || (index / columns == rows - 1 && i == 1))
					{
						continue;
					}
					for (int j = -1; j <= 1; j++)
					{
						if ((index % columns == 0 && j == -1) || (index % columns == columns - 1 && j == 1))
						{
							continue;
						}
						if (mine.MineFlag[index % columns + j, index / columns + i])
						{
							Count++;
						}
					}
				}
				if (Count == 0)
				{
					if (index / columns == 0)
					{
						if (index == 0)
						{
							/*ButtonList[index + 1].PerformClick();
							ButtonList[index + columns].PerformClick();
							ButtonList[index + columns + 1].PerformClick();*/
							ClickButton(ButtonList[index + 1]);
							ClickButton(ButtonList[index + columns]);
							ClickButton(ButtonList[index + columns + 1]);
						}
						else if (index == columns - 1)
						{
							/*ButtonList[index - 1].PerformClick();
							ButtonList[index + columns].PerformClick();
							ButtonList[index + columns - 1].PerformClick();*/
							ClickButton(ButtonList[index - 1]);
							ClickButton(ButtonList[index + columns]);
							ClickButton(ButtonList[index + columns - 1]);
						}
						else
						{
							/*ButtonList[index - 1].PerformClick();
							ButtonList[index + 1].PerformClick();
							ButtonList[index + columns - 1].PerformClick();
							ButtonList[index + columns].PerformClick();
							ButtonList[index + columns + 1].PerformClick();*/
							ClickButton(ButtonList[index - 1]);
							ClickButton(ButtonList[index + 1]);
							ClickButton(ButtonList[index + columns - 1]);
							ClickButton(ButtonList[index + columns]);
							ClickButton(ButtonList[index + columns + 1]);
						}
					}
					else if (index / columns == rows - 1)
					{
						if (index == (rows - 1) * columns)
						{
							/*ButtonList[index + 1].PerformClick();
							ButtonList[index - columns].PerformClick();
							ButtonList[index - columns + 1].PerformClick();*/
							ClickButton(ButtonList[index + 1]);
							ClickButton(ButtonList[index - columns]);
							ClickButton(ButtonList[index - columns + 1]);
						}
						else if (index == rows * columns - 1)
						{
							/*ButtonList[index - 1].PerformClick();
							ButtonList[index - columns].PerformClick();
							ButtonList[index - columns - 1].PerformClick();*/
							ClickButton(ButtonList[index - 1]);
							ClickButton(ButtonList[index - columns]);
							ClickButton(ButtonList[index - columns - 1]);
						}
						else
						{
							/*ButtonList[index - columns - 1].PerformClick();
							ButtonList[index - columns].PerformClick();
							ButtonList[index - columns + 1].PerformClick();
							ButtonList[index - 1].PerformClick();
							ButtonList[index + 1].PerformClick();*/
							ClickButton(ButtonList[index - columns - 1]);
							ClickButton(ButtonList[index - columns]);
							ClickButton(ButtonList[index - columns + 1]);
							ClickButton(ButtonList[index - 1]);
							ClickButton(ButtonList[index + 1]);
						}
					}
					else if (index % columns == 0)
					{
						/*ButtonList[index - columns].PerformClick();
						ButtonList[index - columns + 1].PerformClick();
						ButtonList[index + 1].PerformClick();
						ButtonList[index + columns].PerformClick();
						ButtonList[index + columns + 1].PerformClick();*/
						ClickButton(ButtonList[index - columns]);
						ClickButton(ButtonList[index - columns + 1]);
						ClickButton(ButtonList[index + 1]);
						ClickButton(ButtonList[index + columns]);
						ClickButton(ButtonList[index + columns + 1]);
					}
					else if (index % columns == columns - 1)
					{
						/*ButtonList[index - columns - 1].PerformClick();
						ButtonList[index - columns].PerformClick();
						ButtonList[index - 1].PerformClick();
						ButtonList[index + columns - 1].PerformClick();
						ButtonList[index + columns].PerformClick();*/
						ClickButton(ButtonList[index - columns - 1]);
						ClickButton(ButtonList[index - columns]);
						ClickButton(ButtonList[index - 1]);
						ClickButton(ButtonList[index + columns - 1]);
						ClickButton(ButtonList[index + columns]);
					}
					else
					{
						/*ButtonList[index - columns - 1].PerformClick();
						ButtonList[index - columns].PerformClick();
						ButtonList[index - columns + 1].PerformClick();
						ButtonList[index - 1].PerformClick();
						ButtonList[index + 1].PerformClick();
						ButtonList[index + columns - 1].PerformClick();
						ButtonList[index + columns].PerformClick();
						ButtonList[index + columns + 1].PerformClick();*/
						ClickButton(ButtonList[index - columns - 1]);
						ClickButton(ButtonList[index - columns]);
						ClickButton(ButtonList[index - columns + 1]);
						ClickButton(ButtonList[index - 1]);
						ClickButton(ButtonList[index + 1]);
						ClickButton(ButtonList[index + columns - 1]);
						ClickButton(ButtonList[index + columns]);
						ClickButton(ButtonList[index + columns + 1]);
					}
				}
				button.FlatAppearance.BorderColor = Color.Gray;
				button.BackColor = Color.White;
				button.Text = Count.ToString();
				//button.MouseDown -= btns_MouseDown;
				RemainingSafe--;
				if (RemainingSafe == 0 && !IsFailed)
				{
					timer1.Enabled = false;
					for (int i = 0; i < ButtonList.Count; i++)
					{
						if (mine.MineFlag[i % columns, i / columns])
						{
							ButtonList[i].BackgroundImage = Properties.Resources.地雷;
							ButtonList[i].BackgroundImageLayout = ImageLayout.Stretch;
							ButtonList[i].BackColor = Color.Transparent;
							ButtonList[i].FlatAppearance.BorderColor = Color.Gray;
						}
					}
					MessageBox.Show("恭喜，你完成了这一伟大的壮举");
				}
			}
		}

		private void ClickButton(MyButton button)
		{
			if (!button.IsClicked)
			{
				button.PerformClick();
			}
		}

		private void btns_MouseDown(object sender, MouseEventArgs e)
		{
			MyButton button = (MyButton)sender;
			if (e.Button == MouseButtons.Right)
			{
				switch (button.Text)
				{
					case "":
						button.Text = "🚩";
						MineRemian.Text = (Convert.ToInt32(MineRemian.Text) - 1).ToString();
						break;
					case "🚩":
						button.Text = "❓";
						MineRemian.Text = (Convert.ToInt32(MineRemian.Text) + 1).ToString();
						break;
					case "❓":
						button.Text = "";
						break;
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			int time = Convert.ToInt32(TimeSpent.Text);
			TimeSpent.Text = (time + 1).ToString();
		}
	}

	public class Mine
	{
		public int MineCount { get; set; }
		public int Columns { get; set; }
		public int Rows { get; set; }
		public bool[,] MineFlag { get; set; }

		public Mine()
		{
			MineCount = 10;
			Columns = 9;
			Rows = 9;
			GetMine();
		}

		public Mine(int rows, int columns, int minecount)
		{
			Rows = rows;
			Columns = columns;
			MineCount = minecount;
			GetMine();
		}

		private void GetMine()
		{
			MineFlag = new bool[Columns, Rows];
			Random rd = new Random();
			HashSet<int> Index = new HashSet<int>();
			for (int i = 0; i < MineCount; i++)
			{
				int x = rd.Next(0, Columns);
				int y = rd.Next(0, Rows);

				if (Index.Add(y * Columns + x))
					MineFlag[x, y] = true;
				else
					i--;
			}
		}
	}

	public class MyButton : Button
	{
		public bool IsClicked { get; set; }

		public new event EventHandler DoubleClick;
		DateTime clickTime;
		bool isClicked = false;
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			if (isClicked)
			{
				TimeSpan span = DateTime.Now - clickTime;
				if (span.Milliseconds < SystemInformation.DoubleClickTime)
				{
					DoubleClick(this, e);
					isClicked = false;
				}
				else
				{
					clickTime = DateTime.Now;
				}
			}
			else
			{
				isClicked = true;
				clickTime = DateTime.Now;
			}
		}

		bool IsLeftDown = false;
		bool IsRightDown = false;
		bool IsMouseDown = false;
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (IsLeftDown)
			{
				if (e.Button == MouseButtons.Right)
				{
					IsLeftDown = false;
					IsMouseDown = true;
				}
			}
			else
			{
				if (e.Button == MouseButtons.Left)
				{
					IsLeftDown = true;
				}
			}

			if (IsRightDown)
			{
				if (e.Button == MouseButtons.Left)
				{
					IsRightDown = false;
					IsMouseDown = true;
				}
			}
			else
			{
				if (e.Button == MouseButtons.Right)
				{
					IsRightDown = true;
				}
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (IsMouseDown)
			{
				DoubleClick(this, e);
				IsMouseDown = false;
			}
			else
			{
				IsLeftDown = false;
				IsRightDown = false;
			}
		}
	}

}
