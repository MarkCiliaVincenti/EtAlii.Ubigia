﻿namespace EtAlii.Ubigia.Infrastructure.Functional
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class EntryRepositoryException : Exception
    {
        protected EntryRepositoryException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        
        public EntryRepositoryException(string message)
            : base(message)
        {
        }

        public EntryRepositoryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}