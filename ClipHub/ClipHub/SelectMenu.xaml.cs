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
        private static System.Windows.Forms.Timer filterTimer = new System.Windows.Forms.Timer();
        private readonly BackgroundWorker worker = new BackgroundWorker();
        private static ObservableCollection<ClipboardEntry> obsResults;
        private static String searchTerm;

        public SelectMenu()
        {

            filterTimer.Tick += new EventHandler(FilterTimerProcessor);
            filterTimer.Interval = 200;

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

            worker.DoWork += worker_updateListFilter;
            worker.RunWorkerCompleted += worker_updateListFilterCompleted;
        }

        private void txtSearch_KeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Down:
                    if (this.ListClips.Items.Count > 0)
                    {
                        ListClips.Focus();
                        this.ListClips.SelectedIndex = 0;
                        var item = ListClips.ItemContainerGenerator.ContainerFromIndex(this.ListClips.SelectedIndex) as ListViewItem;
                        if (item != null)
                        {
                            item.Focus();
                        }
                    }

                    break;
                default:

                    break;
            }
        }

        private void worker_updateListFilter(object sender, DoWorkEventArgs e)
        {
            // run all background tasks here
            //filter
            List<ClipboardEntry> results = App.clipRepository.Where<ClipboardEntry>(a => a.clipboardContents.ToLower().Contains(searchTerm.ToLower())).OrderByDescending(p => p.dateClipped).ToList();

            obsResults = new ObservableCollection<ClipboardEntry>(results);

        }

        private void worker_updateListFilterCompleted(object sender,
                                               RunWorkerCompletedEventArgs e)
        {
            //update ui once worker complete his work
            ListClips.DataContext = obsResults;
            Console.WriteLine("Filtered " + DateTime.Now.ToLongTimeString());
        }

        private void updateListFilter()
        {
            searchTerm = this.txtSearch.Text;
            this.worker.RunWorkerAsync();

        }

        private void ListClips_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    if (this.ListClips.SelectedIndex == 0)
                    {
                        //set focus to search box
                        this.ListClips.SelectedIndex = -1;
                        this.txtSearch.Focus();                       
                    }
                    break;
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

            if (clip != null)
            {
                clip.setToClipboard();

                this.Hide();
            }
            //if (App.main != null)
            //{
            //TODO Make this an option to automatically paste, make it a context menu would be a good option too
            //    User32.SetActiveWindow(App.main);
            //    InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_V);
            //}


        }

        private void txtSearch_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            filterTimer.Stop();
            filterTimer.Start();
        }


        private void FilterTimerProcessor(Object myObject,
                                                EventArgs myEventArgs)
        {
            filterTimer.Stop();
            updateListFilter();
        }

        private void ListClips_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ClipboardEntry clip = (ClipboardEntry)this.ListClips.SelectedValue;

            if (clip != null)
            {
                PopupTxt.Text = clip.clipboardContents;
                ListPopup.IsOpen = true;
                ListPopup.Placement = System.Windows.Controls.Primitives.PlacementMode.Left;

                ListPopup.PlacementTarget = (UIElement)this.ListClips;
            }

            

        }

    }
}
