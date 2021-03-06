﻿namespace TranslationQuotingService.DataContract
{
    using System.Runtime.Serialization;

    [DataContract]
    public class QuoteRequest
    {
        [DataMember]
        public int NumberOfWords { get; set; }

        [DataMember]
        public string Urgency { get; set; }

        [DataMember]
        public string WorkType { get; set; }
    }
}
