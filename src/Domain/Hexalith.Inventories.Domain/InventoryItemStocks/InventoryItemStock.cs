﻿// ***********************************************************************
// Assembly         : Hexalith.Domain.Parties
// Author           : Jérôme Piquot
// Created          : 08-21-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 09-12-2023
// ***********************************************************************
// <copyright file="InventoryItemStock.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Inventories.Domain.InventoryItemStocks;

using System.Runtime.Serialization;

using Hexalith.Domain.Aggregates;
using Hexalith.Domain.Events;
using Hexalith.Domain.Exceptions;
using Hexalith.Domain.InventoryItemStocks;
using Hexalith.Inventories.Events.InventoryItemStocks;

/// <summary>
/// Class InventoryItemStock.
/// Implements the <see cref="Aggregate" />
/// Implements the <see cref="IAggregate" />
/// Implements the <see cref="IEquatable{Aggregate}" />
/// Implements the <see cref="IEquatable{InventoryItemStock}" />.
/// </summary>
/// <seealso cref="Aggregate" />
/// <seealso cref="IAggregate" />
/// <seealso cref="IEquatable{Aggregate}" />
/// <seealso cref="IEquatable{InventoryItemStock}" />
[DataContract]
public record InventoryItemStock(
    [property: DataMember] string PartitionId,
    [property: DataMember] string CompanyId,
    [property: DataMember] string OriginId,
    [property: DataMember] string LocationId,
    [property: DataMember] string Id,
    [property: DataMember] decimal Quantity,
    [property: DataMember] DateTimeOffset Date) : Aggregate
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryItemStock" /> class.
    /// </summary>
    /// <param name="increased">The increased.</param>
    public InventoryItemStock(InventoryItemStockIncreased increased)
        : this(
              (increased ?? throw new ArgumentNullException(nameof(increased))).PartitionId,
              increased.OriginId,
              increased.CompanyId,
              increased.LocationId,
              increased.Id,
              increased.Quantity,
              increased.Date)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryItemStock"/> class.
    /// </summary>
    public InventoryItemStock()
        : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0m, DateTimeOffset.MinValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryItemStock" /> class.
    /// </summary>
    /// <param name="decreased">The decreased.</param>
    public InventoryItemStock(InventoryItemStockDecreased decreased)
        : this(
              (decreased ?? throw new ArgumentNullException(nameof(decreased))).PartitionId,
              decreased.OriginId,
              decreased.CompanyId,
              decreased.LocationId,
              decreased.Id,
              -decreased.Quantity,
              decreased.Date)
    {
    }

    /// <inheritdoc/>
    public override (IAggregate Aggregate, IEnumerable<BaseEvent> Events) Apply(BaseEvent domainEvent)
    {
        return (domainEvent switch
        {
            InventoryItemStockIncreased increased => this with { Quantity = Quantity + increased.Quantity },
            InventoryItemStockDecreased decreased => this with { Quantity = Quantity - decreased.Quantity },
            _ => throw new InvalidAggregateEventException(this, domainEvent, false),
        }, []);
    }

    /// <summary>
    /// Gets the name of the aggregate.
    /// </summary>
    /// <returns>System.String.</returns>
    public static string GetAggregateName() => InventoryHelper.InventoryItemStockAggregateName;

    /// <inheritdoc/>
    public override bool IsInitialized() => !string.IsNullOrWhiteSpace(Id);

    /// <inheritdoc/>
    protected override string DefaultAggregateId()
        => InventoryHelper.GetInventoryItemStockAggregateId(PartitionId, OriginId, CompanyId, LocationId, Id);
}