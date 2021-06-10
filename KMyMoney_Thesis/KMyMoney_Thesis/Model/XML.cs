using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace KMyMoney_Thesis.Model
{
    public class XML
    {

        [XmlRoot(ElementName="KMYMONEY_FILE")]
        public class KMYMONEY_FILE
        {
            [XmlElement(ElementName = "FILEINFO")]
            public FileInfo FILEINFO { get; set; }
            [XmlElement(ElementName = "USER")]
            public User USER { get; set; }
            [XmlElement(ElementName = "INSTITUTIONS")]
            public Institutions INSTITUTIONS { get; set; }
            [XmlElement(ElementName = "PAYEES")]
            public Payees PAYEES { get; set; }
            //....
            [XmlElement(ElementName = "KEYVALUEPAIRS")]
            public KeyValuePairs KEYVALUEPAIRS { get; set; }
            [XmlElement(ElementName = "ONLINEJOBS")]
            public OnlineJobs ONLINEJOBS { get; set; }
        }

        [XmlRoot(ElementName = "INSTITUTION")]
        public class FileInfo
        {
            [XmlElement(ElementName = "CREATION_DATE")]
            public CreationDate CREATION_DATE { get; set; }
            [XmlElement(ElementName = "LAST_MODIFIED_DATE")]
            public LastModifiedDate LAST_MODIFIED_DATE { get; set; }
            [XmlElement(ElementName = "VERSION")]
            public Version VERSION { get; set; }
            [XmlElement(ElementName = "FIXVERSION")]
            public FixVersion FIXVERSION { get; set; }
        }

        [XmlRoot(ElementName = "CREATION_DATE")]
        public class CreationDate
        {
            [XmlAttribute(AttributeName = "date")]
            public string date { get; set; }
        }

        [XmlRoot(ElementName = "LAST_MODIFIED_DATE")]
        public class LastModifiedDate
        {
            [XmlAttribute(AttributeName = "date")]
            public string date { get; set; }            
        }

        [XmlRoot(ElementName = "VERSION")]
        public class Version
        {
            [XmlAttribute(AttributeName = "id")]
            public string id { get; set; }            
        }

        [XmlRoot(ElementName = "FIXVERSION")]
        public class FixVersion
        {
            [XmlAttribute(AttributeName = "id")]
            public string id { get; set; }            
        }

        [XmlRoot(ElementName = "INSTITUTION")]
        public class User
        {
            [XmlAttribute(AttributeName = "email")]
            public string email { get; set; }
            [XmlAttribute(AttributeName = "name")]
            public string name { get; set; }
            [XmlElement(ElementName = "ADDRESS")]
            public Address ADDRESS { get; set; }
        }

        [XmlRoot(ElementName = "ADDRESS")]
        public class Address
        {
            [XmlAttribute(AttributeName = "street")]
            public string street { get; set; }
            [XmlAttribute(AttributeName = "telephone")]
            public string telephone { get; set; }
            [XmlAttribute(AttributeName = "county")]
            public string county { get; set; }
            [XmlAttribute(AttributeName = "city")]
            public string city { get; set; }
            [XmlAttribute(AttributeName = "zipcode")]
            public string zipcode { get; set; }
        }

        [XmlRoot(ElementName = "INSTITUTIONS")]
        public class Institutions
        {
            [XmlAttribute(AttributeName = "count")]
            public string count { get; set; }
            [XmlElement(ElementName = "INSTITUTION")]
            public List<Institution> INSTITUTION { get; set; } //multy

            public void setCount()
            {
                try
                {
                    count = INSTITUTION.Count.ToString();
                }
                catch (Exception error)
                {
                    count = "0";
                }
                //count = INSTITUTION.Count.ToString();
            }

        }

        [XmlRoot(ElementName = "INSTITUTION")]
        public class Institution
        {
            [XmlAttribute(AttributeName = "manager")]
            public string manager { get; set; }
            [XmlAttribute(AttributeName = "id")]
            public string id { get; set; }
            [XmlAttribute(AttributeName = "name")]
            public string name { get; set; }
            [XmlAttribute(AttributeName = "sortcode")]
            public string sortcode { get; set; }
            [XmlElement(ElementName = "ADDRESS")]
            public Address2 ADDRESS { get; set; }
            [XmlElement(ElementName = "ACCOUNTIDS")]
            public ACCOUNTIDS ACCOUNTIDS { get; set; }
        }

        [XmlRoot(ElementName = "ADDRESS")]
        public class Address2
        {
            [XmlAttribute(AttributeName = "street")]
            public string street { get; set; }
            [XmlAttribute(AttributeName = "telephone")]
            public string telephone { get; set; }
            [XmlAttribute(AttributeName = "zip")]
            public string zip { get; set; }
            [XmlAttribute(AttributeName = "city")]
            public string city { get; set; }
        }

        [XmlRoot(ElementName = "ACCOUNTIDS")]
        public class ACCOUNTIDS
        {
            [XmlElement(ElementName = "ACCOUNTID")]
            public List<ACCOUNTID> ACCOUNTID { get; set; }
        }

        [XmlRoot(ElementName = "ACCOUNTID")]
        public class ACCOUNTID
        {
            [XmlAttribute(AttributeName = "id")]
            public string id { get; set; }
        }

        [XmlRoot(ElementName = "PAYEES")]
        public class Payees
        {
            [XmlAttribute(AttributeName = "count")]
            public string count { get; set; }
            [XmlElement(ElementName = "PAYEE")]
            public List<Payee> PAYEE { get; set; } //multy

            public void setCount()
            {
                try
                {
                    count = PAYEE.Count.ToString();
                }
                catch (Exception error)
                {
                    count = "0";
                }
            }

        }
        
        [XmlRoot(ElementName = "KEYVALUEPAIRS")]
        public class Payee
        {
            [XmlAttribute(AttributeName = "matchingenabled")]
            public string matchingenabled { get; set; }
            [XmlAttribute(AttributeName = "email")]
            public string email { get; set; }
            [XmlAttribute(AttributeName = "notes")]
            public string notes { get; set; }
            [XmlAttribute(AttributeName = "defaultaccountid")]
            public string defaultaccountid { get; set; }
            [XmlAttribute(AttributeName = "id")]
            public string id { get; set; }
            [XmlAttribute(AttributeName = "name")]
            public string name { get; set; }
            [XmlAttribute(AttributeName = "reference")]
            public string reference { get; set; }
            //[XmlElement(ElementName = "ADDRESS")]
            //public Address2 ADDRESS { get; set; }
            //[XmlElement(ElementName = "ACCOUNTIDS")]
            //public ACCOUNTIDS ACCOUNTIDS { get; set; }
        }

        //...

        [XmlRoot(ElementName = "KEYVALUEPAIRS")]
        public class KeyValuePairs
        {            
            [XmlElement(ElementName = "PAIR")]
            public List<Pair> PAIR { get; set; } //multy
        }

        [XmlRoot(ElementName = "PAIR")]
        public class Pair
        {
            [XmlAttribute(AttributeName = "key")]
            public string key { get; set; }
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "ONLINEJOBS")]
        public class OnlineJobs
        {
            [XmlAttribute(AttributeName = "count")]
            public string count { get; set; }
            [XmlElement(ElementName = "ONLINEJOB")]
            public List<OnlineJob> ONLINEJOB { get; set; } //multy

            public void setCount()
            {
                try
                {
                    count = ONLINEJOB.Count.ToString();
                }
                catch (Exception error)
                {
                    count = "0";
                }
            }
        }

        [XmlRoot(ElementName = "ONLINEJOB")]
        public class OnlineJob
        {
            [XmlAttribute(AttributeName = "send")]
            public string send { get; set; }
            [XmlAttribute(AttributeName = "bankAnswerDate")]
            public string bankAnswerDate { get; set; }
            [XmlAttribute(AttributeName = "bankAnswerState")]
            public string bankAnswerState { get; set; }
            [XmlAttribute(AttributeName = "iid")]
            public string iid { get; set; }
            [XmlAttribute(AttributeName = "abortedByUser")]
            public string abortedByUser { get; set; }
            [XmlAttribute(AttributeName = "acceptedByBank")]
            public string acceptedByBank { get; set; }
            [XmlAttribute(AttributeName = "rejectedByBank")]
            public string rejectedByBank { get; set; }
            [XmlAttribute(AttributeName = "sendingError")]
            public string sendingError { get; set; }
        }
    }

}
