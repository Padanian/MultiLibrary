<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MultiPumpPanel
    Inherits System.Windows.Forms.UserControl

    'UserControl1 esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Me.lblSwitchTag = New System.Windows.Forms.Label()
        Me.lblPumpTag = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCounterPump1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblCounterPump2 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pbPump2LED = New System.Windows.Forms.PictureBox()
        Me.pbPump1LED = New System.Windows.Forms.PictureBox()
        Me.pbSwitchPump = New System.Windows.Forms.PictureBox()
        Me.pbSwitchOnOff = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbPump2LED, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbPump1LED, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSwitchPump, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSwitchOnOff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSwitchTag
        '
        Me.lblSwitchTag.Location = New System.Drawing.Point(3, 79)
        Me.lblSwitchTag.Name = "lblSwitchTag"
        Me.lblSwitchTag.Size = New System.Drawing.Size(58, 18)
        Me.lblSwitchTag.TabIndex = 1
        Me.lblSwitchTag.Text = "Label1"
        Me.lblSwitchTag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPumpTag
        '
        Me.lblPumpTag.Location = New System.Drawing.Point(89, 79)
        Me.lblPumpTag.Name = "lblPumpTag"
        Me.lblPumpTag.Size = New System.Drawing.Size(58, 18)
        Me.lblPumpTag.TabIndex = 2
        Me.lblPumpTag.Text = "Label1"
        Me.lblPumpTag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(158, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Hour counter Pump 1"
        '
        'lblCounterPump1
        '
        Me.lblCounterPump1.AutoSize = True
        Me.lblCounterPump1.Font = New System.Drawing.Font("Digital-7 Mono", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounterPump1.Location = New System.Drawing.Point(3, 0)
        Me.lblCounterPump1.Name = "lblCounterPump1"
        Me.lblCounterPump1.Size = New System.Drawing.Size(63, 20)
        Me.lblCounterPump1.TabIndex = 4
        Me.lblCounterPump1.Text = "000000"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(158, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Hour counter Pump 2"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblCounterPump1)
        Me.Panel1.Location = New System.Drawing.Point(268, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(69, 23)
        Me.Panel1.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblCounterPump2)
        Me.Panel2.Location = New System.Drawing.Point(268, 34)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(69, 23)
        Me.Panel2.TabIndex = 5
        '
        'lblCounterPump2
        '
        Me.lblCounterPump2.AutoSize = True
        Me.lblCounterPump2.Font = New System.Drawing.Font("Digital-7 Mono", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounterPump2.Location = New System.Drawing.Point(3, 0)
        Me.lblCounterPump2.Name = "lblCounterPump2"
        Me.lblCounterPump2.Size = New System.Drawing.Size(63, 20)
        Me.lblCounterPump2.TabIndex = 4
        Me.lblCounterPump2.Text = "000000"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(158, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Lead-lag rotation time"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Font = New System.Drawing.Font("Digital-7 Mono", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDown1.Location = New System.Drawing.Point(272, 72)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(63, 26)
        Me.NumericUpDown1.TabIndex = 7
        Me.NumericUpDown1.Value = New Decimal(New Integer() {168, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(158, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Pump running"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(253, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Pump 1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(253, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Pump 2"
        '
        'pbPump2LED
        '
        Me.pbPump2LED.Image = My.Resources.Resources.led_off_black
        Me.pbPump2LED.Location = New System.Drawing.Point(301, 145)
        Me.pbPump2LED.Name = "pbPump2LED"
        Me.pbPump2LED.Size = New System.Drawing.Size(32, 32)
        Me.pbPump2LED.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbPump2LED.TabIndex = 8
        Me.pbPump2LED.TabStop = False
        '
        'pbPump1LED
        '
        Me.pbPump1LED.Image = My.Resources.Resources.led_green_black
        Me.pbPump1LED.Location = New System.Drawing.Point(301, 109)
        Me.pbPump1LED.Name = "pbPump1LED"
        Me.pbPump1LED.Size = New System.Drawing.Size(32, 32)
        Me.pbPump1LED.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbPump1LED.TabIndex = 8
        Me.pbPump1LED.TabStop = False
        '
        'pbSwitchPump
        '
        Me.pbSwitchPump.Image = My.Resources.Resources.PanelSwitchOnPumpAut
        Me.pbSwitchPump.Location = New System.Drawing.Point(83, 0)
        Me.pbSwitchPump.Name = "pbSwitchPump"
        Me.pbSwitchPump.Size = New System.Drawing.Size(64, 64)
        Me.pbSwitchPump.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbSwitchPump.TabIndex = 3
        Me.pbSwitchPump.TabStop = False
        '
        'pbSwitchOnOff
        '
        Me.pbSwitchOnOff.Image = My.Resources.Resources.PanelSwitchOn_2pos
        Me.pbSwitchOnOff.Location = New System.Drawing.Point(0, 0)
        Me.pbSwitchOnOff.Name = "pbSwitchOnOff"
        Me.pbSwitchOnOff.Size = New System.Drawing.Size(64, 64)
        Me.pbSwitchOnOff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbSwitchOnOff.TabIndex = 3
        Me.pbSwitchOnOff.TabStop = False
        '
        'MultiPumpPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.pbPump2LED)
        Me.Controls.Add(Me.pbPump1LED)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pbSwitchPump)
        Me.Controls.Add(Me.pbSwitchOnOff)
        Me.Controls.Add(Me.lblPumpTag)
        Me.Controls.Add(Me.lblSwitchTag)
        Me.Name = "MultiPumpPanel"
        Me.Size = New System.Drawing.Size(345, 205)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbPump2LED, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbPump1LED, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSwitchPump, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSwitchOnOff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblSwitchTag As Label
    Friend WithEvents lblPumpTag As Label
    Friend WithEvents pbSwitchOnOff As PictureBox
    Friend WithEvents pbSwitchPump As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblCounterPump1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblCounterPump2 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents pbPump1LED As PictureBox
    Friend WithEvents pbPump2LED As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
End Class
