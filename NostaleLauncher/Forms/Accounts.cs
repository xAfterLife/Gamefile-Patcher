using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NostaleLauncher.Forms
{
    public partial class Accounts : Form
    {
        List<string> accounts = new List<string>();

        public Accounts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            accounts.Add(txtID.Text+ "|" + txtPW.Text);
            lvAccounts.Items.Add(txtID.Text);
            Globals.ACCOUNTS = accounts.ToArray();
        }

        private void Accounts_Load(object sender, EventArgs e)
        {
            accounts = Globals.ACCOUNTS.ToList();
            foreach (var account in Globals.ACCOUNTS)
            {
                lvAccounts.Items.Add(account.Split('|')[0]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            accounts.Remove(accounts.Where(x => x.StartsWith(lvAccounts.SelectedItems[0].Text)).FirstOrDefault());
            lvAccounts.Items.Remove(lvAccounts.SelectedItems[0]);
            Globals.ACCOUNTS = accounts.ToArray();
        }
    }
}
