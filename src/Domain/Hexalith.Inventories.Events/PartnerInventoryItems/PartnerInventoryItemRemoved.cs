﻿// <copyright file="PartnerInventoryItemRemoved.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Domain.PartnerInventoryItems;

using System.Runtime.Serialization;

using Hexalith.Extensions;
using Hexalith.Inventories.Events.PartnerInventoryItems;

/// <summary>
/// Class PartnerInventoryItemRemoved.
/// Implements the <see cref="PartnerInventoryItemEvent" />.
/// </summary>
/// <seealso cref="PartnerInventoryItemEvent" />
[DataContract]
[Serializable]
public class PartnerInventoryItemRemoved : PartnerInventoryItemEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PartnerInventoryItemRemoved" /> class.
    /// </summary>
    /// <param name="partitionId">The partition identifier.</param>
    /// <param name="companyId">The company identifier.</param>
    /// <param name="originId">The origin identifier.</param>
    /// <param name="partnerType">Type of the partner.</param>
    /// <param name="partnerId">The partner identifier.</param>
    /// <param name="id">The identifier.</param>
    public PartnerInventoryItemRemoved(
        string partitionId,
        string companyId,
        string originId,
        string partnerType,
        string partnerId,
        string id)
        : base(partitionId, companyId, originId, partnerType, partnerId, id)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PartnerInventoryItemRemoved" /> class.
    /// </summary>
    [Obsolete(DefaultLabels.ForSerializationOnly, true)]
    public PartnerInventoryItemRemoved()
    {
    }
}