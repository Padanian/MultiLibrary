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
        Me.MultiTrimmerKnob1 = New MultiLibrary.MultiTrimmerKnob()
        Me.MultiPanelSwitch2 = New MultiLibrary.MultiPanelSwitch()
        Me.MultiLinearMeter1 = New MultiLibrary.MultiLinearMeter()
        Me.MultiVerticalMeter1 = New MultiLibrary.MultiVerticalMeter()
        Me.MultiPanelSwitch1 = New MultiLibrary.MultiPanelSwitch()
        Me.MultiPanelSemaphor3 = New MultiLibrary.MultiPanelSemaphor()
        Me.MultiPanelSemaphor2 = New MultiLibrary.MultiPanelSemaphor()
        Me.MultiPanelSemaphor1 = New MultiLibrary.MultiPanelSemaphor()
        Me.MultiGauge2 = New MultiLibrary.MultiGauge()
        Me.MultiGauge1 = New MultiLibrary.MultiGauge()
        Me.MultiAmmVoltmeter1 = New MultiLibrary.MultiAmmVoltmeter()
        Me.MultiGenPointCalendarClock1 = New MultiLibrary.MultiGenPointCalendarClock()
        Me.MultiTrimmerKnob2 = New MultiLibrary.MultiTrimmerKnob()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'MultiTrimmerKnob1
        '
        Me.MultiTrimmerKnob1.Location = New System.Drawing.Point(186, 99)
        Me.MultiTrimmerKnob1.maximum = 100
        Me.MultiTrimmerKnob1.minimum = 0
        Me.MultiTrimmerKnob1.Name = "MultiTrimmerKnob1"
        Me.MultiTrimmerKnob1.Size = New System.Drawing.Size(64, 64)
        Me.MultiTrimmerKnob1.TabIndex = 13
        Me.MultiTrimmerKnob1.value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'MultiPanelSwitch2
        '
        Me.MultiPanelSwitch2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MultiPanelSwitch2.isSemaphorBlinking = True
        Me.MultiPanelSwitch2.isSemaphorVisible = True
        Me.MultiPanelSwitch2.lbltext = "Text"
        Me.MultiPanelSwitch2.Location = New System.Drawing.Point(408, 145)
        Me.MultiPanelSwitch2.Name = "MultiPanelSwitch2"
        Me.MultiPanelSwitch2.positions = 2
        Me.MultiPanelSwitch2.semaphorColor = System.Drawing.Color.Yellow
        Me.MultiPanelSwitch2.semaphortext = "Text"
        Me.MultiPanelSwitch2.Size = New System.Drawing.Size(64, 200)
        Me.MultiPanelSwitch2.TabIndex = 11
        '
        'MultiLinearMeter1
        '
        Me.MultiLinearMeter1.isLedVisible = True
        Me.MultiLinearMeter1.Location = New System.Drawing.Point(34, 281)
        Me.MultiLinearMeter1.maximum = 100
        Me.MultiLinearMeter1.minimum = 0
        Me.MultiLinearMeter1.Name = "MultiLinearMeter1"
        Me.MultiLinearMeter1.Size = New System.Drawing.Size(144, 32)
        Me.MultiLinearMeter1.TabIndex = 10
        Me.MultiLinearMeter1.value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.MultiLinearMeter1.WarningThreshold = 80
        '
        'MultiVerticalMeter1
        '
        Me.MultiVerticalMeter1.isLedVisible = True
        Me.MultiVerticalMeter1.Location = New System.Drawing.Point(252, 175)
        Me.MultiVerticalMeter1.maximum = 100
        Me.MultiVerticalMeter1.minimum = 0
        Me.MultiVerticalMeter1.Name = "MultiVerticalMeter1"
        Me.MultiVerticalMeter1.Size = New System.Drawing.Size(32, 144)
        Me.MultiVerticalMeter1.TabIndex = 9
        Me.MultiVerticalMeter1.value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.MultiVerticalMeter1.WarningThreshold = 80
        '
        'MultiPanelSwitch1
        '
        Me.MultiPanelSwitch1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MultiPanelSwitch1.isSemaphorBlinking = False
        Me.MultiPanelSwitch1.isSemaphorVisible = False
        Me.MultiPanelSwitch1.lbltext = "Text"
        Me.MultiPanelSwitch1.Location = New System.Drawing.Point(338, 145)
        Me.MultiPanelSwitch1.Name = "MultiPanelSwitch1"
        Me.MultiPanelSwitch1.positions = 3
        Me.MultiPanelSwitch1.semaphorColor = System.Drawing.Color.Yellow
        Me.MultiPanelSwitch1.semaphortext = "Text"
        Me.MultiPanelSwitch1.Size = New System.Drawing.Size(64, 100)
        Me.MultiPanelSwitch1.TabIndex = 7
        '
        'MultiPanelSemaphor3
        '
        Me.MultiPanelSemaphor3.isSemaphorBlinking = False
        Me.MultiPanelSemaphor3.Location = New System.Drawing.Point(152, 175)
        Me.MultiPanelSemaphor3.Name = "MultiPanelSemaphor3"
        Me.MultiPanelSemaphor3.semaphorColor = System.Drawing.Color.Black
        Me.MultiPanelSemaphor3.semaphortext = "Text"
        Me.MultiPanelSemaphor3.Size = New System.Drawing.Size(64, 100)
        Me.MultiPanelSemaphor3.TabIndex = 6
        '
        'MultiPanelSemaphor2
        '
        Me.MultiPanelSemaphor2.isSemaphorBlinking = False
        Me.MultiPanelSemaphor2.Location = New System.Drawing.Point(82, 175)
        Me.MultiPanelSemaphor2.Name = "MultiPanelSemaphor2"
        Me.MultiPanelSemaphor2.semaphorColor = System.Drawing.Color.Yellow
        Me.MultiPanelSemaphor2.semaphortext = "Text"
        Me.MultiPanelSemaphor2.Size = New System.Drawing.Size(64, 100)
        Me.MultiPanelSemaphor2.TabIndex = 6
        '
        'MultiPanelSemaphor1
        '
        Me.MultiPanelSemaphor1.isSemaphorBlinking = False
        Me.MultiPanelSemaphor1.Location = New System.Drawing.Point(12, 175)
        Me.MultiPanelSemaphor1.Name = "MultiPanelSemaphor1"
        Me.MultiPanelSemaphor1.semaphorColor = System.Drawing.Color.Red
        Me.MultiPanelSemaphor1.semaphortext = "Text"
        Me.MultiPanelSemaphor1.Size = New System.Drawing.Size(64, 100)
        Me.MultiPanelSemaphor1.TabIndex = 6
        '
        'MultiGauge2
        '
        Me.MultiGauge2.isLedVisible = True
        Me.MultiGauge2.Location = New System.Drawing.Point(238, 12)
        Me.MultiGauge2.maximum = 100
        Me.MultiGauge2.minimum = 0
        Me.MultiGauge2.Name = "MultiGauge2"
        Me.MultiGauge2.Size = New System.Drawing.Size(64, 64)
        Me.MultiGauge2.TabIndex = 2
        Me.MultiGauge2.value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.MultiGauge2.WarningThreshold = 80
        '
        'MultiGauge1
        '
        Me.MultiGauge1.isLedVisible = True
        Me.MultiGauge1.Location = New System.Drawing.Point(168, 13)
        Me.MultiGauge1.maximum = 100
        Me.MultiGauge1.minimum = 0
        Me.MultiGauge1.Name = "MultiGauge1"
        Me.MultiGauge1.Size = New System.Drawing.Size(64, 64)
        Me.MultiGauge1.TabIndex = 1
        Me.MultiGauge1.value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.MultiGauge1.WarningThreshold = 80
        '
        'MultiAmmVoltmeter1
        '
        Me.MultiAmmVoltmeter1.Font = New System.Drawing.Font("Segoe UI Semilight", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MultiAmmVoltmeter1.Location = New System.Drawing.Point(12, 13)
        Me.MultiAmmVoltmeter1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MultiAmmVoltmeter1.maximum = 400
        Me.MultiAmmVoltmeter1.minimum = 0
        Me.MultiAmmVoltmeter1.Name = "MultiAmmVoltmeter1"
        Me.MultiAmmVoltmeter1.Size = New System.Drawing.Size(150, 150)
        Me.MultiAmmVoltmeter1.TabIndex = 0
        Me.MultiAmmVoltmeter1.units = "V"
        Me.MultiAmmVoltmeter1.value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'MultiGenPointCalendarClock1
        '
        Me.MultiGenPointCalendarClock1.Location = New System.Drawing.Point(362, 13)
        Me.MultiGenPointCalendarClock1.Name = "MultiGenPointCalendarClock1"
        Me.MultiGenPointCalendarClock1.Settings = New Integer() {0, 0, 0, 0, 0, 0}
        Me.MultiGenPointCalendarClock1.Size = New System.Drawing.Size(96, 96)
        Me.MultiGenPointCalendarClock1.TabIndex = 14
        '
        'MultiTrimmerKnob2
        '
        Me.MultiTrimmerKnob2.Location = New System.Drawing.Point(256, 99)
        Me.MultiTrimmerKnob2.maximum = 400
        Me.MultiTrimmerKnob2.minimum = 0
        Me.MultiTrimmerKnob2.Name = "MultiTrimmerKnob2"
        Me.MultiTrimmerKnob2.Size = New System.Drawing.Size(64, 64)
        Me.MultiTrimmerKnob2.TabIndex = 13
        Me.MultiTrimmerKnob2.value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(301, 322)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Pompe"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 362)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MultiGenPointCalendarClock1)
        Me.Controls.Add(Me.MultiTrimmerKnob2)
        Me.Controls.Add(Me.MultiTrimmerKnob1)
        Me.Controls.Add(Me.MultiPanelSwitch2)
        Me.Controls.Add(Me.MultiLinearMeter1)
        Me.Controls.Add(Me.MultiVerticalMeter1)
        Me.Controls.Add(Me.MultiPanelSwitch1)
        Me.Controls.Add(Me.MultiPanelSemaphor3)
        Me.Controls.Add(Me.MultiPanelSemaphor2)
        Me.Controls.Add(Me.MultiPanelSemaphor1)
        Me.Controls.Add(Me.MultiGauge2)
        Me.Controls.Add(Me.MultiGauge1)
        Me.Controls.Add(Me.MultiAmmVoltmeter1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MultiAmmVoltmeter1 As MultiLibrary.MultiAmmVoltmeter
    Friend WithEvents MultiGauge1 As MultiLibrary.MultiGauge
    Friend WithEvents MultiGauge2 As MultiLibrary.MultiGauge
    Friend WithEvents MultiPanelSemaphor1 As MultiLibrary.MultiPanelSemaphor
    Friend WithEvents MultiPanelSemaphor2 As MultiLibrary.MultiPanelSemaphor
    Friend WithEvents MultiPanelSemaphor3 As MultiLibrary.MultiPanelSemaphor
    Friend WithEvents MultiPanelSwitch1 As MultiLibrary.MultiPanelSwitch
    Friend WithEvents MultiVerticalMeter1 As MultiLibrary.MultiVerticalMeter
    Friend WithEvents MultiLinearMeter1 As MultiLibrary.MultiLinearMeter
    Friend WithEvents MultiPanelSwitch2 As MultiLibrary.MultiPanelSwitch
    Friend WithEvents MultiTrimmerKnob1 As MultiLibrary.MultiTrimmerKnob
    Friend WithEvents MultiGenPointCalendarClock1 As MultiLibrary.MultiGenPointCalendarClock
    Friend WithEvents MultiTrimmerKnob2 As MultiLibrary.MultiTrimmerKnob
    Friend WithEvents Button1 As Button
End Class
