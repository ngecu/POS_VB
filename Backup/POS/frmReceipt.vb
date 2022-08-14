Public Class frmReceipt

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Close()

    End Sub

    Private Sub frmReceipt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.qryReceiptTableAdapter.Fill(Me.ReceiptDataSet.qryReceipt)

        Me.ReportViewer1.RefreshReport()

    End Sub

End Class
