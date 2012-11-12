using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClipHub.Code.Remote;
using SignalR.Client.Hubs;

namespace ClipHub
{
    /// <summary>
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Settings : Window
    {

        delegate void updateCallback(string authKey);

        public Settings()
        {
            InitializeComponent();

            //this.authKey.Text = Properties.Settings.Default.authKey;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.txtUsername.Text))
            {
                string CurrentMachineName = Environment.MachineName;

                RemoteServices clipRemoteServices = new RemoteServices();

                if (clipRemoteServices.authenticateDevice(txtUsername.Text, txtPassw.Text, CurrentMachineName) == true)
                {
                    //good to go. 
                }
                //App.clipRemoteProxy.Invoke("authenticateDevice", txtUsername.Text, txtPassw.Text, CurrentMachineName);

                // Print the message when it comes in
                //App.clipRemoteProxy.On<string>("authenticated", (x) =>
                //{
                //    UpdateAuthKey(x);
                //});


            }
        }

        private void btnUnlink(object sender, RoutedEventArgs e)
        {

        }


    }
}
