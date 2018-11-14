
<Serializable()>
Public Class weeklyScheduler
    Public Property setpointHeatT1 As Decimal
    Public Property setpointHeatT2 As Decimal
    Public Property setpointHeatT3 As Decimal
    Public Property setpointCoolT1 As Decimal
    Public Property setpointCoolT2 As Decimal
    Public Property setpointCoolT3 As Decimal

    Public Property heatPB As Decimal
    Public Property coolPB As Decimal
    Public Property freezeProtSetpoint As Decimal
    Public Property ecoHeatReduction As Decimal
    Public Property ecoCoolIncrease As Decimal
    Public Property workingSetpoint As Decimal
    Public Property manualSetpoint As Decimal()
    Public Property manualSelectedIndex As Integer
    Public activeHeatTemp(,) As Integer
    Public activeCoolTemp(,) As Integer
    Public Sub New()
        ReDim activeHeatTemp(6, 47)
        ReDim activeCoolTemp(6, 47)
        For i = 0 To 6
            For j = 0 To 47
                activeHeatTemp(i, j) = 0
                activeCoolTemp(i, j) = 0
            Next
        Next

        setpointHeatT1 = 15.0
        setpointHeatT2 = 19.0
        setpointHeatT3 = 21.0
        setpointCoolT1 = 24.0
        setpointCoolT2 = 26.0
        setpointCoolT3 = 30.0

        heatPB = 2.0
        coolPB = 2.0
        freezeProtSetpoint = 6.0
        ecoHeatReduction = -4.0
        ecoCoolIncrease = 4.0
        workingSetpoint = 0.0
        manualSetpoint = {freezeProtSetpoint, freezeProtSetpoint}

        manualSelectedIndex = 3

    End Sub



End Class
