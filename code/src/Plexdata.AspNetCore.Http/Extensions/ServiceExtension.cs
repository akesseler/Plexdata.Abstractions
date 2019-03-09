/*
 * MIT License
 * 
 * Copyright (c) 2019 plexdata.de
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using Microsoft.Extensions.DependencyInjection;
using Plexdata.AspNetCore.Http.Abstraction;
using Plexdata.AspNetCore.Http.Facades;
using Plexdata.AspNetCore.Http.Factories;

namespace Plexdata.AspNetCore.Http.Extensions
{
    /// <summary>
    /// The public class to register all dependencies.
    /// </summary>
    /// <remarks>
    /// This class contains methods to perform interface registrations 
    /// for dependency injection.
    /// </remarks>
    public static class ServiceExtension
    {
        /// <summary>
        /// Adds all supported services to the service collection.
        /// </summary>
        /// <remarks>
        /// This method adds all supported and required services to the 
        /// provided service collection instance and makes them injectable 
        /// in other implementations.
        /// </remarks>
        /// <param name="services">
        /// The service collection to add all services to.
        /// </param>
        /// <returns>
        /// The provided service collection.
        /// </returns>
        public static IServiceCollection AddPlexdataHttpServices(this IServiceCollection services)
        {
            if (services != null)
            {
                services.AddHttpContextAccessor();
                services.AddSingleton<IHttpContextCreator, HttpContextCreator>();
                services.AddTransient<IHttpContextFacade, HttpContextFacade>();
            }

            return services;
        }
    }
}
