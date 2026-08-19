using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.NETCore;
using THUCTAP.Data;
using THUCTAP.Interfaces;

namespace THUCTAP.Services
{
    public class ReportService : IReportService
    {
        private readonly AppDbContext _context;

        public ReportService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<byte[]> GenerateUserReportAsync()
        {
            var reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "UserReport.rdlc");

            using var report = new LocalReport();
            report.ReportPath = reportPath;
            var usersFromDb = await _context.Users
                                            .Where(u => u.isActive == true)
                                            //.Select(u => new
                                            //{
                                            //    id = u.id,
                                            //    userName = u.userName,
                                            //    email = u.email,
                                            //    department = u.department,
                                                
                                            //})
                                            .ToListAsync();

            var dataTable = new DataTable();
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("UserName");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("Department");


            foreach (var user in usersFromDb)
            {
                dataTable.Rows.Add(
                    user.id,
                    user.userName ?? "",    
                    user.email ?? "",       
                    user.department ?? ""   
                );
            }

            var dataSource = new ReportDataSource("DataSet1", dataTable);
            report.DataSources.Add(dataSource);

            return report.Render("PDF");
        }
    }
}