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

namespace Plexdata.AspNetCore.Http.Abstraction
{
    /// <summary>
    /// The interface of the HTTP context creator.
    /// </summary>
    /// <remarks>
    /// This interface is indeed a factory. But the naming extension <i>factory</i> would 
    /// be in conflict with the interface name <see cref="IHttpContextFactory"/>. Therefore, 
    /// this interface uses the naming extension <i>creator</i>.
    /// </remarks>
    public interface IHttpContextCreator
    {
        /// <summary>
        /// Creates an instance of type <see cref="IHttpContextFacade"/> by taking current 
        /// <see cref="HttpContext"/>.
        /// </summary>
        /// <remarks>
        /// This method creates an instance of <see cref="IHttpContextFacade"/>. The internal instance of 
        /// <see cref="HttpContext"/> is taken from injected instance of <see cref="IHttpContextAccessor"/>.
        /// </remarks>
        /// <returns>
        /// An instance of type <see cref="IHttpContextFacade"/>.
        /// </returns>
        IHttpContextFacade Create();

        /// <summary>
        /// Creates an instance of type <see cref="IHttpContextFacade"/> using provided instance of 
        /// <see cref="HttpContext"/>.
        /// </summary>
        /// <remarks>
        /// This method creates an instance of type <see cref="IHttpContextFacade"/> by using provided 
        /// instance of <see cref="HttpContext"/>.
        /// </remarks>
        /// <param name="context">
        /// The instance of type <see cref="HttpContext"/> to be wrapped.
        /// </param>
        /// <returns>
        /// An instance of type <see cref="IHttpContextFacade"/>.
        /// </returns>
        IHttpContextFacade Create(HttpContext context);
    }
}
