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
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Plexdata.AspNetCore.Http.Abstraction
{
    /// <summary>
    /// The interface of the HTTP request facade.
    /// </summary>
    /// <remarks>
    /// This interface represents nothing else but the wrapper of <see cref="HttpRequest"/>.
    /// </remarks>
    public interface IHttpRequestFacade
    {
        /// <summary>
        /// Gets or sets the raw query string used to create the query collection.
        /// </summary>
        /// <remarks>
        /// The property returns or changes the raw query string used to create the query collection.
        /// </remarks>
        /// <value>
        /// The raw query string.
        /// </value>
        QueryString QueryString { get; set; }

        /// <summary>
        /// Gets or sets the request body stream.
        /// </summary>
        /// <remarks>
        /// The property returns or changes the request body stream.
        /// </remarks>
        /// <value>
        /// The request body stream.
        /// </value>
        Stream Body { get; set; }

        /// <summary>
        /// Gets or sets the content-type header. 
        /// </summary>
        /// <remarks>
        /// The property returns or changes the content-type header. 
        /// </remarks>
        /// <value>
        /// The content-type header.
        /// </value>
        String ContentType { get; set; }

        /// <summary>
        /// Gets or sets the content-length header.
        /// </summary>
        /// <remarks>
        /// The property returns or changes the content-length header.
        /// </remarks>
        /// <value>
        /// The value of the content-length header, if any.
        /// </value>
        Int64? ContentLength { get; set; }

        /// <summary>
        /// Gets or sets the collection of cookies for this request.
        /// </summary>
        /// <remarks>
        /// The property returns or changes the collection of cookies for this request.
        /// </remarks>
        /// <value>
        /// The collection of cookies for this request.
        /// </value>
        IRequestCookieCollection Cookies { get; set; }

        /// <summary>
        /// Gets the request headers. 
        /// </summary>
        /// <remarks>
        /// The property returns the request headers. 
        /// </remarks>
        /// <value>
        /// The request headers.
        /// </value>
        IHeaderDictionary Headers { get; }

        /// <summary>
        /// Gets or sets the request protocol.
        /// </summary>
        /// <remarks>
        /// The property returns or changes the request protocol.
        /// </remarks>
        /// <value>
        /// The request protocol.
        /// </value>
        String Protocol { get; set; }

        /// <summary>
        /// Gets or sets the query value collection parsed from request query string.
        /// </summary>
        /// <remarks>
        /// The property returns or changes the query value collection parsed from request query string.
        /// </remarks>
        /// <value>
        /// The query value collection parsed from request query string.
        /// </value>
        IQueryCollection Query { get; set; }

        /// <summary>
        /// Gets or sets the request body as a form.
        /// </summary>
        /// <remarks>
        /// The property returns or changes the request body as a form.
        /// </remarks>
        /// <value>
        /// The request body as a form.
        /// </value>
        IFormCollection Form { get; set; }

        /// <summary>
        /// Gets or sets the request path from request path. 
        /// </summary>
        /// <remarks>
        /// The property returns or changes the request path from request path. 
        /// </remarks>
        /// <value>
        /// The request path from request path.
        /// </value>
        PathString Path { get; set; }

        /// <summary>
        /// Gets or sets the request path base.
        /// </summary>
        /// <remarks>
        /// The property returns or changes the request path base.
        /// </remarks>
        /// <value>
        /// The request path base.
        /// </value>
        PathString PathBase { get; set; }

        /// <summary>
        /// Gets or sets the host header. It may include the port as well.
        /// </summary>
        /// <remarks>
        /// The property returns or changes the host header.
        /// </remarks>
        /// <value>
        /// The host header.
        /// </value>
        HostString Host { get; set; }

        /// <summary>
        /// Returns true if the request scheme is HTTPS.
        /// </summary>
        /// <remarks>
        /// The property returns or changes the request scheme to HTTPS.
        /// </remarks>
        /// <value>
        /// True if this request is using HTTPS and false otherwise.
        /// </value>
        Boolean IsHttps { get; set; }

        /// <summary>
        /// Gets or sets the HTTP request scheme.
        /// </summary>
        /// <remarks>
        /// The property returns or changes the HTTP request scheme.
        /// </remarks>
        /// <value>
        /// The HTTP request scheme.
        /// </value>
        String Scheme { get; set; }

        /// <summary>
        /// Gets or sets the HTTP method. 
        /// </summary>
        /// <remarks>
        /// The property returns or changes the HTTP method.
        /// </remarks>
        /// <value>
        /// The HTTP method.
        /// </value>
        String Method { get; set; }

        /// <summary>
        /// Gets the <see cref="IHttpContextFacade"/> for this request.
        /// </summary>
        /// <remarks>
        /// The property returns an instance of <see cref="IHttpContextFacade"/> for this request.
        /// </remarks>
        /// <value>
        /// An instance of <see cref="IHttpContextFacade"/>.
        /// </value>
        IHttpContextFacade HttpContext { get; }

        /// <summary>
        /// Checks the content-type header for form types.
        /// </summary>
        /// <remarks>
        /// The property returns the content-type header for form types.
        /// </remarks>
        /// <value>
        /// True if the content-type header represents a form content type and otherwise false.
        /// </value>
        Boolean HasFormContentType { get; }

        /// <summary>
        /// Reads the request body if it is a form.
        /// </summary>
        /// <remarks>
        /// This method reads the request body if it is a form.
        /// </remarks>
        /// <param name="cancellationToken">
        /// An instance of <see cref="CancellationToken"/>.
        /// </param>
        /// <returns>
        /// The request body as a form.
        /// </returns>
        Task<IFormCollection> ReadFormAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
