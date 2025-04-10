﻿using System.Drawing;
using System.Windows.Forms;

namespace Chronicle.Facilities.Buildings
{
    partial class Buildings
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
            menuStrip1 = new MenuStrip();
            saveToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            listView1 = new ListView();
            buildingID = new ColumnHeader();
            buildingCode = new ColumnHeader();
            buildingName = new ColumnHeader();
            splitContainer1 = new SplitContainer();
            propertyGrid1 = new PropertyGrid();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { saveToolStripMenuItem, newToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(12, 20);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(12, 20);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { buildingID, buildingCode, buildingName });
            listView1.Dock = DockStyle.Fill;
            listView1.FullRowSelect = true;
            listView1.Location = new Point(0, 0);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(442, 426);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // buildingID
            // 
            buildingID.Text = "Building ID";
            buildingID.Width = 100;
            // 
            // buildingCode
            // 
            buildingCode.Text = "Building Code";
            buildingCode.Width = 100;
            // 
            // buildingName
            // 
            buildingName.Text = "Building Name";
            buildingName.Width = 100;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(listView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(propertyGrid1);
            splitContainer1.Size = new Size(800, 426);
            splitContainer1.SplitterDistance = 442;
            splitContainer1.TabIndex = 1;
            // 
            // propertyGrid1
            // 
            propertyGrid1.Dock = DockStyle.Fill;
            propertyGrid1.Location = new Point(0, 0);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(354, 426);
            propertyGrid1.TabIndex = 0;
            // 
            // Buildings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Buildings";
            Text = "Buildings";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ListView listView1;
        private ColumnHeader buildingID;
        private ColumnHeader buildingCode;
        private ColumnHeader buildingName;
        private SplitContainer splitContainer1;
        private PropertyGrid propertyGrid1;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;

    }
}