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
// 스레드(Thread) 를 사용하기 위한 라이브러리 참조. 
using System.Threading;
// Form_List 클래스 라이블러리 참조.
using Form_List;
using System.Reflection;

namespace MainForms
{
    public partial class M03_Main : Form
    {
        // 메인화면 클래스 내부에서 시작 및 종료를 할 수 있도록 하기 위하여
        // 클래스 내부의 필드 멤버로 스레드 객체 그릇 명명;
        private Thread thNowTime;


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

            // 타이머 도구 기능 중지. 
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 문자 의 서식 지정 하여 현재 시간 표시.
            stsNowDateTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
        }

        private void M03_Main_Load(object sender, EventArgs e)
        {
            // 메인 화면 폼이 오픈 되는 시점. 

            /* 신규 스레드 를 통한 시간 체크 
               스레드 (Thread) : 프로세스 내부에서 생성되는 실제 작업의 주체 를 추가 생성 함으로서 
                                 하나의 프로세스(Main) 외에 여러가지 일을 동시에 수행 하는기능. 
                                 메인프로세스 와는 별개로 개별적인 리소스(컴퓨터메모리) 를 가지고 구동 
                                 비동기식 , 병렬식 
            */

            // 스레드를 이용한 현재 시간 표시 기능 구현.
            // 1. 스레드를 실행 할 메서드 를 포함할 클래스 객체.  (ThreadStart)
            ThreadStart ThreadS = new ThreadStart(NowTimeSet);

            // 2. 스레드 클래스 생성 후 실행 메서드 표함되어있는 클래스 첨부
            thNowTime = new Thread(ThreadS);

            // 3. 스레드 를 시작. 
            thNowTime.Start();
        }
        
        private void NowTimeSet()
        {
            // 스레드가 실행 할 메서드.
            // 현재 시각 표현 로직 구현.

            // 무한루프를 통한 현재 시각 표현.
            int iBreakTime = 0;
            while (true)
            {
                // 1초 쉬고
                Thread.Sleep(1 * 1000);
                
                // 시간표현하고
                stsNowDateTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
                
                //// iBreakTime 1증가
                //iBreakTime++;
                //if (iBreakTime == 5)
                //{
                //    break;
                //}
            }
            //MessageBox.Show("5초 가 되어 스레드 로직을 종료합니다.");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // 시스템 종료 버튼 클릭
            // 종료 버튼을 눌러 프로그램을 종료 할때 스레드를 정상완료 하지 않으면 
            // 응용 프로그램이 완벽히 종료 되지 않는다. 
            // Environment.Exit(0);

            // 종료 이벤트를 통해 스레드 등 관련 프로세스 를 리소스에서 
            // 제거 후 안전하게 종료 할 수 있다. 
            Application.Exit();
        }

        private void M03_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 창의 x 버튼 클릭 또는 alt + F4 기능 실행, 종료 버튼 클릭했을때 실행 이벤트.

            // 프로그램 종료 여부를 확인 하거나 
            // 실행되고있는 스레드를 안전하게 삭제 후 종료 할 수 있다. 


            // 1. 프로그램 종료 확인 메세지. 
            if (MessageBox.Show("프로그램을 종료 하시겠습니까?", "프로그램 종료", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel= true;
            }

            // 2. 구동되고있는 스레드가 있다면 종료. 
            // ******* Abort (프로세스의 종료 를 구현할수 있는 대표적인 키워드)
            // Dispose()
            if (thNowTime.IsAlive) thNowTime.Abort();
        }

        private void M_TEST_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // 매뉴 리스트의 아이템(매뉴) 를 클릭 하였을때 이벤트.

            // 1. CS 파일을 직접 호출
            //Form01_MDITest Form01 = new Form01_MDITest();
            //Form01.Show();


            // MDI 로 하위 화면(자식 창) 을 상위 폼(부모 창) 안에서 활성화 시키기.
            // MDI : Multiple Document Interface 의 약자로 
            //       한개의 창에서 여러가지 작업을 할 수 있는 인터페이스를 뜻한다. 

            // 2. MDI 를 이용하여 화면 호출. 
            //Form01_MDITest Form01 = new Form01_MDITest();
            //// MDI 부모 창 Form 과 연결.
            //Form01.MdiParent= this;
            //Form01.Show();


            // 3. 어셈블리(=클래스 라이브러리, namespce, 프로젝트, DLL파일)
            // Form_List 프로젝트 를 호출(DLL)
            // Application.StartupPath : 메인 프로그램이 시작되는 파일의 위치.
            Assembly assembly = Assembly.LoadFrom($"{Application.StartupPath}\\Form_List.DLL");
            // 클린한 매뉴의 CS 파일 타입 확인.
            Type typeform = assembly.GetType($"Form_List.{e.ClickedItem.Name}", true);
            // Form 형식으로 전환
            Form FormMdi = (Form)Activator.CreateInstance(typeform);
            // 종속관계 연결
            FormMdi.MdiParent = this;
            // 화면 오픈. 
            FormMdi.Show(); 
        }

        //private void Form01_MDITest_Click(object sender, EventArgs e)
        //{
        //    Form01_MDITest Form01 = new Form01_MDITest();
        //    // MDI 부모 창 Form 과 연결.
        //    Form01.MdiParent = this;
        //    Form01.Show();
        //}

        //private void mDITest2ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Form02_MDITest Form02 = new Form02_MDITest();
        //    Form02.MdiParent = this;
        //    Form02.Show();
        //}
    }
}
