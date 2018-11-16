Imports System.Configuration
Public Class MultiGenPointCalendarClock
    Dim WithEvents clock As New Timers.Timer
    Dim pi As Double = Math.PI
    Dim apen As New Pen(Color.LightGray, 1)
    Dim b1pen As New Pen(Color.Red, 4)
    Dim b2pen As New Pen(Color.LightGray, 1)
    Dim b3pen As New Pen(Color.Blue, 4)
    Dim cpen As New Pen(Color.Black, 1)
    Dim radius As Integer = 44
    Dim x1, y1, x2, y2, x, y As Integer
    Dim centreX As Double = 48
    Dim centreY As Double = 48
    Private m_settings As Integer()
    Public Property isOn As Boolean
    Public AppSettings As System.Configuration.SettingsBase

    'Private user_settings As System.Configuration.ApplicationSettingsBase
    'Public Property AppSettings() As System.Configuration.ApplicationSettingsBase
    '    Get
    '        Return user_settings
    '    End Get
    '    Set(ByVal value As System.Configuration.ApplicationSettingsBase)
    '        user_settings = value
    '    End Set
    'End Property
    Private Sub pbCalendarClockSettings_Click(sender As Object, e As EventArgs) Handles pbCalendarClockSettings.Click
        Dim myform As New frmCalendarClockSettings
        myform.StartPosition = FormStartPosition.Manual
        myform.Location = New Point(Me.Location.X + Me.Size.Width, Me.Location.Y)
        myform.Settings = Settings


        myform.ShowDialog()


        If myform.DialogResult = DialogResult.OK Then
            Settings = myform.Settings

            AppSettings("MGPCCSettings0") = Settings(0)
            AppSettings("MGPCCSettings1") = Settings(1)
            AppSettings("MGPCCSettings2") = Settings(2)
            AppSettings("MGPCCSettings3") = Settings(3)
            AppSettings("MGPCCSettings4") = Settings(4)
            AppSettings("MGPCCSettings5") = Settings(5)
            AppSettings.Save()


            Me.Refresh()
        End If
    End Sub

    Private Sub MePaint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        e.Graphics.DrawEllipse(cpen, 2, 2, 92, 92)
        e.Graphics.DrawEllipse(cpen, 12, 12, 72, 72)
        Dim i As Double = 6
        For num = 0 To 2 * pi Step pi / 24
            x1 = Convert.ToInt32(radius * Math.Cos(num) + centreX)
            y1 = Convert.ToInt32(radius * Math.Sin(num) + centreY)
            x2 = Convert.ToInt32(7 / 8 * radius * Math.Cos(num) + centreX)
            y2 = Convert.ToInt32(7 / 8 * radius * Math.Sin(num) + centreY)

            e.Graphics.DrawLine(apen, x1, y1, x2, y2)

            If i Mod 2 = 0 Then
                If i = 24 Then i = 0
                Dim lbl As New Label
                With lbl
                    .Text = i.ToString.PadLeft(2, "0")
                    .Location = New Point(Convert.ToInt32(26 / 40 * radius * Math.Cos(num) + centreX - 5), Convert.ToInt32(26 / 40 * radius * Math.Sin(num) + centreY - 5))
                    .Visible = True
                    .Size = New Size(11, 10)
                    .Font = New Font("Segoe UI", 4, FontStyle.Regular)
                    .Name = "lbl" & i.ToString.PadLeft(2, "0")
                    .TextAlign = ContentAlignment.MiddleCenter
                End With
                Me.Controls.Add(lbl)
            End If
            i += 0.5
        Next

        If Settings(0) <> Settings(1) Then
            For i = Stepping(Settings(0)) To Stepping(Settings(1)) Step pi / 288
                x1 = Convert.ToInt32(radius * Math.Cos(i) + centreX)
                y1 = Convert.ToInt32(radius * Math.Sin(i) + centreY)
                x2 = Convert.ToInt32(7 / 8 * radius * Math.Cos(i) + centreX)
                y2 = Convert.ToInt32(7 / 8 * radius * Math.Sin(i) + centreY)

                If i = Stepping(Settings(0)) Then
                    e.Graphics.DrawLine(b1pen, x1, y1, x2, y2)
                    i += pi / 72
                Else e.Graphics.DrawLine(b2pen, x1, y1, x2, y2)
                End If
            Next
            e.Graphics.DrawLine(b3pen, x1, y1, x2, y2)

        End If

        If Settings(2) <> Settings(3) Then
            For i = Stepping(Settings(2)) To Stepping(Settings(3)) Step pi / 288
                x1 = Convert.ToInt32(radius * Math.Cos(i) + centreX)
                y1 = Convert.ToInt32(radius * Math.Sin(i) + centreY)
                x2 = Convert.ToInt32(7 / 8 * radius * Math.Cos(i) + centreX)
                y2 = Convert.ToInt32(7 / 8 * radius * Math.Sin(i) + centreY)

                If i = Stepping(Settings(2)) Then
                    e.Graphics.DrawLine(b1pen, x1, y1, x2, y2)
                    i += pi / 72
                Else e.Graphics.DrawLine(b2pen, x1, y1, x2, y2)
                End If
            Next
            e.Graphics.DrawLine(b3pen, x1, y1, x2, y2)

        End If

        If Settings(4) <> Settings(5) Then
            For i = Stepping(Settings(4)) To Stepping(Settings(5)) Step pi / 288
                x1 = Convert.ToInt32(radius * Math.Cos(i) + centreX)
                y1 = Convert.ToInt32(radius * Math.Sin(i) + centreY)
                x2 = Convert.ToInt32(7 / 8 * radius * Math.Cos(i) + centreX)
                y2 = Convert.ToInt32(7 / 8 * radius * Math.Sin(i) + centreY)

                If i = Stepping(Settings(4)) Then
                    e.Graphics.DrawLine(b1pen, x1, y1, x2, y2)
                    i += pi / 72
                Else e.Graphics.DrawLine(b2pen, x1, y1, x2, y2)
                End If
            Next
            e.Graphics.DrawLine(b3pen, x1, y1, x2, y2)

        End If

    End Sub
    Private Function Stepping(ByVal setting As Integer) As Double
        Return setting * pi / 144 - pi / 2
    End Function
    Public Sub New()
        InitializeComponent()

        AppSettings = My.Settings

        Settings = {AppSettings("MGPCCSettings0"),
            AppSettings("MGPCCSettings1"),
            AppSettings("MGPCCSettings2"),
            AppSettings("MGPCCSettings3"),
            AppSettings("MGPCCSettings4"),
            AppSettings("MGPCCSettings5")}



    End Sub
    Public Property Settings As Integer()
        Get
            Settings = m_settings
        End Get
        Set(Settings As Integer())
            If Settings.Count = 6 Then
                Array.Sort(Settings)
                m_settings = Settings
                Me.Refresh()
            End If
        End Set
    End Property

    Private Sub MultiGenPointCalendarClock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With clock
            .Enabled = True
            .Interval = 666
            .AutoReset = True
            .Start()
        End With
    End Sub

    Private Sub clock_tick() Handles clock.Elapsed
        blinkingDot()
    End Sub
    Private Delegate Sub blinkingDotDelegate()
    Private Sub blinkingDot()

        If Me.InvokeRequired Then
            Dim d As New blinkingDotDelegate(AddressOf Me.blinkingDot)
            Me.BeginInvoke(d)
        Else
            Dim f = (DateTime.Now.Hour * 12 + DateTime.Now.Minute \ 5)
            Dim i = f * 2 * pi / 288 - pi / 2
            x = Convert.ToInt32(1 / 2 * radius * Math.Cos(i) + centreX)
            y = Convert.ToInt32(1 / 2 * radius * Math.Sin(i) + centreY)
            If (f >= Settings(0) And f <= Settings(1)) Or
                (f >= Settings(2) And f <= Settings(3)) Or
                (f >= Settings(4) And f <= Settings(5)) Then
                pbLed.Image = My.Resources.ledgreen
                isOn = True
            Else
                pbLed.Image = My.Resources.ledoff
                isOn = False
            End If
            If Me.Controls.Find("pbDot", True).Length = 0 Then
                Dim pbDot As New PictureBox
                With pbDot
                    .Location = New Point(x, y)
                    .Size = New Size(2, 2)
                    .BackColor = Color.Black
                    .Name = "pbDot"
                End With
                Me.Controls.Add(pbDot)
            Else
                If Me.Controls.Find("pbDot", True)(0).BackColor = Color.Black Then
                    Me.Controls.Find("pbDot", True)(0).BackColor = Me.BackColor
                Else
                    Me.Controls.Find("pbDot", True)(0).BackColor = Color.Black
                End If
            End If
        End If
    End Sub
End Class


