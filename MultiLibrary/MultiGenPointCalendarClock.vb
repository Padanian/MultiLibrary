Public Class MultiGenPointCalendarClock
    Dim pbBoxes As PictureBox() = New PictureBox(287) {}
    Dim pi As Double = Math.PI
    Dim apen As New Pen(Color.LightGray, 1)
    Dim bpen As New Pen(Color.Black, 2)
    Dim cpen As New Pen(Color.Black, 1)
    Dim lpen As New Pen(Color.Black, 10)
    Dim tpen As New Pen(Color.Transparent, 2)
    Dim radius As Integer = 44
    Dim x1, y1, x2, y2 As Integer
    Dim centreX As Double = 48
    Dim centreY As Double = 48
    Private m_settings As Integer()

    Private Sub pbCalendarClockSettings_Click(sender As Object, e As EventArgs) Handles pbCalendarClockSettings.Click
        Dim myform As New frmCalendarClockSettings
        myform.ShowDialog()
        If myform.DialogResult = DialogResult.OK Then
            Settings = myform.Settings
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
                    .Size = New Size(10, 10)
                    .Font = New Font("Segoe UI", 5, FontStyle.Regular)
                    .Name = "lbl" & i.ToString.PadLeft(2, "0")
                    .TextAlign = ContentAlignment.MiddleCenter
                End With
                Me.Controls.Add(lbl)
            End If
            i += 0.5
        Next

        For i = Stepping(Settings(0)) To Stepping(Settings(1)) Step pi / 288
            x1 = Convert.ToInt32(radius * Math.Cos(i) + centreX)
            y1 = Convert.ToInt32(radius * Math.Sin(i) + centreY)
            x2 = Convert.ToInt32(7 / 8 * radius * Math.Cos(i) + centreX)
            y2 = Convert.ToInt32(7 / 8 * radius * Math.Sin(i) + centreY)

            e.Graphics.DrawLine(cpen, x1, y1, x2, y2)
        Next
        For i = Stepping(Settings(2)) To Stepping(Settings(3)) Step pi / 288
            x1 = Convert.ToInt32(radius * Math.Cos(i) + centreX)
            y1 = Convert.ToInt32(radius * Math.Sin(i) + centreY)
            x2 = Convert.ToInt32(7 / 8 * radius * Math.Cos(i) + centreX)
            y2 = Convert.ToInt32(7 / 8 * radius * Math.Sin(i) + centreY)

            e.Graphics.DrawLine(cpen, x1, y1, x2, y2)
        Next
        For i = Stepping(Settings(4)) To Stepping(Settings(5)) Step pi / 288
            x1 = Convert.ToInt32(radius * Math.Cos(i) + centreX)
            y1 = Convert.ToInt32(radius * Math.Sin(i) + centreY)
            x2 = Convert.ToInt32(7 / 8 * radius * Math.Cos(i) + centreX)
            y2 = Convert.ToInt32(7 / 8 * radius * Math.Sin(i) + centreY)

            e.Graphics.DrawLine(cpen, x1, y1, x2, y2)
        Next

    End Sub
    Private Function Stepping(ByVal setting As Integer) As Double
        Return setting * pi / 144 - pi / 2
    End Function
    Public Sub New()
            InitializeComponent()
            Settings = {0, 0, 0, 0, 0, 0}
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

End Class
