// Copyright 2004-2009 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Castle.MicroKernel.Registration.Interceptor
{
	using Castle.DynamicProxy;
	using Core;

	public class InterceptorGroup<S> : RegistrationGroup<S>
	{
		private readonly InterceptorReference[] interceptors;

		public InterceptorGroup(ComponentRegistration<S> registration,
		                        InterceptorReference[] interceptors)
			: base(registration)
		{
			this.interceptors = interceptors;
		}

		public ComponentRegistration<S> Anywhere
		{
			get
			{
				AddDescriptor(new InterceptorDescriptor<S>(interceptors));
				return Registration;
			}
		}

		public ComponentRegistration<S> First
		{
			get
			{
				AddDescriptor(new InterceptorDescriptor<S>(
					interceptors, InterceptorDescriptor<S>.Where.First));
				return Registration;
			}
		}

		public ComponentRegistration<S> Last
		{
			get
			{
				AddDescriptor(new InterceptorDescriptor<S>(
					interceptors, InterceptorDescriptor<S>.Where.Last));
				return Registration;
			}
		}

		public ComponentRegistration<S> AtIndex(int index)
		{
			AddDescriptor(new InterceptorDescriptor<S>(interceptors, index));
			return Registration;
		}

		public InterceptorGroup<S> SelectedWith(IInterceptorSelector selector)
		{
			Registration.SelectInterceptorsWith(selector);
			return this;
		}
	}
}