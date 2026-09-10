using System;

namespace MediLibAPI.Models
{
    public class LabTestBooking
    {
        public int Id { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string FatherName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string TestName { get; set; } = string.Empty;
        public decimal TestFee { get; set; }
        public bool IsFeePaid { get; set; } = false;
        public string? TestResultValue { get; set; }
        public string Status { get; set; } =string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}