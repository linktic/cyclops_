Imports System.IO
Imports System.Xml.Serialization

Friend Class Enrolamiento

    Public Huellas_Obt As Huellas
    Private Configuracion As New Config
    Private Path_config As String
    Private Foto() As Byte
    Private Datos_Solicitud_Entrada As New Datos_Solcitud
    Private m_Calidad As Integer
    Private m_Cantidad_huellas As Integer
    Private sw As ServiceReferenceBio.ServicioBiometricoClient
    Public Evento_Respuesta As New Evento_Local
    Public Resultado_Proceso As Integer
    Public Token As String
    Public FingerPrinterAux As Object

    Sub New(ByVal Datos_solicitud As Datos_Solcitud, ByVal Calidad As Integer, ByVal Cantidad_huellas As Integer, ByVal FingerPrinter As Object)

        ' This call is required by the designer.
        InitializeComponent()
        FingerPrinterAux = FingerPrinter
        Datos_Solicitud_Entrada = Datos_solicitud
        m_Calidad = Calidad
        m_Cantidad_huellas = Cantidad_huellas

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cp As New Capturar_Huellas(FingerPrinterAux)
        cp.Calidad = m_Calidad
        cp.Cantidad_De_Huellas_a_Capturar = m_Cantidad_huellas
        cp.ShowDialog()
        If Not cp.Huellas_Capturadas Is Nothing Then
            Label_Cantidad_Huellas.Text = cp.Huellas_Capturadas.Cantidad_Huellas
            Huellas_Obt = cp.Huellas_Capturadas
        End If
      
    End Sub


    Private Sub Enrolamiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Path_config = Trim(Mid(Environment.GetFolderPath(Environment.SpecialFolder.Windows), 1, 1)) & ":\LINKTIC_BIO\config.xml"
            If File.Exists(Path_config) Then
                Read_Config(Path_config)
            End If

            ToolStripStatusLabel_Usuario.Text = Datos_Solicitud_Entrada.m_NI_Usuario & "_" & [Enum].GetName(GetType(Datos_Solcitud.TipoDocumento), Datos_Solicitud_Entrada.m_TI_Usuario)
            ToolStripStatusLabel_Codigo_Entidad.Text = Datos_Solicitud_Entrada.m_Codigo_Entidad
            Tipo_Identificacion.Text = [Enum].GetName(GetType(Datos_Solcitud.TipoDocumento), Datos_Solicitud_Entrada.m_TI_Cliente)
            Numero_Identificacion.Text = Datos_Solicitud_Entrada.m_NI_Cliente
            Label_Huellas_a_capturar.Text = m_Cantidad_huellas
            ComboBox1.SelectedIndex = 0

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
      
    End Sub


    'Private Sub ConexiónServicioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConexiónServicioToolStripMenuItem.Click
    '    Dim Config_con As New Configurar_Conexion(Configuracion.Url_Servicio)
    '    Config_con.ShowDialog()
    '    Configuracion.Url_Servicio = Config_con.Url
    '    Write_Config(Path_config, Configuracion)
    'End Sub

    Private Sub CámaraWebToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CámaraWebToolStripMenuItem.Click
        Dim camara As New ClassLibrary1.Class1
        Dim Ancho As Integer
        Dim Alto As Integer
        Dim Dispositivo As String = ""
        camara.Configurar(Ancho, Alto, Dispositivo)
        Configuracion.Alto = Alto
        Configuracion.Ancho = Ancho
        Configuracion.Dispositivo_Camara = Dispositivo
        Write_Config(Path_config, Configuracion)
    End Sub



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

    Private Sub Button_Captura_Foto_Click(sender As Object, e As EventArgs) Handles Button_Captura_Foto.Click
        Dim camara As New ClassLibrary1.Class1
        If Configuracion.Alto = 0 Or Configuracion.Ancho = 0 Then
            MsgBox("Se debe realizar la configuración de la cámara antes de realizar la captura.", MsgBoxStyle.Information, "Captura Foto")
            Exit Sub
        Else

            Dim image As System.Drawing.Image
            Try
                image = camara.Capturar(Configuracion.Ancho, Configuracion.Alto, Configuracion.Dispositivo_Camara)

            Catch ex As Exception
                MsgBox("Cámara no conectada o no configurada.", MsgBoxStyle.Information, "Captura Foto")
                Exit Sub
            End Try
          
            If image Is Nothing Then
                MsgBox("No se realizo la captura de la foto.", MsgBoxStyle.Information, "Captura Foto")
                Exit Sub
            End If
            Me.PictureBox_Foto.Image = image
            Using Stream As New System.IO.MemoryStream
                PictureBox_Foto.Image.Save(Stream, System.Drawing.Imaging.ImageFormat.Jpeg)
                Foto = Stream.ToArray
            End Using
        End If
    End Sub

   

    

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Token = ""
        Evento_Respuesta.Mensaje = "Enrolamiento Cancelado"
        Evento_Respuesta.Evento = Evento_Local.Tipo_Evento.SB030_Proceso_Cancelado
        Me.Close()
    End Sub

    
   

    Sub Iniciar_conexion()
        If sw Is Nothing Then
            System.Net.ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf ValidarCertificado)
            sw = New ServiceReferenceBio.ServicioBiometricoClient("BasicHttpBinding_IServicioBiometrico", Configuracion.Url_Servicio)
            '  Dim sw As New ServiceReferenceBio.ServicioBiometricoClient("wsHttpBinding", Configuracion.Url_Servicio)
        End If

    End Sub
   
   
    Private Sub Button_Enviar_Enrolamiento_Click(sender As Object, e As EventArgs) Handles Button_Enviar_Enrolamiento.Click
        Dim Cumple As Boolean = False
        Try
            'Dim sw As New ServiceReferenceBio.ServicioBiometricoClient("BasicHttpBinding_IServicioBiometrico", Configuracion.Url_Servicio)
            ' Dim sw As New ServiceReferenceBio.ServicioBiometricoClient("wsHttpBinding", Configuracion.Url_Servicio)
            'sw.Endpoint.Address = New ServiceModel.EndpointAddress(Configuracion.Url_Servicio)
            Iniciar_conexion()

            Dim Solicitud As New ServiceReferenceBio.Solicitud

            Solicitud.m_Codigo_Entidad = Datos_Solicitud_Entrada.m_Codigo_Entidad
            Solicitud.m_Codigo_Oficina = Datos_Solicitud_Entrada.m_Codigo_Oficina
            Solicitud.m_Codigo_Servicio = Datos_Solicitud_Entrada.m_Codigo_Servicio
            Solicitud.m_TI_Usuario = Datos_Solicitud_Entrada.m_TI_Usuario
            Solicitud.m_NI_Usuario = Datos_Solicitud_Entrada.m_NI_Usuario
            Solicitud.m_NI_Cliente = Datos_Solicitud_Entrada.m_NI_Cliente
            Solicitud.m_TI_Cliente = Datos_Solicitud_Entrada.m_TI_Cliente
            Solicitud.m_Tipo_Solicitud = ServiceReferenceBio.Solicitud.Tipo_Solicitud.Enrolamiento
            Solicitud.m__Descripcion = ComboBox1.SelectedIndex + 1
            If Not Foto Is Nothing Then
                If Foto.Length > 200 Then
                    Solicitud.m_Foto = Convert.ToBase64String(Foto)
                    Cumple = True
                End If
            End If
            Solicitud.m_Huellas = Nothing
            Dim huellas(10) As ServiceReferenceBio.Huella
            If Not Huellas_Obt Is Nothing Then
                If Huellas_Obt.Cantidad_Huellas > 0 Then
                    Cumple = True
                    Dim j As Integer = Label_Cantidad_Huellas.Text
                    ReDim huellas(j - 1)

                    For i = 0 To j - 1
                        huellas(i) = New ServiceReferenceBio.Huella
                        huellas(i).HuellaID = Huellas_Obt.Huellas_list.Item(i).HuellaID
                        huellas(i).Formato = Huellas_Obt.Huellas_list.Item(i).Formato
                        huellas(i).Datos = Huellas_Obt.Huellas_list.Item(i).Datos
                    Next
                End If
                Solicitud.m_Huellas = huellas
            End If


            If Cumple Then
                Dim respuesta As New ServiceReferenceBio.RespuestaSolicitud
                respuesta = sw.RegistrarProceso(Solicitud)
                If respuesta.m_Resultado = ServiceReferenceBio.RespuestaSolicitud.TipoResultado.Proceso_Correcto Then
                    MsgBox("Proceso Correcto" & vbCrLf & [Enum].GetName(GetType(Evento_Local.Tipo_Evento), respuesta.m__Evento.Evento), MsgBoxStyle.Information, "Enrolamiento")
                    Token = respuesta.m_Token
                    Evento_Respuesta.Evento = respuesta.m__Evento.Evento
                    Evento_Respuesta.Mensaje = respuesta.m__Evento.Mensaje
                    Resultado_Proceso = respuesta.m_Resultado
                Else
                    Token = respuesta.m_Token
                    Evento_Respuesta.Evento = respuesta.m__Evento.Evento
                    Evento_Respuesta.Mensaje = respuesta.m__Evento.Mensaje
                    Resultado_Proceso = respuesta.m_Resultado
                    MsgBox("Proceso Fallido" & vbCrLf & [Enum].GetName(GetType(Evento_Local.Tipo_Evento), respuesta.m__Evento.Evento), MsgBoxStyle.Information, "Enrolamiento")
                End If
                Me.Close()
            Else
                MsgBox("No se ha capturado información para realizar el enrolamiento", MsgBoxStyle.Information, "Enrolamiento")
            End If
        Catch ex As Exception
            Token = ""
            Evento_Respuesta.Mensaje = ex.Message
            Evento_Respuesta.Evento = Evento_Local.Tipo_Evento.SB017_Excepción_de_procesamiento_módulo_central
            Me.Close()
        End Try
    End Sub
    Private Function ValidarCertificado(ByVal sender As Object, ByVal certificate As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function
End Class