Imports System.ComponentModel
Imports System.Data.SqlClient
Public Class Twoway

    'Display
    Dim con = New SqlConnection("Data Source=localhost;Initial Catalog=AirlineBooking;Integrated Security=True")
    Dim displayQuery As String = "select * from TwowayTbl"
    Dim command As New SqlCommand(displayQuery, con)
    Dim da2 As New SqlDataAdapter(command)
    Dim tb As New DataTable
    Dim counter As Integer = 0
    Private Sub Twoway_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Set Time to Label1'
        Dim date1 As Date = Now.ToLongTimeString
        Label1.Text = date1
        'Set Date to Label2'
        Dim date2 As Date = Now.ToShortDateString
        Label2.Text = date2

        'Combo 1'
        ComboBox1.Items.Add("Flight-1")
        ComboBox1.Items.Add("Flight-2")
        ComboBox1.Items.Add("Flight-3")

        'Combo 2'
        ComboBox2.Items.Add("First Class")
        ComboBox2.Items.Add("Business")
        ComboBox2.Items.Add("Economy")
        ComboBox2.Items.Add("Premium Economy")

        'Combo 3'
        ComboBox3.Items.Add("Regular")
        ComboBox3.Items.Add("Student")

        da2.Fill(tb)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "Flight-1" Then
            TextBox1.Text = "Nairobi"
            TextBox2.Text = "New York City"
            TextBox3.Text = "5000"
            TextBox4.Text = 100
            TextBox5.Text = Val(TextBox3.Text) + Val(TextBox4.Text)
        ElseIf ComboBox1.SelectedItem = "Flight-2" Then
            TextBox1.Text = "Nairobi"
            TextBox2.Text = "Berlin"
            TextBox3.Text = "6000"
            TextBox4.Text = 500
            TextBox5.Text = Val(TextBox3.Text) + Val(TextBox4.Text)
        ElseIf ComboBox1.SelectedItem = "Flight-3" Then
            TextBox1.Text = "Nairobi"
            TextBox2.Text = "Mumbai"
            TextBox3.Text = "9000"
            TextBox4.Text = 670
            TextBox5.Text = Val(TextBox3.Text) + Val(TextBox4.Text)
        End If

    End Sub

    Private Sub TextBox9_Click(sender As Object, e As EventArgs) Handles TextBox9.Click
        TextBox9.Text = Val(TextBox6.Text) + Val(TextBox7.Text) + Val(TextBox8.Text)
    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        Dim Insertquery As String = "insert into TwowayTbl(FLIGHT_TYPE,SOURCE,DESTINATION,FARE,TAX,TOTAL_FARE,DATE1,ADULTS,CHILDREN,INFANTS,CABIN_CLASS,FARE_TYPE) values(@flight_type,@source,@destination,@fare,@tax,@total_fare,@date1,@adults,@children,@infants,@cabin_class,@fare_type)"
        RunQuery(Insertquery)
    End Sub

    Public Sub RunQuery(ByVal query As String)
        If ComboBox1.SelectedIndex >= 0 And ComboBox2.SelectedIndex >= 0 And ComboBox3.SelectedIndex >= 0 Then
            con = New SqlConnection("Data Source=localhost;Initial Catalog=AirlineBooking;Integrated Security=True")
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@flight_type", ComboBox1.SelectedItem.ToString)
            cmd.Parameters.AddWithValue("@source", TextBox1.Text)
            cmd.Parameters.AddWithValue("@destination", TextBox2.Text)
            cmd.Parameters.AddWithValue("@fare", Val(TextBox3.Text))
            cmd.Parameters.AddWithValue("@tax", Val(TextBox4.Text))
            cmd.Parameters.AddWithValue("@total_fare", Val(TextBox5.Text))
            cmd.Parameters.AddWithValue("@date1", DateTimePicker1.Value.ToString)
            cmd.Parameters.AddWithValue("@adults", Val(TextBox6.Text))
            cmd.Parameters.AddWithValue("@children", Val(TextBox7.Text))
            cmd.Parameters.AddWithValue("@infants", Val(TextBox8.Text))
            cmd.Parameters.AddWithValue("@cabin_class", ComboBox2.SelectedItem.ToString)
            cmd.Parameters.AddWithValue("@fare_type", ComboBox3.SelectedItem.ToString)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Data has been saved!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Please select an option")
        End If

    End Sub

    Public Sub RunQueryForConfirm(ByVal query As String)
        If ComboBox1.SelectedIndex >= 0 And ComboBox2.SelectedIndex >= 0 And ComboBox3.SelectedIndex >= 0 Then
            con = New SqlConnection("Data Source=localhost;Initial Catalog=AirlineBooking;Integrated Security=True")
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@flight_type", ComboBox1.SelectedItem.ToString)
            cmd.Parameters.AddWithValue("@source", TextBox1.Text)
            cmd.Parameters.AddWithValue("@destination", TextBox2.Text)
            cmd.Parameters.AddWithValue("@fare", Val(TextBox3.Text))
            cmd.Parameters.AddWithValue("@tax", Val(TextBox4.Text))
            cmd.Parameters.AddWithValue("@total_fare", Val(TextBox5.Text))
            cmd.Parameters.AddWithValue("@date1", DateTimePicker1.Value.ToString)
            cmd.Parameters.AddWithValue("@adults", Val(TextBox6.Text))
            cmd.Parameters.AddWithValue("@children", Val(TextBox7.Text))
            cmd.Parameters.AddWithValue("@infants", Val(TextBox8.Text))
            cmd.Parameters.AddWithValue("@cabin_class", ComboBox2.SelectedItem.ToString)
            cmd.Parameters.AddWithValue("@fare_type", ComboBox3.SelectedItem.ToString)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Your Ticket is Booked, Thank you", "Confirmed!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Form1.Show()
            Me.Close()
        Else
            MessageBox.Show("Ticket is not booked.Please check the details")
        End If

    End Sub

    Private Sub Add_Click(sender As Object, e As EventArgs) Handles Add.Click
        clear()
    End Sub

    Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        ComboBox1.SelectedIndex = -1
        ComboBox1.Text = "Select Flight"
        ComboBox2.SelectedIndex = -1
        ComboBox2.Text = "Select Cabin Class"
        ComboBox3.SelectedIndex = -1
        ComboBox3.Text = "Select Fare Type"
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        MessageBox.Show("Thank You!!", "Come Again!!")
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Confirm_Click(sender As Object, e As EventArgs) Handles Confirm.Click
        Dim Insertquery As String = "insert into ReportTbl(FLIGHT_TYPE,SOURCE,DESTINATION,FARE,TAX,TOTAL_FARE,DATE,ADULTS,CHILDREN,INFANTS,CABIN_CLASS,FARE_TYPE) values(@flight_type,@source,@destination,@fare,@tax,@total_fare,@date1,@adults,@children,@infants,@cabin_class,@fare_type)"
        RunQueryForConfirm(Insertquery)

    End Sub

    Private Sub Previous_Click(sender As Object, e As EventArgs) Handles Previous.Click
        If counter >= tb.Rows.Count Then
            counter = counter - 2
            If tb.Rows.Count > counter Then

                ComboBox1.SelectedItem = tb.Rows(counter)(1).ToString
                TextBox1.Text = tb.Rows(counter)(2).ToString
                TextBox2.Text = tb.Rows(counter)(3).ToString
                TextBox3.Text = tb.Rows(counter)(4).ToString
                TextBox4.Text = tb.Rows(counter)(5).ToString
                TextBox5.Text = tb.Rows(counter)(6).ToString
                DateTimePicker1.Value = tb.Rows(counter)(7).ToString
                TextBox6.Text = tb.Rows(counter)(8).ToString
                TextBox7.Text = tb.Rows(counter)(9).ToString
                TextBox8.Text = tb.Rows(counter)(10).ToString
                TextBox9.Text = Val(TextBox6.Text) + Val(TextBox7.Text) + Val(TextBox8.Text)
                ComboBox2.SelectedItem = tb.Rows(counter)(11).ToString
                ComboBox3.SelectedItem = tb.Rows(counter)(12).ToString
                counter = counter - 1
            Else
                MessageBox.Show("No Rows Found:" & counter)
            End If
        ElseIf counter >= 0 And tb.Rows.Count > counter Then
            ComboBox1.SelectedItem = tb.Rows(counter)(1).ToString
            TextBox1.Text = tb.Rows(counter)(2).ToString
            TextBox2.Text = tb.Rows(counter)(3).ToString
            TextBox3.Text = tb.Rows(counter)(4).ToString
            TextBox4.Text = tb.Rows(counter)(5).ToString
            TextBox5.Text = tb.Rows(counter)(6).ToString
            DateTimePicker1.Value = tb.Rows(counter)(7).ToString
            TextBox6.Text = tb.Rows(counter)(8).ToString
            TextBox7.Text = tb.Rows(counter)(9).ToString
            TextBox8.Text = tb.Rows(counter)(10).ToString
            TextBox9.Text = Val(TextBox6.Text) + Val(TextBox7.Text) + Val(TextBox8.Text)
            ComboBox2.SelectedItem = tb.Rows(counter)(11).ToString
            ComboBox3.SelectedItem = tb.Rows(counter)(12).ToString
            counter = counter - 1
        Else
            counter = -1
            MessageBox.Show("No Rows Found")
        End If
    End Sub

    Private Sub Next1_Click(sender As Object, e As EventArgs) Handles Next1.Click
        If counter >= 0 Then
            If tb.Rows.Count > counter Then

                ComboBox1.SelectedItem = tb.Rows(counter)(1).ToString
                TextBox1.Text = tb.Rows(counter)(2).ToString
                TextBox2.Text = tb.Rows(counter)(3).ToString
                TextBox3.Text = tb.Rows(counter)(4).ToString
                TextBox4.Text = tb.Rows(counter)(5).ToString
                TextBox5.Text = tb.Rows(counter)(6).ToString
                DateTimePicker1.Value = tb.Rows(counter)(7).ToString
                TextBox6.Text = tb.Rows(counter)(8).ToString
                TextBox7.Text = tb.Rows(counter)(9).ToString
                TextBox8.Text = tb.Rows(counter)(10).ToString
                TextBox9.Text = Val(TextBox6.Text) + Val(TextBox7.Text) + Val(TextBox8.Text)
                ComboBox2.SelectedItem = tb.Rows(counter)(11).ToString
                ComboBox3.SelectedItem = tb.Rows(counter)(12).ToString
                counter = counter + 1
            Else
                MessageBox.Show("No Rows Found")
            End If
        Else
            If TextBox1.Text.Length > 0 Then
                counter = 1
                If tb.Rows.Count > counter Then

                    ComboBox1.SelectedItem = tb.Rows(counter)(1).ToString
                    TextBox1.Text = tb.Rows(counter)(2).ToString
                    TextBox2.Text = tb.Rows(counter)(3).ToString
                    TextBox3.Text = tb.Rows(counter)(4).ToString
                    TextBox4.Text = tb.Rows(counter)(5).ToString
                    TextBox5.Text = tb.Rows(counter)(6).ToString
                    DateTimePicker1.Value = tb.Rows(counter)(7).ToString
                    TextBox6.Text = tb.Rows(counter)(8).ToString
                    TextBox7.Text = tb.Rows(counter)(9).ToString
                    TextBox8.Text = tb.Rows(counter)(10).ToString
                    TextBox9.Text = Val(TextBox6.Text) + Val(TextBox7.Text) + Val(TextBox8.Text)
                    ComboBox2.SelectedItem = tb.Rows(counter)(11).ToString
                    ComboBox3.SelectedItem = tb.Rows(counter)(12).ToString
                    counter = counter + 1
                Else
                    MessageBox.Show("No Rows Found")
                End If
            End If
        End If
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        TextBox9.Text = Val(TextBox6.Text) + Val(TextBox7.Text) + Val(TextBox8.Text)
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        TextBox9.Text = Val(TextBox6.Text) + Val(TextBox7.Text) + Val(TextBox8.Text)
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        TextBox9.Text = Val(TextBox6.Text) + Val(TextBox7.Text) + Val(TextBox8.Text)
    End Sub

End Class