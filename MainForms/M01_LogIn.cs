using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

// SQL  Server 접속 클래스 라이브러리
using System.Data.SqlClient;

using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

// 공통 로직 및 변수등을 관리하는 우리가 만든 클래스라이브러리 (API)
using Assamble;

// WinFormApplication 강의의 목표. 
// C# .NetFreamWork WinForm 의 기본 도구 와 프로그래밍 문법을 사용하여 
// 데이터 베이스 와 유기적으로 연결 되는
// 개발 솔루션의 프레임을 만들어 보고 
// 시스템 개발 프레임 코어 소스 의 구성 원리를 이해 및 기능을 습득한다. 



/*---------------------------------------------------------------------------
 * NAME : M01_LogIn
 * DESC : 시스템 로그인.
 * --------------------------------------------------------------------------
 * DATE   : 2022-12-08
 * AUTHOR : 동상현
 * DESC   : 최초 프로그램 작성
 ----------------------------------------------------------------------------*/


namespace MainForms
{
    public partial class M01_LogIn : Form
    {
        public M01_LogIn()
        {
            InitializeComponent();
        }
        #region < 필드 멤버 >
        private int iLoginFCnt = 0; // 비밀번호 오기입 횟수
        private SqlConnection Connect;

        #endregion


        #region < METHOD >
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            DoLogIn();
        }
        private void DoLogIn()
        {
        

            try
            {
                // 데이터 베이스에 접속 할 경로.
                string sConn = "Data Source = (local); Initial Catalog  = AppDev; Integrated Security = SSPI;"; ;

                // 데이터 베이스 접속 클래스를 인서턴스화 한 객체 생성
                Connect = new SqlConnection(sConn);

                // 데이터 베이스 오픈 명령.
                Connect.Open();

                // ID / PW 를 데이터 베이스에서 가자와서 비교 로직. 
                string sUserId   = txtUserId.Text;
                string sPassWord = txtPassWord.Text;

                #region < ID 와 PW 가 동시에 일치 하는지 를 비교하는 경우 >
                //// ID 와 PW 를 정확하게 입력 하였는지 확인.
                //string sFindUserImfo = $"SELECT USERID,PW FROM TB_USER WHERE USERID = '{sUserId}' AND PW = '{sPassWord}';  ";

                //// SqlDataAdapter : 데이터베이스 연결 후 SELECT SQL 구문 전달 및 결과를 
                ////                  응용프로그램에 받아오는 기능 클래스.
                //SqlDataAdapter adapter = new SqlDataAdapter(sFindUserImfo, Connect);

                //// DataTable : 프로그래밍 언어에서 데이터를 테이블 형태로 관리하는 클래스 자료구조.
                //DataTable dtTemp = new DataTable();

                //// 데이터베이스에 sql 구문을 실행하고 조회 된 데이터 를 dtTemp 에 담는다. 
                //adapter.Fill(dtTemp);


                //// ID 와 PW 를 정확히 입력하지 않은 경우. 
                //if (dtTemp.Rows.Count == 0)
                //{
                //    MessageBox.Show("로그인 ID 또는 PW 가 잘못 되었습니다.");
                //    return;
                //}


                // 로그인을 성공하였을 경우 로직.
                #endregion

                #region < ID 의 존재 여부에 따라 PW 의 일치 여부를 비교하는 경우 >
                //string sFindUserImfo = $"SELECT USERNAME,PW FROM TB_USER WHERE USERID = '{sUserId}';";
                //SqlDataAdapter Adapert = new SqlDataAdapter(sFindUserImfo, sConn);

                //DataTable dTemp = new DataTable();
                //Adapert.Fill(dTemp);

                //// ID 를 잘 못 입력 한 경우 받아온 결과의 행 이 없다
                //if (dTemp.Rows.Count == 0)
                //{
                //    MessageBox.Show("존재하지 않는 ID 입니다.");
                //    return;
                //}

                //// 존재하는 ID 를 입력하여 데이터베이스에서 사용자 정보를 받아왔을경우
                //else if (sPassWord != dTemp.Rows[0]["PW"].ToString())
                //{
                //    MessageBox.Show("비밀번호를 잘못 입력하였습니다.");
                //    return;
                //}
                #endregion

                #region < 비밀번호 3회 이상 실패 시 프로그램 종료 >
                //// UPDATE 구문을 사용 하지 않고 프로그램에서만 3회 실패 시 종료 하는 로직. 
                //string sFindUserImfo = $"SELECT USERNAME,PW FROM TB_USER WHERE USERID = '{sUserId}'";

                //SqlDataAdapter Adapter = new SqlDataAdapter(sFindUserImfo, sConn);

                //DataTable dTemp = new DataTable();

                //Adapter.Fill(dTemp);



                //if (dTemp.Rows.Count == 0)
                //{
                //    MessageBox.Show("ID 가 존재 하지 않습니다.");
                //    return;
                //}
                //else if (sPassWord != dTemp.Rows[0]["PW"].ToString())
                //{
                //    iLoginFCnt++;

                //    if (iLoginFCnt == 3)
                //    {
                //        MessageBox.Show("3회 비밀번호 를 잘못입력하여 프로그램을 종료합니다. ㅋㅋㅋ");
                //        this.Close();
                //    }
                //    MessageBox.Show($"비밀번호를 잘못 입력하였습니다. 남은 횟수 : {3 - iLoginFCnt}");
                //    return;
                //}
                // 성공 하였을 경우.
                //iLoginFCnt = 0;
                #endregion

                #region < 비밀번호 실패 횟수를 DB 에 저장하고 프로그램이 종료 된 후 다시 실행 시켜도 로그인이 되지 않도록 설정. > 

                // 로그인 할수 있는 id 와 비밀번호 입력했는지 확인.
                string sSelectSQL = " SELECT USERNAME                     " +
                                    "       ,PW                           " +
                                    "       ,ISNULL(PW_FCNT,0) AS PW_FCNT " +
                                    "   FROM TB_USER                      " +
                                   $"  WHERE USERID = '{sUserId}'           ";

                SqlDataAdapter Adapter = new SqlDataAdapter(sSelectSQL, Connect);
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("ID 가 존재하지 않습니다.");
                    return;
                }
                else if (Convert.ToInt32(dtTemp.Rows[0]["PW_FCNT"]) == 3)
                {
                    MessageBox.Show("비밀번호 3회 오기입. 관리자와 문의하세요.");
                    this.Close();
                    return;
                }
                else if (sPassWord != dtTemp.Rows[0]["PW"].ToString())
                {
                    int iPwFcnt = Convert.ToInt32(dtTemp.Rows[0]["PW_FCNT"]);
                    iPwFcnt++;

                    // 트랜잭션 클래스
                    SqlTransaction Tran = Connect.BeginTransaction();
                    // 갱신 명령어 전달 클래스. 
                    SqlCommand Cmd = new SqlCommand();
                    try
                    {
                        // Command 에 접속 주소 등록. 
                        Cmd.Connection = Connect;
                        // Command 에 트랜잭션 등록.
                        Cmd.Transaction = Tran;
                        // Command 에 명령문 등록.
                        string sUpdateSQL =  "  UPDATE TB_USER                " +
                                            $"     SET PW_FCNT = '{iPwFcnt}'  " +
                                            $"   WHERE USERID  = '{sUserId}'  ";
                        Cmd.CommandText = sUpdateSQL;

                        // CMD 로 UPDATE 문 데이터베이스에 실행.
                        Cmd.ExecuteNonQuery();

                        Tran.Commit();
                    }
                    catch (Exception ex) 
                    {
                        Tran.Rollback();
                        MessageBox.Show(ex.ToString());
                        return;
                    }  
                    if (iPwFcnt == 3)
                    {
                        MessageBox.Show("비밀번호를 3회 틀렸으므로 프로그램을 종료합니다.");
                        this.Close();
                        return;
                    }
                    // ID 는 있는데 비밀번호가 틀린경우. 3
                    MessageBox.Show($"비밀번호 가 맞지 않습니다.  남은 횟수 : {3 - iPwFcnt}");
                    return;
                }

                #endregion
                

                MessageBox.Show(dtTemp.Rows[0]["USERNAME"].ToString() + " 님 반갑습니다.");
                this.Tag = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();
            } 
        }

        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            // 엔터키를 눌렀을 경우 로그인 한다. 
            if (e.KeyCode == Keys.Enter)
                DoLogIn();
        }


        #endregion

        private void btnPWChang_Click(object sender, EventArgs e)
        {
            // 비밀번호 변경 창 호출.
            M02_PasswordChang M02 = new M02_PasswordChang();
            // 로그인 창 숨기기
            this.Visible = false;
            M02.ShowDialog();
            // 로그인 창 표시하기
            this.Visible = true;
        }
    }
}
