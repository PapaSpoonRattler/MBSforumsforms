using System.Data.SqlClient;

namespace MBSforumsforms
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
		protected override void OnLoad(EventArgs e)
		{

			PopulateForums();
			base.OnLoad(e);

		}

		//class Profile
		//{
		//    public int userID { get; set; }
		//    public string userPassword { get; set; }
		//    public Profile(SqlDataReader reader)
		//    {
		//        userID = (int)reader["ID"];
		//        userPassword = (string)reader["Password"];
		//    }
		//}

		private void LogIn()
		{
			bool loginSuccess = false;

			int ID = int.Parse(txtID.Text);
			string pass = txtPassword.Text;

			var users = User.FetchAll();
			foreach (var user in users)
			{
				if (ID == user.UserID && pass == user.Password)
				{
					ShowMain(true);
					lblIncorrect.Visible = false;
					loginSuccess = true;
					User.CurrentUserID = ID;
				}
				if (loginSuccess == false)
					lblIncorrect.Visible = true;
			}
		}

		private void PopulateForums()
		{
			var forums = Forum.FetchAll();
			foreach (var forum in forums)
			{
				lstForums.Items.Add(forum);
			}
		}

		private void PopulateTopics(int forumID)
		{
			lstPosts.Items.Clear();
			lstTopics.Items.Clear();

			var topics = Topic.FetchAll();
			foreach (var topic in topics)
			{
				if (topic.ForumID == forumID)
					lstTopics.Items.Add(topic);
			}
		}

		private void PopulatePosts(int topicID)
		{
			lstPosts.Items.Clear();

			var posts = Post.FetchAll();
			foreach (var post in posts)
			{
				if (post.TopicID == topicID)
					lstPosts.Items.Add(post);
			}
		}

		private void PopulatePosts_Old(int topicID)
		{
			SqlConnection connection = new SqlConnection(@"Server=JEREMYS-PC\SQLEXPRESS;Database=MBSforum;Trusted_Connection=True;");
			connection.Open();
			var sql = "SELECT * FROM posts";
			SqlCommand cmd = new SqlCommand(sql, connection);
			SqlDataReader reader = cmd.ExecuteReader();

			lstPosts.Items.Clear();

			while (reader.Read())
			{
				if ((int)reader["TopicID"] == topicID)
				{
					var post = new Post(reader);

					lstPosts.Items.Add(post);
				}
			}
		}

		private void CreatePost()
		{
			txtPostDesc.Text = "";
			txtPostTitle.Text = "";
			txtPostAuthor.Text = "";

			txtPostDesc.Enabled = true;
			txtPostTitle.Enabled = true;
			txtPostAuthor.Enabled = false;
			txtPostAuthor.Text = "Me";

			txtPostAuthor.Visible = true;
			txtPostDesc.Visible = true;
			txtPostTitle.Visible = true;
			lblAuthor.Visible = true;
			lblPostName.Visible = true;

			bttnPost.Visible = true;
			bttnLike.Visible = false;
		}

		private void FinalizePost(int topicID)
		{
			string postName, postDesc, postDate, postTime;
			int numOfLikes, postAuthorID;

			postName = txtPostTitle.Text;
			postDesc = txtPostDesc.Text;
			postAuthorID = User.CurrentUserID;
			postDesc = postDesc.ReplaceLineEndings();

			postDate = DateTime.Now.ToString("MM/dd/yy");
			postTime = DateTime.Now.ToString("h:mm:ss tt");

			numOfLikes = 0;

			if (String.IsNullOrWhiteSpace(txtPostTitle.Text))
			{
				lblPostName.BackColor = Color.Firebrick;
			}
			else
			{
				lblPostName.BackColor = Color.Transparent;

				Post.Insert(topicID, numOfLikes, postAuthorID, postName, postDesc, postDate, postTime);

				RefreshPosts();
			}
		}

		private void ViewPost(int postAuthorID, string postTitle, string postDesc)
		{
			txtPostDesc.Text = postDesc;
			txtPostTitle.Text = postTitle;
			txtPostAuthor.Text = postAuthorID.ToString();

			txtPostDesc.Enabled = false;
			txtPostTitle.Enabled = false;
			txtPostAuthor.Enabled = false;

			txtPostAuthor.Visible = true;
			txtPostDesc.Visible = true;
			txtPostTitle.Visible = true;

			bttnPost.Visible = false;
			bttnLike.Visible = true;

			lblPostName.Visible = true;
			lblAuthor.Visible = true;

			CanEdit(postAuthorID);
			UpdateUsers(postAuthorID);
		}

		private void UpdateUsers(int postAuthorID)
		{
			var author = User.Fetch(postAuthorID);

			int userID = author.UserID;

			if (userID == postAuthorID)
				txtPostAuthor.Text = author.Username;
		}

		private void UpdateUsers_Old(int postAuthorID)
		{
			SqlConnection connection = new SqlConnection(@"Server=JEREMYS-PC\SQLEXPRESS;Database=MBSforum;Trusted_Connection=True;");
			connection.Open();
			var sql = "SELECT * FROM users INNER JOIN posts ON users.UserID = posts.PostAuthorID";
			SqlCommand cmd = new SqlCommand(sql, connection);
			SqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				int userID = (int)reader["UserID"];

				if (userID == postAuthorID)
				{
					txtPostAuthor.Text = (string)reader["Username"];
				}
			}
		}

		private void CanEdit(int postAuthorID)
		{
			if (User.CurrentUserID == postAuthorID)
			{
				bttnEditPost.Visible = true;
				bttnRemove.Visible = true;
			}
			else
			{
				bttnEditPost.Visible = false;
				bttnRemove.Visible = false;
			}
		}

		private void EditPost()
		{
			bttnEditPost.Text = "Confirm Edit";

			txtPostDesc.Enabled = true;
		}

		private void FinalizeEdit()
		{
			txtPostDesc.Enabled = false;

			string postDesc = txtPostDesc.Text;
			postDesc = postDesc.ReplaceLineEndings();
			var selectedPost = (Post)lstPosts.SelectedItem;
			var postID = selectedPost.PostID;

			bttnEditPost.Text = "Edit";

			Post.PostEdit(postDesc, postID);

			RefreshPosts();
		}

		private void RemovePost()
		{
			var selectedPost = (Post)lstPosts.SelectedItem;
			var postID = selectedPost.PostID;

			Post.Remove(postID);

			RefreshPosts();
		}

		private void ShowMain(bool shouldShow)
		{
			lstForums.Visible = shouldShow;
			lstTopics.Visible = shouldShow;
			lstPosts.Visible = shouldShow;

			lblAppName.Visible = !shouldShow;
			lblUsername.Visible = !shouldShow;
			lblPassword.Visible = !shouldShow;
			txtID.Visible = !shouldShow;
			txtPassword.Visible = !shouldShow;
			bttnLogin.Visible = !shouldShow;
		}

		private void lstForums_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstForums.SelectedItem is Forum forum)
			{
				PopulateTopics(forum.ID);
				bttnCreate.Visible = false;
			}
		}

		private void lstTopics_SelectedIndexChanged(object sender, EventArgs e)
		{
			RefreshPosts();
		}

		private void RefreshPosts()
		{
			if (lstTopics.SelectedItem is Topic topic)
			{
				PopulatePosts(topic.ID);
				bttnCreate.Visible = true;
			}
		}

		private void lstPosts_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstPosts.SelectedItem is Post post)
				ViewPost(post.PostAuthorID, post.PostName, post.PostDescrip);
		}

		private void bttnCreate_Click(object sender, EventArgs e)
		{
			CreatePost();
		}

		private void bttnPost_Click(object sender, EventArgs e)
		{
			if (lstTopics.SelectedItem is Topic topic)
				FinalizePost(topic.ID);
			else
				throw new Exception($"Unexpected Type {lstTopics.SelectedItem.GetType().Name}");
		}

		private void bttnLogin_Click(object sender, EventArgs e)
		{
			LogIn();
		}

		private void bttnEditPost_Click(object sender, EventArgs e)
		{
			if (bttnEditPost.Text == "Edit")
				EditPost();
			else if (bttnEditPost.Text == "Confirm Edit")
				FinalizeEdit();
		}

		private void bttnRemove_Click(object sender, EventArgs e)
		{
			RemovePost();
		}
	}
}