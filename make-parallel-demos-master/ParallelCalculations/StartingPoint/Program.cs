﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartingPoint {
  class Program {
    static void Main(string[] args) {
      var customers = CreateCustomerData();
      CalculateAverageDiscount(customers);
    }

    static void CalculateAverageDiscount(IList<Customer> customers) {
      var details = new List<CustomerDiscountCalculationDetails>();
      foreach (var customer in customers) {
        var detail = new CustomerDiscountCalculationDetails {
          Customer = customer,
        };
        foreach (var order in customer.Orders) {
          foreach (var line in order.OrderLines) {
            detail.SalesVolume += (line.Count * line.Product.Price);
          }
        }
        details.Add(detail);
      }

      details.Sort((d1, d2) => (int) (d2.SalesVolume - d1.SalesVolume));

      decimal tenth = (decimal) customers.Count / 10;
      decimal fiftieth = tenth * 5;
      decimal eigthieth = tenth * 8;

      var discounts = new Dictionary<CustomerCategory, decimal> {
        {CustomerCategory.A, 15},
        {CustomerCategory.B, 5},
        {CustomerCategory.C, 1.5m},
        {CustomerCategory.D, 0},
      };

      for (int i = 0; i < details.Count; i++) {
        if (i + 1 <= Math.Round(tenth))
          details[i].Category = CustomerCategory.A;
        else if (i + 1 <= Math.Round(fiftieth))
          details[i].Category = CustomerCategory.B;
        else if (i + 1 <= Math.Round(eigthieth))
          details[i].Category = CustomerCategory.C;
        else
          details[i].Category = CustomerCategory.D;

        details[i].Discount =
          details[i].Customer.AssignedDiscount ?? discounts[details[i].Category];
      }

      var averageDiscount = details.Average(d => d.Discount);
      Console.WriteLine($"The average discount is {averageDiscount}");
    }

    class CustomerDiscountCalculationDetails {
      public Customer Customer { get; set; }
      public decimal SalesVolume { get; set; }
      public CustomerCategory Category { get; set; }
      public decimal Discount { get; set; }
    }

    enum CustomerCategory {
      Unassigned,
      A,
      B,
      C,
      D
    }

    static IList<Customer> CreateCustomerData() {
      var hardDrive = new Product { Name = "Hard drive", Price = 89.90m };
      var usbStick = new Product { Name = "USB Stick", Price = 7.90m };
      var screen = new Product { Name = "32 inch LED monitor", Price = 239.95m };
      var marsBar = new Product { Name = "Mars bar", Price = 0.89m };

      return new List<Customer> {
        new Customer {
          Name="Billy",
          Orders = new List<Order> {
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = hardDrive, Count = 8 },
                new OrderLine {Product = screen, Count=2 }
              }
            },
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = hardDrive, Count = 2 },
                new OrderLine {Product = marsBar, Count=10 }
              }
            }
          }
        },
        new Customer {
          Name="Anna",
          Orders = new List<Order> {
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = screen, Count=4 }
              }
            },
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = screen, Count = 2 }
              }
            },
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = screen, Count = 3 }
              }
            },
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = screen, Count = 5 }
              }
            },
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = screen, Count = 1 }
              }
            }
          }
        },
        new Customer {
          Name="Jim",
          Orders = new List<Order> {
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = marsBar, Count=80 }
              }
            },
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = marsBar, Count = 80 }
              }
            },
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = usbStick, Count = 1 }
              }
            },
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = screen, Count = 2 }
              }
            }
          }
        },
        new Customer {
          Name="Peter",
          Orders = new List<Order> {
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = usbStick, Count=10 }
              }
            },
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = hardDrive, Count = 20 }
              }
            },
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = usbStick, Count = 20 }
              }
            }
          }
        },
        new Customer {
          Name="Susan",
          Orders = new List<Order> {
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = hardDrive, Count = 20 }
              }
            },
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = hardDrive, Count = 20 }
              }
            },
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = hardDrive, Count = 20 }
              }
            },
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = hardDrive, Count = 20 }
              }
            },
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = hardDrive, Count = 20 }
              }
            },
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = usbStick, Count = 20 }
              }
            }
          }
        },
        new Customer {
          Name="Megan",
          Orders = new List<Order> {
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = screen, Count = 20 },
                new OrderLine {Product = marsBar, Count = 200 },
                new OrderLine {Product = usbStick, Count = 40 },
                new OrderLine {Product = hardDrive, Count = 80 }
              }
            },
          }
        },
        new Customer {
          Name="Abby",
          AssignedDiscount = 12.5m,
          Orders = new List<Order> {
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = usbStick, Count = 11 },
                new OrderLine {Product = hardDrive, Count = 23 }
              }
            },
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = usbStick, Count = 3 },
                new OrderLine {Product = hardDrive, Count = 8 }
              }
            },
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = usbStick, Count = 14 },
                new OrderLine {Product = hardDrive, Count = 3 }
              }
            },
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = usbStick, Count = 4 },
                new OrderLine {Product = hardDrive, Count = 2 }
              }
            },
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = usbStick, Count = 7 },
                new OrderLine {Product = hardDrive, Count = 4 }
              }
            },
            new Order {
              OrderLines = new List<OrderLine> {
                new OrderLine {Product = usbStick, Count = 45 },
                new OrderLine {Product = hardDrive, Count = 11 }
              }
            }
          }
        }
      };
    }
  }

  public class Customer {
    public string Name { get; set; }
    public IList<Order> Orders { get; set; }

    public decimal? AssignedDiscount { get; set; }
  }

  public class Order {
    public IList<OrderLine> OrderLines { get; set; }
  }

  public class OrderLine {
    public Product Product { get; set; }
    public int Count { get; set; }

  }

  public class Product {
    public string Name { get; set; }
    public decimal Price { get; set; }
  }
}
