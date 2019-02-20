﻿Imports MultiLibrary
Imports EasyModbus
Imports System.IO.Ports

Public Class Form1

    Dim sbMst As New ModbusClient()  'dichiarazione canale modbus master
    Dim MultiAmmVoltmeter1 As New MultiAmmVoltmeter
    Dim MultiAmmVoltmeter2 As New MultiAmmVoltmeter
    Dim MultiAmmVoltmeter3 As New MultiAmmVoltmeter




    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MultiAmmVoltmeter1.minimum = 224
        MultiAmmVoltmeter1.maximum = 236
        MultiAmmVoltmeter2.minimum = 49.95
        MultiAmmVoltmeter2.maximum = 50.05
        MultiAmmVoltmeter3.minimum = 0
        MultiAmmVoltmeter3.maximum = 10


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
            Timer1.Enabled = True

        Catch ex As Exception

            If sbMst.Connected() Then
                sbMst.Disconnect()
                Timer1.Enabled = False
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try


            sbMst.UnitIdentifier = 1
            Dim reading As Integer() = sbMst.ReadInputRegisters(270, 2)
            Dim temp As Decimal = EasyModbus.ModbusClient.ConvertRegistersToFloat({reading(1), reading(0)})
            MultiAmmVoltmeter1.value = temp
            reading = sbMst.ReadInputRegisters(218, 2)
            temp = EasyModbus.ModbusClient.ConvertRegistersToFloat({reading(1), reading(0)})
            MultiAmmVoltmeter2.value = temp
            reading = sbMst.ReadInputRegisters(232, 2)
            temp = EasyModbus.ModbusClient.ConvertRegistersToFloat({reading(1), reading(0)})
            MultiAmmVoltmeter3.value = temp

            sbMst.UnitIdentifier = 2
            Dim lettura = sbMst.ReadInputRegisters(1, 2)
            Dim temp2 = lettura(0)
            Dim refreshStatus As Integer = temp2
            If MultiPumpPanel1.isPump1Running And Not MultiPumpPanel1.isPump2Running Then
                refreshStatus = temp2 And &B11111100 Or &B1
            ElseIf MultiPumpPanel1.isPump2Running And Not MultiPumpPanel1.isPump1Running Then
                refreshStatus = temp2 And &B11111100 Or &B10
            ElseIf MultiPumpPanel1.isPump2Running And MultiPumpPanel1.isPump1Running Then
                refreshStatus = temp2 And &B11111100 Or &B11
            Else
                refreshStatus = temp2 And &B11111100
            End If
            If MultiPanelSwitch1.selectedPosition = 0 Then
                refreshStatus = refreshStatus And &B11111011
            Else
                refreshStatus = refreshStatus Or &B100
            End If
            If MultiPanelSwitch2.selectedPosition = 0 Then
                refreshStatus = refreshStatus And &B11110111
            Else
                refreshStatus = refreshStatus Or &B1000
            End If

            sbMst.WriteSingleRegister(1, refreshStatus)

            Dim temp3 As Integer = lettura(1)
            If temp3 And &B1 Then
                MultiPumpPanel1.pump1Alarm = True
            Else
                MultiPumpPanel1.pump1Alarm = False
            End If
            If temp3 And &B10 Then
                MultiPumpPanel1.pump2Alarm = True
            Else
                MultiPumpPanel1.pump2Alarm = False
            End If
            If temp3 And &B100 Then
                MultiPanelSwitch1.semaphorColor = Color.Yellow
                MultiPanelSwitch1.isSemaphorBlinking = True
            Else
                MultiPanelSwitch1.semaphorColor = Color.Black
                MultiPanelSwitch1.isSemaphorBlinking = False
            End If
            If temp3 And &B1000 Then
                MultiPanelSwitch2.semaphorColor = Color.Yellow
                MultiPanelSwitch2.isSemaphorBlinking = True
            Else
                MultiPanelSwitch2.semaphorColor = Color.Black
                MultiPanelSwitch2.isSemaphorBlinking = False
            End If
        Catch ex As Exception


        End Try

    End Sub
End Class
