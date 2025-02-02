Public Class _Default
    Inherits System.Web.UI.Page

    Dim CONNECT As New Connection()

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Register()
    End Sub

    Public Sub Register()
        Dim username = txtUsername.Text
        Dim password = txtPassword.Text
        Dim display_name = txtDisplayName.Text
        Dim user_type = ddlUserType.SelectedValue

        Dim query = "INSERT INTO users (username, password, display_name, user_type) VALUES (@username, @password, @display_name, @user_type)"

        CONNECT.AddParam("@username", username)
        CONNECT.AddParam("@password", password)
        CONNECT.AddParam("@display_name", display_name)
        CONNECT.AddParam("@user_type", user_type)

        Dim insert = CONNECT.Query(query)

        If insert Then
            Dim script As String = "alert('Successfully Register!');"
            ClientScript.RegisterStartupScript(Me.GetType(), "alertMessage", script, True)
        Else
            Dim script As String = "alert('Failed to Register!');"
            ClientScript.RegisterStartupScript(Me.GetType(), "alertMessage", script, True)
        End If

        ViewTable()
    End Sub

    Public Sub ViewTable()
        Dim query = "SELECT * FROM users"

        CONNECT.Query(query)

        Table1.Rows.Clear()

        Dim headerRow As New TableHeaderRow()
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "Username"})
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "Password"})
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "Display Name"})
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "User Type"})
        Table1.Rows.Add(headerRow)

        For Each row As DataRow In CONNECT.Data.Tables(0).Rows
            Dim tableRow As New TableRow()

            tableRow.Cells.Add(New TableCell() With {.Text = row("username").ToString()})
            tableRow.Cells.Add(New TableCell() With {.Text = row("password").ToString()})
            tableRow.Cells.Add(New TableCell() With {.Text = row("display_name").ToString()})
            tableRow.Cells.Add(New TableCell() With {.Text = row("user_type").ToString()})

            Table1.Rows.Add(tableRow)
        Next
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ViewTable()
    End Sub

End Class