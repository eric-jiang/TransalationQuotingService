namespace TranslationQuotingService
{
    using System;
    using System.ServiceModel;
    using DataContract;

    [ServiceContract]
    public interface ITranslationQuotingService
    {
        [OperationContract]
        [FaultContract(typeof(string))]
        QuoteReply GetQuote(QuoteRequest request);
    }

}
