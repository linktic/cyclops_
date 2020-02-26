Friend Class Evento_Local


    Public Evento As Tipo_Evento

    Public Mensaje As String

    Public Enum Tipo_Evento
        None
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
    End Enum

End Class
