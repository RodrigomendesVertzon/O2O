using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using O2OUI.Conectores.SoapToRest.Models;

namespace O2OUI.Conectores.SoapToRest.Technical
{
    public class SoapToRestTechnical
    {

        public string xmlToJson(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string json = JsonConvert.SerializeXmlNode(doc);
            return json;

        }

        public XmlDocument JsonToxml(string json)
        {

            string xml;
            XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(json);
            doc.LoadXml(doc.InnerXml);
            
            return doc;
                 
        }

        public string InvokeService(XmlToJson xmlToJson)
        {



            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest(GetConfigs.GetConfigSoap(xmlToJson.Identificador).Url);
            XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(xmlToJson.Json);

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    

            string xml = doc.InnerXml;
            xml.Replace("\\", "");
            SOAPReqBody.LoadXml(xml);


       using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    //writting stream result on console    
                    return ServiceResult;
                }
        
            }

            return "Error";
            
        }



        public HttpWebRequest CreateSOAPWebRequest(string url)
        {
            //Making Web Request  
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(url);  
            //SOAPAction  
            Req.Headers.Add(@"SOAPAction:http://tempuri.org/Addition""http://tempuri.org/Addition");  
            //Content_type  
            Req.ContentType = "text/xml;charset=\"utf-8\"";
            Req.Accept = "text/xml";
            //HTTP method  
            Req.Method = "POST";
            //return HttpWebRequest  
            return Req;
        }


        public string InvokeServicexml(CallSoap callSoap)
        {

            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest(GetConfigs.GetConfigSoap(callSoap.Identificador).Url);
            
            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(callSoap.Xml);

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            try
            {
                using (WebResponse Serviceres = request.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                    {
                        //reading stream    
                        var ServiceResult = rd.ReadToEnd();
                        //writting stream result on console    
                        return ServiceResult;
                    }

                }
            }
            catch (Exception ex)
            {
                
                return ex.Message;
            }

        }




    }


}