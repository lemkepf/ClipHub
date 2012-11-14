using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

using System.Resources;
using System.Text;
using Hardcodet.Wpf.TaskbarNotification;
using WpfKlip.Core;
using WpfKlip.Core.Win;
using WpfKlip.Core.Win.Enums;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using Db4objects.Db4o.Linq;
using ClipHub.Code.Models;
using ClipHub.Code.Helpers;
using ClipHub.Code.DAO;
using System.Windows.Input;
using ClipHub;
using Microsoft.AspNet.SignalR.Client.Hubs;
using ClipHub.Code.Remote;

namespace ClipHub
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TaskbarIcon tb;
        public static Boolean skipNextPaste = false;
        public static IClipboardRepository clipRepository;
        private DateTime lastClipTime = DateTime.Now;
        public static RoutedCommand CustomRoutedCommand = new RoutedCommand();
        public static HubConnection hubConnection;
        public static IHubProxy clipRemoteProxy;
        
        public App()
        {
            clipRepository = new ClipboardRespository("clips.db");

            InitializeComponent();

            InitApplication();
        }

        private void InitApplication()
        {
            //initialize NotifyIcon

            tb = (TaskbarIcon)this.FindResource("TrayNotificationIcon");
            //tb = (TaskbarIcon)FindResource("TrayNotificationIcon");
            tb.Visibility = System.Windows.Visibility.Visible;

            CommandBinding binding = new CommandBinding(ApplicationCommands.Close);
            binding.Executed += contextMenuExecuted;
            binding.CanExecute += contextMenuCanExecute;
            tb.ContextMenu.CommandBindings.Add(binding);

            CommandBinding customCommandBinding = new CommandBinding(
            CustomRoutedCommand, contextMenuExecuted, contextMenuCanExecute);

            tb.ContextMenu.CommandBindings.Add(customCommandBinding);

            registerHotKeys();

            // Connect to the service
            hubConnection = new HubConnection("http://localhost:51304/");
            //hubConnection.Credentials.

            // Create a proxy to the chat service
            clipRemoteProxy = hubConnection.CreateHubProxy("clipboardHub");

            // Print the message when it comes in
            clipRemoteProxy.On<string, string>("newClip", (x, y) =>
            {
                gotNewClip(x, y);
            });

            // Start the connection
            hubConnection.Start();

        }

        public void gotNewClip(String clipContents, String applicationClippedFrom)
        {
            Console.WriteLine(clipContents);
        }

        private void registerHotKeys()
        {
            //bind to clipboard 
            ShellHook sh;
            ClipboardHelper ch;
            GlobalHotkeyHelper gh;
            System.Windows.Forms.Form f;

            f = new System.Windows.Forms.Form();
            sh = new ShellHook(f.Handle);
            //sh.WindowActivated += sh_WindowActivated;
            //sh.RudeAppActivated += sh_WindowActivated;
            ch = new ClipboardHelper(f.Handle);
            ch.ClipboardGrabbed += ch_ClipboardGrabbed;
            ch.RegisterClipboardListener();

            gh = new GlobalHotkeyHelper(f.Handle);
            gh.GlobalHotkeyFired += new GlobalHotkeyHandler(gh_GlobalHotkeyFired);

            //gh.RegisterHotKey(72783, KeyModifiers.Control, VirtualKeys.VK_COMMA);
            //gh.RegisterHotKey(72784, KeyModifiers.Alt, VirtualKeys.VK_PERIOD);
            gh.RegisterHotKey(72784, KeyModifiers.Control, VirtualKeys.VK_2);
        }

        void ch_ClipboardGrabbed(System.Windows.Forms.IDataObject dataObject)
        {
            TimeSpan variable =  DateTime.Now - lastClipTime;
            lastClipTime = DateTime.Now;

            if (skipNextPaste || variable.TotalMilliseconds < 500)
            {
                skipNextPaste = false;
                return;
            }


            var formats = dataObject.GetFormats();

            if (formats.Contains(DataFormats.Text))
            {
                var text = Clipboard.GetText();

                if (String.IsNullOrWhiteSpace(text))
                {
                    return;
                }

                var data = Clipboard.GetDataObject();

                ClipHub.Code.Models.ClipboardEntry newClip = new ClipHub.Code.Models.ClipboardEntry();
                newClip.clipboardContents = text;
                newClip.dateClipped = DateTime.Now;

                String title = GetActiveWindowTitle();
                newClip.applicationClippedFrom = title;

                clipRepository.Insert(newClip);
            }
            else if (formats.Contains(DataFormats.FileDrop))
            {
                //var files = dataObject.GetData(DataFormats.FileDrop) as string[];

                //if (CheckDuplicates(ItemsBox, (obj) =>
                //{
                //    string[] objasfiles = obj as string[];

                //    if (objasfiles != null && objasfiles.Length == files.Length)
                //    {

                //        // we need this since order may nto be preserved
                //        // e.g. when user selects file from l-to-r and 
                //        // and then r-to-l
                //        for (int i = 0; i < objasfiles.Length; i++)
                //        {
                //            if (!files.Contains(objasfiles[i]))
                //                return false;
                //        }

                //        return true;
                //    }
                //    return false;
                //}))
                //    return;

                //n = new FileDropsLBI(files);
            }
            else if (System.Windows.Clipboard.ContainsImage())
            {

                //System.Windows.Forms.IDataObject clipboardData = System.Windows.Forms.Clipboard.GetDataObject();
                //System.Drawing.Bitmap bitmap = (System.Drawing.Bitmap)clipboardData.GetData(
                //   System.Windows.Forms.DataFormats.Bitmap);

                //if (CheckDuplicates(ItemsBox, (obj) =>
                //{
                //    var taghash = obj as ImageHash;
                //    if (taghash == null)
                //    {
                //        return false;
                //    }

                //    else return ImageHash.Compare(taghash, new ImageHash(bitmap)) == ImageHash.CompareResult.ciCompareOk;
                //}))
                //    return;

                //n = new ImageLBI(bitmap);
            }

        }

        void gh_GlobalHotkeyFired(int id)
        {

            // show selection menu
            if (id == 72784)
            {
                SelectMenu select = new SelectMenu();

                select.Show();

                return;
            }

        }

        private String GetActiveWindowTitle()
        {
            IntPtr handle = IntPtr.Zero;          
            handle = User32.GetForegroundWindow();

            String title = Helpers.GetWindowText(handle);

            return title;
        }



        private int GetProcessThreadFromWindow(IntPtr hwnd)
        {
            int procid = 0;
            int threadid = User32.GetWindowThreadProcessId(hwnd, ref procid);
            return procid;
        }

        private void contextMenuCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void contextMenuExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if ("Settings".Equals(e.Parameter))
            {
                //show options
                Settings optionsWindow = new Settings();

                optionsWindow.Show();
            }
            else if ("About".Equals(e.Parameter))
            {
                //show about
            }
            else if (e.Command == ApplicationCommands.Close)
            {
                this.Shutdown();
            }
            
        }

        
    }
}
