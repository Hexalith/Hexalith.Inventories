// ***********************************************************************
// Assembly         : Hexalith.Domain.Parties
// Author           : Jérôme Piquot
// Created          : 08-21-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 02-18-2024
// ***********************************************************************
// <copyright file="InventoryUnitConversion.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Inventories.Domain.InventoryUnitConversions;

using System.Runtime.Serialization;

using Hexalith.Domain.Aggregates;
using Hexalith.Domain.Events;
using Hexalith.Domain.Exceptions;
using Hexalith.Domain.Messages;
using Hexalith.Inventories.Events.InventoryUnitConversions;

/// <summary>
/// Class InventoryUnitConversion.
/// Implements the <see cref="Aggregate" />
/// Implements the <see cref="IAggregate" />
/// Implements the <see cref="IEquatable{Aggregate}" />
/// Implements the <see cref="IEquatable{InventoryUnitConversion}" />.
/// </summary>
/// <seealso cref="Aggregate" />
/// <seealso cref="IAggregate" />
/// <seealso cref="IEquatable{Aggregate}" />
/// <seealso cref="IEquatable{InventoryUnitConversion}" />
[DataContract]
public record InventoryUnitConversion(
    [property: DataMember] string PartitionId,
    [property: DataMember] string CompanyId,
    [property: DataMember] string OriginId,
    [property: DataMember] string Id,
    [property: DataMember] string ToUnitId,
    [property: DataMember] string? InventoryItemId,
    [property: DataMember] decimal Factor,
    [property: DataMember] int RoundDecimals) : Aggregate
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryUnitConversion" /> class.
    /// </summary>
    /// <param name="conversion">The InventoryUnitConversion.</param>
    public InventoryUnitConversion(InventoryUnitConversionAdded conversion)
        : this(
              (conversion ?? throw new ArgumentNullException(nameof(conversion))).PartitionId,
              conversion.CompanyId,
              conversion.OriginId,
              conversion.Id,
              conversion.ToUnitId,
              conversion.InventoryItemId,
              conversion.Factor,
              conversion.RoundDecimals)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryUnitConversion"/> class.
    /// </summary>
    public InventoryUnitConversion()
        : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0m, 0)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryUnitConversion" /> class.
    /// </summary>
    /// <param name="conversion">The InventoryUnitConversion.</param>
    public InventoryUnitConversion(InventoryUnitConversionChanged conversion)
        : this(
              (conversion ?? throw new ArgumentNullException(nameof(conversion))).PartitionId,
              conversion.CompanyId,
              conversion.OriginId,
              conversion.Id,
              conversion.ToUnitId,
              conversion.InventoryItemId,
              conversion.Factor,
              conversion.RoundDecimals)
    {
    }

    /// <inheritdoc/>
    public override (IAggregate Aggregate, IEnumerable<BaseMessage> Messages) Apply(BaseEvent domainEvent)
    {
        return (domainEvent switch
        {
            InventoryUnitConversionChanged changed => new InventoryUnitConversion(changed),
            InventoryUnitConversionAdded => throw new InvalidAggregateEventException(this, domainEvent, true),
            _ => throw new InvalidAggregateEventException(this, domainEvent, false),
        }, []);
    }

    /// <summary>
    /// Gets the name of the aggregate.
    /// </summary>
    /// <returns>System.String.</returns>
    public static string GetAggregateName() => InventoryHelper.InventoryUnitConversionAggregateName;

    /// <inheritdoc/>
    public override bool IsInitialized() => !string.IsNullOrWhiteSpace(Id);

    /// <inheritdoc/>
    protected override string DefaultAggregateId() => InventoryHelper.GetInventoryUnitConversionAggregateId(PartitionId, CompanyId, OriginId, Id, ToUnitId, InventoryItemId);
}