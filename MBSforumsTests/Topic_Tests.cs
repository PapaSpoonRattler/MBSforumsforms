using MBSforums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBSforumsTests
{
	[TestClass]
	public class Topic_Tests
    {
		[TestInitialize]
		public void Intialize()
		{
			Config.ConnectionString = @"Server=DESKTOP-E4CK1RC\SQLEXPRESS;Database=MBSforum_tests;Trusted_Connection=True;";
		}

		[TestMethod]
		public void TestFetchAll()
		{
			var topics = Topic.FetchAll();
			Assert.IsTrue(topics.Count == 2);
		}

		[TestMethod]
		public void TestFetch()
		{
			var topicID = 2;
			var topic = Topic.Fetch(topicID);

			Assert.IsTrue(topicID == topic.ID);
		}
	}
}
