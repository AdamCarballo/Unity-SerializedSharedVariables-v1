/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */

/*
 * SerializedSharedVariable
 * Base class of SSV.
 *
 * by Adam Carballo (AdamEC).
 * https://github.com/AdamEC/Unity-SerializedSharedVariables
 */

using System;
using UnityEngine;

namespace EngyneCreations.SSV.Models {

    public abstract class SerializedSharedVariable <T> : ScriptableObject {

        [SerializeField] protected T _value;
        [NonSerialized] protected T _currentValue;


        public virtual T Value {
            get { return _currentValue; }
            set { _currentValue = value; }
        }

        protected virtual void OnValidate() {
            _currentValue = _value;
        }

        protected virtual void OnEnable() {
            _currentValue = _value;
        }
    }
}