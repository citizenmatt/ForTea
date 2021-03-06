﻿#region License
//    Copyright 2012 Julien Lebosquain
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
#endregion
using JetBrains.Annotations;
using JetBrains.Application;
using JetBrains.DataFlow;
using JetBrains.ProjectModel;
using JetBrains.Util;
#if SDK80
using JetBrains.ReSharper.Psi.Modules;
#else
using JetBrains.ReSharper.Psi;
#endif

namespace GammaJul.ReSharper.ForTea.Psi {

	/// <summary>
	/// Provides a <see cref="T4ProjectPsiModuleHandler"/> for a given project.
	/// </summary>
	[SolutionComponent]
	public class T4ProjectPsiModuleProviderFilter : IProjectPsiModuleProviderFilter {

		private readonly ChangeManager _changeManager;
		private readonly T4Environment _t4Environment;

		public JetTuple<IProjectPsiModuleHandler, IPsiModuleDecorator> OverrideHandler(Lifetime lifetime, IProject project, IProjectPsiModuleHandler handler) {
			var t4ModuleHandler = new T4ProjectPsiModuleHandler(lifetime, handler, _changeManager, _t4Environment, project);
			return new JetTuple<IProjectPsiModuleHandler, IPsiModuleDecorator>(t4ModuleHandler, null);
		}

		public T4ProjectPsiModuleProviderFilter([NotNull] ChangeManager changeManager, [NotNull] T4Environment t4Environment) {
			_changeManager = changeManager;
			_t4Environment = t4Environment;
		}

	}

}