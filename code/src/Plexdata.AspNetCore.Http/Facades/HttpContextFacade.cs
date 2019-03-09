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
using Plexdata.AspNetCore.Http.Abstraction;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;

namespace Plexdata.AspNetCore.Http.Facades
{
    /// <summary>
    /// The internal class of the HTTP context facade.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class represents nothing else but the wrapper of <see cref="HttpContext"/>.
    /// </para>
    /// <para>
    /// This class has two significant differences compared to class <see cref="HttpRequest"/>. 
    /// These differences are:
    /// </para>
    /// <list type="number">
    /// <item><description>
    /// The property <see cref="HttpContext.Authentication"/> is not included in this class because 
    /// it has been marked as deprecated in class <see cref="HttpContext"/>.
    /// </description></item>
    /// <item><description>
    /// The property <see cref="HttpContext.User"/> is of type <see cref="IPrincipal"/> instead of type 
    /// <see cref="System.Security.Claims.ClaimsPrincipal"/>. But if it is going to be set it 
    /// must be of that type.
    /// </description></item>
    /// </list>  
    /// </remarks>
    internal class HttpContextFacade : IHttpContextFacade
    {
        /// <summary>
        /// Gets the internal instance of <see cref="HttpContext"/>.
        /// </summary>
        /// <remarks>
        /// The property returns an instance of <see cref="HttpContext"/>.
        /// </remarks>
        /// <value>
        /// The assigned instance of <see cref="HttpContext"/>.
        /// </value>
        internal HttpContext Instance { get; private set; }

        /// <summary>
        /// The internal class constructor is taking an instance of <see cref="HttpContext"/>.
        /// </summary>
        /// <remarks>
        /// The internal class constructor that is used by the <see cref="IHttpContextCreator"/>.
        /// </remarks>
        /// <param name="context">
        /// An instance of <see cref="HttpContext"/> to be assigned.
        /// </param>
        internal HttpContextFacade(HttpContext context)
        {
            this.Initialize(context);
        }

        /// <summary>
        /// The public class constructor taking an instance of <see cref="IHttpContextAccessor"/>.
        /// </summary>
        /// <remarks>
        /// This constructor is used by dependency injection.
        /// </remarks>
        /// <param name="accessor">
        /// An instance of <see cref="IHttpContextAccessor"/>  used to get current instance of 
        /// <see cref="HttpContext"/> from.
        /// </param>
        public HttpContextFacade(IHttpContextAccessor accessor)
        {
            if (accessor == null)
            {
                throw new ArgumentNullException(nameof(accessor));
            }

            this.Initialize(accessor.HttpContext);
        }

        /// <inheritdoc />
        public IFeatureCollection Features
        {
            get
            {
                return this.Instance.Features;
            }
        }

        /// <inheritdoc />
        public IHttpRequestFacade Request { get; private set; }

        /// <inheritdoc />
        public IHttpResponseFacade Response { get; private set; }

        /// <inheritdoc />
        public ConnectionInfo Connection
        {
            get
            {
                return this.Instance.Connection;
            }
        }

        /// <inheritdoc />
        public WebSocketManager WebSockets
        {
            get
            {
                return this.Instance.WebSockets;
            }
        }

        /// <inheritdoc />
        public IPrincipal User
        {
            get
            {
                return this.Instance.User;
            }
            set
            {
                if (value is ClaimsPrincipal)
                {
                    this.Instance.User = value as ClaimsPrincipal;
                }
                else
                {
                    throw new InvalidCastException();
                }
            }
        }

        /// <inheritdoc />
        public IDictionary<Object, Object> Items
        {
            get
            {
                return this.Instance.Items;
            }
            set
            {
                this.Instance.Items = value;
            }
        }

        /// <inheritdoc />
        public IServiceProvider RequestServices
        {
            get
            {
                return this.Instance.RequestServices;
            }
            set
            {
                this.Instance.RequestServices = value;
            }
        }

        /// <inheritdoc />
        public CancellationToken RequestAborted
        {
            get
            {
                return this.Instance.RequestAborted;
            }
            set
            {
                this.Instance.RequestAborted = value;
            }
        }

        /// <inheritdoc />
        public String TraceIdentifier
        {
            get
            {
                return this.Instance.TraceIdentifier;
            }
            set
            {
                this.Instance.TraceIdentifier = value;
            }
        }

        /// <inheritdoc />
        public ISession Session
        {
            get
            {
                return this.Instance.Session;
            }
            set
            {
                this.Instance.Session = value;
            }
        }

        /// <inheritdoc />
        public void Abort()
        {
            this.Instance.Abort();
        }

        /// <summary>
        /// Initializes all properties of this instance.
        /// </summary>
        /// <remarks>
        /// This method is called by the constructors and has to initialize all 
        /// properties accordingly.
        /// </remarks>
        /// <param name="context">
        /// An instance of <see cref="HttpContext"/>.
        /// </param>
        private void Initialize(HttpContext context)
        {
            this.Instance = context ?? throw new ArgumentNullException(nameof(context));
            this.Request = new HttpRequestFacade(context.Request, this);
            this.Response = new HttpResponseFacade(context.Response, this);
        }
    }
}
