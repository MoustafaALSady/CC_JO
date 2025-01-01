Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Public Class Wallpaper
    Const SPI_SETDESKWALLPAPER As Integer = 20
    Const SPIF_UPDATEINIFILE As Integer = &H1&
    Const SPIF_SENDWININICHANGE As Integer = &H2&


    <DllImport("user32")>
    Public Shared Function SystemParametersInfo(ByVal uAction As Integer,
        ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer
    End Function
    Public Enum Style As Integer
        Tiled
        Centered
        Stretched
    End Enum
    Public Sub SetWallpaper(ByVal path As String, ByVal selectedStyle As Style)
        Dim key As RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Control Panel\Desktop", True)
        Select Case selectedStyle
            Case Style.Stretched
                key.SetValue("WallpaperStyle", "2")
                key.SetValue("TileWallpaper", "0")
            Case Style.Centered
                key.SetValue("WallpaperStyle", "1")
                key.SetValue("TileWallpaper", "0")
            Case Style.Tiled
                key.SetValue("WallpaperStyle", "1")
                key.SetValue("TileWallpaper", "1")
        End Select
        Dim unused = SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_UPDATEINIFILE Or SPIF_SENDWININICHANGE)
    End Sub
End Class
