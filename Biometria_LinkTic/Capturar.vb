
Imports Suprema.UFMatcher
Imports Suprema
Imports System.Drawing
Imports System.Threading
Imports System.Media
Imports DPUruNet
Imports DPUruNet.Constants
Imports System.Drawing.Imaging
Imports System.Windows.Forms
Imports System.IO

Friend Class Capturar
    '*************Variables DP*********
    Public Lector As Reader
    Public huella As Fmd
    '***************

    Private m_ScannerManager As UFScannerManager
    Private m_Matcher As UFMatcher = Nothing
    Private m_strError As String
    'Private m_template As Byte()()
    'Private m_template_size As Integer()

    'Private m_template1 As Byte()()
    'Private m_template_size1 As Integer()
    'Private m_template2 As Byte()()
    'Private m_template_size2 As Integer()
    'Private m_template_num As Integer
    'Private m_UserID As String()
    Private m_quality As Integer
    Private m_nType As Integer
    '
    Private Const MAX_TEMPLATE_SIZE As Integer = 1024
    Private Const MAX_TEMPLATE_NUM As Integer = 50

    Private Const MAX_USERID_SIZE As Integer = 10
    Private Const MAX_TEMPLATE_INPUT_NUM As Integer = 4
    Private Const MAX_TEMPLATE_OUTPUT_NUM As Integer = 2

    Private Const FINGERDATA_COL_SERIAL As Integer = 0
    Private Const FINGERDATA_COL_USERID As Integer = 1
    Private Const FINGERDATA_COL_TEMPLATE1 As Integer = 2
    Private Const FINGERDATA_COL_TEMPLATE2 As Integer = 3
    Public FingerPrinterAux As Object

    Private m_Huellas As Huellas
    Private m_Huella_a_capturar As Integer

    Private Template_Capturado As Byte()
    Private Template_Capturado_Size As Integer
    Private m_Capturada As Boolean = False
    ReadOnly Property Capturada As Boolean
        Get
            Return m_Capturada
        End Get
    End Property

    Property Huella_a_capturar As Integer
        Get
            Return m_Huella_a_capturar
        End Get
        Set(value As Integer)
            m_Huella_a_capturar = value
        End Set
    End Property

    Property Calidad As Integer
        Get
            Return m_quality
        End Get
        Set(value As Integer)
            m_quality = value
        End Set
    End Property

    Private Sub Capturar_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        PictureBox_huella.Image = Nothing
    End Sub
    Private Sub DrawCapturedImage(ByRef Scanner As UFScanner)
        Dim g As Graphics = PictureBox_huella.CreateGraphics()
        Dim rect As Rectangle = New Rectangle(0, 0, PictureBox_huella.Width, PictureBox_huella.Height)
        'Dim Resolution As Integer
        Try
            SystemSounds.Beep.Play()
            Scanner.DrawCaptureImageBuffer(g, rect, False)
            '
            'Dim bitmap As Bitmap = Nothing
            'Scanner.GetCaptureImageBuffer(bitmap, Resolution)
            'pbImageFrame.Image = bitmap
        Finally
            g.Dispose()
        End Try
    End Sub

    Public Sub Captura_Suprema()
        Try
            Template_Capturado = New Byte(MAX_TEMPLATE_SIZE) {}
            Template_Capturado_Size = 0
            Dim MatchIndex As Integer = Nothing
            'MsgBox("UFScanner GetScannerNumber: " & nScannerNumber & vbNewLine)
            '==========================================================================='
            ' Create one matcher
            '==========================================================================='

            '  m_ScannerManager = New UFScannerManager(Me)
            m_Matcher = New UFMatcher()

            If (m_Matcher.InitResult = UFM_STATUS.OK) Then
                '       MsgBox("UFMatcher Init: OK" & vbNewLine)
            Else
                UFMatcher.GetErrorString(m_Matcher.InitResult, m_strError)
                '    MsgBox("UFMatcher Init: " & m_strError & vbNewLine) Log de aplicacion
            End If
            '==========================================================================='
            'Enroll
            '==========================================================================='
            FingerPrinterAux.onFinger()
            Thread.Sleep(5000)
            FingerPrinterAux.cbTemplateFormat_SelectedIndexChanged()
            ' Start and wait for task to end.
            'Dim captureResult = Lector.Capture(Formats.Fid.ISO, CaptureProcessing.DP_IMG_PROC_DEFAULT, 5000, Lector.Capabilities.Resolutions(0))
            'If Not CheckCaptureResult(captureResult) Then Return

            'If captureResult.ResultCode <> ResultCode.DP_SUCCESS Then
            '   Throw New Exception("" + captureResult.ToString())
            'End If
            'For Each fiv As Fid.Fiv In CaptureResult.Data.Views
            FingerPrinterAux.btnExtract_Click()
            Thread.Sleep(200)
            FingerPrinterAux.btnRecvTemplate_Click()
            Me.PictureBox_huella.Image = FingerPrinterAux.ImgHuellaGet
            Me.PictureBox_huella.Refresh()
            'Dim resultConversion As DataResult(Of Fmd) = FeatureExtraction.CreateFmdFromFid(CaptureResult.Data, Formats.Fmd.ISO)
            Thread.Sleep(500)
            'huella = resultConversion.Data
            'Next
            Try
                Template_Capturado = FingerPrinterAux.TextTemplate ' Template capturado
                Template_Capturado_Size = FingerPrinterAux.TextReceive
                
            Catch ex As Exception
                MsgBox("La huella no fue capturada de forma correcta.", MsgBoxStyle.Information, "Capturar Huella")
                Exit Sub
            End Try
            '==========================================================================='
            'Identify
            '==========================================================================='
            m_Matcher.nTemplateType = 2002

            '   Dim s = 1024 - Template_Capturado_Size
            '   ReDim Preserve Template_Capturado(Template_Capturado_Size + s)

            Dim ufs_res = m_Matcher.Identify(Template_Capturado, Template_Capturado_Size, m_Huellas.m_template, m_Huellas.m_template_size, m_Huellas.Cantidad_Huellas, 5000, MatchIndex)

            If (ufs_res <> UFS_STATUS.OK) Then
                'UFMatcher.GetErrorString(ufs_res, m_strError)
                'MsgBox("UFMatcher Identify: " & m_strError & vbNewLine) LOG de aplicación
                'Exit Sub
            End If

            If (MatchIndex <> -1) Then
                SystemSounds.Question.Play()
                SystemSounds.Beep.Play()
                MsgBox("¡Esta huella ya fué capturada! verifique el dedo a capturar.", MsgBoxStyle.Information, "Capturar Huella")
            Else
                m_Huellas.Agregar_Huella(Template_Capturado, Template_Capturado_Size, m_Huella_a_capturar)
                m_Capturada = True
            End If

            '==========================================================================='
            'Cerrar Módulo
            '==========================================================================='


            '  ufs_res = m_ScannerManager.Uninit()

            'If (ufs_res = UFS_STATUS.OK) Then
            '    ' MsgBox("UFScanner Uninit: OK" & vbNewLine)
            '    ' RemoveHandler m_ScannerManager.ScannerEvent, AddressOf ScannerEvent

            'Else
            '    UFScanner.GetErrorString(ufs_res, m_strError)
            '    '  MsgBox("UFScanner Uninit: " & m_strError & vbNewLine) log de aplicacion
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub Captura()
        Dim m_ScannerManager As UFScannerManager
        'm_template1 = New Byte(MAX_TEMPLATE_NUM)() {}
        'm_template2 = New Byte(MAX_TEMPLATE_NUM)() {}
        'For i As Integer = 0 To MAX_TEMPLATE_NUM - 1
        '    m_template1(i) = New Byte(MAX_TEMPLATE_SIZE) {}
        '    m_template2(i) = New Byte(MAX_TEMPLATE_SIZE) {}
        'Next
        'm_template_size1 = New Integer(MAX_TEMPLATE_NUM) {}
        'm_template_size2 = New Integer(MAX_TEMPLATE_NUM) {}
        'm_template_num = 0



        'Template_Capturado = New Byte(MAX_TEMPLATE_NUM) {}
        'Template_Capturado_Size = 0

        Template_Capturado = New Byte(MAX_TEMPLATE_SIZE) {}
        Template_Capturado_Size = 0
        Dim MatchIndex As Integer = Nothing

        m_ScannerManager = New UFScannerManager(Me)

        '==========================================================================='
        ' Initilize scanners
        '==========================================================================='
        Dim ufs_res As UFS_STATUS
        Dim nScannerNumber As Integer


        ufs_res = m_ScannerManager.Init()

        If (ufs_res = UFS_STATUS.OK) Then
            '  MsgBox("UFScanner Init: OK")
        Else
            UFScanner.GetErrorString(ufs_res, m_strError)
            '  MsgBox("UFScanner Init: " & m_strError & vbNewLine) ' Log de aplicacion
            If ufs_res = UFS_STATUS.ERR_ALREADY_INITIALIZED Then
                MsgBox("Dispositivo de captura de huellas no conectado", MsgBoxStyle.Critical, "Capturar Huella")
            End If
            Exit Sub
        End If



        nScannerNumber = m_ScannerManager.Scanners.Count
        'MsgBox("UFScanner GetScannerNumber: " & nScannerNumber & vbNewLine)

        '==========================================================================='
        ' Create one matcher
        '==========================================================================='

        m_Matcher = New UFMatcher()

        If (m_Matcher.InitResult = UFM_STATUS.OK) Then
            '       MsgBox("UFMatcher Init: OK" & vbNewLine)
        Else
            UFMatcher.GetErrorString(m_Matcher.InitResult, m_strError)
            '    MsgBox("UFMatcher Init: " & m_strError & vbNewLine) Log de aplicacion

        End If

        '==========================================================================='
        'Enroll
        '==========================================================================='
        Dim Scanner As UFScanner = Nothing
        '   Dim ufs_res As UFS_STATUS
        Dim EnrollQuality As Integer = Nothing
        Dim EnrollMode As Integer = Nothing




        Scanner = m_ScannerManager.Scanners(0)

        If (Equals(Scanner, Nothing)) Then
            MsgBox("Dispositivo de captura de huellas no conectado", MsgBoxStyle.Critical, "Capturar Huella")
            Exit Sub
        End If

        Scanner.nTemplateType = 2002 ' Formato Iso

        Scanner.ClearCaptureImageBuffer()

        ufs_res = Scanner.CaptureSingleImage()
        If (ufs_res <> UFS_STATUS.OK) Then
            UFScanner.GetErrorString(ufs_res, m_strError)
            '     MsgBox("UFScanner CaptureSingleImage: " & m_strError & vbNewLine)
            ufs_res = m_ScannerManager.Uninit()

            If (ufs_res = UFS_STATUS.OK) Then
                ' MsgBox("UFScanner Uninit: OK" & vbNewLine)
                ' RemoveHandler m_ScannerManager.ScannerEvent, AddressOf ScannerEvent
                Exit Sub
            Else
                UFScanner.GetErrorString(ufs_res, m_strError)
                '  MsgBox("UFScanner Uninit: " & m_strError & vbNewLine) log de aplicacion
                Exit Sub
            End If
        End If

        ufs_res = Scanner.ExtractEx(MAX_TEMPLATE_SIZE, Template_Capturado, Template_Capturado_Size, EnrollQuality)

        DrawCapturedImage(Scanner)

        If (ufs_res = UFS_STATUS.OK) Then
            If (EnrollQuality < m_quality) Then
                MsgBox("Calidad inferior al nivel requerido " & vbCrLf & "Calidad:" & EnrollQuality)
                ufs_res = m_ScannerManager.Uninit()
                If (ufs_res = UFS_STATUS.OK) Then
                    ' MsgBox("UFScanner Uninit: OK" & vbNewLine)
                    ' RemoveHandler m_ScannerManager.ScannerEvent, AddressOf ScannerEvent
                    Exit Sub
                Else
                    UFScanner.GetErrorString(ufs_res, m_strError)
                    '  MsgBox("UFScanner Uninit: " & m_strError & vbNewLine) log de aplicacion
                    Exit Sub
                End If
            Else
                ' MsgBox("Captura realizada correctamente " & vbCrLf & "Calidad:" & EnrollQuality)
            End If
        Else
            UFScanner.GetErrorString(ufs_res, m_strError)
            MsgBox("Error en extracción")
            ufs_res = m_ScannerManager.Uninit()
            If (ufs_res = UFS_STATUS.OK) Then
                ' MsgBox("UFScanner Uninit: OK" & vbNewLine)
                ' RemoveHandler m_ScannerManager.ScannerEvent, AddressOf ScannerEvent
                Exit Sub
            Else
                UFScanner.GetErrorString(ufs_res, m_strError)
                '  MsgBox("UFScanner Uninit: " & m_strError & vbNewLine) log de aplicacion
                Exit Sub
            End If
        End If
        '==========================================================================='
        'Identify
        '==========================================================================='
        m_Matcher.nTemplateType = 2002
        ufs_res = m_Matcher.Identify(Template_Capturado, Template_Capturado_Size, m_Huellas.m_template, m_Huellas.m_template_size, m_Huellas.Cantidad_Huellas, 5000, MatchIndex)

        If (ufs_res <> UFS_STATUS.OK) Then
            'UFMatcher.GetErrorString(ufs_res, m_strError)
            'MsgBox("UFMatcher Identify: " & m_strError & vbNewLine) LOG de aplicación
            'Exit Sub
        End If

        If (MatchIndex <> -1) Then
            SystemSounds.Question.Play()
            SystemSounds.Beep.Play()
            MsgBox("¡Esta huella ya fué capturada! verifique el dedo a capturar.", MsgBoxStyle.Information, "Capturar Huella")
        Else
            m_Huellas.Agregar_Huella(Template_Capturado, Template_Capturado_Size, m_Huella_a_capturar)
            m_Capturada = True
        End If

        '==========================================================================='
        'Cerrar Módulo
        '==========================================================================='


        ufs_res = m_ScannerManager.Uninit()

        If (ufs_res = UFS_STATUS.OK) Then
            ' MsgBox("UFScanner Uninit: OK" & vbNewLine)
            ' RemoveHandler m_ScannerManager.ScannerEvent, AddressOf ScannerEvent

        Else
            UFScanner.GetErrorString(ufs_res, m_strError)
            '  MsgBox("UFScanner Uninit: " & m_strError & vbNewLine) log de aplicacion
        End If


    End Sub
    Public Sub Captura_dp()
        Try


            Template_Capturado = New Byte(MAX_TEMPLATE_SIZE) {}
            Template_Capturado_Size = 0
            Dim MatchIndex As Integer = Nothing

            'Iniciar Lector

            Dim Lectores As ReaderCollection

            Lectores = ReaderCollection.GetReaders()

            'Para validar si el lector esta conectado se puede preguntar por la cantidad del lectores

            If Lectores.Count = 0 Then
                MsgBox("No se encuentra el lector conectado")
                Me.Dispose()
                Close()
                Exit Sub
            End If

            Lector = Lectores.First


            Dim Result = Lector.Open(Constants.CapturePriority.DP_PRIORITY_COOPERATIVE)

            If Result <> Constants.ResultCode.DP_SUCCESS Then
                MsgBox("Error:  " & Result.ToString())
            End If



            'MsgBox("UFScanner GetScannerNumber: " & nScannerNumber & vbNewLine)

            '==========================================================================='
            ' Create one matcher
            '==========================================================================='

            '  m_ScannerManager = New UFScannerManager(Me)
            m_Matcher = New UFMatcher()

            If (m_Matcher.InitResult = UFM_STATUS.OK) Then
                '       MsgBox("UFMatcher Init: OK" & vbNewLine)
            Else
                UFMatcher.GetErrorString(m_Matcher.InitResult, m_strError)
                '    MsgBox("UFMatcher Init: " & m_strError & vbNewLine) Log de aplicacion

            End If

            '==========================================================================='
            'Enroll
            '==========================================================================='


            Dim captureResult = Lector.Capture(Formats.Fid.ISO, CaptureProcessing.DP_IMG_PROC_DEFAULT, 5000, Lector.Capabilities.Resolutions(0))


            If Not CheckCaptureResult(captureResult) Then Return

            If captureResult.ResultCode <> ResultCode.DP_SUCCESS Then
                Throw New Exception("" + captureResult.ToString())
            End If
            For Each fiv As Fid.Fiv In captureResult.Data.Views
                Me.PictureBox_huella.Image = DirectCast(CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height), Bitmap)
                Me.PictureBox_huella.Refresh()
                Dim resultConversion As DataResult(Of Fmd) = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Formats.Fmd.ISO)

                huella = resultConversion.Data
            Next
            Try
                Template_Capturado = huella.Bytes ' Template capturado
                Template_Capturado_Size = huella.Bytes.Length
                Lector.Dispose()
                Lector = Nothing
            Catch ex As Exception
                MsgBox("La huella no fue capturada de forma correcta.", MsgBoxStyle.Information, "Capturar Huella")
                Lector.Dispose()
                Lector = Nothing
                Exit Sub
            End Try
            '==========================================================================='
            'Identify
            '==========================================================================='
            m_Matcher.nTemplateType = 2002

            '   Dim s = 1024 - Template_Capturado_Size
            '   ReDim Preserve Template_Capturado(Template_Capturado_Size + s)

            Dim ufs_res = m_Matcher.Identify(Template_Capturado, Template_Capturado_Size, m_Huellas.m_template, m_Huellas.m_template_size, m_Huellas.Cantidad_Huellas, 5000, MatchIndex)

            If (ufs_res <> UFS_STATUS.OK) Then
                'UFMatcher.GetErrorString(ufs_res, m_strError)
                'MsgBox("UFMatcher Identify: " & m_strError & vbNewLine) LOG de aplicación
                'Exit Sub
            End If

            If (MatchIndex <> -1) Then
                SystemSounds.Question.Play()
                SystemSounds.Beep.Play()
                MsgBox("¡Esta huella ya fué capturada! verifique el dedo a capturar.", MsgBoxStyle.Information, "Capturar Huella")
            Else
                m_Huellas.Agregar_Huella(Template_Capturado, Template_Capturado_Size, m_Huella_a_capturar)
                m_Capturada = True
            End If

            '==========================================================================='
            'Cerrar Módulo
            '==========================================================================='


            '  ufs_res = m_ScannerManager.Uninit()

            'If (ufs_res = UFS_STATUS.OK) Then
            '    ' MsgBox("UFScanner Uninit: OK" & vbNewLine)
            '    ' RemoveHandler m_ScannerManager.ScannerEvent, AddressOf ScannerEvent

            'Else
            '    UFScanner.GetErrorString(ufs_res, m_strError)
            '    '  MsgBox("UFScanner Uninit: " & m_strError & vbNewLine) log de aplicacion
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FingerPrinterAux.Main()
        FingerPrinterAux.btnInit_Click()
        Try
            Button1.Text = "¡Por favor, ubicar el dedo sobre el lector!"
            Button1.Refresh()
            If existe_Lector_Dp() Then ' Cambiar 
                Captura_dp()
            ElseIf FingerPrinterAux.StatusSuprema Then
                Captura_Suprema()
            Else
                Captura()
            End If
            Thread.Sleep(500)
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Function existe_Lector_Dp() As Boolean

        Dim Lectores As ReaderCollection

        Lectores = ReaderCollection.GetReaders()

        'Para validar si el lector esta conectado se puede preguntar por la cantidad del lectores

        If Lectores.Count = 0 Then
            Return False
        End If
        Return True
    End Function

    Sub New(ByRef Huellas As Huellas, ByVal FingerPrinter As Object)
        m_Huellas = Huellas
        FingerPrinterAux = FingerPrinter
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Public Function CheckCaptureResult(ByVal captureResult As CaptureResult) As Boolean
        If captureResult.Data Is Nothing Or captureResult.ResultCode <> Constants.ResultCode.DP_SUCCESS Then
            If captureResult.ResultCode <> Constants.ResultCode.DP_SUCCESS Then
                MsgBox("Error en extracción" & captureResult.ResultCode.ToString())
            End If

            If captureResult.Quality <> Constants.CaptureQuality.DP_QUALITY_CANCELED Then
                MsgBox("Calidad inferior al nivel requerido - " & captureResult.Quality.ToString())
            End If
            Return False
        End If
        Return True
    End Function

    Public Function CreateBitmap(ByVal bytes As [Byte](), ByVal width As Integer, ByVal height As Integer) As Bitmap
        Dim rgbBytes As Byte() = New Byte(bytes.Length * 3 - 1) {}

        For i As Integer = 0 To bytes.Length - 1
            rgbBytes((i * 3)) = bytes(i)
            rgbBytes((i * 3) + 1) = bytes(i)
            rgbBytes((i * 3) + 2) = bytes(i)
        Next
        Dim bmp As New Bitmap(width, height, PixelFormat.Format24bppRgb)

        Dim data As BitmapData = bmp.LockBits(New Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.[WriteOnly], PixelFormat.Format24bppRgb)

        For i As Integer = 0 To bmp.Height - 1
            Dim p As New IntPtr(data.Scan0.ToInt64() + data.Stride * i)
            System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3)
        Next

        bmp.UnlockBits(data)

        Return bmp
    End Function

    Private Sub Capturar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox_huella_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox_huella.Click

    End Sub
End Class