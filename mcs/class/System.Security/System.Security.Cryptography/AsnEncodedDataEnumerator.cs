//
// System.Security.Cryptography.AsnEncodedDataEnumerator
//
// Author:
//	Sebastien Pouliot  <sebastien@ximian.com>
//
// (C) 2003 Motus Technologies Inc. (http://www.motus.com)
// Copyright (C) 2004 Novell Inc. (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

#if NET_2_0

using System;
using System.Collections;

namespace System.Security.Cryptography {

	public sealed class AsnEncodedDataEnumerator : IEnumerator {

		private AsnEncodedDataCollection _collection;
		private int _position;

		// note: couldn't reuse the IEnumerator from ArrayList because 
		// it doesn't throw the same exceptions
		internal AsnEncodedDataEnumerator (AsnEncodedDataCollection collection) 
		{
			_collection = collection;
			_position = -1;
		}

		// properties

		public AsnEncodedData Current {
			get {
				if (_position < 0)
					throw new ArgumentOutOfRangeException ();
				return (AsnEncodedData) _collection [_position];
			}
		}

		object IEnumerator.Current {
			get {
				if (_position < 0)
					throw new ArgumentOutOfRangeException ();
				return _collection [_position];
			}
		}

		// methods

		public bool MoveNext () 
		{
			if (++_position < _collection.Count)
				return true;
			else {
				// strangely we must always be able to return the last entry 
				_position = _collection.Count - 1;
				return false;
			}
		}

		public void Reset () 
		{
			_position = -1;
		}
	}
}

#endif
