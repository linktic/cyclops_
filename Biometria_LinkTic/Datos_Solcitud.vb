Friend Class Datos_Solcitud
    Public m_Codigo_Entidad As Integer

    Public m_Codigo_Servicio As Integer

    Public m_Codigo_Oficina As String

    Public m_TI_Usuario As TipoDocumento

    Public m_NI_Usuario As String

    Public m_TI_Cliente As TipoDocumento

    Public m_NI_Cliente As String

    Public Enum TipoDocumento
        CC = 0
        CE = 1
        TI = 2
    End Enum
End Class
