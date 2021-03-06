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
package org.apache.reef.driver.parameters;

import org.apache.reef.runtime.common.DriverRestartCompleted;
import org.apache.reef.runtime.common.driver.defaults.DefaultDriverRestartCompletedHandler;
import org.apache.reef.tang.annotations.Name;
import org.apache.reef.tang.annotations.NamedParameter;
import org.apache.reef.wake.EventHandler;

import java.util.Set;

/**
 * Handler for event that all evaluators have checked back in after driver restart and that the restart is completed
 */
@NamedParameter(doc = "Handler for event of driver restart completion", default_classes = DefaultDriverRestartCompletedHandler.class)
public final class DriverRestartCompletedHandlers implements Name<Set<EventHandler<DriverRestartCompleted>>> {
  private DriverRestartCompletedHandlers() {
  }
}
