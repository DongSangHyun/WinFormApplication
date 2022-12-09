namespace MainForms
{
    partial class M01_LogIn
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.btnPWChang = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "사용자 ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "P/W";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(106, 43);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(239, 21);
            this.txtUserId.TabIndex = 2;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(106, 70);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '★';
            this.txtPassWord.Size = new System.Drawing.Size(239, 21);
            this.txtPassWord.TabIndex = 3;
            this.txtPassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassWord_KeyDown);
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(106, 112);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(117, 45);
            this.btnLogIn.TabIndex = 4;
            this.btnLogIn.Text = "로그인";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // btnPWChang
            // 
            this.btnPWChang.Location = new System.Drawing.Point(229, 112);
            this.btnPWChang.Name = "btnPWChang";
            this.btnPWChang.Size = new System.Drawing.Size(117, 45);
            this.btnPWChang.TabIndex = 5;
            this.btnPWChang.Text = "비밀번호 변경";
            this.btnPWChang.UseVisualStyleBackColor = true;
            this.btnPWChang.Click += new System.EventHandler(this.btnPWChang_Click);
            // 
            // M01_LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 187);
            this.Controls.Add(this.btnPWChang);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "M01_LogIn";
            this.Text = "LOG IN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Button btnPWChang;
    }
}

