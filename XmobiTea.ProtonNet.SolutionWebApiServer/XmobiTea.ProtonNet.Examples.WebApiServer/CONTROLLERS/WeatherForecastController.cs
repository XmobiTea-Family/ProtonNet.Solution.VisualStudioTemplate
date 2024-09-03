using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using $safeprojectname$.Models;
using XmobiTea.ProtonNet.Server.WebApi.Controllers;
using XmobiTea.ProtonNet.Server.WebApi.Controllers.Attribute;
using XmobiTea.ProtonNet.Server.WebApi.Models;
using XmobiTea.ProtonNetCommon;
using XmobiTea.ProtonNetCommon.Extensions;
using XmobiTea.ProtonNetCommon.Types;

namespace $safeprojectname$.Controllers
{
    /// <summary>
    /// Demo for weather forecast controller, webapi 
    /// Handles requests routed to "/weather"
    /// </summary>
    [Route("/weather")]
    class WeatherForecastController : WebApiController
    {
        /// <summary>
        /// A predefined list of weather conditions used to generate weather summaries.
        /// </summary>
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        /// <summary>
        /// Retrieves a list of weather forecasts.
        /// Route: GET /getWeatherForecast
        /// </summary>
        /// <returns>Returns a JSON response containing the weather forecasts.</returns>
        [HttpGet("getAllWeatherForecast")]
        private HttpResponse GetAllWeatherForecast()
        {
            var responseData = Enumerable.Range(1, 5).Select(index => new WeatherForecast()
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = this.Random(-20, 55),
                Summary = Summaries[this.Random(0, Summaries.Length)]
            });

            return this.Response().MakeGetResponse(this.JsonSerialize(responseData), "application/json");
        }

        /// <summary>
        /// Retrieves a list of weather forecasts, optionally filtered by a specified summary.
        /// Route: GET /getWeatherForecast?sumary={summary}
        /// </summary>
        /// <param name="sumary">An optional weather summary to filter the results.</param>
        /// <returns>Returns a JSON response containing the weather forecasts.</returns>
        [HttpGet("getWeatherForecast")]
        private HttpResponse GetWeatherForecast([FromQuery("sumary")] string sumary)
        {
            if (string.IsNullOrEmpty(sumary))
            {
                var responseData = Enumerable.Range(1, 5).Select(index => new WeatherForecast()
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = this.Random(-20, 55),
                    Summary = Summaries[this.Random(0, Summaries.Length)]
                });

                return this.Response().MakeGetResponse(this.JsonSerialize(responseData), "application/json");
            }
            else
            {
                if (!Summaries.Contains(sumary))
                {
                    return this.Response().MakeErrorResponse(StatusCode.NotFound, "Cannot find the specified summary. " + sumary);
                }
                else
                {
                    var responseData = new List<WeatherForecast>()
                    {
                        new WeatherForecast()
                        {
                            Date = DateTime.Now.AddDays(0),
                            TemperatureC = this.Random(-20, 55),
                            Summary = sumary
                        }
                    };

                    return this.Response().MakeGetResponse(this.JsonSerialize(responseData), "application/json");
                }
            }
        }

        /// <summary>
        /// Retrieves a weather forecast for a specific summary passed as a parameter.
        /// Route: GET /getWeatherForecast/{sumary}
        /// </summary>
        /// <param name="sumary">The weather summary to retrieve the forecast for.</param>
        /// <returns>Returns a JSON response containing the weather forecast for the specified summary.</returns>
        [HttpGet("getWeatherForecast/{sumary}")]
        private HttpResponse GetWeatherForecastByParam([FromParam("sumary")] string sumary)
        {
            if (string.IsNullOrEmpty(sumary) || !Summaries.Contains(sumary))
            {
                return this.Response().MakeErrorResponse(StatusCode.NotFound, "Cannot find the specified summary.");
            }
            else
            {
                var responseData = new List<WeatherForecast>()
            {
                new WeatherForecast()
                {
                    Date = DateTime.Now,
                    TemperatureC = this.Random(-20, 55),
                    Summary = sumary
                }
            };

                return this.Response().MakeGetResponse(this.JsonSerialize(responseData), "application/json");
            }
        }

        /// <summary>
        /// Middleware example for setting a temperature value in the middleware context.
        /// </summary>
        /// <param name="context">The context for the middleware.</param>
        /// <param name="next">The delegate to invoke the next middleware in the pipeline.</param>
        /// <returns>Returns the response after processing through the middleware.</returns>
        [HttpMiddleware("getWeatherForecastMiddleware")]
        private HttpResponse GetWeatherForecastMiddleware(MiddlewareContext context, NextDelegate next)
        {
            context.SetData("TemperatureC", this.Random(20, 30));
            this.logger.Debug("The TemperatureC in middleware is " + context.GetData<int>("TemperatureC"));

            return next.Invoke();
        }

        /// <summary>
        /// Retrieves the weather forecast using the temperature set in the middleware context.
        /// Route: GET /getWeatherForecastMiddleware
        /// </summary>
        /// <param name="temperaturnC">The temperature retrieved from the middleware context.</param>
        /// <returns>Returns a JSON response containing the weather forecast with the middleware temperature.</returns>
        [HttpGet("getWeatherForecastMiddleware")]
        private HttpResponse GetWeatherForecastMiddleware([FromMiddlewareContext("TemperatureC")] int temperaturnC)
        {
            var responseData = Enumerable.Range(1, 1).Select(index => new WeatherForecast()
            {
                Date = DateTime.Now,
                TemperatureC = temperaturnC,
                Summary = Summaries[this.Random(0, Summaries.Length)]
            });

            return this.Response().MakeGetResponse(this.JsonSerialize(responseData), "application/json");
        }

        /// <summary>
        /// Produces a random integer within the defined range of values.
        /// </summary>
        /// <param name="min">min value is int</param>
        /// <param name="max">max value is int</param>
        /// <returns></returns>
        private int Random(int min, int max)
        {
            var rd = new Random();
            return rd.Next(min, max);
        }

        /// <summary>
        /// Converts an object into its JSON string representation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        private string JsonSerialize<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var serialiser = new DataContractJsonSerializer(typeof(T));
                serialiser.WriteObject(ms, obj);
                var json = ms.ToArray();
                return Encoding.UTF8.GetString(json, 0, json.Length);
            }
        }
    }

}
