Public Class MultiGenTemperatureIconLeft
    Public Property Tname As String
    Public Property TempValue As Double
    Public Property LEDcolor As Color
    ''' <summary>
    ''' Cambio dell'etichetta descrittiva del nome dell'icona
    ''' </summary>
    ''' <param name="Tname">Stringa descrittiva del nome dell'icona</param>
    ''' <remarks></remarks>
    Public Sub changeName(ByVal Tname As String)
        If Tname.Length = 5 Then
            lblName.Text = Tname
        End If
        lblName.Invalidate()
    End Sub
    ''' <summary>
    ''' Cambio della temperatura associato all'icona
    ''' </summary>
    ''' <param name="TempValue">Valore della temperatura</param>
    ''' <remarks></remarks>
    Public Sub changeTemp(ByVal TempValue As Double)
        lblTemp.Text = Format(TempValue, "##0.0#°C")
        lblTemp.Invalidate()
    End Sub
    ''' <summary>
    ''' Cambio del colore del LED
    ''' </summary>
    ''' <param name="LEDcolor">Colore del Led</param>
    ''' <remarks></remarks>
    Public Sub changeLED(ByVal LEDcolor As Color)
        If LEDcolor = Color.Red Then
            pbLED.Image = My.Resources.ledred
        End If
        If LEDcolor = Color.Green Then
            pbLED.Image = My.Resources.ledgreen
        End If
        If LEDcolor = Color.Gray Then
            pbLED.Image = My.Resources.ledoff
        End If
        pbLED.Invalidate()
    End Sub
End Class