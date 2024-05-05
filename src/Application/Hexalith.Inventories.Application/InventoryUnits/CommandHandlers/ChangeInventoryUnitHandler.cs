﻿// ***********************************************************************
// Assembly         :
// Author           : Jérôme Piquot
// Created          : 02-18-2024
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 02-18-2024
// ***********************************************************************
// <copyright file="ChangeInventoryUnitHandler.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Inventories.Application.InventoryUnits.CommandHandlers;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

using Hexalith.Application.Commands;
using Hexalith.Domain.Aggregates;
using Hexalith.Domain.InventoryUnits;
using Hexalith.Domain.Messages;
using Hexalith.Inventories.Commands.InventoryUnits;

/// <summary>
/// Class ChangeCustomerInformationHandler.
/// Implements the <see cref="CommandHandler{Parties.Commands.ChangeCustomerInformation}" />.
/// </summary>
/// <seealso cref="CommandHandler{Parties.Commands.ChangeCustomerInformation}" />
public class ChangeInventoryUnitHandler : CommandHandler<ChangeInventoryUnit>
{
    /// <inheritdoc/>
    public override async Task<IEnumerable<BaseMessage>> DoAsync([NotNull] ChangeInventoryUnit command, IAggregate? aggregate, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);
        return await Task.FromResult<IEnumerable<BaseMessage>>([new InventoryUnitChanged(
                    command.PartitionId,
                    command.CompanyId,
                    command.OriginId,
                    command.Id,
                    command.Name,
                    command.Description,
                    command.RoundDecimals)
                    ]).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public override async Task<IEnumerable<BaseMessage>> UndoAsync(ChangeInventoryUnit command, IAggregate? aggregate, CancellationToken cancellationToken)
    {
        await Task.CompletedTask.ConfigureAwait(false);
        throw new NotSupportedException();
    }
}