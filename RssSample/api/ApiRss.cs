﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using RssSample.entity;

namespace RssSample.api
{
    public class ApiRss
    {
        private static string URL = "https://news.yahoo.co.jp/pickup/rss.xml";
        public ApiRss()
        {
        }

        public static async Task<dynamic> GetDataFromServiceOfXml() {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(URL);
            if (response == null) {
                return null;
            }
            int statusCode = (int)response.StatusCode;
            if (statusCode >= 400) {
                return null;
            }
            string result = response.Content.ReadAsStringAsync().Result;
            dynamic data = result;
            return data;
        }

        public static async Task<ObservableCollection<Rss>> Get() {
            dynamic result = await GetDataFromServiceOfXml();
            if (result == null) {
                return null;
            }
            ObservableCollection<Rss> rssList = parse(result);
            return rssList;
        }

        private static ObservableCollection<Rss> parse(dynamic result) {
            XDocument doc = XDocument.Parse(result);
            IEnumerable<XElement> items =doc.Element("rss").Element("channel").Elements("item");
            ObservableCollection<Rss> rssList = new ObservableCollection<Rss>();
            foreach(XElement item in items) {
                Rss rss = new Rss();
                rss.title = (string)item.Element("title");
                rss.link = (string)item.Element("link");
                rss.pubDate = (string)item.Element("pubDate");
                rss.guide = (string)item.Element("guide");
                parseEnclosure(ref rss, item.Element("enclosure"));
                rssList.Add(rss);
            }
            return rssList;


        }

        private static void parseEnclosure(ref Rss rss, XElement enclosure) {
            rss.enclosureUrl = (string)enclosure.Attribute("url");
            rss.enclosureType = (string)enclosure.Attribute("type");
        }
    }
}
