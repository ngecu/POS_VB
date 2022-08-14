Public Class frm_cashier_info

    Private Sub CashierBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashierBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CashierBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.CashierDataSet)

    End Sub

    Private Sub frm_cashier_info_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CashierDataSet.Cashier' table. You can move, or remove it, as needed.
        Me.CashierTableAdapter.Fill(Me.CashierDataSet.Cashier)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CashierBindingNavigator.AddNewItem.PerformClick()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CashierBindingNavigatorSaveItem.PerformClick()
        MessageBox.Show("Data Saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MessageBox.Show("Do you want to Close this Form? Press 'Yes' to Close or 'No' to continue.", "Closing...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Me.Close()

        End If
    End Sub
End Class