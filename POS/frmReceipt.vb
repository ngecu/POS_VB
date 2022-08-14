Public Class frmReceipt

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Close()

    End Sub

    Private Sub frmReceipt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim lid As Integer
        If Me.LastID.Text IsNot Nothing Then
            lid = Val(LastID.Text)
            'MsgBox(LastID.Text & " " & lid)

            ' Me.qryReceiptTableAdapter.Fill(Me.ReceiptDataSet.qryReceipt)
            Me.qryReceiptTableAdapter.FillBy(Me.ReceiptDataSet.qryReceipt, lid)
        Else
            Me.qryReceiptTableAdapter.Fill(Me.ReceiptDataSet.qryReceipt)
        End If

        Me.ReportViewer1.RefreshReport()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub
End Class
