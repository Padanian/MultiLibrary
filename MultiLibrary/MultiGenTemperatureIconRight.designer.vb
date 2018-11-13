<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultiGenTemperatureIconRight
    Inherits System.Windows.Forms.UserControl

    'UserControl1 esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblTemp = New System.Windows.Forms.Label()
        Me.pbLED = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.pbLED, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(4, 20)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(34, 13)
        Me.lblName.TabIndex = 22
        Me.lblName.Text = "Tashp"
        '
        'lblTemp
        '
        Me.lblTemp.AutoSize = True
        Me.lblTemp.Location = New System.Drawing.Point(4, 39)
        Me.lblTemp.Name = "lblTemp"
        Me.lblTemp.Size = New System.Drawing.Size(38, 13)
        Me.lblTemp.TabIndex = 23
        Me.lblTemp.Text = "99.9°C"
        '
        'pbLED
        '
        Me.pbLED.Image = Global.MultiLibrary.My.Resources.Resources.ledoff
        Me.pbLED.Location = New System.Drawing.Point(56, 3)
        Me.pbLED.Name = "pbLED"
        Me.pbLED.Size = New System.Drawing.Size(16, 16)
        Me.pbLED.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLED.TabIndex = 25
        Me.pbLED.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.MultiLibrary.My.Resources.Resources.thermometer_symbol_transp
        Me.PictureBox1.Location = New System.Drawing.Point(40, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'MultiGenTemperatureIconRight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.pbLED)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblTemp)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Segoe UI Semilight", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "MultiGenTemperatureIconRight"
        Me.Size = New System.Drawing.Size(75, 55)
        CType(Me.pbLED, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbLED As PictureBox
    Friend WithEvents lblName As Label
    Friend WithEvents lblTemp As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class