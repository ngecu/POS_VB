Imports System.Data.OleDb

Public Class frmLock
    Dim conn As New OleDbConnection

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        Dim sqlQRY As String = "SELECT * FROM Cashier WHERE Password = '" & Me.PasswordTextBox.Text & "'"
        Dim cmd As OleDbCommand = New OleDbCommand(sqlQRY, conn)
        Dim rdr As OleDbDataReader = cmd.ExecuteReader
        rdr.Read()
        If rdr.HasRows = True Then
            Dim Password As String = rdr("Password").ToString
            frmSales.Show()
            PasswordTextBox.Clear()
            PasswordTextBox.Focus()
            Me.Hide()
        ElseIf PasswordTextBox.Text = "" Then
            MessageBox.Show("Please input a valid unlock key!", "Unlock Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            PasswordTextBox.Clear()
            PasswordTextBox.Focus()
        Else
            MessageBox.Show("Invalid unlock key!", "Unlock Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PasswordTextBox.Clear()
            PasswordTextBox.Focus()
        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmLock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim cnString As String

        cnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\POS.mdb"

        conn = New OleDbConnection(cnString)

        Try
            conn.Open()
        Catch ex As OleDbException
            MessageBox.Show(ex.Message, "Error..", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try

    End Sub

End Class
