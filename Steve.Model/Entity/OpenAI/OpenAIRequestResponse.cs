namespace Steve.Model
{
    public class OpenAIRequestResponse
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public EnumOpenaiType Type { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual Users User { get; set; }
    }
}
