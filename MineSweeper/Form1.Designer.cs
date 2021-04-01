
namespace MineSweeper
{
	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NewGame = new System.Windows.Forms.ToolStripMenuItem();
			this.选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TenMine = new System.Windows.Forms.ToolStripMenuItem();
			this.FortyMine = new System.Windows.Forms.ToolStripMenuItem();
			this.NinetyNineMine = new System.Windows.Forms.ToolStripMenuItem();
			this.Exit = new System.Windows.Forms.ToolStripMenuItem();
			this.Help = new System.Windows.Forms.ToolStripMenuItem();
			this.About = new System.Windows.Forms.ToolStripMenuItem();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.游戏ToolStripMenuItem,
            this.Help,
            this.About});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(283, 28);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// 游戏ToolStripMenuItem
			// 
			this.游戏ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewGame,
            this.选项ToolStripMenuItem,
            this.Exit});
			this.游戏ToolStripMenuItem.Name = "游戏ToolStripMenuItem";
			this.游戏ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
			this.游戏ToolStripMenuItem.Text = "游戏";
			// 
			// NewGame
			// 
			this.NewGame.Name = "NewGame";
			this.NewGame.Size = new System.Drawing.Size(137, 26);
			this.NewGame.Text = "新游戏";
			this.NewGame.Click += new System.EventHandler(this.NewGame_Click);
			// 
			// 选项ToolStripMenuItem
			// 
			this.选项ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TenMine,
            this.FortyMine,
            this.NinetyNineMine});
			this.选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
			this.选项ToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
			this.选项ToolStripMenuItem.Text = "选项";
			// 
			// TenMine
			// 
			this.TenMine.Name = "TenMine";
			this.TenMine.Size = new System.Drawing.Size(180, 26);
			this.TenMine.Text = "初级(10个雷)";
			this.TenMine.Click += new System.EventHandler(this.TenMine_Click);
			// 
			// FortyMine
			// 
			this.FortyMine.Name = "FortyMine";
			this.FortyMine.Size = new System.Drawing.Size(180, 26);
			this.FortyMine.Text = "中级(40个雷)";
			this.FortyMine.Click += new System.EventHandler(this.FortyMine_Click);
			// 
			// NinetyNineMine
			// 
			this.NinetyNineMine.Name = "NinetyNineMine";
			this.NinetyNineMine.Size = new System.Drawing.Size(180, 26);
			this.NinetyNineMine.Text = "高级(99个雷)";
			this.NinetyNineMine.Click += new System.EventHandler(this.NinetyNineMine_Click);
			// 
			// Exit
			// 
			this.Exit.Name = "Exit";
			this.Exit.Size = new System.Drawing.Size(137, 26);
			this.Exit.Text = "退出";
			this.Exit.Click += new System.EventHandler(this.Exit_Click);
			// 
			// Help
			// 
			this.Help.Name = "Help";
			this.Help.Size = new System.Drawing.Size(53, 24);
			this.Help.Text = "帮助";
			this.Help.Click += new System.EventHandler(this.Help_Click);
			// 
			// About
			// 
			this.About.Name = "About";
			this.About.Size = new System.Drawing.Size(53, 24);
			this.About.Text = "关于";
			this.About.Click += new System.EventHandler(this.About_Click);
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(283, 233);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.Text = "MineSweeper";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 游戏ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem NewGame;
		private System.Windows.Forms.ToolStripMenuItem Exit;
		private System.Windows.Forms.ToolStripMenuItem Help;
		private System.Windows.Forms.ToolStripMenuItem About;
		private System.Windows.Forms.ToolStripMenuItem 选项ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TenMine;
		private System.Windows.Forms.ToolStripMenuItem FortyMine;
		private System.Windows.Forms.ToolStripMenuItem NinetyNineMine;
		private System.Windows.Forms.Timer timer1;
	}
}

