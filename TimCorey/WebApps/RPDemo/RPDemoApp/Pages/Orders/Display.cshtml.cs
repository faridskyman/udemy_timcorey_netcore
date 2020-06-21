using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLIbrary.Data;
using DataLIbrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RPDemoApp.Models;

namespace RPDemoApp
{
    public class DisplayModel : PageModel
    {
        public readonly IOrderData _orderData;
        public readonly IFoodData _foodData;

        [BindProperty(SupportsGet =true)]
        public int Id { get; set; }

        //if you forget this, on postback, u get nullref.
        [BindProperty]
        public OrderUpdateModel UpdateModel { get; set; }

        public OrderModel Order { get; set; }
        public string ItemPurchased { get; set; }   

        public DisplayModel(IOrderData orderData, IFoodData foodData)
        {
            _orderData = orderData;
            _foodData = foodData;
        }
        public async Task<IActionResult> OnGet()
        {
            Order = await _orderData.GetOrderById(Id);

            if(Order != null)
            {
                var foods = await _foodData.GetFood();

                //  if its not null then give me title, else it will be null
                ItemPurchased = foods.Where(x => x.Id == Order.FoodID).FirstOrDefault()?.Title;
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            //if model passed form view is invalid, no action return back to page
            if(ModelState.IsValid == false)
            {
                return Page();
            }

            //update the order
            await _orderData.UpdateOrderName(UpdateModel.Id, UpdateModel.OrderName);

            return RedirectToPage("./Display", new { UpdateModel.Id });
        }

    }
}