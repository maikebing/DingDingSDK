using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DingDingSDK.utils
{
    public class HttpHelper
    {
        public static BsonDocument httpGet(String url) 
        {
            return new BsonDocument() { };
        //    var request = System.Net.WebRequest.CreateHttp(url);
        //    request.Timeout = 4000;


        //    //System.Net.WebClient httpGet = new System.Net.WebClient();
        //    //httpGet.in
            
        //    //HttpGet httpGet = new HttpGet(url);
        //    //CloseableHttpResponse response = null;
        //    //CloseableHttpClient httpClient = HttpClients.createDefault();
        //  //  RequestConfig requestConfig = RequestConfig.custom().
        //		//setSocketTimeout(2000).setConnectTimeout(2000).build();
        //  //  httpGet.setConfig(requestConfig);

        //try {
        //        response = httpClient.execute(httpGet, new BasicHttpContext());

        //        if (response.getStatusLine().getStatusCode() != 200)
        //        {

        //            System.out.println("request url failed, http code=" + response.getStatusLine().getStatusCode()
        //                               + ", url=" + url);
        //            return null;
        //        }
        //        HttpEntity entity = response.getEntity();
        //        if (entity != null)
        //        {
        //            String resultStr = EntityUtils.toString(entity, "utf-8");

        //            JSONObject result = JSON.parseObject(resultStr);
        //            if (result.getInteger("errcode") == 0)
        //            {
        //                //                	result.remove("errcode");
        //                //                	result.remove("errmsg");
        //                return result;
        //            }
        //            else
        //            {
        //                System.out.println("request url=" + url + ",return value=");
        //                System.out.println(resultStr);
        //                int errCode = result.getInteger("errcode");
        //                String errMsg = result.getString("errmsg");
        //                throw new OApiException(errCode, errMsg);
        //            }
        //        }
        //    } catch (IOException e) {
        //        System.out.println("request url=" + url + ", exception, msg=" + e.getMessage());
        //        e.printStackTrace();
        //    } finally {
        //        if (response != null)
        //            try
        //            {
        //                response.close();
        //            }
        //            catch (IOException e)
        //            {
        //                e.printStackTrace();
        //            }
        //    }

        //return null;
        }


        public static BsonDocument httpPost(String url, Object data) 
        {
            WebClient client = new WebClient();
            client.Headers[HttpResponseHeader.ContentType] = "pplication/json";
            var postdata = System.Text.UTF8Encoding.UTF8.GetBytes((data as BsonDocument).ToString());
            var respostData=client.UploadData(url, postdata);
            return BsonDocument.Parse(System.Text.UTF8Encoding.UTF8.GetString(respostData));

            //return new BsonDocument() { };
            //    HttpPost httpPost = new HttpPost(url);
            //    CloseableHttpResponse response = null;
            //    CloseableHttpClient httpClient = HttpClients.createDefault();
            //    RequestConfig requestConfig = RequestConfig.custom().
            //		setSocketTimeout(2000).setConnectTimeout(2000).build();
            //    httpPost.setConfig(requestConfig);
            //    httpPost.addHeader("Content-Type", "application/json");

            //try {
            //        StringEntity requestEntity = new StringEntity(JSON.toJSONString(data), "utf-8");
            //        httpPost.setEntity(requestEntity);

            //        response = httpClient.execute(httpPost, new BasicHttpContext());

            //        if (response.getStatusLine().getStatusCode() != 200)
            //        {

            //            System.out.println("request url failed, http code=" + response.getStatusLine().getStatusCode()
            //                               + ", url=" + url);
            //            return null;
            //        }
            //        HttpEntity entity = response.getEntity();
            //        if (entity != null)
            //        {
            //            String resultStr = EntityUtils.toString(entity, "utf-8");

            //            JSONObject result = JSON.parseObject(resultStr);
            //            if (result.getInteger("errcode") == 0)
            //            {
            //                result.remove("errcode");
            //                result.remove("errmsg");
            //                return result;
            //            }
            //            else
            //            {
            //                System.out.println("request url=" + url + ",return value=");
            //                System.out.println(resultStr);
            //                int errCode = result.getInteger("errcode");
            //                String errMsg = result.getString("errmsg");
            //                throw new OApiException(errCode, errMsg);
            //            }
            //        }
            //    } catch (IOException e) {
            //        System.out.println("request url=" + url + ", exception, msg=" + e.getMessage());
            //        e.printStackTrace();
            //    } finally {
            //        if (response != null)
            //            try
            //            {
            //                response.close();
            //            }
            //            catch (IOException e)
            //            {
            //                e.printStackTrace();
            //            }
            //    }

            //return null;
        }


        public static BsonDocument uploadMedia(String url, FileInfo file) 
        {
            return new BsonDocument() { };
        //    HttpPost httpPost = new HttpPost(url);
        //    CloseableHttpResponse response = null;
        //    CloseableHttpClient httpClient = HttpClients.createDefault();
        //    RequestConfig requestConfig = RequestConfig.custom().setSocketTimeout(2000).setConnectTimeout(2000).build();
        //    httpPost.setConfig(requestConfig);

        //    HttpEntity requestEntity = MultipartEntityBuilder.create().addPart("media",
        //		new FileBody(file, ContentType.APPLICATION_OCTET_STREAM, file.getName())).build();
        //    httpPost.setEntity(requestEntity);

        //try {
        //        response = httpClient.execute(httpPost, new BasicHttpContext());

        //        if (response.getStatusLine().getStatusCode() != 200)
        //        {

        //            System.out.println("request url failed, http code=" + response.getStatusLine().getStatusCode()
        //                               + ", url=" + url);
        //            return null;
        //        }
        //        HttpEntity entity = response.getEntity();
        //        if (entity != null)
        //        {
        //            String resultStr = EntityUtils.toString(entity, "utf-8");

        //            JSONObject result = JSON.parseObject(resultStr);
        //            if (result.getInteger("errcode") == 0)
        //            {
        //                // 成功
        //                result.remove("errcode");
        //                result.remove("errmsg");
        //                return result;
        //            }
        //            else
        //            {
        //                System.out.println("request url=" + url + ",return value=");
        //                System.out.println(resultStr);
        //                int errCode = result.getInteger("errcode");
        //                String errMsg = result.getString("errmsg");
        //                throw new OApiException(errCode, errMsg);
        //            }
        //        }
        //    } catch (IOException e) {
        //        System.out.println("request url=" + url + ", exception, msg=" + e.getMessage());
        //        e.printStackTrace();
        //    } finally {
        //        if (response != null)
        //            try
        //            {
        //                response.close();
        //            }
        //            catch (IOException e)
        //            {
        //                e.printStackTrace();
        //            }
        //    }

        //return null;
        }


        public static BsonDocument downloadMedia(String url, String fileDir)
        {
            return new BsonDocument() { };
        //    HttpGet httpGet = new HttpGet(url);
        //    CloseableHttpResponse response = null;
        //    CloseableHttpClient httpClient = HttpClients.createDefault();
        //    RequestConfig requestConfig = RequestConfig.custom().setSocketTimeout(2000).setConnectTimeout(2000).build();
        //    httpGet.setConfig(requestConfig);

        //try {
        //        HttpContext localContext = new BasicHttpContext();

        //        response = httpClient.execute(httpGet, localContext);

        //        RedirectLocations locations = (RedirectLocations)localContext.getAttribute(HttpClientContext.REDIRECT_LOCATIONS);
        //        if (locations != null)
        //        {
        //            URI downloadUrl = locations.getAll().get(0);
        //            String filename = downloadUrl.toURL().getFile();
        //            System.out.println("downloadUrl=" + downloadUrl);
        //            File downloadFile = new File(fileDir + File.separator + filename);
        //            FileUtils.writeByteArrayToFile(downloadFile, EntityUtils.toByteArray(response.getEntity()));
        //            JSONObject obj = new JSONObject();
        //            obj.put("downloadFilePath", downloadFile.getAbsolutePath());
        //            obj.put("httpcode", response.getStatusLine().getStatusCode());



        //            return obj;
        //        }
        //        else
        //        {
        //            if (response.getStatusLine().getStatusCode() != 200)
        //            {

        //                System.out.println("request url failed, http code=" + response.getStatusLine().getStatusCode()
        //                                   + ", url=" + url);
        //                return null;
        //            }
        //            HttpEntity entity = response.getEntity();
        //            if (entity != null)
        //            {
        //                String resultStr = EntityUtils.toString(entity, "utf-8");

        //                JSONObject result = JSON.parseObject(resultStr);
        //                if (result.getInteger("errcode") == 0)
        //                {
        //                    // 成功
        //                    result.remove("errcode");
        //                    result.remove("errmsg");
        //                    return result;
        //                }
        //                else
        //                {
        //                    System.out.println("request url=" + url + ",return value=");
        //                    System.out.println(resultStr);
        //                    int errCode = result.getInteger("errcode");
        //                    String errMsg = result.getString("errmsg");
        //                    throw new OApiException(errCode, errMsg);
        //                }
        //            }
        //        }
        //    } catch (IOException e) {
        //        System.out.println("request url=" + url + ", exception, msg=" + e.getMessage());
        //        e.printStackTrace();
        //    } finally {
        //        if (response != null)
        //            try
        //            {
        //                response.close();
        //            }
        //            catch (IOException e)
        //            {
        //                e.printStackTrace();
        //            }
        //    }

        //return null;
        }
    }
}
