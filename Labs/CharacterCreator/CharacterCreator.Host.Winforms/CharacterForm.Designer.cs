namespace CharacterCreator.Host.Winforms
{
    partial class CharacterForm
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
            this.label1 = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._raceBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this._professionBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._strength = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this._intelligence = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this._agility = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this._constitution = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this._charisma = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this._error = new System.Windows.Forms.ErrorProvider(this.components);
            this._attributesLabel = new System.Windows.Forms.Label();
            this._description = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this._attributesError = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._strength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._intelligence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._agility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._constitution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._charisma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._attributesError)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // _txtName
            // 
            this._txtName.Location = new System.Drawing.Point(107, 12);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(119, 20);
            this._txtName.TabIndex = 1;
            this._txtName.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateName);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Race";
            // 
            // _raceBox
            // 
            this._raceBox.AllowDrop = true;
            this._raceBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._raceBox.FormattingEnabled = true;
            this._raceBox.Items.AddRange(new object[] {
            "Human",
            "Dwarf",
            "Gnome",
            "Night Elf",
            "Orc",
            "Troll",
            "Undead",
            "Tauren",
            "Blood Elf",
            "Draenei",
            "Goblin",
            "Worgen",
            "Pandaren"});
            this._raceBox.Location = new System.Drawing.Point(106, 48);
            this._raceBox.MaxDropDownItems = 14;
            this._raceBox.Name = "_raceBox";
            this._raceBox.Size = new System.Drawing.Size(121, 21);
            this._raceBox.TabIndex = 3;
            this._raceBox.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateRace);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Profession";
            // 
            // _professionBox
            // 
            this._professionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._professionBox.FormattingEnabled = true;
            this._professionBox.Items.AddRange(new object[] {
            "Herbalism",
            "Mining",
            "Skinning",
            "Alchemy",
            "Blacksmithing",
            "Enchanting",
            "Engineering",
            "Inscription",
            "Jewelcrafting",
            "Leatherworking",
            "Tailoring"});
            this._professionBox.Location = new System.Drawing.Point(106, 85);
            this._professionBox.Name = "_professionBox";
            this._professionBox.Size = new System.Drawing.Size(121, 21);
            this._professionBox.TabIndex = 5;
            this._professionBox.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateProfession);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Attributes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Strength";
            // 
            // _strength
            // 
            this._strength.Location = new System.Drawing.Point(106, 149);
            this._strength.Name = "_strength";
            this._strength.Size = new System.Drawing.Size(120, 20);
            this._strength.TabIndex = 8;
            this._strength.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Intelligence";
            // 
            // _intelligence
            // 
            this._intelligence.Location = new System.Drawing.Point(106, 187);
            this._intelligence.Name = "_intelligence";
            this._intelligence.Size = new System.Drawing.Size(120, 20);
            this._intelligence.TabIndex = 10;
            this._intelligence.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Agility";
            // 
            // _agility
            // 
            this._agility.Location = new System.Drawing.Point(106, 224);
            this._agility.Name = "_agility";
            this._agility.Size = new System.Drawing.Size(120, 20);
            this._agility.TabIndex = 12;
            this._agility.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 260);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Constitution";
            // 
            // _constitution
            // 
            this._constitution.Location = new System.Drawing.Point(106, 260);
            this._constitution.Name = "_constitution";
            this._constitution.Size = new System.Drawing.Size(120, 20);
            this._constitution.TabIndex = 14;
            this._constitution.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 295);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Charisma";
            // 
            // _charisma
            // 
            this._charisma.Location = new System.Drawing.Point(106, 295);
            this._charisma.Name = "_charisma";
            this._charisma.Size = new System.Drawing.Size(120, 20);
            this._charisma.TabIndex = 16;
            this._charisma.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(110, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "&Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnCancel);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(17, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "&Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnSave);
            // 
            // _error
            // 
            this._error.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._error.ContainerControl = this;
            this._error.RightToLeft = true;

            // 
            // _attributesLabel
            // 
            this._attributesLabel.AutoSize = true;
            this._attributesLabel.Location = new System.Drawing.Point(51, 133);
            this._attributesLabel.Name = "_attributesLabel";
            this._attributesLabel.Size = new System.Drawing.Size(128, 13);
            this._attributesLabel.TabIndex = 21;
            this._attributesLabel.Text = "You have 300 points total";
            // 
            // _description
            // 
            this._description.CausesValidation = false;
            this._description.Location = new System.Drawing.Point(33, 340);
            this._description.Multiline = true;
            this._description.Name = "_description";
            this._description.Size = new System.Drawing.Size(146, 59);
            this._description.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(53, 324);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Description (optional)";
            // 
            // _attributesError
            // 
            this._attributesError.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._attributesError.ContainerControl = this;
            this._attributesError.RightToLeft = true;
            // 
            // CharacterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 446);
            this.Controls.Add(this._attributesLabel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this._description);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._charisma);
            this.Controls.Add(this.label9);
            this.Controls.Add(this._constitution);
            this.Controls.Add(this.label8);
            this.Controls.Add(this._agility);
            this.Controls.Add(this.label7);
            this.Controls.Add(this._intelligence);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._strength);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._professionBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._raceBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._txtName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(250, 485);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 485);
            this.Name = "CharacterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Character";
            ((System.ComponentModel.ISupportInitialize)(this._strength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._intelligence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._agility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._constitution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._charisma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._attributesError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _professionBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown _strength;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown _intelligence;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown _agility;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown _constitution;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown _charisma;
        private System.Windows.Forms.ComboBox _raceBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ErrorProvider _error;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox _description;
        private System.Windows.Forms.Label _attributesLabel;
        private System.Windows.Forms.ErrorProvider _attributesError;
    }
}