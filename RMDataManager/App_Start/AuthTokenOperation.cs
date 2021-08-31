using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace RMDataManager.App_Start
{
    public class AuthTokenOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            // refer to https://stackoverflow.com/questions/51117655/how-to-use-swagger-in-asp-net-webapi-2-0-with-token-based-authentication
            swaggerDoc.paths.Add("/token", new PathItem // add a path /token into swagger
            {
                // below added a Auth category with a post command into swagger
                // the type of data shoulc come through as "application/x-www-form-urlencoded"
                // the definitions of three parameters are given below in a list of parameters
                // the three parameters are "grant_type", "username" and "password"
                // A default value of "grant_type" is given to be "password".
                post = new Operation // add post command
                {
                    tags = new List<string> { "Auth" }, // identifies Auth category
                    consumes = new List<string>
                    {
                        "application/x-www-form-urlencoded" // type of the body for sending this command
                    },
                    parameters = new List<Parameter>
                    {
                        new Parameter
                        {
                            type = "string",
                            name = "grant_type",
                            required = true,
                            @in = "formData",
                            @default = "password"
                        },
                        new Parameter
                        {
                            type = "string",
                            name = "username",
                            required = false,
                            @in = "formData"
                        },
                        new Parameter
                        {
                            type = "string",
                            name = "password",
                            required = false,
                            @in = "formData"
                        }
                    }
                }
            }); 
        }
    }
}