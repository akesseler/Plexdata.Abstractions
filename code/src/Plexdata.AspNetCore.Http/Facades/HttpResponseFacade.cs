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
using System;
using System.IO;
using System.Threading.Tasks;

namespace Plexdata.AspNetCore.Http.Facades
{
    /// <summary>
    /// The internal class of the HTTP response facade.
    /// </summary>
    /// <remarks>
    /// This internal class represents nothing else but the wrapper of <see cref="HttpResponse"/>.
    /// </remarks>
    internal class HttpResponseFacade : IHttpResponseFacade
    {
        /// <summary>
        /// Gets the internal instance of <see cref="HttpResponse"/>.
        /// </summary>
        /// <remarks>
        /// The property returns an instance of <see cref="HttpResponse"/>.
        /// </remarks>
        /// <value>
        /// The assigned instance of <see cref="HttpResponse"/>.
        /// </value>
        internal HttpResponse Instance { get; private set; }

        /// <summary>
        /// The internal class constructor is taking an instance of <see cref="HttpResponse"/> 
        /// as well as an instance of <see cref="IHttpContextFacade"/>.
        /// </summary>
        /// <remarks>
        /// The internal class constructor that is used by the implementation of interface 
        /// <see cref="IHttpContextFacade"/>.
        /// </remarks>
        /// <param name="response">
        /// An instance of <see cref="HttpResponse"/> to be assigned.
        /// </param>
        /// <param name="context">
        /// An instance of <see cref="IHttpContextFacade"/> to be assigned.
        /// </param>
        internal HttpResponseFacade(HttpResponse response, IHttpContextFacade context)
        {
            this.Instance = response ?? throw new ArgumentNullException(nameof(response));
            this.HttpContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc />
        public IHttpContextFacade HttpContext { get; private set; }

        /// <inheritdoc />
        public Int32 StatusCode
        {
            get
            {
                return this.Instance.StatusCode;
            }
            set
            {
                this.Instance.StatusCode = value;
            }
        }

        /// <inheritdoc />
        public IHeaderDictionary Headers
        {
            get
            {
                return this.Instance.Headers;
            }
        }

        /// <inheritdoc />
        public Stream Body
        {
            get
            {
                return this.Instance.Body;
            }
            set
            {
                this.Instance.Body = value;
            }
        }

        /// <inheritdoc />
        public Int64? ContentLength
        {
            get
            {
                return this.Instance.ContentLength;
            }
            set
            {
                this.Instance.ContentLength = value;
            }
        }

        /// <inheritdoc />
        public String ContentType
        {
            get
            {
                return this.Instance.ContentType;
            }
            set
            {
                this.Instance.ContentType = value;
            }
        }

        /// <inheritdoc />
        public IResponseCookies Cookies
        {
            get
            {
                return this.Instance.Cookies;
            }
        }

        /// <inheritdoc />
        public Boolean HasStarted
        {
            get
            {
                return this.Instance.HasStarted;
            }
        }

        /// <inheritdoc />
        public void OnCompleted(Func<Object, Task> callback, Object state)
        {
            this.Instance.OnCompleted(callback, state);
        }

        /// <inheritdoc />
        public virtual void OnCompleted(Func<Task> callback)
        {
            this.Instance.OnCompleted(callback);
        }

        /// <inheritdoc />
        public void OnStarting(Func<Object, Task> callback, Object state)
        {
            this.Instance.OnStarting(callback, state);
        }

        /// <inheritdoc />
        public virtual void OnStarting(Func<Task> callback)
        {
            this.Instance.OnStarting(callback);
        }

        /// <inheritdoc />
        public virtual void Redirect(String location)
        {
            this.Instance.Redirect(location);
        }

        /// <inheritdoc />
        public void Redirect(String location, Boolean permanent)
        {
            this.Instance.Redirect(location, permanent);
        }

        /// <inheritdoc />
        public virtual void RegisterForDispose(IDisposable disposable)
        {
            this.Instance.RegisterForDispose(disposable);
        }
    }
}
