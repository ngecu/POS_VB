Public Class frm_out_of_stock

    Private Sub ProductsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ProductsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ProductDataSet)

    End Sub

    Private Sub frm_out_of_stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ProductDataSet.Products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.FillBy1(Me.ProductDataSet.Products)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MessageBox.Show("Do you want to Close this Form? Press 'Yes' to Close or 'No' to continue.", "Closing...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Me.Close()

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