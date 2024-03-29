﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Grid;
using Vehicles_Reservation_System.Database;
using Syncfusion.Pdf.Tables;
using System.Data;

namespace Vehicles_Reservation_System.Logic
{
    class PDFWriter
    {
        public void reportWriter(int totalBookings, double totalIncome, double thisMonthIncome, int thisMonthBookings,
                                 int totalCustomers, int thisMonthCustomers, int totalVehicles, int thisMonthVehicles,
                                 int totalSedans, int totalHybrids, int totalJeeps)
        {
            //Create a new PDF document.
            PdfDocument report = new PdfDocument();

            //Add a page to the document.
            PdfPage page = report.Pages.Add();

            //DataTable dataTable = new DataTable();

            //PdfGrid gridTable = new PdfGrid();

            
            //dataTable.Columns.Add("Booking ID");
            //dataTable.Columns.Add("Customer Id");
            //dataTable.Columns.Add("Car Id");
            //dataTable.Columns.Add("Amount Due");
            //dataTable.Columns.Add("Booking Date");
            //dataTable.Columns.Add("Return Date");

            //for (int i = 0; i < bookings.Count(); i++)
            //{
            //    dataTable.Rows.Add(bookings[i]);
            //}

            //gridTable.DataSource = dataTable;

            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;

            //Set the standard font.
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            PdfFont smallFont = new PdfStandardFont(PdfFontFamily.Helvetica, 10);

            //Draw the text.
            graphics.DrawString("Vehicle Reservation System", font, PdfBrushes.Black, new PointF(150, 0));

            graphics.DrawString("Report Created On: " + DateTime.Today.ToShortDateString(), font, PdfBrushes.Black, new PointF(130, 30));

            graphics.DrawString("Autogenerated by VRS", smallFont, PdfBrushes.Black, new PointF(0, 50));

            graphics.DrawString("Bookings made this Month: " + thisMonthBookings.ToString(), font, PdfBrushes.Black, new PointF(20, 100));
            graphics.DrawString("Total Booking: " + totalBookings.ToString(), font, PdfBrushes.Black, new PointF(20, 120));

            graphics.DrawString("Income generated this month: " + thisMonthIncome, font, PdfBrushes.Black, new PointF(20, 160));
            graphics.DrawString("Total Income generated: " + totalIncome, font, PdfBrushes.Black, new PointF(20, 180));

            graphics.DrawString("Customers registered this month: " + thisMonthCustomers, font, PdfBrushes.Black, new PointF(20, 220));
            graphics.DrawString("Total Customers registered: " + totalCustomers, font, PdfBrushes.Black, new PointF(20, 240));

            graphics.DrawString("Vehicles included this month: " + thisMonthVehicles, font, PdfBrushes.Black, new PointF(20, 280));
            graphics.DrawString("Total Vehicles included: " + totalVehicles, font, PdfBrushes.Black, new PointF(20, 300));

            graphics.DrawString("Total Sedans: " + totalSedans, font, PdfBrushes.Black, new PointF(20, 340));
            graphics.DrawString("Total Hybrids: " + totalHybrids, font, PdfBrushes.Black, new PointF(20, 360));
            graphics.DrawString("Total Jeeps: " + totalJeeps, font, PdfBrushes.Black, new PointF(20, 380));

            //gridTable.Draw(page, new PointF(20, 90));

            //Save the document.
            report.Save("VRS-Report.pdf");

            //Close the document.
            report.Close(true);
        }

        //public void invoiceWriter(List<Object> customer)
        //{
        //    //Create a new PDF document.
        //    PdfDocument invoice = new PdfDocument();

        //    //Add a page to the document.
        //    PdfPage page = invoice.Pages.Add();

        //    //Create PDF graphics for the page.
        //    PdfGraphics graphics = page.Graphics;

        //    //Set the standard font.
        //    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

        //    //Draw the text.
        //    graphics.DrawString("Vehicle Reservation System", font, PdfBrushes.Black, new PointF(150, 0));

        //    graphics.DrawString("Invoice", font, PdfBrushes.Black, new PointF(170, 0));

        //    graphics.DrawString("Customer Details: " + customer  , font, PdfBrushes.Black, new PointF(20, 50));

        //    graphics.DrawString("Income generated: " , font, PdfBrushes.Black, new PointF(20, 70));

        //    //Save the document.
        //    invoice.Save("Invoice.pdf");

        //    //Close the document.
        //    invoice.Close(true);
        //}
    }
}
