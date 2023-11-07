public class PosData
{
    public string pos_id { get; set; }
    public string campaign_id { get; set; }
    public string allocation_id { get; set; }
    public int installments_number { get; set; }

    //public string cot_percentage { get; set; }
    //public string cot_fixed { get; set; }
    public decimal amount_to_be_paid { get; set; }
    public string currency_code { get; set; }
    public string currency_id { get; set; }
    public string title { get; set; }

    public string hash_key { get; set; }
    
    
    public static PosData ConvertKeyValuePairToObject(KeyValuePair<string, object> kvp)
    {
        PosData posData = new PosData();

        string key = kvp.Key;
        object value = kvp.Value;
        
        switch (key)
        {
            case "pos_id" when value is string posId:
                posData.pos_id = posId;
                break;
            case "campaign_id" when value is string campaignId:
                posData.campaign_id = campaignId;
                break;
            case "allocation_id" when value is string allocationId:
                posData.allocation_id = allocationId;
                break;
            case "installments_number" when value is int installmentsNumber:
                posData.installments_number = installmentsNumber;
                break;
            case "amount_to_be_paid" when value is decimal amountToBePaid:
                posData.amount_to_be_paid = amountToBePaid;
                break;
            case "currency_code" when value is string currencyCode:
                posData.currency_code = currencyCode;
                break;
            case "currency_id" when value is string currencyId:
                posData.currency_id = currencyId;
                break;
            case "title" when value is string title:
                posData.title = title;
                break;
            case "hash_key" when value is string hashKey:
                posData.hash_key = hashKey;
                break;
        }

        return posData;
    }
    
    
}