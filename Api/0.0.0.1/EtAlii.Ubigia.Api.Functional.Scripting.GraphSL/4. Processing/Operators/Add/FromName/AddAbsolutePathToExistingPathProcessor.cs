﻿namespace EtAlii.Ubigia.Api.Functional
{
    using System;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using System.Threading.Tasks;
    using EtAlii.Ubigia.Api.Logical;

    internal class AddAbsolutePathToExistingPathProcessor : AddToExistingPathProcessorBase, IAddAbsolutePathToExistingPathProcessor
    {
        private readonly IProcessingContext _processingContext;

        public AddAbsolutePathToExistingPathProcessor(
            IItemToPathSubjectConverter itemToPathSubjectConverter,
            IItemToIdentifierConverter itemToIdentifierConverter, 
            IProcessingContext processingContext)
            : base(itemToPathSubjectConverter, itemToIdentifierConverter)
        {
            _processingContext = processingContext;
        }

        protected override Task Add(Identifier parentId, PathSubject pathToAdd, ExecutionScope scope, IObserver<object> output)
        {
            var absolutePathSubjectToAdd = (AbsolutePathSubject )pathToAdd;
            var inputObservable = Observable.Create<object>(async observer =>
            {
                await _processingContext.AbsolutePathSubjectProcessor.Process(absolutePathSubjectToAdd, scope, observer);

                return Disposable.Empty;
            });

            inputObservable.SubscribeAsync(
                onError: output.OnError,
                onCompleted: output.OnCompleted,
                onNext: async o =>
                {
                    var identifierToAdd = await this.ItemToIdentifierConverter.Convert(o, scope);
                    var newEntry = await _processingContext.Logical.Nodes.Add(parentId, identifierToAdd, scope);
                    var result = new DynamicNode(newEntry);
                    output.OnNext(result);
                });
            return Task.CompletedTask;
        }
    }
}
