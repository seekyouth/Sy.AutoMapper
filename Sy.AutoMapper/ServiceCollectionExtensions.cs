using Sy.AutoMapper.Helper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using AutoMapper;

namespace Sy.AutoMapper
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加对象映射
        /// </summary>
        /// <param name="services">依赖注入服务集合</param>
        /// <param name="assemblyNames">包含映射配置的程序集名称列表</param>
        /// <returns>更新后的依赖注入服务集合</returns>
        public static IServiceCollection AddMappers(this IServiceCollection service, params string[] assemblyNames)
        {
            // 检查服务集合是否为空，如果为空则抛出异常
            if (service == null)
                throw new ArgumentNullException("service");
            // 检查程序集名称列表是否为空，如果为空则抛出异常
            if (!assemblyNames?.Any()??false)
                throw new ArgumentNullException(paramName: "程序名称为空");
            // 通过RuntimeHelper工具类获取程序集列表
            var assemblys = AssemblyHelper.GetAssemblys(assemblyNames);
            // 检查获取的程序集列表是否为空，如果为空则抛出DllNotFoundException异常
            if (assemblys == null)
                throw new DllNotFoundException("the dll \"" + string.Join(",", assemblyNames) + "\" not be found");
            // 创建AutoMapper的配置对象
            var config = new MapperConfiguration(cfg =>
            {
                // 添加程序集中的映射配置
                cfg.AddMaps(assemblys);
                // 遍历每个程序集
                foreach (var assembly in assemblys)
                {
                    // 获取程序集中所有实现IMapperConfig接口的类型
                    var types = assembly.GetTypes().Where(t => typeof(IMapperConfig).IsAssignableFrom(t));
                    // 遍历每个实现IMapperConfig接口的类型
                    foreach (var type in types)
                    {
                        // 创建该类型的实例，并将其作为IMapperConfig接口实例处理
                        // 调用其Bind方法，将映射配置绑定到AutoMapper的配置对象中
                        ((IMapperConfig)Activator.CreateInstance(type)).Bind(cfg);
                    }
                }
            });
            // 使用AutoMapper的配置对象创建映射器，并将其作为单例添加到服务集合中
            service.AddSingleton(config.CreateMapper());
            // 返回更新后的服务集合
            return service;
        }
    }
}