using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using O2OUI.Conectores.SoapToRest.Technical;
using O2OUI.Conectores.SoapToRest.Models;


namespace O2OUI.Conectores.SoapToRest.Controllers
{
    [RoutePrefix("api/SOAP")]
    public class SoapToRestController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("CallSoapMethod")]
        public string CallSoapMethod(XmlToJson xmlToJson)
        {

            SoapToRestTechnical sr = new SoapToRestTechnical();

            string json;
            json = sr.InvokeService(xmlToJson);
            json = sr.xmlToJson(json);

            return json;
        }


        [AcceptVerbs("POST")]
        [Route("CallSoapMethodXml")]
        public string CallSoapMethodXml(CallSoap callSoap)
        {

            SoapToRestTechnical sr = new SoapToRestTechnical();

            string json;
            json = sr.InvokeServicexml(callSoap);
            json = sr.xmlToJson(json);

            return json;
        }



        [AcceptVerbs("POST")]
        [Route("XmlToJson")]
        public string getXmlToJSon(XmlToJson xmlToJson)
        {
            SoapToRestTechnical sr = new SoapToRestTechnical();
            return sr.xmlToJson(xmlToJson.Json);
        }


        [AcceptVerbs("POST")]
        [Route("JSonToXml")]
        public XmlDocument getJSonToXml(XmlToJson xmlToJson)
        {
            SoapToRestTechnical sr = new SoapToRestTechnical();
            return sr.JsonToxml(xmlToJson.Json);
        }


    }
}
