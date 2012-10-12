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
using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using Db4objects.Db4o.Linq;
using ClipboardPro.Code.Models;
using ClipboardPro.Code.Helpers;
using ClipboardPro.Code.DAO;
using MahApps.Metro.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ClipboardPro
{
    /// <summary>
    /// Interaction logic for SelectMenu.xaml
    /// </summary>
    public partial class SelectMenu : MetroWindow
    {
        //IClipboardRepository clipRepository;

        public SelectMenu()
        {
            InitializeComponent();

            Closing += delegate(object sender, CancelEventArgs e)
            {
                e.Cancel = true;

                this.Hide();
            };

            //clipRepository = new ClipboardRepository();

            List<ClipboardEntry> results = App.clipRepository.All<ClipboardEntry>().OrderByDescending(p => p.dateClipped).ToList();

            ObservableCollection<ClipboardEntry> obsResults = new ObservableCollection<ClipboardEntry>(results);

            //List<ClipboardEntry> result = App.clipRepository.Where<ClipboardEntry>(d => d.dateClipped).Take(10).ToList();
            //populate clips

            ListClips.DataContext = obsResults;

            txtSearch.Focus();
        }

        private void txtSearch_KeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Down:
                    ListClips.Focus();
                    if (this.ListClips.Items.Count > 0)
                        this.ListClips.SelectedIndex = 0;
                    break;
                default:
                    String searchTerm = this.txtSearch.Text;
                    if (searchTerm.Length >= 1)
                    {
                        //filter
                        List<ClipboardEntry> results = App.clipRepository.Where<ClipboardEntry>(a => a.clipboardContents.Contains(searchTerm)).OrderByDescending(p => p.dateClipped).ToList();

                        ObservableCollection<ClipboardEntry> obsResults = new ObservableCollection<ClipboardEntry>(results);

                        //List<ClipboardEntry> result = App.clipRepository.Where<ClipboardEntry>(d => d.dateClipped).Take(10).ToList();
                        //populate clips

                        ListClips.DataContext = obsResults;


                    }

                    break;
            }
        }

        private void ListClips_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    //Get selected index, set this clip to the clipboard, close window. 
                    ClipboardEntry clip = (ClipboardEntry)this.ListClips.SelectedValue;
                    App.skipNextPaste = true;

                    Clipboard.SetText(clip.clipboardContents, TextDataFormat.Text);

                    this.Hide();
                    break;
                //TODO: handle typing again. 
                //case Key:
                //    this.txtSearch.Focus();
                //    break;
            }
        }

        private void MetroWindow_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    this.Hide();
                    break;
            }
        }

        void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ClipboardEntry clip = (ClipboardEntry)this.ListClips.SelectedValue;
            App.skipNextPaste = true;

            Clipboard.SetText(clip.clipboardContents, TextDataFormat.Text);

            this.Hide();
        }

        private void MetroWindow_LostFocus_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

    }
}
