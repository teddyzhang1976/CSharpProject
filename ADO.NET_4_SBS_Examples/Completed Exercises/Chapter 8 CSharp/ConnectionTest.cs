// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 8 - C# Version
//       by Tim Patrick

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Chapter_8_CSharp
{
    public partial class ConnectionTest : Form
    {
        // ----- Class to track text/value pairs in ComboBox controls.
        private class ItemData
        {
            public string ItemText;
            public int ItemValue;

            public ItemData(string initialText, int initialValue)
            {
                this.ItemText = initialText;
                this.ItemValue = initialValue;
            }

            public override string ToString()
            {
                return ItemText;
            }
        }

        public ConnectionTest()
        {
            InitializeComponent();
        }

        private SqlConnectionStringBuilder BuildConnection()
        {
            // ----- Build a connection string based on user settings.
            SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();

            try
            {
                // ----- Add the server name.
                if (LocalServer.Checked == true)
                    connection.DataSource = "(local)";
                else
                    connection.DataSource = ServerName.Text;
                if (IsExpressEdition.Checked == true)
                    connection.DataSource += @"\SQLEXPRESS";

                // ----- Add the authentication.
                if (AuthenticateWindows.Checked == true)
                    connection.IntegratedSecurity = true;
                else
                {
                    connection.IntegratedSecurity = false;
                    connection.UserID = UserName.Text;
                    connection.Password = UserPassword.Text;
                }

                // ----- Add the other settings.
                connection.InitialCatalog = InitialCatalog.Text;
                connection.ConnectTimeout = ((ItemData)ConnectionTimeout.SelectedItem).ItemValue;
                connection.MultipleActiveResultSets = EnableMarsSupport.Checked;

                // ----- Success.
                return connection;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void RefreshConnectionPreview()
        {
            // ----- Refresh the preview of the connection string.
            SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();

            try
            {
                // ----- Build the connection string from settings.
                connection = BuildConnection();
                if (connection == null)
                    ConnectionPreview.Text = "!! Error";
                else
                    ConnectionPreview.Text = connection.ConnectionString;
            }
            catch (Exception ex)
            {
                ConnectionPreview.Text = "!! Error";
            }
        }

        private void RemoteServer_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            // ----- Enable fields as needed.
            LabelServerName.Enabled = RemoteServer.Checked;
            ServerName.Enabled = RemoteServer.Checked;
            IsExpressEdition.Enabled = RemoteServer.Checked;

            // ----- Update the preview.
            RefreshConnectionPreview();
        }

        private void AuthenticateSqlServer_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            // ----- Enable fields as needed.
            LabelUserName.Enabled = AuthenticateSqlServer.Checked;
            UserName.Enabled = AuthenticateSqlServer.Checked;
            LabelPassword.Enabled = AuthenticateSqlServer.Checked;
            UserPassword.Enabled = AuthenticateSqlServer.Checked;

            // ----- Update the preview.
            RefreshConnectionPreview();
        }

        private void TextFields_Enter(System.Object sender, System.EventArgs e)
        {
            // ----- Highlight the entire text.
            ((TextBox)sender).SelectAll();
        }

        private void FieldUpdates(System.Object sender, System.EventArgs e)
        {
            // ----- Update the preview.
            RefreshConnectionPreview();
        }

        private void ActClose_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Exit the program.
            this.Close();
        }

        private void ActTest_Click(System.Object sender, System.EventArgs e)
        {
            // ----- See if the specified connection works.
            SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();
            SqlConnection testLink = null;

            try
            {
                // ----- Retrieve the connection.
                connection = BuildConnection();
                if (connection == null) return;

                // ----- Test the connection.
                testLink = new SqlConnection(connection.ConnectionString);
                testLink.Open();
                if (testLink.State == ConnectionState.Open)
                    MessageBox.Show("Connection opened successfully.");
                else
                    MessageBox.Show("Connection failed to open.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed with the following error: " +
                    ex.Message);
            }
            finally
            {
                if (testLink != null) testLink.Dispose();
            }
        }

        private void ConnectionTest_Load(System.Object sender, System.EventArgs e)
        {
            // ----- Fill in the list of timeout choices.
            ConnectionTimeout.Items.Add(new ItemData("15 Seconds", 15));
            ConnectionTimeout.Items.Add(new ItemData("30 Seconds", 30));
            ConnectionTimeout.Items.Add(new ItemData("45 Seconds", 45));
            ConnectionTimeout.Items.Add(new ItemData("60 Seconds", 60));
            ConnectionTimeout.SelectedIndex = 0;

            // ----- Show the initial connection string.
            RefreshConnectionPreview();
        }
    }
}
