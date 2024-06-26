﻿// ***********************************************************************
// Assembly         : Hexalith.Domain.Parties
// Author           : Jérôme Piquot
// Created          : 08-21-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 02-18-2024
// ***********************************************************************
// <copyright file="ProductDisabled.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// The Events namespace.
/// </summary>
namespace Hexalith.Domain.Products;

using System.Runtime.Serialization;

using Hexalith.Extensions;
using Hexalith.Inventories.Events.Products;

/// <summary>
/// Class ProductConversionInformationChanged.
/// Implements the <see cref="ProductEvent" />.
/// </summary>
/// <seealso cref="ProductEvent" />
[DataContract]
[Serializable]
public class ProductDisabled : ProductEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductDisabled" /> class.
    /// </summary>
    /// <param name="partitionId">The partition identifier.</param>
    /// <param name="companyId">The company identifier.</param>
    /// <param name="originId">The origin identifier.</param>
    /// <param name="id">The identifier.</param>
    /// <param name="name">The name.</param>
    /// <param name="description">The description.</param>
    /// <param name="roundDecimals">The round decimals.</param>
    public ProductDisabled(
        string partitionId,
        string originId,
        string id)
        : base(partitionId, originId, id)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductDisabled" /> class.
    /// </summary>
    [Obsolete(DefaultLabels.ForSerializationOnly, true)]
    public ProductDisabled()
    {
    }
}