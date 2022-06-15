using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using O2O.Conectores.SoapToRest.Controllers;
using O2O.Conectores.SoapToRest.Models;


namespace O2O.Controllers
{
    [RoutePrefix("api/SOAP")]
    public class SoapToRestController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("CallSoapMethod")]
        public string CallSoapMethod(XmlToJson xmlToJson)
        {

            SoapToRest sr = new SoapToRest();

            string json;
            json = sr.InvokeService(xmlToJson);
            json = sr.xmlToJson(json);

            return json;
        }


        [AcceptVerbs("POST")]
        [Route("CallSoapMethodXml")]
        public string CallSoapMethodXml(CallSoap callSoap)
        {

            SoapToRest sr = new SoapToRest();

            string json;
            json = sr.InvokeServicexml(callSoap);
            json = sr.xmlToJson(json);

            return json;
        }



        [AcceptVerbs("POST")]
        [Route("XmlToJson")]
        public string getXmlToJSon(XmlToJson xmlToJson)
        {
            SoapToRest sr = new SoapToRest();
            return sr.xmlToJson(xmlToJson.Json);
        }


        [AcceptVerbs("POST")]
        [Route("JSonToXml")]
        public XmlDocument getJSonToXml(XmlToJson xmlToJson)
        {
            SoapToRest sr = new SoapToRest();
            return sr.JsonToxml(xmlToJson.Json);
        }


    }
}
