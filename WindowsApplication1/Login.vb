Public Class Login


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (txtId.Text = "admin") Or (txtPw.Text = "admin") Then
            MenuQL.Show()
            Me.Hide()

        Else
            MessageBox.Show("tài khoản hoặc mật khẩu không đúng ", "lỗi", MessageBoxButtons.OK)
        End If




    End Sub
End Class
