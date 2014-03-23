namespace TranslationQuotingService
{
    using System;
    using System.ServiceModel;
    using DataContract;

    [ServiceContract]
    public interface ITranslationQuotingService
    {
        [OperationContract]
        [FaultContract(typeof(InvalidOperationException))]
        [FaultContract(typeof(ArgumentNullException))]
        QuoteReply GetQuote(QuoteRequest request);
    }

}
