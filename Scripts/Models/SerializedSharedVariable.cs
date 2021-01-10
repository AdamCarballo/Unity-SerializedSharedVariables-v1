/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */

/*
 * SerializedSharedVariable
 * Base class of SSV.
 *
 * by Adam Carballo (AdamCarballo).
 * https://github.com/AdamCarballo/Unity-SerializedSharedVariables
 */

using System;
using UnityEngine;

namespace EngyneCreations.SSV.Models {
	public abstract class SerializedSharedVariable<T> : ScriptableObject {

		[SerializeField]
		private T _value;

		[NonSerialized]
		private T _currentValue;

		public virtual T Value {
			get => _currentValue;
			set => _currentValue = value;
		}

		protected virtual void OnValidate() {
			_currentValue = _value;
		}

		protected virtual void OnEnable() {
			_currentValue = _value;
		}

	}
}