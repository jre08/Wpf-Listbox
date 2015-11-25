Imports System.Xml.Linq
Imports System.Net
Imports System.Xml

Class MainWindow

    Public Class ListViewItemTemplate
        Public Property ContactName As String
        Public Property Address As String
        Public Property City As String
    End Class
    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        Dim itemsList As New List(Of ListViewItemTemplate)
        Dim item As New ListViewItemTemplate
        'item.ContactName = "FileName A"
        'item.Address = "FilePath A"
        'item.City = "FileType A"
        'itemsList.Add(item)
        item = New ListViewItemTemplate
        'item.ContactName = "FileName B"
        'item.Address = "FilePath B"
        'item.City = "FileType B"
        'itemsList.Add(item)

        Dim xUrl As String =
 "http://api.wunderground.com/api/8390d409d9f2d532/forecast/q/FL/Tallahassee.xml"
        Dim xInfo As New XmlDocument
        xInfo.Load(xUrl)
        Dim nodes1 As XmlNodeList
        Dim picpath As String

        'Day one
        nodes1 = xInfo.SelectNodes("/response/forecast/txt_forecast/forecastdays/forecastday[position()=1]/*")
        picpath = nodes1.Item(2).InnerText
        'picboxD1.Load(picpath)
        item = New ListViewItemTemplate
        item.ContactName = nodes1.Item(3).InnerText
        item.Address = nodes1.Item(4).InnerText
        item.City = nodes1.Item(6).InnerText
        itemsList.Add(item)

        'Night one
        nodes1 = xInfo.SelectNodes("/response/forecast/txt_forecast/forecastdays/forecastday[position()=2]/*")
        picpath = nodes1.Item(2).InnerText
        ' picboxN1.Load(picpath)
        item = New ListViewItemTemplate
        item.ContactName = nodes1.Item(3).InnerText
        item.Address = nodes1.Item(4).InnerText
        item.City = nodes1.Item(6).InnerText
        itemsList.Add(item)

        ''Day two
        nodes1 = xInfo.SelectNodes("/response/forecast/txt_forecast/forecastdays/forecastday[position()=3]/*")
        picpath = nodes1.Item(2).InnerText
        item = New ListViewItemTemplate
        item.ContactName = nodes1.Item(3).InnerText
        item.Address = nodes1.Item(4).InnerText
        item.City = nodes1.Item(6).InnerText
        itemsList.Add(item)

        ''Night two
        nodes1 = xInfo.SelectNodes("/response/forecast/txt_forecast/forecastdays/forecastday[position()=4]/*")
        picpath = nodes1.Item(2).InnerText
        'picboxN2.Load(picpath)
        item = New ListViewItemTemplate
        item.ContactName = nodes1.Item(3).InnerText
        item.Address = nodes1.Item(4).InnerText
        item.City = nodes1.Item(6).InnerText
        itemsList.Add(item)

        ''Day three
        nodes1 = xInfo.SelectNodes("/response/forecast/txt_forecast/forecastdays/forecastday[position()=5]/*")
        picpath = nodes1.Item(2).InnerText
        'picboxD3.Load(picpath)
        item = New ListViewItemTemplate
        item.ContactName = nodes1.Item(3).InnerText
        item.Address = nodes1.Item(4).InnerText
        item.City = nodes1.Item(6).InnerText
        itemsList.Add(item)

        ''Night three
        nodes1 = xInfo.SelectNodes("/response/forecast/txt_forecast/forecastdays/forecastday[position()=6]/*")
        picpath = nodes1.Item(2).InnerText
        ' picboxN3.Load(picpath)
        item = New ListViewItemTemplate
        item.ContactName = nodes1.Item(3).InnerText
        item.Address = nodes1.Item(4).InnerText
        item.City = nodes1.Item(6).InnerText
        itemsList.Add(item)

        ''Day four
        nodes1 = xInfo.SelectNodes("/response/forecast/txt_forecast/forecastdays/forecastday[position()=7]/*")
        picpath = nodes1.Item(2).InnerText
        'picboxD4.Load(picpath)
        item = New ListViewItemTemplate
        item.ContactName = nodes1.Item(3).InnerText
        item.Address = nodes1.Item(4).InnerText
        item.City = nodes1.Item(6).InnerText
        itemsList.Add(item)

        ''Night Four
        nodes1 = xInfo.SelectNodes("/response/forecast/txt_forecast/forecastdays/forecastday[position()=8]/*")
        picpath = nodes1.Item(2).InnerText
        ' picboxN4.Load(picpath)
        item = New ListViewItemTemplate
        item.ContactName = nodes1.Item(3).InnerText
        item.Address = nodes1.Item(4).InnerText
        item.City = nodes1.Item(6).InnerText


        listBox1.ItemsSource = itemsList



    End Sub

    Private Sub listBox1_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles listBox1.SelectionChanged
        'Dim node As XmlNode = CType(listBox1.SelectedItem, ListBoxItem).Tag

        Dim myListBoxItem As ListBoxItem = DirectCast(listBox1.ItemContainerGenerator.ContainerFromItem(listBox1.SelectedItem), ListBoxItem)
        Dim myContentPresenter As ContentPresenter = FindVisualChild(Of ContentPresenter)(myListBoxItem)
        Dim myDataTemplate As DataTemplate = myContentPresenter.ContentTemplate

        Dim myTextBlock As TextBlock = DirectCast(myDataTemplate.FindName("Contactname", myContentPresenter), TextBlock)
        'MessageBox.Show("The text of the named TextBlock in the DataTemplate of the selected list item: " + myTextBlock.Text)

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
