namespace Hexalith.Inventories.Domain;

using Hexalith.Domain.Aggregates;

/// <summary>
/// Inventory helper.
/// </summary>
public static class InventoryHelper
{
    /// <summary>
    /// Gets the identifier separator.
    /// </summary>
    /// <value>The identifier separator.</value>
    public static char IdSeparator => '-';

    /// <summary>
    /// Gets the aggregate name for the InventoryItem.
    /// </summary>
    public static string InventoryItemAggregateName => "InventoryItem";

    /// <summary>
    /// Gets the aggregate name for the InventoryItemStock.
    /// </summary>
    public static string InventoryItemStockAggregateName => "InventoryItemStock";

    /// <summary>
    /// Gets the aggregate name for the InventoryUnit.
    /// </summary>
    public static string InventoryUnitAggregateName => "InventoryUnit";

    /// <summary>
    /// Gets the aggregate name for the InventoryUnitConversion.
    /// </summary>
    public static string InventoryUnitConversionAggregateName => "InventoryUnitConversion";

    /// <summary>
    /// Gets the aggregate name for the PartnerInventoryItem.
    /// </summary>
    public static string PartnerInventoryItemAggregateName => "PartnerInventoryItem";

    /// <summary>
    /// Gets the aggregate name for the Product.
    /// </summary>
    public static string ProductAggregateName => "Product";

    /// <summary>
    /// Gets the aggregate identifier for the InventoryItem.
    /// </summary>
    /// <param name="partitionId">The partition identifier.</param>
    /// <param name="companyId">The company identifier.</param>
    /// <param name="originId">The origin identifier.</param>
    /// <param name="id">The identifier.</param>
    /// <returns>The aggregate identifier.</returns>
    public static string GetInventoryItemAggregateId(string partitionId, string companyId, string originId, string id)
        => Aggregate.Normalize(InventoryItemAggregateName + IdSeparator + partitionId + IdSeparator + companyId + IdSeparator + originId + IdSeparator + id);

    /// <summary>
    /// Gets the aggregate identifier for the InventoryItemStock.
    /// </summary>
    /// <param name="partitionId">The partition identifier.</param>
    /// <param name="originId">The origin identifier.</param>
    /// <param name="companyId">The company identifier.</param>
    /// <param name="locationId">The location identifier.</param>
    /// <param name="id">The identifier.</param>
    /// <returns>The aggregate identifier.</returns>
    public static string GetInventoryItemStockAggregateId(string partitionId, string originId, string companyId, string locationId, string id)
        => Aggregate.Normalize(InventoryItemStockAggregateName + IdSeparator + partitionId + IdSeparator + companyId + IdSeparator + locationId + IdSeparator + originId + IdSeparator + id);

    /// <summary>
    /// Gets the aggregate identifier for the InventoryUnit.
    /// </summary>
    /// <param name="partitionId">The partition identifier.</param>
    /// <param name="companyId">The company identifier.</param>
    /// <param name="originId">The origin identifier.</param>
    /// <param name="id">The identifier.</param>
    /// <returns>The aggregate identifier.</returns>
    public static string GetInventoryUnitAggregateId(string partitionId, string companyId, string originId, string id)
        => Aggregate.Normalize(InventoryUnitAggregateName + IdSeparator + partitionId + IdSeparator + companyId + IdSeparator + originId + IdSeparator + id);

    /// <summary>
    /// Gets the aggregate identifier for the InventoryUnitConversion.
    /// </summary>
    /// <param name="partitionId">The partition identifier.</param>
    /// <param name="companyId">The company identifier.</param>
    /// <param name="originId">The origin identifier.</param>
    /// <param name="id">The identifier.</param>
    /// <param name="toUnitId">The target unit identifier.</param>
    /// <param name="inventoryItemId">The inventory item identifier (optional).</param>
    /// <returns>The aggregate identifier.</returns>
    public static string GetInventoryUnitConversionAggregateId(string partitionId, string companyId, string originId, string id, string toUnitId, string? inventoryItemId)
        => Aggregate.Normalize(
            InventoryUnitConversionAggregateName + IdSeparator + partitionId + IdSeparator + companyId + IdSeparator + originId + IdSeparator + id + IdSeparator + toUnitId + (
                string.IsNullOrWhiteSpace(inventoryItemId)
                    ? string.Empty :
                    IdSeparator + inventoryItemId));

    /// <summary>
    /// Gets the aggregate identifier for the PartnerInventoryItem.
    /// </summary>
    /// <param name="partitionId">The partition identifier.</param>
    /// <param name="companyId">The company identifier.</param>
    /// <param name="originId">The origin identifier.</param>
    /// <param name="partnerType">The partner type.</param>
    /// <param name="partnerId">The partner identifier.</param>
    /// <param name="id">The identifier.</param>
    /// <returns>The aggregate identifier.</returns>
    public static string GetPartnerInventoryItemAggregateId(string partitionId, string companyId, string originId, string partnerType, string partnerId, string id)
        => Aggregate.Normalize(
            PartnerInventoryItemAggregateName + IdSeparator + partitionId + IdSeparator + companyId + IdSeparator + originId + IdSeparator + partnerType + IdSeparator + partnerId + IdSeparator + id);

    /// <summary>
    /// Gets the aggregate identifier for the Product.
    /// </summary>
    /// <param name="partitionId">The partition identifier.</param>
    /// <param name="originId">The origin identifier.</param>
    /// <param name="id">The identifier.</param>
    /// <returns>The aggregate identifier.</returns>
    public static string GetProductAggregateId(string partitionId, string originId, string id)
        => Aggregate.Normalize(ProductAggregateName + IdSeparator + partitionId + IdSeparator + originId + IdSeparator + id);
}