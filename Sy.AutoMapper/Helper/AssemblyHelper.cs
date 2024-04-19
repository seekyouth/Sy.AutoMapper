using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace Sy.AutoMapper.Helper
{
    public static class AssemblyHelper
    {
        
        /// <summary>
        /// 根据正常名称获取程序集
        /// </summary>
        /// <param name="assemblyNames"></param>
        /// <returns></returns>
        public static List<Assembly> GetAssemblys(params string[] assemblyNames)
        {
            return assemblyNames.Select(m => Assembly.Load(m)).Where(m => m != null).ToList();
        }

    }
}
