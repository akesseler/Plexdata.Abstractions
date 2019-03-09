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

using Microsoft.AspNetCore.Http;
using Plexdata.AspNetCore.Http.Abstraction;
using Plexdata.AspNetCore.Http.Facades;
using System;

namespace Plexdata.AspNetCore.Http.Factories
{
    /// <summary>
    /// The implementation of interface <see cref="IHttpContextCreator"/>.
    /// </summary>
    /// <remarks>
    /// This class represents the default implementation of interface <see cref="IHttpContextCreator"/>. 
    /// Intentionally, this class is made as internal to prevent a creation of instances of this class by 
    /// the outside world.
    /// </remarks>
    internal class HttpContextCreator : IHttpContextCreator
    {
        /// <summary>
        /// An instance of the service provider to be used.
        /// </summary>
        /// <remarks>
        /// The instance of the service provider will be provided by the standard dependency injection within 
        /// the class constructor.
        /// </remarks>
        private readonly IServiceProvider provider = null;

        /// <summary>
        /// The standard class constructor.
        /// </summary>
        /// <remarks>
        /// This constructor just initializes its properties.
        /// </remarks>
        /// <param name="provider">
        /// The service provider to be used to resolve interface implementations.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// This exception is thrown if parameter <paramref name="provider"/> is <c>null</c>.
        /// </exception>
        public HttpContextCreator(IServiceProvider provider)
        {
            this.provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        /// <inheritdoc />
        public IHttpContextFacade Create()
        {
            return this.provider.GetService(typeof(IHttpContextFacade)) as IHttpContextFacade;
        }

        /// <inheritdoc />
        public IHttpContextFacade Create(HttpContext context)
        {
            return new HttpContextFacade(context);
        }
    }
}
