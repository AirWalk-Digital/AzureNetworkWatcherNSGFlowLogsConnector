using System;
public class EcsEvent
{
    public string category { get; set; }
    public string action { get; set; }
    public string outcome { get; set; }
    public string start { get; set; }
    public string dataset {get; set;}
    public string ingested {get; set;}
    
    public EcsEvent(DenormalizedRecord denormalizedRecord)
    {
        this.category = denormalizedRecord.category;
        this.action = denormalizedRecord.operationName;

        this.outcome = (denormalizedRecord.deviceAction == "A" ? "allowed" : "denied");

        DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(denormalizedRecord.startTime));
        this.start = dateTimeOffset.UtcDateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ");

        this.dataset = "nsg.access";

        DateTime ingestedUtcNow = DateTime.UtcNow;
        this.ingested = ingestedUtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ");
    }
}
