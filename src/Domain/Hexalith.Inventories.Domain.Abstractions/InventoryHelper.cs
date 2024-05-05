namespace Hexalith.Inventories.Domain;

using Hexalith.Domain.Aggregates;

/// <summary>
/// Inventory helper.
/// </summary>
public static class InventoryHelper
{
    public const char AggregateIdSeperator = '-';

    /// <summary>
    /// The aggregate name for the InventoryItem.
    /// </summary>
    public const string InventoryItemAggregateName = "InventoryItem";

    /// <summary>
    /// The aggregate name for the InventoryItemStock.
    /// </summary>
    public const string InventoryItemStockAggregateName = "InventoryItemStock";

    /// <summary>
    /// The aggregate name for the InventoryUnit.
    /// </summary>
    public const string InventoryUnitAggregateName = "InventoryUnit";

    /// <summary>
    /// The aggregate name for the InventoryUnitConversion.
    /// </summary>
    public const string InventoryUnitConversionAggregateName = "InventoryUnitConversion";

    /// <summary>
    /// The aggregate name for the PartnerInventoryItem.
    /// </summary>
    public const string PartnerInventoryItemAggregateName = "PartnerInventoryItem";

    /// <summary>
    /// The aggregate name for the Product.
    /// </summary>
    public const string ProductAggregateName = "Product";

    public static string GetInventoryItemAggregateId(string partitionId, string companyId, string originId, string id)
                => Aggregate.Normalize(InventoryItemAggregateName + AggregateIdSeperator + partitionId + AggregateIdSeperator + companyId + AggregateIdSeperator + originId + AggregateIdSeperator + id);

    public static string GetInventoryItemStockAggregateId(string partitionId, string originId, string companyId, string locationId, string id)
                => Aggregate.Normalize(InventoryItemStockAggregateName + AggregateIdSeperator + partitionId + AggregateIdSeperator + companyId + AggregateIdSeperator + locationId + AggregateIdSeperator + originId + AggregateIdSeperator + id);

    public static string GetInventoryUnitAggregateId(string partitionId, string companyId, string originId, string id)
                => Aggregate.Normalize(InventoryUnitAggregateName + AggregateIdSeperator + partitionId + AggregateIdSeperator + companyId + AggregateIdSeperator + originId + AggregateIdSeperator + id);

    public static string GetInventoryUnitConversionAggregateId(string partitionId, string companyId, string originId, string id, string toUnitId, string? inventoryItemId = null)
            => Aggregate.Normalize(InventoryUnitConversionAggregateName + AggregateIdSeperator + partitionId + AggregateIdSeperator + companyId + AggregateIdSeperator + originId + AggregateIdSeperator + id + AggregateIdSeperator + toUnitId + (string.IsNullOrWhiteSpace(inventoryItemId) ? string.Empty : AggregateIdSeperator + inventoryItemId));

    public static string GetPartnerInventoryItemAggregateId(string partitionId, string companyId, string originId, string partnerType, string partnerId, string id)
        => Aggregate.Normalize(PartnerInventoryItemAggregateName + AggregateIdSeperator + partitionId + AggregateIdSeperator + companyId + AggregateIdSeperator + originId + AggregateIdSeperator + partnerType + AggregateIdSeperator + partnerId + AggregateIdSeperator + id);

    /// <summary>
    /// Gets the product aggregate identifier.
    /// </summary>
    /// <param name="partitionId">The partition identifier.</param>
    /// <param name="originId">The origin identifier.</param>
    /// <param name="id">The identifier.</param>
    /// <returns>string.</returns>
    public static string GetProductAggregateId(string partitionId, string originId, string id)
        => Aggregate.Normalize(ProductAggregateName + AggregateIdSeperator + partitionId + AggregateIdSeperator + originId + AggregateIdSeperator + id);
}