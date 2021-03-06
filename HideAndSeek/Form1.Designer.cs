﻿namespace HideAndSeek
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
            this.exits = new System.Windows.Forms.ComboBox();
            this.goHere = new System.Windows.Forms.Button();
            this.goThroughTheDoor = new System.Windows.Forms.Button();
            this.description = new System.Windows.Forms.TextBox();
            this.check = new System.Windows.Forms.Button();
            this.hide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exits
            // 
            this.exits.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exits.FormattingEnabled = true;
            this.exits.ItemHeight = 20;
            this.exits.Location = new System.Drawing.Point(143, 274);
            this.exits.Name = "exits";
            this.exits.Size = new System.Drawing.Size(336, 28);
            this.exits.TabIndex = 0;
            this.exits.Visible = false;
            // 
            // goHere
            // 
            this.goHere.Location = new System.Drawing.Point(21, 273);
            this.goHere.Name = "goHere";
            this.goHere.Size = new System.Drawing.Size(116, 30);
            this.goHere.TabIndex = 1;
            this.goHere.Text = "Go here:";
            this.goHere.UseVisualStyleBackColor = true;
            this.goHere.Visible = false;
            this.goHere.Click += new System.EventHandler(this.goHere_Click);
            // 
            // goThroughTheDoor
            // 
            this.goThroughTheDoor.Location = new System.Drawing.Point(21, 308);
            this.goThroughTheDoor.Name = "goThroughTheDoor";
            this.goThroughTheDoor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.goThroughTheDoor.Size = new System.Drawing.Size(458, 30);
            this.goThroughTheDoor.TabIndex = 2;
            this.goThroughTheDoor.Text = "Go through the door";
            this.goThroughTheDoor.UseVisualStyleBackColor = true;
            this.goThroughTheDoor.Visible = false;
            this.goThroughTheDoor.Click += new System.EventHandler(this.goThroughTheDoor_Click);
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(21, 26);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(458, 238);
            this.description.TabIndex = 3;
            // 
            // check
            // 
            this.check.Location = new System.Drawing.Point(21, 345);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(458, 30);
            this.check.TabIndex = 4;
            this.check.Text = "check";
            this.check.UseVisualStyleBackColor = true;
            this.check.Click += new System.EventHandler(this.check_Click);
            // 
            // hide
            // 
            this.hide.Location = new System.Drawing.Point(21, 383);
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(458, 30);
            this.hide.TabIndex = 5;
            this.hide.Text = "Hide!";
            this.hide.UseVisualStyleBackColor = true;
            this.hide.Click += new System.EventHandler(this.hide_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 439);
            this.Controls.Add(this.hide);
            this.Controls.Add(this.check);
            this.Controls.Add(this.description);
            this.Controls.Add(this.goThroughTheDoor);
            this.Controls.Add(this.goHere);
            this.Controls.Add(this.exits);
            this.Name = "Form1";
            this.Text = "Hide and Seek";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox exits;
        private System.Windows.Forms.Button goHere;
        private System.Windows.Forms.Button goThroughTheDoor;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Button check;
        private System.Windows.Forms.Button hide;
    }
}

