﻿/**
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reactive;
using Org.Apache.Reef.Common.io;
using Org.Apache.Reef.IO.Network.Naming;
using Org.Apache.Reef.IO.Network.NetworkService.Codec;
using Org.Apache.Reef.Utilities.Logging;
using Org.Apache.Reef.Tang.Annotations;
using Org.Apache.Reef.Tang.Exceptions;
using Org.Apache.Reef.Wake;
using Org.Apache.Reef.Wake.Remote;
using Org.Apache.Reef.Wake.Remote.Impl;
using Org.Apache.Reef.Wake.Util;

namespace Org.Apache.Reef.IO.Network.NetworkService
{
    /// <summary>
    /// Network service used for Reef Task communication.
    /// </summary>
    /// <typeparam name="T">The message type</typeparam>
    public class NetworkService<T> : INetworkService<T>
    {
        private Logger LOGGER = Logger.GetLogger(typeof(NetworkService<>));

        private IRemoteManager<NsMessage<T>> _remoteManager;
        private IObserver<NsMessage<T>> _messageHandler; 
        private ICodec<NsMessage<T>> _codec; 
        private IIdentifier _localIdentifier;
        private IDisposable _messageHandlerDisposable;
        private Dictionary<IIdentifier, IConnection<T>> _connectionMap;  

        /// <summary>
        /// Create a new NetworkFactory.
        /// </summary>
        /// <param name="nsPort">The port that the NetworkService will listen on</param>
        /// <param name="nameServerAddr">The address of the NameServer</param>
        /// <param name="nameServerPort">The port of the NameServer</param>
        /// <param name="messageHandler">The observer to handle incoming messages</param>
        /// <param name="idFactory">The factory used to create IIdentifiers</param>
        /// <param name="codec">The codec used for serialization</param>
        [Inject]
        public NetworkService(
            [Parameter(typeof(NetworkServiceOptions.NetworkServicePort))] int nsPort,
            [Parameter(typeof(NamingConfigurationOptions.NameServerAddress))] string nameServerAddr,
            [Parameter(typeof(NamingConfigurationOptions.NameServerPort))] int nameServerPort,
            IObserver<NsMessage<T>> messageHandler,
            IIdentifierFactory idFactory,
            ICodec<T> codec)
        {
            _codec = new NsMessageCodec<T>(codec, idFactory);

            IPAddress localAddress = NetworkUtils.LocalIPAddress;
            _remoteManager = new DefaultRemoteManager<NsMessage<T>>(localAddress, nsPort, _codec);
            _messageHandler = messageHandler;

            NamingClient = new NameClient(nameServerAddr, nameServerPort);
            _connectionMap = new Dictionary<IIdentifier, IConnection<T>>();

            LOGGER.Log(Level.Info, "Started network service");
        }

        /// <summary>
        /// Name client for registering ids
        /// </summary>
        public INameClient NamingClient { get; private set; }

        /// <summary>
        /// Open a new connection to the remote host registered to
        /// the name service with the given identifier
        /// </summary>
        /// <param name="destinationId">The identifier of the remote host</param>
        /// <returns>The IConnection used for communication</returns>
        public IConnection<T> NewConnection(IIdentifier destinationId)
        {
            if (_localIdentifier == null)
            {
                throw new IllegalStateException("Cannot open connection without first registering an ID");
            }

            IConnection<T> connection;
            if (_connectionMap.TryGetValue(destinationId, out connection))
            {
                return connection;
            }

            connection = new NsConnection<T>(_localIdentifier, destinationId, 
                NamingClient, _remoteManager, _connectionMap);

            _connectionMap[destinationId] = connection;
            return connection;
        }

        /// <summary>
        /// Register the identifier for the NetworkService with the NameService.
        /// </summary>
        /// <param name="id">The identifier to register</param>
        public void Register(IIdentifier id)
        {
            LOGGER.Log(Level.Info, "Registering id {0} with network service.", id);

            _localIdentifier = id;
            NamingClient.Register(id.ToString(), _remoteManager.LocalEndpoint);

            // Create and register incoming message handler
            var anyEndpoint = new IPEndPoint(IPAddress.Any, 0);
            _messageHandlerDisposable = _remoteManager.RegisterObserver(anyEndpoint, _messageHandler);
        }

        /// <summary>
        /// Unregister the identifier for the NetworkService with the NameService.
        /// </summary>
        public void Unregister()
        {
            if (_localIdentifier == null)
            {
                throw new IllegalStateException("Cannot unregister a non existant identifier");
            }

            NamingClient.Unregister(_localIdentifier.ToString());
            _localIdentifier = null;
            _messageHandlerDisposable.Dispose();
        }

        /// <summary>
        /// Dispose of the NetworkService's resources
        /// </summary>
        public void Dispose()
        {
            NamingClient.Dispose();
            _remoteManager.Dispose();

            LOGGER.Log(Level.Info, "Disposed of network service");
        }
    }
}
