﻿namespace EtAlii.Servus.Api
{
    using System;
    using EtAlii.xTechnology.Logging;

    public class LoggingStorageConnection : IStorageConnection 
    {
        private readonly IStorageConnection _connection;
        private readonly ILogger _logger;

        private string _accountName;
        private string _address;


        public LoggingStorageConnection(
            IStorageConnection connection,
            ILogger logger)
        {
            _connection = connection;
            _logger = logger;
        }

        public Storage Storage { get { return _connection.Storage; } }
        public bool IsConnected { get { return _connection.IsConnected; } }

        public void Open(string address, string accountName)
        {
            _address = address;
            _accountName = accountName;

            var message = String.Format("Opening storage connection (Address: {0} Account: {1})", _address, _accountName);
            _logger.Info(message);
            var start = Environment.TickCount;

            _connection.Open(address, accountName);

            message = String.Format("Opened storage connection (Address: {0} Account: {1} Duration: {2}ms)", _address, _accountName, Environment.TickCount - start);
            _logger.Info(message);
        }

        public void Open(string address, string accountName, string password)
        {
            _address = address;
            _accountName = accountName;

            var message = String.Format("Opening storage connection (Address: {0} Account: {1})", _address, _accountName);
            _logger.Info(message);
            var start = Environment.TickCount;

            _connection.Open(address, accountName, password);

            message = String.Format("Opened storage connection (Address: {0} Account: {1} Duration: {2}ms)", _address, _accountName, Environment.TickCount - start);
            _logger.Info(message);
        }

        public void Close()
        {
            var message = String.Format("Closing storage connection (Address: {0} Account: {1})", _address, _accountName);
            _logger.Info(message);
            var start = Environment.TickCount;

            _connection.Close();

            message = String.Format("Closed storage connection (Address: {0} Account: {1} Duration: {2}ms)", _address, _accountName, Environment.TickCount - start);
            _logger.Info(message);
        }
    }
}
