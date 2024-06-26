﻿// ***********************************************************************
// Assembly         : Hexalith.Domain.Parties
// Author           : Jérôme Piquot
// Created          : 08-21-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 02-18-2024
// ***********************************************************************
// <copyright file="ProductDimensionsChanged.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// The Events namespace.
/// </summary>
namespace Hexalith.Inventories.Events.Products;

using System.Runtime.Serialization;

using Hexalith.Domain.ValueObjects;
using Hexalith.Extensions;

/// <summary>
/// Class ProductConversionInformationChanged.
/// Implements the <see cref="ProductEvent" />.
/// </summary>
/// <seealso cref="ProductEvent" />
[DataContract]
[Serializable]
public class ProductDimensionsChanged : ProductEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductDimensionsChanged" /> class.
    /// </summary>
    /// <param name="partitionId">The partition identifier.</param>
    /// <param name="originId">The origin identifier.</param>
    /// <param name="id">The identifier.</param>
    /// <param name="productDimensions">The product dimensions.</param>
    /// <param name="excludedDimensionCombinations">The excluded dimension combinations.</param>
    public ProductDimensionsChanged(
        string partitionId,
        string originId,
        string id,
        IEnumerable<DimensionValue> productDimensions,
        IEnumerable<IEnumerable<string>> excludedDimensionCombinations)
        : base(partitionId, originId, id)
    {
        ProductDimensions = productDimensions;
        ExcludedDimensionCombinations = excludedDimensionCombinations;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductDimensionsChanged" /> class.
    /// </summary>
    [Obsolete(DefaultLabels.ForSerializationOnly, true)]
    public ProductDimensionsChanged()
    {
        ExcludedDimensionCombinations = [];
        ProductDimensions = [];
    }

    /// <summary>
    /// Gets or sets the excluded dimension combinations.
    /// </summary>
    /// <value>The excluded dimension combinations.</value>
    [DataMember(Order = 21)]
    public IEnumerable<IEnumerable<string>> ExcludedDimensionCombinations { get; set; }

    /// <summary>
    /// Gets or sets the product dimensions.
    /// </summary>
    /// <value>The product dimensions.</value>
    [DataMember(Order = 20)]
    public IEnumerable<DimensionValue> ProductDimensions { get; set; }
}