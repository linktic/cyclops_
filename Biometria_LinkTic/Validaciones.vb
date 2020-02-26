Friend Class Validaciones
    Public Shared Function Validar_Solicitud(ByVal Solicitud As Datos_Solcitud) As Evento_Local
        Dim Evento_Validacion As New Evento_Local

        If (Solicitud.m_Codigo_Entidad) < 0 Then
            Evento_Validacion.Evento = Evento_Local.Tipo_Evento.SB008_Excepción_en_parámetros_de_entrada

            Evento_Validacion.Mensaje = "Codigo Entidad no es valido"
            Return Evento_Validacion
        End If

        If String.IsNullOrEmpty(Solicitud.m_Codigo_Oficina) Then
            Evento_Validacion.Evento = Evento_Local.Tipo_Evento.SB008_Excepción_en_parámetros_de_entrada
            Evento_Validacion.Mensaje = "Codigo_Oficina"
            Return Evento_Validacion
        Else
            If Solicitud.m_Codigo_Oficina.Length > 25 Then
                Evento_Validacion.Evento = Evento_Local.Tipo_Evento.SB008_Excepción_en_parámetros_de_entrada
                Evento_Validacion.Mensaje = "Codigo_Oficina excedió el número de caracteres"
                Return Evento_Validacion
            End If
        End If

        If Solicitud.m_Codigo_Servicio < 0 Then
            Evento_Validacion.Evento = Evento_Local.Tipo_Evento.SB008_Excepción_en_parámetros_de_entrada
            Evento_Validacion.Mensaje = "Codigo Servicio no es válido"
            Return Evento_Validacion
        End If


        If String.IsNullOrEmpty(Solicitud.m_NI_Cliente) Then
            Evento_Validacion.Evento = Evento_Local.Tipo_Evento.SB008_Excepción_en_parámetros_de_entrada
            Evento_Validacion.Mensaje = "Numero_Identificacion_Cliente no puede ser null"
            Return Evento_Validacion
        Else
            If Solicitud.m_NI_Cliente.Length > 25 Then
                Evento_Validacion.Evento = Evento_Local.Tipo_Evento.SB008_Excepción_en_parámetros_de_entrada
                Evento_Validacion.Mensaje = "Numero_Identificacion_Cliente excedió el número de caracteres"
                Return Evento_Validacion
            Else
                Try
                    Convert.ToInt64(Solicitud.m_NI_Cliente)
                Catch ex As Exception
                    Evento_Validacion.Evento = Evento_Local.Tipo_Evento.SB008_Excepción_en_parámetros_de_entrada
                    Evento_Validacion.Mensaje = "Numero_Identificacion_Cliente debe ser númerico"
                    Return Evento_Validacion
                End Try
            End If
        End If

        If String.IsNullOrEmpty(Solicitud.m_NI_Usuario) Then
            Evento_Validacion.Evento = Evento_Local.Tipo_Evento.SB008_Excepción_en_parámetros_de_entrada
            Evento_Validacion.Mensaje = "Numero_Identificacion_Usuario no puede ser null"
            Return Evento_Validacion
        Else
            If Solicitud.m_NI_Cliente.Length > 25 Then
                Evento_Validacion.Evento = Evento_Local.Tipo_Evento.SB008_Excepción_en_parámetros_de_entrada
                Evento_Validacion.Mensaje = "Numero_Identificacion_Usuario excedió el número de caracteres"
                Return Evento_Validacion
            Else
                Try
                    Convert.ToInt64(Solicitud.m_NI_Usuario)
                Catch ex As Exception
                    Evento_Validacion.Evento = Evento_Local.Tipo_Evento.SB008_Excepción_en_parámetros_de_entrada
                    Evento_Validacion.Mensaje = "Numero_Identificacion_Usuario debe ser númerico"
                    Return Evento_Validacion
                End Try
            End If
        End If

        If (Solicitud.m_TI_Cliente) < 0 Or (Solicitud.m_TI_Cliente) >= 3 Then
            Evento_Validacion.Evento = Evento_Local.Tipo_Evento.SB008_Excepción_en_parámetros_de_entrada
            Evento_Validacion.Mensaje = "El tipo de documento del cliente no es valido"
            Return Evento_Validacion
        End If
        If (Solicitud.m_TI_Usuario) < 0 Or (Solicitud.m_TI_Usuario) >= 3 Then
            Evento_Validacion.Evento = Evento_Local.Tipo_Evento.SB008_Excepción_en_parámetros_de_entrada
            Evento_Validacion.Mensaje = "El tipo de documento del usuario no es valido"
            Return Evento_Validacion
        End If

        Return Nothing
    End Function
End Class
