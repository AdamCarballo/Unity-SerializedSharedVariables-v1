/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */

/*
 * InspectorTest
 * Demostration of how SSV are drawn on the inspector
 *
 * by Adam Carballo (AdamEC).
 * https://github.com/AdamEC/Unity-SerializedSharedVariables
 */

using EngyneCreations.SSV.Variables;
using UnityEngine;

namespace EngyneCreations.SSV.Demo {

    public class InspectorTest : MonoBehaviour {

        public StringReference Text;
        public StringReference AnotherText;
        public CustomClassReference CustomClass;
        public StringReference MoreText;
        public StringReference[] TextList;
        public Int32Reference Integer;
    }
}