﻿namespace EtAlii.Ubigia.Api.Functional
{
    using EtAlii.Ubigia.Api.Functional.Traversal;

    public class SelectNodeValueAnnotation : NodeValueAnnotation
    {
        public SelectNodeValueAnnotation(PathSubject source) : base(source)
        {
        }

        public override string ToString()
        {
            return $"@{AnnotationPrefix.NodeValue}({Source?.ToString() ?? string.Empty})";
        }
    }
}
