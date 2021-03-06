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
package org.apache.reef.io.network.naming.serialization;

import org.apache.reef.io.naming.NameAssignment;

import java.util.List;

/**
 * Naming lookup response
 */
public class NamingLookupResponse extends NamingMessage {
  private final List<NameAssignment> nas;

  /**
   * Constructs a naming lookup response
   *
   * @param nas the list of name assignments
   */
  public NamingLookupResponse(List<NameAssignment> nas) {
    this.nas = nas;
  }

  /**
   * Gets name assignments
   *
   * @return a list of name assignments
   */
  public List<NameAssignment> getNameAssignments() {
    return nas;
  }
}
