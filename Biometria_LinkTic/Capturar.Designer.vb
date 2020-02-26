<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Capturar
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
        
        
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox_huella = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox_huella, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(0, 255)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(227, 21)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Iniciar Captura"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox_huella
        '
        Me.PictureBox_huella.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox_huella.Name = "PictureBox_huella"
        Me.PictureBox_huella.Size = New System.Drawing.Size(227, 254)
        Me.PictureBox_huella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox_huella.TabIndex = 0
        Me.PictureBox_huella.TabStop = False
        '
        'Capturar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(227, 276)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox_huella)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Capturar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Capturar"
        CType(Me.PictureBox_huella, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        
    End Sub
    Friend WithEvents PictureBox_huella As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
