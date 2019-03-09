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
using System.Threading.Tasks;

namespace Plexdata.AspNetCore.Http.Abstraction
{
    /// <summary>
    /// The interface of the HTTP response facade.
    /// </summary>
    /// <remarks>
    /// This interface represents nothing else but the wrapper of <see cref="HttpResponse"/>.
    /// </remarks>
    public interface IHttpResponseFacade
    {
        /// <summary>
        /// Gets the <see cref="IHttpContextFacade"/> for this response.
        /// </summary>
        /// <remarks>
        /// The property returns an instance of <see cref="IHttpContextFacade"/> for this response.
        /// </remarks>
        /// <value>
        /// An instance of <see cref="IHttpContextFacade"/>.
        /// </value>
        IHttpContextFacade HttpContext { get; }

        /// <summary>
        /// Gets or sets the HTTP response code.
        /// </summary>
        /// <remarks>
        /// The property returns or changes the HTTP response code.
        /// </remarks>
        /// <value>
        /// An integer representing the status of the HTTP output 
        /// returned to the client.
        /// </value>
        Int32 StatusCode { get; set; }

        /// <summary>
        /// Gets the response headers.
        /// </summary>
        /// <remarks>
        /// The property returns the response headers.
        /// </remarks>
        /// <value>
        /// The response headers.
        /// </value>
        IHeaderDictionary Headers { get; }

        /// <summary>
        /// Gets or sets the response body stream.
        /// </summary>
        /// <remarks>
        /// The property returns or changes the response body stream.
        /// </remarks>
        /// <value>
        /// The response body stream.
        /// </value>
        Stream Body { get; set; }

        /// <summary>
        /// Gets or sets the value for the content-length response header.
        /// </summary>
        /// <remarks>
        /// The property returns or changes the value for the content-length response header.
        /// </remarks>
        /// <value>
        /// The content-length response header.
        /// </value>
        Int64? ContentLength { get; set; }

        /// <summary>
        /// Gets or sets the value for the content-type response header.
        /// </summary>
        /// <remarks>
        /// The property returns or changes the value for the content-type response header.
        /// </remarks>
        /// <value>
        /// The content-type response header.
        /// </value>
        String ContentType { get; set; }

        /// <summary>
        /// Gets an object that can be used to manage cookies for this response. 
        /// </summary>
        /// <remarks>
        /// The property returns an object that can be used to manage cookies for this response. 
        /// </remarks>
        /// <value>
        /// The cookies for this response. 
        /// </value>
        IResponseCookies Cookies { get; }

        /// <summary>
        /// Gets a value indicating whether response headers have been sent to the client.
        /// </summary>
        /// <remarks>
        /// The property returns a value indicating whether response headers have been sent to the client.
        /// </remarks>
        /// <value>
        /// A value indicating whether response headers have been sent to the client.
        /// </value>
        Boolean HasStarted { get; }

        /// <summary>
        /// Adds a delegate to be invoked after the response has finished being sent to the client. 
        /// </summary>
        /// <remarks>
        /// This method adds a delegate to be invoked after the response has finished being sent to the client. 
        /// </remarks>
        /// <param name="callback">
        /// The delegate to invoke.
        /// </param>
        /// <param name="state">
        /// A state object to capture and pass back to the delegate.
        /// </param>
        void OnCompleted(Func<Object, Task> callback, Object state);

        /// <summary>
        /// Adds a delegate to be invoked after the response has finished being sent to the client. 
        /// </summary>
        /// <remarks>
        /// This method adds a delegate to be invoked after the response has finished being sent to the client.
        /// </remarks>
        /// <param name="callback">
        /// The delegate to invoke.
        /// </param>
        void OnCompleted(Func<Task> callback);

        /// <summary>
        /// Adds a delegate to be invoked just before response headers will be sent to the client. 
        /// </summary>
        /// <remarks>
        /// This method adds a delegate to be invoked just before response headers will be sent to the client.
        /// </remarks>
        /// <param name="callback">
        /// The delegate to execute.
        /// </param>
        /// <param name="state">
        /// A state object to capture and pass back to the delegate.
        /// </param>
        void OnStarting(Func<Object, Task> callback, Object state);

        /// <summary>
        /// Adds a delegate to be invoked just before response headers will be sent to the client.
        /// </summary>
        /// <remarks>
        /// This method adds a delegate to be invoked just before response headers will be sent to the client.
        /// </remarks>
        /// <param name="callback">
        /// The delegate to execute.
        /// </param>
        void OnStarting(Func<Task> callback);

        /// <summary>
        /// Returns a temporary redirect response (HTTP 302) to the client. 
        /// </summary>
        /// <remarks>
        /// This method returns a temporary redirect response (HTTP 302) to the client.
        /// </remarks>
        /// <param name="location">
        /// The URL to redirect the client to. This must be properly encoded for use in HTTP 
        /// headers where only ASCII characters are allowed.
        /// </param>
        void Redirect(String location);

        /// <summary>
        /// Returns a redirect response (HTTP 301 or HTTP 302) to the client. 
        /// </summary>
        /// <remarks>
        /// This method returns a redirect response (HTTP 301 or HTTP 302) to the client.
        /// </remarks>
        /// <param name="location">
        /// The URL to redirect the client to. This must be properly encoded for use in HTTP 
        /// headers where only ASCII characters are allowed.
        /// </param>
        /// <param name="permanent">
        /// True if the redirect is permanent (301), otherwise false (302).
        /// </param>
        void Redirect(String location, Boolean permanent);

        /// <summary>
        /// Registers an object for disposal by the host once the request has finished processing. 
        /// </summary>
        /// <remarks>
        /// This method registers an object for disposal by the host once the request has finished 
        /// processing.
        /// </remarks>
        /// <param name="disposable">
        /// The object to be disposed.
        /// </param>
        void RegisterForDispose(IDisposable disposable);
    }
}
