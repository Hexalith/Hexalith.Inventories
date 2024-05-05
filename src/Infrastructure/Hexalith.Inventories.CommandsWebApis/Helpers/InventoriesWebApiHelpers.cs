// ***********************************************************************
// Assembly         : Hexalith.Infrastructure.WebApis.Inventories
// Author           : Jérôme Piquot
// Created          : 10-27-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 10-27-2023
// ***********************************************************************
// <copyright file="InventoriesWebApiHelpers.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Inventories.CommandsWebApis.Helpers;

using System.Diagnostics.CodeAnalysis;

using Dapr.Actors.Client;

using Hexalith.Application.Aggregates;
using Hexalith.Application.Commands;
using Hexalith.Infrastructure.DaprRuntime.Handlers;
using Hexalith.Inventories.Application.Helpers;
using Hexalith.Inventories.CommandsWebApis.Controllers;
using Hexalith.Inventories.Domain.InventoryItems;
using Hexalith.Inventories.Domain.InventoryItemStocks;
using Hexalith.Inventories.Domain.InventoryUnitConversions;
using Hexalith.Inventories.Domain.InventoryUnits;
using Hexalith.Inventories.Domain.PartnerInventoryItems;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

/// <summary>
/// Class InventoriesWebApiHelpers.
/// </summary>
public static class InventoriesWebApiHelpers
{
    /// <summary>
    /// Adds the external systems integration event handlers.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddInventoriesCommandsSubmission([NotNull] this IServiceCollection services)
    {
        services
            .AddInventoriesCommandHandlers()
            .TryAddSingleton<ICommandProcessor>((s) => new AggregateActorCommandProcessor(
                ActorProxy.DefaultProxyFactory,
                s.GetRequiredService<ILogger<AggregateActorCommandProcessor>>()));

        services.TryAddSingleton<IAggregateFactory, AggregateFactory>();
        services.TryAddSingleton<IAggregateProvider, AggregateProvider<InventoryItem>>();
        services.TryAddSingleton<IAggregateProvider, AggregateProvider<InventoryUnit>>();
        services.TryAddSingleton<IAggregateProvider, AggregateProvider<InventoryUnitConversion>>();
        services.TryAddSingleton<IAggregateProvider, AggregateProvider<PartnerInventoryItem>>();
        services.TryAddSingleton<IAggregateProvider, AggregateProvider<InventoryItemStock>>();
        _ = services
         .AddControllers()
         .AddApplicationPart(typeof(InventoriesCommandsController).Assembly)
         .AddDapr();
        return services;
    }
}