Imports System.Data.SqlClient
Imports System.Data.DataSet
Imports MySql.Data.MySqlClient
Imports System.Data.OleDb

Public Class qlsp
    Dim duongdan As String
    Dim tenanh As String

    Dim a As New OpenFileDialog


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.DataGridView1.Rows(e.RowIndex)

            txtMa_sp.Text = row.Cells("ma_sp").Value.ToString
            txtTen_sp.Text = row.Cells("ten_sp").Value.ToString
            ComboBox1.Text = row.Cells("ma_loai").Value.ToString
            txtGia.Text = row.Cells("gia_sp").Value.ToString
            txtMota.Text = row.Cells("mota_sp").Value.ToString
            txtHinh.Text = row.Cells("hinhanh").Value.ToString

        End If
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MenuQL.Show()
        Me.Hide()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim piclocation As String
        a.Filter = Nothing
        piclocation = a.FileName
        a.ShowDialog()
        PictureBox1.Image = Image.FromFile(a.FileName)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtMa_sp.Text = "" Then
            MessageBox.Show("Mã sản phẩm không được để trống")
        ElseIf txtTen_sp.Text = "" Then
            MessageBox.Show("Tên sản phẩm không được để trống")
        ElseIf txtGia.Text = "" Then
            MessageBox.Show("Gía không được để trống")
        ElseIf txtMota.Text = "" Then
            MessageBox.Show("Ghi chú không được để trống")

        ElseIf ComboBox1.Text = "" Then
            MessageBox.Show("Mã loại không được để trống")
        Else
            Dim connec As New MySqlConnection("server =sql6.freesqldatabase.com;user=sql6131126;password=jyx9FJj7pM;database=sql6131126")
            Dim reader As MySqlDataReader
            Dim Command As New MySqlCommand

            Try
                connec.Open()
                Dim Query As String
                ' Dim sqlquery As String = String.Format("Select ma_sp as 'Mã Sản Phẩm',ten_sp as 'Tên Sản Phẩm',gia_sp as'Giá Sản Phẩm',mota_sp as'Mô Tả',ma_loai as 'Mã Loại',hinhanh as 'Hình Ảnh'")
                Query = "insert into sql6131126.sanpham (ma_sp,ten_sp,gia_sp,mota_sp,ma_loai,hinhanh) values ('" & txtMa_sp.Text & "','" & txtTen_sp.Text & "','" & txtGia.Text & "','" & txtMota.Text & "','" & ComboBox1.Text & "','" & txtHinh.Text & "')"
                Command.Connection = connec
                Command.CommandType = CommandType.Text
                Command.CommandText = Query

                reader = Command.ExecuteReader
                MessageBox.Show("Thêm thành công")
                txtMa_sp.Clear()
                txtTen_sp.Clear()
                txtGia.Clear()
                txtHinh.Clear()
                txtMota.Clear()

                connec.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            load_Table()
        End If
    End Sub



    Private Sub Frm_load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_Table()
        Dim connec As New MySqlConnection("server =sql6.freesqldatabase.com;user=sql6131126;password=jyx9FJj7pM;database=sql6131126")
        Dim reader As MySqlDataReader
        Try
            connec.Open()
            Dim Query As String
            Query = "SELECT ma_loai FROM sql6131126.theloai"
            Dim command As New MySqlCommand(Query, connec)
            reader = command.ExecuteReader
            While reader.Read
                Dim sMNSX = reader.GetInt32(0)

                ComboBox1.Items.Add(sMNSX)
            End While

            connec.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    ' Dim sqlquery As String = String.Format("Select ma_sp As 'Mã Sản Phẩm',ten_sp as 'Tên Sản Phẩm',gia_sp as'Giá Sản Phẩm',mota_sp as'Mô Tả',ma_loai as 'Mã Loại',hinhanh as 'Hình Ảnh'")
    '  Dim dtable As DataTable = DBAccess.
    '  End Sub


    Private Sub load_Table()
        Dim MySQLConnection As New MySqlConnection("server =sql6.freesqldatabase.com;user=sql6131126;password=jyx9FJj7pM;database=sql6131126")
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSoure As New BindingSource
        Try
            MySQLConnection.Open()
            Dim Query As String
            Query = "select * from sql6131126.sanpham"
            Dim command As New MySqlCommand(Query, MySQLConnection)
            SDA.SelectCommand = command
            SDA.Fill(dbDataSet)
            bSoure.DataSource = dbDataSet
            DataGridView1.DataSource = bSoure
            SDA.Update(dbDataSet)
            MySQLConnection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim connec As New MySqlConnection("server =sql6.freesqldatabase.com;user=sql6131126;password=jyx9FJj7pM;database=sql6131126")
        Dim reader As MySqlDataReader
        Try
            connec.Open()
            Dim Query As String
            Query = "delete from sql6131126.sanpham where ma_sp='" & txtMa_sp.Text & "'"
            Dim command As New MySqlCommand(Query, connec)
            reader = command.ExecuteReader
            MessageBox.Show("Delete thành công")
            txtMa_sp.Clear()
            txtTen_sp.Clear()
            txtGia.Clear()
            txtHinh.Clear()
            txtMota.Clear()


            connec.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        load_Table()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If txtMa_sp.Text = "" Then
            MessageBox.Show("Mã sản phẩm không được để trống")
        ElseIf txtTen_sp.Text = "" Then
            MessageBox.Show("Tên sản phẩm không được để trống")
        ElseIf txtGia.Text = "" Then
            MessageBox.Show("Gía không được để trống")
        ElseIf txtMota.Text = "" Then
            MessageBox.Show("Ghi chú không được để trống")
        ElseIf txtHinh.Text = "" Then
            MessageBox.Show("Ảnh không được để trống")
        ElseIf ComboBox1.Text = "" Then
            MessageBox.Show("Mã nhà SX không được để trống")
        Else
            Dim connec As New MySqlConnection("server =sql6.freesqldatabase.com;user=sql6131126;password=jyx9FJj7pM;database=sql6131126")
            Dim reader As MySqlDataReader
            Try
                connec.Open()
                Dim Query As String
                Query = "update sql6131126.sanpham set mota_sp='" & txtMota.Text & "',ma_loai='" & ComboBox1.Text & "',ten_sp='" & txtTen_sp.Text & "',gia_sp='" & txtGia.Text & "' where ma_sp='" & txtMa_sp.Text & "'"
                Dim command As New MySqlCommand(Query, connec)
                reader = command.ExecuteReader
                MessageBox.Show("Update thành công")
                txtMa_sp.Clear()
                txtTen_sp.Clear()
                txtGia.Clear()
                txtHinh.Clear()
                txtMota.Clear()


                connec.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            load_Table()
        End If
    End Sub
End Class