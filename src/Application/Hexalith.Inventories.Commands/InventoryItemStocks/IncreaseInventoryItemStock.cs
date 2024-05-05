﻿// ***********************************************************************
// Assembly         : Hexalith.Domain.Parties
// Author           : Jérôme Piquot
// Created          : 08-21-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 09-12-2023
// ***********************************************************************
// <copyright file="IncreaseInventoryItemStock.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Inventories.Commands.InventoryItemStocks;

using System.Runtime.Serialization;

using Hexalith.Extensions;
using Hexalith.Inventories.Commands.InventoryItems;

/// <summary>
/// Class InventoryItemAdded.
/// Implements the <see cref="InventoryItemCommand" />.
/// </summary>
/// <seealso cref="InventoryItemCommand" />
[DataContract]
[Serializable]
public class IncreaseInventoryItemStock : InventoryItemStockCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IncreaseInventoryItemStock"/> class.
    /// </summary>
    /// <param name="partitionId">The partition identifier.</param>
    /// <param name="companyId">The company identifier.</param>
    /// <param name="locationId">The location identifier.</param>
    /// <param name="originId">The origin identifier.</param>
    /// <param name="id">The identifier.</param>
    /// <param name="quantity">The quantity.</param>
    /// <param name="date">The date.</param>
    public IncreaseInventoryItemStock(
        string partitionId,
        string companyId,
        string locationId,
        string originId,
        string id,
        decimal quantity,
        DateTimeOffset date)
        : base(partitionId, companyId, originId, locationId, id)
    {
        Quantity = quantity;
        Date = date;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IncreaseInventoryItemStock" /> class.
    /// </summary>
    [Obsolete(DefaultLabels.ForSerializationOnly, true)]
    public IncreaseInventoryItemStock()
    {
        Quantity = 0;
        Date = DateTimeOffset.MinValue;
    }

    /// <summary>
    /// Gets or sets the external ids.
    /// </summary>
    /// <value>The external ids.</value>
    [DataMember(Order = 11)]
    public DateTimeOffset Date { get; set; }

    /// <summary>
    /// Gets or sets the quantity.
    /// </summary>
    /// <value>The quantity.</value>
    [DataMember(Order = 10)]
    public decimal Quantity { get; set; }
}