#region License block
/*
Copyright (c) 2009 Khaprov Ilya (http://dead-trickster.com)
Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using WpfKlip.Core.Win.Enums;
using WpfKlip.Core.Win;
namespace WpfKlip.Core
{
    public delegate void GlobalHotkeyHandler(int id);

    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class GlobalHotkeyHelper : NativeWindow
    {
        Form parent;

        public GlobalHotkeyHelper(Form parent)
        {
            parent.HandleCreated += new EventHandler(this.OnHandleCreated);
            parent.HandleDestroyed += new EventHandler(this.OnHandleDestroyed);
            this.parent = parent;
        }

        public GlobalHotkeyHelper(IntPtr handle)
        {
            AssignHandle(handle);
        }

        // Listen for the control's window creation and then hook into it.
        internal void OnHandleCreated(object sender, EventArgs e)
        {
            // Window is now created, assign handle to NativeWindow.
            AssignHandle(((Form)sender).Handle);
        }

        internal void OnHandleDestroyed(object sender, EventArgs e)
        {
            // Window was destroyed, release hook.
            ReleaseHandle();
        }

        public override void ReleaseHandle()
        {
            base.ReleaseHandle();
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            WindowMessages wm = (WindowMessages)m.Msg;
            switch (wm)
            {
                case WindowMessages.WM_HOTKEY:
                    ProcessHotKey(m.WParam.ToInt32());
                    break;
            }
            base.WndProc(ref m);
        }

        public event GlobalHotkeyHandler GlobalHotkeyFired;

        private void ProcessHotKey(int id)
        {
            if (GlobalHotkeyFired != null)
            {
                GlobalHotkeyFired(id);
            }
        }

        public bool RegisterHotKey(int id, KeyModifiers modifiers, VirtualKeys vk)
        {
            return User32.RegisterHotKey(this.Handle, id, (uint)modifiers, (int)vk);
        }
    }
}
