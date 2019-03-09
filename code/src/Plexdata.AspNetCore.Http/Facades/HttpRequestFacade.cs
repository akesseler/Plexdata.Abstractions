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
using System.Threading;
using System.Threading.Tasks;

namespace Plexdata.AspNetCore.Http.Facades
{
    /// <summary>
    /// The internal class of the HTTP request facade.
    /// </summary>
    /// <remarks>
    /// This internal class represents nothing else but the wrapper of <see cref="HttpRequest"/>.
    /// </remarks>
    internal class HttpRequestFacade : IHttpRequestFacade
    {
        /// <summary>
        /// Gets the internal instance of <see cref="HttpRequest"/>.
        /// </summary>
        /// <remarks>
        /// The property returns an instance of <see cref="HttpRequest"/>.
        /// </remarks>
        /// <value>
        /// The assigned instance of <see cref="HttpRequest"/>.
        /// </value>
        internal HttpRequest Instance { get; private set; }

        /// <summary>
        /// The internal class constructor is taking an instance of <see cref="HttpRequest"/> 
        /// as well as an instance of <see cref="IHttpContextFacade"/>.
        /// </summary>
        /// <remarks>
        /// The internal class constructor that is used by the implementation of interface 
        /// <see cref="IHttpContextFacade"/>.
        /// </remarks>
        /// <param name="request">
        /// An instance of <see cref="HttpRequest"/> to be assigned.
        /// </param>
        /// <param name="context">
        /// An instance of <see cref="IHttpContextFacade"/> to be assigned.
        /// </param>
        internal HttpRequestFacade(HttpRequest request, IHttpContextFacade context)
        {
            this.Instance = request ?? throw new ArgumentNullException(nameof(request));
            this.HttpContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc />
        public QueryString QueryString
        {
            get
            {
                return this.Instance.QueryString;
            }
            set
            {
                this.Instance.QueryString = value;
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
        public IRequestCookieCollection Cookies
        {
            get
            {
                return this.Instance.Cookies;
            }
            set
            {
                this.Instance.Cookies = value;
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
        public String Protocol
        {
            get
            {
                return this.Instance.Protocol;
            }
            set
            {
                this.Instance.Protocol = value;
            }
        }

        /// <inheritdoc />
        public IQueryCollection Query
        {
            get
            {
                return this.Instance.Query;
            }
            set
            {
                this.Instance.Query = value;
            }
        }

        /// <inheritdoc />
        public IFormCollection Form
        {
            get
            {
                return this.Instance.Form;
            }
            set
            {
                this.Instance.Form = value;
            }
        }

        /// <inheritdoc />
        public PathString Path
        {
            get
            {
                return this.Instance.Path;
            }
            set
            {
                this.Instance.Path = value;
            }
        }

        /// <inheritdoc />
        public PathString PathBase
        {
            get
            {
                return this.Instance.PathBase;
            }
            set
            {
                this.Instance.PathBase = value;
            }
        }

        /// <inheritdoc />
        public HostString Host
        {
            get
            {
                return this.Instance.Host;
            }
            set
            {
                this.Instance.Host = value;
            }
        }

        /// <inheritdoc />
        public Boolean IsHttps
        {
            get
            {
                return this.Instance.IsHttps;
            }
            set
            {
                this.Instance.IsHttps = value;
            }
        }

        /// <inheritdoc />
        public String Scheme
        {
            get
            {
                return this.Instance.Scheme;
            }
            set
            {
                this.Instance.Scheme = value;
            }
        }

        /// <inheritdoc />
        public String Method
        {
            get
            {
                return this.Instance.Method;
            }
            set
            {
                this.Instance.Method = value;
            }
        }

        /// <inheritdoc />
        public IHttpContextFacade HttpContext { get; private set; }

        /// <inheritdoc />
        public Boolean HasFormContentType
        {
            get
            {
                return this.Instance.HasFormContentType;
            }
        }

        /// <inheritdoc />
        public Task<IFormCollection> ReadFormAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.Instance.ReadFormAsync(cancellationToken);
        }
    }
}
