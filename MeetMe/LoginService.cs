using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MeetMe
{
    public class LoginService
    {
        public async Task<Response> Login(string username,string password)
        {
			try
			{
				string url = "https://ssl.meetme.com/mobile/login";
				using WebClientAware webClientAware = new WebClientAware();
				
				webClientAware.Headers.Add("x-device", "android,4d7e52d8-4dab-4c41-acc0-b0a8deb5d112,3825:3825");
				
				webClientAware.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

				var formData = new Dictionary<string, string>()
				{
					{"emailId",username },
                    {"password",password },
					{"fbAccessToken",string.Empty},
					{"deviceVerifications",string.Empty },
					{"lat",string.Empty },
					{"long",string.Empty },
					{"systemInfo",string.Empty },
					{"sessionId", string.Empty.ToRandString(12) },
					{"sessionState" , string.Empty},
					{"rememberMe",string.Empty },
					{"skipResponseKeys", string.Empty }
                };

				Response? response = new Response();
                var content = new FormUrlEncodedContent(formData);
				string contentString = await content.ReadAsStringAsync();

                byte[] byResp = await webClientAware.UploadDataTaskAsync(new Uri(url),"POST",Encoding.UTF8.GetBytes(contentString));


				string res = Encoding.UTF8.GetString(byResp);
				if(res != null)
				{
					response = JsonConvert.DeserializeObject<Response>(res); 
				}

				

				return response;
            }
			catch (Exception ex)
			{

				throw new Exception("login failed");
			}
        }

		private async Task LoginPartAsync(Response response,WebClientAware webClientAware)
		{
			string url = "https://auth.gateway.meetme.com/oauth/token";
            var formData = new Dictionary<string, string>
                {
                    {"subject_token",$"{response.RequestToken},{response.MebmberId}|android,4d7e52d8-4dab-4c41-acc0-b0a8deb5d112,3825:3825" },
                    { "subject_token_type", "urn:ietf:params:oauth:token-type:session"},
                    {"grant_type", "urn:ietf:params:oauth:grant-type:token-exchange" }
                };
            var content = new FormUrlEncodedContent(formData);
            string contentString = await content.ReadAsStringAsync();

			webClientAware.Headers.Clear();

			webClientAware.Headers.Add("content-type", "application/x-www-form-urlencoded");
			webClientAware.Headers.Add("user-agent", "meetme/3825 (id=com.myyearbook.m; variant=release) android/22 (5.1.1) sns/6.3.1 (release) okhttp/???");
			webClientAware.Headers.Add("authorization", "Basic bWVldG1lOnNlY3JldA==");

			byte[] byRes = await webClientAware.UploadDataTaskAsync(new Uri(url),"POST",Encoding.UTF8.GetBytes(contentString));

			string res = Encoding.UTF8.GetString(byRes);

			if(res != null)
			{

			}
        }
    }
}
