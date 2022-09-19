namespace WebAppToModifyRecordsInDB.Contracts.Dtos
{
    public class AccreditationDto
    {
        public DateTime Expires { get; set; } = DateTime.Now;
        public int StatusId { get; set; }

        public virtual StatusDto? Status { get; set; }
    }
}
