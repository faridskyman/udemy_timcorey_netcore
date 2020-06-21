using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLIbrary.Data;
using DataLIbrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RPDemoApp
{
    public class ListModel : PageModel
    {
        private readonly IFoodData _foodData;
        public List<FoodModel> Food { get; set; }

        public ListModel(IFoodData foodData)
        {
            _foodData = foodData;
        }
        public async Task OnGet()
        {
            Food = await _foodData.GetFood();

        }

    }
}