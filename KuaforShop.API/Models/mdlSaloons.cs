namespace KuaforShop.API.Models
{
    public class mdlSaloons
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        public int WorkDays { get; set; }
        public string Phone { get; set; }
        public string MyProperty { get; set; }
        public int SaloonType { get; set; }
    }
}
