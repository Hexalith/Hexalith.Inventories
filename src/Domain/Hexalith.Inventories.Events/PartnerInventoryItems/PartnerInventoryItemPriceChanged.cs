﻿// <copyright file="PartnerInventoryItemPriceChanged.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Inventories.Events.PartnerInventoryItems;

using System.Runtime.Serialization;

using Hexalith.Extensions;

/// <summary>
/// Class PartnerInventoryItemInformationChanged.
/// Implements the <see cref="PartnerInventoryItemEvent" />.
/// </summary>
/// <seealso cref="PartnerInventoryItemEvent" />
[DataContract]
[Serializable]
public class PartnerInventoryItemPriceChanged : PartnerInventoryItemEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PartnerInventoryItemPriceChanged"/> class.
    /// </summary>
    /// <param name="partitionId">The partition identifier.</param>
    /// <param name="companyId">The company identifier.</param>
    /// <param name="originId">The origin identifier.</param>
    /// <param name="partnerType">Type of the partner.</param>
    /// <param name="partnerId">The partner identifier.</param>
    /// <param name="id">The identifier.</param>
    /// <param name="price">The name.</param>
    public PartnerInventoryItemPriceChanged(
        string partitionId,
        string companyId,
        string originId,
        string partnerType,
        string partnerId,
        string id,
        decimal? price)
        : base(partitionId, companyId, originId, partnerType, partnerId, id) => Price = price;

    /// <summary>
    /// Initializes a new instance of the <see cref="PartnerInventoryItemPriceChanged" /> class.
    /// </summary>
    [Obsolete(DefaultLabels.ForSerializationOnly, true)]
    public PartnerInventoryItemPriceChanged()
    {
    }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    [DataMember(Order = 20)]
    public decimal? Price { get; set; }
}