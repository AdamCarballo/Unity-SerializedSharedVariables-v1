/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */

/*
 * CustomClass
 * Simple custom class to demostrate the use of custom classes with generated SSV
 *
 * by Adam Carballo (AdamCarballo).
 * https://github.com/AdamCarballo/Unity-SerializedSharedVariables
 */

using EngyneCreations.SSV.Variables;

namespace EngyneCreations.SSV.Demo {

    [System.Serializable]
    public class CustomClass {

        public bool Toggle;
        public float Number;
        public float[] NumberList;
        public StringReference Text;
        public StringReference[] TextList;
    }
}