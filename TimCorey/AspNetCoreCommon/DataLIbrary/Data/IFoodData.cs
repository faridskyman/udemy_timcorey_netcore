using DataLIbrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLIbrary.Data
{
    public interface IFoodData
    {
        Task<List<FoodModel>> GetFood();
    }
}