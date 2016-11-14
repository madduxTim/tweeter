using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using Tweeter.DAL;
using Tweeter.Models;

namespace Tweeter.Tests.DAL
{
    [TestClass]
    public class TweeterTests
    {
        private Mock<DbSet<ApplicationUser>> mock_users { get; set; }
        private Mock<TweeterContext> mock_context { get; set; }
        private TweeterRepo Repo { get; set; }
        private List<ApplicationUser> users { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<TweeterContext>();
            mock_users = new Mock<DbSet<ApplicationUser>>();
            Repo = new TweeterRepo(mock_context.Object);
        }

        public void ConnectToDataStore()
        {
            users = new List<ApplicationUser>();
            var query_users = users.AsQueryable();
            mock_users.As<IQueryable<ApplicationUser>>().Setup(m => m.Provider).Returns(query_users.Provider);
            mock_users.As<IQueryable<ApplicationUser>>().Setup(m => m.Expression).Returns(query_users.Expression);
            mock_users.As<IQueryable<ApplicationUser>>().Setup(m => m.ElementType).Returns(query_users.ElementType);
            mock_users.As<IQueryable<ApplicationUser>>().Setup(m => m.GetEnumerator()).Returns(query_users.GetEnumerator());

            mock_context.Setup(c => c.TweeterUsers).Returns(mock_users);


        }

        [TestMethod]
        public void RepoEnsureCanCreateInstance()
        {
            TweeterRepo repo = new TweeterRepo();
            Assert.IsNotNull(repo);
        }
    }
}
