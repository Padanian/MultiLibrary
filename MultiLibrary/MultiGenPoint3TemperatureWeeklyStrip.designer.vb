﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.lblClock = New System.Windows.Forms.Label()
        Me.lblTemperature = New System.Windows.Forms.Label()
        Me.lblDay = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.pbCool = New System.Windows.Forms.PictureBox()
        Me.pbEco = New System.Windows.Forms.PictureBox()
        Me.pbManual = New System.Windows.Forms.PictureBox()
        Me.pbHeat = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblWSPtemperature = New System.Windows.Forms.Label()
        CType(Me.pbCool, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbManual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbHeat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblClock
        '
        Me.lblClock.Font = New System.Drawing.Font("Digital-7 Mono", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClock.Location = New System.Drawing.Point(137, 28)
        Me.lblClock.Name = "lblClock"
        Me.lblClock.Size = New System.Drawing.Size(136, 47)
        Me.lblClock.TabIndex = 0
        Me.lblClock.Text = "22:22"
        Me.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTemperature
        '
        Me.lblTemperature.Font = New System.Drawing.Font("Digital-7", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTemperature.Location = New System.Drawing.Point(34, 23)
        Me.lblTemperature.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTemperature.Name = "lblTemperature"
        Me.lblTemperature.Size = New System.Drawing.Size(99, 34)
        Me.lblTemperature.TabIndex = 0
        Me.lblTemperature.Text = "12.3°c"
        Me.lblTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDay
        '
        Me.lblDay.AutoSize = True
        Me.lblDay.Location = New System.Drawing.Point(29, 6)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(13, 13)
        Me.lblDay.TabIndex = 2
        Me.lblDay.Text = "1"
        '
        'lblDate
        '
        Me.lblDate.Font = New System.Drawing.Font("Digital-7", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(176, 76)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(81, 20)
        Me.lblDate.TabIndex = 0
        Me.lblDate.Text = "88/88/88"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbCool
        '
        Me.pbCool.Image = Global.MultiLibrary.My.Resources.Resources.if_snowflake_alt2_372618
        Me.pbCool.Location = New System.Drawing.Point(234, 3)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Day"
        '
        'lblWSPtemperature
        '
        Me.lblWSPtemperature.Font = New System.Drawing.Font("Digital-7", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWSPtemperature.Location = New System.Drawing.Point(30, 57)
        Me.lblWSPtemperature.Margin = New System.Windows.Forms.Padding(0)
        Me.lblWSPtemperature.Name = "lblWSPtemperature"
        Me.lblWSPtemperature.Size = New System.Drawing.Size(103, 34)
        Me.lblWSPtemperature.TabIndex = 0
        Me.lblWSPtemperature.Text = "Setp:  88.8°c"
        Me.lblWSPtemperature.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MultiGenPoint3TemperatureWeeklyStrip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblDay)
        Me.Controls.Add(Me.pbCool)
        Me.Controls.Add(Me.pbEco)
        Me.Controls.Add(Me.pbManual)
        Me.Controls.Add(Me.pbHeat)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblWSPtemperature)
        Me.Controls.Add(Me.lblTemperature)
        Me.Controls.Add(Me.lblClock)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Name = "MultiGenPoint3TemperatureWeeklyStrip"
        Me.Size = New System.Drawing.Size(294, 130)
        CType(Me.pbCool, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbManual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbHeat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblClock As Label
    Friend WithEvents lblTemperature As Label
    Friend WithEvents pbHeat As PictureBox
    Friend WithEvents pbCool As PictureBox
    Friend WithEvents lblDay As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents pbManual As PictureBox
    Friend WithEvents pbEco As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblWSPtemperature As Label
End Class