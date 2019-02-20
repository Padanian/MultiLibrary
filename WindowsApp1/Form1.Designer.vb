<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MultiPumpPanel1 = New MultiLibrary.MultiPumpPanel()
        Me.MultiPanelSwitch1 = New MultiLibrary.MultiPanelSwitch()
        Me.MultiPanelSwitch2 = New MultiLibrary.MultiPanelSwitch()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'MultiPumpPanel1
        '
        Me.MultiPumpPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MultiPumpPanel1.hourCounterPump1 = 292
        Me.MultiPumpPanel1.hourCounterPump2 = 292
        Me.MultiPumpPanel1.lblPumpText = "Mode"
        Me.MultiPumpPanel1.lbltext = "Switch"
        Me.MultiPumpPanel1.Location = New System.Drawing.Point(12, 243)
        Me.MultiPumpPanel1.Name = "MultiPumpPanel1"
        Me.MultiPumpPanel1.pump1Alarm = False
        Me.MultiPumpPanel1.pump2Alarm = False
        Me.MultiPumpPanel1.SemaphorBlinking = False
        Me.MultiPumpPanel1.semaphorColor = System.Drawing.Color.Black
        Me.MultiPumpPanel1.semaphortext = "Signals"
        Me.MultiPumpPanel1.SemaphorVisible = True
        Me.MultiPumpPanel1.Size = New System.Drawing.Size(345, 200)
        Me.MultiPumpPanel1.TabIndex = 0
        '
        'MultiPanelSwitch1
        '
        Me.MultiPanelSwitch1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MultiPanelSwitch1.isSemaphorBlinking = False
        Me.MultiPanelSwitch1.isSemaphorVisible = True
        Me.MultiPanelSwitch1.lbltext = "Relè 3"
        Me.MultiPanelSwitch1.Location = New System.Drawing.Point(407, 243)
        Me.MultiPanelSwitch1.Name = "MultiPanelSwitch1"
        Me.MultiPanelSwitch1.positions = 2
        Me.MultiPanelSwitch1.semaphorColor = System.Drawing.Color.Black
        Me.MultiPanelSwitch1.semaphortext = "Allarme 3"
        Me.MultiPanelSwitch1.Size = New System.Drawing.Size(64, 200)
        Me.MultiPanelSwitch1.TabIndex = 1
        '
        'MultiPanelSwitch2
        '
        Me.MultiPanelSwitch2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MultiPanelSwitch2.isSemaphorBlinking = False
        Me.MultiPanelSwitch2.isSemaphorVisible = True
        Me.MultiPanelSwitch2.lbltext = "Relè 4"
        Me.MultiPanelSwitch2.Location = New System.Drawing.Point(511, 243)
        Me.MultiPanelSwitch2.Name = "MultiPanelSwitch2"
        Me.MultiPanelSwitch2.positions = 2
        Me.MultiPanelSwitch2.semaphorColor = System.Drawing.Color.Black
        Me.MultiPanelSwitch2.semaphortext = "Allarme 4"
        Me.MultiPanelSwitch2.Size = New System.Drawing.Size(64, 200)
        Me.MultiPanelSwitch2.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 460)
        Me.Controls.Add(Me.MultiPanelSwitch2)
        Me.Controls.Add(Me.MultiPanelSwitch1)
        Me.Controls.Add(Me.MultiPumpPanel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents MultiPumpPanel1 As MultiLibrary.MultiPumpPanel
    Friend WithEvents MultiPanelSwitch1 As MultiLibrary.MultiPanelSwitch
    Friend WithEvents MultiPanelSwitch2 As MultiLibrary.MultiPanelSwitch
End Class
