using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Sy.AutoMapper.Extensions
{
    ///<summary>
    /// automapper扩展
    ///</summary>
    public static partial class MapperExtension
    {
        private static IServiceProvider _serviceProvider;

        public static void UseStaticAutoMapper(this IApplicationBuilder applicationBuilder)
        {
            _serviceProvider = applicationBuilder.ApplicationServices;
        }

        public static void UseStaticAutoMapper(this IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        ///<summary>
        ///  类型映射
        ///</summary>
        public static T MapTo<T>(this object obj)
        {
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            return mapper.Map<T>(obj);
        }


        ///<summary>
        /// 类型映射
        ///</summary>
        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            return mapper.Map(source, destination);
        }

        ///<summary>
        /// 集合列表类型映射
        ///</summary>
        public static List<TDestination> MapToList<TDestination>(this IEnumerable source)
        {
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            return mapper.Map<List<TDestination>>(source);
        }

        ///<summary>
        /// 集合列表类型映射
        ///</summary>
        public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            return mapper.Map<List<TDestination>>(source);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static (List<TDestination> list, int total) MapToPage<TDestination>(this (IEnumerable list, int total) input)
        {
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            var list = mapper.Map<List<TDestination>>(input.list);
            return (list, input.total);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static (List<TDestination> list, int total) MapToPage<TSource, TDestination>(this (List<TSource> list, int total) input)
        {
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            var list = mapper.Map<List<TDestination>>(input.list);
            return (list, input.total);
        }

    }
}
