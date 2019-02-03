﻿namespace EtAlii.Ubigia.Api.Logical
{
    using System;

    public partial class Node : IInternalNode
    {
        // TODO: There should be no properties on the Node base class.

        Identifier INode.Id => _entry.Id;

        public string Type => _entry.Type;

        bool INode.IsModified => _isModified;
        private bool _isModified;

        IReadOnlyEntry IInternalNode.Entry => _entry;
        private IReadOnlyEntry _entry;

        private readonly int _uniqueHashCode;

        public Node(IReadOnlyEntry entry)
        {
            _entry = entry;
            _uniqueHashCode = (_entry?.Id ?? Identifier.Empty).GetHashCode(); // We want a unique, never changing hash for the node.
        }

        void IInternalNode.Update(PropertyDictionary properties, IReadOnlyEntry entry)
        {
            _entry = entry ?? throw new ArgumentNullException(nameof(entry));
            _properties = properties ?? throw new ArgumentNullException(nameof(properties));
            _isModified = false;
        }

        public override string ToString()
        {
            return _entry.Type;
        }
    }
}