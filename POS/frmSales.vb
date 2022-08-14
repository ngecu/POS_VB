Imports System.Data.OleDb

Public Class frmSales
    Dim conn As New OleDbConnection

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim sqlQRY As String = "SELECT * FROM Products WHERE ProductCode = '" & txtCode.Text & "'"
        Dim cmd As OleDbCommand = New OleDbCommand(sqlQRY, conn)
        Dim rdr As OleDbDataReader = cmd.ExecuteReader

        If txtCode.Text = "" Then
            MessageBox.Show("Input a product code!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCode.Text = ""
            txtCode.Focus()
        ElseIf rdr.HasRows Then
            rdr.Read()
            Try
                Dim intProductID As Integer = rdr("ProductID").ToString

                Dim newRow As SalesDataSet.SalesDetailsRow = SalesDataSet.SalesDetails.NewSalesDetailsRow

                newRow.SalesID = SalesIDTextBox.Text
                newRow.ProductName = intProductID
                newRow.Qty = 1
                Dim Price As Decimal = rdr("Price")
                newRow.Price = Price
                newRow.Amount = Price

                SalesDataSet.SalesDetails.Rows.Add(newRow)

                txtCode.Text = ""
                txtCode.Focus()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Else
            MessageBox.Show("Product not found!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCode.Text = ""
            txtCode.Focus()
        End If

        txtTotal.Text = Totals()

        Dim vat As Decimal

        vat = Val(txtTotal.Text) * 0.12

        txtVAT.Text = vat
        Button1.Enabled = True
    End Sub

    Private Sub SalesBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesBindingNavigatorSaveItem.Click

        Me.Validate()
        Me.SalesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.SalesDataSet)

    End Sub

    Private Sub frmSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button1.Enabled = False
        Me.ProductsTableAdapter.Fill(Me.ProductDataSet.Products)


        Me.SalesTableAdapter.Fill(Me.SalesDataSet.Sales)

        Dim cnString As String

        cnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\POS.mdb"

        conn = New OleDbConnection(cnString)

        Try
            conn.Open()
        Catch ex As OleDbException
            MessageBox.Show(ex.Message, "Error..", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
        txtVAT.Text = ""
        txtCash.Text = ""
        txtChange.Text = ""
        txtTotal.Text = ""
        SalesIDTextBox.Text = ""

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        SalesBindingNavigator.AddNewItem.PerformClick()

        btnNew.Enabled = False
        SalesDetailsDataGridView.Enabled = True
        txtCode.Enabled = True
        btnAdd.Enabled = True
        txtCash.Enabled = True
        txtCode.Focus()

        txtTotal.Text = 0
        txtVAT.Text = 0
        txtCash.Text = ""
        txtChange.Text = 0



    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        DateTextBox.Text = DateString

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        If MessageBox.Show("Are you sure you want to exit?", "Exit System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Application.Exit()
        Else
            Return
        End If

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        ' MsgBox(SalesIDTextBox.Text)
        Me.Validate()
        Me.SalesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.SalesDataSet)


        Dim sid As String
        sid = SalesIDTextBox.Text
        frmReceipt.LastID.Text = sid
        frmReceipt.ShowDialog()
        Dim intQty As Integer

        For Each row As DataGridViewRow In Me.SalesDetailsDataGridView.Rows
            Dim intProductID As Integer
            Dim strSQL As String

            If row.Cells(Me.Product.Index).Value > 0 Then
                intProductID = row.Cells(Me.Product.Index).Value
                intQty = row.Cells(Me.Qty.Index).Value

                strSQL = "UPDATE Products SET Qty = Qty - " & intQty & " WHERE ProductID = " & intProductID

                Dim cmd_a As OleDbCommand = New OleDbCommand(strSQL, conn)

                cmd_a.ExecuteNonQuery()
            End If
        Next row

        SalesBindingNavigator.AddNewItem.PerformClick()

        txtTotal.Text = 0
        txtVAT.Text = 0
        txtCash.Text = ""
        txtChange.Text = 0
        txtCode.Focus()

    End Sub

    Private Sub btnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLock.Click

        frmLock.Show()

        Me.Hide()

    End Sub

    Private Sub SalesDetailsDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles SalesDetailsDataGridView.CellContentClick

    End Sub

    Private Sub SalesDetailsDataGridView_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles SalesDetailsDataGridView.CellEndEdit

        Dim sales As DataGridView = DirectCast(sender, DataGridView)

        sales("Amount", e.RowIndex).Value = sales("Qty", e.RowIndex).Value * sales("Price", e.RowIndex).Value

        txtTotal.Text = Totals()

        Dim vat As Decimal

        vat = Val(txtTotal.Text) * 0.12

        txtVAT.Text = vat

    End Sub

    Private Function Totals() As Double

        Dim total As Double = 0
        Dim i As Integer = 0

        For i = 0 To SalesDetailsDataGridView.Rows.Count - 1
            total = total + Convert.ToDouble(SalesDetailsDataGridView.Rows(i).Cells("Amount").Value)
        Next i
        Return total

    End Function

    Private Sub txtCash_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCash.TextChanged

        txtChange.Text = Val(txtCash.Text) - Val(txtTotal.Text)

        If Val(txtCash.Text) >= Val(txtTotal.Text) Then
            btnPrint.Enabled = True
        Else
            btnPrint.Enabled = False
        End If

        If Val(txtTotal.Text) = 0 Then
            btnPrint.Enabled = False
        End If



    End Sub

    Private Sub btnAdmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdmin.Click

        frmLogin.ShowDialog()

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frm_enter_cash.ShowDialog()
        frm_enter_cash.TextBox1.Text = ""

        frm_enter_cash.TextBox1.Focus()
    End Sub
End Class
