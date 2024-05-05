﻿// ***********************************************************************
// Assembly         : Hexalith.Infrastructure.WebApis.InventoriesCommands
// Author           : Jérôme Piquot
// Created          : 10-27-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 02-18-2024
// ***********************************************************************
// <copyright file="InventoriesCommandsController.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Inventories.CommandsWebApis.Controllers;

using Dapr;

using Hexalith.Application.Commands;
using Hexalith.Application.States;
using Hexalith.Infrastructure.WebApis.Controllers;
using Hexalith.Inventories.Domain;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

/// <summary>
/// Class InventoriesPubSubController.
/// Implements the <see cref="CommandIntegrationController" />.
/// </summary>
/// <seealso cref="CommandIntegrationController" />
/// <param name="commandProcessor">The command processor.</param>
/// <param name="hostEnvironment">The host environment.</param>
/// <param name="logger">The logger.</param>
/// <remarks>Initializes a new instance of the <see cref="InventoriesCommandsController" /> class.</remarks>
[ApiController]
public class InventoriesCommandsController(
    ICommandProcessor commandProcessor,
    IHostEnvironment hostEnvironment,
    ILogger<InventoriesCommandsController> logger) : CommandSubmissionController(commandProcessor, hostEnvironment, logger)
{
    /// <summary>
    /// Handle external systems commands as an asynchronous operation.
    /// </summary>
    /// <param name="commandState">State of the command.</param>
    /// <returns>A Task&lt;ActionResult&gt; representing the asynchronous operation.</returns>
    [InventoryItemCommandsBusTopic]
    [TopicMetadata("requireSessions", "true")]
    [TopicMetadata("sessionIdleTimeoutInSec ", "60")]
    [TopicMetadata("maxConcurrentSessions", "32")]
    [HttpPost("/handle-inventoryitem-commands")]
    public async Task<ActionResult> SubmitInventoryItemCommandsAsync(CommandState commandState)
        => await HandleCommandAsync(
                commandState,
                InventoryHelper.InventoryItemAggregateName,
                CancellationToken.None)
            .ConfigureAwait(false);

    /// <summary>
    /// Submit inventory item stock commands as an asynchronous operation.
    /// </summary>
    /// <param name="commandState">State of the command.</param>
    /// <returns>A Task&lt;ActionResult&gt; representing the asynchronous operation.</returns>
    [InventoryItemStockCommandsBusTopic]
    [TopicMetadata("requireSessions", "true")]
    [TopicMetadata("sessionIdleTimeoutInSec ", "60")]
    [TopicMetadata("maxConcurrentSessions", "32")]
    [HttpPost("/handle-inventoryitemstock-commands")]
    public async Task<ActionResult> SubmitInventoryItemStockCommandsAsync(CommandState commandState)
        => await HandleCommandAsync(
                commandState,
                InventoryHelper.InventoryItemStockAggregateName,
                CancellationToken.None)
            .ConfigureAwait(false);

    /// <summary>
    /// Submit inventory unit commands as an asynchronous operation.
    /// </summary>
    /// <param name="commandState">State of the command.</param>
    /// <returns>A Task&lt;ActionResult&gt; representing the asynchronous operation.</returns>
    [InventoryUnitCommandsBusTopic]
    [TopicMetadata("requireSessions", "true")]
    [TopicMetadata("sessionIdleTimeoutInSec ", "60")]
    [TopicMetadata("maxConcurrentSessions", "32")]
    [HttpPost("/handle-inventoryunitcommands")]
    public async Task<ActionResult> SubmitInventoryUnitCommandsAsync(CommandState commandState)
    => await HandleCommandAsync(
            commandState,
            InventoryHelper.InventoryUnitAggregateName,
            CancellationToken.None)
        .ConfigureAwait(false);

    /// <summary>
    /// Submit inventory unit conversion commands as an asynchronous operation.
    /// </summary>
    /// <param name="commandState">State of the command.</param>
    /// <returns>A Task&lt;ActionResult&gt; representing the asynchronous operation.</returns>
    [InventoryUnitConversionCommandsBusTopic]
    [TopicMetadata("requireSessions", "true")]
    [TopicMetadata("sessionIdleTimeoutInSec ", "60")]
    [TopicMetadata("maxConcurrentSessions", "32")]
    [HttpPost("/handle-inventoryunitconversion-commands")]
    public async Task<ActionResult> SubmitInventoryUnitConversionCommandsAsync(CommandState commandState)
    => await HandleCommandAsync(
            commandState,
            InventoryHelper.InventoryUnitConversionAggregateName,
            CancellationToken.None)
        .ConfigureAwait(false);

    /// <summary>
    /// Submit partner inventory item commands as an asynchronous operation.
    /// </summary>
    /// <param name="commandState">State of the command.</param>
    /// <returns>A Task&lt;ActionResult&gt; representing the asynchronous operation.</returns>
    [PartnerInventoryItemCommandsBusTopic]
    [TopicMetadata("requireSessions", "true")]
    [TopicMetadata("sessionIdleTimeoutInSec ", "60")]
    [TopicMetadata("maxConcurrentSessions", "32")]
    [HttpPost("/handle-partnerinventoryitem-commands")]
    public async Task<ActionResult> SubmitPartnerInventoryItemCommandsAsync(CommandState commandState)
    => await HandleCommandAsync(
            commandState,
            InventoryHelper.PartnerInventoryItemAggregateName,
            CancellationToken.None)
        .ConfigureAwait(false);
}