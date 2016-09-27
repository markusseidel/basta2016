﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelCalculations {
  class Program {
      // Results of analysing algorithm:

      // create list of customer details and calculate sales volumes
      // order by sales volumes
      // top 10% of customers are A
      // top 50% are B
      // top 80% are C
      // rest are D

      // discount is used on the basis of grouping, unless special customer discount has been assigned
      // finally, calculate average discount

        (from customer in customers.AsParallel()
          Customer = customer,
          SalesVolume = customer.Orders.Sum(
            o => o.OrderLines.Sum(
              ol => ol.Product.Price * ol.Count))
        }).ToList();
        if (i + 1 <= Math.Round(tenth))
          detail.Category = CustomerCategory.D;
}