using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_API_Json.Models;

namespace Test_API_Json
{
    internal class APIAppRequest<T>
    {
        public static ResponseModel<T> GetData(string num = "", string req = "/posts/")
        {
            var response = APIUtils<T>.Response($"{req}{num}");
            //var response = APIUtils<T>.GetResponse($"{req}{num}");
            ResponseModel<T> responsemodel = new ResponseModel<T>();
            responsemodel.StatusCode = (int)response.StatusCode;
            responsemodel.TypeResponseBody = response.ContentType.ToString();

            var json = response.Content;            
            if (json.StartsWith("["))
            {
                responsemodel.Data = JsonConvert.DeserializeObject<List<T>>(json);
                //List<T> data = JsonConvert.DeserializeObject<List<T>>(json);
                //return data;
            }
            else
            {
                T dataprev = JsonConvert.DeserializeObject<T>(json);
                responsemodel.Data = new List<T>();
                responsemodel.Data.Add(dataprev);
                //T data = JsonConvert.DeserializeObject<T>(json);
                //return new List<T>(new[] { data });
            }
            return responsemodel;
        }
        public static ResponseModel<T> PostData(T post, string req = "/posts/")
        {
            var response = APIUtils<T>.Response($"{req}", post, "Post");
            //var response = APIUtils<T>.PostResponse(req, post);
            ResponseModel<T> responsemodel = new ResponseModel<T>();
            responsemodel.StatusCode = (int)response.StatusCode;
            responsemodel.TypeResponseBody = response.ContentType.ToString();
            responsemodel.Data = new List<T>();
            responsemodel.Data.Add(response.Data);
            return responsemodel;
        }
        //public static void GetPost(string key, out ResponseModel responsemodel, out List<T> data)
        //{
        //    var response = APIUtils.GetResponse(key);
        //    responsemodel = null;
        //    responsemodel.StatusCode = (int)response.StatusCode;
        //    responsemodel.ResponseBody = response.ContentType.ToString();

        //    var json = response.Content;

        //    if (json.StartsWith("["))
        //    {
        //        data = JsonConvert.DeserializeObject<List<T>>(json);
        //        //List<T> data = JsonConvert.DeserializeObject<List<T>>(json);
        //        //return data;
        //    }
        //    else
        //    {
        //        T dataprev = JsonConvert.DeserializeObject<T>(json);
        //        data = new List<T>();
        //        data.Add(dataprev);
        //        //T data = JsonConvert.DeserializeObject<T>(json);
        //        //return new List<T>(new[] { data });
        //    }
        //}
    }
}
