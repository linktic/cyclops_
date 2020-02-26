<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Enrolamiento
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ConfiguraciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CámaraWebToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_Usuario = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_Codigo_Entidad = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label_Huellas_a_capturar = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Numero_Identificacion = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Tipo_Identificacion = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox_Foto = New System.Windows.Forms.PictureBox()
        Me.Label_Cantidad_Huellas = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button_Captura_Foto = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button_Enviar_Enrolamiento = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox_Foto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguraciónToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(444, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ConfiguraciónToolStripMenuItem
        '
        Me.ConfiguraciónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CámaraWebToolStripMenuItem})
        Me.ConfiguraciónToolStripMenuItem.Name = "ConfiguraciónToolStripMenuItem"
        Me.ConfiguraciónToolStripMenuItem.Size = New System.Drawing.Size(95, 20)
        Me.ConfiguraciónToolStripMenuItem.Text = "&Configuración"
        '
        'CámaraWebToolStripMenuItem
        '
        Me.CámaraWebToolStripMenuItem.Name = "CámaraWebToolStripMenuItem"
        Me.CámaraWebToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CámaraWebToolStripMenuItem.Text = "Cámara Web"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(50, 17)
        Me.ToolStripStatusLabel5.Text = "Usuario:"
        '
        'ToolStripStatusLabel_Usuario
        '
        Me.ToolStripStatusLabel_Usuario.Name = "ToolStripStatusLabel_Usuario"
        Me.ToolStripStatusLabel_Usuario.Size = New System.Drawing.Size(121, 17)
        Me.ToolStripStatusLabel_Usuario.Text = "ToolStripStatusLabel2"
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(120, 17)
        Me.ToolStripStatusLabel7.Text = "Código de la entidad:"
        '
        'ToolStripStatusLabel_Codigo_Entidad
        '
        Me.ToolStripStatusLabel_Codigo_Entidad.Name = "ToolStripStatusLabel_Codigo_Entidad"
        Me.ToolStripStatusLabel_Codigo_Entidad.Size = New System.Drawing.Size(121, 17)
        Me.ToolStripStatusLabel_Codigo_Entidad.Text = "ToolStripStatusLabel4"
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel_Usuario, Me.ToolStripStatusLabel7, Me.ToolStripStatusLabel_Codigo_Entidad})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 301)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip2.Size = New System.Drawing.Size(444, 22)
        Me.StatusStrip2.TabIndex = 4
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label_Huellas_a_capturar)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Numero_Identificacion)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Tipo_Identificacion)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label_Cantidad_Huellas)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Button_Captura_Foto)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(417, 217)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Cliente", "Apoderado"})
        Me.ComboBox1.Location = New System.Drawing.Point(183, 34)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 25
        '
        'Label_Huellas_a_capturar
        '
        Me.Label_Huellas_a_capturar.AutoSize = True
        Me.Label_Huellas_a_capturar.Location = New System.Drawing.Point(229, 156)
        Me.Label_Huellas_a_capturar.Name = "Label_Huellas_a_capturar"
        Me.Label_Huellas_a_capturar.Size = New System.Drawing.Size(13, 13)
        Me.Label_Huellas_a_capturar.TabIndex = 24
        Me.Label_Huellas_a_capturar.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(202, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "de"
        '
        'Numero_Identificacion
        '
        Me.Numero_Identificacion.AutoSize = True
        Me.Numero_Identificacion.Location = New System.Drawing.Point(183, 120)
        Me.Numero_Identificacion.Name = "Numero_Identificacion"
        Me.Numero_Identificacion.Size = New System.Drawing.Size(43, 13)
        Me.Numero_Identificacion.TabIndex = 22
        Me.Numero_Identificacion.Text = "800000"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(180, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(153, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Número de Identificación:"
        '
        'Tipo_Identificacion
        '
        Me.Tipo_Identificacion.AutoSize = True
        Me.Tipo_Identificacion.Location = New System.Drawing.Point(183, 84)
        Me.Tipo_Identificacion.Name = "Tipo_Identificacion"
        Me.Tipo_Identificacion.Size = New System.Drawing.Size(21, 13)
        Me.Tipo_Identificacion.TabIndex = 20
        Me.Tipo_Identificacion.Text = "CC"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(180, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Tipo de Identificación:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PictureBox_Foto)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(126, 153)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        '
        'PictureBox_Foto
        '
        Me.PictureBox_Foto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Foto.Image = Global.Biometria_LinkTic.My.Resources.Resources.DefaultRostro
        Me.PictureBox_Foto.InitialImage = Nothing
        Me.PictureBox_Foto.Location = New System.Drawing.Point(9, 15)
        Me.PictureBox_Foto.Name = "PictureBox_Foto"
        Me.PictureBox_Foto.Size = New System.Drawing.Size(109, 128)
        Me.PictureBox_Foto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox_Foto.TabIndex = 3
        Me.PictureBox_Foto.TabStop = False
        '
        'Label_Cantidad_Huellas
        '
        Me.Label_Cantidad_Huellas.AutoSize = True
        Me.Label_Cantidad_Huellas.Location = New System.Drawing.Point(183, 156)
        Me.Label_Cantidad_Huellas.Name = "Label_Cantidad_Huellas"
        Me.Label_Cantidad_Huellas.Size = New System.Drawing.Size(13, 13)
        Me.Label_Cantidad_Huellas.TabIndex = 17
        Me.Label_Cantidad_Huellas.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(180, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(190, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Cantidad de huellas capturadas:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(183, 178)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(206, 25)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Capturar Huellas"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button_Captura_Foto
        '
        Me.Button_Captura_Foto.Location = New System.Drawing.Point(29, 178)
        Me.Button_Captura_Foto.Name = "Button_Captura_Foto"
        Me.Button_Captura_Foto.Size = New System.Drawing.Size(126, 25)
        Me.Button_Captura_Foto.TabIndex = 13
        Me.Button_Captura_Foto.Text = "Capturar Foto"
        Me.Button_Captura_Foto.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button2.Location = New System.Drawing.Point(12, 259)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(186, 25)
        Me.Button2.TabIndex = 23
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button_Enviar_Enrolamiento
        '
        Me.Button_Enviar_Enrolamiento.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button_Enviar_Enrolamiento.Location = New System.Drawing.Point(243, 259)
        Me.Button_Enviar_Enrolamiento.Name = "Button_Enviar_Enrolamiento"
        Me.Button_Enviar_Enrolamiento.Size = New System.Drawing.Size(186, 25)
        Me.Button_Enviar_Enrolamiento.TabIndex = 15
        Me.Button_Enviar_Enrolamiento.Text = "Enviar Enrolamiento"
        Me.Button_Enviar_Enrolamiento.UseVisualStyleBackColor = True
        '
        'Enrolamiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(444, 323)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStrip2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Button_Enviar_Enrolamiento)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Enrolamiento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Enrolamiento"
        Me.MenuStrip1.ResumeLayout(false)
        Me.MenuStrip1.PerformLayout
        Me.StatusStrip2.ResumeLayout(false)
        Me.StatusStrip2.PerformLayout
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        CType(Me.PictureBox_Foto,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ConfiguraciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CámaraWebToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_Usuario As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_Codigo_Entidad As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip2 As System.Windows.Forms.StatusStrip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Numero_Identificacion As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Tipo_Identificacion As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox_Foto As System.Windows.Forms.PictureBox
    Friend WithEvents Label_Cantidad_Huellas As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button_Captura_Foto As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button_Enviar_Enrolamiento As System.Windows.Forms.Button
    Friend WithEvents Label_Huellas_a_capturar As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
End Class
