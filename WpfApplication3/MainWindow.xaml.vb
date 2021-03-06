﻿Imports System.Xml.Linq
Imports System.Net
Imports System.Xml
Imports System.Globalization
Imports Microsoft.Maps.MapControl.WPF
Imports Microsoft.Maps.MapControl.WPF.Design





Partial Public Class MainWindow
    Private locConverter As New LocationConverter()
    Public Property Center As Location()


    Public Class ListViewItemTemplate
        Public Property ContactName As String
        Public Property Address As String
        Public Property City As String
        Public Property imgDayIcon As String
    End Class

    Function loadDayIcon(iconpath)
        Dim myImage3 As New Image
        Dim bi3 As New BitmapImage
        bi3.BeginInit()
        bi3.UriSource = New Uri(iconpath)
        bi3.EndInit()
        'myImage3.Stretch = Stretch.Fill
        'myImage3.Source = bi3
        Return bi3

    End Function
    Sub _4day()
        Dim itemsList As New List(Of ListViewItemTemplate)
        Dim item As New ListViewItemTemplate
        'item.ContactName = "FileName A"
        'item.Address = "FilePath A"
        'item.City = "FileType A"
        'itemsList.Add(item)

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
        'picload(picpath)
        'MsgBox(picpath)
        item = New ListViewItemTemplate
        item.imgDayIcon = picpath
        item.ContactName = nodes1.Item(3).InnerText
        item.Address = nodes1.Item(4).InnerText
        item.City = nodes1.Item(6).InnerText
        itemsList.Add(item)

        'Night one
        nodes1 = xInfo.SelectNodes("/response/forecast/txt_forecast/forecastdays/forecastday[position()=2]/*")
        picpath = nodes1.Item(2).InnerText
        ' picboxN1.Load(picpath)
        item = New ListViewItemTemplate
        item.imgDayIcon = picpath
        item.ContactName = nodes1.Item(3).InnerText
        item.Address = nodes1.Item(4).InnerText
        item.City = nodes1.Item(6).InnerText
        itemsList.Add(item)

        ''Day two
        nodes1 = xInfo.SelectNodes("/response/forecast/txt_forecast/forecastdays/forecastday[position()=3]/*")
        picpath = nodes1.Item(2).InnerText
        item = New ListViewItemTemplate
        item.imgDayIcon = picpath
        item.ContactName = nodes1.Item(3).InnerText
        item.Address = nodes1.Item(4).InnerText
        item.City = nodes1.Item(6).InnerText
        itemsList.Add(item)

        ''Night two
        nodes1 = xInfo.SelectNodes("/response/forecast/txt_forecast/forecastdays/forecastday[position()=4]/*")
        picpath = nodes1.Item(2).InnerText
        'picboxN2.Load(picpath)
        item = New ListViewItemTemplate
        item.imgDayIcon = picpath
        item.ContactName = nodes1.Item(3).InnerText
        item.Address = nodes1.Item(4).InnerText
        item.City = nodes1.Item(6).InnerText
        itemsList.Add(item)

        ''Day three
        nodes1 = xInfo.SelectNodes("/response/forecast/txt_forecast/forecastdays/forecastday[position()=5]/*")
        picpath = nodes1.Item(2).InnerText
        'picboxD3.Load(picpath)
        item = New ListViewItemTemplate
        item.imgDayIcon = picpath
        item.ContactName = nodes1.Item(3).InnerText
        item.Address = nodes1.Item(4).InnerText
        item.City = nodes1.Item(6).InnerText
        itemsList.Add(item)

        ''Night three
        nodes1 = xInfo.SelectNodes("/response/forecast/txt_forecast/forecastdays/forecastday[position()=6]/*")
        picpath = nodes1.Item(2).InnerText
        ' picboxN3.Load(picpath)
        item = New ListViewItemTemplate
        item.imgDayIcon = picpath
        item.ContactName = nodes1.Item(3).InnerText
        item.Address = nodes1.Item(4).InnerText
        item.City = nodes1.Item(6).InnerText
        itemsList.Add(item)

        ''Day four
        nodes1 = xInfo.SelectNodes("/response/forecast/txt_forecast/forecastdays/forecastday[position()=7]/*")
        picpath = nodes1.Item(2).InnerText
        'picboxD4.Load(picpath)
        item = New ListViewItemTemplate
        item.imgDayIcon = picpath
        item.ContactName = nodes1.Item(3).InnerText
        item.Address = nodes1.Item(4).InnerText
        item.City = nodes1.Item(6).InnerText
        itemsList.Add(item)

        ''Night Four
        nodes1 = xInfo.SelectNodes("/response/forecast/txt_forecast/forecastdays/forecastday[position()=8]/*")
        picpath = nodes1.Item(2).InnerText
        ' picboxN4.Load(picpath)
        item = New ListViewItemTemplate
        item.imgDayIcon = picpath
        item.ContactName = nodes1.Item(3).InnerText
        item.Address = nodes1.Item(4).InnerText
        item.City = nodes1.Item(6).InnerText
        itemsList.Add(item)


        listBox1.ItemsSource = itemsList
    End Sub

    Private Sub picload(picpath)
        'Dim node As XmlNode = CType(listBox1.SelectedItem, ListBoxItem).Tag

        Dim myListBoxItem As ListBoxItem = DirectCast(listBox1.ItemContainerGenerator.ContainerFromItem(listBox1.SelectedItem), ListBoxItem)
        Dim myContentPresenter As ContentPresenter = FindVisualChild(Of ContentPresenter)(myListBoxItem)
        Dim myDataTemplate As DataTemplate = myContentPresenter.ContentTemplate

        Dim myTextBlock As Image = DirectCast(myDataTemplate.FindName("imgDayIcon", myContentPresenter), Image)
        MessageBox.Show(myTextBlock.Source.ToString)

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

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Call _4day()
        Call _weatherMap()

    End Sub

    Sub _weatherMap()
        'Dim center As Location = CType(locConverter.ConvertFrom(taginfo))
        Dim zoom As Double = System.Convert.ToDouble(4.0)
        ' Set the map view
        'wthrmap.SetView(New Location(35.8659551749783, -95.2603628139199), zoom)

    End Sub
    Private Sub listBox1_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles listBox1.SelectionChanged
        Dim myListBoxItem As ListBoxItem = DirectCast(listBox1.ItemContainerGenerator.ContainerFromItem(listBox1.SelectedItem), ListBoxItem)
        Dim myContentPresenter As ContentPresenter = FindVisualChild(Of ContentPresenter)(myListBoxItem)
        Dim myDataTemplate As DataTemplate = myContentPresenter.ContentTemplate

        Dim myTextBlock As Image = DirectCast(myDataTemplate.FindName("imgDayIcon", myContentPresenter), Image)
        'MessageBox.Show(myTextBlock.Source.ToString)
    End Sub

    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        'infobox.Text = wthrmap.Center.ToString
        Dim frm = New Window1
        frm.Show()
    End Sub
End Class
