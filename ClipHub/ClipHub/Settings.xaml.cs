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
using SignalR.Client.Hubs;

namespace ClipHub
{
    /// <summary>
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Settings : Window
    {

        delegate void updateCallback(string tekst);

        public Settings()
        {
            InitializeComponent();

            this.authKey.Text = Properties.Settings.Default.authKey;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.txtUsername.Text))
            {

                App.clipRemoteProxy.Invoke("authenticateDevice", txtUsername.Text, Guid.NewGuid());


                // Print the message when it comes in
                App.clipRemoteProxy.On<string>("authenticated", (x) =>
                {
                    UpdateElement(x);
                });
            }
        }

        private void UpdateElement(string tekst)
        {
            if (this.authKey.Dispatcher.CheckAccess() == false)
            {
                updateCallback uCallBack = new updateCallback(UpdateElement);
                this.Dispatcher.Invoke(uCallBack, tekst);
            }
            else
            {
                this.authKey.Text = tekst;
                Properties.Settings.Default.authKey = tekst;
                Properties.Settings.Default.Save();
            }
        }


    }
}
