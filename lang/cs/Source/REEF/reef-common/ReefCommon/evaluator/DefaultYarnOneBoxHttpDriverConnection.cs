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

using Org.Apache.Reef.Tang.Annotations;
using System;
using System.Globalization;

namespace Org.Apache.Reef.Common.Evaluator
{
    public class DefaultYarnOneBoxHttpDriverConnection : IDriverConnection
    {
        [Inject]
        public DefaultYarnOneBoxHttpDriverConnection()
        {
        }

        public DriverInformation GetDriverInformation(string applicationId)
        {
            // e.g., http://yingdac1:8088/proxy/application_1407519727821_0012/reef/v1/driver
            string oneBoxHost = string.Format(CultureInfo.InvariantCulture, "http://{0}:8088/proxy/", Environment.MachineName);
            Uri queryUri = new Uri(
                string.Concat(
                oneBoxHost,
                applicationId,
                Constants.HttpReefUriSpecification,
                Constants.HttpDriverUriTarget));
            return DriverInformation.GetDriverInformationFromHttp(queryUri);
        }
    }
}
