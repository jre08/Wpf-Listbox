Class MainWindow

    Public Class ListViewItemTemplate
        Public Property ContactName As String
        Public Property Address As String
        Public Property City As String
    End Class
    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        Dim itemsList As New List(Of ListViewItemTemplate)
        Dim item As New ListViewItemTemplate
        item.ContactName = "FileName A"
        item.Address = "FilePath A"
        item.City = "FileType A"
        itemsList.Add(item)
        item = New ListViewItemTemplate
        item.ContactName = "FileName B"
        item.Address = "FilePath B"
        item.City = "FileType B"
        itemsList.Add(item)

        listBox1.ItemsSource = itemsList

    End Sub

    Private Sub listBox1_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles listBox1.SelectionChanged
        'Dim node As XmlNode = CType(listBox1.SelectedItem, ListBoxItem).Tag

        Dim myListBoxItem As ListBoxItem = DirectCast(listBox1.ItemContainerGenerator.ContainerFromItem(listBox1.SelectedItem), ListBoxItem)
        Dim myContentPresenter As ContentPresenter = FindVisualChild(Of ContentPresenter)(myListBoxItem)
        Dim myDataTemplate As DataTemplate = myContentPresenter.ContentTemplate

        Dim myTextBlock As TextBlock = DirectCast(myDataTemplate.FindName("Contactname", myContentPresenter), TextBlock)
        MessageBox.Show("The text of the named TextBlock in the DataTemplate of the selected list item: " + myTextBlock.Text)


        'MsgBox(Convert.ToString(listBox1.Content) & " Item was selected.", Title
    End Sub

    Private Function FindVisualChild(Of childItem As DependencyObject)(obj As DependencyObject) As childItem


        For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(obj) - 1


            Dim child As DependencyObject = VisualTreeHelper.GetChild(obj, i)

            If child IsNot Nothing AndAlso TypeOf child Is childItem Then

                Return DirectCast(child, childItem)
            Else



                Dim childOfChild As childItem = FindVisualChild(Of childItem)(child)

                If childOfChild IsNot Nothing Then

                    Return childOfChild

                End If

            End If
        Next

        Return Nothing

    End Function

End Class
