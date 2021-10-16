Imports System.ComponentModel

Public Class Form1

    'Default radio buttons are disabled
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
    End Sub

    Private Sub BConfirm_Click(sender As Object, e As EventArgs) Handles BConfirm.Click
        If RadioButton1.Checked = True Then
            Dim oneway As New Oneway
            oneway.Show()
        ElseIf RadioButton2.Checked = True Then
            Dim multicity As New Multicity
            multicity.Show()
        ElseIf RadioButton3.Checked = True Then
            Dim twoway As New Twoway
            twoway.Show()
        Else
            MessageBox.Show("Please select any option", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        MessageBox.Show("Thank You! Happy and Safe Journey", "Air Ticket Pro")
        Me.Close()
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Dim dataReport As New DataReport
        dataReport.Show()
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do you really want to close the app", "Exit", MessageBoxButtons.YesNo)
        If dialog = DialogResult.No Then
            e.Cancel = True
        Else
            Application.ExitThread()

        End If

    End Sub
End Class
