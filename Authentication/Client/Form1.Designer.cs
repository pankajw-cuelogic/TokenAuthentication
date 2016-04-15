namespace Client
{
    partial class Form1
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnValidate = new System.Windows.Forms.Button();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnUerDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(87, 92);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(114, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create Token";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(207, 92);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(110, 23);
            this.btnValidate.TabIndex = 1;
            this.btnValidate.Text = "Validate Token";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(87, 33);
            this.txtToken.Multiline = true;
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(230, 40);
            this.txtToken.TabIndex = 2;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(56, 141);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 17);
            this.lblMessage.TabIndex = 3;
            // 
            // btnUerDetails
            // 
            this.btnUerDetails.Location = new System.Drawing.Point(154, 121);
            this.btnUerDetails.Name = "btnUerDetails";
            this.btnUerDetails.Size = new System.Drawing.Size(110, 23);
            this.btnUerDetails.TabIndex = 4;
            this.btnUerDetails.Text = "Get User Details";
            this.btnUerDetails.UseVisualStyleBackColor = true;
            this.btnUerDetails.Click += new System.EventHandler(this.btnUerDetails_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 188);
            this.Controls.Add(this.btnUerDetails);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.btnCreate);
            this.Name = "Form1";
            this.Text = "Authentication";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnUerDetails;
    }
}

