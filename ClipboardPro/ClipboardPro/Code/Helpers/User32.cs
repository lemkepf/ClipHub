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
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using WpfKlip.Core.Win.Structs;
using WpfKlip.Core.Win.Enums;
using System.Security.Permissions;
using System.Drawing;
using System.Windows.Forms;

namespace WpfKlip.Core.Win
{
    class User32
    {


        [DllImport("user32.dll")]
        public static extern bool AddClipboardFormatListener(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

        [DllImport("shdocvw.dll", EntryPoint = "#118")]
        public static extern void ShellDDEInit(bool b);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool AnimateWindow(IntPtr hWnd, uint dwTime, FlagsAnimateWindow dwFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int AppendMenu(IntPtr MenuHandle, int Flags, int NewID, String Item);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool AttachThreadInput(IntPtr idAttach, IntPtr idAttachTo, bool fAttach);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT pt);

        [DllImport("user32.dll")]
        static extern IntPtr CreatePopupMenu();

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateWindowEx(uint dwExStyle, string lpClassName, string lpWindowName, uint dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateWindowEx(int dwExStyle, IntPtr atomClassName, string lpWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);


        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateWindowEx(int dwExStyle, string lpClassName, string lpWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, uint message, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll")]
        public static extern int DestroyIcon(IntPtr hIcon);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool DestroyWindow(IntPtr hwnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool DestroyMenu(IntPtr hwnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool DeregisterShellHookWindow(IntPtr hwnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern void DisableProcessWindowsGhosting();

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool DispatchMessage(ref MSG msg);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool DragDetect(IntPtr hWnd, Point pt);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool DrawFocusRect(IntPtr hWnd, ref RECT rect);

        [DllImport("User32.dll", SetLastError = false, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int DrawText(IntPtr hDC, string lpString, int nCount, ref RECT Rect, int wFormat);

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int EnableWindow(IntPtr hwnd, int fEnable);

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int EnableWindow(IntPtr hwnd, bool fEnable);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

        [DllImport("user32.dll", EntryPoint = "EndTask", SetLastError = true)]
        public static extern bool EndTask(IntPtr hwnd, bool shutdown, bool force);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool EnumWindows(EnumWindowsProc numFunc, IntPtr lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool EnumChildWindows(IntPtr hWndParent, EnumWindowsProc numFunc, IntPtr lParam);

        [DllImport("User32.dll", SetLastError = false, CharSet = CharSet.Auto)]
        public static extern int FillRect(IntPtr hDC, ref RECT rect, IntPtr hBrush);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string className, string windowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwnd, IntPtr afterChild, string className, string text);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetAncestor(IntPtr hwnd, int flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetAncestor(IntPtr hwnd, GetAncestorFlags flags);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern UInt16 GetAsyncKeyState(int vKey);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hwnd, StringBuilder className, int maxCount);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, GetClassLongOffsets offest);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClientRect(IntPtr hwnd, ref RECT lpRect);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClientRect(IntPtr hwnd, [In, Out] ref Rectangle rect);

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgnclip, uint fdwOptions);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetFocus();

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern ushort GetKeyState(int virtKey);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetMenuItemCount(IntPtr hMenu);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetSysColorBrush(int index);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetSystemMenu(IntPtr WindowHandle, bool bReset);

        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern int GetTabbedTextExtent(IntPtr hDC, string lpString, int nCount, int nTabPositions, ref int lpnTabStopPositions);

        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern bool GetGUIThreadInfo(uint threadid, out GUITHREADINFO guiinfo);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetTopWindow(IntPtr hwnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindow(IntPtr hwnd, int uCmd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindow(IntPtr hwnd, GetWindowContstants uCmd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [Obsolete("This function is unsafe. Use GetWindowLongPtr instead."),
         DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);

        [Obsolete("This function is unsafe. Use GetWindowLongPtr instead."),
         DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, GWLIndex nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowModuleFileName(IntPtr hwnd, ref System.Text.StringBuilder lpszFileName, int cchFileNameMax);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowRect(IntPtr hWnd, ref RECT rect);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetWindowRect(IntPtr hWnd, [In, Out] ref Rectangle rect);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowRgn(IntPtr hwnd, ref IntPtr rgn);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, [Out] StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern void GetWindowThreadProcessId(IntPtr hWnd, out IntPtr threadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, ref int procId);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool HideCaret(IntPtr hWnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int InsertMenu(IntPtr hMenu, int Position, int Flags, int NewId, String Item);

        [DllImport("user32.dll")]
        public static extern bool InsertMenuItem(IntPtr hMenu, int uItem, bool fByPosition,
           [In] ref MENUITEMINFO lpmii);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool InvalidateRect(IntPtr hWnd, ref RECT rect, bool erase);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern bool InvalidateRect(IntPtr hwnd, ref Rectangle rect, bool bErase);

        [DllImport("user32.dll", SetLastError = false, CharSet = CharSet.Auto)]
        public static extern int InvertRect(IntPtr hDC, ref RECT rect);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool IsChild(IntPtr hwndParent, IntPtr hwnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool IsHungAppWindow(IntPtr hwnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool IsIconic(IntPtr hwnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool IsWindow(IntPtr hwnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool IsWindowEnabled(IntPtr hWnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool IsWindowVisible(IntPtr hwnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool IsZoomed(IntPtr hwnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr LoadCursor(IntPtr hInstance, uint cursor);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern bool MessageBeep(BeepType Type);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax, uint wFlag);

        [DllImport("user32.dll")]
        public static extern bool PeekMessage(ref Message msg, IntPtr hwnd, int msgMin, int msgMax, int remove);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int PostMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool RedrawWindow(IntPtr hWnd, IntPtr rectUpdate, IntPtr hrgnUpdate, uint flags);

        [DllImport("user32.dll")]
        public static extern int RemoveMenu(IntPtr hMenu, int position, MenuItemFlags menuItemFlags);

        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern ushort RegisterClass(ref WNDCLASS wc);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.U2)]
        public static extern UInt16 RegisterClassEx([In] ref WNDCLASSEX lpwcx);

        //  RegisterShellHook Lib "shell32.dll" Alias "#181" (ByVal hwnd As IntPtr, ByVal flags As Integer) As Boolean

        [DllImport("User32.dll", CharSet = CharSet.Auto, EntryPoint = "#181")]
        public static extern bool RegisterShellHook(IntPtr hWnd, int flags);
        /// <summary>
        /// Registers a specified Shell window to receive certain messages for events or notifications that are useful to
        /// Shell applications. The event messages received are only those sent to the Shell window associated with the
        /// specified window's desktop. Many of the messages are the same as those that can be received after calling
        /// the SetWindowsHookEx function and specifying WH_SHELL for the hook type. The difference with
        /// RegisterShellHookWindow is that the messages are received through the specified window's WindowProc
        /// and not through a call back procedure. 
        /// </summary>
        /// <param name="hWnd">[in] Handle to the window to register for Shell hook messages.</param>
        /// <returns>TRUE if the function succeeds; FALSE if the function fails. </returns>
        /// <remarks>
        /// As with normal window messages, the second parameter of the window procedure identifies the
        /// message as a "WM_SHELLHOOKMESSAGE". However, for these Shell hook messages, the
        /// message value is not a pre-defined constant like other message identifiers (IDs) such as
        /// WM_COMMAND. The value must be obtained dynamically using a call to
        /// RegisterWindowMessage(TEXT("SHELLHOOK"));. This precludes handling these messages using
        /// a traditional switch statement which requires ID values that are known at compile time.
        /// For handling Shell hook messages, the normal practice is to code an If statement in the default
        /// section of your switch statement and then handle the message if the value of the message ID
        /// is the same as the value obtained from the RegisterWindowMessage call. 
        /// 
        /// for more see MSDN
        /// </remarks>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool RegisterShellHookWindow(IntPtr hWnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern uint RegisterTaskBar(IntPtr hWnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern uint RegisterWindowMessage(string Message);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ScreenToClient(IntPtr hWnd, ref POINT pt);

        [DllImport("User32.dll")]
        public static extern uint SendInput(uint numberOfInputs, [MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] KEYBOARD_INPUT[] input, int structSize);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern uint SendMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, WindowMessages Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, WindowMessages Msg, int wParam, int lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, int lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        /// <summary>
        /// An overloaded <c>SendMessage</c> for sending a TB_SETBUTTONINFO message.
        /// </summary>
        /// <param name="hWnd">The handle of the ToolBar.</param>
        /// <param name="Msg">TB_SETBUTTONINFO</param>
        /// <param name="wParam">The index to the ToolBarButton.</param>
        /// <param name="lParam">Pointer to a <see cref="TBBUTTONINFO"/> structure that contains the new button information.</param>
        /// <returns>Returns nonzero if successful, or zero otherwise.</returns>
        [DllImport("User32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, ref TBBUTTONINFO lParam);

        [DllImport("User32.dll")]
        public static extern int SendMessageTimeout(IntPtr hWnd, int uMsg, int wParam, int lParam, int fuFlags, int uTimeout, ref int lpdwResult);

        [DllImport("User32.dll")]
        public static extern int SendMessageTimeout(IntPtr hWnd, int uMsg, IntPtr wParam, IntPtr lParam, int fuFlags, int uTimeout, ref int lpdwResult);

        [DllImport("User32.dll")]
        public static extern IntPtr SendMessageTimeout(int p, IntPtr intPtr, IntPtr intPtr_3, int p_4, int timeout, ref int result);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetCursor(IntPtr hCursor);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetFocus(IntPtr hWnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowLong(IntPtr hWnd, GWLIndex nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowsHookEx(HookType code,
            HookProc func,
            IntPtr hInstance,
            int threadID);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern bool SetWindowText(IntPtr hwnd, string newText);

        [DllImport("user32.dll")]
        public static extern int UnhookWindowsHookEx(IntPtr hhook);

        [DllImport("user32.dll")]
        public static extern int CallNextHookEx(IntPtr hhook,
            int code, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool SetParent(IntPtr hWndChild, IntPtr hWnd);


        [DllImport("user32.dll")]
        public static extern void SetShellWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern int SetShellWindow(int hWnd);

        [DllImport("user32.dll")]
        public static extern int SetShellWindowEx(IntPtr hWnd, IntPtr Child);

        [DllImport("user32.dll")]
        static public extern void SetTaskmanWindow(IntPtr hwnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndAfter, int X, int Y, int Width, int Height, SetWindowPosFlags flags);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowPos(IntPtr hWnd, int hWndAfter, int X, int Y, int Width, int Height, SetWindowPosFlags flags);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowPos(IntPtr hWnd, SetWindowPosZ hWndAfter, int X, int Y, int Width, int Height, SetWindowPosFlags flags);

        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, int flags);

        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowPos(IntPtr hWnd, SetWindowPosZ hWndInsertAfter, int x, int y, int cx, int cy, int flags);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool redraw);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ShowCaret(IntPtr hWnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int ShowWindow(IntPtr hWnd, short cmdShow);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int ShowWindow(IntPtr hWnd, ShowWindowStyles cmdShow);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(SystemParametersInfoActions uAction, uint uParam, ref uint lpvParam, uint fuWinIni);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SystemParametersInfo(SPI uiAction, uint uiParam, ref MINIMIZEDMETRICS pvParam, uint fWinIni);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SystemParametersInfo(SPI uiAction, uint uiParam, StringBuilder pvParam, uint fWinIni);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SystemParametersInfo(SPI uiAction, uint uiParam, ref String pvParam, uint fWinIni);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SystemParametersInfo(SPI uiAction, uint uiParam, String pvParam, uint fWinIni);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SystemParametersInfo(SPI uiAction, uint uiParam, IntPtr pvParam, uint fWinIni);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SystemParametersInfo(SPI uiAction, uint uiParam, ref RECT pvParam, uint fWinIni);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        [DllImport("user32.DLL", SetLastError = false, CharSet = CharSet.Auto)]
        public static extern int TabbedTextOut(IntPtr hDC, int x, int y, string lpString, int nCount, int nTabPositions, ref int lpnTabStopPositions, int nTabOrigin);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool TrackMouseEvent(ref TRACKMOUSEEVENTS tme);

        [DllImport("User32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool TrackMouseEvent(TRACKMOUSEEVENT tme);

        [DllImport("user32.dll")]
        public static extern bool TrackPopupMenu(IntPtr hMenu, uint uFlags, int x, int y,
           int nReserved, IntPtr hWnd, IntPtr prcRect);

        [DllImport("user32.dll")]
        public static extern int TrackPopupMenuEx(IntPtr hMenu, uint uFlags, int x, int y,
           IntPtr hWnd, IntPtr prcRect);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool TranslateMessage(ref MSG msg);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool UnregisterClass(string lpClassName, IntPtr hInstance);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINT pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINT pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool UpdateWindow(IntPtr hwnd);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern bool ValidateRect(IntPtr hwnd, ref Rectangle rect);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool WaitMessage();

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr WindowFromPoint(POINT point);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetActiveWindow(IntPtr intPtr);


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers,
           int vk);

        [DllImport("user32.dll")]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr ChildWindowFromPointEx(IntPtr hwnd, POINT p, int flags);

        [DllImport("user32.dll")]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);


    }
}
