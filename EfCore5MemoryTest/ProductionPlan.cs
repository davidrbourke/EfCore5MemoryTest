using System;
using System.Collections.Generic;
using System.Text;

namespace EfCore5MemoryTest
{
    public class ProductionPlan
    {
        public int ProductionPlanId { get; set; }
        public DateTime PlanDate { get; set; }
        public int StoreId { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<PlanItem> PlanItems { get; set; }
    }
}
