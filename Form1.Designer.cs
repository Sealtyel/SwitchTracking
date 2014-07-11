namespace SwitchTracking
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.switchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.switchDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.switchDataSet = new SwitchTracking.SwitchDataSet();
            this.switchTableAdapter = new SwitchTracking.SwitchDataSetTableAdapters.SwitchTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.fillBy1ToolStrip = new System.Windows.Forms.ToolStrip();
            this.fillBy1ToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.switchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.switchDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.switchDataSet)).BeginInit();
            this.fillBy1ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.switchBindingSource;
            this.comboBox1.DisplayMember = "nombre";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "ip";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // switchBindingSource
            // 
            this.switchBindingSource.DataMember = "Switch";
            this.switchBindingSource.DataSource = this.switchDataSetBindingSource;
            // 
            // switchDataSetBindingSource
            // 
            this.switchDataSetBindingSource.DataSource = this.switchDataSet;
            this.switchDataSetBindingSource.Position = 0;
            this.switchDataSetBindingSource.CurrentChanged += new System.EventHandler(this.switchDataSetBindingSource_CurrentChanged);
            // 
            // switchDataSet
            // 
            this.switchDataSet.DataSetName = "SwitchDataSet";
            this.switchDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // switchTableAdapter
            // 
            this.switchTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // fillBy1ToolStrip
            // 
            this.fillBy1ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillBy1ToolStripButton});
            this.fillBy1ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillBy1ToolStrip.Name = "fillBy1ToolStrip";
            this.fillBy1ToolStrip.Size = new System.Drawing.Size(111, 25);
            this.fillBy1ToolStrip.TabIndex = 2;
            this.fillBy1ToolStrip.Text = "fillBy1ToolStrip";
            // 
            // fillBy1ToolStripButton
            // 
            this.fillBy1ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillBy1ToolStripButton.Name = "fillBy1ToolStripButton";
            this.fillBy1ToolStripButton.Size = new System.Drawing.Size(45, 22);
            this.fillBy1ToolStripButton.Text = "FillBy1";
            this.fillBy1ToolStripButton.Click += new System.EventHandler(this.fillBy1ToolStripButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 264);
            this.Controls.Add(this.fillBy1ToolStrip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.switchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.switchDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.switchDataSet)).EndInit();
            this.fillBy1ToolStrip.ResumeLayout(false);
            this.fillBy1ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource switchDataSetBindingSource;
        private SwitchDataSet switchDataSet;
        private System.Windows.Forms.BindingSource switchBindingSource;
        private SwitchDataSetTableAdapters.SwitchTableAdapter switchTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip fillBy1ToolStrip;
        private System.Windows.Forms.ToolStripButton fillBy1ToolStripButton;
    }
}