Public Class frm_maintenance_inventory

    Private Sub ProductsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ProductsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ProductDataSet)

    End Sub

    Private Sub frm_maintenance_inventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ProductDataSet.Products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.ProductDataSet.Products)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ProductsBindingNavigator.AddNewItem.PerformClick()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ProductsBindingNavigatorSaveItem.PerformClick()
        MessageBox.Show("Data Saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MessageBox.Show("Do you want to Close this Form? Press 'Yes' to Close or 'No' to continue.", "Closing...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Me.Close()

        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If MessageBox.Show("Do you want to delete this item? Click 'Yes' to Close or 'No' to continue.", "delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then

            ProductsBindingNavigator.DeleteItem.PerformClick()

            MessageBox.Show("One Items Deleted", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub textBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textBox1.TextChanged
        If textBox1.Text = "" Then
            Me.ProductsTableAdapter.Fill(Me.ProductDataSet.Products)
        ElseIf textBox1.Text = "search" Then
            Me.ProductsTableAdapter.Fill(Me.ProductDataSet.Products)
        Else
            Me.ProductsTableAdapter.FillBy(Me.ProductDataSet.Products, textBox1.Text)
        End If
    End Sub
End Class