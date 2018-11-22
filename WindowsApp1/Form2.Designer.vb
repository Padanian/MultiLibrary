<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Me.MultiPumpPanel1 = New MultiLibrary.MultiPumpPanel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'MultiPumpPanel1
        '
        Me.MultiPumpPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MultiPumpPanel1.hourCounterPump1 = 88
        Me.MultiPumpPanel1.hourCounterPump2 = 88
        Me.MultiPumpPanel1.lblPumpText = "Mode"
        Me.MultiPumpPanel1.lbltext = "Switch"
        Me.MultiPumpPanel1.Location = New System.Drawing.Point(12, 12)
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
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(277, 231)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Ritorna"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 268)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MultiPumpPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Form2"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MultiPumpPanel1 As MultiLibrary.MultiPumpPanel
    Friend WithEvents Button1 As Button
End Class
