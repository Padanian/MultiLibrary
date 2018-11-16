<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultiGenPointCalendarClock
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Me.pbCalendarClockSettings = New System.Windows.Forms.PictureBox()
        Me.pbLed = New System.Windows.Forms.PictureBox()
        CType(Me.pbCalendarClockSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbLed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbCalendarClockSettings
        '
        Me.pbCalendarClockSettings.Image = Global.MultiLibrary.My.Resources.Resources.SettingsGroup_64x
        Me.pbCalendarClockSettings.Location = New System.Drawing.Point(81, 0)
        Me.pbCalendarClockSettings.Name = "pbCalendarClockSettings"
        Me.pbCalendarClockSettings.Size = New System.Drawing.Size(15, 15)
        Me.pbCalendarClockSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbCalendarClockSettings.TabIndex = 0
        Me.pbCalendarClockSettings.TabStop = False
        '
        'pbLed
        '
        Me.pbLed.Image = Global.MultiLibrary.My.Resources.Resources.ledoff
        Me.pbLed.Location = New System.Drawing.Point(32, 32)
        Me.pbLed.Name = "pbLed"
        Me.pbLed.Size = New System.Drawing.Size(32, 32)
        Me.pbLed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLed.TabIndex = 1
        Me.pbLed.TabStop = False
        '
        'MultiGenPointCalendarClock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pbLed)
        Me.Controls.Add(Me.pbCalendarClockSettings)
        Me.Name = "MultiGenPointCalendarClock"
        Me.Size = New System.Drawing.Size(96, 96)
        CType(Me.pbCalendarClockSettings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbLed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbCalendarClockSettings As PictureBox
    Friend WithEvents pbLed As PictureBox
End Class
