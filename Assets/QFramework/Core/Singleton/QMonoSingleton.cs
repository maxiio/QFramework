﻿/****************************************************************************
 * Copyright (c) 2017 snowcold
 * Copyright (c) 2017 liangxie
 * 
 * http://liangxiegame.com
 * https://github.com/liangxiegame/QFramework
 * https://github.com/SnowCold/SCFramework_Engine
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
****************************************************************************/

using UnityEngine;
using System;
/// <summary>
/// 需要使用MonoBehaviour的单例模式
/// </summary>
namespace QFramework {

	public abstract class QMonoSingleton<T> : MonoBehaviour,ISingleton where T : QMonoSingleton<T>
	{
		protected static T mInstance = null;
		static object mLock = new object();

		public static T Instance
		{
			get {
				lock (mLock) 
				{
					if (mInstance == null) 
					{
						mInstance = QSingletonCreator.CreateMonoSingleton<T> ();
					}
				}
				return mInstance;
			}
		}

		public virtual void OnSingletonInit()
		{

		}

		protected virtual void OnDestroy()
		{
			mInstance = null;
		}
	}
}