package Excel

import (
	"fmt"
	"strconv"

	excelize "github.com/xuri/excelize/v2"
)

type Workbook struct {
	Workbook *excelize.File
}

func NewWorkbook() *Workbook {
	file := excelize.NewFile()
	return &Workbook{file}
}

func (wb *Workbook) AddSheet(sheetName string) {
	wb.Workbook.NewSheet(sheetName)
}

func (wb *Workbook) AddRowToSheet(sheetName string, cells []interface{}) {
	rows, _ := wb.Workbook.GetRows(sheetName)
	rowIndex := len(rows) + 1
	for cellIndex, cellValue := range cells {
		cell := GetCellName(cellIndex, rowIndex)
		wb.Workbook.SetCellValue(sheetName, cell, cellValue)
	}
}

func (wb *Workbook) Write(destinationPath string) {
	err := wb.Workbook.SaveAs(destinationPath)
	if err != nil {
		fmt.Printf("Failed to save Excel file: %+v", err)
	}
}

func GetCellName(colIndex, rowIndex int) string {
	colName := ""
	for colIndex >= 0 {
		colName = fmt.Sprintf("%c", 'A'+colIndex%26) + colName
		colIndex = colIndex/26 - 1
	}
	return colName + strconv.Itoa(rowIndex)
}
