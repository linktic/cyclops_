Friend Class Configurar_Conexion
    Public Url As String
    Sub New(ByRef url1 As String)
        InitializeComponent()

        Url = url1

    End Sub

    Private Sub Button_Captura_Foto_Click(sender As Object, e As EventArgs) Handles Button_Captura_Foto.Click
        Url = TextBox1.Text
        Me.Close()
    End Sub

    Private Sub Configurar_Conexion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = Url
    End Sub
End Class