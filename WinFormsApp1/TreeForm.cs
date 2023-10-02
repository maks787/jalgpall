using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormsApp1
{
    public partial class TreeForm : Form
    {
        TreeView tree;
        Button btn;
        Label lbl;
        bool isButtonVisible = false; 
        bool isLabelVisible = false; 

        public TreeForm()
        {
            this.Height = 600;
            this.Width = 800;
            this.Text = "Vorm põhielementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.BorderStyle = BorderStyle.Fixed3D;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode treeNode = new TreeNode("Elemendid");
            treeNode.Nodes.Add(new TreeNode("Nupp-Button"));
            btn = new Button();
            btn.Height = 40;
            btn.Width = 100;
            btn.Text = "CLICk";
            btn.Location = new Point(150, 50);
            btn.Click += Btn_Click;
            //label
            treeNode.Nodes.Add(new TreeNode("Silt-Label"));
            lbl = new Label();
            lbl.Text = "Pealkiri";
            lbl.Location = new Point(150, 0);
            lbl.Size = new Size(200, 50);
            lbl.BackColor = Color.Red;

            tree.Nodes.Add(treeNode);
            this.Controls.Add(tree);
        }

        private void Tree_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp-Button")
            {
                if (isButtonVisible)
                {
                    this.Controls.Remove(btn); 
                    isButtonVisible = false;
                }
                else
                {
                    this.Controls.Add(btn); 
                    isButtonVisible = true;
                }
                tree.SelectedNode = null;
            }
            else if (e.Node.Text == "Silt-Label")
            {
                if (isLabelVisible)
                {
                    this.Controls.Remove(lbl); 
                    isLabelVisible = false;
                }
                else
                {
                    this.Controls.Add(lbl); 
                    isLabelVisible = true;
                }
                tree.SelectedNode = null;

            }
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            if (btn.BackColor == Color.Aqua)
            {
                btn.BackColor = Color.Chocolate;
            }
            else
            {
                btn.BackColor = Color.Aqua;
            }
        }
    }
}
