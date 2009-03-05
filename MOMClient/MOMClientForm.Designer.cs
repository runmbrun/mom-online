namespace MOM
{
    partial class MOMClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabPageAdmin = new System.Windows.Forms.TabPage();
            this.panelTest = new System.Windows.Forms.Panel();
            this.tabPageGame = new System.Windows.Forms.TabPage();
            this.gameControl1 = new MOM.GameControl();
            this.tabPageLobby = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxDecks2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonGameSolitare = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonChat = new System.Windows.Forms.Button();
            this.textBoxChat = new System.Windows.Forms.TextBox();
            this.tabPageLogin = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPageRegisteredUser = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.tabPageNewUser = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.statusStrip1.SuspendLayout();
            this.tabPageAdmin.SuspendLayout();
            this.tabPageGame.SuspendLayout();
            this.tabPageLobby.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPageRegisteredUser.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxResults
            // 
            this.listBoxResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxResults.FormattingEnabled = true;
            this.listBoxResults.Location = new System.Drawing.Point(0, 494);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.Size = new System.Drawing.Size(857, 134);
            this.listBoxResults.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 628);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(857, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // tabPageAdmin
            // 
            this.tabPageAdmin.Controls.Add(this.panelTest);
            this.tabPageAdmin.Location = new System.Drawing.Point(4, 22);
            this.tabPageAdmin.Name = "tabPageAdmin";
            this.tabPageAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdmin.Size = new System.Drawing.Size(849, 450);
            this.tabPageAdmin.TabIndex = 5;
            this.tabPageAdmin.Text = "Admin";
            this.tabPageAdmin.UseVisualStyleBackColor = true;
            // 
            // panelTest
            // 
            this.panelTest.Location = new System.Drawing.Point(56, 42);
            this.panelTest.Name = "panelTest";
            this.panelTest.Size = new System.Drawing.Size(669, 363);
            this.panelTest.TabIndex = 6;
            // 
            // tabPageGame
            // 
            this.tabPageGame.Controls.Add(this.gameControl1);
            this.tabPageGame.Location = new System.Drawing.Point(4, 22);
            this.tabPageGame.Name = "tabPageGame";
            this.tabPageGame.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGame.Size = new System.Drawing.Size(849, 450);
            this.tabPageGame.TabIndex = 4;
            this.tabPageGame.Text = "Game";
            this.tabPageGame.UseVisualStyleBackColor = true;
            // 
            // gameControl1
            // 
            this.gameControl1.Location = new System.Drawing.Point(0, 0);
            this.gameControl1.Name = "gameControl1";
            this.gameControl1.Size = new System.Drawing.Size(640, 400);
            this.gameControl1.TabIndex = 1;
            this.gameControl1.Text = "gameControl1";
            this.gameControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gameControl1_MouseMove);
            this.gameControl1.Click += new System.EventHandler(this.gameControl1_Click);
            this.gameControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gameControl1_MouseClick);
            this.gameControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gameControl1_KeyPress);
            // 
            // tabPageLobby
            // 
            this.tabPageLobby.Controls.Add(this.groupBox1);
            this.tabPageLobby.Controls.Add(this.label5);
            this.tabPageLobby.Controls.Add(this.buttonChat);
            this.tabPageLobby.Controls.Add(this.textBoxChat);
            this.tabPageLobby.Location = new System.Drawing.Point(4, 22);
            this.tabPageLobby.Name = "tabPageLobby";
            this.tabPageLobby.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLobby.Size = new System.Drawing.Size(849, 450);
            this.tabPageLobby.TabIndex = 3;
            this.tabPageLobby.Text = "Lobby";
            this.tabPageLobby.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxDecks2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.buttonGameSolitare);
            this.groupBox1.Location = new System.Drawing.Point(16, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 112);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Play a Solitare Game";
            // 
            // comboBoxDecks2
            // 
            this.comboBoxDecks2.FormattingEnabled = true;
            this.comboBoxDecks2.Location = new System.Drawing.Point(9, 42);
            this.comboBoxDecks2.Name = "comboBoxDecks2";
            this.comboBoxDecks2.Size = new System.Drawing.Size(154, 21);
            this.comboBoxDecks2.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Select Deck to Play:";
            // 
            // buttonGameSolitare
            // 
            this.buttonGameSolitare.Location = new System.Drawing.Point(55, 79);
            this.buttonGameSolitare.Name = "buttonGameSolitare";
            this.buttonGameSolitare.Size = new System.Drawing.Size(68, 27);
            this.buttonGameSolitare.TabIndex = 4;
            this.buttonGameSolitare.Text = "Start";
            this.buttonGameSolitare.UseVisualStyleBackColor = true;
            this.buttonGameSolitare.Click += new System.EventHandler(this.buttonGameSolitare_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 428);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Chat";
            // 
            // buttonChat
            // 
            this.buttonChat.Location = new System.Drawing.Point(585, 422);
            this.buttonChat.Name = "buttonChat";
            this.buttonChat.Size = new System.Drawing.Size(75, 23);
            this.buttonChat.TabIndex = 1;
            this.buttonChat.Text = "Send";
            this.buttonChat.UseVisualStyleBackColor = true;
            this.buttonChat.Click += new System.EventHandler(this.buttonChat_Click);
            // 
            // textBoxChat
            // 
            this.textBoxChat.Location = new System.Drawing.Point(54, 425);
            this.textBoxChat.Name = "textBoxChat";
            this.textBoxChat.Size = new System.Drawing.Size(511, 20);
            this.textBoxChat.TabIndex = 0;
            // 
            // tabPageLogin
            // 
            this.tabPageLogin.Controls.Add(this.tabControl2);
            this.tabPageLogin.Location = new System.Drawing.Point(4, 22);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogin.Size = new System.Drawing.Size(849, 450);
            this.tabPageLogin.TabIndex = 0;
            this.tabPageLogin.Text = "Login";
            this.tabPageLogin.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPageRegisteredUser);
            this.tabControl2.Controls.Add(this.tabPageNewUser);
            this.tabControl2.Location = new System.Drawing.Point(6, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(245, 156);
            this.tabControl2.TabIndex = 3;
            // 
            // tabPageRegisteredUser
            // 
            this.tabPageRegisteredUser.Controls.Add(this.label2);
            this.tabPageRegisteredUser.Controls.Add(this.buttonLogin);
            this.tabPageRegisteredUser.Controls.Add(this.textBoxUser);
            this.tabPageRegisteredUser.Controls.Add(this.label1);
            this.tabPageRegisteredUser.Controls.Add(this.textBoxPassword);
            this.tabPageRegisteredUser.Location = new System.Drawing.Point(4, 22);
            this.tabPageRegisteredUser.Name = "tabPageRegisteredUser";
            this.tabPageRegisteredUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRegisteredUser.Size = new System.Drawing.Size(237, 130);
            this.tabPageRegisteredUser.TabIndex = 0;
            this.tabPageRegisteredUser.Text = "Registered User";
            this.tabPageRegisteredUser.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(57, 84);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(63, 22);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(84, 13);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(100, 20);
            this.textBoxUser.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "User";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(84, 49);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassword.TabIndex = 1;
            // 
            // tabPageNewUser
            // 
            this.tabPageNewUser.Location = new System.Drawing.Point(4, 22);
            this.tabPageNewUser.Name = "tabPageNewUser";
            this.tabPageNewUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNewUser.Size = new System.Drawing.Size(237, 130);
            this.tabPageNewUser.TabIndex = 1;
            this.tabPageNewUser.Text = "New User";
            this.tabPageNewUser.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageLogin);
            this.tabControl1.Controls.Add(this.tabPageLobby);
            this.tabControl1.Controls.Add(this.tabPageGame);
            this.tabControl1.Controls.Add(this.tabPageAdmin);
            this.tabControl1.Location = new System.Drawing.Point(0, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(857, 476);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tabControl1_KeyPress);
            // 
            // MOMClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 650);
            this.Controls.Add(this.listBoxResults);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "MOMClientForm";
            this.Text = "Master of Magic";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPageAdmin.ResumeLayout(false);
            this.tabPageGame.ResumeLayout(false);
            this.tabPageLobby.ResumeLayout(false);
            this.tabPageLobby.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageLogin.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPageRegisteredUser.ResumeLayout(false);
            this.tabPageRegisteredUser.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ListBox listBoxResults;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabPage tabPageAdmin;
        public System.Windows.Forms.Panel panelTest;
        private System.Windows.Forms.TabPage tabPageGame;
        private System.Windows.Forms.TabPage tabPageLobby;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxDecks2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonGameSolitare;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonChat;
        private System.Windows.Forms.TextBox textBoxChat;
        private System.Windows.Forms.TabPage tabPageLogin;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPageRegisteredUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TabPage tabPageNewUser;
        private System.Windows.Forms.TabControl tabControl1;
        private GameControl gameControl1;
    }
}

