Imports Biometria_LinkTic
Imports System.Xml.Serialization
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging


Public Class Form1
    Public Estado As Tipo_estado
    Public Entidad As New Entidad
    Public path As String
    Public Enum Tipo_estado
        Inicial
        Edicion
    End Enum
    Private Sub Button1_Click(sender As Object, e As EventArgs)
     
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked Then
            Estado = Tipo_estado.Edicion
            EstadoEdicíon()
        Else
            Estado = Tipo_estado.Inicial
            EstadoInicial()
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'FingerPrinter.Main()
        'FingerPrinter.btnInit_Click()
        Estado = Tipo_estado.Inicial
        path = Trim(Mid(Environment.GetFolderPath(Environment.SpecialFolder.System), 1, 1)) & ":\LINKTIC_BIO\Entidad.xml"
        EstadoInicial()
    End Sub
    Sub EstadoInicial()
        Me.GroupBox_Entidad.Enabled = False
        Me.GroupBox_Usuario.Enabled = False
        If File.Exists(path) Then
            Read_Entidad(path)
            Me.TextBox_Entidad.Text = Entidad.m_Codigo_Entidad
            Me.TextBox_Servicio.Text = Entidad.m_Codigo_Servicio
            Me.TextBox_Oficina.Text = Entidad.m_Codigo_Oficina
            Me.ComboBox_TIU.SelectedIndex = Entidad.m_TI_Usuario
            Me.TextBox_NIU.Text = Entidad.m_NI_Usuario
        End If
    End Sub
    Sub EstadoEdicíon()
        Me.GroupBox_Entidad.Enabled = True
        Me.GroupBox_Usuario.Enabled = True
    End Sub

    Private Sub Button_Guardar_Click(sender As Object, e As EventArgs) Handles Button_Guardar.Click
        Entidad.m_Codigo_Entidad = Me.TextBox_Entidad.Text
        Entidad.m_Codigo_Servicio = Me.TextBox_Servicio.Text
        Entidad.m_Codigo_Oficina = Me.TextBox_Oficina.Text
        Entidad.m_TI_Usuario = Me.ComboBox_TIU.SelectedIndex
        Entidad.m_NI_Usuario = Me.TextBox_NIU.Text
        If Write_Entidad(path, Entidad) Then
            MsgBox("La información de la entidad fué guardada correctamente", MsgBoxStyle.Information, "Guardar")
        Else
            MsgBox("No se logro guardo la informcación de la entidad", MsgBoxStyle.Critical, "Guardar")
        End If

    End Sub


    Private Sub TextBox_Entidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Entidad.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox_Servicio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Servicio.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox_NIU_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_NIU.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            If Not e.KeyChar = ""c Then

                e.Handled = True

            End If
        End If
    End Sub

    Private Sub TextBox_NIC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_NIC.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            If Not e.KeyChar = ""c Then

                e.Handled = True

            End If
        End If
    End Sub

    Private Shared Function Write_Entidad(ByVal path As String, ByVal inputParameters As Entidad) As Boolean
        Try
            Dim serializador As XmlSerializer = New XmlSerializer(GetType(Entidad))
            Dim escritor As New StringWriter
            '   escritor.Dispose()
            serializador.Serialize(escritor, inputParameters)

            File.WriteAllText(path, escritor.ToString)

            'Dim x As XmlSerializer = New XmlSerializer(GetType(Solicitud))
            'Dim writer As TextWriter = New StreamWriter("or.xml")
            'x.Serialize(writer, inputParameters)
            'writer.Close()

            Return True
        Catch ex As Exception

            Return False
        End Try
    End Function
    Private Sub Read_Entidad(ByVal path As String)
        Dim objstreamreader As New StreamReader(path)
        Dim x As New XmlSerializer(Entidad.GetType)
        Entidad = x.Deserialize(objstreamreader)
        objstreamreader.Close()
    End Sub




    Private Sub TextBox_NIU_TextChanged(sender As Object, e As EventArgs) Handles TextBox_NIU.TextChanged

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        'MessageBox.Show(FingerPrinter.StatusSuprema)
        'FingerPrinter.onFinger()
        Try
            Dim bio As New Biometria_LinkTic.Biometria
            Dim res As Integer
            res = bio.Enrolamiento(Entidad.m_TI_Usuario, Entidad.m_NI_Usuario, Entidad.m_Codigo_Entidad, Entidad.m_Codigo_Servicio, Entidad.m_Codigo_Oficina, Me.ComboBox_TIC.SelectedIndex, TextBox_NIC.Text, FingerPrinter)
            MsgBox([Enum].GetName(GetType(Tipo_Evento), res) & vbCrLf & bio.Mensaje, MsgBoxStyle.Information, "Enrolamiento")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Public Enum Tipo_Evento
        SB000_Proceso_Cancelado
        SB001_Cliente_enrolado_en_el_sistema
        SB002_Cliente_autenticado
        SB003_Cliente_no_autenticado
        SB004_Usuario_validado_en_el_sistema
        SB005_Cliente_eliminado_del_sistema
        SB006_Validación_de_usuario_fallida
        SB007_Número_de_intentos_de_login_superados
        SB008_Excepción_en_parámetros_de_entrada
        SB009_Lector_de_huellas_no_conectado
        SB010_Excepción_en_la_captura_de_huella
        SB011_Falló_en_lector_de_huella
        SB012_Huella_ya_capturada_en_el_proceso_de_enrolamiento
        SB013_Cámara_web_no_conectada
        SB014_Falló_en_cámara_web
        SB015_Excepción_en_la_captura_de_foto
        SB016_Token_generado_correctamente
        SB017_Excepción_de_procesamiento_módulo_central
        SB018_Excepción_generado_token
        SB019_Consulta_de_token_valido
        SB020_Consulta_de_token_invalido
        SB021_Excepción_en_generación_de_reporte
        SB022_Usuario_creado_correctamente
        SB023_Usuario_eliminado
        SB024_Perfil_creado
        SB025_Perfil_editado
        SB026_Tiempo_de_espera_agotado_de_procesamiento
        SB027_Cliente_ya_enrolado_en_el_sistema
        SB028_Cliente_no_enrolado_en_el_sistema
        SB029_Cliente_sin_huellas
        SB030_Proceso_Cancelado
        SB031_Perfil_Eliminado
        SB032_Usuario_Editado
    End Enum

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim bio As New Biometria_LinkTic.Biometria
            Dim res As Integer
            res = bio.Autenticacion(Entidad.m_TI_Usuario, Entidad.m_NI_Usuario, Entidad.m_Codigo_Entidad, Entidad.m_Codigo_Servicio, Entidad.m_Codigo_Oficina, Me.ComboBox_TIC.SelectedIndex, TextBox_NIC.Text, FingerPrinter)
            MsgBox([Enum].GetName(GetType(Tipo_Evento), res) & vbCrLf & bio.Mensaje, MsgBoxStyle.Information, "Autenticacion")

            System.Net.ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf ValidarCertificado)
            If res = 16 Then
                Dim tk As New Token.TokenClient("BasicHttpBinding_IToken", Entidad.ServicioToken)
                Dim res_bio As New Token.RespuestaToken

                res_bio = tk.ConsultarToken(bio._Token)

                MsgBox([Enum].GetName(GetType(Tipo_Evento), res_bio.m_Resultado) & vbCrLf & bio.Mensaje, MsgBoxStyle.Information, "Autenticacion")
            End If
          
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim bio As New Biometria_LinkTic.Biometria
            Dim res As Integer
            res = bio.EliminarEnrolamiento(Entidad.m_TI_Usuario, Entidad.m_NI_Usuario, Entidad.m_Codigo_Entidad, Entidad.m_Codigo_Servicio, Entidad.m_Codigo_Oficina, Me.ComboBox_TIC.SelectedIndex, TextBox_NIC.Text)
            MsgBox([Enum].GetName(GetType(Tipo_Evento), res) & vbCrLf & bio.Mensaje, MsgBoxStyle.Information, "Enrolamiento")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       
    End Sub
    Private Function ValidarCertificado(ByVal sender As Object, ByVal certificate As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function

    Private Sub ConexiónTokenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConexiónTokenToolStripMenuItem.Click
        Dim Config_con As New Configurar_Conexion(Entidad.ServicioToken)
        Dim Path_config As String = Trim(Mid(Environment.GetFolderPath(Environment.SpecialFolder.Windows), 1, 1)) & ":\LINKTIC_BIO\Entidad.xml"
        Config_con.ShowDialog()
        Entidad.ServicioToken = Config_con.Url
        Write_Entidad(Path_config, Entidad)
    End Sub


End Class
