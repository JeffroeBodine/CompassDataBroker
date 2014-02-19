namespace RestClient
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
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnGetDocumentTypeGroups = new System.Windows.Forms.Button();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.btnGetDocumentTypeGroup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(681, 12);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(503, 742);
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // btnGetDocumentTypeGroups
            // 
            this.btnGetDocumentTypeGroups.Location = new System.Drawing.Point(12, 12);
            this.btnGetDocumentTypeGroups.Name = "btnGetDocumentTypeGroups";
            this.btnGetDocumentTypeGroups.Size = new System.Drawing.Size(170, 23);
            this.btnGetDocumentTypeGroups.TabIndex = 1;
            this.btnGetDocumentTypeGroups.Text = "Get Document Type Groups";
            this.btnGetDocumentTypeGroups.UseVisualStyleBackColor = true;
            this.btnGetDocumentTypeGroups.Click += new System.EventHandler(this.btnGetDocumentTypeGroups_Click);
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(12, 344);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(663, 410);
            this.tbOutput.TabIndex = 2;
            // 
            // btnGetDocumentTypeGroup
            // 
            this.btnGetDocumentTypeGroup.Location = new System.Drawing.Point(188, 12);
            this.btnGetDocumentTypeGroup.Name = "btnGetDocumentTypeGroup";
            this.btnGetDocumentTypeGroup.Size = new System.Drawing.Size(170, 23);
            this.btnGetDocumentTypeGroup.TabIndex = 3;
            this.btnGetDocumentTypeGroup.Text = "Get Document Type Group";
            this.btnGetDocumentTypeGroup.UseVisualStyleBackColor = true;
            this.btnGetDocumentTypeGroup.Click += new System.EventHandler(this.btnGetDocumentTypeGroup_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 766);
            this.Controls.Add(this.btnGetDocumentTypeGroup);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.btnGetDocumentTypeGroups);
            this.Controls.Add(this.pbImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnGetDocumentTypeGroups;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Button btnGetDocumentTypeGroup;
    }
}

