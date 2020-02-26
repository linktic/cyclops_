Imports System.Xml.Serialization
Imports System.IO

Friend Class LoginEnrolamiento
    Private Configuracion As New Config
    Private Path_config As String
    'Private NI_Usuario As String
    'Private TI_Usuario As String
    Public Login As Boolean = False
    Public Cantidad_Huellas As Integer
    Public Calidad_Huellas As Integer
    Private Nombre_Usuario As String
    Private Password_Usuario As String
    Public evento_login As New Evento_Local
    Private Intentos As Integer = 0
    Private Finalizar As Boolean = False
    Private sw As ServiceReferenceBio.ServicioBiometricoClient
    Private datos_solicitud As New Datos_Solcitud
    Sub New(ByVal datos As Datos_Solcitud)

        ' This call is required by the designer.
        InitializeComponent()
        Me.datos_solicitud = datos
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Try
            'Path_config = Trim(Mid(Environment.GetFolderPath(Environment.SpecialFolder.Windows), 1, 1)) & ":\LINKTIC_BIO\config.xml"
            'If File.Exists(Path_config) Then
            '    Read_Config(Path_config)
            'End If
            If UsernameTextBox.Text = "" Then
                MsgBox("No se ingreso el nombre de usuario.", MsgBoxStyle.Exclamation, "Login")
                Exit Sub
            End If
            If PasswordTextBox.Text = "" Then
                MsgBox("No se ingreso contraseña.", MsgBoxStyle.Exclamation, "Login")
                Exit Sub
            End If
            If Intentos = 0 Then

                Consultar_Entidad_Servicio()
                If Not evento_login Is Nothing Then
                    Login = False
                    Me.Dispose()
                    Me.Close()
                    Exit Sub
                End If
                evento_login = New Evento_Local
                Consultar()

            End If
            If Finalizar Then
                Me.Dispose()
                Me.Close()
            Else
                If Strings.StrComp(Nombre_Usuario, Me.UsernameTextBox.Text, CompareMethod.Text) = 0 Then
                    If Strings.StrComp(Password_Usuario, getMD5Hash(Me.PasswordTextBox.Text), CompareMethod.Text) = 0 Then
                        Login = True
                        Me.evento_login = Nothing
                        Me.Close()
                        Exit Sub
                    End If
                End If

                MsgBox(" Las credenciales del usuario no son validas" & vbCrLf & " número de intentos: " & Intentos + 1 & " de 3", MsgBoxStyle.Exclamation, "Login")
                Me.UsernameTextBox.Text = ""
                Me.PasswordTextBox.Text = ""
                If Intentos >= 2 Then
                    'bloquear usuario
                    Bloquear_usuario()
                    MsgBox(" El usuario ha sido bloqueado por el número de intetos fallidos. " & vbCrLf & " Informe al administrador del sistema.", MsgBoxStyle.Critical, "Login")
                    Me.Close()
                End If
                Intentos = Intentos + 1
            End If
           
            'Verificar respuestas del servicio eventos

        Catch ex As Exception
            evento_login.Evento = Evento_Local.Tipo_Evento.SB030_Proceso_Cancelado
            evento_login.Mensaje = ex.Message
            Login = False
            Me.Close()
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub


    'Private Sub ConexiónServicioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConexiónServicioToolStripMenuItem.Click
    '    Dim Config_con As New Configurar_Conexion(Configuracion.Url_Servicio)
    '    Path_config = Trim(Mid(Environment.GetFolderPath(Environment.SpecialFolder.Windows), 1, 1)) & ":\LINKTIC_BIO\config.xml"
    '    Config_con.ShowDialog()
    '    Configuracion.Url_Servicio = Config_con.Url
    '    Write_Config(Path_config, Configuracion)
    'End Sub

    Private Sub Read_Config(ByVal path As String)
        Dim objstreamreader As New StreamReader(path)
        Dim x As New XmlSerializer(Configuracion.GetType)
        Configuracion = x.Deserialize(objstreamreader)
        objstreamreader.Close()
    End Sub
    Private Shared Function Write_Config(ByVal path As String, ByVal inputParameters As Config) As Boolean
        Try
            Dim serializador As XmlSerializer = New XmlSerializer(GetType(Config))
            Dim escritor As New StringWriter
            serializador.Serialize(escritor, inputParameters)
            File.WriteAllText(path, escritor.ToString)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

   
    Private Sub LoginEnrolamiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Try
        Try
            Path_config = Trim(Mid(Environment.GetFolderPath(Environment.SpecialFolder.Windows), 1, 1)) & ":\LINKTIC_BIO\config.xml"
            If File.Exists(Path_config) Then
                Read_Config(Path_config)
            End If

        Catch ex As Exception
            Me.evento_login.Evento = Evento_Local.Tipo_Evento.SB030_Proceso_Cancelado
            Me.evento_login.Mensaje = ex.Message
        End Try
        
        '    Dim sw As New ServiceReferenceBio.ServicioBiometricoClient("BasicHttpBinding_IServicioBiometrico", Configuracion.Url_Servicio)
        '    Dim S_Parametrizacion As New ServiceReferenceBio.SolicitudParametrizacion
        '    Dim R_Parametrización As New ServiceReferenceBio.RespuestaParametrizacion
        '    S_Parametrizacion.m_NI = NI_Usuario
        '    S_Parametrizacion.m_TI = TI_Usuario
        '    S_Parametrizacion.m_Tipo_Solicitud = ServiceReferenceBio.SolicitudParametrizacion.Tipo_Solicitud.Enrolamiento
        '    R_Parametrización = sw.Parametrizacion(S_Parametrizacion)

        '    If R_Parametrización.m__Evento.Evento = ServiceReferenceBio._Evento.Tipo_Evento.None Then

        '        Calidad_Huellas = R_Parametrización.Calidad
        '        Cantidad_Huellas = R_Parametrización.H_Enrolamiento
        '        Nombre_Usuario = R_Parametrización.Data(0)
        '        Password_Usuario = R_Parametrización.Data(1)
        '    Else
        '        evento_login.Evento = R_Parametrización.m__Evento.Evento
        '        evento_login.Mensaje = R_Parametrización.m__Evento.Mensaje
        '        Login = False
        '        Me.Close()
        '    End If
        '    'Verificar respuestas del servicio eventos

        'Catch ex As Exception
        '    evento_login.Evento = Evento_Local.Tipo_Evento.SB030_Proceso_Cancelado
        '    evento_login.Mensaje = ex.Message
        '    Login = False
        '    MsgBox(ex.Message)
        'End Try
    End Sub
    Private Shared Function getMD5Hash(ByVal strToHash As String) As String
        Dim md5Obj As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = md5Obj.ComputeHash(bytesToHash)

        Dim strResult As String = ""
        Dim b As Byte

        For Each b In bytesToHash
            strResult += b.ToString("x2")
        Next

        Return strResult
    End Function

    Sub Consultar()
        '  Dim sw As New ServiceReferenceBio.ServicioBiometricoClient("BasicHttpBinding_IServicioBiometrico", Configuracion.Url_Servicio)
        Iniciar_conexion()
        Dim S_Parametrizacion As New ServiceReferenceBio.SolicitudParametrizacion
        Dim R_Parametrización As New ServiceReferenceBio.RespuestaParametrizacion
        S_Parametrizacion.m_NI = datos_solicitud.m_NI_Usuario
        S_Parametrizacion.m_TI = datos_solicitud.m_TI_Usuario
        S_Parametrizacion.m_Tipo_Solicitud = ServiceReferenceBio.SolicitudParametrizacion.Tipo_Solicitud.Enrolamiento
        R_Parametrización = sw.Parametrizacion(S_Parametrizacion)

        If R_Parametrización.m__Evento Is Nothing Then

            Calidad_Huellas = R_Parametrización.Calidad
            Cantidad_Huellas = R_Parametrización.H_Enrolamiento
            Nombre_Usuario = R_Parametrización.Data(0)
            Password_Usuario = R_Parametrización.Data(1)
            If Strings.StrComp(Nombre_Usuario, Me.UsernameTextBox.Text, CompareMethod.Text) = 0 Then
                If Strings.StrComp(Password_Usuario, getMD5Hash(Me.PasswordTextBox.Text), CompareMethod.Text) = 0 Then
                    Login = True
                    Me.evento_login = Nothing
                    Finalizar = True
                End If
            End If

        Else
            evento_login.Evento = R_Parametrización.m__Evento.Evento
            evento_login.Mensaje = R_Parametrización.m__Evento.Mensaje
            Login = False
            Finalizar = True
        End If
    End Sub
    Sub Iniciar_conexion()
        If sw Is Nothing Then
            System.Net.ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf ValidarCertificado)
            sw = New ServiceReferenceBio.ServicioBiometricoClient("BasicHttpBinding_IServicioBiometrico", Configuracion.Url_Servicio)
            '  Dim sw As New ServiceReferenceBio.ServicioBiometricoClient("wsHttpBinding", Configuracion.Url_Servicio)
        End If

    End Sub

    Sub Bloquear_usuario()
        Iniciar_conexion()
        Dim solicitud As New ServiceReferenceBio.Solicitud
        Dim R_solicitud As New ServiceReferenceBio.RespuestaSolicitud
        solicitud.m_Tipo_Solicitud = ServiceReferenceBio.Solicitud.Tipo_Solicitud.Evento
        solicitud.m_NI_Usuario = datos_solicitud.m_NI_Usuario
        solicitud.m_TI_Usuario = datos_solicitud.m_TI_Usuario
        solicitud.m_Codigo_Entidad = datos_solicitud.m_Codigo_Entidad
        solicitud.m_Codigo_Oficina = datos_solicitud.m_Codigo_Oficina
        solicitud.m_Codigo_Servicio = datos_solicitud.m_Codigo_Servicio
        solicitud.m_NI_Cliente = datos_solicitud.m_NI_Cliente
        solicitud.m_TI_Cliente = datos_solicitud.m_TI_Cliente
        solicitud.m__Evento = New ServiceReferenceBio._Evento
        solicitud.m__Evento.Evento = ServiceReferenceBio._Evento.Tipo_Evento.SB007_Número_de_intentos_de_login_superados
        solicitud.m__Evento.Mensaje = ""
        R_solicitud = sw.RegistrarProceso(solicitud)
        Me.evento_login.Evento = R_solicitud.m__Evento.Evento
        Me.evento_login.Mensaje = R_solicitud.m__Evento.Mensaje
    End Sub
    Private Sub Consultar_Entidad_Servicio()
        '  Dim sw As New ServiceReferenceBio.ServicioBiometricoClient("BasicHttpBinding_IServicioBiometrico", Configuracion.Url_Servicio)
        Iniciar_conexion()
        Dim S_Parametrizacion As New ServiceReferenceBio.SolicitudParametrizacion
        Dim R_Parametrización As New ServiceReferenceBio.RespuestaParametrizacion
        Dim data(1) As String

        data(0) = Datos_Solicitud.m_Codigo_Servicio
        data(1) = Datos_Solicitud.m_Codigo_Entidad
        S_Parametrizacion.Data = data
        S_Parametrizacion.m_NI = Datos_Solicitud.m_NI_Cliente
        S_Parametrizacion.m_TI = Datos_Solicitud.m_TI_Cliente
        S_Parametrizacion.m_Tipo_Solicitud = ServiceReferenceBio.SolicitudParametrizacion.Tipo_Solicitud.Validacion
        R_Parametrización = sw.Parametrizacion(S_Parametrizacion)

        If R_Parametrización.m__Evento.Evento = ServiceReferenceBio._Evento.Tipo_Evento.None Then

            evento_login = Nothing
        Else
            evento_login.Evento = R_Parametrización.m__Evento.Evento
            evento_login.Mensaje = R_Parametrización.m__Evento.Mensaje
        End If
    End Sub
    Private Function ValidarCertificado(ByVal sender As Object, ByVal certificate As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function
End Class
