﻿using wallet_stellar_api.Application.TodoLists.Commands.CreateTodoList;
using wallet_stellar_api.Application.TodoLists.Commands.DeleteTodoList;
using wallet_stellar_api.Application.TodoLists.Commands.UpdateTodoList;
using wallet_stellar_api.Application.TodoLists.Queries.GetTodos;

namespace wallet_stellar_api.Web.Endpoints;

public class TodoLists : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetTodoLists)
            .MapPost(CreateTodoList)
            .MapPut(UpdateTodoList, "{id}")
            .MapDelete(DeleteTodoList, "{id}");
    }

    public Task<TodosVm> GetTodoLists(ISender sender)
    {
        return  sender.Send(new GetTodosQuery());
    }

    public Task<Guid> CreateTodoList(ISender sender, CreateTodoListCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdateTodoList(ISender sender, Guid id, UpdateTodoListCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteTodoList(ISender sender, Guid id)
    {
        await sender.Send(new DeleteTodoListCommand(id));
        return Results.NoContent();
    }
}
