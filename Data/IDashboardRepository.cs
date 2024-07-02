using System.Threading.Tasks;
using TechPrimeLab.Models;

namespace TechPrimeLab.Data
{
    public interface IDashboardRepository
    {
        Task<DashboardDataDto> GetDashboardDataAsync();
    }
}
