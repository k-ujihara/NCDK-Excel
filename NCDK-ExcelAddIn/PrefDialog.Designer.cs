namespace NCDK_ExcelAddIn
{
    partial class PrefDialog
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
            this.labelColoring = new System.Windows.Forms.Label();
            this.comboColoring = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboImageType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textMinimumPixels = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.comboToolkit = new System.Windows.Forms.ComboBox();
            this.labelToolkit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelColoring
            // 
            this.labelColoring.AutoSize = true;
            this.labelColoring.Font = new System.Drawing.Font("MS UI Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelColoring.Location = new System.Drawing.Point(17, 51);
            this.labelColoring.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelColoring.Name = "labelColoring";
            this.labelColoring.Size = new System.Drawing.Size(80, 19);
            this.labelColoring.TabIndex = 0;
            this.labelColoring.Text = "Coloring:";
            // 
            // comboColoring
            // 
            this.comboColoring.Font = new System.Drawing.Font("MS UI Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboColoring.FormattingEnabled = true;
            this.comboColoring.Location = new System.Drawing.Point(150, 51);
            this.comboColoring.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.comboColoring.Name = "comboColoring";
            this.comboColoring.Size = new System.Drawing.Size(242, 26);
            this.comboColoring.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(17, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Image Type:";
            // 
            // comboImageType
            // 
            this.comboImageType.Font = new System.Drawing.Font("MS UI Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboImageType.FormattingEnabled = true;
            this.comboImageType.Location = new System.Drawing.Point(150, 86);
            this.comboImageType.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.comboImageType.Name = "comboImageType";
            this.comboImageType.Size = new System.Drawing.Size(242, 26);
            this.comboImageType.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(17, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Minimum Pixels:";
            // 
            // textMinimumPixels
            // 
            this.textMinimumPixels.Font = new System.Drawing.Font("MS UI Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textMinimumPixels.Location = new System.Drawing.Point(150, 126);
            this.textMinimumPixels.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textMinimumPixels.Name = "textMinimumPixels";
            this.textMinimumPixels.Size = new System.Drawing.Size(242, 26);
            this.textMinimumPixels.TabIndex = 5;
            this.textMinimumPixels.Text = "300";
            this.textMinimumPixels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(249, 216);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(74, 31);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(332, 216);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(74, 31);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(165, 216);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(74, 31);
            this.buttonReset.TabIndex = 8;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // comboToolkit
            // 
            this.comboToolkit.Font = new System.Drawing.Font("MS UI Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboToolkit.FormattingEnabled = true;
            this.comboToolkit.Location = new System.Drawing.Point(150, 12);
            this.comboToolkit.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.comboToolkit.Name = "comboToolkit";
            this.comboToolkit.Size = new System.Drawing.Size(242, 26);
            this.comboToolkit.TabIndex = 9;
            // 
            // labelToolkit
            // 
            this.labelToolkit.AutoSize = true;
            this.labelToolkit.Font = new System.Drawing.Font("MS UI Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelToolkit.Location = new System.Drawing.Point(17, 12);
            this.labelToolkit.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelToolkit.Name = "labelToolkit";
            this.labelToolkit.Size = new System.Drawing.Size(68, 19);
            this.labelToolkit.TabIndex = 10;
            this.labelToolkit.Text = "Toolkit:";
            // 
            // PrefDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(419, 262);
            this.ControlBox = false;
            this.Controls.Add(this.labelToolkit);
            this.Controls.Add(this.comboToolkit);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textMinimumPixels);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboImageType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboColoring);
            this.Controls.Add(this.labelColoring);
            this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.Name = "PrefDialog";
            this.Text = "Preference";
            this.Load += new System.EventHandler(this.PrefDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelColoring;
        public System.Windows.Forms.ComboBox comboColoring;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboImageType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonReset;
        public System.Windows.Forms.TextBox textMinimumPixels;
        public System.Windows.Forms.ComboBox comboToolkit;
        private System.Windows.Forms.Label labelToolkit;
    }
}