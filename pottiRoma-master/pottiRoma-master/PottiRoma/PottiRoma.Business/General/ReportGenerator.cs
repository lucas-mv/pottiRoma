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
using PottiRoma.Entities.Internal;

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

                ws.Cells["A2"].Value = "Flor";
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
                ws.Cells["B2"].Value = "Flor";
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

        public static byte[] GenerateSalespeopleReport(List<SalespersonEntity> salespeople)
        {
            byte[] reportData;
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet ws = package.Workbook.Worksheets.Add("testsheet");

                ws.Cells["A1"].Value = "Relatório de Flores - " + DateTime.Now.ToShortDateString();
                ws.Cells["A1"].Style.Font.Bold = true;

                ws.Cells["A2"].Value = "Flor";
                ws.Cells["B2"].Value = "Email";
                ws.Cells["C2"].Value = "CPF";
                ws.Cells["D2"].Value = "CEP";
                ws.Cells["E2"].Value = "Telefone primário";
                ws.Cells["F2"].Value = "Telefone secundário";
                ws.Cells["G2"].Value = "Temporada";
                ws.Cells["H2"].Value = "Sementes de ticket médio";
                ws.Cells["I2"].Value = "Sementes de clientes registrados";
                ws.Cells["J2"].Value = "Sementes de peças por atendimento";
                ws.Cells["K2"].Value = "Sementes por convidar Flores";
                ws.Cells["L2"].Value = "Aniversário";

                ws.Cells["A2:L2"].Style.Font.Bold = true;

                var line = 2;
                foreach (var salesperson in salespeople)
                {
                    line++;
                    ws.Cells["A" + line].Value = salesperson.Name;
                    ws.Cells["B" + line].Value = salesperson.Email;
                    ws.Cells["C" + line].Value = salesperson.Cpf;
                    ws.Cells["D" + line].Value = salesperson.Cep;
                    ws.Cells["E" + line].Value = salesperson.PrimaryTelephone;
                    ws.Cells["F" + line].Value = salesperson.SecundaryTelephone;
                    ws.Cells["G" + line].Value = salesperson.Season;
                    ws.Cells["H" + line].Value = salesperson.AverageTicketPoints;
                    ws.Cells["I" + line].Value = salesperson.RegisterClientsPoints;
                    ws.Cells["J" + line].Value = salesperson.AverageItensPerSalePoints;
                    ws.Cells["K" + line].Value = salesperson.InviteAllyFlowersPoints;
                    ws.Cells["L" + line].Value = salesperson.Birthday.ToShortDateString();
                }

                ws.Cells[ws.Dimension.Address].AutoFitColumns();
                reportData = package.GetAsByteArray();
            }
            return reportData;
        }

        public static byte[] GenerateRankingBySeasonReport(List<RankingBySeasonEntity> rankings)
        {
            byte[] reportData;
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet ws = package.Workbook.Worksheets.Add("testsheet");

                ws.Cells["A1"].Value = "Relatório Ranking por Temporada - " + DateTime.Now.ToShortDateString();
                ws.Cells["A1"].Style.Font.Bold = true;

                ws.Cells["A2"].Value = "Flor";
                ws.Cells["B2"].Value = "Email";
                ws.Cells["C2"].Value = "Temporada";
                ws.Cells["D2"].Value = "Total de sementes";
                ws.Cells["E2"].Value = "Data de início da temporada";
                ws.Cells["F2"].Value = "Data de término da temporada";
                ws.Cells["G2"].Value = "Sementes de ticket médio";
                ws.Cells["H2"].Value = "Sementes de clientes registrados";
                ws.Cells["I2"].Value = "Sementes de peças por atendimento";
                ws.Cells["J2"].Value = "Sementes por convidar Flores";

                ws.Cells["A2:J2"].Style.Font.Bold = true;

                var line = 2;
                foreach (var ranking in rankings)
                {
                    line++;
                    ws.Cells["A" + line].Value = ranking.Name;
                    ws.Cells["B" + line].Value = ranking.Email;
                    ws.Cells["C" + line].Value = ranking.Season;
                    ws.Cells["D" + line].Value = ranking.TotalPoints;
                    ws.Cells["E" + line].Value = ranking.StartDate.ToShortDateString();
                    ws.Cells["F" + line].Value = ranking.EndDate.ToShortDateString();
                    ws.Cells["G" + line].Value = ranking.AverageTicketPoints;
                    ws.Cells["H" + line].Value = ranking.RegisterClientsPoints;
                    ws.Cells["I" + line].Value = ranking.AverageItensPerSalePoints;
                    ws.Cells["J" + line].Value = ranking.InviteAllyFlowersPoints;
                }

                ws.Cells[ws.Dimension.Address].AutoFitColumns();
                reportData = package.GetAsByteArray();
            }
            return reportData;
        }
    }
}
