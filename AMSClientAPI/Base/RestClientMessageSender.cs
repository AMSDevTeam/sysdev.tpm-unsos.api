using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

/**
 * Centralize synchronizer request sender.
 * Dynamically Accept Object Storage Classes
 * @return boolean
 * 
 */
namespace AMSClientAPI.Base
{
    public struct resData
    {
        public object reponseData { get; set; }

    }

    public class RestClientMessageSender
    {

        private RestClient client;
        private RestRequest request;

        public RestSharp.Method httpMethod(IDictionary<string, object> param)
        {

            RestSharp.Method method = 0;

            switch (param["HTTPMethod"].ToString())
            {
                case "POST":

                    method = Method.POST;
                    break;

                case "PUT":
                    method = Method.PUT;
                    break;

            }

            return method;

        }

        /// <summary>
        /// Send Request to API endpoint
        /// </summary>
        /// <typeparam name="serviceClass">Dynamic class service</typeparam>
        /// <param name="storage">Contains all the parameters needed in sending the request</param>
        /// <returns></returns>
        ///
        public object sendRequest<serviceClass>(GenericStorage storage) where serviceClass : class, new()
        {
            IDictionary<string, object> v = new Dictionary<string, object>();

            object response = null;    
            
            try
            {

                foreach (var prop in storage.GetType().GetProperties())
                {
                    
                    if (prop.GetValue(storage, null) != null)

                        v[prop.Name] = prop.GetValue(storage, null);

                }
                if (v.Count > 0)
                {

                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                    client = new RestClient(storage.APIEndpoint);

                    client.Authenticator   = new HttpBasicAuthenticator(Constant.api_username, Constant.api_password);                 
                    client.CookieContainer = new System.Net.CookieContainer();
                    

                    request = new RestRequest(v["WebURL"].ToString(), httpMethod(v));                
              

                    switch (request.Method.ToString())
                    {
                        case Constant.POST:

                           
                            request.RequestFormat = DataFormat.Json;
                            request.AddParameter("Application/Json", JsonConvert.SerializeObject(v["List"]), ParameterType.RequestBody);

                            response =  client.Execute(request);
                            Thread.Sleep(5000);
                            break;

                    }

                }

            }
            catch (Exception) { return response; }

            return response;

        }

    }

}
