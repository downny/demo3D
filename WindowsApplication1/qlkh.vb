Imports MySql.Data.MySqlClient

Public Class qlkh
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtMa.Text = "" Then
            MessageBox.Show("Mã khách hàng không được để trống")
        ElseIf txtTen.Text = "" Then
            MessageBox.Show("Tên khách hàng không được để trống")
        ElseIf txtDia.Text = "" Then
            MessageBox.Show("Địa chỉ không được để trống")
        ElseIf txtdt.Text = "" Then
            MessageBox.Show("Số điện thoại không được để trống")
        Else
            Dim connec As New MySqlConnection("host=127.0.0.1;username=root;password='';database=assignment")
            Dim reader As MySqlDataReader
            Try
                connec.Open()
                Dim Query As String
                Query = "insert into assignment.khachhang (ma_kh,ten_kh,diachi_kh,sdt_kh) values ('" & txtMa.Text & "','" & txtTen.Text & "','" & txtDia.Text & "','" & txtdt.Text & "')"
                Dim command As New MySqlCommand(Query, connec)
                reader = command.ExecuteReader
                MessageBox.Show("Thêm thành công")
                txtMa.Clear()
                txtTen.Clear()
                txtDia.Clear()
                txtdt.Clear()

                connec.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            load_Table()
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.DataGridView1.Rows(e.RowIndex)

            txtMa.Text = row.Cells("ma_kh").Value.ToString
            txtTen.Text = row.Cells("ten_kh").Value.ToString
            txtDia.Text = row.Cells("diachi_kh").Value.ToString
            txtdt.Text = row.Cells("sdt_kh").Value.ToString


        End If
    End Sub

    Private Sub load_Table()
        Dim connec As New MySqlConnection("host=127.0.0.1;username=root;password='';database=assignment")
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSoure As New BindingSource
        Try
            connec.Open()
            Dim Query As String
            Query = "select * from assignment.khachhang"
            Dim command As New MySqlCommand(Query, connec)
            SDA.SelectCommand = command
            SDA.Fill(dbDataSet)
            bSoure.DataSource = dbDataSet
            DataGridView1.DataSource = bSoure
            SDA.Update(dbDataSet)
            connec.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ThongTinKH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_Table()
    End Sub

    Private Sub txtMKH_TextChanged(sender As Object, e As EventArgs) Handles txtMa.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If txtMa.Text = "" Then
            MessageBox.Show("Mã khách hàng không được để trống")
        ElseIf txtTen.Text = "" Then
            MessageBox.Show("Tên khách hàng không được để trống")
        ElseIf txtDia.Text = "" Then
            MessageBox.Show("Địa chỉ không được để trống")
        ElseIf txtdt.Text = "" Then
            MessageBox.Show("Số điện thoại không được để trống")
        Else
            Dim connec As New MySqlConnection("host=127.0.0.1;username=root;password='';database=assignment")
            Dim reader As MySqlDataReader
            Try
                connec.Open()
                Dim Query As String
                Query = "update assignment.khachhang set ten_kh='" & txtTen.Text & "',diachi_kh='" & txtDia.Text & "',sdt_kh='" & txtdt.Text & "' where ma_kh='" & txtMa.Text & "'"
                Dim command As New MySqlCommand(Query, connec)
                reader = command.ExecuteReader
                MessageBox.Show("Update thành công")
                txtMa.Clear()
                txtTen.Clear()
                txtDia.Clear()
                txtdt.Clear()


                connec.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            load_Table()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim connec As New MySqlConnection("host=127.0.0.1;username=root;password='';database=assignment")
        Dim reader As MySqlDataReader
        Try
            connec.Open()
            Dim Query As String
            Query = "delete from assignment.khachhang where ma_kh='" & txtMa.Text & "'"
            Dim command As New MySqlCommand(Query, connec)
            reader = command.ExecuteReader
            MessageBox.Show("Delete thành công")
            txtMa.Clear()
            txtTen.Clear()
            txtDia.Clear()
            txtdt.Clear()

            connec.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        load_Table()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MenuQL.Show()
        Me.Hide()

    End Sub
End Class
