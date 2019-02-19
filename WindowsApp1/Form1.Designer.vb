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
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 150
        '
        'MultiPumpPanel1
        '
        Me.MultiPumpPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MultiPumpPanel1.hourCounterPump1 = 128
        Me.MultiPumpPanel1.hourCounterPump2 = 128
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 460)
        Me.Controls.Add(Me.MultiPumpPanel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents MultiPumpPanel1 As MultiLibrary.MultiPumpPanel
End Class
