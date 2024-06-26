﻿// ***********************************************************************
// Assembly         :
// Author           : Jérôme Piquot
// Created          : 02-18-2024
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 02-18-2024
// ***********************************************************************
// <copyright file="ChangeInventoryUnitConversion.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Inventories.Commands.InventoryUnitConversions;

using System.Runtime.Serialization;

using Hexalith.Extensions;

/// <summary>
/// Class InventoryItemConversionInformationChanged.
/// Implements the <see cref="InventoryUnitConversionCommand" />.
/// </summary>
/// <seealso cref="InventoryUnitConversionCommand" />
[DataContract]
[Serializable]
public class ChangeInventoryUnitConversion : InventoryUnitConversionCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ChangeInventoryUnitConversion" /> class.
    /// </summary>
    /// <param name="partitionId">The partition identifier.</param>
    /// <param name="companyId">The company identifier.</param>
    /// <param name="originId">The origin identifier.</param>
    /// <param name="id">The identifier.</param>
    /// <param name="toUnitId">To unit identifier.</param>
    /// <param name="inventoryItemId">The inventory item identifier.</param>
    /// <param name="factor">The factor.</param>
    /// <param name="roundDecimals">The round decimals.</param>
    public ChangeInventoryUnitConversion(
        string partitionId,
        string companyId,
        string originId,
        string id,
        string toUnitId,
        string? inventoryItemId,
        decimal factor,
        int roundDecimals)
        : base(partitionId, companyId, originId, id, toUnitId, inventoryItemId)
    {
        Factor = factor;
        RoundDecimals = roundDecimals;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ChangeInventoryUnitConversion" /> class.
    /// </summary>
    [Obsolete(DefaultLabels.ForSerializationOnly, true)]
    public ChangeInventoryUnitConversion()
    {
    }

    /// <summary>
    /// Gets the factor.
    /// </summary>
    /// <value>The factor.</value>
    [DataMember(Order = 20)]
    public decimal Factor { get; }

    /// <summary>
    /// Gets the round decimals.
    /// </summary>
    /// <value>The round decimals.</value>
    [DataMember(Order = 21)]
    public int RoundDecimals { get; }
}