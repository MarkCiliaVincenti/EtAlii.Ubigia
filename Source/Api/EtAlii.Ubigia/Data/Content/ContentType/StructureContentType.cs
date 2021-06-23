﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license in https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia
{
    public class StructureContentType : ContentType
    {
        private const string StructureContentTypeId = "Structure";

        public ContentType Hierarchy { get; } = new(StructureContentTypeId, "Hierarchy");

        internal StructureContentType()
            : base(StructureContentTypeId)
        {
        }
    }
}
