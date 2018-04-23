Imports System
Imports System.Data
Imports System.Windows

Namespace BubbleSettings_CustomMarkerTemplate
    Partial Public Class MainWindow
        Inherits Window

        Private Const filepath As String = "..\..\Earthquakes.xml"

        Private minMagnitude As Double = 7
        Private maxMagnitude As Double = 9
        Private table As DataTable

        Public ReadOnly Property DataTable() As DataTable
            Get
                Return table
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim dataSet As New DataSet()
            dataSet.ReadXml(filepath)
            table = dataSet.Tables(0)

            table.ReadXml(filepath)
            table.DefaultView.RowFilter = String.Format("(mag >= {0}) AND (mag <= {1})", minMagnitude, maxMagnitude)
            Me.DataContext = Me
        End Sub
    End Class
End Namespace
