Public Class frmLogin

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        If Me.PasswordTextBox.Text = "Administrator" Or Me.PasswordTextBox.Text = "Admin" Then
            mdiAdmin.Show()
            Me.Close()
            frmSales.Hide()
        ElseIf Me.PasswordTextBox.Text = "" Then
            MessageBox.Show("Please input a password!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            PasswordTextBox.Clear()
            PasswordTextBox.Focus()
        Else
            MessageBox.Show("Invalid password!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PasswordTextBox.Clear()
            PasswordTextBox.Focus()
        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
