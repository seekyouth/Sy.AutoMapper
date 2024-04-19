using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sy.AutoMapper.Extensions
{
    ///<summary>
    /// automapper扩展
    ///</summary>
    public static partial class MapperExtension
    {
        ///<summary>
        ///  类型映射
        ///</summary>
        public static async Task<TDestination> MapToAsync<TSource, TDestination>(this Task<TSource> input)
        {
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            return mapper.Map<TDestination>(await input);
        }

        ///<summary>
        ///  类型映射
        ///</summary>
        public static async ValueTask<TDestination> MapToAsync<TSource, TDestination>(this ValueTask<TSource> input)
        {
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            return mapper.Map<TDestination>(await input);
        }

        ///<summary>
        /// 类型映射
        ///</summary>
        public static async Task<TDestination> MapToAsync<TSource, TDestination>(this Task<TSource> input, TDestination destination)
        {
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            return mapper.Map(await input, destination);
        }

        ///<summary>
        /// 类型映射
        ///</summary>
        public static async Task<TDestination> MapToAsync<TDestination>(this object source, Task<TDestination> destination)
        {
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            return mapper.Map(source, await destination);
        }

        ///<summary>
        /// 类型映射
        ///</summary>
        public static async ValueTask<TDestination> MapToAsync<TDestination>(this object source, ValueTask<TDestination> destination)
        {
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            return mapper.Map(source, await destination);
        }

        ///<summary>
        /// 类型映射
        ///</summary>
        public static async ValueTask<TDestination> MapToAsync<TSource, TDestination>(this ValueTask<TSource> input, TDestination destination)
        {
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            return mapper.Map(await input, destination);
        }

        ///<summary>
        /// 集合列表类型映射
        ///</summary>
        public static async Task<List<TDestination>> MapToListAsync<TSource, TDestination>(this Task<List<TSource>> input)
        {
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            return mapper.Map<List<TDestination>>(await input);
        }

        ///<summary>
        /// 集合列表类型映射
        ///</summary>
        public static async ValueTask<List<TDestination>> MapToListAsync<TSource, TDestination>(this ValueTask<List<TSource>> input)
        {
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            return mapper.Map<List<TDestination>>(await input);
        }

        ///<summary>
        /// 集合列表类型映射
        ///</summary>
        public static async Task<List<TDestination>> MapToListAsync<TSource, TDestination>(this Task<IEnumerable<TSource>> input)
        {
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            return mapper.Map<List<TDestination>>(await input);
        }

        ///<summary>
        /// 集合列表类型映射
        ///</summary>
        public static async ValueTask<List<TDestination>> MapToListAsync<TSource, TDestination>(this ValueTask<IEnumerable<TSource>> input)
        {
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            return mapper.Map<List<TDestination>>(await input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static async Task<(List<TDestination> list, int total)> MapToPageAsync<TSource, TDestination>(this ValueTask<(List<TSource> list, int total)> task)
        {
            var input = await task;
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
        public static async Task<(List<TDestination> list, int total)> MapToPageAsync<TSource, TDestination>(this Task<(List<TSource> list, int total)> task)
        {
            var input = await task;
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
        public static async Task<(List<TDestination> list, int total)> MapToPageAsync<TDestination>(this ValueTask<(IEnumerable list, int total)> task)
        {
            var input = await task;
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
        public static async Task<(List<TDestination> list, int total)> MapToPageAsync<TDestination>(this Task<(IEnumerable list, int total)> task)
        {
            var input = await task;
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            var list = mapper.Map<List<TDestination>>(input.list);
            return (list, input.total);
        }
    }
}
