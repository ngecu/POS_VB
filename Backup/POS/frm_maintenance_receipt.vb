Public Class frm_maintenance_receipt

    Private Sub SalesBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.SalesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.SalesDataSet)

    End Sub

    Private Sub frm_maintenance_receipt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ProductDataSet.Products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.ProductDataSet.Products)
        'TODO: This line of code loads data into the 'SalesDataSet.SalesDetails' table. You can move, or remove it, as needed.
        Me.SalesDetailsTableAdapter.Fill(Me.SalesDataSet.SalesDetails)
        'TODO: This line of code loads data into the 'SalesDataSet.Sales' table. You can move, or remove it, as needed.
        Me.SalesTableAdapter.Fill(Me.SalesDataSet.Sales)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MessageBox.Show("Do you want to Close this Form? Press 'Yes' to Close or 'No' to continue.", "Closing...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Me.Close()

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SalesBindingNavigatorSaveItem.PerformClick()
        MessageBox.Show("Data Saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class