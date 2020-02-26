Imports System
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Drawing.Imaging
Imports System.IO
Imports Com.Suprema
Imports Com.Suprema.Hid
Imports Com.Suprema.HidScanner
Imports SupremaLFD
Imports System.Runtime.InteropServices

Public Class FingerPrinter
    Inherits Form

    Public Const DbtDevicearrival As Integer = &H8000 'system detected a new device
    Public Const DbtDeviceremovecomplete As Integer = &H8004 'device is gone
    Public Const DbtDevnodesChanged As Integer = &H7 'HID device changes
    Public Const WmDevicechange As Integer = &H219 'device change event
    Public mHidScanner As HidScanner = Nothing
    Public mHidScanners As HidScanner()
    Public mHidScannerCount As Integer = 0
    Public mSelectedDevIdx As Integer = 0
    Public mCurrentImageType As Extra = Extra.SIMG_RAW
    Public mFwUpgradeTimer As Timer
    Public mFwTimerCount As Integer = 0
    Private imgHuella As Image
    Private statusSupremaAux As Boolean = False
    Private txtTemplate As Byte()
    Private txtRecvSize As Integer
    Private txtRecvType As String

    Property txtReceiveType As String
        Get
            Return txtRecvType
        End Get
        Set(value As String)
            txtRecvType = value
        End Set
    End Property

    Property TextReceive As Integer
        Get
            Return txtRecvSize
        End Get
        Set(value As Integer)
            txtRecvSize = value
        End Set
    End Property

    Property TextTemplate As Byte()
        Get
            Return txtTemplate
        End Get
        Set(value As Byte())
            txtTemplate = value
        End Set
    End Property

    Property StatusSuprema As Boolean
        Get
            Return statusSupremaAux
        End Get
        Set(value As Boolean)
            statusSupremaAux = value
        End Set
    End Property
    Property ImgHuellaGet As Image
        Get
            Return imgHuella
        End Get
        Set(value As Image)
            imgHuella = value
        End Set
    End Property

    Public Sub Main()
        Dim nDeviceType As Integer = 1
        SupremaLFD.Liblfd.LIBLFD_Init(nDeviceType)
    End Sub

    Public __UpdateDeviceListSleep As Integer = 0
    Public __IsUpdateInProgress As Boolean = False

    Public Sub cbTemplateFormat_SelectedIndexChanged()
        Dim format = CInt(Extra.STEMPLATE_ISO)
        Dim err As Integer = mHidScanners(mSelectedDevIdx).SetTemplateFormat(format)
    End Sub

    Public Sub UpdateDeviceListWithSleep()
        __IsUpdateInProgress = True
        Threading.Thread.Sleep(__UpdateDeviceListSleep)
        UpdateDeviceList()
        __IsUpdateInProgress = False
    End Sub

    Public Sub onFinger()
        Try
            mHidScanners(mSelectedDevIdx).CaptureSingle(AddressOf CaptureCallback)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub cbLFDLevel_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        'cbLFDLevel.SelectedIndex
        Dim err As Integer = mHidScanners(mSelectedDevIdx).SetLFDLevel(5)

        'If Err() <> CInt([Error].ECH_SUCCESS) Then
        'Log("Failed to set lfd level(err:" & err & ")" & vbCrLf)
        'End If
    End Sub

    Public Sub btnExtract_Click()
        Dim err As Integer = mHidScanners(mSelectedDevIdx).ExtractFromCapturedImage()

        If err = CInt([Error].ECH_SUCCESS) Then
            'Log("Successed to extract template" & vbCrLf)
        Else
            'Log("failed to extract template(error: " & err & ")" & vbCrLf)
        End If
    End Sub

    Public Sub btnRecvTemplate_Click()
        Dim templateData As Byte() = Nothing
        Dim templateSize As Integer = 0
        Dim templateType As Integer = 0
        Dim templateQuality As Integer = 0
        Dim err As Integer = mHidScanners(mSelectedDevIdx).ReceiveCaptureTemplate(templateData, templateQuality, templateSize, templateType, False)

        If err = CInt([Error].ECH_SUCCESS) Then
            Dim s As String = BitConverter.ToString(templateData).Replace("-", String.Empty)
            s = Regex.Replace(s, "[^\u0020-\u007E]+", String.Empty)
            Dim txData As Byte() = Enumerable.Range(0, s.Length).Where(Function(x) x Mod 2 = 0).[Select](Function(x) Convert.ToByte(s.Substring(x, 2), 16)).ToArray()
            Dim myinteger As Integer
            myinteger = CInt(templateSize.ToString())
            TextTemplate = txData
            TextReceive = myinteger
            txtReceiveType = templateType.ToString()
        Else
            'Log("Failed to receive template data(error:" & err & ")" & vbCrLf)
        End If
    End Sub

    Public Sub CaptureCallback(ByVal err As Integer, ByVal image_data As Byte(), ByVal size As Integer, ByVal type As Integer)
        If err = CInt([Error].ECH_SUCCESS) Then
            'MessageBox.Show("Captura Completada")
        Else
            If err = -43 Then
                'MessageBox.Show("Error capturando la huella")
                Return
                'Log("Fake Finger(H/W) !!!")
            Else
                'MessageBox.Show("Error capturando la huella")
                Return
                'Log("Capture Fail! (error: " & err & ")" & vbCrLf)
            End If
        End If


        If image_data IsNot Nothing Then

            If type = CInt(Extra.SIMG_RAW) Then
                '191001_Jack =>
                Dim nWidth As Integer = mHidScanners(mSelectedDevIdx).GetWidth()
                Dim nHeight As Integer = mHidScanners(mSelectedDevIdx).GetHeight()
                Dim pbyTemp As Byte() = New Byte(nWidth * nHeight - 1) {}
                Array.Copy(image_data, pbyTemp, nWidth * nHeight)

                'System.IO.File.WriteAllBytes("Temp.raw", pbyTemp);

                'byte[] pbyTemp2 = System.IO.File.ReadAllBytes("Rr2.raw");
                'int nLen = pbyTemp2.Length;

                'cbLFDLevel.SelectedIndex

                Dim nScore As Integer = 0
                Dim nLFDLevel As Integer = 5
                Dim nRetVal As Integer = SupremaLFD.Liblfd.LIBLFD_GetResult(pbyTemp, nWidth, nHeight, 3, nScore)
                'int nRetVal = SupremaLFD.Liblfd.LIBLFD_GetResult(pbyTemp2, nWidth, nHeight, 5, ref nScore);

                Dim strTemp As String = "Hybrid LFD Error"

                If nRetVal = 1 Then
                    strTemp = String.Format("Hybrid LFD - Fake Finger : {0}", nScore)
                ElseIf nRetVal = 2 Then
                    strTemp = String.Format("Hybrid LFD - Live Finger : {0}", nScore)
                End If
                MessageBox.Show(strTemp)
                'Log(strTemp)
                '191001_Jack <=       

                Dim bmp = CreateBitmapFromBytes(image_data, mHidScanners(mSelectedDevIdx).GetWidth(), mHidScanners(mSelectedDevIdx).GetHeight())
                ImgHuellaGet = bmp
                'imageView.Image = bmp
                'imageView.SizeMode = PictureBoxSizeMode.StretchImage
            ElseIf type = CInt(Extra.SIMG_BMP) Then
                Dim ms As MemoryStream = New MemoryStream(image_data)
                ImgHuellaGet = Image.FromStream(ms)
                'imageView.Image = Image.FromStream(ms)
                'imageView.SizeMode = PictureBoxSizeMode.StretchImage
            Else
                'Log("unsupported image format to draw" & vbCrLf)
            End If
        End If

    End Sub

    Public Shared Function CreateBitmapFromBytes(ByVal pixelValues As Byte(), ByVal width As Integer, ByVal height As Integer) As Bitmap
        'Create an image that will hold the image data
        Dim bmp As Bitmap = New Bitmap(width, height, PixelFormat.Format8bppIndexed)

        'Get a reference to the images pixel data
        Dim dimension As Rectangle = New Rectangle(0, 0, bmp.Width, bmp.Height)
        Dim picData As BitmapData = bmp.LockBits(dimension, ImageLockMode.ReadWrite, bmp.PixelFormat)
        Dim pixelStartAddress As IntPtr = picData.Scan0

        'Copy the pixel data into the bitmap structure
        Marshal.Copy(pixelValues, 0, pixelStartAddress, pixelValues.Length)
        Dim pal As ColorPalette = bmp.Palette

        For i As Integer = 0 To 256 - 1
            pal.Entries(i) = Color.FromArgb(i, i, i)
        Next

        bmp.Palette = pal
        bmp.UnlockBits(picData)
        Return bmp
    End Function

    Public Sub btnInit_Click()
        'Log(">> Init <<" & vbCrLf & vbCrLf)
        If mHidScanner Is Nothing Then mHidScanner = New HidScanner()
        StatusSuprema = UpdateDeviceList()
        'MessageBox.Show(StatusSuprema)

        If mHidScannerCount > 0 Then
            'listDevices.SelectedIndex = 0
        End If
    End Sub

    Public Sub UpdateDeviceList(ByVal delay As Integer)
        If __IsUpdateInProgress OrElse mHidScanner Is Nothing Then Return
        __UpdateDeviceListSleep = delay
        Call New Threading.Thread(New Threading.ThreadStart(AddressOf UpdateDeviceListWithSleep)).Start()
    End Sub

    Public Function UpdateDeviceList() As Boolean
        If mHidScanner Is Nothing Then
            Return False
        End If

        mHidScannerCount = mHidScanner.GetDeviceCount()
        Const maxTries As Integer = 80
        'Log(vbCrLf & "================================" & vbCrLf)
        'Log("   HIDCSharp Version v01.21.001   " & vbCrLf)
        'Log("================================" & vbCrLf & vbCrLf)
        'Log(mHidScannerCount & " Device(s) found" & vbCrLf)
        Dim nSelectedOld As Integer = -1
        'Invoke(CType(Sub()
        'nSelectedOld = 0
        'listDevices.Items.Clear()
        'End Sub, MethodInvoker))

        If mHidScannerCount > 0 Then
            mHidScanners = New HidScanner(mHidScannerCount - 1) {}

            For i As Integer = 0 To mHidScannerCount - 1
                mHidScanners(i) = New HidScanner()

                If mHidScanners(i) Is Nothing Then
                    Return False
                End If

                If mHidScanners(i).Init(i) Then
                    Dim cnt As Integer = 0
                    Dim err As Integer = 0
                    Dim device_name As Byte() = New Byte(16) {}
                    Dim device_sn As Byte() = New Byte(16) {}
                    Dim fw_ver As Byte() = New Byte(8) {}
                    Dim hw_ver As Byte() = New Byte(8) {}
                    Dim protocol_ver As Byte() = New Byte(8) {}
                    Dim strName, strSN, strFWVer, strHWVer, strProVer As String

                    Do
                        err = mHidScanners(i).GetDeviceInfo(device_name, device_sn, fw_ver, hw_ver, protocol_ver)
                        Threading.Thread.Sleep(100)
                        If err = CInt([Error].ECH_SUCCESS) Then Exit Do
                    Loop While Threading.Interlocked.Increment(cnt) < maxTries

                    strName = Encoding.Default.GetString(device_name)
                    strSN = Encoding.Default.GetString(device_sn)
                    strFWVer = Encoding.Default.GetString(fw_ver)
                    strHWVer = Encoding.Default.GetString(hw_ver)
                    strProVer = Encoding.Default.GetString(protocol_ver)
                    'Log("================================" & vbCrLf)
                    'Log("Module Name: " & strName)
                    'Log(vbCrLf & "Module S/N: " & strSN)
                    'Log(vbCrLf & "F/W version: " & strFWVer)
                    'Log(vbCrLf & "H/W version: " & strHWVer)
                    'Log(vbCrLf & "Protocol version: " & strProVer)
                    'Log(vbCrLf & "================================" & vbCrLf)
                    'Invoke(CType(Sub() listDevices.Items.Add("[" & i & "] : " & strName), MethodInvoker))
                End If
            Next

            If nSelectedOld < mHidScannerCount AndAlso nSelectedOld >= 0 Then
                'Invoke(CType(Sub() listDevices.SelectedIndex = 0, MethodInvoker))
            End If

            Return True
        Else
            Return False
        End If
    End Function


End Class
