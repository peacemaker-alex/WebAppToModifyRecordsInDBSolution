namespace WebAppToModifyRecordsInDB.Contracts.Dtos
{
    public class AccreditationDto
    {
        public string Expires { get; set; }
        public int StatusId { get; set; }

        public virtual StatusDto? Status { get; set; }
    }
}
