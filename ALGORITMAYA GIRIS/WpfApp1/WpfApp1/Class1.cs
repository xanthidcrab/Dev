using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
  
    public class Person
    {
        [BsonElement("id")]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("birthDate")]
        public DateTime BirthDate { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; }

        [BsonElement("address")]
        public Address Address { get; set; }

        [BsonElement("phones")]
        public List<PhoneNumber> Phones { get; set; }
    }

    public class Address
    {
        [BsonElement("street")]
        public string Street { get; set; }

        [BsonElement("city")]
        public string City { get; set; }
    }

    public class PhoneNumber
    {
        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("number")]
        public string Number { get; set; }
    }
    public class BsonHelper
    {
        public static byte[] ToBson<T>(T obj)
        {
            return obj.ToBson();
        }

        public static T FromBson<T>(byte[] data)
        {
            return BsonSerializer.Deserialize<T>(data);
        }

        public static void SaveBsonFile<T>(T obj, string path)
        {
            var bson = obj.ToBson();
            File.WriteAllBytes(path, bson);
        }

        public static T LoadBsonFile<T>(string path)
        {
            var data = File.ReadAllBytes(path);
            return BsonSerializer.Deserialize<T>(data);
        }
    }
}
