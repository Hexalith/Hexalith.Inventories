﻿// ***********************************************************************
// Assembly         :
// Author           : Jérôme Piquot
// Created          : 02-18-2024
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 02-18-2024
// ***********************************************************************
// <copyright file="DisassociateInventoryItemBarcode.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Inventories.Commands.InventoryItems;

using System.Runtime.Serialization;

using Hexalith.Extensions;

/// <summary>
/// Class InventoryItemConversionInformationChanged.
/// Implements the <see cref="InventoryItemBarcodeCommand" />.
/// </summary>
/// <seealso cref="InventoryItemBarcodeCommand" />
[DataContract]
[Serializable]
public class DisassociateInventoryItemBarcode : InventoryItemBarcodeCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DisassociateInventoryItemBarcode" /> class.
    /// </summary>
    /// <param name="partitionId">The partition identifier.</param>
    /// <param name="companyId">The company identifier.</param>
    /// <param name="originId">The origin identifier.</param>
    /// <param name="id">The identifier.</param>
    /// <param name="barcode">The barcode.</param>
    public DisassociateInventoryItemBarcode(
        string partitionId,
        string companyId,
        string originId,
        string id,
        string barcode)
        : base(partitionId, companyId, originId, id, barcode)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DisassociateInventoryItemBarcode" /> class.
    /// </summary>
    [Obsolete(DefaultLabels.ForSerializationOnly, true)]
    public DisassociateInventoryItemBarcode()
    {
    }
}