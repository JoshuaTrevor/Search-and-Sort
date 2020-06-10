namespace MaterialUIDemo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.squaresPanel = new System.Windows.Forms.Panel();
            this.goButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.sortCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.searchCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.timerTrackBar = new System.Windows.Forms.TrackBar();
            this.renderGridCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.renderGapsCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.algorithmSelectorBox = new System.Windows.Forms.ComboBox();
            this.gridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPanel
            // 
            this.gridPanel.BackColor = System.Drawing.Color.MidnightBlue;
            this.gridPanel.Controls.Add(this.squaresPanel);
            this.gridPanel.Location = new System.Drawing.Point(12, 12);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(572, 572);
            this.gridPanel.TabIndex = 0;
            this.gridPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gridPanel_Paint);
            // 
            // squaresPanel
            // 
            this.squaresPanel.BackColor = System.Drawing.Color.Transparent;
            this.squaresPanel.Location = new System.Drawing.Point(0, 0);
            this.squaresPanel.Name = "squaresPanel";
            this.squaresPanel.Size = new System.Drawing.Size(572, 575);
            this.squaresPanel.TabIndex = 1;
            this.squaresPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.squaresPanel_Paint);
            // 
            // goButton
            // 
            this.goButton.Depth = 0;
            this.goButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.goButton.Location = new System.Drawing.Point(12, 590);
            this.goButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.goButton.Name = "goButton";
            this.goButton.Primary = true;
            this.goButton.Size = new System.Drawing.Size(248, 63);
            this.goButton.TabIndex = 1;
            this.goButton.Text = "Go!";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // sortCheckBox
            // 
            this.sortCheckBox.AutoSize = true;
            this.sortCheckBox.Checked = true;
            this.sortCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sortCheckBox.Depth = 0;
            this.sortCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.sortCheckBox.Location = new System.Drawing.Point(263, 590);
            this.sortCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.sortCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.sortCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.sortCheckBox.Name = "sortCheckBox";
            this.sortCheckBox.Ripple = true;
            this.sortCheckBox.Size = new System.Drawing.Size(55, 30);
            this.sortCheckBox.TabIndex = 2;
            this.sortCheckBox.Text = "Sort";
            this.sortCheckBox.UseVisualStyleBackColor = true;
            // 
            // searchCheckBox
            // 
            this.searchCheckBox.AutoSize = true;
            this.searchCheckBox.Depth = 0;
            this.searchCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.searchCheckBox.Location = new System.Drawing.Point(263, 623);
            this.searchCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.searchCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.searchCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.searchCheckBox.Name = "searchCheckBox";
            this.searchCheckBox.Ripple = true;
            this.searchCheckBox.Size = new System.Drawing.Size(73, 30);
            this.searchCheckBox.TabIndex = 3;
            this.searchCheckBox.Text = "Search";
            this.searchCheckBox.UseVisualStyleBackColor = true;
            // 
            // timerTrackBar
            // 
            this.timerTrackBar.LargeChange = 1;
            this.timerTrackBar.Location = new System.Drawing.Point(474, 593);
            this.timerTrackBar.Minimum = 6;
            this.timerTrackBar.Name = "timerTrackBar";
            this.timerTrackBar.Size = new System.Drawing.Size(110, 45);
            this.timerTrackBar.TabIndex = 0;
            this.timerTrackBar.TickFrequency = 2;
            this.timerTrackBar.Value = 8;
            this.timerTrackBar.Scroll += new System.EventHandler(this.timerTrackBar_Scroll);
            // 
            // renderGridCheckBox
            // 
            this.renderGridCheckBox.AutoSize = true;
            this.renderGridCheckBox.Depth = 0;
            this.renderGridCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.renderGridCheckBox.Location = new System.Drawing.Point(347, 590);
            this.renderGridCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.renderGridCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.renderGridCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.renderGridCheckBox.Name = "renderGridCheckBox";
            this.renderGridCheckBox.Ripple = true;
            this.renderGridCheckBox.Size = new System.Drawing.Size(102, 30);
            this.renderGridCheckBox.TabIndex = 5;
            this.renderGridCheckBox.Text = "Render Grid";
            this.renderGridCheckBox.UseVisualStyleBackColor = true;
            // 
            // renderGapsCheckBox
            // 
            this.renderGapsCheckBox.AutoSize = true;
            this.renderGapsCheckBox.Depth = 0;
            this.renderGapsCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.renderGapsCheckBox.Location = new System.Drawing.Point(347, 623);
            this.renderGapsCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.renderGapsCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.renderGapsCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.renderGapsCheckBox.Name = "renderGapsCheckBox";
            this.renderGapsCheckBox.Ripple = true;
            this.renderGapsCheckBox.Size = new System.Drawing.Size(108, 30);
            this.renderGapsCheckBox.TabIndex = 6;
            this.renderGapsCheckBox.Text = "Render Gaps";
            this.renderGapsCheckBox.UseVisualStyleBackColor = true;
            // 
            // algorithmSelectorBox
            // 
            this.algorithmSelectorBox.CausesValidation = false;
            this.algorithmSelectorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.algorithmSelectorBox.FormattingEnabled = true;
            this.algorithmSelectorBox.Items.AddRange(new object[] {
            "Bubble",
            "Heap",
            "Selection",
            "Merge",
            "Quick"});
            this.algorithmSelectorBox.Location = new System.Drawing.Point(474, 628);
            this.algorithmSelectorBox.Name = "algorithmSelectorBox";
            this.algorithmSelectorBox.Size = new System.Drawing.Size(110, 21);
            this.algorithmSelectorBox.TabIndex = 7;
            this.algorithmSelectorBox.Tag = "";
            this.algorithmSelectorBox.SelectedIndexChanged += new System.EventHandler(this.algorithmSelectorBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(596, 660);
            this.Controls.Add(this.algorithmSelectorBox);
            this.Controls.Add(this.renderGapsCheckBox);
            this.Controls.Add(this.renderGridCheckBox);
            this.Controls.Add(this.timerTrackBar);
            this.Controls.Add(this.searchCheckBox);
            this.Controls.Add(this.sortCheckBox);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.gridPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximumSize = new System.Drawing.Size(612, 699);
            this.MinimumSize = new System.Drawing.Size(612, 699);
            this.Name = "Form1";
            this.Text = "Search and Sort - Joshua Trevor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timerTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel gridPanel;
        private MaterialSkin.Controls.MaterialRaisedButton goButton;
        private System.Windows.Forms.Panel squaresPanel;
        private System.Windows.Forms.Timer timer1;
        private MaterialSkin.Controls.MaterialCheckBox sortCheckBox;
        private MaterialSkin.Controls.MaterialCheckBox searchCheckBox;
        private System.Windows.Forms.TrackBar timerTrackBar;
        private MaterialSkin.Controls.MaterialCheckBox renderGridCheckBox;
        private MaterialSkin.Controls.MaterialCheckBox renderGapsCheckBox;
        private System.Windows.Forms.ComboBox algorithmSelectorBox;
    }
}

