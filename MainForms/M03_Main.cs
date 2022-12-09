using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assamble;

namespace MainForms
{
    public partial class M03_Main : Form
    {
        public M03_Main()
        {
            // 로그인 창 실행. 
            M01_LogIn M01 = new M01_LogIn();
            M01.ShowDialog();
            if (Convert.ToBoolean(M01.Tag) == false)
            {
                // 로그인 실패 시 .메인창 종료 

                // 현재 클래스 종료 
                // 객체의 생성자 멤버에서 Close() 실행 시 정상 종료 할 수 없음. 
                //this.Close();

                // 어플리케이션 클래스를 사용하여 프로세스의 강제 종료 처리. 
                // 현시점 에서 어플리케이션 강제 종료. 
                Environment.Exit(0);
            }
            // 폼 에 있는 컨트롤 디자인을 초기화 하여 구성함. 
            InitializeComponent();
        }
    }
}
