using MBSforums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MBSforumsTests
{
	[TestClass]
	public class Forum_Tests
	{
		[TestInitialize]
		public void Intialize()
        {
			Config.ConnectionString = @"Server=DESKTOP-E4CK1RC\SQLEXPRESS;Database=MBSforum_tests;Trusted_Connection=True;";
		}

		[TestMethod]
		public void TestFetchAll()
		{
			var forums = Forum.FetchAll();
			Assert.IsTrue(forums.Count == 2);
		}

		[TestMethod]
		public void TestFetch()
        {
			var forumID = 1;
			var forum = Forum.Fetch(forumID);

			Assert.IsTrue(forumID == forum.ID);
        }
	}
}