Imports System.Windows.Forms

Public Class mdiAdmin

    Private Sub InventoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventoryToolStripMenuItem.Click

        frmProducts.Show()
        frmProducts.MdiParent = Me

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click

        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next

        If MessageBox.Show("Are you sure you want to exit?", "Exit System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Application.Exit()
        Else
            Return
        End If

    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click

        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next

        If MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            frmSales.Show()

            Me.Hide()
        Else
            Return
        End If

    End Sub

    Private Sub AddItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddItemToolStripMenuItem.Click
        frm_add_products.Show()
        frm_add_products.MdiParent = Me

    End Sub

    Private Sub AdminToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub AdminToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdminToolStripMenuItem1.Click
        frm_Admin_info.Show()
        frm_Admin_info.MdiParent = Me
    End Sub

    Private Sub CashierToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashierToolStripMenuItem1.Click
        frm_cashier_info.Show()
        frm_cashier_info.MdiParent = Me

    End Sub

    Private Sub AddItemQuantityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddItemQuantityToolStripMenuItem.Click
        frm_add_qty.Show()
        frm_add_qty.MdiParent = Me

    End Sub

    Private Sub OutOfStockItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutOfStockItemsToolStripMenuItem.Click
        frm_out_of_stock.Show()
        frm_out_of_stock.MdiParent = Me

    End Sub

    Private Sub InventoryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventoryToolStripMenuItem1.Click
        frm_maintenance_inventory.Show()
        frm_maintenance_inventory.MdiParent = Me

    End Sub

    Private Sub RecieToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecieToolStripMenuItem.Click
        frm_maintenance_receipt.Show()
        frm_maintenance_receipt.MdiParent = Me

    End Sub

    Private Sub ToolStripLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel1.Click

    End Sub

    Private Sub mdiAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ToolStripLabel1.Text = Date.Now
    End Sub
End Class
