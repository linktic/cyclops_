Imports System.Windows.Forms

Friend Class Capturar_Huellas
    Private Const MAX_TEMPLATE_SIZE As Integer = 1024
    Private Const MAX_TEMPLATE_NUM As Integer = 50
    Public Calidad As Integer
    Private _Huellas_Capturadas As Huellas
    Public Cantidad_De_Huellas As Integer
    Public Cantidad_De_Huellas_a_Capturar As Integer
    Public Num_huellas() As String
    Public Autenticacion As Boolean = False
    Public FingerPrinterAux As Object

    Property Huellas_Capturadas As Huellas
        Get
            Return _Huellas_Capturadas
        End Get
        Set(value As Huellas)
            _Huellas_Capturadas = value
        End Set
    End Property

    Sub New(ByVal FingerPrinter As Object)

        ' This call is required by the designer.
        InitializeComponent()
        FingerPrinterAux = FingerPrinter
        'FingerPrinter.onFinger()
    End Sub

    Private Sub Capturar_Huellas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar_Dedos()
        Cantidad_De_Huellas = 0
        Label_Cantidad_Huellas.Text = Cantidad_De_Huellas
        Label_Huellas_a_Capturar.Text = Cantidad_De_Huellas_a_Capturar
        Huellas_Capturadas = New Huellas
        'ComboBox_Calidad.SelectedIndex = (100 - Calidad) / 10
    End Sub
    Private Sub Limpiar_Dedos()
        Dim tt_1 As New ToolTip()
        Dim tt_2 As New ToolTip()
        Dim tt_3 As New ToolTip()
        Dim tt_4 As New ToolTip()
        Dim tt_5 As New ToolTip()
        tt_1.SetToolTip(PictureBox_1, "Pulgar Derecho")
        tt_2.SetToolTip(PictureBox_2, "Indice Derecho")
        tt_3.SetToolTip(PictureBox_3, "Medio Derecho")
        tt_4.SetToolTip(PictureBox_4, "Anular Derecho")
        tt_5.SetToolTip(PictureBox_5, "Meñique Derecho")

        Dim tt_1_i As New ToolTip()
        Dim tt_2_i As New ToolTip()
        Dim tt_3_i As New ToolTip()
        Dim tt_4_i As New ToolTip()
        Dim tt_5_i As New ToolTip()
        tt_1_i.SetToolTip(PictureBox_6, "Pulgar Izquierdo")
        tt_2_i.SetToolTip(PictureBox_7, "Indice Izquierdo")
        tt_3_i.SetToolTip(PictureBox_8, "Medio Izquierdo")
        tt_4_i.SetToolTip(PictureBox_9, "Anular Izquierdo")
        tt_5_i.SetToolTip(PictureBox_10, "Meñique Izquierdo")
        PictureBox_H1.Visible = False
        PictureBox_H2.Visible = False
        PictureBox_H3.Visible = False
        PictureBox_H4.Visible = False
        PictureBox_H5.Visible = False
        PictureBox_H6.Visible = False
        PictureBox_H7.Visible = False
        PictureBox_H8.Visible = False
        PictureBox_H9.Visible = False
        PictureBox_H10.Visible = False
        '     ComboBox_Calidad.SelectedIndex = 5
        ComboBox_Calidad.SelectedIndex = (90 - Calidad) / 10


        PictureBox_a_1.Visible = False
        PictureBox_a_2.Visible = False
        PictureBox_a_3.Visible = False
        PictureBox_a_4.Visible = False
        PictureBox_a_5.Visible = False
        PictureBox_a_6.Visible = False
        PictureBox_a_7.Visible = False
        PictureBox_a_8.Visible = False
        PictureBox_a_9.Visible = False
        PictureBox_a_10.Visible = False
        If Autenticacion Then
            For Each s As String In Num_huellas
                Select Case s
                    Case 1
                        PictureBox_a_1.Visible = True
                    Case 2
                        PictureBox_a_2.Visible = True
                    Case 3
                        PictureBox_a_3.Visible = True
                    Case 4
                        PictureBox_a_4.Visible = True
                    Case 5
                        PictureBox_a_5.Visible = True
                    Case 6
                        PictureBox_a_6.Visible = True
                    Case 7
                        PictureBox_a_7.Visible = True
                    Case 8
                        PictureBox_a_8.Visible = True
                    Case 9
                        PictureBox_a_9.Visible = True
                    Case 10
                        PictureBox_a_10.Visible = True
                End Select
            Next
        End If

    End Sub


    Private Sub PictureBox_2_Click(sender As Object, e As EventArgs) Handles PictureBox_2.Click
        Dim ch As New Capturar(_Huellas_Capturadas, FingerPrinterAux)
        'Cantidad_De_Huellas = Cantidad_De_Huellas + 1
        If _Huellas_Capturadas.Cantidad_Huellas >= Cantidad_De_Huellas_a_Capturar Then
            MsgBox("Se han capturado la cantidad de huellas esperadas.", MsgBoxStyle.Information, "Enrolamiento")
            Exit Sub
        End If
        ch.Huella_a_capturar = 2
        If Autenticacion Then
            Dim Capturar_aute As Boolean = False
            For Each n As String In Num_huellas
                Dim i As Integer
                i = Convert.ToInt64(n)
                If i = ch.Huella_a_capturar Then
                    Capturar_aute = True
                End If
            Next
            If Not Capturar_aute Then
                Exit Sub
            End If
        End If

        ch.Calidad = Calidad
        ch.ShowDialog()
        Label_Cantidad_Huellas.Text = _Huellas_Capturadas.Cantidad_Huellas
        If ch.Capturada Then
            PictureBox_H2.Visible = True
            PictureBox_a_2.Visible = False
            PictureBox_2.Enabled = False
        Else
            PictureBox_H2.Visible = False
        End If
    End Sub

    Private Sub ComboBox_Calidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Calidad.SelectedIndexChanged
        If (ComboBox_Calidad.SelectedIndex = 9) Then
            Calidad = 0
        End If
    End Sub

    Private Sub PictureBox_3_Click(sender As Object, e As EventArgs) Handles PictureBox_3.Click
        Dim ch As New Capturar(_Huellas_Capturadas, FingerPrinterAux)
        ' Cantidad_De_Huellas = Cantidad_De_Huellas + 1
        If _Huellas_Capturadas.Cantidad_Huellas >= Cantidad_De_Huellas_a_Capturar Then
            MsgBox("Se han capturado la cantidad de huellas esperadas.", MsgBoxStyle.Information, "Enrolamiento")
            Exit Sub
        End If
        ch.Huella_a_capturar = 3
        If Autenticacion Then
            Dim Capturar_aute As Boolean = False
            For Each n As String In Num_huellas
                Dim i As Integer
                i = Convert.ToInt64(n)
                If i = ch.Huella_a_capturar Then
                    Capturar_aute = True
                End If
            Next
            If Not Capturar_aute Then
                Exit Sub
            End If
        End If
        ch.Calidad = Calidad
        ch.ShowDialog()
        Label_Cantidad_Huellas.Text = _Huellas_Capturadas.Cantidad_Huellas
        If ch.Capturada Then
            PictureBox_H3.Visible = True
            PictureBox_a_3.Visible = False
            PictureBox_3.Enabled = False
        Else
            PictureBox_H3.Visible = False
        End If
    End Sub

    Private Sub PictureBox_4_Click(sender As Object, e As EventArgs) Handles PictureBox_4.Click
        Dim ch As New Capturar(_Huellas_Capturadas, FingerPrinterAux)
        'Cantidad_De_Huellas = Cantidad_De_Huellas + 1
        If _Huellas_Capturadas.Cantidad_Huellas >= Cantidad_De_Huellas_a_Capturar Then
            MsgBox("Se han capturado la cantidad de huellas esperadas.", MsgBoxStyle.Information, "Enrolamiento")
            Exit Sub
        End If
        ch.Huella_a_capturar = 4
        If Autenticacion Then
            Dim Capturar_aute As Boolean = False
            For Each n As String In Num_huellas
                Dim i As Integer
                i = Convert.ToInt64(n)
                If i = ch.Huella_a_capturar Then
                    Capturar_aute = True
                End If
            Next
            If Not Capturar_aute Then
                Exit Sub
            End If
        End If
        ch.Calidad = Calidad
        ch.ShowDialog()
        Label_Cantidad_Huellas.Text = _Huellas_Capturadas.Cantidad_Huellas
        If ch.Capturada Then
            PictureBox_H4.Visible = True
            PictureBox_a_4.Visible = False
            PictureBox_4.Enabled = False
        Else
            PictureBox_H4.Visible = False
        End If
    End Sub

    Private Sub PictureBox_5_Click(sender As Object, e As EventArgs) Handles PictureBox_5.Click
        Dim ch As New Capturar(_Huellas_Capturadas, FingerPrinterAux)
        'Cantidad_De_Huellas = Cantidad_De_Huellas + 1
        If _Huellas_Capturadas.Cantidad_Huellas >= Cantidad_De_Huellas_a_Capturar Then
            MsgBox("Se han capturado la cantidad de huellas esperadas.", MsgBoxStyle.Information, "Enrolamiento")
            Exit Sub
        End If
        ch.Huella_a_capturar = 5
        If Autenticacion Then
            Dim Capturar_aute As Boolean = False
            For Each n As String In Num_huellas
                Dim i As Integer
                i = Convert.ToInt64(n)
                If i = ch.Huella_a_capturar Then
                    Capturar_aute = True
                End If
            Next
            If Not Capturar_aute Then
                Exit Sub
            End If
        End If
        ch.Calidad = Calidad
        ch.ShowDialog()
        Label_Cantidad_Huellas.Text = _Huellas_Capturadas.Cantidad_Huellas
        If ch.Capturada Then
            PictureBox_H5.Visible = True
            PictureBox_a_5.Visible = False
            PictureBox_5.Enabled = False
        Else
            PictureBox_H5.Visible = False
        End If
    End Sub

    Private Sub PictureBox_1_Click(sender As Object, e As EventArgs) Handles PictureBox_1.Click
        Dim ch As New Capturar(_Huellas_Capturadas, FingerPrinterAux)
        'Cantidad_De_Huellas = Cantidad_De_Huellas + 1
        If _Huellas_Capturadas.Cantidad_Huellas >= Cantidad_De_Huellas_a_Capturar Then
            MsgBox("Se han capturado la cantidad de huellas esperadas.", MsgBoxStyle.Information, "Enrolamiento")
            Exit Sub
        End If
        ch.Huella_a_capturar = 1
        If Autenticacion Then
            Dim Capturar_aute As Boolean = False
            For Each n As String In Num_huellas
                Dim i As Integer
                i = Convert.ToInt64(n)
                If i = ch.Huella_a_capturar Then
                    Capturar_aute = True
                End If
            Next
            If Not Capturar_aute Then
                Exit Sub
            End If
        End If
        ch.Calidad = Calidad
        ch.ShowDialog()
        Label_Cantidad_Huellas.Text = _Huellas_Capturadas.Cantidad_Huellas
        If ch.Capturada Then
            PictureBox_H1.Visible = True
            PictureBox_a_1.Visible = False
            PictureBox_1.Enabled = False
        Else
            PictureBox_H1.Visible = False
        End If
    End Sub

    Private Sub PictureBox_6_Click(sender As Object, e As EventArgs) Handles PictureBox_6.Click
        Dim ch As New Capturar(_Huellas_Capturadas, FingerPrinterAux)
        'Cantidad_De_Huellas = Cantidad_De_Huellas + 1
        If _Huellas_Capturadas.Cantidad_Huellas >= Cantidad_De_Huellas_a_Capturar Then
            MsgBox("Se han capturado la cantidad de huellas esperadas.", MsgBoxStyle.Information, "Enrolamiento")
            Exit Sub
        End If
        ch.Huella_a_capturar = 6
        If Autenticacion Then
            Dim Capturar_aute As Boolean = False
            For Each n As String In Num_huellas
                Dim i As Integer
                i = Convert.ToInt64(n)
                If i = ch.Huella_a_capturar Then
                    Capturar_aute = True
                End If
            Next
            If Not Capturar_aute Then
                Exit Sub
            End If
        End If
        ch.Calidad = Calidad
        ch.ShowDialog()
        Label_Cantidad_Huellas.Text = _Huellas_Capturadas.Cantidad_Huellas
        If ch.Capturada Then
            PictureBox_H6.Visible = True
            PictureBox_a_6.Visible = False
            PictureBox_6.Enabled = False
        Else
            PictureBox_H6.Visible = False
        End If
    End Sub

    Private Sub PictureBox_7_Click(sender As Object, e As EventArgs) Handles PictureBox_7.Click
        Dim ch As New Capturar(_Huellas_Capturadas, FingerPrinterAux)
        'Cantidad_De_Huellas = Cantidad_De_Huellas + 1
        If _Huellas_Capturadas.Cantidad_Huellas >= Cantidad_De_Huellas_a_Capturar Then
            MsgBox("Se han capturado la cantidad de huellas esperadas.", MsgBoxStyle.Information, "Enrolamiento")
            Exit Sub
        End If
        ch.Huella_a_capturar = 7
        If Autenticacion Then
            Dim Capturar_aute As Boolean = False
            For Each n As String In Num_huellas
                Dim i As Integer
                i = Convert.ToInt64(n)
                If i = ch.Huella_a_capturar Then
                    Capturar_aute = True
                End If
            Next
            If Not Capturar_aute Then
                Exit Sub
            End If
        End If
        ch.Calidad = Calidad
        ch.ShowDialog()
        Label_Cantidad_Huellas.Text = _Huellas_Capturadas.Cantidad_Huellas
        If ch.Capturada Then
            PictureBox_H7.Visible = True
            PictureBox_a_7.Visible = False
            PictureBox_7.Enabled = False
        Else
            PictureBox_H7.Visible = False
        End If
    End Sub

    Private Sub PictureBox_8_Click(sender As Object, e As EventArgs) Handles PictureBox_8.Click
        Dim ch As New Capturar(_Huellas_Capturadas, FingerPrinterAux)
        'Cantidad_De_Huellas = Cantidad_De_Huellas + 1
        If _Huellas_Capturadas.Cantidad_Huellas >= Cantidad_De_Huellas_a_Capturar Then
            MsgBox("Se han capturado la cantidad de huellas esperadas.", MsgBoxStyle.Information, "Enrolamiento")
            Exit Sub
        End If
        ch.Huella_a_capturar = 8
        If Autenticacion Then
            Dim Capturar_aute As Boolean = False
            For Each n As String In Num_huellas
                Dim i As Integer
                i = Convert.ToInt64(n)
                If i = ch.Huella_a_capturar Then
                    Capturar_aute = True
                End If
            Next
            If Not Capturar_aute Then
                Exit Sub
            End If
        End If
        ch.Calidad = Calidad
        ch.ShowDialog()
        Label_Cantidad_Huellas.Text = _Huellas_Capturadas.Cantidad_Huellas
        If ch.Capturada Then
            PictureBox_H8.Visible = True
            PictureBox_a_8.Visible = False
            PictureBox_8.Enabled = False
        Else
            PictureBox_H8.Visible = False
        End If
    End Sub

    Private Sub PictureBox_9_Click(sender As Object, e As EventArgs) Handles PictureBox_9.Click
        Dim ch As New Capturar(_Huellas_Capturadas, FingerPrinterAux)
        'Cantidad_De_Huellas = Cantidad_De_Huellas + 1
        If _Huellas_Capturadas.Cantidad_Huellas >= Cantidad_De_Huellas_a_Capturar Then
            MsgBox("Se han capturado la cantidad de huellas esperadas.", MsgBoxStyle.Information, "Enrolamiento")
            Exit Sub
        End If
        ch.Huella_a_capturar = 9
        If Autenticacion Then
            Dim Capturar_aute As Boolean = False
            For Each n As String In Num_huellas
                Dim i As Integer
                i = Convert.ToInt64(n)
                If i = ch.Huella_a_capturar Then
                    Capturar_aute = True
                End If
            Next
            If Not Capturar_aute Then
                Exit Sub
            End If
        End If
        ch.Calidad = Calidad
        ch.ShowDialog()
        Label_Cantidad_Huellas.Text = _Huellas_Capturadas.Cantidad_Huellas
        If ch.Capturada Then
            PictureBox_H9.Visible = True
            PictureBox_a_9.Visible = False
            PictureBox_9.Enabled = False
        Else
            PictureBox_H9.Visible = False
        End If
    End Sub

    Private Sub PictureBox_10_Click(sender As Object, e As EventArgs) Handles PictureBox_10.Click
        Dim ch As New Capturar(_Huellas_Capturadas, FingerPrinterAux)
        'Cantidad_De_Huellas = Cantidad_De_Huellas + 1
        If _Huellas_Capturadas.Cantidad_Huellas >= Cantidad_De_Huellas_a_Capturar Then
            MsgBox("Se han capturado la cantidad de huellas esperadas.", MsgBoxStyle.Information, "Enrolamiento")
            Exit Sub
        End If
        ch.Huella_a_capturar = 10
        If Autenticacion Then
            Dim Capturar_aute As Boolean = False
            For Each n As String In Num_huellas
                Dim i As Integer
                i = Convert.ToInt64(n)
                If i = ch.Huella_a_capturar Then
                    Capturar_aute = True
                End If
            Next
            If Not Capturar_aute Then
                Exit Sub
            End If
        End If
        ch.Calidad = Calidad
        ch.ShowDialog()
        Label_Cantidad_Huellas.Text = _Huellas_Capturadas.Cantidad_Huellas
        If ch.Capturada Then
            PictureBox_H10.Visible = True
            PictureBox_a_10.Visible = False
            PictureBox_10.Enabled = False
        Else
            PictureBox_H10.Visible = False
        End If
    End Sub


    Private Sub Button_Cancelar_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click
        Me.Dispose()
        Me._Huellas_Capturadas = Nothing
        Me.Close()
    End Sub

    Private Sub Button_Finalizar_Click(sender As Object, e As EventArgs) Handles Button_Finalizar.Click
        If Convert.ToInt32(Label_Cantidad_Huellas.Text) = Cantidad_De_Huellas_a_Capturar Then
            Me.Close()
        Else
            Dim Resultado As MsgBoxResult = MsgBox("Se deben capturar minimo " & Cantidad_De_Huellas_a_Capturar & " huellas!" & vbCrLf & "Si desea continuar con la captura presione aceptar o cancelar para finalizar.", MsgBoxStyle.OkCancel Or MsgBoxStyle.Exclamation, "Capturar Huellas")
            '  Dim s As MsgBoxStyle
            If Resultado = MsgBoxResult.Cancel Then
                Me.Dispose()
                Me._Huellas_Capturadas = Nothing
            End If
        End If
    End Sub
End Class