﻿// <copyright file="InventoryUnitSettings.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Inventories.DaprRuntime.Configurations;

using Hexalith.Application.Configurations;
using Hexalith.Extensions.Configuration;
using Hexalith.Inventories.Domain;

/// <summary>
/// Class InventoryUnitSettings.
/// Implements the <see cref="ISettings" />.
/// </summary>
/// <seealso cref="ISettings" />
public class InventoryUnitSettings : ISettings
{
    /// <summary>
    /// Gets or sets the command processor.
    /// </summary>
    /// <value>The command processor.</value>
    public CommandProcessorSettings? CommandProcessor { get; set; }

    /// <summary>
    /// The configuration section name of the settings.
    /// </summary>
    /// <returns>The name.</returns>
    public static string ConfigurationName() => InventoryHelper.InventoryUnitAggregateName;
}