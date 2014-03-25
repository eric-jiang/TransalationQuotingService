namespace TranslationQuotingService
{
    using System;
    using DataContract;
    using Business;
    using Microsoft.Practices.Unity;
    using System.ServiceModel;
    using Microsoft.Practices.Unity.Utility;
    using System.Web;

    public class TranslationQuotingService : ITranslationQuotingService
    {
        [Dependency]
        public IManageQuote ManageQuote { get; set; }
        
        public TranslationQuotingService()
        {
            var accessor = HttpContext.Current.ApplicationInstance as IContainerAccessor;
            var container = accessor.Container;
            container.BuildUp(this);
        }

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
