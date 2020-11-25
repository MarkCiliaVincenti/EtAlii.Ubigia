﻿namespace EtAlii.xTechnology.MicroContainer.Tests
{
    public class SecondChild : ISecondChild, IInitializable<IParent>
    {
        public int Counter { get; private set; }
        public IParent Parent { get; private set; }

        public void Initialize(IParent initial)
        {
            Parent = initial;
            Counter++;
        }
    }
}
