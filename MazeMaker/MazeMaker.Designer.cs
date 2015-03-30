namespace MazeMaker
{
    partial class MazeMaker
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
            this.maze = new System.Windows.Forms.Label();
            this.redoButton = new System.Windows.Forms.Button();
            this.mazeBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mazeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // maze
            // 
            this.maze.AutoSize = true;
            this.maze.Font = new System.Drawing.Font("Courier New", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maze.Location = new System.Drawing.Point(17, 52);
            this.maze.Name = "maze";
            this.maze.Size = new System.Drawing.Size(0, 8);
            this.maze.TabIndex = 0;
            // 
            // redoButton
            // 
            this.redoButton.Location = new System.Drawing.Point(170, 12);
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(51, 23);
            this.redoButton.TabIndex = 1;
            this.redoButton.Text = "here!";
            this.redoButton.UseVisualStyleBackColor = true;
            this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
            // 
            // mazeBox
            // 
            this.mazeBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mazeBox.Location = new System.Drawing.Point(240, 12);
            this.mazeBox.Name = "mazeBox";
            this.mazeBox.Size = new System.Drawing.Size(400, 400);
            this.mazeBox.TabIndex = 2;
            this.mazeBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "To re-run Prim\'s Algorithim click:";
            // 
            // MazeMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 422);
            this.Controls.Add(this.redoButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mazeBox);
            this.Controls.Add(this.maze);
            this.Name = "MazeMaker";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MazeMaker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mazeBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label maze;
        private System.Windows.Forms.Button redoButton;
        private System.Windows.Forms.PictureBox mazeBox;
        private System.Windows.Forms.Label label1;
    }
}

