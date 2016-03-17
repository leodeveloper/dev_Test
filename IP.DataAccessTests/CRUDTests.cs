using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IP.DataAccess;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Microsoft.XmlDiffPatch;
using System.Xml;
using System.IO;
using System.Text;
using System.Data.SqlTypes;
using System.Collections.Generic;


namespace IP.DataAccessTests
{
    [TestClass]
    public class CRUDTests
    {
        protected JavaScriptSerializer serializer = new JavaScriptSerializer();

        public static bool CompareJson(string expected, string actual)
        {
            var expectedDoc = JsonConvert.DeserializeXmlNode(expected, "root");
            var actualDoc = JsonConvert.DeserializeXmlNode(actual, "root");
            var diff = new XmlDiff(XmlDiffOptions.IgnoreWhitespace |
                                   XmlDiffOptions.IgnoreChildOrder);
            using (var ms = new MemoryStream())
            {
                var writer = new XmlTextWriter(ms, Encoding.UTF8);
                var result = diff.Compare(expectedDoc, actualDoc, writer);
                if (!result)
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    Console.WriteLine(new StreamReader(ms).ReadToEnd());
                }
                return result;
            }
        }

        [TestMethod]
        public void CreateLogEntry()
        {
            var logEntry = new LogEntry()
            {
                UserId = 1,
                OrganisationId = 1,
                ApplicationName = "DataAccessTests",
                CreatedAt = new SqlDateTime(DateTime.Now).Value,
                Message = "Test message",
                Data = Environment.StackTrace
            };
            using (var ctx = new IPContext())
            {
                ctx.LogEntries.Add(logEntry);
                ctx.SaveChanges();
            }
            using (var ctx = new IPContext())
            {
                var fromDb = ctx.LogEntries.Find(logEntry.ID);
                var originalJson = serializer.Serialize(logEntry);
                var fromDbJson = serializer.Serialize(fromDb);
                Assert.AreEqual(originalJson, fromDbJson);
            }
        }


        [TestMethod]
        public void CreateUser()
        {
            var user = new User()
            {
                //Have to initialize the empty list because otherwise the JSON comparison borks
                //TODO: custom serializer?
                LogEntries = new List<LogEntry>()
            };
            using (var ctx = new IPContext())
            {
                ctx.Users.Add(user);
                ctx.SaveChanges();
            }
            using (var ctx = new IPContext())
            {
                var fromDb = ctx.Users.Find(user.UserId);
                var originalJson = serializer.Serialize(user);
                var fromDbJson = serializer.Serialize(fromDb);
                Assert.IsTrue(CompareJson(originalJson, fromDbJson));
            }
        }
    }
}
