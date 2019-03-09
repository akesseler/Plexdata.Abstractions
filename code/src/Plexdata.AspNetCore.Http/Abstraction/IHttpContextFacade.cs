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
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;

namespace Plexdata.AspNetCore.Http.Abstraction
{
    /// <summary>
    /// The interface of the HTTP context facade.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This interface represents nothing else but the wrapper of <see cref="HttpContext"/>.
    /// </para>
    /// <para>
    /// This interface has two significant differences compared to class <see cref="HttpRequest"/>. 
    /// These differences are:
    /// </para>
    /// <list type="number">
    /// <item><description>
    /// The property <see cref="HttpContext.Authentication"/> is not included in this interface because 
    /// it has been marked as deprecated in class <see cref="HttpContext"/>.
    /// </description></item>
    /// <item><description>
    /// The property <see cref="HttpContext.User"/> is of type <see cref="IPrincipal"/> instead of type 
    /// <see cref="System.Security.Claims.ClaimsPrincipal"/>. But if it is going to be set it 
    /// must be of that type.
    /// </description></item>
    /// </list>  
    /// </remarks>
    public interface IHttpContextFacade
    {
        /// <summary>
        /// Gets the collection of HTTP features provided by the server and middleware available 
        /// on this request.
        /// </summary>
        /// <remarks>
        /// This property returns a collection of HTTP features provided by the server and middleware 
        /// available on this request.
        /// </remarks>
        /// <value>
        /// An instance of <see cref="IFeatureCollection"/>.
        /// </value>
        IFeatureCollection Features { get; }

        /// <summary>
        /// Gets the <see cref="IHttpRequestFacade"/> object for this request.
        /// </summary>
        /// <remarks>
        /// This property returns the facade for the <see cref="HttpRequest"/> for this request.
        /// </remarks>
        /// <value>
        /// An instance of <see cref="IHttpRequestFacade"/>.
        /// </value>
        IHttpRequestFacade Request { get; }

        /// <summary>
        /// Gets the <see cref="IHttpResponseFacade"/> object for this request.
        /// </summary>
        /// <remarks>
        /// This property returns the facade for the <see cref="HttpResponse"/> for this request.
        /// </remarks>
        /// <value>
        /// An instance of <see cref="IHttpResponseFacade"/>.
        /// </value>
        IHttpResponseFacade Response { get; }

        /// <summary>
        /// Gets information about the underlying connection for this request. 
        /// </summary>
        /// <remarks>
        /// This property returns information about the underlying connection for this request.
        /// </remarks>
        /// <value>
        /// An instance of <see cref="ConnectionInfo"/>.
        /// </value>
        ConnectionInfo Connection { get; }

        /// <summary>
        /// Gets an object that manages the establishment of Web-Socket connections for this request.
        /// </summary>
        /// <remarks>
        /// This property returns an object that manages the establishment of Web-Socket connections 
        /// for this request.
        /// </remarks>
        /// <value>
        /// An instance of <see cref="WebSocketManager"/>.
        /// </value>
        WebSocketManager WebSockets { get; }

        /// <summary>
        /// Gets or sets the user for this request.
        /// </summary>
        /// <remarks>
        /// The underlying instance of <see cref="HttpContext"/> uses an instance of <see cref="System.Security.Claims.ClaimsPrincipal"/>. 
        /// Therefore, ensure the instance of <see cref="IPrincipal"/> to be set is of type <see cref="System.Security.Claims.ClaimsPrincipal"/>. 
        /// Otherwise and exception of type <see cref="InvalidCastException"/> is thrown.
        /// </remarks>
        /// <value>
        /// An instance of <see cref="IPrincipal"/>.
        /// </value>
        /// <exception cref="InvalidCastException">
        /// This exception is thrown if instance of <see cref="IPrincipal"/> is not of type <see cref="System.Security.Claims.ClaimsPrincipal"/>.
        /// </exception>
        IPrincipal User { get; set; }

        /// <summary>
        /// Gets or sets a key/value collection that can be used to share data within the scope of 
        /// this request.
        /// </summary>
        /// <remarks>
        /// This property returns or changes a key/value collection that can be used to share data 
        /// within the scope of this request.
        /// </remarks>
        /// <value>
        /// An instance of <see cref="IDictionary{Object, Object}"/>.
        /// </value>
        IDictionary<Object, Object> Items { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IServiceProvider"/> that provides access to the request's 
        /// service container.
        /// </summary>
        /// <remarks>
        /// This property returns or changes the <see cref="IServiceProvider"/> that provides access 
        /// to the request's service container.
        /// </remarks>
        /// <value>
        /// An instance of <see cref="IServiceProvider"/>.
        /// </value>
        IServiceProvider RequestServices { get; set; }

        /// <summary>
        /// Notifies when the connection underlying this request is aborted and thus request operations 
        /// should be cancelled.
        /// </summary>
        /// <remarks>
        /// This property notifies when the connection underlying this request is aborted and thus request 
        /// operations should be cancelled.
        /// </remarks>
        /// <value>
        /// An instance of <see cref="CancellationToken"/>.
        /// </value>
        CancellationToken RequestAborted { get; set; }

        /// <summary>
        /// Gets or sets a unique identifier to represent this request in trace logs.
        /// </summary>
        /// <remarks>
        /// This property returns or changes a unique identifier to represent this request in trace logs.
        /// </remarks>
        /// <value>
        /// A string representing the unique identifier.
        /// </value>
        String TraceIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the object used to manage user session data for this request.
        /// </summary>
        /// <remarks>
        /// This property returns or changes the object used to manage user session data for this request.
        /// </remarks>
        /// <value>
        /// An instance of <see cref="ISession"/>.
        /// </value>
        ISession Session { get; set; }

        /// <summary>
        /// Aborts the connection underlying this request.
        /// </summary>
        /// <remarks>
        /// This method aborts the connection underlying this request.
        /// </remarks>
        void Abort();
    }
}
