namespace THUCTAP.Models
{
    public class Equipment : BaseModel
    {
        public string equipmentName { get; set; } = string.Empty;
        public string model { get; set; } = string.Empty;
        public string serialNumber { get; set; } = string.Empty;
        public string manufacturer { get; set; } = string.Empty;
        public string countryOfOrigin { get; set; } = string.Empty;
        public string equipmentCode { get; set; } = string.Empty;
        public string location { get; set; } = string.Empty;

        public DateTime? receivedDate { get; set; }
        public string conditionWhenReceived { get; set; } = string.Empty;
        public DateTime? startDateOfUse { get; set; }
        public string conditionWhenStarted { get; set; } = string.Empty;

        public string supplierName { get; set; } = string.Empty;
        public string supplierAddress { get; set; } = string.Empty;
        public string engineerInCharge { get; set; } = string.Empty;
        public string supplierPhone { get; set; } = string.Empty;
        public string supplierEmail { get; set; } = string.Empty;
        public ICollection<EquipmentManager> managers { get; set; } = new List<EquipmentManager>();
        public ICollection<EquipmentMaintenance> maintenances { get; set; } = new List<EquipmentMaintenance>();
    }
}