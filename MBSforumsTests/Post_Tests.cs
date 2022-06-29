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
    public class Post_Tests
    {
        [TestInitialize]
        public void Intialize()
        {
            Config.ConnectionString = @"Server=DESKTOP-E4CK1RC\SQLEXPRESS;Database=MBSforum_tests;Trusted_Connection=True;";
        }

        [TestMethod]
        public void Test()
        {
            var topicID = 2;
            var numOfLikes = 0;
            var postAuthorID = 1;
            var postName = "Test title for the Test Database in C#";
            var postDate = "2012-02-21T18:10:00";
            var postTime = "2012-02-21T18:10:00";
            var postDesc = "awdwadwa";
            var newPostDesc = "Fixed!";
            var id = Post.FetchInsertID(topicID, numOfLikes, postAuthorID, postName, postDesc, postDate, postTime);
            var post = Post.Fetch(id);
            Assert.AreEqual(post.PostDescrip, postDesc);
            Post.PostEdit(newPostDesc, id);
            Assert.AreEqual(post.PostDescrip, postDesc);
            Post.Remove(id);
            Assert.ThrowsException<Exception>(() => Post.Fetch(id));

            //Delegate, anonymous methods, lambdas, stored procedures, sql injection attack
            //If you're feeling brave, ANONYMOUS TYPES
        }

    }
}
