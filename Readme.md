<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128613434/19.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T385401)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Spreadsheet for WinForms - How to Assign Custom In-Place Editors to Worksheet Cells

This example demonstrates how to use custom editors for in-place editing of cell content. Both predefined editors supported by the **SpreadsheetControl** for in-place editing ([ComboBoxEdit](https://docs.devexpress.com/WindowsForms/DevExpress.XtraEditors.ComboBoxEdit), [DateEdit](https://docs.devexpress.com/WindowsForms/DevExpress.XtraEditors.DateEdit), and [CheckEdit](https://docs.devexpress.com/WindowsForms/DevExpress.XtraEditors.CheckEdit)) and the custom editor ([SpinEdit](https://docs.devexpress.com/WindowsForms/DevExpress.XtraEditors.SpinEdit)) are used to edit cells located in the specific columns of a worksheet table.

## Implementation Details

To assign an in-place editor of a predefined type to a specific cell range in a worksheet, use the `Add` method of the [CustomCellInplaceEditorCollection](https://docs.devexpress.com/OfficeFileAPI/DevExpress.Spreadsheet.CustomCellInplaceEditorCollection) collection, which stores the custom cell editors specified in a worksheet.

To assign your own custom editor to a cell, handle the [SpreadsheetControl.CustomCellEdit](https://docs.devexpress.com/WindowsForms/DevExpress.XtraSpreadsheet.SpreadsheetControl.CustomCellEdit) event. This event fires when a user is about to start editing a cell. and allows you by Set a corresponding [RepositoryItem](https://docs.devexpress.com/WindowsForms/DevExpress.XtraEditors.Repository.RepositoryItem) descendant to the event's `RepositoryItem` parameter to supply a custom in-place editor to the edited cell.

## Files to Review

* [Form1.cs](./CS/Spreadsheet_CustomCellEditors/Form1.cs) (VB: [Form1.vb](./VB/Spreadsheet_CustomCellEditors/Form1.vb))

## Documentation

* [Custom Cell In-place Editors](https://docs.devexpress.com/WindowsForms/18170/controls-and-libraries/spreadsheet/cell-basics/custom-cell-in-place-editors)
