using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.BLL
{
    public class OrderRules : IOrderRules
    {
        public OrderResponse Validate(DateTime date, string name, TaxInfo tax, Product product, decimal area)
        {

            OrderResponse response = new OrderResponse();


            if (date < DateTime.Today)
            {
                response.Success = false;
                response.Message = "Orders must be placed for future dates.";
                return response;
            }

            if (name.Length < 1)
            {
                response.Success = false;
                response.Message = "Name field cannot be left blank.";
                return response;
            }

            if (tax == null)
            {
                response.Success = false;
                response.Message =
                    "The state you entered in is invalid or we do not currently deliver to that location.";
                return response;
            }

            if (product == null)
            {
                response.Success = false;
                response.Message = "The product type you entered is invalid.";
                return response;
            }

            if (area < 100)
            {
                response.Success = false;
                response.Message = "Area must be greater than 100 square ft.";
                return response;
            }
            response.Success = true;
            response.Order.CustomerName = name;
            response.Order.State = tax.StateAbbrevation;
            response.Order.TaxRate = tax.TaxRate;
            response.Order.Area = area;
            response.Order.ProductType = product.ProductType;
            response.Order.CostPerSquareFoot = product.CostPerSquareFoot;
            response.Order.LaborCostPerSqareFoot = product.LaborCostPerSquareFoot;
            response.Order.MaterialCost = area * product.CostPerSquareFoot;
            response.Order.LaborCost = area * product.LaborCostPerSquareFoot;
            response.Order.Tax = (response.Order.MaterialCost + product.LaborCostPerSquareFoot) * (tax.TaxRate / 100);
            response.Order.Total = response.Order.MaterialCost + response.Order.LaborCost + response.Order.Tax;
            return response;
        }
    }
}
