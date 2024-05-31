using FinalProject.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Reflection;
using FinalProject.Model;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        private EnquiryLoginDataAccess _elda;
        private Document _document;

        [TestInitialize]
        public void Setup()
        {

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();


            _elda = new EnquiryLoginDataAccess(config);
            _document = new Document();
        }


        [TestMethod]
        public void TestForCreateEnquirer()
        {

            string emailAlreadyExist = "";
            string validEmail = "";

            emailAlreadyExist = _elda.CreateEnquirer("rathidhruv9285@gmail.com", "hello123");
            validEmail = _elda.CreateEnquirer("hello123@gmail.com", "hello123");

            Assert.AreNotEqual(emailAlreadyExist, validEmail);

        }

        [TestMethod]
        public void TestForGetDocuments()
        {

           Assert.AreEqual(_elda.GetDocuments("xyz@gmail.com") , null);
            
            var doc  = new Document();
            doc = null;

            doc = _elda.GetDocuments("rathidhruv9285@gmail.com");
            Assert.AreNotEqual(doc, null);

        }


        [TestMethod]
        public void TestForGetEnquirer()
        {
           

            var enq = new CreateEnquiry();
            enq = null;

            enq = _elda.GetEnquirer("dhruv@gmail.com","dhruvrathi");
             Assert.AreNotEqual(enq, null);
        }



    }
}