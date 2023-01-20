namespace Steve.Model
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string  UserName { get; set; }
        public string? MobileNumber { get; set; }
        public string? EmailId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<OpenAIRequestResponse> OpenAIRequestResponses { get; set; }
    }
}
