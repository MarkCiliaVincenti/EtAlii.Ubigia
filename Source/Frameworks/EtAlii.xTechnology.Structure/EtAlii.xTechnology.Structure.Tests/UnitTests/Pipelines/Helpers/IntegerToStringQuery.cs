// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.xTechnology.Structure.Tests
{
    using EtAlii.xTechnology.Structure;

    public class IntegerToStringQuery : Query<int>
    {
        public IntegerToStringQuery(int parameter) 
            : base(parameter)
        {
        }

        public int Integer => ((IParams<int>)this).Parameter;
    }
}