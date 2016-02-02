using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rnet.Classes;
using System.Threading;

namespace Rnet
{
    public partial class View : Form
    {
        TreeNode clients;
        TreeNode storages;
        List<TreeNode> storageNodes;
        List<TreeNode> clientNodes;

        public View()
        {
            InitializeComponent();

            lblStorageName.Text = "";

            this.clients = new TreeNode("Clients");
            this.storages = new TreeNode("Storages");

            UpdateTreeview();
        }

        private void UpdateTreeview()
        {
            
            this.clientNodes = new List<TreeNode>();
            this.storageNodes = new List<TreeNode>();
            this.tvStorage.Nodes.Clear();
            this.clients.Nodes.Clear();
            this.storages.Nodes.Clear();

            foreach (Storage s in SS.Storages)
            {
                TreeNode ret = new TreeNode(s.ID);

                //foreach (File f in s.Files)
                //{
                //    ret.Nodes.Add(new TreeNode(f.Name));
                //}

                storageNodes.Add(ret);
            }
            foreach (Client c in SS.Clients)
            {
                clientNodes.Add(new TreeNode(c.ID));
            }

            foreach (TreeNode t in this.clientNodes)
            {
                this.clients.Nodes.Add(t);
            }
            foreach (TreeNode t in this.storageNodes)
            {
                this.storages.Nodes.Add(t);
            }            

            tvStorage.Nodes.Add(this.clients);
            tvStorage.Nodes.Add(this.storages);
        }
        private void UpdateListBox(Storage storage)
        {
            lblStorageName.Text = storage.ID;

            lbFiles.Items.Clear();

            foreach (File f in storage.Files)
            {
                lbFiles.Items.Add(f.Name);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UpdateTreeview();
        }

        private void tvStorage_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //if (tvStorage.SelectedNode.Parent == this.storages)
            //{
            //    foreach (Storage s in SS.Storages)
            //    {
            //        if (s.ID == tvStorage.SelectedNode.Text)
            //        {
            //            UpdateListBox(s);
            //            break;
            //        }
            //    }
            //}
        }

        private void tvStorage_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (tvStorage.SelectedNode.Parent == this.storages)
            {
                foreach (Storage s in SS.Storages)
                {
                    if (s.ID == tvStorage.SelectedNode.Text)
                    {
                        UpdateListBox(s);
                        break;
                    }
                }
            }
        }
    }
}
