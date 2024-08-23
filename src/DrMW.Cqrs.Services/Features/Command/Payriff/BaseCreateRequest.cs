using Newtonsoft.Json;

namespace Application.Features.Commands.Payriff.Create;

public class BaseCreateRequest
{
    [JsonProperty("code")] public string? Code { get; set; }
    [JsonProperty("internalMessage")] public string? InternalMessage { get; set; }
    [JsonProperty("message")] public string? Message { get; set; }
    [JsonProperty("payload")] public Payload? Payload { get; set; }
}

public class Payload
{
    [JsonProperty("version")] public string? Version { get; set; }
    [JsonProperty("orderID")] public string? OrderId { get; set; }

    [JsonProperty("sessionID")] public string? SessionId { get; set; }

    [JsonProperty("transactionType")] public string? TransactionType { get; set; }

    [JsonProperty("purchaseAmount")] public decimal? PurchaseAmount { get; set; }

    [JsonProperty("currency")] public string? Currency { get; set; }

    [JsonProperty("tranDateTime")] public string? TranDateTime { get; set; }

    [JsonProperty("responseCode")] public string? ResponseCode { get; set; }

    [JsonProperty("responseDescription")] public string? ResponseDescription { get; set; }

    [JsonProperty("brand")] public string? Brand { get; set; }

    [JsonProperty("orderStatus")] public string? OrderStatus { get; set; }

    [JsonProperty("approvalCode")] public string? ApprovalCode { get; set; }

    [JsonProperty("orderDescription")] public string? OrderDescription { get; set; }

    [JsonProperty("approvalCodeScr")] public string? ApprovalCodeScr { get; set; }

    [JsonProperty("purchaseAmountScr")] public decimal? PurchaseAmountScr { get; set; }

    [JsonProperty("currencyScr")] public string? CurrencyScr { get; set; }

    [JsonProperty("orderStatusScr")] public string? OrderStatusScr { get; set; }

    [JsonProperty("cardRegistration")] public CardPayload? CardRegistration { get; set; }

    [JsonProperty("rrn")] public string? Rrn { get; set; }

    [JsonProperty("pan")] public string? Pan { get; set; }

    [JsonProperty("invoiceUuid")] public string? InvoiceUuid { get; set; }
}

public class CardPayload
{
    [JsonProperty("MaskedPAN")] public string? CardNumber { get; set; }
    [JsonProperty("CardUID")] public string? CardId { get; set; }
    [JsonProperty("Brand")] public string? Brand { get; set; }
}