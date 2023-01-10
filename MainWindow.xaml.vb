Imports System.Data
Imports System.Data.SqlClient

Class MainWindow

    Dim con As New SqlConnection("Data Source=PROCYON-W10\SQLEXPRESS;Initial Catalog=ProgrammingDB;User ID=Pooja;Password=***********;Trusted_Connection=False;MultipleActiveResultSets=true;integrated Security=true")

    Private Sub Btn_insert_Click(sender As Object, e As RoutedEventArgs) Handles Btn_insert.Click
        Dim pid As Integer = Txtpid.Text
        Dim iname As String = Txt_name.Text
        Dim design As String = Txt_design.Text
        Dim color As String = Combocolor.Text
        Dim insertdate As DateTime = Datee.Text
        Dim wtype As String = ""

        If Radioallowed.IsChecked Then
            wtype = "Allowed"
        Else
            wtype = "Not Allowed"

        End If
        Dim con As New SqlConnection("Data Source=PROCYON-W10\SQLEXPRESS;Initial Catalog=ProgrammingDB;User ID=Pooja;Password=***********;Trusted_Connection=False;MultipleActiveResultSets=true;integrated Security=true")
        con.Open()
        Dim command As New SqlCommand("Insert into Product_Setup_Tab values('" & pid & "','" & iname & "','" & design & "','" & color & "','" & insertdate & "','" & wtype & "')", con)
        command.ExecuteNonQuery()
        con.Close()

        MessageBox.Show("Inserted Successfully")
        LoaddatainGrid()
    End Sub
    Private Sub LoaddatainGrid()
        Dim command As New SqlCommand("select * from Product_Setup_Tab ", con)
        Dim sda As New SqlDataAdapter(command)
        Dim dt As New DataTable
        sda.Fill(dt)
        DataGridView1.ItemsSource = dt.DefaultView
    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        LoaddatainGrid()
    End Sub

    Private Sub Btn_update_Click(sender As Object, e As RoutedEventArgs) Handles Btn_update.Click
        Dim pid As Integer = Txtpid.Text
        Dim iname As String = Txt_name.Text
        Dim design As String = Txt_design.Text
        Dim color As String = Combocolor.Text
        Dim insertdate As DateTime = Datee.Text
        Dim wtype As String = ""

        If Radioallowed.IsChecked Then
            wtype = "Allowed"
        Else
            wtype = "Not Allowed"

        End If
        Dim con As New SqlConnection("Data Source=PROCYON-W10\SQLEXPRESS;Initial Catalog=ProgrammingDB;User ID=Pooja;Password=***********;Trusted_Connection=False;MultipleActiveResultSets=true;integrated Security=true")
        con.Open()
        Dim command As New SqlCommand("Update Product_Setup_Tab set ItemName='" & iname & "', Design='" & design & "', Color='" & color & "', ItemDate='" & insertdate & "', WarrantyType='" & wtype & "' where Product_ID='" & pid & "'", con)
        command.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("Updated Successfully")
        LoaddatainGrid()
    End Sub

    Private Sub Btn_delete_Click(sender As Object, e As RoutedEventArgs) Handles Btn_delete.Click
        Dim pid As Integer = Txtpid.Text
        con.Open()
        Dim command As New SqlCommand("delete Product_Setup_Tab where Product_ID='" & pid & "'", con)
        command.ExecuteNonQuery()
        MessageBox.Show("Deleted Successfully")
        LoaddatainGrid()
        con.Close()
    End Sub

    Private Sub Btn_search_Click(sender As Object, e As RoutedEventArgs) Handles Btn_search.Click
        Dim pid As Integer = Txtpid.Text
        Dim command As New SqlCommand("select * from Product_Setup_Tab where product_ID='" & pid & "'", con)
        Dim sda As New SqlDataAdapter(command)
        Dim dt As New DataTable
        sda.Fill(dt)
        DataGridView1.ItemsSource = dt.DefaultView
    End Sub

    Private Sub Btn_display_Click(sender As Object, e As RoutedEventArgs) Handles Btn_display.Click
        Dim command As New SqlCommand("select * from Product_Setup_Tab", con)
        Dim sda As New SqlDataAdapter(command)
        Dim dt As New DataTable
        sda.Fill(dt)
        DataGridView1.ItemsSource = dt.DefaultView
    End Sub

    Private Sub Btn_clear_Click(sender As Object, e As RoutedEventArgs) Handles Btn_clear.Click
        Txtpid.Text = ""
        Txt_name.Text = ""
        Txt_design.Text = ""
        Combocolor.Text = ""
        Datee.Text = ""

    End Sub
End Class
