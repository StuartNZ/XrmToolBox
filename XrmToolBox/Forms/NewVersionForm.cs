﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XrmToolBox.Forms
{
    public partial class NewVersionForm : Form
    {
        private const string style = "<style>*{font-family:Segoe UI;}</style>";
        private readonly string userName;
        private readonly string repositoryName;

        public NewVersionForm(string currentVersion, string newVersion, string description, string userName, string repositoryName)
        {
            InitializeComponent();

            lblCurrentVersion.Text = string.Format(lblCurrentVersion.Text, currentVersion);
            lblNewVersion.Text = string.Format(lblNewVersion.Text, newVersion);
            webBrowser1.DocumentText = style + description;
            webBrowser1.ScriptErrorsSuppressed = true;

            this.userName = userName;
            this.repositoryName = repositoryName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Process.Start(string.Format("https://github.com/{0}/{1}/releases",userName, repositoryName));
        }
    }
}
