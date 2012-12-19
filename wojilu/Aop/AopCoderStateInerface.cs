﻿/*
 * Copyright 2010 www.wojilu.com
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *      http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace wojilu.Aop {

    internal class AopCoderStateInerface : AopCoderState {
        public override String GetClassPrefix() {
            return "__I_";
        }

        public override String InvokeTarget() {
            return "m_objTarget";
        }

        public override String GetBasePrefix() {
            return "__base_";
        }

        public override String GetMethodOverride() {
            return "";
        }

        public override String GetInvokeTargetThis() {
            return "m_objTarget";
        }

        public override string IsSubClassStr() {
            return "false";
        }

        public override String GetClassFullName( Type t, String interfaceFullName ) {
            String interfacePrefix = GetClassPrefix() + interfaceFullName.Replace( ".", "_" ) + "_";
            return interfacePrefix + t.Name;
        }
    }
}
