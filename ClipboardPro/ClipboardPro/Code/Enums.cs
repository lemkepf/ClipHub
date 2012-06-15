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

#region Using directives
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.ComponentModel;
#endregion

namespace WpfKlip.Core.Win.Enums
{
    #region Window Class Styles enum
    public enum WINCLS : uint
    {
        CS_VREDRAW = 0x0001,
        CS_HREDRAW = 0x0002,
        CS_DBLCLKS = 0x0008,
        CS_OWNDC = 0x0020,
        CS_CLASSDC = 0x0040,
        CS_PARENTDC = 0x0080,
        CS_NOCLOSE = 0x0200,
        CS_SAVEBITS = 0x0800,
        CS_BYTEALIGNCLIENT = 0x1000,
        CS_BYTEALIGNWINDOW = 0x2000,
        CS_GLOBALCLASS = 0x4000,

        CS_IME = 0x00010000,

        // defined if #if(_WIN32_WINNT >= 0x0501)
        CS_DROPSHADOW = 0x00020000
    }
    #endregion //Window Class Styles enum

    #region GetAncestorFlags enum
    public enum GetAncestorFlags
    {
        GA_PARENT = 1,
        GA_ROOT = 2,
        GA_ROOTOWNER = 3
    }
    #endregion

    #region GetClassLongOffsets enum
    public enum GetClassLongOffsets
    {
        GCL_MENUNAME = (-8),
        GCL_HBRBACKGROUND = (-10),
        GCL_HCURSOR = (-12),
        GCL_HICON = (-14),
        GCL_HMODULE = (-16),
        GCL_CBWNDEXTRA = (-18),
        GCL_CBCLSEXTRA = (-20),
        GCL_WNDPROC = (-24),
        GCL_STYLE = (-26),
        GCW_ATOM = (-32),
        GCL_HICONSM = (-34),
        GCLP_MENUNAME = (-8),
        GCLP_HBRBACKGROUND = (-10),
        GCLP_HCURSOR = (-12),
        GCLP_HICON = (-14),
        GCLP_HMODULE = (-16),
        GCLP_WNDPROC = (-24),
        CLP_HICONSM = (-34)
    }
    #endregion

    #region GetFileIconFlags enum
    public enum GetFileIconFlags
    {
        // get icon
        SHGFI_ICON = 256,
        // get display name
        SHGFI_DISPLAYNAME = 512,
        // get type name
        SHGFI_TYPENAME = 1024,
        // get attributes
        SHGFI_ATTRIBUTES = 2048,
        // get icon location
        SHGFI_ICONLOCATION = 4096,
        // return exe type
        SHGFI_EXETYPE = 8192,
        // get system icon index
        SHGFI_SYSICONINDEX = 16384,
        // put a link overlay on icon
        SHGFI_LINKOVERLAY = 32768,
        // show icon in selected state
        SHGFI_SELECTED = 65536,

        //Windows 2000+
        // get only specified attributes
        SHGFI_ATTR_SPECIFIED = 131072,

        // get large icon
        SHGFI_LARGEICON = 0,
        // get small icon
        SHGFI_SMALLICON = 1,
        // get open icon
        SHGFI_OPENICON = 2,
        // get shell size icon
        SHGFI_SHELLICONSIZE = 4,
        // pszPath is a pidl
        SHGFI_PIDL = 8,
        // use passed dwFileAttribute
        SHGFI_USEFILEATTRIBUTES = 16,
        //IE 5+
        // apply the appropriate overlays
        SHGFI_ADDOVERLAYS = 32,
        // Get the index of the overlay
        SHGFI_OVERLAYINDEX = 64,
        // in the upper 8 bits of the iIcon
    }
    #endregion

    #region PeekMessageOptions
    [Flags]
    public enum PeekMessageOptions
    {
        PM_NOREMOVE = 0x0000,
        PM_REMOVE = 0x0001,
        PM_NOYIELD = 0x0002
    }
    #endregion // PeekMessageOptions

    #region SetWindowPosFlags
    [Flags]
    public enum SetWindowPosFlags : uint
    {
        SWP_NOSIZE = 0x0001,
        SWP_NOMOVE = 0x0002,
        SWP_NOZORDER = 0x0004,
        SWP_NOREDRAW = 0x0008,
        SWP_NOACTIVATE = 0x0010,
        SWP_FRAMECHANGED = 0x0020,
        SWP_SHOWWINDOW = 0x0040,
        SWP_HIDEWINDOW = 0x0080,
        SWP_NOCOPYBITS = 0x0100,
        SWP_NOOWNERZORDER = 0x0200,
        SWP_NOSENDCHANGING = 0x0400,
        SWP_DRAWFRAME = 0x0020,
        SWP_NOREPOSITION = 0x0200,
        SWP_DEFERERASE = 0x2000,
        SWP_ASYNCWINDOWPOS = 0x4000
    }
    #endregion //SetWindowPosFlags

    #region RedrawWindowOptions enum
    [Flags]
    public enum RedrawWindowOptions
    {
        RDW_INVALIDATE = 0x0001,
        RDW_publicPA = 0x0002,
        RDW_ERASE = 0x0004,
        RDW_VALIDATE = 0x0008,
        RDW_NOpublicPAINT = 0x0010,
        RDW_NOERASE = 0x0020,
        RDW_NOCHILDREN = 0x0040,
        RDW_ALLCHILDREN = 0x0080,
        RDW_UPDATENOW = 0x0100,
        RDW_ERASENOW = 0x0200,
        RDW_FRAME = 0x0400,
        RDW_NOFRAME = 0x0800
    }
    #endregion //SetWindowPositionOptions

    #region SendMessageTimeoutFlags
    public enum SendMessageTimeoutFlags
    {
        SMTO_NORMAL = 0x0000,
        SMTO_BLOCK = 0x0001,
        SMTO_ABORTIFHUNG = 0x0002,
        SMTO_NOTIMEOUTIFNOTHUNG = 0x0008,
        SMTO_ERRORONEXIT = 0x0020
    }
    #endregion

    #region SetWindowPositionOptions enum
    [Flags]
    public enum SetWindowPosOptions
    {
        SWP_NOSIZE = 0x0001,
        SWP_NOMOVE = 0x0002,
        SWP_NOZORDER = 0x0004,
        SWP_NOACTIVATE = 0x0010,
        SWP_FRAMECHANGED = 0x0020,
        SWP_SHOWWINDOW = 0x0040,
        SWP_NOOWNERZORDER = 0x0200,
        SWP_NOSENDCHANGING = 0x0400
    }
    #endregion

    #region SetWindowPosZ enum
    public enum SetWindowPosZ
    {
        HWND_TOP = 0,
        HWND_BOTTOM = 1,
        HWND_TOPMOST = -1,
        HWND_NOTOPMOST = -2
    }
    #endregion //SetWindowPosZ

    #region ShellEvents enum
    public enum ShellEvents
    {
        HSHELL_WINDOWCREATED = 1,
        HSHELL_WINDOWDESTROYED = 2,
        HSHELL_ACTIVATESHELLWINDOW = 3,

        HSHELL_WINDOWACTIVATED = 4,
        HSHELL_GETMINRECT = 5,
        HSHELL_REDRAW = 6,
        HSHELL_TASKMAN = 7,
        HSHELL_LANGUAGE = 8,
        HSHELL_SYSMENU = 9,
        HSHELL_ENDTASK = 10,
        HSHELL_ACCESSIBILITYSTATE = 11,
        HSHELL_APPCOMMAND = 12,
        HSHELL_WINDOWREPLACED = 13,
        HSHELL_WINDOWREPLACING = 14,
        HSHELL_HIGHBIT = 0x8000,
        HSHELL_FLASH = (HSHELL_REDRAW | HSHELL_HIGHBIT),
        HSHELL_RUDEAPPACTIVATED = (HSHELL_WINDOWACTIVATED | HSHELL_HIGHBIT)
    }
    #endregion

    #region ShowWindowStyles enum
    public enum ShowWindowStyles : short
    {
        SW_HIDE = 0,
        SW_SHOWNORMAL = 1,
        SW_NORMAL = 1,
        SW_SHOWMINIMIZED = 2,
        SW_SHOWMAXIMIZED = 3,
        SW_MAXIMIZE = 3,
        SW_SHOWNOACTIVATE = 4,
        SW_SHOW = 5,
        SW_MINIMIZE = 6,
        SW_SHOWMINNOACTIVE = 7,
        SW_SHOWNA = 8,
        SW_RESTORE = 9,
        SW_SHOWDEFAULT = 10,
        SW_FORCEMINIMIZE = 11,
        SW_MAX = 11
    }
    #endregion //ShowWindowStyles

    #region WindowStyle enum
    public enum WindowStyle : int
    {
        WS_OVERLAPPED = 0x00000000,
        WS_POPUP = -2147483648,
        WS_CHILD = 0x40000000,
        WS_MINIMIZE = 0x20000000,
        WS_VISIBLE = 0x10000000,
        WS_DISABLED = 0x08000000,
        WS_CLIPSIBLINGS = 0x04000000,
        WS_CLIPCHILDREN = 0x02000000,
        WS_MAXIMIZE = 0x01000000,
        WS_CAPTION = 0x00C00000,
        WS_BORDER = 0x00800000,
        WS_DLGFRAME = 0x00400000,
        WS_VSCROLL = 0x00200000,
        WS_HSCROLL = 0x00100000,
        WS_SYSMENU = 0x00080000,
        WS_THICKFRAME = 0x00040000,
        WS_GROUP = 0x00020000,
        WS_TABSTOP = 0x00010000,
        WS_MINIMIZEBOX = 0x00020000,
        WS_MAXIMIZEBOX = 0x00010000,
        WS_TILED = WS_OVERLAPPED,
        WS_ICONIC = WS_MINIMIZE,
        WS_SIZEBOX = WS_THICKFRAME,
        WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW,
        WS_OVERLAPPEDWINDOW = (WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU |
        WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX),
        WS_POPUPWINDOW = (WS_POPUP | WS_BORDER | WS_SYSMENU),
        WS_CHILDWINDOW = (WS_CHILD),
    }
    #endregion //WindowStyle

    #region WindowStyleEx enum
    public enum WindowStyleEx : int
    {
        WS_EX_DLGMODALFRAME = 0x00000001,
        WS_EX_NOPARENTNOTIFY = 0x00000004,
        WS_EX_TOPMOST = 0x00000008,
        WS_EX_ACCEPTFILES = 0x00000010,
        WS_EX_TRANSPARENT = 0x00000020,
        WS_EX_MDICHILD = 0x00000040,
        WS_EX_TOOLWINDOW = 0x00000080,
        WS_EX_WINDOWEDGE = 0x00000100,
        WS_EX_CLIENTEDGE = 0x00000200,
        WS_EX_CONTEXTHELP = 0x00000400,
        WS_EX_RIGHT = 0x00001000,
        WS_EX_LEFT = 0x00000000,
        WS_EX_RTLREADING = 0x00002000,
        WS_EX_LTRREADING = 0x00000000,
        WS_EX_LEFTSCROLLBAR = 0x00004000,
        WS_EX_RIGHTSCROLLBAR = 0x00000000,
        WS_EX_CONTROLPARENT = 0x00010000,
        WS_EX_STATICEDGE = 0x00020000,
        WS_EX_APPWINDOW = 0x00040000,
        WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE),
        WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST),
        WS_EX_LAYERED = 0x00080000,
        WS_EX_NOINHERITLAYOUT = 0x00100000, // Disable inheritence of mirroring by children
        WS_EX_LAYOUTRTL = 0x00400000, // Right to left mirroring
        WS_EX_COMPOSITED = 0x02000000,
        WS_EX_NOACTIVATE = 0x08000000,
    }
    #endregion //WindowStyleEx

    #region Virtual Keys enum
    [Flags]
    public enum VirtualKeys
    {
        VK_LBUTTON = 0x01,
        VK_CANCEL = 0x03,
        VK_BACK = 0x08,
        VK_TAB = 0x09,
        VK_CLEAR = 0x0C,
        VK_RETURN = 0x0D,
        VK_SHIFT = 0x10,
        VK_CONTROL = 0x11,
        VK_MENU = 0x12,
        VK_CAPITAL = 0x14,
        VK_ESCAPE = 0x1B,
        VK_SPACE = 0x20,
        VK_PRIOR = 0x21,
        VK_NEXT = 0x22,
        VK_END = 0x23,
        VK_HOME = 0x24,
        VK_LEFT = 0x25,
        VK_UP = 0x26,
        VK_RIGHT = 0x27,
        VK_DOWN = 0x28,
        VK_SELECT = 0x29,
        VK_EXECUTE = 0x2B,
        VK_SNAPSHOT = 0x2C,
        VK_HELP = 0x2F,
        VK_0 = 0x30,
        VK_1 = 0x31,
        VK_2 = 0x32,
        VK_3 = 0x33,
        VK_4 = 0x34,
        VK_5 = 0x35,
        VK_6 = 0x36,
        VK_7 = 0x37,
        VK_8 = 0x38,
        VK_9 = 0x39,
        VK_A = 0x41,
        VK_B = 0x42,
        VK_C = 0x43,
        VK_D = 0x44,
        VK_E = 0x45,
        VK_F = 0x46,
        VK_G = 0x47,
        VK_H = 0x48,
        VK_I = 0x49,
        VK_J = 0x4A,
        VK_K = 0x4B,
        VK_L = 0x4C,
        VK_M = 0x4D,
        VK_N = 0x4E,
        VK_O = 0x4F,
        VK_P = 0x50,
        VK_Q = 0x51,
        VK_R = 0x52,
        VK_S = 0x53,
        VK_T = 0x54,
        VK_U = 0x55,
        VK_V = 0x56,
        VK_W = 0x57,
        VK_X = 0x58,
        VK_Y = 0x59,
        VK_Z = 0x5A,
        VK_NUMPAD0 = 0x60,
        VK_NUMPAD1 = 0x61,
        VK_NUMPAD2 = 0x62,
        VK_NUMPAD3 = 0x63,
        VK_NUMPAD4 = 0x64,
        VK_NUMPAD5 = 0x65,
        VK_NUMPAD6 = 0x66,
        VK_NUMPAD7 = 0x67,
        VK_NUMPAD8 = 0x68,
        VK_NUMPAD9 = 0x69,
        VK_MULTIPLY = 0x6A,
        VK_ADD = 0x6B,
        VK_SEPARATOR = 0x6C,
        VK_SUBTRACT = 0x6D,
        VK_DECIMAL = 0x6E,
        VK_DIVIDE = 0x6F,
        VK_ATTN = 0xF6,
        VK_CRSEL = 0xF7,
        VK_EXSEL = 0xF8,
        VK_EREOF = 0xF9,
        VK_PLAY = 0xFA,
        VK_ZOOM = 0xFB,
        VK_NONAME = 0xFC,
        VK_PA1 = 0xFD,
        VK_OEM_CLEAR = 0xFE,
        VK_LWIN = 0x5B,
        VK_RWIN = 0x5C,
        VK_APPS = 0x5D,
        VK_LSHIFT = 0xA0,
        VK_RSHIFT = 0xA1,
        VK_LCONTROL = 0xA2,
        VK_RCONTROL = 0xA3,
        VK_LMENU = 0xA4,
        VK_RMENU = 0xA5
    }
    #endregion // Virtual Keys

    #region WindowMessages enum
    public enum WindowMessages
    {
        WM_NULL = 0x0000,
        WM_CREATE = 0x0001,
        WM_DESTROY = 0x0002,
        WM_MOVE = 0x0003,
        WM_SIZE = 0x0005,
        WM_ACTIVATE = 0x0006,
        WM_SETFOCUS = 0x0007,
        WM_KILLFOCUS = 0x0008,
        WM_ENABLE = 0x000A,
        WM_SETREDRAW = 0x000B,
        WM_SETTEXT = 0x000C,
        WM_GETTEXT = 0x000D,
        WM_GETTEXTLENGTH = 0x000E,
        WM_PAINT = 0x000F,
        WM_CLOSE = 0x0010,
        WM_QUERYENDSESSION = 0x0011,
        WM_QUIT = 0x0012,
        WM_QUERYOPEN = 0x0013,
        WM_ERASEBKGND = 0x0014,
        WM_SYSCOLORCHANGE = 0x0015,
        WM_ENDSESSION = 0x0016,
        WM_SHOWWINDOW = 0x0018,
        WM_WININICHANGE = 0x001A,
        WM_SETTINGCHANGE = 0x001A,
        WM_DEVMODECHANGE = 0x001B,
        WM_ACTIVATEAPP = 0x001C,
        WM_FONTCHANGE = 0x001D,
        WM_TIMECHANGE = 0x001E,
        WM_CANCELMODE = 0x001F,
        WM_SETCURSOR = 0x0020,
        WM_MOUSEACTIVATE = 0x0021,
        WM_CHILDACTIVATE = 0x0022,
        WM_QUEUESYNC = 0x0023,
        WM_GETMINMAXINFO = 0x0024,
        WM_PAINTICON = 0x0026,
        WM_ICONERASEBKGND = 0x0027,
        WM_NEXTDLGCTL = 0x0028,
        WM_SPOOLERSTATUS = 0x002A,
        WM_DRAWITEM = 0x002B,
        WM_MEASUREITEM = 0x002C,
        WM_DELETEITEM = 0x002D,
        WM_VKEYTOITEM = 0x002E,
        WM_CHARTOITEM = 0x002F,
        WM_SETFONT = 0x0030,
        WM_GETFONT = 0x0031,
        WM_SETHOTKEY = 0x0032,
        WM_GETHOTKEY = 0x0033,
        WM_QUERYDRAGICON = 0x0037,
        WM_COMPAREITEM = 0x0039,
        WM_GETOBJECT = 0x003D,
        WM_COMPACTING = 0x0041,
        WM_COMMNOTIFY = 0x0044,
        WM_WINDOWPOSCHANGING = 0x0046,
        WM_WINDOWPOSCHANGED = 0x0047,
        WM_POWER = 0x0048,
        WM_COPYDATA = 0x004A,
        WM_CANCELJOURNAL = 0x004B,
        WM_NOTIFY = 0x004E,
        WM_INPUTLANGCHANGEREQUEST = 0x0050,
        WM_INPUTLANGCHANGE = 0x0051,
        WM_TCARD = 0x0052,
        WM_HELP = 0x0053,
        WM_USERCHANGED = 0x0054,
        WM_NOTIFYFORMAT = 0x0055,
        WM_CONTEXTMENU = 0x007B,
        WM_STYLECHANGING = 0x007C,
        WM_STYLECHANGED = 0x007D,
        WM_DISPLAYCHANGE = 0x007E,
        WM_GETICON = 0x007F,
        WM_SETICON = 0x0080,
        WM_NCCREATE = 0x0081,
        WM_NCDESTROY = 0x0082,
        WM_NCCALCSIZE = 0x0083,
        WM_NCHITTEST = 0x0084,
        WM_NCPAINT = 0x0085,
        WM_NCACTIVATE = 0x0086,
        WM_GETDLGCODE = 0x0087,
        WM_SYNCPAINT = 0x0088,
        WM_NCMOUSEMOVE = 0x00A0,
        WM_NCLBUTTONDOWN = 0x00A1,
        WM_NCLBUTTONUP = 0x00A2,
        WM_NCLBUTTONDBLCLK = 0x00A3,
        WM_NCRBUTTONDOWN = 0x00A4,
        WM_NCRBUTTONUP = 0x00A5,
        WM_NCRBUTTONDBLCLK = 0x00A6,
        WM_NCMBUTTONDOWN = 0x00A7,
        WM_NCMBUTTONUP = 0x00A8,
        WM_NCMBUTTONDBLCLK = 0x00A9,
        WM_KEYDOWN = 0x0100,
        WM_KEYUP = 0x0101,
        WM_CHAR = 0x0102,
        WM_DEADCHAR = 0x0103,
        WM_SYSKEYDOWN = 0x0104,
        WM_SYSKEYUP = 0x0105,
        WM_SYSCHAR = 0x0106,
        WM_SYSDEADCHAR = 0x0107,
        WM_KEYLAST = 0x0108,
        WM_IME_STARTCOMPOSITION = 0x010D,
        WM_IME_ENDCOMPOSITION = 0x010E,
        WM_IME_COMPOSITION = 0x010F,
        WM_IME_KEYLAST = 0x010F,
        WM_INITDIALOG = 0x0110,
        WM_COMMAND = 0x0111,
        WM_SYSCOMMAND = 0x0112,
        WM_TIMER = 0x0113,
        WM_HSCROLL = 0x0114,
        WM_VSCROLL = 0x0115,
        WM_INITMENU = 0x0116,
        WM_INITMENUPOPUP = 0x0117,
        WM_MENUSELECT = 0x011F,
        WM_MENUCHAR = 0x0120,
        WM_ENTERIDLE = 0x0121,
        WM_MENURBUTTONUP = 0x0122,
        WM_MENUDRAG = 0x0123,
        WM_MENUGETOBJECT = 0x0124,
        WM_UNINITMENUPOPUP = 0x0125,
        WM_MENUCOMMAND = 0x0126,
        WM_CTLCOLORMSGBOX = 0x0132,
        WM_CTLCOLOREDIT = 0x0133,
        WM_CTLCOLORLISTBOX = 0x0134,
        WM_CTLCOLORBTN = 0x0135,
        WM_CTLCOLORDLG = 0x0136,
        WM_CTLCOLORSCROLLBAR = 0x0137,
        WM_CTLCOLORSTATIC = 0x0138,
        WM_MOUSEFIRST = 0x0200,
        WM_MOUSEMOVE = 0x0200,
        WM_LBUTTONDOWN = 0x0201,
        WM_LBUTTONUP = 0x0202,
        WM_LBUTTONDBLCLK = 0x0203,
        WM_RBUTTONDOWN = 0x0204,
        WM_RBUTTONUP = 0x0205,
        WM_RBUTTONDBLCLK = 0x0206,
        WM_MBUTTONDOWN = 0x0207,
        WM_MBUTTONUP = 0x0208,
        WM_MBUTTONDBLCLK = 0x0209,
        WM_PARENTNOTIFY = 0x0210,
        WM_ENTERMENULOOP = 0x0211,
        WM_EXITMENULOOP = 0x0212,
        WM_NEXTMENU = 0x0213,
        WM_SIZING = 0x0214,
        WM_CAPTURECHANGED = 0x0215,
        WM_MOVING = 0x0216,
        WM_DEVICECHANGE = 0x0219,
        WM_MDICREATE = 0x0220,
        WM_MDIDESTROY = 0x0221,
        WM_MDIACTIVATE = 0x0222,
        WM_MDIRESTORE = 0x0223,
        WM_MDINEXT = 0x0224,
        WM_MDIMAXIMIZE = 0x0225,
        WM_MDITILE = 0x0226,
        WM_MDICASCADE = 0x0227,
        WM_MDIICONARRANGE = 0x0228,
        WM_MDIGETACTIVE = 0x0229,
        WM_MDISETMENU = 0x0230,
        WM_ENTERSIZEMOVE = 0x0231,
        WM_EXITSIZEMOVE = 0x0232,
        WM_DROPFILES = 0x0233,
        WM_MDIREFRESHMENU = 0x0234,
        WM_IME_SETCONTEXT = 0x0281,
        WM_IME_NOTIFY = 0x0282,
        WM_IME_CONTROL = 0x0283,
        WM_IME_COMPOSITIONFULL = 0x0284,
        WM_IME_SELECT = 0x0285,
        WM_IME_CHAR = 0x0286,
        WM_IME_REQUEST = 0x0288,
        WM_IME_KEYDOWN = 0x0290,
        WM_IME_KEYUP = 0x0291,
        WM_MOUSEWHEEL = 0x020A,
        WM_MOUSEHOVER = 0x02A1,
        WM_NCMOUSELEAVE = 0x02A2,
        WM_MOUSELEAVE = 0x02A3,
        WM_MOUSELAST = 0x020D,
        WM_CUT = 0x0300,
        WM_COPY = 0x0301,
        WM_PASTE = 0x0302,
        WM_CLEAR = 0x0303,
        WM_UNDO = 0x0304,
        WM_RENDERFORMAT = 0x0305,
        WM_RENDERALLFORMATS = 0x0306,
        WM_DESTROYCLIPBOARD = 0x0307,
        WM_DRAWCLIPBOARD = 0x0308,
        WM_PAINTCLIPBOARD = 0x0309,
        WM_VSCROLLCLIPBOARD = 0x030A,
        WM_SIZECLIPBOARD = 0x030B,
        WM_ASKCBFORMATNAME = 0x030C,
        WM_CHANGECBCHAIN = 0x030D,
        WM_HSCROLLCLIPBOARD = 0x030E,
        WM_QUERYNEWPALETTE = 0x030F,
        WM_PALETTEISCHANGING = 0x0310,
        WM_PALETTECHANGED = 0x0311,
        WM_HOTKEY = 0x0312,
        WM_PRINT = 0x0317,
        WM_PRINTCLIENT = 0x0318,
        WM_HANDHELDFIRST = 0x0358,
        WM_HANDHELDLAST = 0x035F,
        WM_AFXFIRST = 0x0360,
        WM_AFXLAST = 0x037F,
        WM_PENWINFIRST = 0x0380,
        WM_PENWINLAST = 0x038F,
        WM_APP = 0x8000,
        WM_USER = 0x0400,
        WM_RASDIALEVENT = 0xCCCD,
        EM_GETCHARFORMAT = WM_USER + 58,
        TB_SETBUTTONINFO = WM_USER + 66,
        EM_SETCHARFORMAT = WM_USER + 68,
        WM_CLIPBOARDUPDATE = 0x031D
    }
    #endregion //WindowMessages

    #region WMACTIVEState enum
    public enum WMACTIVEState : int
    {

        WA_INACTIVE = 0,
        WA_ACTIVE = 1,
        WA_CLICKACTIVE = 2
    }
    #endregion //WMACTIVEState enum

    #region WM_MOUSEACTIVATEReturnCodes enum
    ///<summary>
    /// WM_MOUSEACTIVATE Return Codes
    ///</summary>
    public enum WM_MOUSEACTIVATEReturnCodes : int
    {
        MA_ACTIVATE = 1,
        MA_ACTIVATEANDEAT = 2,
        MA_NOACTIVATE = 3,
        MA_NOACTIVATEANDEAT = 4
    }
    #endregion //WM_MOUSEACTIVATEReturnCodes enum

    #region Temporary WindowMessage enum
    /*public enum WindowMessage
    {
        WM_NULL = 0x0000,
        WM_CREATE = 0x0001,
        WM_DESTROY = 0x0002,
        WM_MOVE = 0x0003,
        WM_SIZE = 0x0005,
        WM_ACTIVATE = 0x0006,
        WM_SETFOCUS = 0x0007,
        WM_KILLFOCUS = 0x0008,
        WM_ENABLE = 0x000A,
        WM_SETREDRAW = 0x000B,
        WM_SETTEXT = 0x000C,
        WM_GETTEXT = 0x000D,
        WM_GETTEXTLENGTH = 0x000E,
        WM_PAINT = 0x000F,
        WM_CLOSE = 0x0010,
        WM_QUERYENDSESSION = 0x0011,
        WM_QUIT = 0x0012,
        WM_QUERYOPEN = 0x0013,
        WM_ERASEBKGND = 0x0014,
        WM_SYSCOLORCHANGE = 0x0015,
        WM_ENDSESSION = 0x0016,
        WM_SHOWWINDOW = 0x0018,
        WM_CTLCOLOR = 0x0019,
        WM_WININICHANGE = 0x001A,
        WM_SETTINGCHANGE = 0x001A,
        WM_DEVMODECHANGE = 0x001B,
        WM_ACTIVATEAPP = 0x001C,
        WM_FONTCHANGE = 0x001D,
        WM_TIMECHANGE = 0x001E,
        WM_CANCELMODE = 0x001F,
        WM_SETCURSOR = 0x0020,
        WM_MOUSEACTIVATE = 0x0021,
        WM_CHILDACTIVATE = 0x0022,
        WM_QUEUESYNC = 0x0023,
        WM_GETMINMAXINFO = 0x0024,
        WM_PAINTICON = 0x0026,
        WM_ICONERASEBKGND = 0x0027,
        WM_NEXTDLGCTL = 0x0028,
        WM_SPOOLERSTATUS = 0x002A,
        WM_DRAWITEM = 0x002B,
        WM_MEASUREITEM = 0x002C,
        WM_DELETEITEM = 0x002D,
        WM_VKEYTOITEM = 0x002E,
        WM_CHARTOITEM = 0x002F,
        WM_SETFONT = 0x0030,
        WM_GETFONT = 0x0031,
        WM_SETHOTKEY = 0x0032,
        WM_GETHOTKEY = 0x0033,
        WM_QUERYDRAGICON = 0x0037,
        WM_COMPAREITEM = 0x0039,
        WM_GETOBJECT = 0x003D,
        WM_COMPACTING = 0x0041,
        WM_COMMNOTIFY = 0x0044,
        WM_WINDOWPOSCHANGING = 0x0046,
        WM_WINDOWPOSCHANGED = 0x0047,
        WM_POWER = 0x0048,
        WM_COPYDATA = 0x004A,
        WM_CANCELJOURNAL = 0x004B,
        WM_NOTIFY = 0x004E,
        WM_INPUTLANGCHANGEREQUEST = 0x0050,
        WM_INPUTLANGCHANGE = 0x0051,
        WM_TCARD = 0x0052,
        WM_HELP = 0x0053,
        WM_USERCHANGED = 0x0054,
        WM_NOTIFYFORMAT = 0x0055,
        WM_CONTEXTMENU = 0x007B,
        WM_STYLECHANGING = 0x007C,
        WM_STYLECHANGED = 0x007D,
        WM_DISPLAYCHANGE = 0x007E,
        WM_GETICON = 0x007F,
        WM_SETICON = 0x0080,
        WM_NCCREATE = 0x0081,
        WM_NCDESTROY = 0x0082,
        WM_NCCALCSIZE = 0x0083,
        WM_NCHITTEST = 0x0084,
        WM_NCPAINT = 0x0085,
        WM_NCACTIVATE = 0x0086,
        WM_GETDLGCODE = 0x0087,
        WM_SYNCPAINT = 0x0088,
        WM_NCMOUSEMOVE = 0x00A0,
        WM_NCLBUTTONDOWN = 0x00A1,
        WM_NCLBUTTONUP = 0x00A2,
        WM_NCLBUTTONDBLCLK = 0x00A3,
        WM_NCRBUTTONDOWN = 0x00A4,
        WM_NCRBUTTONUP = 0x00A5,
        WM_NCRBUTTONDBLCLK = 0x00A6,
        WM_NCMBUTTONDOWN = 0x00A7,
        WM_NCMBUTTONUP = 0x00A8,
        WM_NCMBUTTONDBLCLK = 0x00A9,
        WM_KEYDOWN = 0x0100,
        WM_KEYUP = 0x0101,
        WM_CHAR = 0x0102,
        WM_DEADCHAR = 0x0103,
        WM_SYSKEYDOWN = 0x0104,
        WM_SYSKEYUP = 0x0105,
        WM_SYSCHAR = 0x0106,
        WM_SYSDEADCHAR = 0x0107,
        WM_KEYLAST = 0x0108,
        WM_IME_STARTCOMPOSITION = 0x010D,
        WM_IME_ENDCOMPOSITION = 0x010E,
        WM_IME_COMPOSITION = 0x010F,
        WM_IME_KEYLAST = 0x010F,
        WM_INITDIALOG = 0x0110,
        WM_Element = 0x0111,
        WM_COMMAND = 0x0111,
        WM_SYSElement = 0x0112,
        WM_TIMER = 0x0113,
        WM_HSCROLL = 0x0114,
        WM_VSCROLL = 0x0115,
        WM_INITMENU = 0x0116,
        WM_INITMENUPOPUP = 0x0117,
        WM_MENUSELECT = 0x011F,
        WM_MENUCHAR = 0x0120,
        WM_ENTERIDLE = 0x0121,
        WM_MENURBUTTONUP = 0x0122,
        WM_MENUDRAG = 0x0123,
        WM_MENUGETOBJECT = 0x0124,
        WM_UNINITMENUPOPUP = 0x0125,
        WM_MENUElement = 0x0126,
        WM_CTLCOLORMSGBOX = 0x0132,
        WM_CTLCOLOREDIT = 0x0133,
        WM_CTLCOLORLISTBOX = 0x0134,
        WM_CTLCOLORBTN = 0x0135,
        WM_CTLCOLORDLG = 0x0136,
        WM_CTLCOLORSCROLLBAR = 0x0137,
        WM_CTLCOLORSTATIC = 0x0138,
        WM_MOUSEMOVE = 0x0200,
        WM_LBUTTONDOWN = 0x0201,
        WM_LBUTTONUP = 0x0202,
        WM_LBUTTONDBLCLK = 0x0203,
        WM_RBUTTONDOWN = 0x0204,
        WM_RBUTTONUP = 0x0205,
        WM_RBUTTONDBLCLK = 0x0206,
        WM_MBUTTONDOWN = 0x0207,
        WM_MBUTTONUP = 0x0208,
        WM_MBUTTONDBLCLK = 0x0209,
        WM_MOUSEWHEEL = 0x020A,
        WM_PARENTNOTIFY = 0x0210,
        WM_ENTERMENULOOP = 0x0211,
        WM_EXITMENULOOP = 0x0212,
        WM_NEXTMENU = 0x0213,
        WM_SIZING = 0x0214,
        WM_CAPTURECHANGED = 0x0215,
        WM_MOVING = 0x0216,
        WM_DEVICECHANGE = 0x0219,
        WM_MDICREATE = 0x0220,
        WM_MDIDESTROY = 0x0221,
        WM_MDIACTIVATE = 0x0222,
        WM_MDIRESTORE = 0x0223,
        WM_MDINEXT = 0x0224,
        WM_MDIMAXIMIZE = 0x0225,
        WM_MDITILE = 0x0226,
        WM_MDICASCADE = 0x0227,
        WM_MDIICONARRANGE = 0x0228,
        WM_MDIGETACTIVE = 0x0229,
        WM_MDISETMENU = 0x0230,
        WM_ENTERSIZEMOVE = 0x0231,
        WM_EXITSIZEMOVE = 0x0232,
        WM_DROPFILES = 0x0233,
        WM_MDIREFRESHMENU = 0x0234,
        WM_IME_SETCONTEXT = 0x0281,
        WM_IME_NOTIFY = 0x0282,
        WM_IME_CONTROL = 0x0283,
        WM_IME_COMPOSITIONFULL = 0x0284,
        WM_IME_SELECT = 0x0285,
        WM_IME_CHAR = 0x0286,
        WM_IME_REQUEST = 0x0288,
        WM_IME_KEYDOWN = 0x0290,
        WM_IME_KEYUP = 0x0291,
        WM_MOUSEHOVER = 0x02A1,
        WM_MOUSELEAVE = 0x02A3,
        WM_CUT = 0x0300,
        WM_COPY = 0x0301,
        WM_PASTE = 0x0302,
        WM_CLEAR = 0x0303,
        WM_UNDO = 0x0304,
        WM_RENDERFORMAT = 0x0305,
        WM_RENDERALLFORMATS = 0x0306,
        WM_DESTROYCLIPBOARD = 0x0307,
        WM_DRAWCLIPBOARD = 0x0308,
        WM_PAINTCLIPBOARD = 0x0309,
        WM_VSCROLLCLIPBOARD = 0x030A,
        WM_SIZECLIPBOARD = 0x030B,
        WM_ASKCBFORMATNAME = 0x030C,
        WM_CHANGECBCHAIN = 0x030D,
        WM_HSCROLLCLIPBOARD = 0x030E,
        WM_QUERYNEWPALETTE = 0x030F,
        WM_PALETTEISCHANGING = 0x0310,

        WM_PALETTECHANGED = 0x0311,
        WM_HOTKEY = 0x0312,
        WM_PRINT = 0x0317,
        WM_PRINTCLIENT = 0x0318,
        WM_HANDHELDFIRST = 0x0358,
        WM_HANDHELDLAST = 0x035F,
        WM_AFXFIRST = 0x0360,
        WM_AFXLAST = 0x037F,
        WM_PENWINFIRST = 0x0380,
        WM_PENWINLAST = 0x038F,
        WM_APP = 0x8000,
        WM_USER = 0x0400,
        WM_REFLECT = WM_USER + 0x1c00,
        WM_THEMECHANGED = 794,
    }*/
    #endregion

    #region SystemCommands enum
    public enum SystemCommands
    {
        SC_SIZE = 0xF000,
        SC_MOVE = 0xF010,
        SC_MINIMIZE = 0xF020,
        SC_MAXIMIZE = 0xF030,
        SC_MAXIMIZE2 = 0xF032,	// fired from double-click on caption
        SC_NEXTWINDOW = 0xF040,
        SC_PREVWINDOW = 0xF050,
        SC_CLOSE = 0xF060,
        SC_VSCROLL = 0xF070,
        SC_HSCROLL = 0xF080,
        SC_MOUSEMENU = 0xF090,
        SC_KEYMENU = 0xF100,
        SC_ARRANGE = 0xF110,
        SC_RESTORE = 0xF120,
        SC_RESTORE2 = 0xF122,	// fired from double-click on caption
        SC_TASKLIST = 0xF130,
        SC_SCREENSAVE = 0xF140,
        SC_HOTKEY = 0xF150,
        SC_DEFAULT = 0xF160,
        SC_MONITORPOWER = 0xF170,
        SC_CONTEXTHELP = 0xF180,
        SC_SEPARATOR = 0xF00F
    }

    #endregion // SystemCommands

    #region Cursors enum
    public enum Cursors : uint
    {
        IDC_ARROW = 32512U,
        IDC_IBEAM = 32513U,
        IDC_WAIT = 32514U,
        IDC_CROSS = 32515U,
        IDC_UPARROW = 32516U,
        IDC_SIZE = 32640U,
        IDC_ICON = 32641U,
        IDC_SIZENWSE = 32642U,
        IDC_SIZENESW = 32643U,
        IDC_SIZEWE = 32644U,
        IDC_SIZENS = 32645U,
        IDC_SIZEALL = 32646U,
        IDC_NO = 32648U,
        IDC_HAND = 32649U,
        IDC_APPSTARTING = 32650U,
        IDC_HELP = 32651U
    }
    #endregion //Cursors

    #region TRACK_MODE_TYPE enum
    public enum TRACK_MODE_TYPE { YellowMode2, XAForm2, CDDA }
    #endregion

    #region TrackMouseEventFlags enum
    [Flags]
    public enum TrackMouseEventFlags : uint
    {
        TME_HOVER = 1,
        TME_LEAVE = 2,
        TME_QUERY = 0x40000000,
        TME_CANCEL = 0x80000000,
        TME_NONCLIENT = 0x00000010
    }
    #endregion //TrackMouseEventFlags

    #region MouseActivateFlags enum
    public enum MouseActivateFlags
    {
        MA_ACTIVATE = 1,
        MA_ACTIVATEANDEAT = 2,
        MA_NOACTIVATE = 3,
        MA_NOACTIVATEANDEAT = 4
    }
    #endregion //MouseActivateFlags

    #region DialogCodes enum
    public enum DialogCodes
    {
        DLGC_WANTARROWS = 0x0001,
        DLGC_WANTTAB = 0x0002,
        DLGC_WANTALLKEYS = 0x0004,
        DLGC_WANTMESSAGE = 0x0004,
        DLGC_HASSETSEL = 0x0008,
        DLGC_DEFPUSHBUTTON = 0x0010,
        DLGC_UNDEFPUSHBUTTON = 0x0020,
        DLGC_RADIOBUTTON = 0x0040,
        DLGC_WANTCHARS = 0x0080,
        DLGC_STATIC = 0x0100,
        DLGC_BUTTON = 0x2000
    }
    #endregion //MouseActivateFlags

    #region UpdateLayeredWindowsFlags enum
    public enum UpdateLayeredWindowsFlags
    {
        ULW_COLORKEY = 0x00000001,
        ULW_ALPHA = 0x00000002,
        ULW_OPAQUE = 0x00000004
    }
    #endregion //UpdateLayeredWindowsFlags

    #region AlphaFlags enum
    public enum AlphaFlags : byte
    {
        AC_SRC_OVER = 0x00,
        AC_SRC_ALPHA = 0x01
    }
    #endregion //AlphaFlags

    #region TernaryRasterOperations enum
    public enum TernaryRasterOperations
    {
        SRCCOPY = 0x00CC0020, /* dest = source*/
        SRCPAINT = 0x00EE0086, /* dest = source OR dest*/
        SRCAND = 0x008800C6, /* dest = source AND dest*/
        SRCINVERT = 0x00660046, /* dest = source XOR dest*/
        SRCERASE = 0x00440328, /* dest = source AND (NOT dest )*/
        NOTSRCCOPY = 0x00330008, /* dest = (NOT source)*/
        NOTSRCERASE = 0x001100A6, /* dest = (NOT src) AND (NOT dest) */
        MERGECOPY = 0x00C000CA, /* dest = (source AND pattern)*/
        MERGEPAINT = 0x00BB0226, /* dest = (NOT source) OR dest*/
        PATCOPY = 0x00F00021, /* dest = pattern*/
        PATPAINT = 0x00FB0A09, /* dest = DPSnoo*/
        PATINVERT = 0x005A0049, /* dest = pattern XOR dest*/
        DSTINVERT = 0x00550009, /* dest = (NOT dest)*/
        BLACKNESS = 0x00000042, /* dest = BLACK*/
        WHITENESS = 0x00FF0062, /* dest = WHITE*/
    };
    #endregion //TernaryRasterOperations

    #region BrushStyles enum
    public enum BrushStyles
    {
        BS_SOLID = 0,
        BS_NULL = 1,
        BS_HOLLOW = 1,
        BS_HATCHED = 2,
        BS_PATTERN = 3,
        BS_INDEXED = 4,
        BS_DIBPATTERN = 5,
        BS_DIBPATTERNPT = 6,
        BS_PATTERN8X8 = 7,
        BS_DIBPATTERN8X8 = 8,
        BS_MONOPATTERN = 9
    }
    #endregion //BrushStyles

    #region HatchStyles enum
    public enum HatchStyles
    {
        HS_HORIZONTAL = 0,
        HS_VERTICAL = 1,
        HS_FDIAGONAL = 2,
        HS_BDIAGONAL = 3,
        HS_CROSS = 4,
        HS_DIAGCROSS = 5
    }
    #endregion //HatchStyles

    #region CombineFlags
    public enum CombineFlags
    {
        RGN_AND = 1,
        RGN_OR = 2,
        RGN_XOR = 3,
        RGN_DIFF = 4,
        RGN_COPY = 5
    }
    #endregion //CombineFlags

    #region NCHITTEST enum
    /// <summary>
    /// Location of cursor hot spot returnet in WM_NCHITTEST.
    /// </summary>
    public enum NCHITTEST
    {
        /// <summary>
        /// On the screen background or on a dividing line between windows 
        /// (same as HTNOWHERE, except that the DefWindowProc function produces a system beep to indicate an error).
        /// </summary>
        HTERROR = (-2),
        /// <summary>
        /// In a window currently covered by another window in the same thread 
        /// (the message will be sent to underlying windows in the same thread until one of them returns a code that is not HTTRANSPARENT).
        /// </summary>
        HTTRANSPARENT = (-1),
        /// <summary>
        /// On the screen background or on a dividing line between windows.
        /// </summary>
        HTNOWHERE = 0,
        /// <summary>In a client area.</summary>
        HTCLIENT = 1,
        /// <summary>In a title bar.</summary>
        HTCAPTION = 2,
        /// <summary>In a window menu or in a Close button in a child window.</summary>
        HTSYSMENU = 3,
        /// <summary>In a size box (same as HTSIZE).</summary>
        HTGROWBOX = 4,
        /// <summary>In a menu.</summary>
        HTMENU = 5,
        /// <summary>In a horizontal scroll bar.</summary>
        HTHSCROLL = 6,
        /// <summary>In the vertical scroll bar.</summary>
        HTVSCROLL = 7,
        /// <summary>In a Minimize button.</summary>
        HTMINBUTTON = 8,
        /// <summary>In a Maximize button.</summary>
        HTMAXBUTTON = 9,
        /// <summary>In the left border of a resizable window 
        /// (the user can click the mouse to resize the window horizontally).</summary>
        HTLEFT = 10,
        /// <summary>
        /// In the right border of a resizable window 
        /// (the user can click the mouse to resize the window horizontally).
        /// </summary>
        HTRIGHT = 11,
        /// <summary>In the upper-horizontal border of a window.</summary>
        HTTOP = 12,
        /// <summary>In the upper-left corner of a window border.</summary>
        HTTOPLEFT = 13,
        /// <summary>In the upper-right corner of a window border.</summary>
        HTTOPRIGHT = 14,
        /// <summary>	In the lower-horizontal border of a resizable window 
        /// (the user can click the mouse to resize the window vertically).</summary>
        HTBOTTOM = 15,
        /// <summary>In the lower-left corner of a border of a resizable window 
        /// (the user can click the mouse to resize the window diagonally).</summary>
        HTBOTTOMLEFT = 16,
        /// <summary>	In the lower-right corner of a border of a resizable window 
        /// (the user can click the mouse to resize the window diagonally).</summary>
        HTBOTTOMRIGHT = 17,
        /// <summary>In the border of a window that does not have a sizing border.</summary>
        HTBORDER = 18,
        HTOBJECT = 19,
        /// <summary>In a Close button.</summary>
        HTCLOSE = 20,
        /// <summary>In a Help button.</summary>
        HTHELP = 21,
    }
    #endregion //NCHITTEST

    #region SystemParametersInfoActions enum
    public enum SystemParametersInfoActions : uint
    {
        GetBeep = 1,
        SetBeep = 2,
        GetMouse = 3,
        SetMouse = 4,
        GetBorder = 5,
        SetBorder = 6,
        GetKeyboardSpeed = 10,
        SetKeyboardSpeed = 11,
        LangDriver = 12,
        IconHorizontalSpacing = 13,
        GetScreenSaveTimeout = 14,
        SetScreenSaveTimeout = 15,
        GetScreenSaveActive = 16,
        SetScreenSaveActive = 17,
        GetGridGranularity = 18,
        SetGridGranularity = 19,
        SetDeskWallPaper = 20,
        SetDeskPattern = 21,
        GetKeyboardDelay = 22,
        SetKeyboardDelay = 23,
        IconVerticalSpacing = 24,
        GetIconTitleWrap = 25,
        SetIconTitleWrap = 26,
        GetMenuDropAlignment = 27,
        SetMenuDropAlignment = 28,
        SetDoubleClkWidth = 29,
        SetDoubleClkHeight = 30,
        GetIconTitleLogFont = 31,
        SetDoubleClickTime = 32,
        SetMouseButtonSwap = 33,
        SetIconTitleLogFont = 34,
        GetFastTaskSwitch = 35,
        SetFastTaskSwitch = 36,
        SetDragFullWindows = 37,
        GetDragFullWindows = 38,
        GetNonClientMetrics = 41,
        SetNonClientMetrics = 42,
        GetMinimizedMetrics = 43,
        SetMinimizedMetrics = 44,
        GetIconMetrics = 45,
        SetIconMetrics = 46,
        SetWorkArea = 47,
        GetWorkArea = 48,
        SetPenWindows = 49,
        GetFilterKeys = 50,
        SetFilterKeys = 51,
        GetToggleKeys = 52,
        SetToggleKeys = 53,
        GetMouseKeys = 54,
        SetMouseKeys = 55,
        GetShowSounds = 56,
        SetShowSounds = 57,
        GetStickyKeys = 58,
        SetStickyKeys = 59,
        GetAccessTimeout = 60,
        SetAccessTimeout = 61,
        GetSerialKeys = 62,
        SetSerialKeys = 63,
        GetSoundsEntry = 64,
        SetSoundsEntry = 65,
        GetHighContrast = 66,
        SetHighContrast = 67,
        GetKeyboardPref = 68,
        SetKeyboardPref = 69,
        GetScreenReader = 70,
        SetScreenReader = 71,
        GetAnimation = 72,
        SetAnimation = 73,
        GetFontSmoothing = 74,
        SetFontSmoothing = 75,
        SetDragWidth = 76,
        SetDragHeight = 77,
        SetHandHeld = 78,
        GetLowPowerTimeout = 79,
        GetPowerOffTimeout = 80,
        SetLowPowerTimeout = 81,
        SetPowerOffTimeout = 82,
        GetLowPowerActive = 83,
        GetPowerOffActive = 84,
        SetLowPowerActive = 85,
        SetPowerOffActive = 86,
        SetCursors = 87,
        SetIcons = 88,
        GetDefaultInputLang = 89,
        SetDefaultInputLang = 90,
        SetLangToggle = 91,
        GetWindwosExtension = 92,
        SetMouseTrails = 93,
        GetMouseTrails = 94,
        ScreenSaverRunning = 97,
        GetMouseHoverTime = 0x0066
    }
    #endregion //SystemParametersInfoActions

    #region FlagsAnimateWindow enum
    [Flags()]
    public enum FlagsAnimateWindow : uint
    {
        AW_HOR_POSITIVE = 0x00000001,
        AW_HOR_NEGATIVE = 0x00000002,
        AW_VER_POSITIVE = 0x00000004,
        AW_VER_NEGATIVE = 0x00000008,
        AW_CENTER = 0x00000010,
        AW_HIDE = 0x00010000,
        AW_ACTIVATE = 0x00020000,
        AW_SLIDE = 0x00040000,
        AW_BLEND = 0x00080000
    }
    #endregion //FlagsAnimateWindow

    #region DCX enum
    [Flags()]
    public enum DCX
    {
        DCX_CACHE = 0x2,
        DCX_CLIPCHILDREN = 0x8,
        DCX_CLIPSIBLINGS = 0x10,
        DCX_EXCLUDERGN = 0x40,
        DCX_EXCLUDEUPDATE = 0x100,
        DCX_INTERSECTRGN = 0x80,
        DCX_INTERSECTUPDATE = 0x200,
        DCX_LOCKWINDOWUPDATE = 0x400,
        DCX_NORECOMPUTE = 0x100000,
        DCX_NORESETATTRS = 0x4,
        DCX_PARENTCLIP = 0x20,
        DCX_VALIDATE = 0x200000,
        DCX_WINDOW = 0x1,
    }
    #endregion //DCX

    #region RasterOperations enum
    public enum RasterOperations : uint
    {
        SRCCOPY = 0x00CC0020,
        SRCPAINT = 0x00EE0086,
        SRCAND = 0x008800C6,
        SRCINVERT = 0x00660046,
        SRCERASE = 0x00440328,
        NOTSRCCOPY = 0x00330008,
        NOTSRCERASE = 0x001100A6,
        MERGECOPY = 0x00C000CA,
        MERGEPAINT = 0x00BB0226,
        PATCOPY = 0x00F00021,
        PATPAINT = 0x00FB0A09,
        PATINVERT = 0x005A0049,
        DSTINVERT = 0x00550009,
        BLACKNESS = 0x00000042,
        WHITENESS = 0x00FF0062
    }
    #endregion //RasterOperations

    #region CHARFORMAT enum
    public enum CHARFORMAT : int
    {
        SCF_SELECTION = 0x0001,
        SCF_WORD = 0x0002,
        SCF_DEFAULT = 0x0000,	// Set default charformat or paraformat
        SCF_ALL = 0x0004,	// Not valid with SCF_SELECTION or SCF_WORD
        SCF_USEUIRULES = 0x0008,	// Modifier for SCF_SELECTION; says that
        //  format came from a toolbar, etc., and
        //  hence UI formatting rules should be
        //  used instead of literal formatting
        SCF_ASSOCIATEFONT = 0x0010,	// Associate fontname with bCharSet (one
        //  possible for each of Western, ME, FE,
        //  Thai)
        SCF_NOKBUPDATE = 0x0020,	// Do not update KB layput for this change
        //  even if autokeyboard is on
        SCF_ASSOCIATEFONT2 = 0x0040	// Associate plane-2 (surrogate) font
    }
    #endregion //CHARFOMAT

    #region MenuItemFlags enum
    public enum MenuItemFlags
    { // The item ...
        MF_ENABLED = 0,
        mfUnchecked = 0x00000000,    // ... is not checked
        mfString = 0x00000000,    // ... contains a string as label
        mfDisabled = 0x00000002,    // ... is disabled
        mfGrayed = 0x00000001,    // ... is grayed
        mfChecked = 0x00000008,    // ... is checked
        mfPopup = 0x00000010,    // ... Is a popup menu. Pass the
        //     menu handle of the popup
        //     menu into the ID parameter.
        mfBarBreak = 0x00000020,    // ... is a bar break
        mfBreak = 0x00000040,    // ... is a break
        mfByPosition = 0x00000400,    // ... is identified by the position
        mfByCommand = 0x00000000,    // ... is identified by its ID
        mfSeparator = 0x00000800     // ... is a seperator (String and
        //     ID parameters are ignored).
    }
    #endregion //MenuItemFlags

    #region MenuItemInfoMask enum
    public enum MenuItemInfoMask
    {
        MIIM_STATE = 0x00000001,
        MIIM_ID = 0x00000002,
        MIIM_SUBMENU = 0x00000004,
        MIIM_CHECKMARKS = 0x00000008,
        MIIM_TYPE = 0x00000010,
        MIIM_DATA = 0x00000020,

        MIIM_STRING = 0x00000040,
        MIIM_BITMAP = 0x00000080,
        MIIM_FTYPE = 0x00000100
    }
    #endregion //MenuItemInfoMask

    #region CHARFORMAT2Flags enum Richedit.h
    public enum CHARFORMAT2Flags : uint
    {
        CFE_BOLD = 0x0001,
        CFE_ITALIC = 0x0002,
        CFE_UNDERLINE = 0x0004,
        CFE_STRIKEOUT = 0x0008,
        CFE_PROTECTED = 0x0010,
        CFE_LINK = 0x0020,
        CFE_AUTOCOLOR = 0x40000000,
        CFE_SUBSCRIPT = 0x00010000,		/* Superscript and subscript are */
        CFE_SUPERSCRIPT = 0x00020000,		/*  mutually exclusive			 */

        CFM_SMALLCAPS = 0x0040,			/* (*)	*/
        CFM_ALLCAPS = 0x0080,			/* Displayed by 3.0	*/
        CFM_HIDDEN = 0x0100,			/* Hidden by 3.0 */
        CFM_OUTLINE = 0x0200,			/* (*)	*/
        CFM_SHADOW = 0x0400,			/* (*)	*/
        CFM_EMBOSS = 0x0800,			/* (*)	*/
        CFM_IMPRINT = 0x1000,			/* (*)	*/
        CFM_DISABLED = 0x2000,
        CFM_REVISED = 0x4000,

        CFM_BACKCOLOR = 0x04000000,
        CFM_LCID = 0x02000000,
        CFM_UNDERLINETYPE = 0x00800000,		/* Many displayed by 3.0 */
        CFM_WEIGHT = 0x00400000,
        CFM_SPACING = 0x00200000,		/* Displayed by 3.0	*/
        CFM_KERNING = 0x00100000,		/* (*)	*/
        CFM_STYLE = 0x00080000,		/* (*)	*/
        CFM_ANIMATION = 0x00040000,		/* (*)	*/
        CFM_REVAUTHOR = 0x00008000,

        CFM_BOLD = 0x00000001,
        CFM_ITALIC = 0x00000002,
        CFM_UNDERLINE = 0x00000004,
        CFM_STRIKEOUT = 0x00000008,
        CFM_PROTECTED = 0x00000010,
        CFM_LINK = 0x00000020,
        CFM_SIZE = 0x80000000,
        CFM_COLOR = 0x40000000,
        CFM_FACE = 0x20000000,
        CFM_OFFSET = 0x10000000,
        CFM_CHARSET = 0x08000000,
        CFM_SUBSCRIPT = CFE_SUBSCRIPT | CFE_SUPERSCRIPT,
        CFM_SUPERSCRIPT = CFM_SUBSCRIPT,

        CFU_UNDERLINENONE = 0x00000000,
        CFU_UNDERLINE = 0x00000001,
        CFU_UNDERLINEWORD = 0x00000002, /* (*) displayed as ordinary underline	*/
        CFU_UNDERLINEDOUBLE = 0x00000003, /* (*) displayed as ordinary underline	*/
        CFU_UNDERLINEDOTTED = 0x00000004,
        CFU_UNDERLINEDASH = 0x00000005,
        CFU_UNDERLINEDASHDOT = 0x00000006,
        CFU_UNDERLINEDASHDOTDOT = 0x00000007,
        CFU_UNDERLINEWAVE = 0x00000008,
        CFU_UNDERLINETHICK = 0x00000009,
        CFU_UNDERLINEHAIRLINE = 0x0000000A /* (*) displayed as ordinary underline	*/
    }
    #endregion //CHARFORMAT2Flags

    #region EmfToWmfBitsFlags enum
    // Specifies the flags/options for the unmanaged call to the GDI+ method
    // Metafile.EmfToWmfBits().
    public enum EmfToWmfBitsFlags
    {

        // Use the default conversion
        EmfToWmfBitsFlagsDefault = 0x00000000,

        // Embedded the source of the EMF metafiel within the resulting WMF
        // metafile
        EmfToWmfBitsFlagsEmbedEmf = 0x00000001,

        // Place a 22-byte header in the resulting WMF file.  The header is
        // required for the metafile to be considered placeable.
        EmfToWmfBitsFlagsIncludePlaceable = 0x00000002,

        // Don't simulate clipping by using the XOR operator.
        EmfToWmfBitsFlagsNoXORClip = 0x00000004
    };
    #endregion //EmfToWmfBitsFlags

    #region ArrangeWindows enum
    /// <summary>
    /// Starting position and direction used when arranging minimized windows. 
    /// The starting position must be one of the following values. 
    /// </summary>
    public enum ArrangeWindow : int
    {
        /// <summary>
        /// Start at the lower-left corner of the work area.
        /// </summary>
        ARW_BOTTOMLEFT = 0x0000,
        /// <summary>
        /// Start at the lower-right corner of the work area.
        /// </summary>
        ARW_BOTTOMRIGHT = 0x0001,
        /// <summary>
        /// Start at the upper-left corner of the work area.
        /// </summary>
        ARW_TOPLEFT = 0x0002,
        /// <summary>
        /// Start at the upper-right corner of the work area.
        /// </summary>
        ARW_TOPRIGHT = 0x0003,
        /// <summary>
        /// No Description
        /// </summary>
        ARW_STARTMASK = 0x0003,
        /// <summary>
        /// No Description
        /// </summary>
        ARW_STARTRIGHT = 0x0001,
        /// <summary>
        /// No Description
        /// </summary>
        ARW_STARTTOP = 0x0002,

        /// <summary>
        /// Arrange left (valid with ARW_BOTTOMRIGHT and ARW_TOPRIGHT only).
        /// </summary>
        ARW_LEFT = 0x0000,
        /// <summary>
        /// Arrange right (valid with ARW_BOTTOMLEFT and ARW_TOPLEFT only).
        /// </summary>
        ARW_RIGHT = 0x0000,
        /// <summary>
        /// Arrange up (valid with ARW_BOTTOMLEFT and ARW_BOTTOMRIGHT only).
        /// </summary>
        ARW_UP = 0x0004,
        /// <summary>
        /// Arrange down (valid with ARW_TOPLEFT and ARW_TOPRIGHT only).
        /// </summary>
        ARW_DOWN = 0x0004,
        /// <summary>
        /// No Desription
        /// </summary>
        ARW_HIDE = 0x0008
    }
    #endregion //ArrangeWindow enum

    #region DrawTextFlags enum
    public enum DrawTextFlags
    {
        DT_TOP = 0x00000000,
        DT_LEFT = 0x00000000,
        DT_CENTER = 0x00000001,
        DT_RIGHT = 0x00000002,
        DT_VCENTER = 0x00000004,
        DT_BOTTOM = 0x00000008,
        DT_WORDBREAK = 0x00000010,
        DT_SINGLELINE = 0x00000020,
        DT_EXPANDTABS = 0x00000040,
        DT_TABSTOP = 0x00000080,
        DT_NOCLIP = 0x00000100,
        DT_EXTERNALLEADING = 0x00000200,
        DT_CALCRECT = 0x00000400,
        DT_NOPREFIX = 0x00000800,
        DT_INTERNAL = 0x00001000,
        DT_EDITCONTROL = 0x00002000,
        DT_PATH_ELLIPSIS = 0x00004000,
        DT_END_ELLIPSIS = 0x00008000,
        DT_MODIFYSTRING = 0x00010000,
        DT_RTLREADING = 0x00020000,
        DT_WORD_ELLIPSIS = 0x00040000,
        DT_NOFULLWIDTHCHARBREAK = 0x00080000,
        DT_HIDEPREFIX = 0x00100000,
        DT_PREFIXONLY = 0x00200000,
    }
    #endregion //DrawTextFlags

    #region TextBoxNotifications enum
    public enum TextBoxNotifications
    {
        EN_SETFOCUS = 0x0100,
        EN_KILLFOCUS = 0x0200,
        EN_CHANGE = 0x0300,
        EN_UPDATE = 0x0400,
        EN_ERRSPACE = 0x0500,
        EN_MAXTEXT = 0x0501,
        EN_HSCROLL = 0x0601,
        EN_VSCROLL = 0x0602,
    }
    #endregion //TextBoxNotifications

    #region TextBoxStyles enum
    public enum TextBoxStyles
    {
        ES_LEFT = 0x0000,
        ES_CENTER = 0x0001,
        ES_RIGHT = 0x0002,
        ES_MULTILINE = 0x0004,
        ES_UPPERCASE = 0x0008,
        ES_LOWERCASE = 0x0010,
        ES_PASSWORD = 0x0020,
        ES_AUTOVSCROLL = 0x0040,
        ES_AUTOHSCROLL = 0x0080,
        ES_NOHIDESEL = 0x0100,
        ES_OEMCONVERT = 0x0400,
        ES_READONLY = 0x0800,
        ES_WANTRETURN = 0x1000,
    }
    #endregion //TextBoxStyles

    #region TextBoxMessages enum
    public enum TextBoxMessages
    {
        EM_GETSEL = 0x00B0,
        EM_LINEINDEX = 0x00BB,
        EM_LINEFROMCHAR = 0x00C9,
        EM_POSFROMCHAR = 0x00D6,
    }
    #endregion //TextBoxMessages

    #region WMPrintFlags enum
    [Flags()]
    public enum WMPrintFlags
    {
        PRF_CHECKVISIBLE = 0x00000001,
        PRF_NONCLIENT = 0x00000002,
        PRF_CLIENT = 0x00000004,
        PRF_ERASEBKGND = 0x00000008,
        PRF_CHILDREN = 0x00000010,
        PRF_OWNED = 0x0000020,
    }
    #endregion //WMPrintFlags

    #region GDIRop enum
    public enum GDIRop
    {
        SrcCopy = 13369376,
        Blackness = 0, //to be implemented
        Whiteness = 0
    }
    #endregion //GDIRop

    #region ToolBarInfo enum
    /// <summary>
    /// A set of flags that indicate which members of <see cref="TBBUTTONINFO.dwMask"/> contain valid information.
    /// </summary>
    [Flags]
    public enum ToolBarInfo : uint
    {
        TBIF_IMAGE = 0x00000001,
        TBIF_TEXT = 0x00000002,
        TBIF_STATE = 0x00000004,
        TBIF_STYLE = 0x00000008,
        TBIF_LPARAM = 0x00000010,
        TBIF_COMMAND = 0x00000020,
        TBIF_SIZE = 0x00000040,
        TBIF_BYINDEX = 0x80000000,
    }
    #endregion //ToolBarInfo

    #region Enum HookType
    // Hook Types
    public enum HookType : int
    {
        WH_JOURNALRECORD = 0,
        WH_JOURNALPLAYBACK = 1,
        WH_KEYBOARD = 2,
        WH_GETMESSAGE = 3,
        WH_CALLWNDPROC = 4,
        WH_CBT = 5,
        WH_SYSMSGFILTER = 6,
        WH_MOUSE = 7,
        WH_HARDWARE = 8,
        WH_DEBUG = 9,
        WH_SHELL = 10,
        WH_FOREGROUNDIDLE = 11,
        WH_CALLWNDPROCRET = 12,
        WH_KEYBOARD_LL = 13,
        WH_MOUSE_LL = 14
    }
    #endregion

    #region GWL index enum
    public enum GWLIndex
    {
        GWL_WNDPROC = -4,
        GWL_HINSTANCE = -6,
        GWL_HWNDPARENT = -8,
        GWL_STYLE = -16,
        GWL_EXSTYLE = -20,
        GWL_USERDATA = -21,
        GWL_ID = -12
    }
    #endregion //GWLindex enum

    #region GUIthreadinfo flags
    public enum GUITHREADINFOFlags
    {
        GUI_CARETBLINKING = 0x00000001,
        GUI_INMOVESIZE = 0x00000002,
        GUI_INMENUMODE = 0x00000004,
        GUI_SYSTEMMENUMODE = 0x00000008,
        GUI_POPUPMENUMODE = 0x00000010,
        GUI_16BITTASK64 = 0x00000000,
        GUI_16BITTASK = 0x00000020
    }
    #endregion

    #region GetWindow Constants
    public enum GetWindowContstants
    {
        GW_HWNDFIRST = 0,
        GW_HWNDLAST = 1,
        GW_HWNDNEXT = 2,
        GW_HWNDPREV = 3,
        GW_OWNER = 4,
        GW_CHILD = 5,

        GW_ENABLEDPOPUP = 6,
        GW_MAX = 6

    }
    #endregion //GetWindow Constants

    #region SPI
    /// <summary>
    /// SPI_ System-wide parameter - Used in SystemParametersInfo function 
    /// </summary>
    [Description("SPI_(System-wide parameter - Used in SystemParametersInfo function )")]
    public enum SPI : uint
    {
        /// <summary>
        /// Determines whether the warning beeper is on. 
        /// The pvParam parameter must point to a BOOL variable that receives TRUE if the beeper is on, or FALSE if it is off.
        /// </summary>
        SPI_GETBEEP = 0x0001,

        /// <summary>
        /// Turns the warning beeper on or off. The uiParam parameter specifies TRUE for on, or FALSE for off.
        /// </summary>
        SPI_SETBEEP = 0x0002,

        /// <summary>
        /// Retrieves the two mouse threshold values and the mouse speed.
        /// </summary>
        SPI_GETMOUSE = 0x0003,

        /// <summary>
        /// Sets the two mouse threshold values and the mouse speed.
        /// </summary>
        SPI_SETMOUSE = 0x0004,

        /// <summary>
        /// Retrieves the border multiplier factor that determines the width of a window's sizing border. 
        /// The pvParam parameter must point to an integer variable that receives this value.
        /// </summary>
        SPI_GETBORDER = 0x0005,

        /// <summary>
        /// Sets the border multiplier factor that determines the width of a window's sizing border. 
        /// The uiParam parameter specifies the new value.
        /// </summary>
        SPI_SETBORDER = 0x0006,

        /// <summary>
        /// Retrieves the keyboard repeat-speed setting, which is a value in the range from 0 (approximately 2.5 repetitions per second) 
        /// through 31 (approximately 30 repetitions per second). The actual repeat rates are hardware-dependent and may vary from 
        /// a linear scale by as much as 20%. The pvParam parameter must point to a DWORD variable that receives the setting
        /// </summary>
        SPI_GETKEYBOARDSPEED = 0x000A,

        /// <summary>
        /// Sets the keyboard repeat-speed setting. The uiParam parameter must specify a value in the range from 0 
        /// (approximately 2.5 repetitions per second) through 31 (approximately 30 repetitions per second). 
        /// The actual repeat rates are hardware-dependent and may vary from a linear scale by as much as 20%. 
        /// If uiParam is greater than 31, the parameter is set to 31.
        /// </summary>
        SPI_SETKEYBOARDSPEED = 0x000B,

        /// <summary>
        /// Not implemented.
        /// </summary>
        SPI_LANGDRIVER = 0x000C,

        /// <summary>
        /// Sets or retrieves the width, in pixels, of an icon cell. The system uses this rectangle to arrange icons in large icon view. 
        /// To set this value, set uiParam to the new value and set pvParam to null. You cannot set this value to less than SM_CXICON.
        /// To retrieve this value, pvParam must point to an integer that receives the current value.
        /// </summary>
        SPI_ICONHORIZONTALSPACING = 0x000D,

        /// <summary>
        /// Retrieves the screen saver time-out value, in seconds. The pvParam parameter must point to an integer variable that receives the value.
        /// </summary>
        SPI_GETSCREENSAVETIMEOUT = 0x000E,

        /// <summary>
        /// Sets the screen saver time-out value to the value of the uiParam parameter. This value is the amount of time, in seconds, 
        /// that the system must be idle before the screen saver activates.
        /// </summary>
        SPI_SETSCREENSAVETIMEOUT = 0x000F,

        /// <summary>
        /// Determines whether screen saving is enabled. The pvParam parameter must point to a bool variable that receives TRUE 
        /// if screen saving is enabled, or FALSE otherwise.
        /// </summary>
        SPI_GETSCREENSAVEACTIVE = 0x0010,

        /// <summary>
        /// Sets the state of the screen saver. The uiParam parameter specifies TRUE to activate screen saving, or FALSE to deactivate it.
        /// </summary>
        SPI_SETSCREENSAVEACTIVE = 0x0011,

        /// <summary>
        /// Retrieves the current granularity value of the desktop sizing grid. The pvParam parameter must point to an integer variable 
        /// that receives the granularity.
        /// </summary>
        SPI_GETGRIDGRANULARITY = 0x0012,

        /// <summary>
        /// Sets the granularity of the desktop sizing grid to the value of the uiParam parameter.
        /// </summary>
        SPI_SETGRIDGRANULARITY = 0x0013,

        /// <summary>
        /// Sets the desktop wallpaper. The value of the pvParam parameter determines the new wallpaper. To specify a wallpaper bitmap, 
        /// set pvParam to point to a null-terminated string containing the name of a bitmap file. Setting pvParam to "" removes the wallpaper. 
        /// Setting pvParam to SETWALLPAPER_DEFAULT or null reverts to the default wallpaper.
        /// </summary>
        SPI_SETDESKWALLPAPER = 0x0014,

        /// <summary>
        /// Sets the current desktop pattern by causing Windows to read the Pattern= setting from the WIN.INI file.
        /// </summary>
        SPI_SETDESKPATTERN = 0x0015,

        /// <summary>
        /// Retrieves the keyboard repeat-delay setting, which is a value in the range from 0 (approximately 250 ms delay) through 3 
        /// (approximately 1 second delay). The actual delay associated with each value may vary depending on the hardware. The pvParam parameter must point to an integer variable that receives the setting.
        /// </summary>
        SPI_GETKEYBOARDDELAY = 0x0016,

        /// <summary>
        /// Sets the keyboard repeat-delay setting. The uiParam parameter must specify 0, 1, 2, or 3, where zero sets the shortest delay 
        /// (approximately 250 ms) and 3 sets the longest delay (approximately 1 second). The actual delay associated with each value may 
        /// vary depending on the hardware.
        /// </summary>
        SPI_SETKEYBOARDDELAY = 0x0017,

        /// <summary>
        /// Sets or retrieves the height, in pixels, of an icon cell. 
        /// To set this value, set uiParam to the new value and set pvParam to null. You cannot set this value to less than SM_CYICON.
        /// To retrieve this value, pvParam must point to an integer that receives the current value.
        /// </summary>
        SPI_ICONVERTICALSPACING = 0x0018,

        /// <summary>
        /// Determines whether icon-title wrapping is enabled. The pvParam parameter must point to a bool variable that receives TRUE 
        /// if enabled, or FALSE otherwise.
        /// </summary>
        SPI_GETICONTITLEWRAP = 0x0019,

        /// <summary>
        /// Turns icon-title wrapping on or off. The uiParam parameter specifies TRUE for on, or FALSE for off.
        /// </summary>
        SPI_SETICONTITLEWRAP = 0x001A,

        /// <summary>
        /// Determines whether pop-up menus are left-aligned or right-aligned, relative to the corresponding menu-bar item. 
        /// The pvParam parameter must point to a bool variable that receives TRUE if left-aligned, or FALSE otherwise.
        /// </summary>
        SPI_GETMENUDROPALIGNMENT = 0x001B,

        /// <summary>
        /// Sets the alignment value of pop-up menus. The uiParam parameter specifies TRUE for right alignment, or FALSE for left alignment.
        /// </summary>
        SPI_SETMENUDROPALIGNMENT = 0x001C,

        /// <summary>
        /// Sets the width of the double-click rectangle to the value of the uiParam parameter. 
        /// The double-click rectangle is the rectangle within which the second click of a double-click must fall for it to be registered 
        /// as a double-click.
        /// To retrieve the width of the double-click rectangle, call GetSystemMetrics with the SM_CXDOUBLECLK flag.
        /// </summary>
        SPI_SETDOUBLECLKWIDTH = 0x001D,

        /// <summary>
        /// Sets the height of the double-click rectangle to the value of the uiParam parameter. 
        /// The double-click rectangle is the rectangle within which the second click of a double-click must fall for it to be registered 
        /// as a double-click.
        /// To retrieve the height of the double-click rectangle, call GetSystemMetrics with the SM_CYDOUBLECLK flag.
        /// </summary>
        SPI_SETDOUBLECLKHEIGHT = 0x001E,

        /// <summary>
        /// Retrieves the logical font information for the current icon-title font. The uiParam parameter specifies the size of a LOGFONT structure, 
        /// and the pvParam parameter must point to the LOGFONT structure to fill in.
        /// </summary>
        SPI_GETICONTITLELOGFONT = 0x001F,

        /// <summary>
        /// Sets the double-click time for the mouse to the value of the uiParam parameter. The double-click time is the maximum number 
        /// of milliseconds that can occur between the first and second clicks of a double-click. You can also call the SetDoubleClickTime 
        /// function to set the double-click time. To get the current double-click time, call the GetDoubleClickTime function.
        /// </summary>
        SPI_SETDOUBLECLICKTIME = 0x0020,

        /// <summary>
        /// Swaps or restores the meaning of the left and right mouse buttons. The uiParam parameter specifies TRUE to swap the meanings 
        /// of the buttons, or FALSE to restore their original meanings.
        /// </summary>
        SPI_SETMOUSEBUTTONSWAP = 0x0021,

        /// <summary>
        /// Sets the font that is used for icon titles. The uiParam parameter specifies the size of a LOGFONT structure, 
        /// and the pvParam parameter must point to a LOGFONT structure.
        /// </summary>
        SPI_SETICONTITLELOGFONT = 0x0022,

        /// <summary>
        /// This flag is obsolete. Previous versions of the system use this flag to determine whether ALT+TAB fast task switching is enabled. 
        /// For Windows 95, Windows 98, and Windows NT version 4.0 and later, fast task switching is always enabled.
        /// </summary>
        SPI_GETFASTTASKSWITCH = 0x0023,

        /// <summary>
        /// This flag is obsolete. Previous versions of the system use this flag to enable or disable ALT+TAB fast task switching. 
        /// For Windows 95, Windows 98, and Windows NT version 4.0 and later, fast task switching is always enabled.
        /// </summary>
        SPI_SETFASTTASKSWITCH = 0x0024,

        //#if(WINVER >= 0x0400)
        /// <summary>
        /// Sets dragging of full windows either on or off. The uiParam parameter specifies TRUE for on, or FALSE for off. 
        /// Windows 95:  This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
        /// </summary>
        SPI_SETDRAGFULLWINDOWS = 0x0025,

        /// <summary>
        /// Determines whether dragging of full windows is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// if enabled, or FALSE otherwise. 
        /// Windows 95:  This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
        /// </summary>
        SPI_GETDRAGFULLWINDOWS = 0x0026,

        /// <summary>
        /// Retrieves the metrics associated with the nonclient area of nonminimized windows. The pvParam parameter must point 
        /// to a NONCLIENTMETRICS structure that receives the information. Set the cbSize member of this structure and the uiParam parameter 
        /// to sizeof(NONCLIENTMETRICS).
        /// </summary>
        SPI_GETNONCLIENTMETRICS = 0x0029,

        /// <summary>
        /// Sets the metrics associated with the nonclient area of nonminimized windows. The pvParam parameter must point 
        /// to a NONCLIENTMETRICS structure that contains the new parameters. Set the cbSize member of this structure 
        /// and the uiParam parameter to sizeof(NONCLIENTMETRICS). Also, the lfHeight member of the LOGFONT structure must be a negative value.
        /// </summary>
        SPI_SETNONCLIENTMETRICS = 0x002A,

        /// <summary>
        /// Retrieves the metrics associated with minimized windows. The pvParam parameter must point to a MINIMIZEDMETRICS structure 
        /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(MINIMIZEDMETRICS).
        /// </summary>
        SPI_GETMINIMIZEDMETRICS = 0x002B,

        /// <summary>
        /// Sets the metrics associated with minimized windows. The pvParam parameter must point to a MINIMIZEDMETRICS structure 
        /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(MINIMIZEDMETRICS).
        /// </summary>
        SPI_SETMINIMIZEDMETRICS = 0x002C,

        /// <summary>
        /// Retrieves the metrics associated with icons. The pvParam parameter must point to an ICONMETRICS structure that receives 
        /// the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(ICONMETRICS).
        /// </summary>
        SPI_GETICONMETRICS = 0x002D,

        /// <summary>
        /// Sets the metrics associated with icons. The pvParam parameter must point to an ICONMETRICS structure that contains 
        /// the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(ICONMETRICS).
        /// </summary>
        SPI_SETICONMETRICS = 0x002E,

        /// <summary>
        /// Sets the size of the work area. The work area is the portion of the screen not obscured by the system taskbar 
        /// or by application desktop toolbars. The pvParam parameter is a pointer to a RECT structure that specifies the new work area rectangle, 
        /// expressed in virtual screen coordinates. In a system with multiple display monitors, the function sets the work area 
        /// of the monitor that contains the specified rectangle.
        /// </summary>
        SPI_SETWORKAREA = 0x002F,

        /// <summary>
        /// Retrieves the size of the work area on the primary display monitor. The work area is the portion of the screen not obscured 
        /// by the system taskbar or by application desktop toolbars. The pvParam parameter must point to a RECT structure that receives 
        /// the coordinates of the work area, expressed in virtual screen coordinates. 
        /// To get the work area of a monitor other than the primary display monitor, call the GetMonitorInfo function.
        /// </summary>
        SPI_GETWORKAREA = 0x0030,

        /// <summary>
        /// Windows Me/98/95:  Pen windows is being loaded or unloaded. The uiParam parameter is TRUE when loading and FALSE 
        /// when unloading pen windows. The pvParam parameter is null.
        /// </summary>
        SPI_SETPENWINDOWS = 0x0031,

        /// <summary>
        /// Retrieves information about the HighContrast accessibility feature. The pvParam parameter must point to a HIGHCONTRAST structure 
        /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(HIGHCONTRAST). 
        /// For a general discussion, see remarks.
        /// Windows NT:  This value is not supported.
        /// </summary>
        /// <remarks>
        /// There is a difference between the High Contrast color scheme and the High Contrast Mode. The High Contrast color scheme changes 
        /// the system colors to colors that have obvious contrast; you switch to this color scheme by using the Display Options in the control panel. 
        /// The High Contrast Mode, which uses SPI_GETHIGHCONTRAST and SPI_SETHIGHCONTRAST, advises applications to modify their appearance 
        /// for visually-impaired users. It involves such things as audible warning to users and customized color scheme 
        /// (using the Accessibility Options in the control panel). For more information, see HIGHCONTRAST on MSDN.
        /// For more information on general accessibility features, see Accessibility on MSDN.
        /// </remarks>
        SPI_GETHIGHCONTRAST = 0x0042,

        /// <summary>
        /// Sets the parameters of the HighContrast accessibility feature. The pvParam parameter must point to a HIGHCONTRAST structure 
        /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(HIGHCONTRAST).
        /// Windows NT:  This value is not supported.
        /// </summary>
        SPI_SETHIGHCONTRAST = 0x0043,

        /// <summary>
        /// Determines whether the user relies on the keyboard instead of the mouse, and wants applications to display keyboard interfaces 
        /// that would otherwise be hidden. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// if the user relies on the keyboard; or FALSE otherwise.
        /// Windows NT:  This value is not supported.
        /// </summary>
        SPI_GETKEYBOARDPREF = 0x0044,

        /// <summary>
        /// Sets the keyboard preference. The uiParam parameter specifies TRUE if the user relies on the keyboard instead of the mouse, 
        /// and wants applications to display keyboard interfaces that would otherwise be hidden; uiParam is FALSE otherwise.
        /// Windows NT:  This value is not supported.
        /// </summary>
        SPI_SETKEYBOARDPREF = 0x0045,

        /// <summary>
        /// Determines whether a screen reviewer utility is running. A screen reviewer utility directs textual information to an output device, 
        /// such as a speech synthesizer or Braille display. When this flag is set, an application should provide textual information 
        /// in situations where it would otherwise present the information graphically.
        /// The pvParam parameter is a pointer to a BOOL variable that receives TRUE if a screen reviewer utility is running, or FALSE otherwise.
        /// Windows NT:  This value is not supported.
        /// </summary>
        SPI_GETSCREENREADER = 0x0046,

        /// <summary>
        /// Determines whether a screen review utility is running. The uiParam parameter specifies TRUE for on, or FALSE for off.
        /// Windows NT:  This value is not supported.
        /// </summary>
        SPI_SETSCREENREADER = 0x0047,

        /// <summary>
        /// Retrieves the animation effects associated with user actions. The pvParam parameter must point to an ANIMATIONINFO structure 
        /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(ANIMATIONINFO).
        /// </summary>
        SPI_GETANIMATION = 0x0048,

        /// <summary>
        /// Sets the animation effects associated with user actions. The pvParam parameter must point to an ANIMATIONINFO structure 
        /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(ANIMATIONINFO).
        /// </summary>
        SPI_SETANIMATION = 0x0049,

        /// <summary>
        /// Determines whether the font smoothing feature is enabled. This feature uses font antialiasing to make font curves appear smoother 
        /// by painting pixels at different gray levels. 
        /// The pvParam parameter must point to a BOOL variable that receives TRUE if the feature is enabled, or FALSE if it is not.
        /// Windows 95:  This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
        /// </summary>
        SPI_GETFONTSMOOTHING = 0x004A,

        /// <summary>
        /// Enables or disables the font smoothing feature, which uses font antialiasing to make font curves appear smoother 
        /// by painting pixels at different gray levels. 
        /// To enable the feature, set the uiParam parameter to TRUE. To disable the feature, set uiParam to FALSE.
        /// Windows 95:  This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
        /// </summary>
        SPI_SETFONTSMOOTHING = 0x004B,

        /// <summary>
        /// Sets the width, in pixels, of the rectangle used to detect the start of a drag operation. Set uiParam to the new value. 
        /// To retrieve the drag width, call GetSystemMetrics with the SM_CXDRAG flag.
        /// </summary>
        SPI_SETDRAGWIDTH = 0x004C,

        /// <summary>
        /// Sets the height, in pixels, of the rectangle used to detect the start of a drag operation. Set uiParam to the new value. 
        /// To retrieve the drag height, call GetSystemMetrics with the SM_CYDRAG flag.
        /// </summary>
        SPI_SETDRAGHEIGHT = 0x004D,

        /// <summary>
        /// Used internally; applications should not use this value.
        /// </summary>
        SPI_SETHANDHELD = 0x004E,

        /// <summary>
        /// Retrieves the time-out value for the low-power phase of screen saving. The pvParam parameter must point to an integer variable 
        /// that receives the value. This flag is supported for 32-bit applications only.
        /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        /// Windows 95:  This flag is supported for 16-bit applications only.
        /// </summary>
        SPI_GETLOWPOWERTIMEOUT = 0x004F,

        /// <summary>
        /// Retrieves the time-out value for the power-off phase of screen saving. The pvParam parameter must point to an integer variable 
        /// that receives the value. This flag is supported for 32-bit applications only.
        /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        /// Windows 95:  This flag is supported for 16-bit applications only.
        /// </summary>
        SPI_GETPOWEROFFTIMEOUT = 0x0050,

        /// <summary>
        /// Sets the time-out value, in seconds, for the low-power phase of screen saving. The uiParam parameter specifies the new value. 
        /// The pvParam parameter must be null. This flag is supported for 32-bit applications only.
        /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        /// Windows 95:  This flag is supported for 16-bit applications only.
        /// </summary>
        SPI_SETLOWPOWERTIMEOUT = 0x0051,

        /// <summary>
        /// Sets the time-out value, in seconds, for the power-off phase of screen saving. The uiParam parameter specifies the new value. 
        /// The pvParam parameter must be null. This flag is supported for 32-bit applications only.
        /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        /// Windows 95:  This flag is supported for 16-bit applications only.
        /// </summary>
        SPI_SETPOWEROFFTIMEOUT = 0x0052,

        /// <summary>
        /// Determines whether the low-power phase of screen saving is enabled. The pvParam parameter must point to a BOOL variable 
        /// that receives TRUE if enabled, or FALSE if disabled. This flag is supported for 32-bit applications only.
        /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        /// Windows 95:  This flag is supported for 16-bit applications only.
        /// </summary>
        SPI_GETLOWPOWERACTIVE = 0x0053,

        /// <summary>
        /// Determines whether the power-off phase of screen saving is enabled. The pvParam parameter must point to a BOOL variable 
        /// that receives TRUE if enabled, or FALSE if disabled. This flag is supported for 32-bit applications only.
        /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        /// Windows 95:  This flag is supported for 16-bit applications only.
        /// </summary>
        SPI_GETPOWEROFFACTIVE = 0x0054,

        /// <summary>
        /// Activates or deactivates the low-power phase of screen saving. Set uiParam to 1 to activate, or zero to deactivate. 
        /// The pvParam parameter must be null. This flag is supported for 32-bit applications only.
        /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        /// Windows 95:  This flag is supported for 16-bit applications only.
        /// </summary>
        SPI_SETLOWPOWERACTIVE = 0x0055,

        /// <summary>
        /// Activates or deactivates the power-off phase of screen saving. Set uiParam to 1 to activate, or zero to deactivate. 
        /// The pvParam parameter must be null. This flag is supported for 32-bit applications only.
        /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        /// Windows 95:  This flag is supported for 16-bit applications only.
        /// </summary>
        SPI_SETPOWEROFFACTIVE = 0x0056,

        /// <summary>
        /// Reloads the system cursors. Set the uiParam parameter to zero and the pvParam parameter to null.
        /// </summary>
        SPI_SETCURSORS = 0x0057,

        /// <summary>
        /// Reloads the system icons. Set the uiParam parameter to zero and the pvParam parameter to null.
        /// </summary>
        SPI_SETICONS = 0x0058,

        /// <summary>
        /// Retrieves the input locale identifier for the system default input language. The pvParam parameter must point 
        /// to an HKL variable that receives this value. For more information, see Languages, Locales, and Keyboard Layouts on MSDN.
        /// </summary>
        SPI_GETDEFAULTINPUTLANG = 0x0059,

        /// <summary>
        /// Sets the default input language for the system shell and applications. The specified language must be displayable 
        /// using the current system character set. The pvParam parameter must point to an HKL variable that contains 
        /// the input locale identifier for the default language. For more information, see Languages, Locales, and Keyboard Layouts on MSDN.
        /// </summary>
        SPI_SETDEFAULTINPUTLANG = 0x005A,

        /// <summary>
        /// Sets the hot key set for switching between input languages. The uiParam and pvParam parameters are not used. 
        /// The value sets the shortcut keys in the keyboard property sheets by reading the registry again. The registry must be set before this flag is used. the path in the registry is \HKEY_CURRENT_USER\keyboard layout\toggle. Valid values are "1" = ALT+SHIFT, "2" = CTRL+SHIFT, and "3" = none.
        /// </summary>
        SPI_SETLANGTOGGLE = 0x005B,

        /// <summary>
        /// Windows 95:  Determines whether the Windows extension, Windows Plus!, is installed. Set the uiParam parameter to 1. 
        /// The pvParam parameter is not used. The function returns TRUE if the extension is installed, or FALSE if it is not.
        /// </summary>
        SPI_GETWINDOWSEXTENSION = 0x005C,

        /// <summary>
        /// Enables or disables the Mouse Trails feature, which improves the visibility of mouse cursor movements by briefly showing 
        /// a trail of cursors and quickly erasing them. 
        /// To disable the feature, set the uiParam parameter to zero or 1. To enable the feature, set uiParam to a value greater than 1 
        /// to indicate the number of cursors drawn in the trail.
        /// Windows 2000/NT:  This value is not supported.
        /// </summary>
        SPI_SETMOUSETRAILS = 0x005D,

        /// <summary>
        /// Determines whether the Mouse Trails feature is enabled. This feature improves the visibility of mouse cursor movements 
        /// by briefly showing a trail of cursors and quickly erasing them. 
        /// The pvParam parameter must point to an integer variable that receives a value. If the value is zero or 1, the feature is disabled. 
        /// If the value is greater than 1, the feature is enabled and the value indicates the number of cursors drawn in the trail. 
        /// The uiParam parameter is not used.
        /// Windows 2000/NT:  This value is not supported.
        /// </summary>
        SPI_GETMOUSETRAILS = 0x005E,

        /// <summary>
        /// Windows Me/98:  Used internally; applications should not use this flag.
        /// </summary>
        SPI_SETSCREENSAVERRUNNING = 0x0061,

        /// <summary>
        /// Same as SPI_SETSCREENSAVERRUNNING.
        /// </summary>
        SPI_SCREENSAVERRUNNING = SPI_SETSCREENSAVERRUNNING,
        //#endif /* WINVER >= 0x0400 */

        /// <summary>
        /// Retrieves information about the FilterKeys accessibility feature. The pvParam parameter must point to a FILTERKEYS structure 
        /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(FILTERKEYS).
        /// </summary>
        SPI_GETFILTERKEYS = 0x0032,

        /// <summary>
        /// Sets the parameters of the FilterKeys accessibility feature. The pvParam parameter must point to a FILTERKEYS structure 
        /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(FILTERKEYS).
        /// </summary>
        SPI_SETFILTERKEYS = 0x0033,

        /// <summary>
        /// Retrieves information about the ToggleKeys accessibility feature. The pvParam parameter must point to a TOGGLEKEYS structure 
        /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(TOGGLEKEYS).
        /// </summary>
        SPI_GETTOGGLEKEYS = 0x0034,

        /// <summary>
        /// Sets the parameters of the ToggleKeys accessibility feature. The pvParam parameter must point to a TOGGLEKEYS structure 
        /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(TOGGLEKEYS).
        /// </summary>
        SPI_SETTOGGLEKEYS = 0x0035,

        /// <summary>
        /// Retrieves information about the MouseKeys accessibility feature. The pvParam parameter must point to a MOUSEKEYS structure 
        /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(MOUSEKEYS).
        /// </summary>
        SPI_GETMOUSEKEYS = 0x0036,

        /// <summary>
        /// Sets the parameters of the MouseKeys accessibility feature. The pvParam parameter must point to a MOUSEKEYS structure 
        /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(MOUSEKEYS).
        /// </summary>
        SPI_SETMOUSEKEYS = 0x0037,

        /// <summary>
        /// Determines whether the Show Sounds accessibility flag is on or off. If it is on, the user requires an application 
        /// to present information visually in situations where it would otherwise present the information only in audible form. 
        /// The pvParam parameter must point to a BOOL variable that receives TRUE if the feature is on, or FALSE if it is off. 
        /// Using this value is equivalent to calling GetSystemMetrics (SM_SHOWSOUNDS). That is the recommended call.
        /// </summary>
        SPI_GETSHOWSOUNDS = 0x0038,

        /// <summary>
        /// Sets the parameters of the SoundSentry accessibility feature. The pvParam parameter must point to a SOUNDSENTRY structure 
        /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(SOUNDSENTRY).
        /// </summary>
        SPI_SETSHOWSOUNDS = 0x0039,

        /// <summary>
        /// Retrieves information about the StickyKeys accessibility feature. The pvParam parameter must point to a STICKYKEYS structure 
        /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(STICKYKEYS).
        /// </summary>
        SPI_GETSTICKYKEYS = 0x003A,

        /// <summary>
        /// Sets the parameters of the StickyKeys accessibility feature. The pvParam parameter must point to a STICKYKEYS structure 
        /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(STICKYKEYS).
        /// </summary>
        SPI_SETSTICKYKEYS = 0x003B,

        /// <summary>
        /// Retrieves information about the time-out period associated with the accessibility features. The pvParam parameter must point 
        /// to an ACCESSTIMEOUT structure that receives the information. Set the cbSize member of this structure and the uiParam parameter 
        /// to sizeof(ACCESSTIMEOUT).
        /// </summary>
        SPI_GETACCESSTIMEOUT = 0x003C,

        /// <summary>
        /// Sets the time-out period associated with the accessibility features. The pvParam parameter must point to an ACCESSTIMEOUT 
        /// structure that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(ACCESSTIMEOUT).
        /// </summary>
        SPI_SETACCESSTIMEOUT = 0x003D,

        //#if(WINVER >= 0x0400)
        /// <summary>
        /// Windows Me/98/95:  Retrieves information about the SerialKeys accessibility feature. The pvParam parameter must point 
        /// to a SERIALKEYS structure that receives the information. Set the cbSize member of this structure and the uiParam parameter 
        /// to sizeof(SERIALKEYS).
        /// Windows Server 2003, Windows XP/2000/NT:  Not supported. The user controls this feature through the control panel.
        /// </summary>
        SPI_GETSERIALKEYS = 0x003E,

        /// <summary>
        /// Windows Me/98/95:  Sets the parameters of the SerialKeys accessibility feature. The pvParam parameter must point 
        /// to a SERIALKEYS structure that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter 
        /// to sizeof(SERIALKEYS). 
        /// Windows Server 2003, Windows XP/2000/NT:  Not supported. The user controls this feature through the control panel.
        /// </summary>
        SPI_SETSERIALKEYS = 0x003F,
        //#endif /* WINVER >= 0x0400 */ 

        /// <summary>
        /// Retrieves information about the SoundSentry accessibility feature. The pvParam parameter must point to a SOUNDSENTRY structure 
        /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(SOUNDSENTRY).
        /// </summary>
        SPI_GETSOUNDSENTRY = 0x0040,

        /// <summary>
        /// Sets the parameters of the SoundSentry accessibility feature. The pvParam parameter must point to a SOUNDSENTRY structure 
        /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(SOUNDSENTRY).
        /// </summary>
        SPI_SETSOUNDSENTRY = 0x0041,

        //#if(_WIN32_WINNT >= 0x0400)
        /// <summary>
        /// Determines whether the snap-to-default-button feature is enabled. If enabled, the mouse cursor automatically moves 
        /// to the default button, such as OK or Apply, of a dialog box. The pvParam parameter must point to a BOOL variable 
        /// that receives TRUE if the feature is on, or FALSE if it is off. 
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_GETSNAPTODEFBUTTON = 0x005F,

        /// <summary>
        /// Enables or disables the snap-to-default-button feature. If enabled, the mouse cursor automatically moves to the default button, 
        /// such as OK or Apply, of a dialog box. Set the uiParam parameter to TRUE to enable the feature, or FALSE to disable it. 
        /// Applications should use the ShowWindow function when displaying a dialog box so the dialog manager can position the mouse cursor. 
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_SETSNAPTODEFBUTTON = 0x0060,
        //#endif /* _WIN32_WINNT >= 0x0400 */

        //#if (_WIN32_WINNT >= 0x0400) || (_WIN32_WINDOWS > 0x0400)
        /// <summary>
        /// Retrieves the width, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent 
        /// to generate a WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the width. 
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_GETMOUSEHOVERWIDTH = 0x0062,

        /// <summary>
        /// Retrieves the width, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent 
        /// to generate a WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the width. 
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_SETMOUSEHOVERWIDTH = 0x0063,

        /// <summary>
        /// Retrieves the height, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent 
        /// to generate a WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the height. 
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_GETMOUSEHOVERHEIGHT = 0x0064,

        /// <summary>
        /// Sets the height, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent 
        /// to generate a WM_MOUSEHOVER message. Set the uiParam parameter to the new height.
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_SETMOUSEHOVERHEIGHT = 0x0065,

        /// <summary>
        /// Retrieves the time, in milliseconds, that the mouse pointer has to stay in the hover rectangle for TrackMouseEvent 
        /// to generate a WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the time. 
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_GETMOUSEHOVERTIME = 0x0066,

        /// <summary>
        /// Sets the time, in milliseconds, that the mouse pointer has to stay in the hover rectangle for TrackMouseEvent 
        /// to generate a WM_MOUSEHOVER message. This is used only if you pass HOVER_DEFAULT in the dwHoverTime parameter in the call to TrackMouseEvent. Set the uiParam parameter to the new time. 
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_SETMOUSEHOVERTIME = 0x0067,

        /// <summary>
        /// Retrieves the number of lines to scroll when the mouse wheel is rotated. The pvParam parameter must point 
        /// to a UINT variable that receives the number of lines. The default value is 3. 
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_GETWHEELSCROLLLINES = 0x0068,

        /// <summary>
        /// Sets the number of lines to scroll when the mouse wheel is rotated. The number of lines is set from the uiParam parameter. 
        /// The number of lines is the suggested number of lines to scroll when the mouse wheel is rolled without using modifier keys. 
        /// If the number is 0, then no scrolling should occur. If the number of lines to scroll is greater than the number of lines viewable, 
        /// and in particular if it is WHEEL_PAGESCROLL (#defined as UINT_MAX), the scroll operation should be interpreted 
        /// as clicking once in the page down or page up regions of the scroll bar.
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_SETWHEELSCROLLLINES = 0x0069,

        /// <summary>
        /// Retrieves the time, in milliseconds, that the system waits before displaying a shortcut menu when the mouse cursor is 
        /// over a submenu item. The pvParam parameter must point to a DWORD variable that receives the time of the delay. 
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_GETMENUSHOWDELAY = 0x006A,

        /// <summary>
        /// Sets uiParam to the time, in milliseconds, that the system waits before displaying a shortcut menu when the mouse cursor is 
        /// over a submenu item. 
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_SETMENUSHOWDELAY = 0x006B,

        /// <summary>
        /// Determines whether the IME status window is visible (on a per-user basis). The pvParam parameter must point to a BOOL variable 
        /// that receives TRUE if the status window is visible, or FALSE if it is not.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETSHOWIMEUI = 0x006E,

        /// <summary>
        /// Sets whether the IME status window is visible or not on a per-user basis. The uiParam parameter specifies TRUE for on or FALSE for off.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETSHOWIMEUI = 0x006F,
        //#endif

        //#if(WINVER >= 0x0500)
        /// <summary>
        /// Retrieves the current mouse speed. The mouse speed determines how far the pointer will move based on the distance the mouse moves. 
        /// The pvParam parameter must point to an integer that receives a value which ranges between 1 (slowest) and 20 (fastest). 
        /// A value of 10 is the default. The value can be set by an end user using the mouse control panel application or 
        /// by an application using SPI_SETMOUSESPEED.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETMOUSESPEED = 0x0070,

        /// <summary>
        /// Sets the current mouse speed. The pvParam parameter is an integer between 1 (slowest) and 20 (fastest). A value of 10 is the default. 
        /// This value is typically set using the mouse control panel application.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETMOUSESPEED = 0x0071,

        /// <summary>
        /// Determines whether a screen saver is currently running on the window station of the calling process. 
        /// The pvParam parameter must point to a BOOL variable that receives TRUE if a screen saver is currently running, or FALSE otherwise.
        /// Note that only the interactive window station, "WinSta0", can have a screen saver running.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETSCREENSAVERRUNNING = 0x0072,

        /// <summary>
        /// Retrieves the full path of the bitmap file for the desktop wallpaper. The pvParam parameter must point to a buffer 
        /// that receives a null-terminated path string. Set the uiParam parameter to the size, in characters, of the pvParam buffer. The returned string will not exceed MAX_PATH characters. If there is no desktop wallpaper, the returned string is empty.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETDESKWALLPAPER = 0x0073,
        //#endif /* WINVER >= 0x0500 */

        //#if(WINVER >= 0x0500)
        /// <summary>
        /// Determines whether active window tracking (activating the window the mouse is on) is on or off. The pvParam parameter must point 
        /// to a BOOL variable that receives TRUE for on, or FALSE for off.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETACTIVEWINDOWTRACKING = 0x1000,

        /// <summary>
        /// Sets active window tracking (activating the window the mouse is on) either on or off. Set pvParam to TRUE for on or FALSE for off.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETACTIVEWINDOWTRACKING = 0x1001,

        /// <summary>
        /// Determines whether the menu animation feature is enabled. This master switch must be on to enable menu animation effects. 
        /// The pvParam parameter must point to a BOOL variable that receives TRUE if animation is enabled and FALSE if it is disabled. 
        /// If animation is enabled, SPI_GETMENUFADE indicates whether menus use fade or slide animation.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETMENUANIMATION = 0x1002,

        /// <summary>
        /// Enables or disables menu animation. This master switch must be on for any menu animation to occur. 
        /// The pvParam parameter is a BOOL variable; set pvParam to TRUE to enable animation and FALSE to disable animation.
        /// If animation is enabled, SPI_GETMENUFADE indicates whether menus use fade or slide animation.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETMENUANIMATION = 0x1003,

        /// <summary>
        /// Determines whether the slide-open effect for combo boxes is enabled. The pvParam parameter must point to a BOOL variable 
        /// that receives TRUE for enabled, or FALSE for disabled.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETCOMBOBOXANIMATION = 0x1004,

        /// <summary>
        /// Enables or disables the slide-open effect for combo boxes. Set the pvParam parameter to TRUE to enable the gradient effect, 
        /// or FALSE to disable it.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETCOMBOBOXANIMATION = 0x1005,

        /// <summary>
        /// Determines whether the smooth-scrolling effect for list boxes is enabled. The pvParam parameter must point to a BOOL variable 
        /// that receives TRUE for enabled, or FALSE for disabled.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETLISTBOXSMOOTHSCROLLING = 0x1006,

        /// <summary>
        /// Enables or disables the smooth-scrolling effect for list boxes. Set the pvParam parameter to TRUE to enable the smooth-scrolling effect,
        /// or FALSE to disable it.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETLISTBOXSMOOTHSCROLLING = 0x1007,

        /// <summary>
        /// Determines whether the gradient effect for window title bars is enabled. The pvParam parameter must point to a BOOL variable 
        /// that receives TRUE for enabled, or FALSE for disabled. For more information about the gradient effect, see the GetSysColor function.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETGRADIENTCAPTIONS = 0x1008,

        /// <summary>
        /// Enables or disables the gradient effect for window title bars. Set the pvParam parameter to TRUE to enable it, or FALSE to disable it. 
        /// The gradient effect is possible only if the system has a color depth of more than 256 colors. For more information about 
        /// the gradient effect, see the GetSysColor function.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETGRADIENTCAPTIONS = 0x1009,

        /// <summary>
        /// Determines whether menu access keys are always underlined. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// if menu access keys are always underlined, and FALSE if they are underlined only when the menu is activated by the keyboard.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETKEYBOARDCUES = 0x100A,

        /// <summary>
        /// Sets the underlining of menu access key letters. The pvParam parameter is a BOOL variable. Set pvParam to TRUE to always underline menu 
        /// access keys, or FALSE to underline menu access keys only when the menu is activated from the keyboard.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETKEYBOARDCUES = 0x100B,

        /// <summary>
        /// Same as SPI_GETKEYBOARDCUES.
        /// </summary>
        SPI_GETMENUUNDERLINES = SPI_GETKEYBOARDCUES,

        /// <summary>
        /// Same as SPI_SETKEYBOARDCUES.
        /// </summary>
        SPI_SETMENUUNDERLINES = SPI_SETKEYBOARDCUES,

        /// <summary>
        /// Determines whether windows activated through active window tracking will be brought to the top. The pvParam parameter must point 
        /// to a BOOL variable that receives TRUE for on, or FALSE for off.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETACTIVEWNDTRKZORDER = 0x100C,

        /// <summary>
        /// Determines whether or not windows activated through active window tracking should be brought to the top. Set pvParam to TRUE 
        /// for on or FALSE for off.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETACTIVEWNDTRKZORDER = 0x100D,

        /// <summary>
        /// Determines whether hot tracking of user-interface elements, such as menu names on menu bars, is enabled. The pvParam parameter 
        /// must point to a BOOL variable that receives TRUE for enabled, or FALSE for disabled. 
        /// Hot tracking means that when the cursor moves over an item, it is highlighted but not selected. You can query this value to decide 
        /// whether to use hot tracking in the user interface of your application.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETHOTTRACKING = 0x100E,

        /// <summary>
        /// Enables or disables hot tracking of user-interface elements such as menu names on menu bars. Set the pvParam parameter to TRUE 
        /// to enable it, or FALSE to disable it.
        /// Hot-tracking means that when the cursor moves over an item, it is highlighted but not selected.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETHOTTRACKING = 0x100F,

        /// <summary>
        /// Determines whether menu fade animation is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// when fade animation is enabled and FALSE when it is disabled. If fade animation is disabled, menus use slide animation. 
        /// This flag is ignored unless menu animation is enabled, which you can do using the SPI_SETMENUANIMATION flag. 
        /// For more information, see AnimateWindow.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETMENUFADE = 0x1012,

        /// <summary>
        /// Enables or disables menu fade animation. Set pvParam to TRUE to enable the menu fade effect or FALSE to disable it. 
        /// If fade animation is disabled, menus use slide animation. he The menu fade effect is possible only if the system 
        /// has a color depth of more than 256 colors. This flag is ignored unless SPI_MENUANIMATION is also set. For more information, 
        /// see AnimateWindow.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETMENUFADE = 0x1013,

        /// <summary>
        /// Determines whether the selection fade effect is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// if enabled or FALSE if disabled. 
        /// The selection fade effect causes the menu item selected by the user to remain on the screen briefly while fading out 
        /// after the menu is dismissed.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETSELECTIONFADE = 0x1014,

        /// <summary>
        /// Set pvParam to TRUE to enable the selection fade effect or FALSE to disable it.
        /// The selection fade effect causes the menu item selected by the user to remain on the screen briefly while fading out 
        /// after the menu is dismissed. The selection fade effect is possible only if the system has a color depth of more than 256 colors.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETSELECTIONFADE = 0x1015,

        /// <summary>
        /// Determines whether ToolTip animation is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// if enabled or FALSE if disabled. If ToolTip animation is enabled, SPI_GETTOOLTIPFADE indicates whether ToolTips use fade or slide animation.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETTOOLTIPANIMATION = 0x1016,

        /// <summary>
        /// Set pvParam to TRUE to enable ToolTip animation or FALSE to disable it. If enabled, you can use SPI_SETTOOLTIPFADE 
        /// to specify fade or slide animation.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETTOOLTIPANIMATION = 0x1017,

        /// <summary>
        /// If SPI_SETTOOLTIPANIMATION is enabled, SPI_GETTOOLTIPFADE indicates whether ToolTip animation uses a fade effect or a slide effect.
        ///  The pvParam parameter must point to a BOOL variable that receives TRUE for fade animation or FALSE for slide animation. 
        ///  For more information on slide and fade effects, see AnimateWindow.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETTOOLTIPFADE = 0x1018,

        /// <summary>
        /// If the SPI_SETTOOLTIPANIMATION flag is enabled, use SPI_SETTOOLTIPFADE to indicate whether ToolTip animation uses a fade effect 
        /// or a slide effect. Set pvParam to TRUE for fade animation or FALSE for slide animation. The tooltip fade effect is possible only 
        /// if the system has a color depth of more than 256 colors. For more information on the slide and fade effects, 
        /// see the AnimateWindow function.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETTOOLTIPFADE = 0x1019,

        /// <summary>
        /// Determines whether the cursor has a shadow around it. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// if the shadow is enabled, FALSE if it is disabled. This effect appears only if the system has a color depth of more than 256 colors.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETCURSORSHADOW = 0x101A,

        /// <summary>
        /// Enables or disables a shadow around the cursor. The pvParam parameter is a BOOL variable. Set pvParam to TRUE to enable the shadow 
        /// or FALSE to disable the shadow. This effect appears only if the system has a color depth of more than 256 colors.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETCURSORSHADOW = 0x101B,

        //#if(_WIN32_WINNT >= 0x0501)
        /// <summary>
        /// Retrieves the state of the Mouse Sonar feature. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// if enabled or FALSE otherwise. For more information, see About Mouse Input on MSDN.
        /// Windows 2000/NT, Windows 98/95:  This value is not supported.
        /// </summary>
        SPI_GETMOUSESONAR = 0x101C,

        /// <summary>
        /// Turns the Sonar accessibility feature on or off. This feature briefly shows several concentric circles around the mouse pointer 
        /// when the user presses and releases the CTRL key. The pvParam parameter specifies TRUE for on and FALSE for off. The default is off. 
        /// For more information, see About Mouse Input.
        /// Windows 2000/NT, Windows 98/95:  This value is not supported.
        /// </summary>
        SPI_SETMOUSESONAR = 0x101D,

        /// <summary>
        /// Retrieves the state of the Mouse ClickLock feature. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// if enabled, or FALSE otherwise. For more information, see About Mouse Input.
        /// Windows 2000/NT, Windows 98/95:  This value is not supported.
        /// </summary>
        SPI_GETMOUSECLICKLOCK = 0x101E,

        /// <summary>
        /// Turns the Mouse ClickLock accessibility feature on or off. This feature temporarily locks down the primary mouse button 
        /// when that button is clicked and held down for the time specified by SPI_SETMOUSECLICKLOCKTIME. The uiParam parameter specifies 
        /// TRUE for on, 
        /// or FALSE for off. The default is off. For more information, see Remarks and About Mouse Input on MSDN.
        /// Windows 2000/NT, Windows 98/95:  This value is not supported.
        /// </summary>
        SPI_SETMOUSECLICKLOCK = 0x101F,

        /// <summary>
        /// Retrieves the state of the Mouse Vanish feature. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// if enabled or FALSE otherwise. For more information, see About Mouse Input on MSDN.
        /// Windows 2000/NT, Windows 98/95:  This value is not supported.
        /// </summary>
        SPI_GETMOUSEVANISH = 0x1020,

        /// <summary>
        /// Turns the Vanish feature on or off. This feature hides the mouse pointer when the user types; the pointer reappears 
        /// when the user moves the mouse. The pvParam parameter specifies TRUE for on and FALSE for off. The default is off. 
        /// For more information, see About Mouse Input on MSDN.
        /// Windows 2000/NT, Windows 98/95:  This value is not supported.
        /// </summary>
        SPI_SETMOUSEVANISH = 0x1021,

        /// <summary>
        /// Determines whether native User menus have flat menu appearance. The pvParam parameter must point to a BOOL variable 
        /// that returns TRUE if the flat menu appearance is set, or FALSE otherwise.
        /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETFLATMENU = 0x1022,

        /// <summary>
        /// Enables or disables flat menu appearance for native User menus. Set pvParam to TRUE to enable flat menu appearance 
        /// or FALSE to disable it. 
        /// When enabled, the menu bar uses COLOR_MENUBAR for the menubar background, COLOR_MENU for the menu-popup background, COLOR_MENUHILIGHT 
        /// for the fill of the current menu selection, and COLOR_HILIGHT for the outline of the current menu selection. 
        /// If disabled, menus are drawn using the same metrics and colors as in Windows 2000 and earlier.
        /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETFLATMENU = 0x1023,

        /// <summary>
        /// Determines whether the drop shadow effect is enabled. The pvParam parameter must point to a BOOL variable that returns TRUE 
        /// if enabled or FALSE if disabled.
        /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETDROPSHADOW = 0x1024,

        /// <summary>
        /// Enables or disables the drop shadow effect. Set pvParam to TRUE to enable the drop shadow effect or FALSE to disable it. 
        /// You must also have CS_DROPSHADOW in the window class style.
        /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETDROPSHADOW = 0x1025,

        /// <summary>
        /// Retrieves a BOOL indicating whether an application can reset the screensaver's timer by calling the SendInput function 
        /// to simulate keyboard or mouse input. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// if the simulated input will be blocked, or FALSE otherwise. 
        /// </summary>
        SPI_GETBLOCKSENDINPUTRESETS = 0x1026,

        /// <summary>
        /// Determines whether an application can reset the screensaver's timer by calling the SendInput function to simulate keyboard 
        /// or mouse input. The uiParam parameter specifies TRUE if the screensaver will not be deactivated by simulated input, 
        /// or FALSE if the screensaver will be deactivated by simulated input.
        /// </summary>
        SPI_SETBLOCKSENDINPUTRESETS = 0x1027,
        //#endif /* _WIN32_WINNT >= 0x0501 */

        /// <summary>
        /// Determines whether UI effects are enabled or disabled. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// if all UI effects are enabled, or FALSE if they are disabled.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETUIEFFECTS = 0x103E,

        /// <summary>
        /// Enables or disables UI effects. Set the pvParam parameter to TRUE to enable all UI effects or FALSE to disable all UI effects.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETUIEFFECTS = 0x103F,

        /// <summary>
        /// Retrieves the amount of time following user input, in milliseconds, during which the system will not allow applications 
        /// to force themselves into the foreground. The pvParam parameter must point to a DWORD variable that receives the time.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETFOREGROUNDLOCKTIMEOUT = 0x2000,

        /// <summary>
        /// Sets the amount of time following user input, in milliseconds, during which the system does not allow applications 
        /// to force themselves into the foreground. Set pvParam to the new timeout value.
        /// The calling thread must be able to change the foreground window, otherwise the call fails.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETFOREGROUNDLOCKTIMEOUT = 0x2001,

        /// <summary>
        /// Retrieves the active window tracking delay, in milliseconds. The pvParam parameter must point to a DWORD variable 
        /// that receives the time.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETACTIVEWNDTRKTIMEOUT = 0x2002,

        /// <summary>
        /// Sets the active window tracking delay. Set pvParam to the number of milliseconds to delay before activating the window 
        /// under the mouse pointer.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETACTIVEWNDTRKTIMEOUT = 0x2003,

        /// <summary>
        /// Retrieves the number of times SetForegroundWindow will flash the taskbar button when rejecting a foreground switch request. 
        /// The pvParam parameter must point to a DWORD variable that receives the value.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETFOREGROUNDFLASHCOUNT = 0x2004,

        /// <summary>
        /// Sets the number of times SetForegroundWindow will flash the taskbar button when rejecting a foreground switch request. 
        /// Set pvParam to the number of times to flash.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETFOREGROUNDFLASHCOUNT = 0x2005,

        /// <summary>
        /// Retrieves the caret width in edit controls, in pixels. The pvParam parameter must point to a DWORD that receives this value.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETCARETWIDTH = 0x2006,

        /// <summary>
        /// Sets the caret width in edit controls. Set pvParam to the desired width, in pixels. The default and minimum value is 1.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETCARETWIDTH = 0x2007,

        //#if(_WIN32_WINNT >= 0x0501)
        /// <summary>
        /// Retrieves the time delay before the primary mouse button is locked. The pvParam parameter must point to DWORD that receives 
        /// the time delay. This is only enabled if SPI_SETMOUSECLICKLOCK is set to TRUE. For more information, see About Mouse Input on MSDN.
        /// Windows 2000/NT, Windows 98/95:  This value is not supported.
        /// </summary>
        SPI_GETMOUSECLICKLOCKTIME = 0x2008,

        /// <summary>
        /// Turns the Mouse ClickLock accessibility feature on or off. This feature temporarily locks down the primary mouse button 
        /// when that button is clicked and held down for the time specified by SPI_SETMOUSECLICKLOCKTIME. The uiParam parameter 
        /// specifies TRUE for on, or FALSE for off. The default is off. For more information, see Remarks and About Mouse Input on MSDN.
        /// Windows 2000/NT, Windows 98/95:  This value is not supported.
        /// </summary>
        SPI_SETMOUSECLICKLOCKTIME = 0x2009,

        /// <summary>
        /// Retrieves the type of font smoothing. The pvParam parameter must point to a UINT that receives the information.
        /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETFONTSMOOTHINGTYPE = 0x200A,

        /// <summary>
        /// Sets the font smoothing type. The pvParam parameter points to a UINT that contains either FE_FONTSMOOTHINGSTANDARD, 
        /// if standard anti-aliasing is used, or FE_FONTSMOOTHINGCLEARTYPE, if ClearType is used. The default is FE_FONTSMOOTHINGSTANDARD. 
        /// When using this option, the fWinIni parameter must be set to SPIF_SENDWININICHANGE | SPIF_UPDATEINIFILE; otherwise, 
        /// SystemParametersInfo fails.
        /// </summary>
        SPI_SETFONTSMOOTHINGTYPE = 0x200B,

        /// <summary>
        /// Retrieves a contrast value that is used in ClearType™ smoothing. The pvParam parameter must point to a UINT 
        /// that receives the information.
        /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETFONTSMOOTHINGCONTRAST = 0x200C,

        /// <summary>
        /// Sets the contrast value used in ClearType smoothing. The pvParam parameter points to a UINT that holds the contrast value. 
        /// Valid contrast values are from 1000 to 2200. The default value is 1400.
        /// When using this option, the fWinIni parameter must be set to SPIF_SENDWININICHANGE | SPIF_UPDATEINIFILE; otherwise, 
        /// SystemParametersInfo fails.
        /// SPI_SETFONTSMOOTHINGTYPE must also be set to FE_FONTSMOOTHINGCLEARTYPE.
        /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETFONTSMOOTHINGCONTRAST = 0x200D,

        /// <summary>
        /// Retrieves the width, in pixels, of the left and right edges of the focus rectangle drawn with DrawFocusRect. 
        /// The pvParam parameter must point to a UINT.
        /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETFOCUSBORDERWIDTH = 0x200E,

        /// <summary>
        /// Sets the height of the left and right edges of the focus rectangle drawn with DrawFocusRect to the value of the pvParam parameter.
        /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETFOCUSBORDERWIDTH = 0x200F,

        /// <summary>
        /// Retrieves the height, in pixels, of the top and bottom edges of the focus rectangle drawn with DrawFocusRect. 
        /// The pvParam parameter must point to a UINT.
        /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETFOCUSBORDERHEIGHT = 0x2010,

        /// <summary>
        /// Sets the height of the top and bottom edges of the focus rectangle drawn with DrawFocusRect to the value of the pvParam parameter.
        /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETFOCUSBORDERHEIGHT = 0x2011,

        /// <summary>
        /// Not implemented.
        /// </summary>
        SPI_GETFONTSMOOTHINGORIENTATION = 0x2012,

        /// <summary>
        /// Not implemented.
        /// </summary>
        SPI_SETFONTSMOOTHINGORIENTATION = 0x2013,
    }
    #endregion // SPI

    #region DriveTypes enum
    public enum DriveTypes : uint
    {
        DRIVE_UNKNOWN = 0,
        DRIVE_NO_ROOT_DIR,
        DRIVE_REMOVABLE,
        DRIVE_FIXED,
        DRIVE_REMOTE,
        DRIVE_CDROM,
        DRIVE_RAMDISK
    };
    #endregion // DriveTypes enum

    #region DesiredAccess enum
    public enum DesiredAccess : uint
    {
        GENERIC_READ = 0x80000000,
        GENERIC_WRITE = 0x40000000,
        GENERIC_EXECUTE = 0x20000000,
        GENERIC_ALL = 0x10000000
    }
    #endregion // DesiredAccess enum

    #region FileShareConsts enum
    public enum FileShareConsts : uint
    {
        //Share constants
        FILE_SHARE_READ = 0x00000001,
        FILE_SHARE_WRITE = 0x00000002,
        FILE_SHARE_DELETE = 0x00000004
    }
    #endregion // FileShareConsts enum

    #region CreationDispositionConsts enum
    public enum CreationDispositionConsts : uint
    {
        //CreationDisposition constants
        CREATE_NEW = 1,
        CREATE_ALWAYS = 2,
        OPEN_EXISTING = 3,
        OPEN_ALWAYS = 4,
        TRUNCATE_EXISTING = 5
    }
    #endregion //CreationDispositionConsts enum

    #region IOCTLConsts enum
    public enum IOCTLConsts : uint
    {
        IOCTL_CDROM_READ_TOC = 0x00024000,
        IOCTL_STORAGE_CHECK_VERIFY = 0x002D4800,
        IOCTL_CDROM_RAW_READ = 0x0002403E,
        IOCTL_STORAGE_MEDIA_REMOVAL = 0x002D4804,
        IOCTL_STORAGE_EJECT_MEDIA = 0x002D4808,
        IOCTL_STORAGE_LOAD_MEDIA = 0x002D480C
    }
    #endregion // IOCTLCOnsts enum

    #region WindowIconSize enum
    public enum WindowIconSize : int
    {
        /// <summary>
        /// A small icon used for the window caption.
        /// </summary>
        /// <remarks></remarks>
        Small = 0,
        /// <summary>
        /// A big icon used for Alt-Tab.
        /// </summary>
        /// <remarks></remarks>
        Big = 1,
        /// <summary>
        /// Returns either the small icon, if available, or the system generated one.
        /// </summary>
        /// <remarks></remarks>
        Small2 = 2
    }
    #endregion // WindowIconSize

    #region BeepType enum
    public enum BeepType
    {
        SimpleBeep = -1,
        SystemAsterisk = 0x00000040,
        SystemExclamation = 0x00000030,
        SystemHand = 0x00000010,
        SystemQuestion = 0x00000020,
        SystemDefault = 0
    }
    #endregion // BeepType enum

    #region KeyModifiers enum
    public enum KeyModifiers
    {
        Shift = 0x00000001,
        Control = 0x00000002,
        Alt = 0x00000004
    }
    #endregion

    /*#region RASCONNSTATE enum
	public enum RASCONNSTATE 
	{
  		RASCS_OpenPort				= 0, 
  		RASCS_PortOpened, 
  		RASCS_ConnectDevice, 
  		RASCS_DeviceConnected, 
  		RASCS_AllDevicesConnected, 
  		RASCS_Authenticate, 
  		RASCS_AuthNotify, 
  		RASCS_AuthRetry, 
  		RASCS_AuthCallback, 
  		RASCS_AuthChangePassword, 
  		RASCS_AuthProject, 
  		RASCS_AuthLinkSpeed, 
  		RASCS_AuthAck, 
  		RASCS_ReAuthenticate, 
  		RASCS_Authenticated, 
  		RASCS_PrepareForCallback, 
  		RASCS_WaitForModemReset, 
  		RASCS_WaitForCallback,
  		RASCS_Projected, 
 
		#if (WINVER >= 0x400) 
  		RASCS_StartAuthentication,    // Windows 95 only 
  		RASCS_CallbackComplete,       // Windows 95 only 
  		RASCS_LogonNetwork,           // Windows 95 only 
		#endif 
		
 		RASCS_SubEntryConnected,
  		RASCS_SubEntryDisconnected,
 		RASCS_Interactive = RASCS_PAUSED, 
  		RASCS_RetryAuthentication, 
  		RASCS_CallbackSetByCaller, 
  		RASCS_PasswordExpired, 
  		
		#if (WINVER >= 0x500)
  		RASCS_InvokeEapUI,
		#endif
 
  		RASCS_Connected = RASCS_DONE, 
  		RASCS_Disconnected 
		}  
	#endregion //RASCONNSTATE
	
	#region RASPROJECTION enum
	public enum RASPROJECTION
	{
  		RASP_Amb 	= 0x10000,
  		RASP_PpNbf 	= 0x803F,
		RASP_PppIpx = 0x802B,
		RASP_PppIp 	= 0x8021,
		RASP_PppCcp = 0x80FD,
		RASP_PppLcp = 0xC021,
		RASP_Slip 	= 0x20000
	}
	#endregion //RASPROJECTION
	
	*/

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //

    #region  enum

    #endregion //
}
