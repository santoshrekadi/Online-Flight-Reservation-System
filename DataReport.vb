Imports System.Data.SqlClient
Public Class DataReport
    Private Sub DataReport1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con = New SqlConnection("Data Source=localhost;Initial Catalog=AirlineBooking;Integrated Security=True")
        Dim command As New SqlCommand("select SOURCE,DESTINATION,DATE,(ADULTS+CHILDREN+INFANTS) as PASSENGERS,FLIGHT_TYPE,FARE_TYPE from ReportTbl", con)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable
        adapter.Fill(table)
        DataGridView1.DataSource = table
    End Sub
End Class