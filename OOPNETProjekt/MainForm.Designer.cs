namespace OOPNETProjekt
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsPlayer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddPicture = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddFavourite = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tcRankListsContainer = new System.Windows.Forms.TabControl();
            this.tpGoals = new System.Windows.Forms.TabPage();
            this.dgvGoal = new System.Windows.Forms.DataGridView();
            this.clmImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.clmFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNumGoals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpYellowCards = new System.Windows.Forms.TabPage();
            this.dgvYellowCard = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmYellowCards = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpMatch = new System.Windows.Forms.TabPage();
            this.dgvMatch = new System.Windows.Forms.DataGridView();
            this.clmLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmVisitorCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHomeTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAwayTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpFavouritePlayersContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRepresentations = new System.Windows.Forms.ComboBox();
            this.flpPlayersContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.cmsFavouritePlayer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemoveFavourite = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPlayer.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tcRankListsContainer.SuspendLayout();
            this.tpGoals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoal)).BeginInit();
            this.tpYellowCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYellowCard)).BeginInit();
            this.tpMatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatch)).BeginInit();
            this.cmsFavouritePlayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsPlayer
            // 
            this.cmsPlayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddPicture,
            this.tsmiAddFavourite});
            this.cmsPlayer.Name = "cmsPlayerStats";
            resources.ApplyResources(this.cmsPlayer, "cmsPlayer");
            // 
            // tsmiAddPicture
            // 
            this.tsmiAddPicture.Name = "tsmiAddPicture";
            resources.ApplyResources(this.tsmiAddPicture, "tsmiAddPicture");
            this.tsmiAddPicture.Click += new System.EventHandler(this.tsmiAddPicture_Click);
            // 
            // tsmiAddFavourite
            // 
            this.tsmiAddFavourite.Name = "tsmiAddFavourite";
            resources.ApplyResources(this.tsmiAddFavourite, "tsmiAddFavourite");
            this.tsmiAddFavourite.Click += new System.EventHandler(this.tsmiAddFavourite_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblInfo});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // lblInfo
            // 
            this.lblInfo.Name = "lblInfo";
            resources.ApplyResources(this.lblInfo, "lblInfo");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSettings,
            this.tsmiExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Name = "tsmiSettings";
            resources.ApplyResources(this.tsmiSettings, "tsmiSettings");
            this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            resources.ApplyResources(this.tsmiExit, "tsmiExit");
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tcRankListsContainer
            // 
            resources.ApplyResources(this.tcRankListsContainer, "tcRankListsContainer");
            this.tcRankListsContainer.Controls.Add(this.tpGoals);
            this.tcRankListsContainer.Controls.Add(this.tpYellowCards);
            this.tcRankListsContainer.Controls.Add(this.tpMatch);
            this.tcRankListsContainer.Name = "tcRankListsContainer";
            this.tcRankListsContainer.SelectedIndex = 0;
            // 
            // tpGoals
            // 
            this.tpGoals.Controls.Add(this.dgvGoal);
            resources.ApplyResources(this.tpGoals, "tpGoals");
            this.tpGoals.Name = "tpGoals";
            this.tpGoals.UseVisualStyleBackColor = true;
            // 
            // dgvGoal
            // 
            this.dgvGoal.AllowUserToAddRows = false;
            this.dgvGoal.AllowUserToDeleteRows = false;
            this.dgvGoal.AllowUserToResizeRows = false;
            this.dgvGoal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmImage,
            this.clmFirstName,
            this.clmLastName,
            this.clmNumGoals});
            resources.ApplyResources(this.dgvGoal, "dgvGoal");
            this.dgvGoal.Name = "dgvGoal";
            this.dgvGoal.ReadOnly = true;
            this.dgvGoal.RowHeadersVisible = false;
            this.dgvGoal.RowTemplate.Height = 120;
            this.dgvGoal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // clmImage
            // 
            this.clmImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(this.clmImage, "clmImage");
            this.clmImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.clmImage.Name = "clmImage";
            this.clmImage.ReadOnly = true;
            // 
            // clmFirstName
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clmFirstName.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.clmFirstName, "clmFirstName");
            this.clmFirstName.Name = "clmFirstName";
            this.clmFirstName.ReadOnly = true;
            // 
            // clmLastName
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmLastName.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.clmLastName, "clmLastName");
            this.clmLastName.Name = "clmLastName";
            this.clmLastName.ReadOnly = true;
            // 
            // clmNumGoals
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmNumGoals.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.clmNumGoals, "clmNumGoals");
            this.clmNumGoals.Name = "clmNumGoals";
            this.clmNumGoals.ReadOnly = true;
            // 
            // tpYellowCards
            // 
            this.tpYellowCards.Controls.Add(this.dgvYellowCard);
            resources.ApplyResources(this.tpYellowCards, "tpYellowCards");
            this.tpYellowCards.Name = "tpYellowCards";
            this.tpYellowCards.UseVisualStyleBackColor = true;
            // 
            // dgvYellowCard
            // 
            this.dgvYellowCard.AllowUserToAddRows = false;
            this.dgvYellowCard.AllowUserToDeleteRows = false;
            this.dgvYellowCard.AllowUserToResizeRows = false;
            this.dgvYellowCard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvYellowCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYellowCard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.clmYellowCards});
            resources.ApplyResources(this.dgvYellowCard, "dgvYellowCard");
            this.dgvYellowCard.Name = "dgvYellowCard";
            this.dgvYellowCard.ReadOnly = true;
            this.dgvYellowCard.RowHeadersVisible = false;
            this.dgvYellowCard.RowTemplate.Height = 120;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(this.dataGridViewImageColumn1, "dataGridViewImageColumn1");
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // clmYellowCards
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmYellowCards.DefaultCellStyle = dataGridViewCellStyle6;
            resources.ApplyResources(this.clmYellowCards, "clmYellowCards");
            this.clmYellowCards.Name = "clmYellowCards";
            this.clmYellowCards.ReadOnly = true;
            // 
            // tpMatch
            // 
            this.tpMatch.Controls.Add(this.dgvMatch);
            resources.ApplyResources(this.tpMatch, "tpMatch");
            this.tpMatch.Name = "tpMatch";
            this.tpMatch.UseVisualStyleBackColor = true;
            // 
            // dgvMatch
            // 
            this.dgvMatch.AllowUserToAddRows = false;
            this.dgvMatch.AllowUserToDeleteRows = false;
            this.dgvMatch.AllowUserToResizeRows = false;
            this.dgvMatch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmLocation,
            this.clmVisitorCount,
            this.clmHomeTeam,
            this.clmAwayTeam});
            resources.ApplyResources(this.dgvMatch, "dgvMatch");
            this.dgvMatch.Name = "dgvMatch";
            this.dgvMatch.ReadOnly = true;
            this.dgvMatch.RowHeadersVisible = false;
            this.dgvMatch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // clmLocation
            // 
            resources.ApplyResources(this.clmLocation, "clmLocation");
            this.clmLocation.Name = "clmLocation";
            this.clmLocation.ReadOnly = true;
            // 
            // clmVisitorCount
            // 
            resources.ApplyResources(this.clmVisitorCount, "clmVisitorCount");
            this.clmVisitorCount.Name = "clmVisitorCount";
            this.clmVisitorCount.ReadOnly = true;
            // 
            // clmHomeTeam
            // 
            resources.ApplyResources(this.clmHomeTeam, "clmHomeTeam");
            this.clmHomeTeam.Name = "clmHomeTeam";
            this.clmHomeTeam.ReadOnly = true;
            // 
            // clmAwayTeam
            // 
            resources.ApplyResources(this.clmAwayTeam, "clmAwayTeam");
            this.clmAwayTeam.Name = "clmAwayTeam";
            this.clmAwayTeam.ReadOnly = true;
            // 
            // flpFavouritePlayersContainer
            // 
            this.flpFavouritePlayersContainer.AllowDrop = true;
            resources.ApplyResources(this.flpFavouritePlayersContainer, "flpFavouritePlayersContainer");
            this.flpFavouritePlayersContainer.BackColor = System.Drawing.Color.Transparent;
            this.flpFavouritePlayersContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpFavouritePlayersContainer.Name = "flpFavouritePlayersContainer";
            this.flpFavouritePlayersContainer.DragDrop += new System.Windows.Forms.DragEventHandler(this.PlayersContainer_DragDrop);
            this.flpFavouritePlayersContainer.DragEnter += new System.Windows.Forms.DragEventHandler(this.PlayersContainer_DragEnter);
            this.flpFavouritePlayersContainer.DragLeave += new System.EventHandler(this.PlayersContainer_DragLeave);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbRepresentations
            // 
            this.cbRepresentations.FormattingEnabled = true;
            resources.ApplyResources(this.cbRepresentations, "cbRepresentations");
            this.cbRepresentations.Name = "cbRepresentations";
            this.cbRepresentations.SelectedIndexChanged += new System.EventHandler(this.cbRepresentations_SelectedIndexChanged);
            // 
            // flpPlayersContainer
            // 
            this.flpPlayersContainer.AllowDrop = true;
            resources.ApplyResources(this.flpPlayersContainer, "flpPlayersContainer");
            this.flpPlayersContainer.BackColor = System.Drawing.Color.Transparent;
            this.flpPlayersContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpPlayersContainer.Name = "flpPlayersContainer";
            this.flpPlayersContainer.DragDrop += new System.Windows.Forms.DragEventHandler(this.PlayersContainer_DragDrop);
            this.flpPlayersContainer.DragEnter += new System.Windows.Forms.DragEventHandler(this.PlayersContainer_DragEnter);
            this.flpPlayersContainer.DragLeave += new System.EventHandler(this.PlayersContainer_DragLeave);
            // 
            // cmsFavouritePlayer
            // 
            this.cmsFavouritePlayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPictureToolStripMenuItem,
            this.tsmiRemoveFavourite});
            this.cmsFavouritePlayer.Name = "cmsFavouritePlayer";
            resources.ApplyResources(this.cmsFavouritePlayer, "cmsFavouritePlayer");
            // 
            // addPictureToolStripMenuItem
            // 
            this.addPictureToolStripMenuItem.Name = "addPictureToolStripMenuItem";
            resources.ApplyResources(this.addPictureToolStripMenuItem, "addPictureToolStripMenuItem");
            this.addPictureToolStripMenuItem.Click += new System.EventHandler(this.tsmiAddPicture_Click);
            // 
            // tsmiRemoveFavourite
            // 
            this.tsmiRemoveFavourite.Name = "tsmiRemoveFavourite";
            resources.ApplyResources(this.tsmiRemoveFavourite, "tsmiRemoveFavourite");
            this.tsmiRemoveFavourite.Click += new System.EventHandler(this.tsmiRemoveFavourite_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcRankListsContainer);
            this.Controls.Add(this.flpFavouritePlayersContainer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbRepresentations);
            this.Controls.Add(this.flpPlayersContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.cmsPlayer.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tcRankListsContainer.ResumeLayout(false);
            this.tpGoals.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoal)).EndInit();
            this.tpYellowCards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvYellowCard)).EndInit();
            this.tpMatch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatch)).EndInit();
            this.cmsFavouritePlayer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsPlayer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblInfo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.TabControl tcRankListsContainer;
        private System.Windows.Forms.TabPage tpGoals;
        private System.Windows.Forms.DataGridView dgvGoal;
        private System.Windows.Forms.TabPage tpYellowCards;
        private System.Windows.Forms.DataGridView dgvYellowCard;
        private System.Windows.Forms.TabPage tpMatch;
        private System.Windows.Forms.FlowLayoutPanel flpFavouritePlayersContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbRepresentations;
        private System.Windows.Forms.FlowLayoutPanel flpPlayersContainer;
        private System.Windows.Forms.DataGridView dgvMatch;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddPicture;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddFavourite;
        private System.Windows.Forms.ContextMenuStrip cmsFavouritePlayer;
        private System.Windows.Forms.ToolStripMenuItem addPictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveFavourite;
        private System.Windows.Forms.DataGridViewImageColumn clmImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNumGoals;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmYellowCards;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmVisitorCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHomeTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAwayTeam;
    }
}

