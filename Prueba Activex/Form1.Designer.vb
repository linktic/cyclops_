<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBox_TIC = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox_NIC = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button_Guardar = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox_Usuario = New System.Windows.Forms.GroupBox()
        Me.ComboBox_TIU = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox_NIU = New System.Windows.Forms.TextBox()
        Me.GroupBox_Entidad = New System.Windows.Forms.GroupBox()
        Me.TextBox_Entidad = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox_Servicio = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox_Oficina = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ConexiónTokenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox_Usuario.SuspendLayout()
        Me.GroupBox_Entidad.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(15, 29)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(356, 258)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(348, 232)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Información de cliente"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.ComboBox_TIC)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.TextBox_NIC)
        Me.GroupBox3.Location = New System.Drawing.Point(21, 50)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(304, 157)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(14, 125)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(137, 23)
        Me.Button3.TabIndex = 16
        Me.Button3.Text = "Eliminar Enrolamiento"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(157, 96)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(137, 23)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "Autenticar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(14, 96)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(137, 23)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Enrolar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboBox_TIC
        '
        Me.ComboBox_TIC.FormattingEnabled = True
        Me.ComboBox_TIC.Items.AddRange(New Object() {"CC ", "CE", "TI"})
        Me.ComboBox_TIC.Location = New System.Drawing.Point(144, 22)
        Me.ComboBox_TIC.Name = "ComboBox_TIC"
        Me.ComboBox_TIC.Size = New System.Drawing.Size(150, 21)
        Me.ComboBox_TIC.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Tipo de Identificacion:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Número de identificación:"
        '
        'TextBox_NIC
        '
        Me.TextBox_NIC.Location = New System.Drawing.Point(144, 56)
        Me.TextBox_NIC.MaxLength = 25
        Me.TextBox_NIC.Name = "TextBox_NIC"
        Me.TextBox_NIC.Size = New System.Drawing.Size(150, 20)
        Me.TextBox_NIC.TabIndex = 11
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button_Guardar)
        Me.TabPage2.Controls.Add(Me.CheckBox1)
        Me.TabPage2.Controls.Add(Me.GroupBox_Usuario)
        Me.TabPage2.Controls.Add(Me.GroupBox_Entidad)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(348, 232)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Información de Entidad"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button_Guardar
        '
        Me.Button_Guardar.Location = New System.Drawing.Point(193, 203)
        Me.Button_Guardar.Name = "Button_Guardar"
        Me.Button_Guardar.Size = New System.Drawing.Size(137, 23)
        Me.Button_Guardar.TabIndex = 21
        Me.Button_Guardar.Text = "Guardar"
        Me.Button_Guardar.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(6, 209)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(53, 17)
        Me.CheckBox1.TabIndex = 20
        Me.CheckBox1.Text = "Editar"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'GroupBox_Usuario
        '
        Me.GroupBox_Usuario.Controls.Add(Me.ComboBox_TIU)
        Me.GroupBox_Usuario.Controls.Add(Me.Label6)
        Me.GroupBox_Usuario.Controls.Add(Me.Label7)
        Me.GroupBox_Usuario.Controls.Add(Me.TextBox_NIU)
        Me.GroupBox_Usuario.Location = New System.Drawing.Point(6, 108)
        Me.GroupBox_Usuario.Name = "GroupBox_Usuario"
        Me.GroupBox_Usuario.Size = New System.Drawing.Size(324, 89)
        Me.GroupBox_Usuario.TabIndex = 19
        Me.GroupBox_Usuario.TabStop = False
        Me.GroupBox_Usuario.Text = "Usuario:"
        '
        'ComboBox_TIU
        '
        Me.ComboBox_TIU.FormattingEnabled = True
        Me.ComboBox_TIU.Items.AddRange(New Object() {"CC ", "CE", "TI"})
        Me.ComboBox_TIU.Location = New System.Drawing.Point(159, 23)
        Me.ComboBox_TIU.Name = "ComboBox_TIU"
        Me.ComboBox_TIU.Size = New System.Drawing.Size(150, 21)
        Me.ComboBox_TIU.TabIndex = 21
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(26, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Tipo de Identificacion :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(26, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(127, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Número de identificación:"
        '
        'TextBox_NIU
        '
        Me.TextBox_NIU.Location = New System.Drawing.Point(159, 54)
        Me.TextBox_NIU.MaxLength = 25
        Me.TextBox_NIU.Name = "TextBox_NIU"
        Me.TextBox_NIU.Size = New System.Drawing.Size(150, 20)
        Me.TextBox_NIU.TabIndex = 19
        '
        'GroupBox_Entidad
        '
        Me.GroupBox_Entidad.Controls.Add(Me.TextBox_Entidad)
        Me.GroupBox_Entidad.Controls.Add(Me.Label5)
        Me.GroupBox_Entidad.Controls.Add(Me.TextBox_Servicio)
        Me.GroupBox_Entidad.Controls.Add(Me.Label1)
        Me.GroupBox_Entidad.Controls.Add(Me.Label2)
        Me.GroupBox_Entidad.Controls.Add(Me.TextBox_Oficina)
        Me.GroupBox_Entidad.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox_Entidad.Name = "GroupBox_Entidad"
        Me.GroupBox_Entidad.Size = New System.Drawing.Size(324, 96)
        Me.GroupBox_Entidad.TabIndex = 18
        Me.GroupBox_Entidad.TabStop = False
        '
        'TextBox_Entidad
        '
        Me.TextBox_Entidad.Location = New System.Drawing.Point(108, 23)
        Me.TextBox_Entidad.Name = "TextBox_Entidad"
        Me.TextBox_Entidad.Size = New System.Drawing.Size(56, 20)
        Me.TextBox_Entidad.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Codigo Oficina:"
        '
        'TextBox_Servicio
        '
        Me.TextBox_Servicio.Location = New System.Drawing.Point(253, 23)
        Me.TextBox_Servicio.Name = "TextBox_Servicio"
        Me.TextBox_Servicio.Size = New System.Drawing.Size(56, 20)
        Me.TextBox_Servicio.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Codigo Entidad:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(170, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Código Servicio:"
        '
        'TextBox_Oficina
        '
        Me.TextBox_Oficina.Location = New System.Drawing.Point(108, 61)
        Me.TextBox_Oficina.MaxLength = 25
        Me.TextBox_Oficina.Name = "TextBox_Oficina"
        Me.TextBox_Oficina.Size = New System.Drawing.Size(201, 20)
        Me.TextBox_Oficina.TabIndex = 15
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(383, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConexiónTokenToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(96, 22)
        Me.ToolStripDropDownButton1.Text = "Configuración"
        '
        'ConexiónTokenToolStripMenuItem
        '
        Me.ConexiónTokenToolStripMenuItem.Name = "ConexiónTokenToolStripMenuItem"
        Me.ConexiónTokenToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ConexiónTokenToolStripMenuItem.Text = "Conexión Token"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(383, 299)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cliente_Biometría"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox_Usuario.ResumeLayout(False)
        Me.GroupBox_Usuario.PerformLayout()
        Me.GroupBox_Entidad.ResumeLayout(False)
        Me.GroupBox_Entidad.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ComboBox_TIC As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox_NIC As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox_Usuario As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox_TIU As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox_NIU As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox_Entidad As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox_Entidad As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Servicio As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Oficina As System.Windows.Forms.TextBox
    Friend WithEvents Button_Guardar As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ConexiónTokenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
