/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */

/*
 * SerializedSharedReference
 * Base class to work with SSV. This is the class drawn in the inspector.
 *
 * by Adam Carballo (AdamCarballo).
 * https://github.com/AdamCarballo/Unity-SerializedSharedVariables
 */

using JetBrains.Annotations;
using UnityEngine;

namespace EngyneCreations.SSV.Models {
	public abstract class SerializedSharedReference<TV, TT> where TV : SerializedSharedVariable<TT> {

		[UsedImplicitly]
		[SerializeField]
		private bool _useConstant = true;
		
		[UsedImplicitly]
		[SerializeField]
		private TT _constantValue;

		[UsedImplicitly]
		[SerializeField]
		private TV _variable;


		public virtual TT Value {
			get => _useConstant ? _constantValue : _variable.Value;
			set {
				if (_useConstant) {
					_constantValue = value;
				} else {
					_variable.Value = value;
				}
			}
		}

		public SerializedSharedReference(TT defaultConstantValue) {
			_constantValue = defaultConstantValue;
		}

		public SerializedSharedReference(bool loadUsingConstant = true) {
			_useConstant = loadUsingConstant;
		}

	}
}