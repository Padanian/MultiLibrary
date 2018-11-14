Imports System.Globalization
Imports System.IO
Imports System.Threading

Public Class MultiGenPoint3TemperatureWeeklyStrip
    Dim WithEvents clock As New Timers.Timer
    Dim WithEvents determinaWSP As New Timers.Timer
    Private m_temperature As Decimal
    Private m_isHeating As Boolean
    Private m_isCooling As Boolean
    Private m_isManual As Boolean
    Private m_isOff As Boolean
    Private m_isEco As Boolean
    Public Shared UpdateRequest As Boolean = True
    Private m_WorkingSetpoint As Decimal
    Private myWeeklySchedule As New weeklyScheduler
    Private myWeeklyScheduleManualSave As New weeklyScheduler
    Private Event eventoManualeAttivato()
    Private Event eventoManualeDisattivato()
    Private Event temperatureChanged()
    Public Property isHeating As Boolean
        Get
            isHeating = m_isHeating
        End Get
        Set(isHeating As Boolean)
            If Not m_isOff Then
                pbHeat.Visible = isHeating
                m_isHeating = isHeating
                pbCool.Visible = Not isHeating
                pbCoolON.Visible = Not isHeating
                m_isCooling = Not isHeating
                UpdateRequest = True
            End If
        End Set
    End Property
    Public Property isCooling As Boolean
        Get
            isCooling = m_isCooling
        End Get
        Set(isCooling As Boolean)
            If Not m_isOff Then
                pbCool.Visible = isCooling
                m_isCooling = isCooling
                pbHeat.Visible = Not isCooling
                pbHeatON.Visible = Not isCooling
                m_isHeating = Not isCooling
                UpdateRequest = True
            End If
        End Set
    End Property
    Public Property isManual As Boolean
        Get
            isManual = m_isManual
        End Get
        Set(isManual As Boolean)
            If Not m_isOff Then
                pbManual.Visible = isManual
                m_isManual = isManual
            End If
            If m_isManual Then
                myWeeklyScheduleManualSave = DeepClone(myWeeklySchedule)
                RaiseEvent eventoManualeAttivato()
            Else
                myWeeklySchedule = DeepClone(myWeeklyScheduleManualSave)
                RaiseEvent eventoManualeDisattivato()
            End If
        End Set
    End Property
    Public Property isEco As Boolean
        Get
            isEco = m_isEco
        End Get
        Set(isEco As Boolean)
            If Not m_isOff And Not m_isManual And Not ((m_WorkingSetpoint + myWeeklySchedule.ecoHeatReduction) <= myWeeklySchedule.freezeProtSetpoint) Then
                pbEco.Visible = isEco
                m_isEco = isEco
            Else
                m_isEco = False
            End If
        End Set
    End Property
    Public Property isOff As Boolean
        Get
            isOff = m_isOff
        End Get
        Set(isOff As Boolean)
            m_isOff = isOff
            If isOff = True Then
                clock.Enabled = False
                For Each ctl In Me.Controls
                    If Not ctl.name.contains("lblClock") Then
                        ctl.visible = False
                    Else
                        lblClockHH.Text = "OFF"
                    End If
                Next
            Else
                clock.Enabled = True
                For Each ctl In Me.Controls
                    ctl.visible = True
                    If ctl.name = pbCool.Name Then
                        ctl.visible = isCooling
                    ElseIf ctl.name = pbHeat.Name Then
                        ctl.visible = isHeating
                    ElseIf ctl.name = pbManual.Name Then
                        ctl.visible = isManual
                    ElseIf ctl.name = pbEco.Name Then
                        ctl.visible = isEco
                    End If
                    If TypeOf (ctl) Is Label And ctl.name.contains("lblDay") Then
                        If Not ctl.name.contains(DateTime.Now.DayOfWeek) Then
                            ctl.visible = False
                        End If
                    End If
                    clock_tick()
                Next
            End If
            Me.Refresh()
        End Set
    End Property
    Public Property temperature As Decimal
        Get
            temperature = m_temperature
        End Get
        Set(temperature As Decimal)
            lblTemperature.Text = (Format(temperature, "##0.0").ToString & "°c").Replace(",", ".")
            m_temperature = temperature
            RaiseEvent temperatureChanged()
        End Set
    End Property
    Public ReadOnly Property workingSetpoint As Decimal
        Get
            Return m_WorkingSetpoint
        End Get
    End Property

    Private Sub MultiGenPoint3TemperatureWeeklyStrip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateRequest = True
        Me.Refresh()
        AddHandler eventoManualeAttivato, AddressOf Me.visualizzazioneManuale
        AddHandler eventoManualeDisattivato, AddressOf Me.devisualizzazioneManuale
        AddHandler temperatureChanged, AddressOf Me.gestioneTemperatura
    End Sub
    Public Sub New()
        InitializeComponent()
        modificaClockText("")

#Region "Labels"
        Dim lbl04 As New Label
        With lbl04
            .Text = "04"
            .Location = New Point(12 * 3 + 6, 96)
            .Visible = True
            .Width = 20
            .Height = 12
        End With
        Me.Controls.Add(lbl04)
        Dim lbl08 As New Label
        With lbl08
            .Text = "08"
            .Location = New Point(12 * 7 + 6, 96)
            .Visible = True
            .Width = 20
            .Height = 12
        End With
        Me.Controls.Add(lbl08)
        Dim lbl12 As New Label
        With lbl12
            .Text = "12"
            .Location = New Point(12 * 11 + 6, 96)
            .Visible = True
            .Width = 20
            .Height = 12
        End With
        Me.Controls.Add(lbl12)
        Dim lbl16 As New Label
        With lbl16
            .Text = "16"
            .Location = New Point(12 * 15 + 6, 96)
            .Visible = True
            .Width = 20
            .Height = 12
        End With
        Me.Controls.Add(lbl16)
        Dim lbl20 As New Label
        With lbl20
            .Text = "20"
            .Location = New Point(12 * 19 + 6, 96)
            .Visible = True
            .Width = 20
            .Height = 12
        End With
        Me.Controls.Add(lbl20)
#End Region


        temperature = 20.0
        m_WorkingSetpoint = 20.0
        isHeating = True
        isCooling = False
        isManual = False
        isEco = False
        gestioneTemperatura()

        Dim originalCulture As CultureInfo = Thread.CurrentThread.CurrentCulture
        If DateTime.Now.DayOfWeek <> 0 Then
            lblDay.Text = WeekdayName(DateTime.Now.DayOfWeek, True)
        Else
            lblDay.Text = WeekdayName(DayOfWeek.Sunday + 7, True)
        End If
        Thread.CurrentThread.CurrentCulture = originalCulture


        AddHandler Me.Click, AddressOf pbSquares_Click

        If System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy" Then
            lblDate.Text = DateTime.Now.Month.ToString.PadLeft(2, "0") & "/" &
            DateTime.Now.Day.ToString.PadLeft(2, "0") & "/" &
            Strings.Right(DateTime.Now.Year.ToString, 2).PadLeft(2, "0")
        ElseIf System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy" Then
            lblDate.Text = DateTime.Now.Day.ToString.PadLeft(2, "0") & "/" &
                DateTime.Now.Month.ToString.PadLeft(2, "0") & "/" &
                Strings.Right(DateTime.Now.Year.ToString, 2).PadLeft(2, "0")
        End If

        If File.Exists(Path.GetTempPath & "default.mgp") Then
            Try
                Dim fStream As New FileStream(Path.GetTempPath & "default.mgp", FileMode.Open)
                Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
                Dim bftemp As weeklyScheduler = bf.Deserialize(fStream) ' read from file
                myWeeklySchedule = DeepClone(bftemp)

                If bftemp.manualSelectedIndex = 0 Then 'T3
                    myWeeklySchedule.manualSetpoint = {bftemp.setpointHeatT3, bftemp.setpointCoolT3}
                ElseIf bftemp.manualSelectedIndex = 1 Then 'T2
                    myWeeklySchedule.manualSetpoint = {bftemp.setpointHeatT2, bftemp.setpointCoolT2}
                ElseIf bftemp.manualSelectedIndex = 2 Then 'T1
                    myWeeklySchedule.manualSetpoint = {bftemp.setpointHeatT1, bftemp.setpointCoolT1}
                ElseIf bftemp.manualSelectedIndex = 3 Then 'Frost Prot.
                    myWeeklySchedule.manualSetpoint = {bftemp.freezeProtSetpoint, bftemp.freezeProtSetpoint}
                End If


                UpdateRequest = True

                fStream.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try
        End If

        With clock
            .Interval = 500
            .Enabled = True
            .AutoReset = True
            .Start()
        End With

    End Sub

    Private Sub clock_tick() Handles clock.Elapsed
        If DateTime.Now.Second Mod 2 = 0 Then
            modificaClockText(DateTime.Now.Hour.ToString.PadLeft(2, "0") & "." & DateTime.Now.Minute.ToString.PadLeft(2, "0"))
        Else
            modificaClockText(DateTime.Now.Hour.ToString.PadLeft(2, "0") & ":" & DateTime.Now.Minute.ToString.PadLeft(2, "0"))
        End If

        modificalblDays()

        Dim timingUpdate = 3600
#If DEBUG Then
        timingUpdate = 60
#End If

        If UpdateRequest Or DateTime.Now.Second Mod timingUpdate = 0 Then

            clock.Enabled = False

            If Me.Controls.Count < 144 Then

                Dim counter As Integer
                For i = 3 To 288 Step 6
                    Dim pbTickT1 As PictureBox = New PictureBox
                    Dim pbTickT2 As PictureBox = New PictureBox
                    Dim pbTickT3 As PictureBox = New PictureBox
                    With pbTickT3
                        .Width = 5
                        .Height = 5
                        .Location = New Point(.Location.X + i, .Location.Y + 110)
                        .Visible = True
                        .Name = "pbTickT3" & counter.ToString.PadLeft(2, "0")
                    End With
                    Me.BeginInvoke(Sub()
                                       Me.Controls.Add(pbTickT3)
                                   End Sub)
                    AddHandler pbTickT3.Click, AddressOf pbSquares_Click
                    With pbTickT2
                        .Width = 5
                        .Height = 5
                        .Location = New Point(.Location.X + i, .Location.Y + 116)
                        .Visible = True
                        .Name = "pbTickT2" & counter.ToString.PadLeft(2, "0")
                    End With
                    Me.BeginInvoke(Sub()
                                       Me.Controls.Add(pbTickT2)
                                   End Sub)
                    AddHandler pbTickT2.Click, AddressOf pbSquares_Click
                    With pbTickT1
                        .Width = 5
                        .Height = 5
                        .Location = New Point(.Location.X + i, .Location.Y + 122)
                        .Visible = True
                        .Name = "pbTickT1" & counter.ToString.PadLeft(2, "0")
                    End With
                    Me.BeginInvoke(Sub()
                                       Me.Controls.Add(pbTickT1)
                                   End Sub)
                    AddHandler pbTickT1.Click, AddressOf pbSquares_Click

                    If isHeating Then
                        If myWeeklySchedule.activeHeatTemp(DateTime.Now.DayOfWeek, counter) = 0 Then
                            pbTickT1.BackColor = Color.LightGray
                            pbTickT2.BackColor = Color.LightGray
                            pbTickT3.BackColor = Color.LightGray
                        ElseIf myWeeklySchedule.activeHeatTemp(DateTime.Now.DayOfWeek, counter) = 1 Then
                            pbTickT1.BackColor = Color.Black
                            pbTickT2.BackColor = Color.LightGray
                            pbTickT3.BackColor = Color.LightGray
                        ElseIf myWeeklySchedule.activeHeatTemp(DateTime.Now.DayOfWeek, counter) = 2 Then
                            pbTickT1.BackColor = Color.Black
                            pbTickT2.BackColor = Color.Black
                            pbTickT3.BackColor = Color.LightGray
                        ElseIf myWeeklySchedule.activeHeatTemp(DateTime.Now.DayOfWeek, counter) = 3 Then
                            pbTickT1.BackColor = Color.Black
                            pbTickT2.BackColor = Color.Black
                            pbTickT3.BackColor = Color.Black
                        End If
                    ElseIf isCooling Then
                        If myWeeklySchedule.activeCoolTemp(DateTime.Now.DayOfWeek, counter) = 0 Then
                            pbTickT3.BackColor = Color.LightGray
                            pbTickT2.BackColor = Color.LightGray
                            pbTickT1.BackColor = Color.LightGray
                        ElseIf myWeeklySchedule.activeCoolTemp(DateTime.Now.DayOfWeek, counter) = 1 Then
                            pbTickT3.BackColor = Color.Black
                            pbTickT2.BackColor = Color.LightGray
                            pbTickT1.BackColor = Color.LightGray
                        ElseIf myWeeklySchedule.activeCoolTemp(DateTime.Now.DayOfWeek, counter) = 2 Then
                            pbTickT3.BackColor = Color.Black
                            pbTickT2.BackColor = Color.Black
                            pbTickT1.BackColor = Color.LightGray
                        ElseIf myWeeklySchedule.activeCoolTemp(DateTime.Now.DayOfWeek, counter) = 3 Then
                            pbTickT3.BackColor = Color.Black
                            pbTickT2.BackColor = Color.Black
                            pbTickT1.BackColor = Color.Black
                        End If
                    End If
                    counter += 1
                Next
            Else
                Dim counter As Integer
                For i = 3 To 288 Step 6
                    If isHeating Then
                        If myWeeklySchedule.activeHeatTemp(DateTime.Now.DayOfWeek, counter) = 0 Then
                            DirectCast(Me.Controls.Find("pbTickT1" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.LightGray
                            DirectCast(Me.Controls.Find("pbTickT2" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.LightGray
                            DirectCast(Me.Controls.Find("pbTickT3" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.LightGray
                        ElseIf myWeeklySchedule.activeHeatTemp(DateTime.Now.DayOfWeek, counter) = 1 Then
                            DirectCast(Me.Controls.Find("pbTickT1" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.Black
                            DirectCast(Me.Controls.Find("pbTickT2" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.LightGray
                            DirectCast(Me.Controls.Find("pbTickT3" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.LightGray
                        ElseIf myWeeklySchedule.activeHeatTemp(DateTime.Now.DayOfWeek, counter) = 2 Then
                            DirectCast(Me.Controls.Find("pbTickT1" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.Black
                            DirectCast(Me.Controls.Find("pbTickT2" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.Black
                            DirectCast(Me.Controls.Find("pbTickT3" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.LightGray
                        ElseIf myWeeklySchedule.activeHeatTemp(DateTime.Now.DayOfWeek, counter) = 3 Then
                            DirectCast(Me.Controls.Find("pbTickT1" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.Black
                            DirectCast(Me.Controls.Find("pbTickT2" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.Black
                            DirectCast(Me.Controls.Find("pbTickT3" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.Black
                        End If
                    ElseIf isCooling Then
                        If myWeeklySchedule.activeCoolTemp(DateTime.Now.DayOfWeek, counter) = 0 Then
                            DirectCast(Me.Controls.Find("pbTickT3" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.LightGray
                            DirectCast(Me.Controls.Find("pbTickT2" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.LightGray
                            DirectCast(Me.Controls.Find("pbTickT1" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.LightGray
                        ElseIf myWeeklySchedule.activeCoolTemp(DateTime.Now.DayOfWeek, counter) = 1 Then
                            DirectCast(Me.Controls.Find("pbTickT3" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.Black
                            DirectCast(Me.Controls.Find("pbTickT2" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.LightGray
                            DirectCast(Me.Controls.Find("pbTickT1" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.LightGray
                        ElseIf myWeeklySchedule.activeCoolTemp(DateTime.Now.DayOfWeek, counter) = 2 Then
                            DirectCast(Me.Controls.Find("pbTickT3" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.Black
                            DirectCast(Me.Controls.Find("pbTickT2" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.Black
                            DirectCast(Me.Controls.Find("pbTickT1" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.LightGray
                        ElseIf myWeeklySchedule.activeCoolTemp(DateTime.Now.DayOfWeek, counter) = 3 Then
                            DirectCast(Me.Controls.Find("pbTickT3" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.Black
                            DirectCast(Me.Controls.Find("pbTickT2" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.Black
                            DirectCast(Me.Controls.Find("pbTickT1" & counter.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.Black
                        End If
                    End If
                    counter += 1
                Next
            End If
        End If

        clock.Enabled = True

        UpdateRequest = False
        If m_isManual Then
            RaiseEvent eventoManualeAttivato()
        Else
            RaiseEvent eventoManualeDisattivato()
        End If
        blinkingDot()


    End Sub
    Private Sub pbSquares_Click()

        Dim newDlg As New dlgTemperatureCalendar

        newDlg.dlgWeeklyScheduler = myWeeklySchedule
        newDlg.ShowDialog()
        isManual = False
        If newDlg.DialogResult = DialogResult.OK Then
            myWeeklySchedule = DeepClone(newDlg.dlgWeeklyScheduler)
        End If
        gestioneTemperatura()
    End Sub
    Private Sub Me_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        Dim myGraphics As Graphics
        Dim myRectangle As Rectangle
        Dim myPen As New Pen(Color.DarkGray, 2)

        myGraphics = Graphics.FromHwnd(Me.Handle)
        myRectangle = New Rectangle(0, 0, 294, 130)
        myGraphics.DrawRectangle(myPen, myRectangle)

    End Sub
    Private Sub visualizzazioneManuale()



        If m_isHeating Then
            If myWeeklySchedule.manualSetpoint(0) = myWeeklySchedule.freezeProtSetpoint Then
                For day = 0 To 6
                    For hh = 0 To 47
                        myWeeklySchedule.activeHeatTemp(day, hh) = 0
                    Next
                Next
            ElseIf myWeeklySchedule.manualSetpoint(0) = myWeeklySchedule.setpointHeatT1 Then
                For day = 0 To 6
                    For hh = 0 To 47
                        myWeeklySchedule.activeHeatTemp(day, hh) = 1
                    Next
                Next
            ElseIf myWeeklySchedule.manualSetpoint(0) = myWeeklySchedule.setpointHeatT2 Then
                For day = 0 To 6
                    For hh = 0 To 47
                        myWeeklySchedule.activeHeatTemp(day, hh) = 2
                    Next
                Next
            ElseIf myWeeklySchedule.manualSetpoint(0) = myWeeklySchedule.setpointHeatT3 Then
                For day = 0 To 6
                    For hh = 0 To 47
                        myWeeklySchedule.activeHeatTemp(day, hh) = 3
                    Next
                Next
            End If
        ElseIf m_isCooling Then
            If myWeeklySchedule.manualSetpoint(1) = myWeeklySchedule.freezeProtSetpoint Then
                For day = 0 To 6
                    For hh = 0 To 47
                        myWeeklySchedule.activeCoolTemp(day, hh) = 0
                    Next
                Next
            ElseIf myWeeklySchedule.manualSetpoint(1) = myWeeklySchedule.setpointCoolT1 Then
                For day = 0 To 6
                    For hh = 0 To 47
                        myWeeklySchedule.activeCoolTemp(day, hh) = 1
                    Next
                Next
            ElseIf myWeeklySchedule.manualSetpoint(1) = myWeeklySchedule.setpointCoolT2 Then
                For day = 0 To 6
                    For hh = 0 To 47
                        myWeeklySchedule.activeCoolTemp(day, hh) = 2
                    Next
                Next
            ElseIf myWeeklySchedule.manualSetpoint(1) = myWeeklySchedule.setpointCoolT3 Then
                For day = 0 To 6
                    For hh = 0 To 47
                        myWeeklySchedule.activeCoolTemp(day, hh) = 3
                    Next
                Next
            End If

        End If

        UpdateRequest = True
        'Me.BeginInvoke(Sub()
        '                   Me.Refresh()
        '               End Sub)

    End Sub
    Private Sub devisualizzazioneManuale()

        UpdateRequest = True
        'Me.BeginInvoke(Sub()
        '                   Me.Refresh()
        '               End Sub)


    End Sub
    Private Sub gestioneTemperatura()
        If m_isHeating Then
            pbCoolON.Visible = False
            If m_temperature < m_WorkingSetpoint - myWeeklySchedule.heatPB Then
                'heating ON
                pbHeatON.Visible = True
            ElseIf m_temperature >= m_WorkingSetpoint Then
                'heating OFF
                pbHeatON.Visible = False
            End If
        ElseIf m_isCooling Then
            pbHeatON.Visible = False
            If m_temperature > m_WorkingSetpoint + myWeeklySchedule.coolPB Then
                'cooling ON
                pbCoolON.Visible = True
            ElseIf m_temperature <= m_WorkingSetpoint Then
                'heating OFF
                pbCoolON.Visible = False
            End If
        End If
    End Sub

    Private Delegate Sub blinkingDotDelegate()
    Private Sub blinkingDot() 'Determina anche WSP



        If Me.InvokeRequired Then
            Dim d As New blinkingDotDelegate(AddressOf Me.blinkingDot)
            Me.BeginInvoke(d)
        Else
            Dim position As Integer
            Dim defaultColor As Color
            position = (DateTime.Now.Hour * 60 + DateTime.Now.Minute) \ 30

            If isHeating Then
                If myWeeklySchedule.activeHeatTemp(DateTime.Now.DayOfWeek, position) <> 0 Then
                    defaultColor = Color.Black
                Else
                    defaultColor = Color.LightGray
                End If

                'Determinazione working setpoint
                If m_isManual Then
                    m_WorkingSetpoint = myWeeklySchedule.manualSetpoint(0)
                ElseIf myWeeklySchedule.activeHeatTemp(DateTime.Now.DayOfWeek, position) = 0 Then
                    m_WorkingSetpoint = myWeeklySchedule.freezeProtSetpoint
                ElseIf myWeeklySchedule.activeHeatTemp(DateTime.Now.DayOfWeek, position) = 1 Then
                    m_WorkingSetpoint = myWeeklySchedule.setpointHeatT1
                ElseIf myWeeklySchedule.activeHeatTemp(DateTime.Now.DayOfWeek, position) = 2 Then
                    m_WorkingSetpoint = myWeeklySchedule.setpointHeatT2
                ElseIf myWeeklySchedule.activeHeatTemp(DateTime.Now.DayOfWeek, position) = 3 Then
                    m_WorkingSetpoint = myWeeklySchedule.setpointHeatT3
                End If
                If m_isEco And Not m_isManual Then
                    m_WorkingSetpoint += myWeeklySchedule.ecoHeatReduction
                End If

            ElseIf isCooling Then
                If myWeeklySchedule.activeCoolTemp(DateTime.Now.DayOfWeek, position) = 3 Then
                    defaultColor = Color.Black
                Else
                    defaultColor = Color.LightGray
                End If

                'Determinazione working setpoint
                If m_isManual Then
                    m_WorkingSetpoint = myWeeklySchedule.manualSetpoint(1)
                ElseIf myWeeklySchedule.activeCoolTemp(DateTime.Now.DayOfWeek, position) = 0 Then
                    m_WorkingSetpoint = myWeeklySchedule.freezeProtSetpoint
                ElseIf myWeeklySchedule.activeCoolTemp(DateTime.Now.DayOfWeek, position) = 1 Then
                    m_WorkingSetpoint = myWeeklySchedule.setpointCoolT3
                ElseIf myWeeklySchedule.activeCoolTemp(DateTime.Now.DayOfWeek, position) = 2 Then
                    m_WorkingSetpoint = myWeeklySchedule.setpointCoolT2
                ElseIf myWeeklySchedule.activeCoolTemp(DateTime.Now.DayOfWeek, position) = 3 Then
                    m_WorkingSetpoint = myWeeklySchedule.setpointCoolT1
                End If
                If m_isEco And Not m_isManual Then
                    m_WorkingSetpoint += myWeeklySchedule.ecoCoolIncrease
                End If

            End If

            gestioneTemperatura()

            If DateTime.Now.Second Mod 2 Then
                If DirectCast(Me.Controls.Find("pbTickT1" & position.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = defaultColor Then
                    DirectCast(Me.Controls.Find("pbTickT1" & position.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = Color.DarkGray
                Else
                    DirectCast(Me.Controls.Find("pbTickT1" & position.ToString.PadLeft(2, "0"), True)(0), PictureBox).BackColor = defaultColor
                End If
            End If
        End If

        Me.BeginInvoke(Sub()
                           lblWSPtemperature.Text = ("SETP: " & Format(m_WorkingSetpoint, "##0.0").ToString & "°c").Replace(",", ".")
                       End Sub)



    End Sub
    Private Delegate Sub modificaClockTextDelegate(ByVal a As String)
    Private Sub modificaClockText(ByVal a As String)

        If Me.InvokeRequired Then
            Dim d As New modificaClockTextDelegate(AddressOf Me.modificaClockText)
            Me.BeginInvoke(d, New Object() {a})
        Else
            lblClockHH.Text = a
        End If

    End Sub
    Private Delegate Sub modificalblDaysDelegate()
    Private Sub modificalblDays()

        If Me.InvokeRequired Then
            Dim d As New modificalblDaysDelegate(AddressOf Me.modificalblDays)
            Me.BeginInvoke(d)
        Else
            If DateTime.Now.Hour = 0 And DateTime.Now.Minute = 0 And DateTime.Now.Second = 0 Then
                For Each lbl In Me.Controls
                    If TypeOf (lbl) Is Label And lbl.name.contains("lblDay") Then
                        If lbl.name.contains(DateTime.Now.DayOfWeek) Then
                            lbl.visible = True
                        Else
                            lbl.visible = False
                        End If
                    End If
                Next
            End If
        End If

    End Sub

    Function DeepClone(Of T)(ByRef orig As T) As T

        ' Don't serialize a null object, simply return the default for that object
        If (Object.ReferenceEquals(orig, Nothing)) Then Return Nothing

        Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim stream As New IO.MemoryStream()

        formatter.Serialize(stream, orig)
        stream.Seek(0, IO.SeekOrigin.Begin)

        Return CType(formatter.Deserialize(stream), T)

    End Function

End Class
