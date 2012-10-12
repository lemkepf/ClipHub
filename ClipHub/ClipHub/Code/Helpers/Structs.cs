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
using System.Drawing;
using System.Runtime.InteropServices;
using WpfKlip.Core.Win.Enums;
using System.Windows.Forms;
#endregion

namespace WpfKlip.Core.Win.Structs
{
    #region APPBARDATA
    [StructLayout(LayoutKind.Sequential)]
    public struct APPBARDATA
    {
        public UInt32 cbSize;
        public IntPtr hWnd;
        public UInt32 uCallbackMessage;
        public UInt32 uEdge;
        public RECT rc;
        public Int32 lParam;
    }
    #endregion

    #region MSG struct
    [StructLayout(LayoutKind.Sequential)]
    public struct MSG
    {
        public IntPtr hwnd;
        public int message;
        public IntPtr wParam;
        public IntPtr lParam;
        public int time;
        public int pt_x;
        public int pt_y;
    }
    #endregion //MSG

    #region PAINTSRUCT struct
    [StructLayout(LayoutKind.Sequential)]
    public struct PAINTSTRUCT
    {
        public IntPtr hdc;
        public int fErase;
        public Rectangle rcPaint;
        public int fRestore;
        public int fIncUpdate;
        public int Reserved1;
        public int Reserved2;
        public int Reserved3;
        public int Reserved4;
        public int Reserved5;
        public int Reserved6;
        public int Reserved7;
        public int Reserved8;
    }
    #endregion //PAINTSTRUCT

    #region RECT struct
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
        public RECT(int left, int top, int right, int bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }
        public Rectangle Rect { get { return new Rectangle(this.left, this.top, this.right - this.left, this.bottom - this.top); } }
        public static RECT FromXYWH(int x, int y, int width, int height)
        {
            return new RECT(x,
                            y,
                            x + width,
                            y + height);
        }
        public static RECT FromRectangle(Rectangle rect)
        {
            return new RECT(rect.Left,
                             rect.Top,
                             rect.Right,
                             rect.Bottom);
        }

        public override string ToString()
        {
            return "{left=" + left.ToString() + ", " + "top=" + top.ToString() + ", " +
                "right=" + right.ToString() + ", " + "bottom=" + bottom.ToString() + "}";
        }
    }
    #endregion //RECT

    #region WINDOWPOS struct
    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPOS
    {
        public IntPtr hwnd;
        public IntPtr hWndInsertAfter;
        public int x;
        public int y;
        public int cx;
        public int cy;
        public uint flags;
    }
    #endregion //WINDOWPOS

    #region SHELLHOOKINFO
    public struct SHELLHOOKINFO
    {
        public IntPtr hwnd;
        public RECT rc;
    }
    #endregion

    #region SHFILEINFO struct
    [StructLayout(LayoutKind.Sequential)]
    public struct SHFILEINFO
    {
        public IntPtr hIcon;
        public IntPtr iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    };
    #endregion //SHFILEINFO

    #region POINT struct
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int x;
        public int y;
    }
    #endregion //POINT

    #region POINTF struct
    [StructLayoutAttribute(LayoutKind.Sequential)]
    class POINTF
    {
        internal float X;

        internal float Y;


        internal POINTF()
        {
        }

        internal POINTF(PointF pt)
        {
            X = pt.X;
            Y = pt.Y;
        }

        internal POINTF(Point pt)
        {
            X = pt.X;
            Y = pt.Y;
        }

        internal PointF ToPoint()
        {
            return new PointF(X, Y);
        }
    }
    #endregion

    #region SIZE struct
    [StructLayout(LayoutKind.Sequential)]
    public struct SIZE
    {
        public int cx;
        public int cy;
    }
    #endregion //SIZE

    #region BLENDFUNCTION struct
    [StructLayout(LayoutKind.Sequential)]
    public struct BLENDFUNCTION
    {
        public byte BlendOp;
        public byte BlendFlags;
        public byte SourceConstantAlpha;
        public byte AlphaFormat;
    }
    #endregion //BLENDFUNCTION

    #region TRACKMOUSEEVENTS struct
    [StructLayout(LayoutKind.Sequential)]
    public struct TRACKMOUSEEVENTS
    {
        public const uint TME_HOVER = 0x00000001;
        public const uint TME_LEAVE = 0x00000002;
        public const uint TME_NONCLIENT = 0x00000010;
        public const uint TME_QUERY = 0x40000000;
        public const uint TME_CANCEL = 0x80000000;
        public const uint HOVER_DEFAULT = 0xFFFFFFFF;

        private uint cbSize;
        private uint dwFlags;
        private IntPtr hWnd;
        private uint dwHoverTime;

        public TRACKMOUSEEVENTS(uint dwFlags, IntPtr hWnd, uint dwHoverTime)
        {
            cbSize = 16;
            this.dwFlags = dwFlags;
            this.hWnd = hWnd;
            this.dwHoverTime = dwHoverTime;
        }
    }
    #endregion //TRACKMOUSEEVENTS

    #region TRACKMOUSEEVENT class
    [StructLayout(LayoutKind.Sequential)]
    public class TRACKMOUSEEVENT
    {
        public TRACKMOUSEEVENT()
        {
            this.cbSize = Marshal.SizeOf(typeof(TRACKMOUSEEVENT));
            this.dwHoverTime = 100;
        }
        public int cbSize;
        public int dwFlags;
        public IntPtr hwndTrack;
        public int dwHoverTime;
    }
    #endregion //TRACKMOUSEEVENT

    #region LOGBRUSH struct
    [StructLayout(LayoutKind.Sequential)]
    public struct LOGBRUSH
    {
        public uint lbStyle;
        public uint lbColor;
        public uint lbHatch;
        public NCCALCSIZE_PARAMS l;
    }
    #endregion //LOGBRUSH

    #region NCCALCSIZE_PARAMS struct
    [StructLayout(LayoutKind.Sequential)]
    public struct NCCALCSIZE_PARAMS
    {
        //public RECT rgrc1;
        //public RECT rgrc2;
        //public RECT rgrc3;
        //public IntPtr lppos;
        /// <summary>
        /// Contains the new coordinates of a window that has been moved or resized, that is, it is the proposed new window coordinates.
        /// </summary>
        public RECT rectProposed;
        /// <summary>
        /// Contains the coordinates of the window before it was moved or resized.
        /// </summary>
        public RECT rectBeforeMove;
        /// <summary>
        /// Contains the coordinates of the window's client area before the window was moved or resized.
        /// </summary>
        public RECT rectClientBeforeMove;
        /// <summary>
        /// Pointer to a WINDOWPOS structure that contains the size and position values specified in the operation that moved or resized the window.
        /// </summary>
        public WINDOWPOS lpPos;
    }
    #endregion //_NCCALCSIZE_PARAMS

    #region CWPRETSTRUCT struct
    [StructLayout(LayoutKind.Sequential)]
    public struct CWPRETSTRUCT
    {
        public int lResult;
        public int lParam;
        public int wParam;
        public int message;
        public IntPtr hwnd;
    }
    #endregion //CWPRETSTRUCT

    #region RASADPARAMS struct
    [StructLayout(LayoutKind.Sequential)]
    public struct RASADPARAMS
    {
        public uint dwSize;
        public IntPtr hwndOwner;
        public uint dwFlags;
        public long xDlg;
        public long yDlg;
    }
    #endregion //RASADPARAMS

    #region MARGINS
    [StructLayout(LayoutKind.Sequential)]
    public struct MARGINS
    {
        public int cxLeftWidth;      // width of left border that retains its size
        public int cxRightWidth;     // width of right border that retains its size
        public int cyTopHeight;      // height of top border that retains its size
        public int cyBottomHeight;   // height of bottom border that retains its size
    };
    #endregion

    #region MENUITEMINFO struct
    public struct MENUITEMINFO
    {
        public int cbSize;
        public int fMask;
        public int fType;
        public int fState;
        public int wID;
        public IntPtr hSubMenu;
        public IntPtr hbmpChecked;
        public IntPtr hbmpUnchecked;
        public IntPtr dwItemData;
        public String dwTypeData;
        public int cch;
        public IntPtr hbmpItem;

        public static int sizeOf
        {
            get { return Marshal.SizeOf(typeof(MENUITEMINFO)); }
        }
    }
    #endregion //MENUITEMINFO

    #region CHARFORMAT2 struct
    [StructLayout(LayoutKind.Sequential)]
    public struct CHARFORMAT2
    {
        public UInt32 cbSize;
        public UInt32 dwMask;
        public UInt32 dwEffects;
        public Int32 yHeight;
        public Int32 yOffset;
        public Int32 crTextColor;
        public byte bCharSet;
        public byte bPitchAndFamily;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] szFaceName;
        public UInt16 wWeight;
        public UInt16 sSpacing;
        public int crBackColor; // Color.ToArgb() -> int
        public int lcid;
        public int dwReserved;
        public Int16 sStyle;
        public Int16 wKerning;
        public byte bUnderlineType;
        public byte bAnimation;
        public byte bRevAuthor;
        public byte bReserved1;
    }
    #endregion //CHARFORMAT2

    #region WNDCLASS struct
    public struct WNDCLASS
    {
        public uint style;
        public WndProc lpfnWndProc;
        public int cbClsExtra;
        public int cbWndExtra;
        public IntPtr hInstance;
        public IntPtr hIcon;
        public IntPtr hCursor;
        public IntPtr hbrBackground;
        public string lpszMenuName;
        public string lpszClassName;
    }
    #endregion //WNDCLASS struct

    #region  WNDCLASSEX struct
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct WNDCLASSEX
    {
        [MarshalAs(UnmanagedType.U4)]
        public int cbSize;
        [MarshalAs(UnmanagedType.U4)]
        public uint style;
        public WndProc lpfnWndProc;
        public int cbClsExtra;
        public int cbWndExtra;
        public IntPtr hInstance;
        public IntPtr hIcon;
        public IntPtr hCursor;
        public IntPtr hbrBackground;
        public string lpszMenuName;
        public string lpszClassName;
        public IntPtr hIconSm;
    }
    #endregion //WNDCLASSEX struct

    #region MINIMIZEDMETRICS struct
    public struct MINIMIZEDMETRICS
    {
        public int cbSize;
        public int iWidth;
        public int iHorzGap;
        public int iVertGap;
        public int iArrange;
    }
    #endregion //MINIMIZEDMETRICS struct

    #region MINMAXINFO
    public struct MINMAXINFO
    {
        public POINT ptReserved;
        public POINT ptMaxSize;
        public POINT ptMaxPosition;
        public POINT ptMinTrackSize;
        public POINT ptMaxTrackSize;
    }
    #endregion

    #region MyStruct struct
    [StructLayout(LayoutKind.Sequential)]
    internal struct MyStruct
    {
        public int SomeValue;
        public byte b1;
        public byte b2;
        public byte b3;
        public byte b4;
        public byte b5;
        public byte b6;
        public byte b7;
        public byte b8;
    }
    #endregion MyStruct

    #region GDITextMetric struct
    [StructLayout(LayoutKind.Sequential)]
    public struct GDITextMetric
    {
        public int tmMemoryHeight;
        public int tmAscent;
        public int tmDescent;
        public int tmInternalLeading;
        public int tmExternalLeading;
        public int tmAveCharWidth;
        public int tmMaxCharWidth;
        public int tmWeight;
        public int tmOverhang;
        public int tmDigitizedAspectX;
        public int tmDigitizedAspectY;
        public byte tmFirstChar;
        public byte tmLastChar;
        public byte tmDefaultChar;
        public byte tmBreakChar;
        public byte tmItalic;
        public byte tmUnderlined;
        public byte tmStruckOut;
        public byte tmPitchAndFamily;
        public byte tmCharSet;
    }
    #endregion //GDITextMetric

    #region GUIthreadinfo
    [StructLayout(LayoutKind.Sequential)]
    public struct GUITHREADINFO
    {
        public int cbSize;
        public int flags;
        public IntPtr hwndActive;
        public IntPtr hwndFocus;
        public IntPtr hwndCapture;
        public IntPtr hwndMenuOwner;
        public IntPtr hwndMoveSize;
        public IntPtr hwndCaret;
        public RECT rcCaret;
    }

    #endregion

    #region ENUMLOGFONTEX struct
    [StructLayout(LayoutKind.Sequential)]
    public class ENUMLOGFONTEX
    {
        public LogFont elfLogFont = null;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string elfFullName = "";
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] elfStyle = null;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] elfScript = null;
    }
    #endregion

    #region LogFont struct
    [StructLayout(LayoutKind.Sequential)]
    public class LogFont
    {
        public int lfHeight = 0;
        public int lfWidth = 0;
        public int lfEscapement = 0;
        public int lfOrientation = 0;
        public int lfWeight = 0;
        public byte lfItalic = 0;
        public byte lfUnderline = 0;
        public byte lfStrikeOut = 0;
        public byte lfCharSet = 0;
        public byte lfOutPrecision = 0;
        public byte lfClipPrecision = 0;
        public byte lfQuality = 0;
        public byte lfPitchAndFamily = 0;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string lfFaceName = "";
    }
    #endregion LogFont

    #region TBUTTONINFO struct
    /// <summary>
    /// Contains information for a specific button in a toolbar.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TBBUTTONINFO
    {
        /// <summary>
        /// Size of the structure, in bytes.
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// Set of flags that indicate which members contain valid information.
        /// </summary>
        public ToolBarInfo dwMask;

        /// <summary>
        /// Command identifier of the button. 
        /// </summary>
        public int idCommand;

        /// <summary>
        /// Image index of the button.
        /// </summary>
        public int iImage;

        /// <summary>
        /// State flags of the button.
        /// </summary>
        public byte fsState;

        /// <summary>
        /// Style flags of the button.
        /// </summary>
        public byte fsStyle;

        /// <summary>
        /// Width of the button, in pixels.
        /// </summary>
        public short cx;

        /// <summary>
        /// Application-defined value associated with the button.
        /// </summary>
        public UIntPtr lParam;

        /// <summary>
        /// Address of a character buffer that contains or receives the button text.
        /// </summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string lpszText;

        /// <summary>
        /// Size of the buffer at pszText.
        /// </summary>
        public int cchText;
    }
    #endregion //TBBUTTONINFO struct

    #region CWPSTRUCT struct
    /// <summary>
    /// Windows calls this hook whenever the Windows SendMessage function is called. 
    /// The filter functions receive a hook code from Windows indicating whether the message was sent 
    /// from the current thread and receive a pointer to a structure containing the actual message.
    /// The CWPSTRUCT structure has the following form:
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CWPSTRUCT
    {
        public IntPtr lParam;
        public IntPtr wParam;
        public int message;
        public IntPtr hwnd;
    }
    #endregion //CWPSTRUCT struct

    #region COPYDATASTRUCT struct
    [StructLayout(LayoutKind.Sequential)]
    public struct COPYDATASTRUCT
    {
        public int dwData;
        public int cbData;
        public IntPtr lpData;
    }
    #endregion //COPYDATASTRUCT

    #region NOTIFYICONDATA struct
    public struct NOTIFYICONDATA
    {
        /// <summary>
        /// Size of this structure, in bytes. 
        /// </summary>
        public int cbSize;

        /// <summary>
        /// Handle to the window that receives notification messages associated with an icon in the 
        /// taskbar status area. The Shell uses hWnd and uID to identify which icon to operate on 
        /// when Shell_NotifyIcon is invoked. 
        /// </summary>
        public IntPtr hwnd;

        /// <summary>
        /// Application-defined identifier of the taskbar icon. The Shell uses hWnd and uID to identify 
        /// which icon to operate on when Shell_NotifyIcon is invoked. You can have multiple icons 
        /// associated with a single hWnd by assigning each a different uID. 
        /// </summary>
        public int uID;

        /// <summary>
        /// Flags that indicate which of the other members contain valid data. This member can be 
        /// a combination of the NIF_XXX constants.
        /// </summary>
        public int uFlags;

        /// <summary>
        /// Application-defined message identifier. The system uses this identifier to send 
        /// notifications to the window identified in hWnd. 
        /// </summary>
        public int uCallbackMessage;

        /// <summary>
        /// Handle to the icon to be added, modified, or deleted. 
        /// </summary>
        public IntPtr hIcon;

        /// <summary>
        /// String with the text for a standard ToolTip. It can have a maximum of 64 characters including 
        /// the terminating NULL. For Version 5.0 and later, szTip can have a maximum of 
        /// 128 characters, including the terminating NULL.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szTip;

        /// <summary>
        /// State of the icon. 
        /// </summary>
        public int dwState;

        /// <summary>
        /// A value that specifies which bits of the state member are retrieved or modified. 
        /// For example, setting this member to NIS_HIDDEN causes only the item's hidden state to be retrieved. 
        /// </summary>
        public int dwStateMask;

        /// <summary>
        /// String with the text for a balloon ToolTip. It can have a maximum of 255 characters. 
        /// To remove the ToolTip, set the NIF_INFO flag in uFlags and set szInfo to an empty string. 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string szInfo;

        /// <summary>
        /// NOTE: This field is also used for the Timeout value. Specifies whether the Shell notify 
        /// icon interface should use Windows 95 or Windows 2000 
        /// behavior. For more information on the differences in these two behaviors, see 
        /// Shell_NotifyIcon. This member is only employed when using Shell_NotifyIcon to send an 
        /// NIM_VERSION message. 
        /// </summary>
        public int uVersion;

        /// <summary>
        /// String containing a title for a balloon ToolTip. This title appears in boldface 
        /// above the text. It can have a maximum of 63 characters. 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szInfoTitle;

        /// <summary>
        /// Adds an icon to a balloon ToolTip. It is placed to the left of the title. If the 
        /// szTitleInfo member is zero-length, the icon is not shown. See 
        /// <see cref="BalloonIconStyle">RMUtils.WinAPI.Structs.BalloonIconStyle</see> for more
        /// information.
        /// </summary>
        public int dwInfoFlags;
    }
    #endregion //NOTIFYICONDATA struct

    #region WINDOWINFO struct
    [StructLayout(LayoutKind.Sequential)]
    struct WINDOWINFO
    {
        public uint cbSize;
        public RECT rcWindow;
        public RECT rcClient;
        public uint dwStyle;
        public uint dwExStyle;
        public uint dwWindowStatus;
        public uint cxWindowBorders;
        public uint cyWindowBorders;
        public ushort atomWindowType;
        public ushort wCreatorVersion;
    }
    #endregion //WINDOWINFO

    #region TRACK_DATA struct
    [StructLayout(LayoutKind.Sequential)]
    public struct TRACK_DATA
    {
        public byte Reserved;
        private byte BitMapped;
        public byte Control
        {
            get
            {
                return (byte)(BitMapped & 0x0F);
            }
            set
            {
                BitMapped = (byte)((BitMapped & 0xF0) | (value & (byte)0x0F));
            }
        }
        public byte Adr
        {
            get
            {
                return (byte)((BitMapped & (byte)0xF0) >> 4);
            }
            set
            {
                BitMapped = (byte)((BitMapped & (byte)0x0F) | (value << 4));
            }
        }
        public byte TrackNumber;
        public byte Reserved1;
        /// <summary>
        /// Don't use array to avoid array creation
        /// </summary>
        public byte Address_0;
        public byte Address_1;
        public byte Address_2;
        public byte Address_3;
    };

    #endregion

    [StructLayout(LayoutKind.Sequential)]
    public class TrackDataList
    {
        public const int MAXIMUM_NUMBER_TRACKS = 100;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAXIMUM_NUMBER_TRACKS * 8)]
        private byte[] Data;
        public TRACK_DATA this[int Index]
        {
            get
            {
                if ((Index < 0) | (Index >= MAXIMUM_NUMBER_TRACKS))
                {
                    throw new IndexOutOfRangeException();
                }
                TRACK_DATA res;
                GCHandle handle = GCHandle.Alloc(Data, GCHandleType.Pinned);
                try
                {
                    IntPtr buffer = handle.AddrOfPinnedObject();
                    buffer = (IntPtr)(buffer.ToInt32() + (Index * Marshal.SizeOf(typeof(TRACK_DATA))));
                    res = (TRACK_DATA)Marshal.PtrToStructure(buffer, typeof(TRACK_DATA));
                }
                finally
                {
                    handle.Free();
                }
                return res;
            }
        }
        public TrackDataList()
        {
            Data = new byte[MAXIMUM_NUMBER_TRACKS * Marshal.SizeOf(typeof(TRACK_DATA))];
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public class CDROM_TOC
    {
        public ushort Length;
        public byte FirstTrack = 0;
        public byte LastTrack = 0;

        public TrackDataList TrackData;

        public CDROM_TOC()
        {
            TrackData = new TrackDataList();
            Length = (ushort)Marshal.SizeOf(this);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public class PREVENT_MEDIA_REMOVAL
    {
        public byte PreventMediaRemoval = 0;
    }


    [StructLayout(LayoutKind.Sequential)]
    public class RAW_READ_INFO
    {
        public long DiskOffset = 0;
        public uint SectorCount = 0;
        public TRACK_MODE_TYPE TrackMode = TRACK_MODE_TYPE.CDDA;
    }



    [StructLayout(LayoutKind.Sequential)]
    public struct KEYBOARD_INPUT
    {
        public uint type;
        public ushort vk;
        public ushort scanCode;
        public uint flags;
        public uint time;
        public uint extrainfo;
        public uint padding1;
        public uint padding2;
    }

    /*	#region RASAMB struct
	[StructLayout(LayoutKind.Sequential)]
	public struct RASAMB
	{
		public uint dwSize;
		public uint dwError;
		public char szNetBiosError = new char[NETBIOS_NAME_LEN + 1];
		public byte bLana;
	}
	#endregion //RASAMB
	
	#region RASAUTODIALENTRY struct
	[StructLayout(LayoutKind.Sequential)]
	public struct RASAUTODIALENTRY
	{  
		public uint dwSize;
		public uint dwFlags;
		public uint dwDialingLocation;
		public char szEntry = new char[RAS_MaxEntryName + 1];
	} 
	#endregion //RASAUTODIALENTRY
	
	#region RASCOMMSETTINGS struct
	[StructLayout(LayoutKind.Sequential)]
	public struct RASCOMMSETTINGS 
	{  
		public uint dwSize;
		public byte bParity;
		public byte bStop;
		public byte bByteSize;
		public byte bAlign;
	} 
	#endregion //RASCOMMSETTINGS
	
	/*#region RASCONN struct
	[StructLayout(LayoutKind.Sequential)]
	public struct RASCONN 
	{
  		public uint     dwSize;
  		public HRASCONN  hrasconn;
  		public char     szEntryName = new char[RAS_MaxEntryName + 1];

  		#if (WINVER >= 0x400)
  		public char    szDeviceType = new char[ RAS_MaxDeviceType + 1 ];
  		public char    szDeviceName = new char[ RAS_MaxDeviceName + 1 ];										   
		#endif
		#if (WINVER >= 0x401)
   		public char    szPhonebook = new char[ MAX_PATH ];
   		public uint    dwSubEntry;
		#endif
		#if (WINVER >= 0x500)
   		public Guid     guidEntry;
		#endif
		#if (WINVER >= 0x501)
   		public uint     dwFlags;
   		public Luid      luid;													
		#endif
	} 
	#endregion //RASCONN
	
	#region RASCONNSTATUS struct
	[StructLayout(LayoutKind.Sequential)]
	public struct RASCONNSTATUS
	{
  		public uint         dwSize; 
  		public RASCONNSTATE rasconnstate; 
  		public uint         dwError; 
  		public char         szDeviceType = new char[RAS_MaxDeviceType + 1]; 
  		public char         szDeviceName = new char[RAS_MaxDeviceName + 1];
		#if (WINVER >= 0x401)
  		public public char  szPhoneNumber = new char[ RAS_MaxPhoneNumber + 1 ];
		#endif // (WINVER >= 0x401)
	} 
	#endregion //RASCONNSTATUS
	
	#region ASCREDENTIALS struct
	[StructLayout(LayoutKind.Sequential)]
	public struct ASCREDENTIALS
	{  
		 public uint dwSize;
		 public uint dwMask;
		 public char szUserName = new char[UNLEN + 1];
		 public char szPassword = new char[PWLEN + 1];
		 public char szDomain = new char[DNLEN + 1];
	}
	#endregion //ASCREDENTIALS
	
	#region RASCUSTOMSCRIPTEXTENSIONS struct
	[StructLayout(LayoutKind.Sequential)]
	public struct RASCUSTOMSCRIPTEXTENSIONS 
	{  
		public uint dwSize;  
		public PFNRASSETCOMMSETTINGS pfRasSetCommSettings ;
	}
	#endregion //RASCUSTOMSCRIPTEXTENSIONS
	
	#region RASCTRYINFO struct
	[StructLayout(LayoutKind.Sequential)]
	public struct RASCTRYINFO 
	{  
		public uint dwSize;  
		public uint dwCountryID;  
		public uint dwNextCountryID;  
		public uint dwCountryCode;  
		public uint dwCountryNameOffset;
	}
	#endregion //RASCTRYINFO
	
	#region RASDEVINFO struct
	[StructLayout(LayoutKind.Sequential)]
	public struct RASDEVINFO 
	{  
		public uint dwSize;  
		public char szDeviceType = new char[RAS_MaxDeviceType + 1];  
		public char szDeviceName = new char[RAS_MaxDeviceName + 1];
	}
	#endregion //RASDEVINFO
	
	#region RASDIALDLG struct 
	[StructLayout(LayoutKind.Sequential)]
	public struct RASDIALDLG
	{  
		 public uint dwSize;  
		 public IntPtr hwndOwner;  
		 public uint dwFlags;  
		 public long xDlg;  
		 public long yDlg;  
		 public uint dwSubEntry;  
		 public uint dwError;  
		 public IntPtr reserved;  
		 public IntPtr reserved2;
		 
	}
	#endregion //RASDIALDLG
	
	#region RASDIALEXTENSIONS struct
	[StructLayout(LayoutKind.Sequential)]
	public struct RASDIALEXTENSIONS
	{
    	public uint     dwSize;
    	public uint     dwfOptions;
    	public IntPtr      hwndParent;
    	public IntPtr reserved;
    	#if (WINVER >= 0x500)
    	public IntPtr reserved1;
    	public RASEAPINFO RasEapInfo;
    	#endif
	}
	#endregion //RASDIALEXTENSIONS
	
	#region RASDIALPARAMS struct
	[StructLayout(LayoutKind.Sequential)]
	public struct RASDIALPARAMS
	{
  		public uint  dwSize; 
  		public char  szEntryName = new char[RAS_MaxEntryName + 1]; 
  		public char  szPhoneNumber = new char[RAS_MaxPhoneNumber + 1]; 
  		public char  szCallbackNumber = new char[RAS_MaxCallbackNumber + 1]; 
  		public char  szUserName = new char[UNLEN + 1]; 
  		public char  szPassword = new char[PWLEN + 1]; 
  		public char  szDomain = new char[DNLEN + 1] ; 
		#if (WINVER >= 0x401)
  		public uint      dwSubEntry;
  		public IntPtr  dwCallbackId;
		#endif
	}
	#endregion //RASDIALPARAMS
	
	#region RASEAPINFO struct
	[StructLayout(LayoutKind.Sequential)]
	public struct RASEAPINFO 
	{  
		public uint dwSizeofEapInfo; 
		public BYTE* pbEapInfo;
	}
	#endregion //RASEAPINFO
	
	#region RASEAPUSERIDENTITY struct
	[StructLayout(LayoutKind.Sequential)]
	public struct RASEAPUSERIDENTITY 
	{  
		public char szUserName = new char[UNLEN + 1];  
		public uint dwSizeofEapInfo;  
		public byte pbEapInfo;
}
	#endregion //RASEAPUSERIDENTITY
	
	#region RASENTRY struct 
	[StructLayout(LayoutKind.Sequential)]
	public struct RASENTRY 
	{
  		public uint      dwSize;
  		public uint      dwfOptions;
  		//
  		// Location/phone number.
  		//
  		public uint      dwCountryID;
  		public uint      dwCountryCode;
  		public char      szAreaCode = new char[RAS_MaxAreaCode + 1];
  		public char      szLocalPhoneNumber = new char[RAS_MaxPhoneNumber + 1];
  		public uint      dwAlternateOffset;
  		//
  		// PPP/Ip
  		//
  		public RASIPADDR  ipaddr;
  		public RASIPADDR  ipaddrDns;
  		public RASIPADDR  ipaddrDnsAlt;
  		public RASIPADDR  ipaddrWins;
  		public RASIPADDR  ipaddrWinsAlt;
  		//
  		// Framing
  		//
  		public uint      dwFrameSize;
  		public uint      dwfNetProtocols;
  		public uint      dwFramingProtocol;
  		//
  		// Scripting
  		//
  		public char      szScript = new char[MAX_PATH];
  		//
  		// AutoDial
  		//
  		public char      szAutodialDll = new char[MAX_PATH];
  		public char      szAutodialFunc = new char[MAX_PATH];
  		//
  		// Device
  		//
  		public char      szDeviceType = new char[RAS_MaxDeviceType + 1];
  		public char      szDeviceName = new char[RAS_MaxDeviceName + 1];
  		//
  		// X.25
  		//
  		public char      szX25PadType = new char[RAS_MaxPadType + 1];
  		public char      szX25Address = new char[RAS_MaxX25Address + 1];
  		public char      szX25Facilities = new char[RAS_MaxFacilities + 1];
  		public char      szX25UserData = new char[RAS_MaxUserData + 1];
  		public uint      dwChannels;
  		//
  		// Reserved
  		//
  		public uint      dwReserved1;
  		public uint      dwReserved2;
		#if (WINVER >= 0x401)
  		//
  		// Multilink and BAP
  		//
  		public uint      dwSubEntries;
  		public uint      dwDialMode;
  		public uint      dwDialExtraPercent;
  		public uint      dwDialExtraSampleSeconds;
  		public uint      dwHangUpExtraPercent;
  		public uint      dwHangUpExtraSampleSeconds;
  		//
  		// Idle time out
  		//
  		public uint      dwIdleDisconnectSeconds;
		#endif
		#if (WINVER >= 0x500)
  		public uint      dwType;
  		public uint      dwEncryptionType;
  		public uint      dwCustomAuthKey;
  		public Guid       guidId;
   
  		public char      szCustomDialDll = new char[MAX_PATH]; 
  		public uint      dwVpnStrategy; 
		#endif
		#if (WINVER >= 0x501)
  		public uint      dwfOptions2;
  		public uint      dwfOptions3;
  		public char      szDnsSuffix = new char[RAS_MaxDnsSuffix];
 	    public uint      dwTcpWindowSize;
  		public char      szPrerequisitePbk = new char[MAX_PATH];
  		public char      szPrerequisiteEntry = new char[RAS_MaxEntryName + 1];
  		public uint      dwRedialCount;
  		public uint      dwRedialPause;
		#endif
	}
	#endregion //RASENTRY
	
	#region RASENTRYDLG struct	
	[StructLayout(LayoutKind.Sequential)]
	public struct RASENTRYDLG 
	{   
		public uint dwSize;   
		public IntPtr hwndOwner;   
		public uint dwFlags;   
		public long xDlg;   
		public long yDlg;  
		public char szEntry = new char[RAS_MaxEntryName + 1];  
		public uint dwError;   
		public IntPtr reserved;   
		public IntPtr reserved2;
	}
	#endregion //RASENTRYDLG
	
	#region RASENTRYNAME struct	
	[StructLayout(LayoutKind.Sequential)]
	public struct RASENTRYNAME 
	{
  		public uint  dwSize; 
  		public char  szEntryName = new char[RAS_MaxEntryName + 1]; 
		#if (WINVER >= 0x500)
  		public uint dwFlags;
  		public char  szPhonebookPath = new char[MAX_PATH + 1];
		#endif
	}
	#endregion //RASENTRYNAME
	
	#region RASIPADDR struct	
	[StructLayout(LayoutKind.Sequential)]
	public struct RASIPADDR 
	{  
		public byte a;
		public byte b;  
		public byte c;
		public byte d;
	}
	#endregion //RASIPADDR
	
	
	#region RASMONITORDLG struct	
	[StructLayout(LayoutKind.Sequential)]
	public struct RASMONITORDLG 
	{  
		public uint dwSize;  
		public IntPtr hwndOwner;  
		public uint dwFlags;  
		public uint dwStartPage;  
		public long xDlg;  
		public long yDlg;  
		public uint dwError;  
		public IntPtr reserved;  
		public IntPtr reserved2;
	}
	#endregion //RASMONITORDLG
	
	#region RASNOUSER struct	
	[StructLayout(LayoutKind.Sequential)]
	public struct RASNOUSER 
	{   
		public uint dwSize;   
		public uint dwFlags;  
		public uint dwTimeoutMs;  
		public char szUserName = new char[UNLEN + 1];  
		public char szPassword = new char[PWLEN + 1];  
		public char szDomain = new char[DNLEN + 1];
}
	#endregion //RASNOUSER
	
	#region RASPBDLG struct	
	[StructLayout(LayoutKind.Sequential)]
	public struct RASPBDLG 
	{   
		public uint dwSize;   
		public IntPtr hwndOwner;   
		public uint dwFlags;   
		public long xDlg;   
		public long yDlg;   
		public IntPtr dwCallbackId;   
		public RASPBDLGFUNC pCallback;  
		public uint dwError;   
		public IntPtr reserved;   
		public IntPtr reserved2;
}
	#endregion //RASPBDLG 
	
	#region RASPPPCCP struct	
	[StructLayout(LayoutKind.Sequential)]
	public struct RASPPPCCP 
	{  
		public uint dwSize;  
		public uint dwError;  
		public uint dwCompressionAlgorithm;  
		public uint dwOptions;  
		public uint dwServerCompressionAlgorithm;  
		public uint dwServerOptions;
}
	#endregion //RASPPPCCP
	
	#region RASPPPIP struct	
	[StructLayout(LayoutKind.Sequential)]
	public  struct  RASPPPIP 
	{
  		public uint    dwSize; 
  		public uint    dwError; 
  		public char    szIpAddress = new char[RAS_MaxIpAddress + 1]; 
		#ifndef WINNT35COMPATIBLE
  		public char    szServerIpAddress = new char[RAS_MaxIpAddress + 1];
		#endif
		#if (WINVER >= 0x500)
  		public uint    dwOptions;
  		public uint    dwServerOptions;
		#endif
	}
	#endregion //RASPPPIP
	
	#region RASPPPIPX struct	
	[StructLayout(LayoutKind.Sequential)]
	public struct RASPPPIPX 
	{  
		public uint dwSize;  
		public uint dwError;  
		public char szIpxAddress = new char[RAS_MaxIpxAddress + 1];
	}
	#endregion //RASPPPIPX
	
	#region RASPPPLCP struct	
	[StructLayout(LayoutKind.Sequential)]
	public  struct  RASPPPLCP 
	{
  		public uint dwSize;
  		public int  fBundled;
		#if (WINVER >= 0x500)
  		public uint  dwError;
  		public uint  dwAuthenticationProtocol;
  		public uint  dwAuthenticationData;
  		public uint  dwEapTypeId;
  		public uint  dwServerAuthenticationProtocol;
  		public uint  dwServerAuthenticationData;
  		public uint  dwServerEapTypeId;
  		int   fMultilink;
  		public uint  dwTerminateReason;
  		public uint  dwServerTerminateReason;
  		public char  szReplyMessage = new char[RAS_MaxReplyMessage];
  		public uint  dwOptions;
  		public uint  dwServerOptions;
		#endif
	}
	#endregion //RASPPPLCP
	
	#region RASPPPNBF struct
	[StructLayout(LayoutKind.Sequential)]
	public struct RASPPPNBF 
	{  
		public uint dwSize;  
		public uint dwError;  
		public uint dwNetBiosError;  
		public char szNetBiosError = new char[NETBIOS_NAME_LEN + 1];  
		public char szWorkstationName = new char[NETBIOS_NAME_LEN + 1];  
		public byte bLana;
	}
	#endregion //RASPPPNBF
	
	#region RASSLIP struct	
	[StructLayout(LayoutKind.Sequential)]
	public struct RASSLIP 
	{  
		public uint dwSize;  
		public uint dwError;  
		public char szIpAddress = new char[RAS_MaxIpAddress + 1];
}
	#endregion //
	
	#region RASSUBENTRY struct	
	[StructLayout(LayoutKind.Sequential)]
	public struct RASSUBENTRY 
	{  
		public uint dwSize;
		public uint dwfFlags;  
		public char szDeviceType = new char[RAS_MaxDeviceType + 1];  
		public char szDeviceName = new char[RAS_MaxDeviceName + 1];  
		public char szLocalPhoneNumber = new char[RAS_MaxPhoneNumber + 1];  
		public uint dwAlternateOffset;
	}
	#endregion //RASSUBENTRY
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	
	#region struct	
	[StructLayout(LayoutKind.Sequential)]
	#endregion //
	*/


}
