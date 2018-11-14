<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MultiGenPoint3TemperatureWeeklyStrip
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
        Me.lblClockHH = New System.Windows.Forms.Label()
        Me.lblTemperature = New System.Windows.Forms.Label()
        Me.lblDay = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblWSPtemperature = New System.Windows.Forms.Label()
        Me.pbCoolON = New System.Windows.Forms.PictureBox()
        Me.pbHeatON = New System.Windows.Forms.PictureBox()
        Me.pbCool = New System.Windows.Forms.PictureBox()
        Me.pbEco = New System.Windows.Forms.PictureBox()
        Me.pbManual = New System.Windows.Forms.PictureBox()
        Me.pbHeat = New System.Windows.Forms.PictureBox()
        CType(Me.pbCoolON, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbHeatON, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbCool, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbManual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbHeat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblClockHH
        '
        Me.lblClockHH.Font = New System.Drawing.Font("Digital-7", 42.0!)
        Me.lblClockHH.Location = New System.Drawing.Point(135, 30)
        Me.lblClockHH.Margin = New System.Windows.Forms.Padding(0)
        Me.lblClockHH.Name = "lblClockHH"
        Me.lblClockHH.Size = New System.Drawing.Size(142, 55)
        Me.lblClockHH.TabIndex = 0
        Me.lblClockHH.Text = "22:22"
        Me.lblClockHH.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTemperature
        '
        Me.lblTemperature.Font = New System.Drawing.Font("Digital-7", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTemperature.Location = New System.Drawing.Point(39, 37)
        Me.lblTemperature.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTemperature.Name = "lblTemperature"
        Me.lblTemperature.Size = New System.Drawing.Size(99, 26)
        Me.lblTemperature.TabIndex = 0
        Me.lblTemperature.Text = "20,0°c"
        Me.lblTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDay
        '
        Me.lblDay.Font = New System.Drawing.Font("Digital-7 Mono", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDay.Location = New System.Drawing.Point(3, 6)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(43, 20)
        Me.lblDay.TabIndex = 2
        Me.lblDay.Text = "MMM"
        '
        'lblDate
        '
        Me.lblDate.Font = New System.Drawing.Font("Digital-7 Mono", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(36, 6)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(81, 20)
        Me.lblDate.TabIndex = 0
        Me.lblDate.Text = "88/88/88"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWSPtemperature
        '
        Me.lblWSPtemperature.Font = New System.Drawing.Font("Digital-7", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWSPtemperature.Location = New System.Drawing.Point(28, 69)
        Me.lblWSPtemperature.Margin = New System.Windows.Forms.Padding(0)
        Me.lblWSPtemperature.Name = "lblWSPtemperature"
        Me.lblWSPtemperature.Size = New System.Drawing.Size(103, 20)
        Me.lblWSPtemperature.TabIndex = 0
        Me.lblWSPtemperature.Text = "Setp:  20,0°c"
        Me.lblWSPtemperature.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbCoolON
        '
        Me.pbCoolON.Image = Global.MultiLibrary.My.Resources.Resources.black_dot_transparent_back
        Me.pbCoolON.Location = New System.Drawing.Point(265, 3)
        Me.pbCoolON.Name = "pbCoolON"
        Me.pbCoolON.Size = New System.Drawing.Size(8, 8)
        Me.pbCoolON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbCoolON.TabIndex = 3
        Me.pbCoolON.TabStop = False
        Me.pbCoolON.Visible = False
        '
        'pbHeatON
        '
        Me.pbHeatON.Image = Global.MultiLibrary.My.Resources.Resources.black_dot_transparent_back
        Me.pbHeatON.Location = New System.Drawing.Point(232, 3)
        Me.pbHeatON.Name = "pbHeatON"
        Me.pbHeatON.Size = New System.Drawing.Size(8, 8)
        Me.pbHeatON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbHeatON.TabIndex = 3
        Me.pbHeatON.TabStop = False
        Me.pbHeatON.Visible = False
        '
        'pbCool
        '
        Me.pbCool.Image = Global.MultiLibrary.My.Resources.Resources.if_snowflake_alt2_372618
        Me.pbCool.Location = New System.Drawing.Point(249, 3)
        Me.pbCool.Name = "pbCool"
        Me.pbCool.Size = New System.Drawing.Size(16, 16)
        Me.pbCool.TabIndex = 1
        Me.pbCool.TabStop = False
        '
        'pbEco
        '
        Me.pbEco.Image = Global.MultiLibrary.My.Resources.Resources.if_coda_eco_ecology_environment_flower_green_leaf_nature_paper_plant_392515_1_
        Me.pbEco.Location = New System.Drawing.Point(163, 3)
        Me.pbEco.Name = "pbEco"
        Me.pbEco.Size = New System.Drawing.Size(16, 16)
        Me.pbEco.TabIndex = 1
        Me.pbEco.TabStop = False
        '
        'pbManual
        '
        Me.pbManual.Image = Global.MultiLibrary.My.Resources.Resources.if_icon_3_high_five_329409
        Me.pbManual.Location = New System.Drawing.Point(180, 3)
        Me.pbManual.Name = "pbManual"
        Me.pbManual.Size = New System.Drawing.Size(16, 16)
        Me.pbManual.TabIndex = 1
        Me.pbManual.TabStop = False
        '
        'pbHeat
        '
        Me.pbHeat.Image = Global.MultiLibrary.My.Resources.Resources.if_sun_226556
        Me.pbHeat.Location = New System.Drawing.Point(216, 3)
        Me.pbHeat.Name = "pbHeat"
        Me.pbHeat.Size = New System.Drawing.Size(16, 16)
        Me.pbHeat.TabIndex = 1
        Me.pbHeat.TabStop = False
        '
        'MultiGenPoint3TemperatureWeeklyStrip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblDay)
        Me.Controls.Add(Me.pbCoolON)
        Me.Controls.Add(Me.pbHeatON)
        Me.Controls.Add(Me.pbCool)
        Me.Controls.Add(Me.pbEco)
        Me.Controls.Add(Me.pbManual)
        Me.Controls.Add(Me.pbHeat)
        Me.Controls.Add(Me.lblWSPtemperature)
        Me.Controls.Add(Me.lblTemperature)
        Me.Controls.Add(Me.lblClockHH)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Name = "MultiGenPoint3TemperatureWeeklyStrip"
        Me.Size = New System.Drawing.Size(294, 130)
        CType(Me.pbCoolON, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbHeatON, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbCool, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbManual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbHeat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblClockHH As Label
    Friend WithEvents lblTemperature As Label
    Friend WithEvents pbHeat As PictureBox
    Friend WithEvents pbCool As PictureBox
    Friend WithEvents lblDay As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents pbManual As PictureBox
    Friend WithEvents pbEco As PictureBox
    Friend WithEvents lblWSPtemperature As Label
    Friend WithEvents pbHeatON As PictureBox
    Friend WithEvents pbCoolON As PictureBox
End Class