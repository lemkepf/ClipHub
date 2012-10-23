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
using ClipHub.Code.Models;
using ClipHub.Code.Helpers;
using ClipHub.Code.DAO;
using MahApps.Metro.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WpfKlip.Core.Win;
using WindowsInput;

namespace ClipHub
{
    /// <summary>
    /// Interaction logic for SelectMenu.xaml
    /// </summary>
    public partial class SelectMenu : MetroWindow
    {
        //IDataAccess clipRepository;
        private static System.Windows.Forms.Timer filterTimer = new System.Windows.Forms.Timer();
        private readonly BackgroundWorker worker = new BackgroundWorker();
        private static ObservableCollection<ClipboardEntry> obsResults;
        private static String searchTerm;

        public static RoutedCommand CustomRoutedCommand = new RoutedCommand();

        public SelectMenu()
        {
            InitializeComponent();

            //handle filter to only do it every 200ms as they type
            filterTimer.Tick += new EventHandler(FilterTimerProcessor);
            filterTimer.Interval = 200;          

            //handle window closing
            Closing += delegate(object sender, CancelEventArgs e)
            {
                e.Cancel = true;

                this.Hide();
            };

            //right click menu binding
            CommandBinding customCommandBinding = new CommandBinding(
            CustomRoutedCommand, contextMenuExecuted, contextMenuCanExecute);

            this.ListClips.ContextMenu.CommandBindings.Add(customCommandBinding);

            //bind results
            List<ClipboardEntry> results = App.clipRepository.getAllClipboardentryList();

            ObservableCollection<ClipboardEntry> obsResults = new ObservableCollection<ClipboardEntry>(results);

            ListClips.DataContext = obsResults;

            txtSearch.Focus();

            //worker thread 
            worker.DoWork += worker_updateListFilter;
            worker.RunWorkerCompleted += worker_updateListFilterCompleted;

            //string line = null;
            //while ((line = Console.ReadLine()) != null)
            //{
            //    // Send a message to the server
            //    chat.Invoke("Send", line).Wait();
            //}
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
            if (String.IsNullOrWhiteSpace(searchTerm)){
                List<ClipboardEntry> results = App.clipRepository.getAllClipboardentryList();
                obsResults = new ObservableCollection<ClipboardEntry>(results);
            }else{
                List<ClipboardEntry> results = App.clipRepository.getAllClipboardentryListFilter(searchTerm);
                obsResults = new ObservableCollection<ClipboardEntry>(results);
            }
        }

        private void worker_updateListFilterCompleted(object sender,
                                               RunWorkerCompletedEventArgs e)
        {
            //update ui once worker complete his work
            ListClips.DataContext = obsResults;
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

        private void Show_Context_ForClipMouseDown(object sender, RoutedEventArgs e)
        {
 
            Button button = sender as Button;

            ClipboardEntry item = (ClipboardEntry)(sender as FrameworkElement).DataContext;

            int index = this.ListClips.Items.IndexOf(item);

            this.ListClips.SelectedIndex = index;

            ListView clip = (ListView)this.ListClips;

            if (clip != null)
            {
                clip.ContextMenu.PlacementTarget = button;
                clip.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Right;
                clip.ContextMenu.IsOpen = true;
            }
        }

        private void Pin_Item_MouseDown(object sender, RoutedEventArgs e)
        {
 
            Button button = sender as Button;

            ClipboardEntry item = (ClipboardEntry)(sender as FrameworkElement).DataContext;

            int index = this.ListClips.Items.IndexOf(item);

            this.ListClips.SelectedIndex = index;

            SetItemPinned(item);
        }

        private void SetItemPinned(ClipboardEntry item)
        {
            if (item.pinned == true)
            {
                item.pinned = false;
            }
            else
            {
                item.pinned = true;
            }

            App.clipRepository.Save(item);

            this.updateListFilter();
        }

        

        private void contextMenuCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void contextMenuExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if ("removeEntry".Equals(e.Parameter))
            {
                ClipboardEntry clip = (ClipboardEntry)this.ListClips.SelectedItem;
                if (clip != null)
                {
                    App.clipRepository.Delete(clip);
                    this.updateListFilter();
                }
            }
            else if ("setClipboard".Equals(e.Parameter))
            {
                this.setSelectedClip();
            }else if ("pinEntry".Equals(e.Parameter))
            {
                ClipboardEntry clip = (ClipboardEntry)this.ListClips.SelectedValue;

                if (clip != null)
                {
                    SetItemPinned(clip);
                }
            }
            else if ("pushToCloud".Equals(e.Parameter))
            {
                //TODO
            }           
        }



    }
}
