// ***********************************************************************
// Assembly         : Hexalith.Infrastructure.WebApis.Parties
// Author           : Jérôme Piquot
// Created          : 10-26-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 10-27-2023
// ***********************************************************************
// <copyright file="InventoryItemIntegrationEventsController.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Inventories.EventsWebApis.Controllers;

using Dapr;

using Hexalith.Application.Events;
using Hexalith.Application.Projections;
using Hexalith.Application.States;
using Hexalith.Infrastructure.WebApis.Controllers;
using Hexalith.Inventories.Domain;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

/// <summary>
/// Class PartiesPubSubController.
/// Implements the <see cref="EventIntegrationController" />.
/// </summary>
/// <seealso cref="EventIntegrationController" />
/// <remarks>
/// Initializes a new instance of the <see cref="InventoryItemIntegrationEventsController"/> class.
/// </remarks>
/// <param name="eventProcessor">The event processor.</param>
/// <param name="projectionProcessor">The projection processor.</param>
/// <param name="hostEnvironment">The host environment.</param>
/// <param name="logger">The logger.</param>
[ApiController]
public abstract class InventoryItemIntegrationEventsController(
    IIntegrationEventProcessor eventProcessor,
    IProjectionUpdateProcessor projectionProcessor,
    IHostEnvironment hostEnvironment,
    ILogger logger) : EventIntegrationController(eventProcessor, projectionProcessor, hostEnvironment, logger)
{
    /// <summary>
    /// Handle aggregate external reference events as an asynchronous operation.
    /// </summary>
    /// <param name="eventState">State of the event.</param>
    /// <returns>A Task&lt;ActionResult&gt; representing the asynchronous operation.</returns>
    [InventoryItemEventsBusTopic]
    [TopicMetadata("requireSessions", "true")]
    [TopicMetadata("sessionIdleTimeoutInSec ", "60")]
    [TopicMetadata("maxConcurrentSessions", "32")]
    [HttpPost("/handle-inventoryitem-events")]
    public async Task<ActionResult> HandleInventoryItemEventsAsync(EventState eventState)
         => await HandleEventAsync(
                eventState,
                InventoryHelper.InventoryItemAggregateName,
                CancellationToken.None)
             .ConfigureAwait(false);
}