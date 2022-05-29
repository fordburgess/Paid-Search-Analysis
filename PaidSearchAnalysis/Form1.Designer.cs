namespace PaidSearchAnalysis
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.input_folder = new System.Windows.Forms.TextBox();
            this.search_input_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.output_location = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.output_search_button = new System.Windows.Forms.Button();
            this.run_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.outputLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.inputFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // input_folder
            // 
            this.input_folder.Location = new System.Drawing.Point(257, 161);
            this.input_folder.Name = "input_folder";
            this.input_folder.Size = new System.Drawing.Size(220, 27);
            this.input_folder.TabIndex = 0;
            // 
            // search_input_button
            // 
            this.search_input_button.Location = new System.Drawing.Point(500, 161);
            this.search_input_button.Name = "search_input_button";
            this.search_input_button.Size = new System.Drawing.Size(94, 29);
            this.search_input_button.TabIndex = 1;
            this.search_input_button.Text = "Search";
            this.search_input_button.UseVisualStyleBackColor = true;
            this.search_input_button.Click += new System.EventHandler(this.search_input_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input File";
            // 
            // output_location
            // 
            this.output_location.Location = new System.Drawing.Point(257, 239);
            this.output_location.Name = "output_location";
            this.output_location.Size = new System.Drawing.Size(220, 27);
            this.output_location.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Output Location";
            // 
            // output_search_button
            // 
            this.output_search_button.Location = new System.Drawing.Point(500, 237);
            this.output_search_button.Name = "output_search_button";
            this.output_search_button.Size = new System.Drawing.Size(94, 29);
            this.output_search_button.TabIndex = 5;
            this.output_search_button.Text = "Search";
            this.output_search_button.UseVisualStyleBackColor = true;
            this.output_search_button.Click += new System.EventHandler(this.output_search_button_Click);
            // 
            // run_button
            // 
            this.run_button.Location = new System.Drawing.Point(359, 313);
            this.run_button.Name = "run_button";
            this.run_button.Size = new System.Drawing.Size(151, 29);
            this.run_button.TabIndex = 6;
            this.run_button.Text = "Run";
            this.run_button.UseVisualStyleBackColor = true;
            this.run_button.Click += new System.EventHandler(this.run_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(227, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(394, 30);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tatjana\'s Paid Search Analysis";                        
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 426);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.run_button);
            this.Controls.Add(this.output_search_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.output_location);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.search_input_button);
            this.Controls.Add(this.input_folder);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox input_folder;
        private Button search_input_button;
        private Label label1;
        private TextBox output_location;
        private Label label2;
        private Button output_search_button;
        private Button run_button;
        private Label label3;
        private FolderBrowserDialog outputLocation;
        private FolderBrowserDialog inputFolder;
    }
}