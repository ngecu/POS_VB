Public Class frm_add_products

    Private Sub ProductsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ProductsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ProductDataSet)

    End Sub

    Private Sub frm_add_products_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ProductDataSet.Products' table. You can move, or remove it, as needed.
        ProductIDTextBox.Visible = False
        QtyTextBox.Enabled = False
        ProductNameTextBox.Enabled = False
        ProductCodeTextBox.Enabled = False
        PriceTextBox.Enabled = False
        AmountTextBox.Enabled = False
    End Sub

   

 

    Private Sub ProductsBindingNavigator_RefreshItems(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsBindingNavigator.RefreshItems

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ProductsBindingNavigator.AddNewItem.PerformClick()
        QtyTextBox.Enabled = True
        ProductNameTextBox.Enabled = True
        ProductCodeTextBox.Enabled = True
        PriceTextBox.Enabled = True
        AmountTextBox.Enabled = True
        QtyTextBox.Focus()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ProductsBindingNavigatorSaveItem.PerformClick()
        MessageBox.Show("Data Saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ProductsBindingNavigator.AddNewItem.PerformClick()
        QtyTextBox.Focus()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MessageBox.Show("Do you want to Close this Form? Press 'Yes' to Close or 'No' to continue.", "Closing...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Me.Close()

        End If
    End Sub
End Class