Friend Class Huellas
    Private Const MAX_TEMPLATE_SIZE As Integer = 1024
    Private Const MAX_TEMPLATE_NUM As Integer = 9
    Public m_template As Byte()()
    Public m_template_size As Integer()
    Public Cantidad_Huellas As Integer
    Public Huellas_list As New List(Of Huella)

    Sub New()
        m_template = New Byte(MAX_TEMPLATE_NUM)() {}
        For i As Integer = 0 To MAX_TEMPLATE_NUM
            m_template(i) = New Byte(MAX_TEMPLATE_SIZE) {}
        Next

        m_template_size = New Integer(MAX_TEMPLATE_NUM) {}
        Cantidad_Huellas = 0

    End Sub
    Function Agregar_Huella(ByRef Template As Byte(), ByRef Template_Size As Integer, ByVal Numero_Dedo As Integer) As Boolean
        Try
            Template(24) = Numero_Dedo
            System.Array.Copy(Template, 0, m_template(Cantidad_Huellas), 0, Template_Size) ' Modificar minucia y agregar número de dedo
            m_template_size(Cantidad_Huellas) = Template_Size
            Cantidad_Huellas = Cantidad_Huellas + 1
            Dim h As New Huella
            h.Datos = Convert.ToBase64String(Template)
            h.HuellaID = Numero_Dedo
            h.Formato = "ISO"
            Huellas_list.Add(h)
            Return True
        Catch ex As Exception
            'Error agregando huella en la lista
            Return False
        End Try
    End Function

End Class
