using WorkFlex.Services.DTOs;

namespace WorkFlex.Services.Interface
{
    public interface IDashboardService
    {
        Task<DashboardDto?> GetDashboardData();
    }
}
