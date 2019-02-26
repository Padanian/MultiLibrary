Imports MultiLibrary
Imports EasyModbus
Imports System.IO.Ports
Imports System.ComponentModel
Imports uPLibrary.Networking.M2Mqtt
Imports System.Net
Imports System.Text
Imports uPLibrary.Networking.M2Mqtt.Messages

Public Class Form1

    Dim sbMst As New ModbusClient()  'dichiarazione canale modbus master
    Dim MultiAmmVoltmeter1 As New MultiAmmVoltmeter
    Dim MultiAmmVoltmeter2 As New MultiAmmVoltmeter
    Dim MultiAmmVoltmeter3 As New MultiAmmVoltmeter
    Dim WithEvents backgroundworker1 As New BackgroundWorker
    Dim client As MqttClient = New MqttClient("m24.cloudmqtt.com", 17241, False, Nothing, Nothing, MqttSslProtocols.None)





    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MultiAmmVoltmeter1.minimum = 224
        MultiAmmVoltmeter1.maximum = 236
        MultiAmmVoltmeter1.value = MultiAmmVoltmeter1.minimum
        MultiAmmVoltmeter2.minimum = 49.95
        MultiAmmVoltmeter2.maximum = 50.05
        MultiAmmVoltmeter2.value = MultiAmmVoltmeter2.minimum
        MultiAmmVoltmeter3.minimum = 0
        MultiAmmVoltmeter3.maximum = 10
        MultiAmmVoltmeter3.value = MultiAmmVoltmeter3.minimum

        Dim qosLevels As Byte() = {MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE}

        client.Subscribe({"Voltage"}, qosLevels)
        Dim c As String = Guid.NewGuid().ToString
        client.Connect(c, "hlatsjgt", "PljNZjm_PBOI", False, 9999)


        Try

            If sbMst.Connected Then
                sbMst.Disconnect()
            End If

            Dim port As Integer = 10
            sbMst.Baudrate = 38400

            sbMst.NumberOfRetries = 2
            sbMst.UnitIdentifier = 1
            sbMst.SerialPort = "COM10"

            sbMst.Parity = Parity.None
            sbMst.StopBits = 1
            sbMst.ConnectionTimeout = 150

            sbMst.Connect()

        Catch ex As Exception

            If sbMst.Connected() Then
                sbMst.Disconnect()
            End If

        End Try

        Me.Controls.Add(MultiAmmVoltmeter1)
        MultiAmmVoltmeter1.Location = New Point(12, 23)

        Me.Controls.Add(MultiAmmVoltmeter2)
        MultiAmmVoltmeter2.Location = New Point(168, 23)
        MultiAmmVoltmeter2.units = "H"

        Me.Controls.Add(MultiAmmVoltmeter3)
        MultiAmmVoltmeter3.Location = New Point(324, 23)
        MultiAmmVoltmeter3.units = "A"


    End Sub

    Private Sub backgroundworker1_RunWorkerAsync(sender As Object, e As DoWorkEventArgs) Handles backgroundworker1.DoWork

        Dim timestart As DateTime = DateTime.Now
        While Not sbMst.Connected

        End While

        Try
            sbMst.UnitIdentifier = 1
            Dim reading As Integer() = sbMst.ReadInputRegisters(270, 2)
            Dim temp1 As Decimal = EasyModbus.ModbusClient.ConvertRegistersToFloat({reading(1), reading(0)})
            reading = sbMst.ReadInputRegisters(218, 16)
            Dim temp2 As Decimal = EasyModbus.ModbusClient.ConvertRegistersToFloat({reading(1), reading(0)})
            Dim temp3 As Decimal = EasyModbus.ModbusClient.ConvertRegistersToFloat({reading(15), reading(14)})

            Dim result As UShort = client.Publish("Voltage", Encoding.UTF8.GetBytes(temp1))

            Me.BeginInvoke(Sub()

                               If Math.Round(MultiAmmVoltmeter1.value, 1) <> Math.Round(temp1, 1) Then
                                   MultiAmmVoltmeter1.value = temp1
                               End If
                               If Math.Round(MultiAmmVoltmeter2.value, 2) <> Math.Round(temp2, 2) Then
                                   MultiAmmVoltmeter2.value = temp2
                               End If
                               If Math.Round(MultiAmmVoltmeter3.value, 1) <> Math.Round(temp3, 1) Then
                                   MultiAmmVoltmeter3.value = temp3
                               End If

                           End Sub)


            sbMst.UnitIdentifier = 2
            Dim lettura = sbMst.ReadInputRegisters(1, 2)
            temp1 = lettura(0)
            Dim refreshStatusInizio As Integer = temp1
            Dim refreshStatusFine As Integer = refreshStatusInizio
            If MultiPumpPanel1.isPump1Running And Not MultiPumpPanel1.isPump2Running Then
                refreshStatusFine = temp1 And &B11111100 Or &B1
            ElseIf MultiPumpPanel1.isPump2Running And Not MultiPumpPanel1.isPump1Running Then
                refreshStatusFine = temp1 And &B11111100 Or &B10
            ElseIf MultiPumpPanel1.isPump2Running And MultiPumpPanel1.isPump1Running Then
                refreshStatusFine = temp1 And &B11111100 Or &B11
            Else
                refreshStatusFine = temp1 And &B11111100
            End If
            If MultiPanelSwitch1.selectedPosition = 0 Then
                refreshStatusFine = refreshStatusFine And &B11111011
            Else
                refreshStatusFine = refreshStatusFine Or &B100
            End If
            If MultiPanelSwitch2.selectedPosition = 0 Then
                refreshStatusFine = refreshStatusFine And &B11110111
            Else
                refreshStatusFine = refreshStatusFine Or &B1000
            End If

            If refreshStatusFine <> refreshStatusInizio Then
                sbMst.WriteSingleRegister(1, refreshStatusFine)
            End If

            Me.BeginInvoke(Sub()

                               temp2 = lettura(1)
                               If temp2 And &B1 Then
                                   MultiPumpPanel1.pump1Alarm = True
                               Else
                                   MultiPumpPanel1.pump1Alarm = False
                               End If
                               If temp2 And &B10 Then
                                   MultiPumpPanel1.pump2Alarm = True
                               Else
                                   MultiPumpPanel1.pump2Alarm = False
                               End If

                               If temp2 And &B100 Then
                                   MultiPanelSwitch1.semaphorColor = Color.Yellow
                                   MultiPanelSwitch1.isSemaphorBlinking = True
                               Else
                                   MultiPanelSwitch1.semaphorColor = Color.Black
                                   MultiPanelSwitch1.isSemaphorBlinking = False
                               End If
                               If temp2 And &B1000 Then
                                   MultiPanelSwitch2.semaphorColor = Color.Yellow
                                   MultiPanelSwitch2.isSemaphorBlinking = True
                               Else
                                   MultiPanelSwitch2.semaphorColor = Color.Black
                                   MultiPanelSwitch2.isSemaphorBlinking = False
                               End If

                               Dim timestop As DateTime = DateTime.Now
                               Label1.Text = "Tempo di esecuzione..." & ((timestop.Second * 1000 + timestop.Millisecond) - (timestart.Second * 1000 + timestart.Millisecond)).ToString & "ms"

                           End Sub)


        Catch ex As Exception


        End Try


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not backgroundworker1.IsBusy Then
            backgroundworker1.RunWorkerAsync()
        End If
    End Sub
End Class
