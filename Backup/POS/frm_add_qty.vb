Public Class frm_add_qty

    Private Sub ProductsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ProductsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ProductDataSet)

    End Sub

    Private Sub frm_add_qty_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ProductDataSet.Products' table. You can move, or remove it, as needed.
        ProductIDTextBox.Visible = False
        QtyTextBox.Enabled = False
        ProductNameTextBox.Enabled = False
        ProductCodeTextBox.Enabled = False
        PriceTextBox.Enabled = False
        AmountTextBox.Enabled = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MessageBox.Show("Do you want to Close this Form? Press 'Yes' to Close or 'No' to continue.", "Closing...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Me.Close()

        End If
    End Sub

    Private Sub textBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textBox1.TextChanged
        If textBox1.Text = "" Then
            Return
        ElseIf textBox1.Text = "search" Then
            Return
        Else
            Me.ProductsTableAdapter.FillBy(Me.ProductDataSet.Products, textBox1.Text)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        QtyTextBox.Text = Val(TextBox2.Text) + Val(QtyTextBox.Text)
        ProductsBindingNavigatorSaveItem.PerformClick()

        MessageBox.Show("Quantity Added", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        QtyTextBox.Text = ""
        ProductNameTextBox.Text = ""
        ProductCodeTextBox.Text = ""
        PriceTextBox.Text = ""
        AmountTextBox.Text = ""
        TextBox2.Text = ""
    End Sub
End Class