﻿// ***********************************************************************
// Assembly         : Hexalith.Infrastructure.WebApis.ExternalSystemsEvents
// Author           : Jérôme Piquot
// Created          : 11-04-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 11-04-2023
// ***********************************************************************
// <copyright file="CustomerEventsBusTopicAttribute.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Inventories.EventsWebApis.Controllers;

using Hexalith.Infrastructure.WebApis.Buses;
using Hexalith.Inventories.Domain;

/// <summary>
/// Class PartnerInventoryItemEventsBusTopicAttribute. This class cannot be inherited.
/// Implements the <see cref="EventBusTopicAttribute" />.
/// </summary>
/// <seealso cref="EventBusTopicAttribute" />
[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public sealed class PartnerInventoryItemEventsBusTopicAttribute : EventBusTopicAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PartnerInventoryItemEventsBusTopicAttribute"/> class.
    /// </summary>
    public PartnerInventoryItemEventsBusTopicAttribute()
        : base(InventoryHelper.PartnerInventoryItemAggregateName)
    {
    }
}