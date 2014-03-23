namespace TranslationQuotingService.DataContract
{
    using System.Runtime.Serialization;
    
    [DataContract]
    public class QuoteReply
    {
        [DataMember]
        public int TotalPrice { get; set; }

        [DataMember]
        public bool IncludeGst { get; set; }
    }
}
