Public Class MultiGenPointCalendarClock
    Dim pbBoxes As PictureBox() = New PictureBox(287) {}
    Dim pi As Double = Math.PI
    Dim apen As New Pen(Color.LightGray, 1)
    Dim bpen As New Pen(Color.Gray, 1)
    Dim cpen As New Pen(Color.Black, 1)
    Dim lpen As New Pen(Color.Black, 10)
    Dim tpen As New Pen(Color.Transparent, 2)
    Dim radius As Integer = 60
    Dim x1, y1, x2, y2 As Integer
    Dim centreX As Double = 64
    Dim centreY As Double = 64
    Private m_settings As Integer()

    Private Sub MePaint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        e.Graphics.DrawEllipse(cpen, 2, 2, 124, 124)
        e.Graphics.DrawEllipse(cpen, 12, 12, 104, 104)
        Dim i As Double = 6
        For num = 0 To 2 * pi Step pi / 24
            x1 = Convert.ToInt32(radius * Math.Cos(num) + centreX)
            y1 = Convert.ToInt32(radius * Math.Sin(num) + centreY)
            x2 = Convert.ToInt32(7 / 8 * radius * Math.Cos(num) + centreX)
            y2 = Convert.ToInt32(7 / 8 * radius * Math.Sin(num) + centreY)

            e.Graphics.DrawLine(apen, x1, y1, x2, y2)

            If i Mod 2 = 0 Then
                Dim lbl As New Label
                With lbl
                    .Text = i.ToString.PadLeft(2, "0")
                    .Location = New Point(Convert.ToInt32(28 / 40 * radius * Math.Cos(num) + centreX - 5), Convert.ToInt32(28 / 40 * radius * Math.Sin(num) + centreY - 5))
                    .Visible = True
                    .Size = New Size(10, 10)
                    .Font = New Font("Segoe UI", 5, FontStyle.Regular)
                    .Name = "lbl" & i.ToString.PadLeft(2, "0")
                    .TextAlign = ContentAlignment.MiddleCenter
                End With
                Me.Controls.Add(lbl)
            End If
            If i = 24 Then i = 0
            i += 0.5
        Next

        'For i = 2 To 23 Step 2
        '        Dim lbl As New Label
        '        With lbl
        '            .Text = i.ToString.PadLeft(2, "0")
        '            .Location = New Point(12 * (i - 1) + 7, 2)
        '            .Visible = True
        '            .Size = New Size(18, 10)
        '            .Font = New Font("Segoe UI", 5, FontStyle.Regular)
        '            .Name = "lbl" & i.ToString.PadLeft(2, "0")
        '        End With
        '        Me.Controls.Add(lbl)
        '    Next
        '    e.Graphics.DrawLine(lpen, Settings(0), 25, Settings(1), 25)
        '    e.Graphics.DrawLine(lpen, Settings(2), 25, Settings(3), 25)
        '    e.Graphics.DrawLine(lpen, Settings(4), 25, Settings(5), 25)



    End Sub
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
