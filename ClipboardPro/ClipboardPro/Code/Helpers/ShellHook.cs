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
using System.Runtime.InteropServices;
using WpfKlip.Core.Win.Structs;
using WpfKlip.Core.Win.Enums;

namespace WpfKlip.Core.Win
{
    public unsafe delegate void GetMinRectShellHookEventHandler(ShellHook sender, SHELLHOOKINFO* rect);
    public delegate void GeneralShellHookEventHandler(ShellHook sender, IntPtr hWnd);
    public delegate void AppcommandShellHookEventHandler(ShellHook sender, APPCOMMAND command);
    public struct APPCOMMAND
    {
    }



    public class ShellHook : NativeWindow
    {
        uint WM_ShellHook;




        public ShellHook(IntPtr hWnd)
        {
            CreateParams cp = new CreateParams();

            /*// Fill in the CreateParams details.
            cp.Caption = "Click here";
            cp.ClassName = "Button";

            // Set the position on the form
            cp.X = 100;
            cp.Y = 100;
            cp.Height = 100;
            cp.Width = 100;

            // Specify the form as the parent.
            cp.Parent = User32.GetDesktopWindow();

            // Create as a child of the specified parent
            cp.Style = (int) WindowStyle.WS_POPUP;// WS_CHILD | WS_VISIBLE;
            cp.ExStyle = (int)WindowStyleEx.WS_EX_TOOLWINDOW;*/

            // Create the actual window
            this.CreateHandle(cp);


            // User32.SetShellWindow(hWnd);
            User32.SetTaskmanWindow(hWnd);
            if (User32.RegisterShellHookWindow(this.Handle))
            {
                WM_ShellHook = User32.RegisterWindowMessage("SHELLHOOK");
#if DEBUG
                Console.WriteLine("WM_ShellHook: " + WM_ShellHook.ToString());
#endif
            }

        }

        public void Deregister()
        {
            User32.RegisterShellHook(Handle, 0);
        }

        #region Shell events

        /// <summary>
        /// A top-level, unowned window has been created. The window exists when the system calls this hook.
        /// </summary>
        public event GeneralShellHookEventHandler WindowCreated;
        /// <summary>
        /// A top-level, unowned window is about to be destroyed. The window still exists when the system calls this hook.
        /// </summary>
        public event GeneralShellHookEventHandler WindowDestroyed;
        /// <summary>
        /// The shell should activate its main window.
        /// </summary>
        public event GeneralShellHookEventHandler ActivateShellWindow;
        /// <summary>
        /// The activation has changed to a different top-level, unowned window. 
        /// </summary>
        public event GeneralShellHookEventHandler WindowActivated;
        /// <summary>
        /// A window is being minimized or maximized. The system needs the coordinates of the minimized rectangle for the window. 
        /// </summary>
        public event GetMinRectShellHookEventHandler GetMinRect;
        /// <summary>
        /// The title of a window in the task bar has been redrawn. 
        /// </summary>
        public event GeneralShellHookEventHandler Redraw;
        /// <summary>
        /// The user has selected the task list. A shell application that provides a task list should return TRUE to prevent Microsoft Windows from starting its task list.
        /// </summary>
        public event GeneralShellHookEventHandler Taskman;
        /// <summary>
        /// Keyboard language was changed or a new keyboard layout was loaded.
        /// </summary>
        public event GeneralShellHookEventHandler Language;
        public event GeneralShellHookEventHandler Sysmenu;
        public event GeneralShellHookEventHandler EndTask;
        /// <summary>
        /// Windows 2000/XP: The accessibility state has changed. 
        /// </summary>
        public event GeneralShellHookEventHandler Accessibilitystate;
        /// <summary>
        /// Windows 2000/XP: The user completed an input event (for example, pressed an application command button on the mouse 
        /// or an application command key on the keyboard), and the application did not handle the WM_APPCOMMAND message generated by that input. 
        /// </summary>
        public event AppcommandShellHookEventHandler Appcommand;
        /// <summary>
        /// Windows XP: A top-level window is being replaced. The window exists when the system calls this hook. 
        /// </summary>
        public event GeneralShellHookEventHandler WindowReplaced;
        public event GeneralShellHookEventHandler WindowReplacing;
        public event GeneralShellHookEventHandler Flash;
        public event GeneralShellHookEventHandler RudeAppActivated;

        protected unsafe override void WndProc(ref Message m)
        {
            if (m.Msg == WM_ShellHook)
            {
                switch ((ShellEvents)m.WParam)
                {
                    case ShellEvents.HSHELL_WINDOWCREATED:
                        if (IsAppWindow(m.LParam))
                        {
                            OnWindowCreated(m.LParam);
                        }
#if TRACE_SHELL_HOOK
                        Console.WriteLine("HSHELL_WINDOWCREATED: " + m);
#endif
                        break;
                    case ShellEvents.HSHELL_WINDOWDESTROYED:
                        //  WindowWrapper.isDestroyed(m.LParam);
                        if (WindowDestroyed != null)
                        {
                            WindowDestroyed(this, m.LParam);
                        }
#if TRACE_SHELL_HOOK
                        Console.WriteLine("HSHELL_WINDOWDESTROYED: " + m);
#endif
                        break;
                    case ShellEvents.HSHELL_ACTIVATESHELLWINDOW:
                        if (ActivateShellWindow != null)
                        {
                            ActivateShellWindow(this, IntPtr.Zero);
                        }
#if TRACE_SHELL_HOOK
                        Console.WriteLine("HSHELL_ACTIVATESHELLWINDOW: " + m);
#endif
                        break;
                    case ShellEvents.HSHELL_WINDOWACTIVATED:
                        if (WindowActivated != null)
                        {
                            WindowActivated(this, m.LParam);
                        }
#if TRACE_SHELL_HOOK
                        Console.WriteLine("HSHELL_WINDOWACTIVATED: " + m);
#endif
                        break;
                    case ShellEvents.HSHELL_GETMINRECT:
                        if (GetMinRect != null)
                        {
                            SHELLHOOKINFO* ptr = (SHELLHOOKINFO*)m.LParam.ToPointer();
                            GetMinRect(this, ptr);
                        }
#if TRACE_SHELL_HOOK
                        Console.WriteLine("HSHELL_GETMINRECT: " + m);
#endif
                        break;
                    case ShellEvents.HSHELL_REDRAW:
                        if (Redraw != null)
                        {
                            Redraw(this, m.LParam);
                        }
#if TRACE_SHELL_HOOK
                        Console.WriteLine("HSHELL_REDRAW: " + m);
#endif
                        break;
                    case ShellEvents.HSHELL_TASKMAN:
                        if (Taskman != null)
                        {
                            Taskman(this, m.LParam);
                        }
#if TRACE_SHELL_HOOK
                        Console.WriteLine("HSHELL_TASKMAN: " + m);
#endif
                        break;
                    case ShellEvents.HSHELL_LANGUAGE:
                        if (Language != null)
                        {
                            Language(this, IntPtr.Zero);
                        }
#if TRACE_SHELL_HOOK
                        Console.WriteLine("HSHELL_LANGUAGE: " + m);
#endif
                        break;
                    case ShellEvents.HSHELL_SYSMENU:
                        if (Sysmenu != null)
                        {
                            Sysmenu(this, m.LParam);
                        }
#if TRACE_SHELL_HOOK
                        Console.WriteLine("HSHELL_SYSMENU: " + m);
#endif
                        break;
                    case ShellEvents.HSHELL_ENDTASK:
                        if (EndTask != null)
                        {
                            EndTask(this, m.LParam);
                        }
#if TRACE_SHELL_HOOK
                        Console.WriteLine("HSHELL_ENDTASK: " + m);
#endif
                        break;
                    case ShellEvents.HSHELL_ACCESSIBILITYSTATE:
                        if (Accessibilitystate != null)
                        {
                            Accessibilitystate(this, m.LParam);
                        }
#if TRACE_SHELL_HOOK
                        Console.WriteLine("HSHELL_ACCESSIBILITYSTATE: " + m);
#endif
                        break;
                    case ShellEvents.HSHELL_APPCOMMAND:
                        if (Appcommand != null)
                        {
                            throw new NotSupportedException("APPCOMMAND event currently not supported by shellhook");
                        }
#if TRACE_SHELL_HOOK
                        Console.WriteLine("HSHELL_APPCOMMAND: " + m);
#endif
                        break;
                    case ShellEvents.HSHELL_WINDOWREPLACED:
                        if (WindowReplaced != null)
                        {
                            WindowReplaced(this, m.LParam);
                        }
#if TRACE_SHELL_HOOK
                        Console.WriteLine("HSHELL_WINDOWREPLACED: " + m);
#endif
                        break;
                    case ShellEvents.HSHELL_WINDOWREPLACING:
                        if (WindowReplacing != null)
                        {
                            WindowReplacing(this, m.LParam);
                        }
#if TRACE_SHELL_HOOK
                        Console.WriteLine("HSHELL_WINDOWREPLACING: " + m);
#endif
                        break;
                    case ShellEvents.HSHELL_FLASH:
                        if (Flash != null)
                        {
                            Flash(this, m.LParam);
                        }
#if TRACE_SHELL_HOOK
                        Console.WriteLine("HSHELL_FLASH: " + m);
#endif
                        break;
                    case ShellEvents.HSHELL_RUDEAPPACTIVATED:
                        if (RudeAppActivated != null)
                        {
                            RudeAppActivated(this, m.LParam);
                        }
#if TRACE_SHELL_HOOK
                        Console.WriteLine("HSHELL_RUDEAPPACTIVATED: " + m);
#endif
                        break;
                    default:
                        break;
                }
            }
            base.WndProc(ref m);
        }

        #endregion

        #region Windows enumeration
        public void EnumWindows()
        {
            User32.EnumWindows(EnumWindowsProc, IntPtr.Zero);
        }

        bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam)
        {
            if (IsAppWindow(hWnd))
            {
                OnWindowCreated(hWnd);
            }
            return true;
        }

        bool OnWindowCreated(IntPtr hWnd)
        {
#if DEBUG
            Console.WriteLine("Window Created - Title: " + Helpers.GetWindowText(hWnd));
#endif
            if (WindowCreated != null)
            {
                WindowCreated(this, hWnd);
            }

            return true;
        }

        bool IsAppWindow(IntPtr hWnd)
        {
            if ((User32.GetWindowLong(hWnd, (int)GWLIndex.GWL_STYLE) & (int)WindowStyle.WS_SYSMENU) == 0) return false;

            if (User32.IsWindowVisible(hWnd))
            {
                if ((User32.GetWindowLong(hWnd, (int)GWLIndex.GWL_EXSTYLE) & (int)WindowStyleEx.WS_EX_TOOLWINDOW) == 0)
                {
                    if (User32.GetParent(hWnd) != null)
                    {
                        IntPtr hwndOwner = User32.GetWindow(hWnd, (int)GetWindowContstants.GW_OWNER);
                        if (hwndOwner != null &&
                        ((User32.GetWindowLong(hwndOwner, (int)GWLIndex.GWL_STYLE) & ((int)WindowStyle.WS_VISIBLE | (int)WindowStyle.WS_CLIPCHILDREN)) != ((int)WindowStyle.WS_VISIBLE | (int)WindowStyle.WS_CLIPCHILDREN)) ||
                        (User32.GetWindowLong(hwndOwner, (int)GWLIndex.GWL_EXSTYLE) & (int)WindowStyleEx.WS_EX_TOOLWINDOW) != 0)
                        {
                            return true;
                        }
                        else
                            return false;
                    }
                    else
                        return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        #endregion
    }
}
