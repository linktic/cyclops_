Imports System.IO
Imports System.Xml.Serialization
Imports System.Threading

<Microsoft.VisualBasic.ComClass()> Public Class Biometria
    Implements IObjectSafety

    Public _Token As String
    Public _Mensaje As String
    Private Datos_Solicitud As New Datos_Solcitud
    Private Evento As New Evento_Local
    Private Configuracion As New Config
    Private sw As ServiceReferenceBio.ServicioBiometricoClient

    'Autenticación
    Private Cantidad_Huellas As Integer
    Private Calidad_Huellas As Integer
    Private Num_Huellas() As String
    Public FingerPrinterAux As Object


    Public ReadOnly Property Mensaje As String

        Get
            Return _Mensaje
        End Get

    End Property
    Public ReadOnly Property Token As String

        Get
            Return _Token
        End Get

    End Property
    ''' <summary>
    ''' Permite el registro biometrico del cliente el sistema.
    ''' </summary>
    ''' <param name="TI_Usuario">Tipo de identificación del usuario</param>
    ''' <param name="NI_Usuario">Número de deintificación del usuario</param>
    ''' <param name="Cod_Entidad">Codigo de la entidad</param>
    ''' <param name="Cod_Servicio">Codigo del servicio</param>
    ''' <param name="Cod_Oficina">Codigo de la oficina</param>
    ''' <param name="TI_Cliente">Tipo de identificación del cliente</param>
    ''' <param name="NI_Cliente">Número de deintificación del cliente</param>
    ''' <returns>Resultado del proceso de enrolamiento</returns>
    ''' <remarks></remarks>

    Public Function Enrolamiento(ByVal TI_Usuario As Integer, ByVal NI_Usuario As String, ByVal Cod_Entidad As Integer, ByVal Cod_Servicio As Integer, ByVal Cod_Oficina As String, ByVal TI_Cliente As Integer, ByVal NI_Cliente As String, ByVal FingerPrinter As Object) As Integer
        Try
            'Read_Config(Trim(Mid(Environment.GetFolderPath(Environment.SpecialFolder.Windows), 1, 1)) & ":\LINKTIC_BIO\config.xml")
            'Dim sw As New ServiceReferenceBio.ServicioBiometricoClient("BasicHttpBinding_IServicioBiometrico", Configuracion.Url_Servicio)
            Dim Archivo_Config As String = Trim(Mid(Environment.GetFolderPath(Environment.SpecialFolder.Windows), 1, 1)) & ":\LINKTIC_BIO\Biometria_LinkTic.dll.config"
            ' Dim Archivo_Config As String = Trim(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\LINKTIC_BIO\Biometria_LinkTic.dll.config")
            ' Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            'MsgBox(AppDomain.CurrentDomain.GetData("APP_CONFIG_FILE"))
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", Archivo_Config)
            ' System.Threading.Thread.Sleep(100)
            'MsgBox(AppDomain.CurrentDomain.GetData("APP_CONFIG_FILE"))

            Datos_Solicitud.m_Codigo_Entidad = Cod_Entidad
            Datos_Solicitud.m_Codigo_Servicio = Cod_Servicio
            Datos_Solicitud.m_Codigo_Oficina = Cod_Oficina
            Datos_Solicitud.m_TI_Usuario = TI_Usuario
            Datos_Solicitud.m_TI_Cliente = TI_Cliente
            Datos_Solicitud.m_NI_Usuario = NI_Usuario
            Datos_Solicitud.m_NI_Cliente = NI_Cliente

            Evento = Validaciones.Validar_Solicitud(Datos_Solicitud)

            If Not Evento Is Nothing Then
                _Mensaje = Evento.Mensaje
                Return Evento.Evento
            End If


            'Llamado de parametrización 
            'Consultar_Entidad_Servicio()
            'If Not Evento Is Nothing Then
            '    _Mensaje = Evento.Mensaje
            '    Return Evento.Evento
            'End If


            Dim log As New LoginEnrolamiento(Datos_Solicitud)
            log.ShowDialog()

            If Not log.Login Then
                _Token = ""
                _Mensaje = log.evento_login.Mensaje

                Return log.evento_login.Evento
            End If


            Dim enroll As New Enrolamiento(Datos_Solicitud, log.Calidad_Huellas, log.Cantidad_Huellas, FingerPrinter)
            enroll.ShowDialog()

            _Mensaje = enroll.Evento_Respuesta.Mensaje
            _Token = enroll.Token
            Return enroll.Evento_Respuesta.Evento
        Catch ex As Exception
            _Token = ""
            _Mensaje = ex.Message
            Return Evento_Local.Tipo_Evento.SB017_Excepción_de_procesamiento_módulo_central
        End Try
    End Function
    ''' <summary>
    ''' Permite verificar la identidad del cliente.
    ''' </summary>
    ''' <param name="TI_Usuario">Tipo de identificación del usuario</param>
    ''' <param name="NI_Usuario">Número de deintificación del usuario</param>
    ''' <param name="Cod_Entidad">Codigo de la entidad</param>
    ''' <param name="Cod_Servicio">Codigo del servicio</param>
    ''' <param name="Cod_Oficina">Codigo de la oficina</param>
    ''' <param name="TI_Cliente">Tipo de identificación del cliente</param>
    ''' <param name="NI_Cliente">Número de deintificación del cliente</param>
    ''' <returns>Resultado del proceso de autenticación</returns>
    ''' <remarks></remarks>
    Public Function Autenticacion(ByVal TI_Usuario As Integer, ByVal NI_Usuario As String, ByVal Cod_Entidad As Integer, ByVal Cod_Servicio As Integer, ByVal Cod_Oficina As String, ByVal TI_Cliente As Integer, ByVal NI_Cliente As String, ByVal FingerPrinter As Object) As Integer
        Try
            Read_Config(Trim(Mid(Environment.GetFolderPath(Environment.SpecialFolder.Windows), 1, 1)) & ":\LINKTIC_BIO\config.xml")

            Dim Archivo_Config As String = Trim(Mid(Environment.GetFolderPath(Environment.SpecialFolder.Windows), 1, 1)) & ":\LINKTIC_BIO\Biometria_LinkTic.dll.config"
            '  Environment.SpecialFolder.Windows 
            '  MsgBox(AppDomain.CurrentDomain.GetData("APP_CONFIG_FILE"))
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", Archivo_Config)
            'System.Threading.Thread.Sleep(100)
            'MsgBox(AppDomain.CurrentDomain.GetData("APP_CONFIG_FILE"))
            'Llamado de parametrización 
            Datos_Solicitud.m_Codigo_Entidad = Cod_Entidad
            Datos_Solicitud.m_Codigo_Servicio = Cod_Servicio
            Datos_Solicitud.m_Codigo_Oficina = Cod_Oficina
            Datos_Solicitud.m_TI_Usuario = TI_Usuario
            Datos_Solicitud.m_TI_Cliente = TI_Cliente
            Datos_Solicitud.m_NI_Usuario = NI_Usuario
            Datos_Solicitud.m_NI_Cliente = NI_Cliente

            Evento = Validaciones.Validar_Solicitud(Datos_Solicitud)

            If Not Evento Is Nothing Then
                _Mensaje = Evento.Mensaje
                Return Evento.Evento
            End If
            Evento = New Evento_Local
            Consultar_Entidad_Servicio()
            If Not Evento Is Nothing Then
                _Mensaje = Evento.Mensaje
                Return Evento.Evento
            End If

            Evento = New Evento_Local
            Consultar()
            If Not Evento Is Nothing Then
                _Mensaje = Evento.Mensaje
                Return Evento.Evento
            End If

            Evento = New Evento_Local
            Dim Capturar_Huellas As New Capturar_Huellas(FingerPrinter)
            Capturar_Huellas.Text = "Autenticación"
            Capturar_Huellas.Button_Finalizar.Text = "Autenticar"
            Capturar_Huellas.Cantidad_De_Huellas_a_Capturar = Cantidad_Huellas
            Capturar_Huellas.Num_huellas = Num_Huellas
            Dim Huellas_Autenticar As New List(Of Huella)
            Capturar_Huellas.Autenticacion = True
            Capturar_Huellas.Calidad = Calidad_Huellas
            Capturar_Huellas.ShowDialog()

            If Capturar_Huellas.Huellas_Capturadas Is Nothing Then
                _Token = ""
                _Mensaje = "Autenticación Cancelada"
                Return Evento_Local.Tipo_Evento.SB030_Proceso_Cancelado
            End If

            Huellas_Autenticar = Capturar_Huellas.Huellas_Capturadas.Huellas_list

            'Dim sw As New ServiceReferenceBio.ServicioBiometricoClient()
            'sw.Endpoint.Address = New ServiceModel.EndpointAddress(Configuracion.Url_Servicio)
            'System.Net.ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf ValidarCertificado)
            'Dim sw As New ServiceReferenceBio.ServicioBiometricoClient("BasicHttpBinding_IServicioBiometrico", Configuracion.Url_Servicio)
            Iniciar_conexion()
            Dim Solicitud As New ServiceReferenceBio.Solicitud

            Solicitud.m_Codigo_Entidad = Cod_Entidad
            Solicitud.m_Codigo_Oficina = Cod_Oficina
            Solicitud.m_Codigo_Servicio = Cod_Servicio
            Solicitud.m_TI_Usuario = TI_Usuario
            Solicitud.m_NI_Usuario = NI_Usuario
            Solicitud.m_NI_Cliente = NI_Cliente
            Solicitud.m_TI_Cliente = TI_Cliente
            Solicitud.m_Tipo_Solicitud = ServiceReferenceBio.Solicitud.Tipo_Solicitud.Autenticacion

            Solicitud.m_Huellas = Nothing
            Dim huellas(10) As ServiceReferenceBio.Huella
            If Not Huellas_Autenticar Is Nothing Then
                If Huellas_Autenticar.Count > 0 Then

                    Dim j As Integer = Huellas_Autenticar.Count
                    ReDim huellas(j - 1)

                    For i = 0 To j - 1
                        huellas(i) = New ServiceReferenceBio.Huella
                        huellas(i).HuellaID = Huellas_Autenticar.Item(i).HuellaID
                        huellas(i).Formato = Huellas_Autenticar.Item(i).Formato
                        huellas(i).Datos = Huellas_Autenticar.Item(i).Datos
                    Next
                End If
                Solicitud.m_Huellas = huellas
                Dim respuesta As New ServiceReferenceBio.RespuestaSolicitud
                respuesta = sw.RegistrarProceso(Solicitud)
                If respuesta.m_Resultado = ServiceReferenceBio.RespuestaSolicitud.TipoResultado.Proceso_Correcto Then
                    ' MsgBox("Proceso Correcto" & vbCrLf & [Enum].GetName(GetType(Evento_Local.Tipo_Evento), respuesta.m__Evento.Evento), MsgBoxStyle.Information, "Autenticación")
                    _Token = respuesta.m_Token

                    _Mensaje = respuesta.m__Evento.Mensaje
                    _Token = respuesta.m_Token
                    Return respuesta.m__Evento.Evento

                Else
                    _Mensaje = respuesta.m__Evento.Mensaje
                    _Token = respuesta.m_Token
                    ' MsgBox("Proceso Fallido" & vbCrLf & [Enum].GetName(GetType(Evento_Local.Tipo_Evento), respuesta.m__Evento.Evento), MsgBoxStyle.Information, "Autenticación")
                    Return respuesta.m__Evento.Evento
                End If
            Else
                _Token = ""
                _Mensaje = "No se capturaron huellas para realizar autenticación"
                Return Evento_Local.Tipo_Evento.SB030_Proceso_Cancelado
            End If
        Catch ex As Exception
            _Token = ""
            _Mensaje = ex.Message
            Return Evento_Local.Tipo_Evento.SB017_Excepción_de_procesamiento_módulo_central
        End Try
    End Function
    ''' <summary>
    ''' Permite dar de baja a un cliente en el sistema.
    ''' </summary>
    ''' <param name="TI_Usuario">Tipo de identificación del usuario</param>
    ''' <param name="NI_Usuario">Número de deintificación del usuario</param>
    ''' <param name="Cod_Entidad">Codigo de la entidad</param>
    ''' <param name="Cod_Servicio">Codigo del servicio</param>
    ''' <param name="Cod_Oficina">Codigo de la oficina</param>
    ''' <param name="TI_Cliente">Tipo de identificación del cliente</param>
    ''' <param name="NI_Cliente">Número de deintificación del cliente</param>
    ''' <returns>Resultado del proceso de eliminar enrolamiento</returns>
    ''' <remarks></remarks>
    Public Function EliminarEnrolamiento(ByVal TI_Usuario As Integer, ByVal NI_Usuario As String, ByVal Cod_Entidad As Integer, ByVal Cod_Servicio As Integer, ByVal Cod_Oficina As String, ByVal TI_Cliente As Integer, ByVal NI_Cliente As String) As Integer
        Try
            Read_Config(Trim(Mid(Environment.GetFolderPath(Environment.SpecialFolder.Windows), 1, 1)) & ":\LINKTIC_BIO\config.xml")
            'Dim sw As New ServiceReferenceBio.ServicioBiometricoClient("BasicHttpBinding_IServicioBiometrico", Configuracion.Url_Servicio)
            Dim Archivo_Config As String = Trim(Mid(Environment.GetFolderPath(Environment.SpecialFolder.Windows), 1, 1)) & ":\LINKTIC_BIO\Biometria_LinkTic.dll.config"
            '  Environment.SpecialFolder.Windows 

            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", Archivo_Config)
            System.Threading.Thread.Sleep(100)
            Datos_Solicitud.m_Codigo_Entidad = Cod_Entidad
            Datos_Solicitud.m_Codigo_Servicio = Cod_Servicio
            Datos_Solicitud.m_Codigo_Oficina = Cod_Oficina
            Datos_Solicitud.m_TI_Usuario = TI_Usuario
            Datos_Solicitud.m_TI_Cliente = TI_Cliente
            Datos_Solicitud.m_NI_Usuario = NI_Usuario
            Datos_Solicitud.m_NI_Cliente = NI_Cliente

            Evento = Validaciones.Validar_Solicitud(Datos_Solicitud)

            If Not Evento Is Nothing Then
                _Mensaje = Evento.Mensaje
                Return Evento.Evento
            End If


            'Llamado de parametrización 
            'Consultar_Entidad_Servicio()
            'If Not Evento Is Nothing Then
            '    _Mensaje = Evento.Mensaje
            '    Return Evento.Evento
            'End If

            Dim log As New LoginEnrolamiento(Datos_Solicitud)
            log.ShowDialog()

            If Not log.Login Then
                _Token = ""
                _Mensaje = log.evento_login.Mensaje

                Return log.evento_login.Evento
            End If

            Iniciar_conexion()
            '   Dim sw As New ServiceReferenceBio.ServicioBiometricoClient("BasicHttpBinding_IServicioBiometrico", Configuracion.Url_Servicio)

            Dim Solicitud As New ServiceReferenceBio.Solicitud
            Dim R_Solicitud As New ServiceReferenceBio.RespuestaSolicitud
            Solicitud.m_Codigo_Entidad = Cod_Entidad
            Solicitud.m_Codigo_Oficina = Cod_Oficina
            Solicitud.m_Codigo_Servicio = Cod_Servicio
            Solicitud.m_TI_Usuario = TI_Usuario
            Solicitud.m_NI_Usuario = NI_Usuario
            Solicitud.m_NI_Cliente = NI_Cliente
            Solicitud.m_TI_Cliente = TI_Cliente
            Solicitud.m_Tipo_Solicitud = ServiceReferenceBio.Solicitud.Tipo_Solicitud.Eliminacion
            R_Solicitud = sw.RegistrarProceso(Solicitud)

            _Mensaje = R_Solicitud.m__Evento.Mensaje
            _Token = R_Solicitud.m_Token
            Return R_Solicitud.m__Evento.Evento
        Catch ex As Exception
            _Token = ""
            _Mensaje = ex.Message
            Return Evento_Local.Tipo_Evento.SB017_Excepción_de_procesamiento_módulo_central
        End Try
    End Function
    Private Sub Read_Config(ByVal path As String)
        Dim objstreamreader As New StreamReader(path)
        Dim x As New XmlSerializer(Configuracion.GetType)
        Configuracion = x.Deserialize(objstreamreader)
        objstreamreader.Close()
    End Sub
    Private Sub Iniciar_conexion()
        If sw Is Nothing Then

            System.Net.ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf ValidarCertificado)
            sw = New ServiceReferenceBio.ServicioBiometricoClient("BasicHttpBinding_IServicioBiometrico", Configuracion.Url_Servicio)

        End If

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
           
            Evento = Nothing
        Else
            Evento.Evento = R_Parametrización.m__Evento.Evento
            Evento.Mensaje = R_Parametrización.m__Evento.Mensaje
        End If
    End Sub
    Private Sub Consultar()
        '  Dim sw As New ServiceReferenceBio.ServicioBiometricoClient("BasicHttpBinding_IServicioBiometrico", Configuracion.Url_Servicio)
        Iniciar_conexion()
        Dim S_Parametrizacion As New ServiceReferenceBio.SolicitudParametrizacion
        Dim R_Parametrización As New ServiceReferenceBio.RespuestaParametrizacion
        S_Parametrizacion.m_NI = Datos_Solicitud.m_NI_Cliente
        S_Parametrizacion.m_TI = Datos_Solicitud.m_TI_Cliente
        S_Parametrizacion.m_Tipo_Solicitud = ServiceReferenceBio.SolicitudParametrizacion.Tipo_Solicitud.Autenticacion
        R_Parametrización = sw.Parametrizacion(S_Parametrizacion)

        If R_Parametrización.m__Evento Is Nothing Then
            Calidad_Huellas = R_Parametrización.Calidad
            Cantidad_Huellas = R_Parametrización.H_Autenticacion
            Num_Huellas = R_Parametrización.Data
            Evento = Nothing
        Else
            Evento.Evento = R_Parametrización.m__Evento.Evento
            Evento.Mensaje = R_Parametrización.m__Evento.Mensaje
        End If
    End Sub
    
    Public Function GetInterfaceSafetyOptions(ByRef iid As Guid, ByRef pdwSupportedOptions As Integer, ByRef pdwEnabledOptions As Integer) As Long Implements IObjectSafety.GetInterfaceSafetyOptions
        Return 0
    End Function

    Public Function SetInterfaceSafetyOptions(ByRef iid As Guid, dwOptionSetMask As Integer, dwEnabledOptions As Integer) As Long Implements IObjectSafety.SetInterfaceSafetyOptions
        Return 0
    End Function
    Private Function ValidarCertificado(ByVal sender As Object, ByVal certificate As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function
End Class
