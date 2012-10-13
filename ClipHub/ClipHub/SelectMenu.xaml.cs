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
using WpfKlip.Core.Win;
using WindowsInput;

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

            List<ClipboardEntry> results = App.clipRepository.All<ClipboardEntry>().OrderByDescending(p => p.dateClipped).ToList();

            ObservableCollection<ClipboardEntry> obsResults = new ObservableCollection<ClipboardEntry>(results);

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
                    this.updateListFilter();
                    break;
            }
        }

        private void updateListFilter()
        {
            String searchTerm = this.txtSearch.Text;

            //filter
            List<ClipboardEntry> results = App.clipRepository.Where<ClipboardEntry>(a => a.clipboardContents.ToLower().Contains(searchTerm.ToLower())).OrderByDescending(p => p.dateClipped).ToList();

            ObservableCollection<ClipboardEntry> obsResults = new ObservableCollection<ClipboardEntry>(results);

            ListClips.DataContext = obsResults;

        }

        private void ListClips_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    //Get selected index, set this clip to the clipboard, close window. 
                    this.setSelectedClip();
                    break;
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
            this.setSelectedClip();
        }

        private void MetroWindow_LostFocus_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void setSelectedClip()
        {
            ClipboardEntry clip = (ClipboardEntry)this.ListClips.SelectedValue;

            clip.setToClipboard();

            this.Hide();

            if (App.main != null)
            {
                //TODO Make this an option to automatically paste, make it a context menu would be a good option too
                User32.SetActiveWindow(App.main);
                InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_V);
            }

            
        }

    }
}
