﻿// ***********************************************************************
// Assembly         : Hexalith.Domain.Parties
// Author           : Jérôme Piquot
// Created          : 08-21-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 09-12-2023
// ***********************************************************************
// <copyright file="InventoryItemStockEvent.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Inventories.Events.InventoryItemStocks;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

using Hexalith.Domain.Events;
using Hexalith.Extensions;
using Hexalith.Inventories.Domain;

/// <summary>
/// Class InventoryItemStockEvent.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
[DataContract]
[Serializable]
public abstract class InventoryItemStockEvent : CompanyEntityEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryItemStockEvent"/> class.
    /// </summary>
    /// <param name="partitionId">The partition identifier.</param>
    /// <param name="companyId">The company identifier.</param>
    /// <param name="originId">The origin identifier.</param>
    /// <param name="locationId">The location identifier.</param>
    /// <param name="id">The identifier.</param>
    [JsonConstructor]
    protected InventoryItemStockEvent(string partitionId, string companyId, string originId, string locationId, string id)
        : base(partitionId, companyId, originId, id) => LocationId = locationId;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryItemStockEvent" /> class.
    /// </summary>
    [Obsolete(DefaultLabels.ForSerializationOnly, true)]
    protected InventoryItemStockEvent() => LocationId = string.Empty;

    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    [DataMember(Order = 10)]
    [JsonPropertyOrder(10)]
    public string LocationId { get; set; }

    /// <inheritdoc/>
    protected override string DefaultAggregateId() => InventoryHelper.GetInventoryItemStockAggregateId(PartitionId, OriginId, CompanyId, LocationId, Id);

    /// <inheritdoc/>
    protected override string DefaultAggregateName() => InventoryHelper.InventoryItemStockAggregateName;
}