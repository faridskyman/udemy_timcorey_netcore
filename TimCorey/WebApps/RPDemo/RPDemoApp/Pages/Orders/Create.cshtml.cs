using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLIbrary.Data;
using DataLIbrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RPDemoApp
{
    public class CreateModel : PageModel
    {
        private readonly IFoodData _foodData;
        private readonly IOrderData _orderData;

        public List<SelectListItem> FoodItems { get; set; }
        
        [BindProperty]
        public OrderModel Order { get; set; }
                
        public CreateModel(IFoodData foodData, IOrderData orderData)
        {
            _foodData = foodData;
            _orderData = orderData;
        }

        public async Task OnGet()
        {
            var food = await _foodData.GetFood();

            FoodItems = new List<SelectListItem>();

            //ddl
            food.ForEach(x =>
            {
                FoodItems.Add(new SelectListItem { Value = x.Id.ToString(), Text = x.Title });
            });
        }

        public async Task<IActionResult> OnPost()
        {
            int id;
            // means model return has something wrong, we should not process it
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            //todo make the db call get just the food item instead of getting all food
            var foods = await _foodData.GetFood();

            // one way to iterate
            //foods.ForEach(x =>
            //{
            //    if (x.Id == Order.FoodID)
            //        Order.Total = Order.Quantity * x.Price;
            //});

            // a nicer linq way
            try
            {
                Order.Total = Order.Quantity * foods.Where(x => x.Id == Order.FoodID).First().Price;
                //save order into db
                id = await _orderData.CreateOrder(Order);
            }
            catch
            {
                return RedirectToPage("./Create");
            }

            return RedirectToPage("./Display", new { Id = id });
        }
    }
}