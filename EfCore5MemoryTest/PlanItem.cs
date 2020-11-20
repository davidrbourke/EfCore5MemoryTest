using System;

namespace EfCore5MemoryTest
{
    public class PlanItem
    {
        public int PlanItemId { get; set; }
        public int SkuId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ProductionPlanId {get;set;}
        public ProductionPlan ProductionPlan { get; set; }
    }
}
