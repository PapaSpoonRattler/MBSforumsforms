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

        class Forum
        {
            public int ID { get; set; }
            public string ForumName { get; set; }
            public Forum(SqlDataReader reader)
            {
                ID = (int)reader["ID"];
                ForumName = (string)reader["ForumName"];
            }
            public override string ToString()
            {
                return ForumName;
            }
        }

        class Topic
        {
            public int ID { get; set; }
            public string TopicName { get; set; }
            public Topic(SqlDataReader reader)
            {
                ID = (int)reader["ID"];
                TopicName = (string)reader["TopicName"];
            }
            public override string ToString()
            {
                return TopicName;
            }
        }

        class Post
        {
            public string PostDescrip { get; set; }
            public string PostName { get; set; }
            public string PostAuthor { get; set; }
            public Post(SqlDataReader reader)
            {
                PostDescrip = (string)reader["PostDescrip"];
                PostName = (string)reader["PostName"];
                PostAuthor = (string)reader["PostAuthor"];

            }
            public override string ToString()
            {
                return PostName;
            }
        }

        private void LogIn()
        {
            bool loginSuccess = false;

            SqlConnection connection = new SqlConnection(@"Server=DESKTOP-E4CK1RC\SQLEXPRESS;Database=MBSforum;Trusted_Connection=True;");
            connection.Open();
            var sql = "SELECT * FROM users";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //Profile profile = new Profile(reader);
                int ID = int.Parse(txtID.Text);
                var pass = txtPassword.Text;

                if (ID == (int)reader["ID"] && pass == (string)reader["Password"])
                {
                    ShowMain(true);
                    lblIncorrect.Visible = false;
                    loginSuccess = true;
                }
            }
            if (loginSuccess == false)
                lblIncorrect.Visible = true;
        }

        private void PopulateForums()
        {
            SqlConnection connection = new SqlConnection(@"Server=DESKTOP-E4CK1RC\SQLEXPRESS;Database=MBSforum;Trusted_Connection=True;");
            connection.Open();
            var sql = "SELECT * FROM forums";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var forum = new Forum(reader);
                lstForums.Items.Add(forum);
            }
        }

        private void PopulateTopics(int forumID)
        {
            SqlConnection connection = new SqlConnection(@"Server=DESKTOP-E4CK1RC\SQLEXPRESS;Database=MBSforum;Trusted_Connection=True;");
            connection.Open();
            var sql = "SELECT * FROM topics";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if ((int)reader["ForumID"] == forumID)
                {
                    var topic = new Topic(reader);

                    lstPosts.Items.Clear();
                    lstTopics.Items.Clear();
                    lstTopics.Items.Add(topic);
                }
            }
        }

        private void PopulatePosts(int topicID)
        {
            SqlConnection connection = new SqlConnection(@"Server=DESKTOP-E4CK1RC\SQLEXPRESS;Database=MBSforum;Trusted_Connection=True;");
            connection.Open();
            var sql = "SELECT * FROM posts";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
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
            txtPostAuthor.Enabled = true;

            txtPostAuthor.Visible = true;
            txtPostDesc.Visible = true;
            txtPostTitle.Visible = true;

            bttnPost.Visible = true;
            bttnLike.Visible = false;
        }

        private void FinalizePost(int topicID)
        {
            SqlConnection connection = new SqlConnection(@"Server=DESKTOP-E4CK1RC\SQLEXPRESS;Database=MBSforum;Trusted_Connection=True;");
            connection.Open();

            string postName, postDesc, postAuthor, postDate, postTime;
            int numOfLikes;

            postName = txtPostTitle.Text;
            postDesc = txtPostDesc.Text;
            postAuthor = txtPostAuthor.Text;
            postDesc = postDesc.ReplaceLineEndings();

            postDate = DateTime.Now.ToString("MM/dd/yy");
            postTime = DateTime.Now.ToString("h:mm:ss tt");

            numOfLikes = 0;

            var sql = $"INSERT INTO posts VALUES ({topicID}, '{postName}', '{postDesc}', {numOfLikes}, '{postDate}', '{postTime}', '{postAuthor}')";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
        }

        private void ViewPost(string postAuthor, string postTitle, string postDesc)
        {
            txtPostDesc.Text = postDesc;
            txtPostTitle.Text = postTitle;
            txtPostAuthor.Text = postAuthor;

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
            else
                throw new Exception($"Unexpected Type {lstForums.SelectedItem.GetType().Name}");
        }

        private void lstTopics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTopics.SelectedItem is Topic topic)
            {
                PopulatePosts(topic.ID);
                bttnCreate.Visible = true;
            }
            else
                throw new Exception($"Unexpected Type {lstTopics.SelectedItem.GetType().Name}");
        }

        private void lstPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPosts.SelectedItem is Post post)
                ViewPost(post.PostAuthor, post.PostName, post.PostDescrip);
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
    }
}