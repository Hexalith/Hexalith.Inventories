// ***********************************************************************
// Assembly         : Hexalith.Application.Parties
// Author           : Jérôme Piquot
// Created          : 09-04-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 02-18-2024
// ***********************************************************************
// <copyright file="InventoriesHelper.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Inventories.Application.Helpers;

using Hexalith.Application.Commands;
using Hexalith.Inventories.Application.InventoryItems.CommandHandlers;
using Hexalith.Inventories.Application.InventoryItemStocks.CommandHandlers;
using Hexalith.Inventories.Application.InventoryUnitConversions.CommandHandlers;
using Hexalith.Inventories.Application.InventoryUnits.CommandHandlers;
using Hexalith.Inventories.Application.PartnerInventoryItems.CommandHandlers;
using Hexalith.Inventories.Commands.InventoryItems;
using Hexalith.Inventories.Commands.InventoryItemStocks;
using Hexalith.Inventories.Commands.InventoryUnitConversions;
using Hexalith.Inventories.Commands.InventoryUnits;
using Hexalith.Inventories.Commands.PartnerInventoryItems;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Class PartiesHelper.
/// </summary>
public static class InventoriesHelper
{
    /// <summary>
    /// Adds the parties command handlers.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddInventoriesCommandHandlers(this IServiceCollection services)
    {
        return services
            .AddInventoryItemsCommandHandlers()
            .AddInventoryItemStocksCommandHandlers()
            .AddInventoryUnitConversionsCommandHandlers()
            .AddInventoryUnitsCommandHandlers()
            .AddPartnerInventoryItemsCommandHandlers();
    }

    /// <summary>
    /// Adds the inventory items command handlers.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddInventoryItemsCommandHandlers(this IServiceCollection services)
    {
        return services
            .AddTransient<ICommandHandler<AddInventoryItem>, AddInventoryItemHandler>()
            .AddTransient<ICommandHandler<AdjustInventoryItemBarcodeRatio>, AdjustInventoryItemBarcodeRatioHandler>()
            .AddTransient<ICommandHandler<AssignInventoryItemBarcode>, AssignInventoryItemBarcodeHandler>()
            .AddTransient<ICommandHandler<AssignInventoryItemDefaultBarcode>, AssignInventoryItemDefaultBarcodeHandler>()
            .AddTransient<ICommandHandler<ChangeInventoryItemInformation>, ChangeInventoryItemInformationHandler>()
            .AddTransient<ICommandHandler<ClearInventoryItemDefaultBarcode>, ClearInventoryItemDefaultBarcodeHandler>()
            .AddTransient<ICommandHandler<DisassociateInventoryItemBarcode>, DisassociateInventoryItemBarcodeHandler>();
    }

    /// <summary>
    /// Adds the inventory item stocks command handlers.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddInventoryItemStocksCommandHandlers(this IServiceCollection services)
    {
        return services
            .AddTransient<ICommandHandler<DecreaseInventoryItemStock>, DecreaseInventoryItemStockHandler>()
            .AddTransient<ICommandHandler<IncreaseInventoryItemStock>, IncreaseInventoryItemStockHandler>();
    }

    /// <summary>
    /// Adds the inventory unit conversions handlers.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddInventoryUnitConversionsCommandHandlers(this IServiceCollection services)
    {
        return services
            .AddTransient<ICommandHandler<AddInventoryUnitConversion>, AddInventoryUnitConversionHandler>()
            .AddTransient<ICommandHandler<ChangeInventoryUnitConversion>, ChangeInventoryUnitConversionHandler>();
    }

    /// <summary>
    /// Adds the inventory units handlers.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddInventoryUnitsCommandHandlers(this IServiceCollection services)
    {
        return services
            .AddTransient<ICommandHandler<AddInventoryUnit>, AddInventoryUnitHandler>()
            .AddTransient<ICommandHandler<ChangeInventoryUnit>, ChangeInventoryUnitHandler>();
    }

    /// <summary>
    /// Adds the partner inventory items handlers.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddPartnerInventoryItemsCommandHandlers(this IServiceCollection services)
    {
        return services
            .AddTransient<ICommandHandler<AddPartnerInventoryItem>, AddPartnerInventoryItemHandler>()
            .AddTransient<ICommandHandler<ChangePartnerInventoryItem>, ChangePartnerInventoryItemHandler>()
            .AddTransient<ICommandHandler<RemovePartnerInventoryItem>, RemovePartnerInventoryItemHandler>();
    }
}