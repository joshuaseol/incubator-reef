/**
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
package org.apache.reef.runtime.mesos.driver;

import org.apache.reef.annotations.audience.Private;
import org.apache.reef.proto.DriverRuntimeProtocol.NodeDescriptorProto;
import org.apache.reef.proto.DriverRuntimeProtocol.ResourceAllocationProto;
import org.apache.reef.proto.DriverRuntimeProtocol.ResourceStatusProto;
import org.apache.reef.proto.DriverRuntimeProtocol.RuntimeStatusProto;
import org.apache.reef.runtime.common.driver.api.RuntimeParameters;
import org.apache.reef.tang.annotations.Parameter;
import org.apache.reef.wake.EventHandler;

import javax.inject.Inject;

@Private
final class REEFEventHandlers {
  private final EventHandler<ResourceAllocationProto> resourceAllocationEventHandler;
  private final EventHandler<RuntimeStatusProto> runtimeStatusEventHandler;
  private final EventHandler<NodeDescriptorProto> nodeDescriptorEventHandler;
  private final EventHandler<ResourceStatusProto> resourceStatusHandlerEventHandler;

  @Inject
  REEFEventHandlers(final @Parameter(RuntimeParameters.ResourceAllocationHandler.class) EventHandler<ResourceAllocationProto> resourceAllocationEventHandler,
                    final @Parameter(RuntimeParameters.RuntimeStatusHandler.class) EventHandler<RuntimeStatusProto> runtimeStatusEventHandler,
                    final @Parameter(RuntimeParameters.NodeDescriptorHandler.class) EventHandler<NodeDescriptorProto> nodeDescriptorEventHandler,
                    final @Parameter(RuntimeParameters.ResourceStatusHandler.class) EventHandler<ResourceStatusProto> resourceStatusHandlerEventHandler) {
    this.resourceAllocationEventHandler = resourceAllocationEventHandler;
    this.runtimeStatusEventHandler = runtimeStatusEventHandler;
    this.nodeDescriptorEventHandler = nodeDescriptorEventHandler;
    this.resourceStatusHandlerEventHandler = resourceStatusHandlerEventHandler;
  }

  void onNodeDescriptor(final NodeDescriptorProto nodeDescriptorProto) {
    this.nodeDescriptorEventHandler.onNext(nodeDescriptorProto);
  }

  void onRuntimeStatus(final RuntimeStatusProto runtimeStatusProto) {
    this.runtimeStatusEventHandler.onNext(runtimeStatusProto);
  }

  void onResourceAllocation(final ResourceAllocationProto resourceAllocationProto) {
    this.resourceAllocationEventHandler.onNext(resourceAllocationProto);
  }

  void onResourceStatus(final ResourceStatusProto resourceStatusProto) {
    this.resourceStatusHandlerEventHandler.onNext(resourceStatusProto);
  }
}