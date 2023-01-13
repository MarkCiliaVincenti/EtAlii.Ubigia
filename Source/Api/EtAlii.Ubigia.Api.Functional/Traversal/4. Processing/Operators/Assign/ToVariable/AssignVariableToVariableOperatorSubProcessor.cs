// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Api.Functional.Traversal;

using System;
using System.Threading.Tasks;

public class AssignVariableToVariableOperatorSubProcessor : IAssignVariableToVariableOperatorSubProcessor
{
    public Task Assign(OperatorParameters parameters)
    {
        var variableSubject = (VariableSubject)parameters.LeftSubject;
        var subject = parameters.RightSubject;
        var source = subject.ToString();

        var variableName = variableSubject.Name;

        var variable = new ScopeVariable(parameters.RightInput, source);
        parameters.Scope.Variables[variableName] = variable;

        parameters.RightInput.Subscribe(
            onError: (e) => parameters.Output.OnError(e),
            onCompleted: () => parameters.Output.OnCompleted(),
            onNext: o => parameters.Output.OnNext(o));
        return Task.CompletedTask;
    }
}
