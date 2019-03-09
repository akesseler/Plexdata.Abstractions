## Plexdata Abstractions

The _Plexdata Abstractions_ project represents a set of libraries that are mainly intended to be used for testing.

But at the moment, this project provides just one library which shall solve the problem that testing of the HTTP context is almost impossible in a .NET Core application. 


### Licensing

The software has been published under the terms of _MIT License_.

### Documentation

An overview documentation is not yet available at the moment. Therefore, please refer to the project's Wiki for a detailed documentation of all classes and their methods.

### Examples

#### HTTP Context Interfacing

For this purpose the library ``Plexdata.AspNetCore.Http`` is used. The first step to do is to register all services required to work with the provided interfaces. In a .NET Core application this is usually done inside method ``ConfigureServices`` of class ``Startup``. See below how to register all services of the ``Plexdata.AspNetCore.Http`` library.

```
using Plexdata.AspNetCore.Http.Extensions;

...

public class Startup
{
  public void ConfigureServices(IServiceCollection services)
  {
    ...

    services.AddPlexdataHttpServices();

    ...
  }
}
```

The next step in using the HTTP context wrapper interfaces is done in the controllers. See below for an example how to turn it into practice.

```
using Plexdata.AspNetCore.Http.Abstraction;

public class ValuesController : ControllerBase
{
  private readonly IHttpContextCreator creator = null;

  public ValuesController(IHttpContextCreator creator)
  {
    this.creator = creator ?? throw new ArgumentNullException(nameof(creator));
  }

  [HttpGet]
  public ActionResult<Values> GetValues()
  {
    // Take HTTP context from IHttpContextAccessor.
    IHttpContextFacade facade = this.creator.Create();

    if (!facade.User.IsInRole("admin"))
    {
      return base.Unauthorized();
    }

    return base.Ok(...);
  }
}
```

The code snippet above shows how to get current HTTP context without having any kind of reference. 

Alternatively, it would also be possible to get an instance of the ``IHttpContextFacade`` interface from the HTTP context instance of the base class. See below for such an example.

```
[HttpGet]
public ActionResult<Values> GetValues()
{
  // Take HTTP context from the instance of the base class.
  IHttpContextFacade facade = this.creator.Create(base.HttpContext);

  if (!facade.User.IsInRole("admin"))
  {
    return base.Unauthorized();
  }

  return base.Ok(...);
}
```

Under some circumstances it might be necessary to turn the ``IHttpContextFacade`` back into the real ``HttpContext``. For this purpose an extension method for ``IHttpContextFacade`` and for ``IHttpRequestFacade`` as well as for ``IHttpResponseFacade`` can be used. See below for en example of how to accomplish this task.

```
using Plexdata.AspNetCore.Http.Abstraction;
using Plexdata.AspNetCore.Http.Extensions;

...

[HttpGet]
public ActionResult<Values> GetValues()
{
  // Take HTTP context from IHttpContextAccessor.
  IHttpContextFacade facade = this.creator.Create();

  ...

  HttpContext  context  = facade.ToInstance();
  HttpRequest  request  = facade.Request.ToInstance();
  HttpResponse response = facade.Response.ToInstance();

  return base.Ok(...);
}
```


