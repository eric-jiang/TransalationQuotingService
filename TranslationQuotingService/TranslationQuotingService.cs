namespace TranslationQuotingService
{
    using System;
    using DataContract;
    using Business;
    using Microsoft.Practices.Unity;
    using System.ServiceModel;
    using Microsoft.Practices.Unity.Utility;

    public class TranslationQuotingService : ITranslationQuotingService
    {
        [Dependency]
        public IManageQuote ManageQuote { get; set; }
        
        public QuoteReply GetQuote(QuoteRequest request)
        {
            try
            {
                ManageQuote.InitializeQuote(request.Urgency, request.NumberOfWords, request.WorkType);

                var manageQuote = ManageQuote.InitializeQuote(request.Urgency, request.NumberOfWords, request.WorkType).CalculateQuotePrice();
                return new QuoteReply { TotalPrice = manageQuote.Quote.TotalPrice, IncludeGst = manageQuote.Quote.IncludeGst };
            }
            catch(Exception ex)
            {
                throw new FaultException<string>(ex.Message, ex.Message);
            }

        }
    }
}
