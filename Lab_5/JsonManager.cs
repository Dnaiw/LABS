﻿using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Formatting = System.Xml.Formatting;

namespace Lab_5
{
    public class JsonManager<T> where T : new()
    {
        private readonly string _jsonPath;

        public JsonManager(string path)
        {
            this._jsonPath = path;
        }

        public void SaveToJson(T data, string fileName)
        {

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = (Newtonsoft.Json.Formatting)Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(data, jsonSerializerSettings);
            File.WriteAllText(this._jsonPath + "\\" + fileName, json);
        }

        public T LoadJson(string fileName)
        {
            string allText = File.ReadAllText(this._jsonPath + "\\" + fileName);
            T items = JsonConvert.DeserializeObject<T>(allText);

            return items;
        }

        public bool IsExists(string fileName)
        {
            return File.Exists(this._jsonPath + "\\" + fileName);
        }
    }
}
