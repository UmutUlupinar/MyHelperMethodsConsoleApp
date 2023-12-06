public class DictionaryHelper
{
    public static T ConvertKeyValuePairToObject<T>(KeyValuePair<string, object> kvp) where T : new()
    {
        T result = new T();

        string key = kvp.Key;
        object value = kvp.Value;

        if (value != null)
        {
            var type = typeof(T);

            var property = type.GetProperty(key);
            if (property != null)
            {
                if (property.PropertyType.IsAssignableFrom(value.GetType()))
                {
                    property.SetValue(result, value);
                }
            }
        }
        return result;
    }
}

// Example with specific class
public class PosData
{
    public string property1 { get; set; }
    public string property2 { get; set; }
    public string property3 { get; set; }
    public int property4 { get; set; }
    
    
    public static PosData ConvertKeyValuePairToObject(KeyValuePair<string, object> kvp)
    {
        Data data = new Data();

        string key = kvp.Key;
        object value = kvp.Value;
        
        switch (key)
        {
            case "pos_id" when value is string property1:
                data.property1 = property1;
                break;
            case "campaign_id" when value is string property2:
                posData.campaign_id = campaignId;
                break;
            case "allocation_id" when value is string property3:
                posData.allocation_id = allocationId;
                break;
        }
        return posData;
    }

    public static PosData ConvertDictionaryToObject(Dictionary<string, object> dictionary)
{
    PosData posData = new PosData();

    // Dictionary içindeki değerleri PosData sınıfının özelliklerine atayın
    if (dictionary.ContainsKey("pos_id") && dictionary["pos_id"] is string posId)
    {
        posData.pos_id = posId;
    }

    if (dictionary.ContainsKey("campaign_id") && dictionary["campaign_id"] is string campaignId)
    {
        posData.campaign_id = campaignId;
    }

    if (dictionary.ContainsKey("allocation_id") && dictionary["allocation_id"] is string allocationId)
    {
        posData.allocation_id = allocationId;
    }

    if (dictionary.ContainsKey("installments_number") && dictionary["installments_number"] is int installmentsNumber)
    {
        posData.installments_number = installmentsNumber;
    }

    if (dictionary.ContainsKey("amount_to_be_paid") && dictionary["amount_to_be_paid"] is decimal amountToBePaid)
    {
        posData.amount_to_be_paid = amountToBePaid;
    }

    if (dictionary.ContainsKey("currency_code") && dictionary["currency_code"] is string currencyCode)
    {
        posData.currency_code = currencyCode;
    }

    if (dictionary.ContainsKey("currency_id") && dictionary["currency_id"] is string currencyId)
    {
        posData.currency_id = currencyId;
    }

    if (dictionary.ContainsKey("title") && dictionary["title"] is string title)
    {
        posData.title = title;
    }

    if (dictionary.ContainsKey("hash_key") && dictionary["hash_key"] is string hashKey)
    {
        posData.hash_key = hashKey;
    }

    return posData;
}
    
    
}
