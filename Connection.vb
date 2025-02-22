﻿Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class Connection
    Public ConnectionString As String = "Data Source=DESKTOP-PD9I1RP\SQLEXPRESS;Initial Catalog=asp_website;Integrated Security=True"

    ' Connection Query Funcitionality

    ' our main connection
    Public Connect As New SqlConnection(ConnectionString)

    ' array of parameters
    Public Parameters As New List(Of SqlParameter)

    ' the result of every query
    Public Data As DataSet

    ' count of results
    Public DataCount As Integer

    ' create open and close fn
    Public Sub Open()
        If Connect.State = ConnectionState.Closed Then
            Connect.Open()
        End If
    End Sub

    Public Sub Close()
        If Connect.State = ConnectionState.Open Then
            Connect.Close()
        End If
    End Sub

    Public Sub AddParam(ByVal key As String, ByVal value As String)
        Parameters.Add(New SqlParameter(key, value))
    End Sub

    Public Function Query(ByVal command_query As String) As Boolean
        Open()

        Dim command As New SqlCommand(command_query, Connect)

        If Parameters.Count > 0 Then
            For Each param As SqlParameter In Parameters
                command.Parameters.Add(param)
            Next
            Parameters.Clear()
        End If

        If command_query.StartsWith("INSERT", StringComparison.OrdinalIgnoreCase) OrElse
           command_query.StartsWith("UPDATE", StringComparison.OrdinalIgnoreCase) OrElse
           command_query.StartsWith("DELETE", StringComparison.OrdinalIgnoreCase) Then

            Dim rowsAffected As Integer = command.ExecuteNonQuery()

            Close()

            Return rowsAffected > 0
        ElseIf command_query.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase) Then

            Dim adapter As New SqlDataAdapter(command)
            Data = New DataSet()
            DataCount = adapter.Fill(Data)
            Close()

            Return DataCount > 0
        Else

            Close()
            Return False
        End If
    End Function

End Class