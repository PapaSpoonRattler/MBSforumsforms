namespace MBSforumsforms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstForums = new System.Windows.Forms.ListBox();
            this.lstTopics = new System.Windows.Forms.ListBox();
            this.lstPosts = new System.Windows.Forms.ListBox();
            this.bttnPost = new System.Windows.Forms.Button();
            this.txtPostDesc = new System.Windows.Forms.TextBox();
            this.bttnLike = new System.Windows.Forms.Button();
            this.totalLikes = new System.Windows.Forms.Label();
            this.bttnCreate = new System.Windows.Forms.Button();
            this.txtPostAuthor = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtPostTitle = new System.Windows.Forms.TextBox();
            this.lblPostName = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.bttnLogin = new System.Windows.Forms.Button();
            this.lblIncorrect = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstForums
            // 
            this.lstForums.FormattingEnabled = true;
            this.lstForums.ItemHeight = 15;
            this.lstForums.Location = new System.Drawing.Point(12, 10);
            this.lstForums.Name = "lstForums";
            this.lstForums.Size = new System.Drawing.Size(302, 124);
            this.lstForums.TabIndex = 0;
            this.lstForums.Visible = false;
            this.lstForums.SelectedIndexChanged += new System.EventHandler(this.lstForums_SelectedIndexChanged);
            // 
            // lstTopics
            // 
            this.lstTopics.FormattingEnabled = true;
            this.lstTopics.ItemHeight = 15;
            this.lstTopics.Location = new System.Drawing.Point(12, 140);
            this.lstTopics.Name = "lstTopics";
            this.lstTopics.Size = new System.Drawing.Size(302, 124);
            this.lstTopics.TabIndex = 1;
            this.lstTopics.Visible = false;
            this.lstTopics.SelectedIndexChanged += new System.EventHandler(this.lstTopics_SelectedIndexChanged);
            // 
            // lstPosts
            // 
            this.lstPosts.FormattingEnabled = true;
            this.lstPosts.ItemHeight = 15;
            this.lstPosts.Location = new System.Drawing.Point(12, 270);
            this.lstPosts.Name = "lstPosts";
            this.lstPosts.Size = new System.Drawing.Size(302, 139);
            this.lstPosts.TabIndex = 2;
            this.lstPosts.Visible = false;
            this.lstPosts.SelectedIndexChanged += new System.EventHandler(this.lstPosts_SelectedIndexChanged);
            // 
            // bttnPost
            // 
            this.bttnPost.Location = new System.Drawing.Point(437, 374);
            this.bttnPost.Name = "bttnPost";
            this.bttnPost.Size = new System.Drawing.Size(116, 50);
            this.bttnPost.TabIndex = 3;
            this.bttnPost.Text = "Post";
            this.bttnPost.UseVisualStyleBackColor = true;
            this.bttnPost.Visible = false;
            this.bttnPost.Click += new System.EventHandler(this.bttnPost_Click);
            // 
            // txtPostDesc
            // 
            this.txtPostDesc.Location = new System.Drawing.Point(331, 53);
            this.txtPostDesc.Multiline = true;
            this.txtPostDesc.Name = "txtPostDesc";
            this.txtPostDesc.Size = new System.Drawing.Size(457, 306);
            this.txtPostDesc.TabIndex = 4;
            this.txtPostDesc.Visible = false;
            this.txtPostDesc.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // bttnLike
            // 
            this.bttnLike.Location = new System.Drawing.Point(577, 374);
            this.bttnLike.Name = "bttnLike";
            this.bttnLike.Size = new System.Drawing.Size(116, 50);
            this.bttnLike.TabIndex = 5;
            this.bttnLike.Text = "Like";
            this.bttnLike.UseVisualStyleBackColor = true;
            this.bttnLike.Visible = false;
            // 
            // totalLikes
            // 
            this.totalLikes.AutoSize = true;
            this.totalLikes.Location = new System.Drawing.Point(617, 427);
            this.totalLikes.Name = "totalLikes";
            this.totalLikes.Size = new System.Drawing.Size(57, 15);
            this.totalLikes.TabIndex = 6;
            this.totalLikes.Text = "totalLikes";
            this.totalLikes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.totalLikes.Visible = false;
            // 
            // bttnCreate
            // 
            this.bttnCreate.Location = new System.Drawing.Point(94, 415);
            this.bttnCreate.Name = "bttnCreate";
            this.bttnCreate.Size = new System.Drawing.Size(116, 30);
            this.bttnCreate.TabIndex = 7;
            this.bttnCreate.Text = "Create Post";
            this.bttnCreate.UseVisualStyleBackColor = true;
            this.bttnCreate.Visible = false;
            this.bttnCreate.Click += new System.EventHandler(this.bttnCreate_Click);
            // 
            // txtPostAuthor
            // 
            this.txtPostAuthor.Location = new System.Drawing.Point(331, 20);
            this.txtPostAuthor.Multiline = true;
            this.txtPostAuthor.Name = "txtPostAuthor";
            this.txtPostAuthor.Size = new System.Drawing.Size(136, 27);
            this.txtPostAuthor.TabIndex = 8;
            this.txtPostAuthor.Visible = false;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(331, 2);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(52, 15);
            this.lblAuthor.TabIndex = 9;
            this.lblAuthor.Text = "Author *";
            this.lblAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAuthor.Visible = false;
            // 
            // txtPostTitle
            // 
            this.txtPostTitle.Location = new System.Drawing.Point(473, 20);
            this.txtPostTitle.Multiline = true;
            this.txtPostTitle.Name = "txtPostTitle";
            this.txtPostTitle.Size = new System.Drawing.Size(315, 27);
            this.txtPostTitle.TabIndex = 12;
            this.txtPostTitle.Visible = false;
            // 
            // lblPostName
            // 
            this.lblPostName.AutoSize = true;
            this.lblPostName.Location = new System.Drawing.Point(473, 2);
            this.lblPostName.Name = "lblPostName";
            this.lblPostName.Size = new System.Drawing.Size(63, 15);
            this.lblPostName.TabIndex = 13;
            this.lblPostName.Text = "Post Title *";
            this.lblPostName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPostName.Visible = false;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(238, 188);
            this.txtID.Multiline = true;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(315, 27);
            this.txtID.TabIndex = 14;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(238, 237);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(315, 27);
            this.txtPassword.TabIndex = 15;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(238, 170);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(21, 15);
            this.lblUsername.TabIndex = 16;
            this.lblUsername.Text = "ID:";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(238, 218);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(60, 15);
            this.lblPassword.TabIndex = 17;
            this.lblPassword.Text = "Password:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAppName.Location = new System.Drawing.Point(324, 124);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(149, 32);
            this.lblAppName.TabIndex = 18;
            this.lblAppName.Text = "MBS Forums";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bttnLogin
            // 
            this.bttnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bttnLogin.Location = new System.Drawing.Point(333, 270);
            this.bttnLogin.Name = "bttnLogin";
            this.bttnLogin.Size = new System.Drawing.Size(116, 30);
            this.bttnLogin.TabIndex = 19;
            this.bttnLogin.Text = "Log In";
            this.bttnLogin.UseVisualStyleBackColor = true;
            this.bttnLogin.Click += new System.EventHandler(this.bttnLogin_Click);
            // 
            // lblIncorrect
            // 
            this.lblIncorrect.AutoSize = true;
            this.lblIncorrect.BackColor = System.Drawing.Color.Firebrick;
            this.lblIncorrect.Location = new System.Drawing.Point(318, 303);
            this.lblIncorrect.Name = "lblIncorrect";
            this.lblIncorrect.Size = new System.Drawing.Size(146, 15);
            this.lblIncorrect.TabIndex = 20;
            this.lblIncorrect.Text = "Incorrect UserID/Password";
            this.lblIncorrect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIncorrect.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblIncorrect);
            this.Controls.Add(this.bttnLogin);
            this.Controls.Add(this.lblAppName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblPostName);
            this.Controls.Add(this.txtPostTitle);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.txtPostAuthor);
            this.Controls.Add(this.bttnCreate);
            this.Controls.Add(this.totalLikes);
            this.Controls.Add(this.bttnLike);
            this.Controls.Add(this.txtPostDesc);
            this.Controls.Add(this.bttnPost);
            this.Controls.Add(this.lstPosts);
            this.Controls.Add(this.lstTopics);
            this.Controls.Add(this.lstForums);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lstForums;
        private ListBox lstTopics;
        private ListBox lstPosts;
        private Button bttnPost;
        private TextBox txtPostDesc;
        private Button bttnLike;
        private Label totalLikes;
        private Button bttnCreate;
        private TextBox txtPostAuthor;
        private Label lblAuthor;
        private TextBox txtPostTitle;
        private Label lblPostName;
        private TextBox txtID;
        private TextBox txtPassword;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblAppName;
        private Button bttnLogin;
        private Label lblIncorrect;
    }
}