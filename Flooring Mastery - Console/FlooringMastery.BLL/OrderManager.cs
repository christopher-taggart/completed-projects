using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepo;
        private IProductRepository _productRepo;
        private ITaxInfoRepository _taxRepo;

        public OrderManager(IOrderRepository orderRepo, ITaxInfoRepository taxRepo, IProductRepository productRepo)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _taxRepo = taxRepo;
        }

        public void DisplayProductInfo()
        {
            List<Product>products = _productRepo.GetAllProductInfo();
            foreach (var p in products)
            {
                Console.WriteLine($"Product Type: {p.ProductType}\nCost Per Square Foot: {p.CostPerSquareFoot:C}\nLabor Cost Per Square Foot: {p.LaborCostPerSquareFoot:C}");
                Console.WriteLine("===================================");
            }
        }

        public OrderResponse AddOrder(string date, string name, string state, string pType, decimal area)
        {
            OrderResponse AddResponse = new OrderResponse();
            OrderRules rules = new OrderRules();
            DateTime d = DateTime.Parse(date);

            TaxInfo tax = new TaxInfo();
            tax = _taxRepo.GetTaxInfoByState(state);

            Product product = new Product();
            product = _productRepo.GetProductByType(pType);

            AddResponse = rules.Validate(d, name, tax, product, area);
            if (!AddResponse.Success)
            {
                return AddResponse;
            }

            AddResponse.Order.OrderNumber = GetCustomerOrderNumber(date);
            return AddResponse;

        }

        public void SaveOrder(Order order, string date)
        {
            List<Order>orders = new List<Order>();
            List<Order>orderedList = new List<Order>();
            DateTime d = DateTime.Parse(date);
            string newDate = d.ToString("MMddyyyy");
           
            orders = _orderRepo.LoadOrders(newDate);
            if (orders == null)
            {
                List<Order> orders2 = new List<Order>();
                orders2.Add(order);
                _orderRepo.SaveOrder(orders2, newDate);
                return;
           
            }
            orders.Add(order);
            orderedList = orders.OrderBy(o => o.OrderNumber).ToList();
            _orderRepo.SaveOrder(orderedList, newDate);

        }
        
        public int GetCustomerOrderNumber(string date)
        {
            DateTime d = DateTime.Parse(date);
            string formatDate = d.ToString("MMddyyyy");
            int number = 1;
            
            List<Order>orders = _orderRepo.LoadOrders(formatDate);
            if (orders != null)
            {

                number += orders.Max(m => m.OrderNumber);
            }

            else
            {
                number = 1;
            }

            return number;
        }

        public OrderListResponse GetOrdersByDate(string date)
        {
            OrderListResponse response = new OrderListResponse();
            
            DateTime d = DateTime.Parse(date);
            string formatDate = d.ToString("MMddyyyy");
            
            response.Orders = _orderRepo.LoadOrders(formatDate);
            if (response.Orders == null)
            {
                response.Success = false;
                response.Message = "There are no orders for this date.";
                return response;
            }
            
                response.Success = true;
                return response;
            
        }

        public void RemoveOrder(List<Order>orders, int orderNumber, string date)
        {
            DateTime d = DateTime.Parse(date);
            string newDate = d.ToString("MMddyyyy");
            Order order = new Order();
            foreach (var o in orders)
            {
                if (orderNumber == o.OrderNumber)
                {
                    order = o;
                }
            }
            orders.Remove(order);
            _orderRepo.SaveOrder(orders, newDate);
            
        }

        public OrderResponse EditOrder(string date, string name, string state, string pType, decimal area, int orderNumber)
        {
            OrderResponse response = new OrderResponse();
            OrderRules rules = new OrderRules();
            DateTime d = DateTime.Parse(date);

            TaxInfo tax = new TaxInfo();
            tax = _taxRepo.GetTaxInfoByState(state);

            Product product = new Product();
            product = _productRepo.GetProductByType(pType);

            response = rules.Validate(d, name, tax, product, area);
            if (!response.Success)
            {
                
                return response;
            }
            response.Order.OrderNumber = orderNumber;
            return response;
        }

        public OrderResponse GetOrderByOrderNumber(List<Order> orders, int orderNumber)
        {
            OrderResponse response = new OrderResponse();

            foreach (var order in orders)
            {
                if(order.OrderNumber == orderNumber)
                {
                    response.Order = order;
                    response.Success = true;
                    return response;
                }
            }
            response.Success = false;
            response.Message = "There are no orders with that order number.";
            return response;
        }
    }
}
