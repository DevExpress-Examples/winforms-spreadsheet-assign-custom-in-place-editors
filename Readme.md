<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128613434/19.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T385401)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Spreadsheet_CustomCellEditors/Form1.cs) (VB: [Form1.vb](./VB/Spreadsheet_CustomCellEditors/Form1.vb))
<!-- default file list end -->
# How to assign custom in-place editors to worksheet cells  


This example demonstrates how to use custom editors for in-place editing of cell content. Both predefined editors supported by the <strong>SpreadsheetControl</strong> for in-place editing (<a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraEditorsComboBoxEdittopic">ComboBoxEdit</a>, <a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraEditorsDateEdittopic">DateEdit</a>, and <a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraEditorsCheckEdittopic">CheckEdit</a>) and the custom editor (<a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraEditorsSpinEdittopic">SpinEdit</a>) are used to edit cells located in the specific columns of a worksheet table.<br>To assign an in-place editor of a predefined type to a specific cell range in a worksheet, use the <strong>Add</strong> method of the <a href="https://documentation.devexpress.com/#CoreLibraries/clsDevExpressSpreadsheetCustomCellInplaceEditorCollectiontopic">CustomCellInplaceEditorCollection</a> collection, which stores the custom cell editors specified in a worksheet.<br>To assign your own custom editor to a cell, handle the <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraSpreadsheetSpreadsheetControl_CustomCellEdittopic">SpreadsheetControl.CustomCellEdit</a> event. This event fires when a user is about to start editing a cell and allows you to supply a custom in-place editor to the edited cell by setting a corresponding <a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraEditorsRepositoryRepositoryItemtopic">RepositoryItem</a> descendant to the event's <strong>RepositoryItem</strong> parameter.

<br/>


