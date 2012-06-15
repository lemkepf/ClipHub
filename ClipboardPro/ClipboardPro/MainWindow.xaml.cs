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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfKlip.Core;
using WpfKlip.Core.Win;

namespace ClipboardPro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //bind to clipboard 
            ShellHook sh;
            ClipboardHelper ch;
            System.Windows.Forms.Form f;

            f = new System.Windows.Forms.Form();
            sh = new ShellHook(f.Handle);
            //sh.WindowActivated += sh_WindowActivated;
            //sh.RudeAppActivated += sh_WindowActivated;
            ch = new ClipboardHelper(f.Handle);
            ch.ClipboardGrabbed += ch_ClipboardGrabbed;
            ch.RegisterClipboardListener();


        }

        void ch_ClipboardGrabbed(System.Windows.Forms.IDataObject dataObject)
        {
            //try
            //{
            var formats = dataObject.GetFormats();
            //DataEnabledListBoxItem n = null;
            //var ItemsBox = mainWindow.ItemsBox;
            if (formats.Contains(DataFormats.Text))
            {
                var text = Clipboard.GetText();

                //if (Settings.Default.OmitEmptyStrings && String.IsNullOrEmpty(text))
                //{
                //    return;
                //}

                //if (Settings.Default.OmitWhitespacesOnlyString && String.IsNullOrEmpty(text.Trim()))
                //{
                //    return;
                //}

                //if (CheckDuplicates(ItemsBox, (obj) => (text as string) == (obj as string)))
                //    return;
                var data = Clipboard.GetDataObject();
                //n = new TextDataLBI(Clipboard.GetDataObject());
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

            //if (n != null)
            //{
            //    ItemsBox.Items.Insert(0, n);
            //    //n.ItemClicked += new ItemCopiedEventHandler(n_ItemClicked);
            //}

            /* Console.WriteLine("\r\n\r\n");

             for (int i = 0; i < ItemsBox.Items.Count; i++)
             {
                 Console.WriteLine("{0}:{1}", i, (ItemsBox.Items[i] as ListBoxItem).Tag);
             }*/
        }
    }

}
