Imports System
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.Spreadsheet
Imports DevExpress.XtraEditors.Repository

Namespace Spreadsheet_CustomCellEditors

    Public Partial Class Form1
        Inherits RibbonForm

        Public Sub New()
            InitializeComponent()
            spreadsheetControl.LoadDocument("Documents\Document.xlsx", DocumentFormat.Xlsx)
            AddHandler spreadsheetControl.DocumentLoaded, AddressOf spreadsheetControl1_DocumentLoaded
#Region "#CustomCellEdit"
            AddHandler spreadsheetControl.CustomCellEdit, AddressOf spreadsheetControl1_CustomCellEdit
        ' ...
#End Region  ' #CustomCellEdit
        End Sub

        Private Sub spreadsheetControl1_DocumentLoaded(ByVal sender As Object, ByVal e As EventArgs)
            BindCustomEditors()
        End Sub

        Private Sub BindCustomEditors()
            Dim worksheet As Worksheet = spreadsheetControl.Document.Worksheets("Sales report")
#Region "#PredefinedEditors"
            ' Use a date editor as the in-place editor for cells located in the "Order Date" column of the worksheet table.
            Dim dateEditRange As CellRange = worksheet("Table[Order Date]")
            worksheet.CustomCellInplaceEditors.Add(dateEditRange, CustomCellInplaceEditorType.DateEdit)
            ' Use a combo box editor as the in-place editor for cells located in the "Category" column of the worksheet table.
            ' The editor's items are obtained from a cell range in the current worksheet.
            Dim comboBoxRange As CellRange = worksheet("Table[Category]")
            worksheet.CustomCellInplaceEditors.Add(comboBoxRange, CustomCellInplaceEditorType.ComboBox, ValueObject.FromRange(worksheet("J3:J9")))
            ' Use a check editor as the in-place editor for cells located in the "Discount" column of the worksheet table.
            Dim checkBoxRange As CellRange = worksheet("Table[Discount]")
            worksheet.CustomCellInplaceEditors.Add(checkBoxRange, CustomCellInplaceEditorType.CheckBox)
            ' Use the custom control (SpinEdit) as the in-place editor for cells located in the "Quantity" column of the worksheet table.
            ' To provide the required editor, handle the CustomCellEdit event. 
            Dim customRange As CellRange = worksheet("Table[Qty]")
            worksheet.CustomCellInplaceEditors.Add(customRange, CustomCellInplaceEditorType.Custom, "MySpinEdit")
#End Region  ' #PredefinedEditors
        End Sub

#Region "#CustomCellEdit"
        Private Sub spreadsheetControl1_CustomCellEdit(ByVal sender As Object, ByVal e As DevExpress.XtraSpreadsheet.SpreadsheetCustomCellEditEventArgs)
            ' Specify a type of the custom editor assigned to cells of the "Quantity" table column.
            ' To identify the custom editor, use a value of ValueObject associated with it. 
            If e.ValueObject.IsText AndAlso Equals(e.ValueObject.TextValue, "MySpinEdit") Then
                ' Create a repository item corresponding to a SpinEdit control and specify its settings.
                Dim repository As RepositoryItemSpinEdit = New RepositoryItemSpinEdit()
                repository.AutoHeight = False
                repository.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
                repository.MinValue = 1
                repository.MaxValue = 1000
                repository.IsFloatValue = False
                ' Assign the SpinEdit editor to a cell.
                e.RepositoryItem = repository
            End If
        End Sub
#End Region  ' #CustomCellEdit
    End Class
End Namespace
