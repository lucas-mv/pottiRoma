using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;
using System.Threading.Tasks;
using PottiRoma.Entities;
using PottiRoma.Business.User;

namespace PottiRoma.Business.General
{
    public static class ReportGenerator
    {
        public static byte[] GenerateSalesReport(List<SaleEntity> sales)
        {
            byte[] reportData;
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet ws = package.Workbook.Worksheets.Add("testsheet");

                ws.Cells["A1"].Value = "Relatório de vendas - " + DateTime.Now.ToShortDateString();
                ws.Cells["A1"].Style.Font.Bold = true;

                ws.Cells["A2"].Value = "Revendedora";
                ws.Cells["B2"].Value = "Cliente";
                ws.Cells["C2"].Value = "Data venda";
                ws.Cells["D2"].Value = "Valor total";
                ws.Cells["E2"].Value = "Valor pago";
                ws.Cells["F2"].Value = "Número de peças";
                ws.Cells["G2"].Value = "Descrição";
                ws.Cells["A2:G2"].Style.Font.Bold = true;

                var line = 2;
                foreach(var sale in sales)
                {
                    line++;
                    ws.Cells["A" + line].Value = sale.UserName;
                    ws.Cells["B" + line].Value = sale.ClientName;
                    ws.Cells["C" + line].Value = sale.SaleDate.ToString("dd/MM/yyyy - hh:mm");
                    ws.Cells["D" + line].Value = "R$ " + sale.SaleValue.ToString("0.00");
                    ws.Cells["E" + line].Value = "R$ " + sale.SalePaidValue.ToString("0.00");
                    ws.Cells["F" + line].Value = sale.NumberSoldPieces;
                    ws.Cells["G" + line].Value = sale.Description;
                }

                ws.Cells[ws.Dimension.Address].AutoFitColumns();
                reportData = package.GetAsByteArray();
            }
            return reportData;
        }

        public static byte[] GenerateClientsReport(List<ClientEntity> clients)
        {
            byte[] reportData;
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet ws = package.Workbook.Worksheets.Add("testsheet");

                ws.Cells["A1"].Value = "Relatório de clientes - " + DateTime.Now.ToShortDateString();
                ws.Cells["A1"].Style.Font.Bold = true;

                ws.Cells["A2"].Value = "Cliente";
                ws.Cells["B2"].Value = "Revendedora";
                ws.Cells["C2"].Value = "Cep";
                ws.Cells["D2"].Value = "Email";
                ws.Cells["E2"].Value = "Telefone";
                ws.Cells["F2"].Value = "Aniversário";
                ws.Cells["A2:F2"].Style.Font.Bold = true;

                var line = 2;
                foreach (var client in clients)
                {
                    line++;
                    var salesperson = UserBusiness.GetUserById(client.UsuarioId);
                    ws.Cells["A" + line].Value = client.Name;
                    ws.Cells["B" + line].Value = salesperson.Name;
                    ws.Cells["C" + line].Value = client.Cep;
                    ws.Cells["D" + line].Value = client.Email;
                    ws.Cells["E" + line].Value = client.Telephone;
                    ws.Cells["F" + line].Value = client.Birthdate.ToString("dd/MM");
                }

                ws.Cells[ws.Dimension.Address].AutoFitColumns();
                reportData = package.GetAsByteArray();
            }
            return reportData;
        }
    }
}
