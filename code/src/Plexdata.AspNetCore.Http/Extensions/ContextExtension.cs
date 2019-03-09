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

namespace Plexdata.AspNetCore.Http.Extensions
{
    /// <summary>
    /// The extension to transform interfaces into real objects.
    /// </summary>
    /// <remarks>
    /// This class provides methods to be able to transform provided 
    /// interfaces into their object representations.
    /// </remarks>
    public static class ContextExtension
    {
        /// <summary>
        /// Converts an instance of interface <see cref="IHttpContextFacade"/> 
        /// into its instance of class <see cref="HttpContext"/>.
        /// </summary>
        /// <remarks>
        /// This method tries to convert provided instance of <see cref="IHttpContextFacade"/> 
        /// into the instance of <see cref="HttpContext"/>.
        /// </remarks>
        /// <param name="facade">
        /// The HTTP context facade to be converted.
        /// </param>
        /// <returns>
        /// The converted HTTP context implementation.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// This exception is thrown if provided instance of <see cref="IHttpContextFacade"/> 
        /// is <c>null</c>.
        /// </exception>
        /// <exception cref="InvalidCastException">
        /// This exception is thrown if provided instance of <see cref="IHttpContextFacade"/> 
        /// is not of type <see cref="HttpContextFacade"/>, the default interface implementation.
        /// </exception>
        public static HttpContext ToInstance(this IHttpContextFacade facade)
        {
            if (facade == null)
            {
                throw new ArgumentNullException(nameof(facade));
            }

            if (facade is HttpContextFacade)
            {
                return (facade as HttpContextFacade).Instance;
            }

            throw new InvalidCastException();
        }

        /// <summary>
        /// Converts an instance of interface <see cref="IHttpRequestFacade"/> 
        /// into its instance of class <see cref="HttpRequest"/>.
        /// </summary>
        /// <remarks>
        /// This method tries to convert provided instance of <see cref="IHttpRequestFacade"/> 
        /// into the instance of <see cref="HttpRequest"/>.
        /// </remarks>
        /// <param name="facade">
        /// The HTTP request facade to be converted.
        /// </param>
        /// <returns>
        /// The converted HTTP request implementation.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// This exception is thrown if provided instance of <see cref="IHttpRequestFacade"/> 
        /// is <c>null</c>.
        /// </exception>
        /// <exception cref="InvalidCastException">
        /// This exception is thrown if provided instance of <see cref="IHttpRequestFacade"/> 
        /// is not of type <see cref="HttpRequestFacade"/>, the default interface implementation.
        /// </exception>
        public static HttpRequest ToInstance(this IHttpRequestFacade facade)
        {
            if (facade == null)
            {
                throw new ArgumentNullException(nameof(facade));
            }

            if (facade is HttpRequestFacade)
            {
                return (facade as HttpRequestFacade).Instance;
            }

            throw new InvalidCastException();
        }

        /// <summary>
        /// Converts an instance of interface <see cref="IHttpResponseFacade"/> 
        /// into its instance of class <see cref="HttpResponse"/>.
        /// </summary>
        /// <remarks>
        /// This method tries to convert provided instance of <see cref="IHttpResponseFacade"/> 
        /// into the instance of <see cref="HttpResponse"/>.
        /// </remarks>
        /// <param name="facade">
        /// The HTTP response facade to be converted.
        /// </param>
        /// <returns>
        /// The converted HTTP response implementation.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// This exception is thrown if provided instance of <see cref="IHttpResponseFacade"/> 
        /// is <c>null</c>.
        /// </exception>
        /// <exception cref="InvalidCastException">
        /// This exception is thrown if provided instance of <see cref="IHttpResponseFacade"/> 
        /// is not of type <see cref="HttpResponseFacade"/>, the default interface implementation.
        /// </exception>
        public static HttpResponse ToInstance(this IHttpResponseFacade facade)
        {
            if (facade == null)
            {
                throw new ArgumentNullException(nameof(facade));
            }

            if (facade is HttpResponseFacade)
            {
                return (facade as HttpResponseFacade).Instance;
            }

            throw new InvalidCastException();
        }
    }
}
