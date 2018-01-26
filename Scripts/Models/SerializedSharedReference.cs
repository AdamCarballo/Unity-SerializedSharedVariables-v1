/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */

/*
 * SerializedSharedReference
 * Base class to work with SSV. This is the class drawn in the inspector.
 *
 * by Adam Carballo (AdamEC).
 * https://github.com/AdamEC/Unity-SerializedSharedVariables
 */

namespace EngyneCreations.SSV.Models {

    public abstract class SerializedSharedReference <V, T> where V : SerializedSharedVariable<T> {

        public bool UseConstant = true;
        public T ConstantValue;
        public V Variable;


        public virtual T Value {
            get { return UseConstant ? ConstantValue : Variable.Value; }
            set {
                if (UseConstant) {
                    ConstantValue = value;
                } else {
                    Variable.Value = value;
                }
            }
        }

        public SerializedSharedReference(T defaultConstantValue) {
            ConstantValue = defaultConstantValue;
        }

        public SerializedSharedReference(bool loadUsingConstant = true) {
            UseConstant = loadUsingConstant;
        }
    }
}