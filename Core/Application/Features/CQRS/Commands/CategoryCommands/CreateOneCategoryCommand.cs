﻿using Application.Features.CQRS.Results.CategoryResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForCategoryCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.CategoryCommands
{
    public class CreateOneCategoryCommand : CategoryCommandForManipulation,IRequest<CreateOneCategoryCommandResult>
    {

    }
}
