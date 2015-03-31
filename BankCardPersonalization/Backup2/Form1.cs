using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace TestAdvButton
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private AdvButton.RoundButton roundButton1;
		private System.Windows.Forms.ImageList imageList1;
		private AdvButton.RoundButton roundButton2;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.roundButton1 = new AdvButton.RoundButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.roundButton2 = new AdvButton.RoundButton();
			this.SuspendLayout();
			// 
			// roundButton1
			// 
			this.roundButton1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.roundButton1.ColorGradient = ((System.Byte)(2));
			this.roundButton1.ColorStepGradient = ((System.Byte)(2));
			this.roundButton1.FadeOut = false;
			this.roundButton1.HoverColor = System.Drawing.SystemColors.ControlDark;
			this.roundButton1.ImageIndex = 0;
			this.roundButton1.ImageList = this.imageList1;
			this.roundButton1.Location = new System.Drawing.Point(24, 16);
			this.roundButton1.Name = "roundButton1";
			this.roundButton1.Size = new System.Drawing.Size(64, 64);
			this.roundButton1.TabIndex = 0;
			this.roundButton1.TextStartPoint = new System.Drawing.Point(50, 26);
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Red;
			// 
			// roundButton2
			// 
			this.roundButton2.BackColor = System.Drawing.Color.LightSteelBlue;
			this.roundButton2.ColorGradient = ((System.Byte)(2));
			this.roundButton2.ColorStepGradient = ((System.Byte)(2));
			this.roundButton2.FadeOut = false;
			this.roundButton2.HoverColor = System.Drawing.SystemColors.ControlDark;
			this.roundButton2.ImageIndex = 1;
			this.roundButton2.ImageList = this.imageList1;
			this.roundButton2.Location = new System.Drawing.Point(96, 24);
			this.roundButton2.Name = "roundButton2";
			this.roundButton2.Size = new System.Drawing.Size(48, 48);
			this.roundButton2.TabIndex = 1;
			this.roundButton2.TextStartPoint = new System.Drawing.Point(50, 26);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(168, 104);
			this.Controls.Add(this.roundButton2);
			this.Controls.Add(this.roundButton1);
			this.Name = "Form1";
			this.Text = "Test App";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	}
}
