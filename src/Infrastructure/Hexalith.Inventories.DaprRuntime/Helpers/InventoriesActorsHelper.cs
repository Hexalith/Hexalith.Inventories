// <copyright file="InventoriesActorsHelper.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Inventories.DaprRuntime.Helpers;

using System.Diagnostics.CodeAnalysis;

using Dapr.Actors.Runtime;

using Hexalith.Infrastructure.DaprRuntime.Helpers;
using Hexalith.Infrastructure.DaprRuntime.Sales.Actors;
using Hexalith.Inventories.Domain;
using Hexalith.Inventories.Domain.InventoryItems;
using Hexalith.Inventories.Domain.InventoryItemStocks;
using Hexalith.Inventories.Domain.InventoryUnitConversions;
using Hexalith.Inventories.Domain.InventoryUnits;
using Hexalith.Inventories.Domain.PartnerInventoryItems;

/// <summary>
/// Class InventoriesHelper.
/// </summary>
public static class InventoriesActorsHelper
{
    /// <summary>
    /// Adds the parties.
    /// </summary>
    /// <param name="actors">The actors.</param>
    /// <returns>ActorRegistrationCollection.</returns>
    /// <exception cref="ArgumentNullException">null.</exception>
    public static ActorRegistrationCollection AddInventoriesAggregates([NotNull] this ActorRegistrationCollection actors)
    {
        ArgumentNullException.ThrowIfNull(actors);
        actors.RegisterActor<AggregateActor>(AggregateActorBase.GetAggregateActorName(InventoryHelper.InventoryItemAggregateName));
        actors.RegisterActor<AggregateActor>(AggregateActorBase.GetAggregateActorName(InventoryHelper.InventoryItemStockAggregateName));
        actors.RegisterActor<AggregateActor>(AggregateActorBase.GetAggregateActorName(InventoryHelper.InventoryUnitAggregateName));
        actors.RegisterActor<AggregateActor>(AggregateActorBase.GetAggregateActorName(InventoryHelper.InventoryUnitConversionAggregateName));
        actors.RegisterActor<AggregateActor>(AggregateActorBase.GetAggregateActorName(InventoryHelper.PartnerInventoryItemAggregateName));
        return actors;
    }

    /// <summary>
    /// Adds the parties projections.
    /// </summary>
    /// <param name="actors">The actors.</param>
    /// <param name="applicationId">Name of the application.</param>
    /// <returns>ActorRegistrationCollection.</returns>
    /// <exception cref="ArgumentNullException">null.</exception>
    public static ActorRegistrationCollection AddInventoriesProjections([NotNull] this ActorRegistrationCollection actors, string applicationId)
    {
        ArgumentNullException.ThrowIfNull(actors);
        actors.RegisterProjectionActor<InventoryItem>(applicationId);
        actors.RegisterProjectionActor<InventoryItemStock>(applicationId);
        actors.RegisterProjectionActor<InventoryUnitConversion>(applicationId);
        actors.RegisterProjectionActor<InventoryUnit>(applicationId);
        actors.RegisterProjectionActor<PartnerInventoryItem>(applicationId);
        return actors;
    }
}