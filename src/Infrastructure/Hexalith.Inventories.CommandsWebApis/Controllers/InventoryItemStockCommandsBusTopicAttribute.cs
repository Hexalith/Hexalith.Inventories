﻿// <copyright file="InventoryItemStockCommandsBusTopicAttribute.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Inventories.CommandsWebApis.Controllers;

using Hexalith.Infrastructure.WebApis.Buses;
using Hexalith.Inventories.Domain;

/// <summary>
/// Class InventoryItemStockCommandsBusTopicAttribute. This class cannot be inherited.
/// Implements the <see cref="CommandBusTopicAttribute" />.
/// </summary>
/// <seealso cref="CommandBusTopicAttribute" />
[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public sealed class InventoryItemStockCommandsBusTopicAttribute : CommandBusTopicAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryItemStockCommandsBusTopicAttribute"/> class.
    /// </summary>
    public InventoryItemStockCommandsBusTopicAttribute()
        : base(InventoryHelper.InventoryItemStockAggregateName)
    {
    }
}