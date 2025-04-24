package Task5;

import org.apache.poi.ss.usermodel.*;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

import java.io.*;
import java.util.*;

public class ExcelProcessor {
    public static void main(String[] args) {
        String inputFile = "products.xlsx";
        String outputFile = "filtered_products.xlsx";

        double totalPrice = 0;
        int count = 0;

        List<Row> filteredRows = new ArrayList<>();

        try (FileInputStream fis = new FileInputStream(inputFile);
             Workbook workbook = new XSSFWorkbook(fis)) {

            Sheet sheet = workbook.getSheetAt(0);
            int priceColumnIndex = 2;

            Iterator<Row> rowIterator = sheet.iterator();
            Row header = rowIterator.next(); // заглавен ред

            while (rowIterator.hasNext()) {
                Row row = rowIterator.next();
                Cell priceCell = row.getCell(priceColumnIndex);

                if (priceCell != null && priceCell.getCellType() == CellType.NUMERIC) {
                    double price = priceCell.getNumericCellValue();

                    if (price > 100) {
                        filteredRows.add(row);
                        totalPrice += price;
                        count++;
                    }
                }
            }

            double average = count > 0 ? totalPrice / count : 0;
            System.out.printf("Average price of filtered items: %.2f%n", average);

            Workbook newWorkbook = new XSSFWorkbook();
            Sheet newSheet = newWorkbook.createSheet("Filtered");

            Row newHeader = newSheet.createRow(0);
            for (int i = 0; i < header.getLastCellNum(); i++) {
                Cell cell = newHeader.createCell(i);
                cell.setCellValue(header.getCell(i).getStringCellValue());
            }

            int rowIndex = 1;
            for (Row originalRow : filteredRows) {
                Row newRow = newSheet.createRow(rowIndex++);
                for (int i = 0; i < originalRow.getLastCellNum(); i++) {
                    Cell oldCell = originalRow.getCell(i);
                    if (oldCell != null) {
                        Cell newCell = newRow.createCell(i);
                        switch (oldCell.getCellType()) {
                            case STRING -> newCell.setCellValue(oldCell.getStringCellValue());
                            case NUMERIC -> newCell.setCellValue(oldCell.getNumericCellValue());
                        }
                    }
                }
            }

            Row summaryRow = newSheet.createRow(rowIndex);
            summaryRow.createCell(0).setCellValue("Average price:");
            summaryRow.createCell(1).setCellValue(average);

            try (FileOutputStream fos = new FileOutputStream(outputFile)) {
                newWorkbook.write(fos);
            }

            newWorkbook.close();
            System.out.println("Filtered data written to: " + outputFile);

        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
