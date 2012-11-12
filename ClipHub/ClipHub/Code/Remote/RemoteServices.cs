using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ClipHub.Code.Remote
{
    class RemoteServices 
    {
        public Boolean authenticateDevice(String username, String password, String computerName)
        {
            //call webapi

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:51304/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            
            AuthenticateDeviceRequest authRequest = new AuthenticateDeviceRequest();
            authRequest.username = username;
            authRequest.password = password;
            authRequest.deviceName = computerName;

            // List all products.
            HttpResponseMessage response = client.PostAsJsonAsync("api/RemoteApi", authRequest).Result; //client.PostAsync("api/RemoteApi").Result;  // Blocking call!
            
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var authResponse = response.Content.ReadAsAsync<AuthenticateDeviceResponse>().Result;
                
                //am I ok?

                if (authResponse.success == true)
                {
                    Properties.Settings.Default.authKey = authResponse.authenticationKey;
                    Properties.Settings.Default.authUsername = authRequest.username;
                    Properties.Settings.Default.Save();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }

        }
    }

    public class AuthenticateDeviceResponse
    {
        public string authenticationKey { get; set; }
        public Boolean success { get; set; }
        public DateTime dateClipped { get; set; }
    }

    public class AuthenticateDeviceRequest
    {
        public string username { get; set; }
        public string password { get; set; }
        public string deviceName { get; set; }

    }
}
