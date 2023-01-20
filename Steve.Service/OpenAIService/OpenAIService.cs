using Steve.Data;
using Steve.Model;

namespace Steve.Service
{
    public class OpenAIService : IOpenAIService
    {
        private readonly SteveContext _steveContext;
        public OpenAIService(SteveContext steveContext)
        {
            _steveContext = steveContext;
        }

        public void Save(OpenAIViewModel openAIViewModel)
        {
            OpenAIRequestResponse openAIRequestResponse = new()
            {
                CreatedOn = DateTime.UtcNow,
                Request = openAIViewModel.Request,
                Response = openAIViewModel.Response,
                UserId = openAIViewModel.UserId,
                Type = EnumOpenaiType.GrammarCorrection
            };

            _steveContext.OpenAIRequestResponses.Add(openAIRequestResponse);
            _steveContext.SaveChanges();
        }
    }
}
