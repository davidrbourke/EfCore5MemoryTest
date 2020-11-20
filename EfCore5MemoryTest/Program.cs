using System;
using System.Linq;

namespace EfCore5MemoryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");
            new ProcessPlans().Run();
        }

        public class ProcessPlans
        {
            public void Run()
            {
                var planDate = DateTime.Now.Date;
                for (var storeIdInc = 1; storeIdInc <= 1000; storeIdInc++)
                {
                    // Wrapping dbcontext in using for each save to the DB uses max of 53MB of Memory.
                    // Having the using outside the for statement above, uses > 250MB of RAM
                    using (var dbContext = new AppDbContext())
                    {
                        var plan = GetProductionPlan(storeIdInc % 10, planDate);
                        dbContext.ProductionPlans.Add(plan);
                        dbContext.SaveChanges();
                        Console.WriteLine($"Saving Store: {storeIdInc % 10}, plandate {planDate}");
                    }
                }
            }

            public ProductionPlan GetProductionPlan(int storeId, DateTime planDate)
            {
                return new ProductionPlan
                {
                    PlanDate = planDate,
                    CreatedAt = DateTime.Now,
                    StoreId = storeId,
                    PlanItems = Enumerable.Range(1, 1000).Select(j =>
                    {
                        return new PlanItem
                        {
                            SkuId = storeId * j,
                            Quantity = 10,
                            CreatedAt = DateTime.Now,
                        };
                    }).ToList()
                };
            }
        }
    }
}
