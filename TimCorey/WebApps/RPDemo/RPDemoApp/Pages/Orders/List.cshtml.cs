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
    public class ListOrderModel : PageModel
    {
        private readonly IOrderData _orderData;
        public List<OrderModel> Orders { get; set; }

        public ListOrderModel(IOrderData orderData)
        {
            _orderData = orderData;
        }
        public async Task OnGet()
        {
            Orders = await _orderData.GetAllOrders();
        }
    }
}