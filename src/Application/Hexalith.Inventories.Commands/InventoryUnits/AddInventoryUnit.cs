﻿// ***********************************************************************
// Assembly         :
// Author           : Jérôme Piquot
// Created          : 02-18-2024
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 02-18-2024
// ***********************************************************************
// <copyright file="AddInventoryUnit.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Inventories.Commands.InventoryUnits;

using System.Runtime.Serialization;

using Hexalith.Extensions;

/// <summary>
/// Class InventoryItemConversionInformationChanged.
/// Implements the <see cref="InventoryUnitCommand" />.
/// </summary>
/// <seealso cref="InventoryUnitCommand" />
[DataContract]
[Serializable]
public class AddInventoryUnit : InventoryUnitCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddInventoryUnit" /> class.
    /// </summary>
    /// <param name="partitionId">The partition identifier.</param>
    /// <param name="companyId">The company identifier.</param>
    /// <param name="originId">The origin identifier.</param>
    /// <param name="id">The identifier.</param>
    /// <param name="name">The name.</param>
    /// <param name="description">The description.</param>
    /// <param name="roundDecimals">The round decimals.</param>
    public AddInventoryUnit(
        string partitionId,
        string companyId,
        string originId,
        string id,
        string name,
        string? description,
        int roundDecimals)
        : base(partitionId, companyId, originId, id)
    {
        RoundDecimals = roundDecimals;
        Name = name;
        Description = description;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AddInventoryUnit" /> class.
    /// </summary>
    [Obsolete(DefaultLabels.ForSerializationOnly, true)]
    public AddInventoryUnit() => Name = string.Empty;

    /// <summary>
    /// Gets the description.
    /// </summary>
    /// <value>The description.</value>
    [DataMember(Order = 21)]
    public string? Description { get; }

    /// <summary>
    /// Gets the factor.
    /// </summary>
    /// <value>The factor.</value>
    [DataMember(Order = 20)]
    public string Name { get; }

    /// <summary>
    /// Gets the round decimals.
    /// </summary>
    /// <value>The round decimals.</value>
    [DataMember(Order = 22)]
    public int RoundDecimals { get; }
}