using System;
using DevExpress.XtraBars.Ribbon;
using DevExpress.Spreadsheet;
using DevExpress.XtraEditors.Repository;

namespace Spreadsheet_CustomCellEditors
{
    public partial class Form1 : RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
            spreadsheetControl.LoadDocument("Documents\\Document.xlsx", DocumentFormat.Xlsx);

            spreadsheetControl.DocumentLoaded += spreadsheetControl1_DocumentLoaded;
            #region #CustomCellEdit
            spreadsheetControl.CustomCellEdit += spreadsheetControl1_CustomCellEdit;
            // ...
            #endregion #CustomCellEdit
        }

        private void spreadsheetControl1_DocumentLoaded(object sender, EventArgs e)
        {
            BindCustomEditors();
        }

        private void BindCustomEditors()
        {
            Worksheet worksheet = spreadsheetControl.Document.Worksheets["Sales report"];

            #region #PredefinedEditors
            // Use a date editor as the in-place editor for cells located in the "Order Date" column of the worksheet table.
            Range dateEditRange = worksheet["Table[Order Date]"];
            worksheet.CustomCellInplaceEditors.Add(dateEditRange, CustomCellInplaceEditorType.DateEdit);

            // Use a combo box editor as the in-place editor for cells located in the "Category" column of the worksheet table.
            // The editor's items are obtained from a cell range in the current worksheet.
            Range comboBoxRange = worksheet["Table[Category]"];
            worksheet.CustomCellInplaceEditors.Add(comboBoxRange, CustomCellInplaceEditorType.ComboBox, ValueObject.FromRange(worksheet["J3:J9"]));

            // Use a check editor as the in-place editor for cells located in the "Discount" column of the worksheet table.
            Range checkBoxRange = worksheet["Table[Discount]"];
            worksheet.CustomCellInplaceEditors.Add(checkBoxRange, CustomCellInplaceEditorType.CheckBox);

            // Use the custom control (SpinEdit) as the in-place editor for cells located in the "Quantity" column of the worksheet table.
            // To provide the required editor, handle the CustomCellEdit event. 
            Range customRange = worksheet["Table[Qty]"];
            worksheet.CustomCellInplaceEditors.Add(customRange, CustomCellInplaceEditorType.Custom, "MySpinEdit");
            #endregion #PredefinedEditors
        }

        #region #CustomCellEdit
        private void spreadsheetControl1_CustomCellEdit(object sender, DevExpress.XtraSpreadsheet.SpreadsheetCustomCellEditEventArgs e)
        {
            // Specify a type of the custom editor assigned to cells of the "Quantity" table column.
            // To identify the custom editor, use a value of ValueObject associated with it. 
            if (e.ValueObject.IsText && e.ValueObject.TextValue == "MySpinEdit")
            {
                // Create a repository item corresponding to a SpinEdit control and specify its settings.
                RepositoryItemSpinEdit repository = new RepositoryItemSpinEdit();
                repository.AutoHeight = false;
                repository.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

                repository.MinValue = 1;
                repository.MaxValue = 1000;
                repository.IsFloatValue = false;
                // Assign the SpinEdit editor to a cell.
                e.RepositoryItem = repository;
            }
        }
        #endregion #CustomCellEdit
    }
}