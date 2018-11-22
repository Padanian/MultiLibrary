<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalendarClockSettings
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.dtpF1Start = New System.Windows.Forms.DateTimePicker()
        Me.dtpF1Stop = New System.Windows.Forms.DateTimePicker()
        Me.dtpF2Start = New System.Windows.Forms.DateTimePicker()
        Me.dtpF2Stop = New System.Windows.Forms.DateTimePicker()
        Me.dtpF3Start = New System.Windows.Forms.DateTimePicker()
        Me.dtpF3Stop = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkF2 = New System.Windows.Forms.CheckBox()
        Me.chkF3 = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(66, 170)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'dtpF1Start
        '
        Me.dtpF1Start.CustomFormat = "HH:mm"
        Me.dtpF1Start.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpF1Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpF1Start.Location = New System.Drawing.Point(39, 34)
        Me.dtpF1Start.Name = "dtpF1Start"
        Me.dtpF1Start.ShowUpDown = True
        Me.dtpF1Start.Size = New System.Drawing.Size(65, 29)
        Me.dtpF1Start.TabIndex = 1
        Me.dtpF1Start.Value = New Date(2018, 11, 15, 0, 0, 0, 0)
        '
        'dtpF1Stop
        '
        Me.dtpF1Stop.CustomFormat = "HH:mm"
        Me.dtpF1Stop.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpF1Stop.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpF1Stop.Location = New System.Drawing.Point(112, 34)
        Me.dtpF1Stop.Name = "dtpF1Stop"
        Me.dtpF1Stop.ShowUpDown = True
        Me.dtpF1Stop.Size = New System.Drawing.Size(65, 29)
        Me.dtpF1Stop.TabIndex = 1
        Me.dtpF1Stop.Value = New Date(2018, 11, 15, 0, 0, 0, 0)
        '
        'dtpF2Start
        '
        Me.dtpF2Start.CustomFormat = "HH:mm"
        Me.dtpF2Start.Enabled = False
        Me.dtpF2Start.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpF2Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpF2Start.Location = New System.Drawing.Point(39, 78)
        Me.dtpF2Start.Name = "dtpF2Start"
        Me.dtpF2Start.ShowUpDown = True
        Me.dtpF2Start.Size = New System.Drawing.Size(65, 29)
        Me.dtpF2Start.TabIndex = 1
        Me.dtpF2Start.Value = New Date(2018, 11, 15, 0, 0, 0, 0)
        '
        'dtpF2Stop
        '
        Me.dtpF2Stop.CustomFormat = "HH:mm"
        Me.dtpF2Stop.Enabled = False
        Me.dtpF2Stop.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpF2Stop.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpF2Stop.Location = New System.Drawing.Point(112, 78)
        Me.dtpF2Stop.Name = "dtpF2Stop"
        Me.dtpF2Stop.ShowUpDown = True
        Me.dtpF2Stop.Size = New System.Drawing.Size(65, 29)
        Me.dtpF2Stop.TabIndex = 1
        Me.dtpF2Stop.Value = New Date(2018, 11, 15, 0, 0, 0, 0)
        '
        'dtpF3Start
        '
        Me.dtpF3Start.CustomFormat = "HH:mm"
        Me.dtpF3Start.Enabled = False
        Me.dtpF3Start.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpF3Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpF3Start.Location = New System.Drawing.Point(39, 122)
        Me.dtpF3Start.Name = "dtpF3Start"
        Me.dtpF3Start.ShowUpDown = True
        Me.dtpF3Start.Size = New System.Drawing.Size(65, 29)
        Me.dtpF3Start.TabIndex = 1
        Me.dtpF3Start.Value = New Date(2018, 11, 15, 0, 0, 0, 0)
        '
        'dtpF3Stop
        '
        Me.dtpF3Stop.CustomFormat = "HH:mm"
        Me.dtpF3Stop.Enabled = False
        Me.dtpF3Stop.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpF3Stop.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpF3Stop.Location = New System.Drawing.Point(112, 122)
        Me.dtpF3Stop.Name = "dtpF3Stop"
        Me.dtpF3Stop.ShowUpDown = True
        Me.dtpF3Stop.Size = New System.Drawing.Size(65, 29)
        Me.dtpF3Stop.TabIndex = 1
        Me.dtpF3Stop.Value = New Date(2018, 11, 15, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "F1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(14, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "F2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(14, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "F3"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(50, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Start"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(126, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Stop"
        '
        'chkF2
        '
        Me.chkF2.AutoSize = True
        Me.chkF2.Location = New System.Drawing.Point(185, 86)
        Me.chkF2.Name = "chkF2"
        Me.chkF2.Size = New System.Drawing.Size(15, 14)
        Me.chkF2.TabIndex = 3
        Me.chkF2.UseVisualStyleBackColor = True
        '
        'chkF3
        '
        Me.chkF3.AutoSize = True
        Me.chkF3.Location = New System.Drawing.Point(185, 130)
        Me.chkF3.Name = "chkF3"
        Me.chkF3.Size = New System.Drawing.Size(15, 14)
        Me.chkF3.TabIndex = 3
        Me.chkF3.UseVisualStyleBackColor = True
        '
        'frmCalendarClockSettings
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(224, 211)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkF3)
        Me.Controls.Add(Me.chkF2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpF3Stop)
        Me.Controls.Add(Me.dtpF3Start)
        Me.Controls.Add(Me.dtpF2Stop)
        Me.Controls.Add(Me.dtpF2Start)
        Me.Controls.Add(Me.dtpF1Stop)
        Me.Controls.Add(Me.dtpF1Start)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCalendarClockSettings"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents dtpF1Start As DateTimePicker
    Friend WithEvents dtpF1Stop As DateTimePicker
    Friend WithEvents dtpF2Start As DateTimePicker
    Friend WithEvents dtpF2Stop As DateTimePicker
    Friend WithEvents dtpF3Start As DateTimePicker
    Friend WithEvents dtpF3Stop As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents chkF2 As CheckBox
    Friend WithEvents chkF3 As CheckBox
End Class
