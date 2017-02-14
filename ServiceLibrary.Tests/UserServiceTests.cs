using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ServiceLibrary.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_NullUser_ExceptionThrown()
        {
            UserService service = new UserService();
            service.Add(null);
        }

        [TestMethod]
        public void Add_EmptyUser_Success()
        {
            UserService service = new UserService();
            User user = new User();
            service.Add(user);
        }

        [TestMethod]
        public void Add_DefaultUser_Success()
        {
            UserService service = new UserService();
            User user = new User
            {
                FirstName = "FirstName",
                LastName = "LastName",
                DateOfBirth = new DateTime(2000, 9, 9)
            };
            service.Add(user);
        }

        [TestMethod]
        public void Add_DoubleUser_Success()
        {
            UserService service = new UserService();
            User user = new User
            {
                FirstName = "FirstName",
                LastName = "LastName",
                DateOfBirth = new DateTime(2000, 9, 9)
            };
            service.Add(user);
            service.Add(user);
        }

        [TestMethod]
        public void Delete_UnexistedUser_Success()
        {
            UserService service = new UserService();
            User user = new User
            {
                FirstName = "FirstName",
                LastName = "LastName",
                DateOfBirth = new DateTime(2000, 9, 9)
            };
            service.Delete(user);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Delete_NullUser_Exception()
        {
            UserService service = new UserService();
            service.Delete(null);
        }

        [TestMethod]
        public void Delete_ExistedUser_Success()
        {
            UserService service = new UserService();
            User user = new User
            {
                FirstName = "FirstName",
                LastName = "LastName",
                DateOfBirth = new DateTime(2000, 9, 9)
            };
            service.Add(user);
            service.Delete(user);
        }

        [TestMethod]
        public void Search_UnexistedUser_Null()
        {
            UserService service = new UserService();
            var searchResult = service.Search(x => x.FirstName == "FirstName");
            Assert.IsNull(searchResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Search_Null_Exception()
        {
            UserService service = new UserService();
            service.Search(null);
        }

        [TestMethod]
        public void Search_ExistedUser_ListOfUsers()
        {
            UserService service = new UserService();
            User user = new User
            {
                FirstName = "FirstName",
                LastName = "LastName",
                DateOfBirth = new DateTime(2000, 9, 9)
            };
            service.Add(user);
            var searchResult = service.Search(x => x.FirstName == "FirstName");
            Assert.IsNotNull(searchResult);
        }
    }
}
