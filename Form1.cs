using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace StoreManager
{
    public partial class Form1 : Form
    {

        public string _platformName = "Windows";
        public string _deviceName = "WindowsPC";
        public string _app_id = "";

        WindowsDriver<WindowsElement> _deskTopSessoin;
        CUtility _myUtility;
        public KeyList _keyList;


        MStoreManager _storeManager;
        public Form1()
        {
            InitializeComponent();
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void TxtTester_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void getTarget_Attributes(WindowsElement target)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Parsing Elements"));
            target.Click();
        }
        private void button2_Click(object sender, EventArgs e)
        {



            try
            {
                OpenQA.Selenium.Appium.AppiumOptions ao = new AppiumOptions();
                ao.AddAdditionalCapability("app", "Root");
                ao.AddAdditionalCapability("platformName", _platformName);
                ao.AddAdditionalCapability("deviceName", _deviceName);

                //Default Time out is 1 minutes
                _deskTopSessoin = new WindowsDriver<WindowsElement>(new Uri(@"http://127.0.0.1:4723"), ao, TimeSpan.FromMinutes(2));

                //  element = _deskTopSessoin.FindElementByAccessibilityId(assertion_name/*"ad"*/);
                //AppiumWebElement alarm_button = _deskTopSessoin.FindElement(By.Name("알림 센터"));   //이방법도 OK
                /*WindowsElement*/

                //tile-P~Microsoft.WindowsStore_8wekyb3d8bbwe!App
                //Below Code is test Okay
                AppiumWebElement start_button = _deskTopSessoin.FindElement(By.Name("시작"));
                Thread.Sleep(2000);

                if (start_button != null)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Find StartBtn"));
                    start_button.Click();
                }

                Thread.Sleep(3000);
                AppiumWebElement store_button = _deskTopSessoin.FindElementByAccessibilityId("tile-P~Microsoft.WindowsStore_8wekyb3d8bbwe!App");

                Thread.Sleep(2000);
                if (store_button != null)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Find Store Btn"));
                    store_button.Click();
                }

                //여기까지 문제 없었으면 Store창이 정상적으로 display되어졌을 것이다.
                Thread.Sleep(7000);
                AppiumWebElement gaming_button = _deskTopSessoin.FindElementByAccessibilityId("gaming");
                if (gaming_button != null)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Find gaming Btn"));
                    gaming_button.Click();
                }

                Thread.Sleep(2000);
                AppiumWebElement freegame_list = _deskTopSessoin.FindElement(By.Name("모두 표시 99/+  무료 인기 게임"));
                freegame_list.Click();


                Thread.Sleep(5000);
                var gameElement = _deskTopSessoin.FindElementsByClassName("GridViewItem");
                var currList = gameElement.ToList();
                System.Diagnostics.Debug.WriteLine(string.Format("[Setting MenuList]List Count:{0}", currList.Count));

                foreach (var currItem in currList)
                {

                    System.Diagnostics.Debug.WriteLine(string.Format("element name:{0}", currItem.GetAttribute("Name")));
                    //this.getTarget_Attributes(currItem);

                    currItem.Click();

                    //get 1 depth목록
                    Thread.Sleep(3000);

                    //var elements = _deskTopSessoin.FindElementsByXPath("//Button[@Name=\"NavigationControl\"]/child::*");
                    //var elements = _deskTopSessoin.FindElementsByXPath("//Group[@AutomationId==\"pdp\"]/child::*");
                    var elements = _deskTopSessoin.FindElementByAccessibilityId("pdp").FindElementsByXPath("//*");
                    foreach (var currChild in elements)
                    {
                        System.Diagnostics.Debug.WriteLine(string.Format("child name:{0}", currChild.GetAttribute("Name")));
                    }
                        break;

                }




                /*출력 결과
                 * child name:
                        child name:
                        child name:
                        child name:ROBLOX
                        child name:게시자
                        child name:‪ROBLOX Corporation‬
                        child name:범주
                        child name:액션 및 어드벤처의 자세한 결과 보기
                        child name:,
                        child name:가족 및 어린이의 자세한 결과 보기
                        child name:23개 평가이(가) 있는 경우 평점: 별 5개 중 3.4개
                        child name:공유
                        child name:공식 클럽
                        child name:* 기간 한정 이벤트(4월 7일~28일): 에그 헌트 이벤트가 새로운 보상과 함께 돌아왔어요! 40개가 넘는 시크릿 에그가 Roblox 유니버스에서 사라졌답니다. 이 모든 에그들을 되찾는 건 E.G.G. 에이전트인 여러분에게 달려 있죠. 동료 요원들과 협력해 시크릿 미션을 수행하고 특별 아이템을 잠금 해제하세요! * 무한히 다양한 궁극의 가상 세계 Roblox. 이곳에서 게임을 플레이하고, 제작하며, 상상하던 모든 걸 이루어 보세요. 수백만의 플레이어와 함께 어울리며, 글로벌 커뮤니티의 멤버들이 손수 만든 몰입형 세상을 탐험해 보세요. 이미 Roblox에 가입하셨나요? 내 계정에 로그인하고 지금 바로 플레이하세요! 수백만 개의 세상을 체험하세요 여러분은 어떤 게임을 좋아하나요? 장대한 스토리가 있는 롤플레잉 어드벤처 게임? 세상의 모든 라이벌과 맞서 싸우는 게임? 아니면 그저 친구들과 여유로이 어울리며 이야기할 수 있는 게임? Roblox의 커뮤니티가 직접 만들어 가는 이 세상의 라이브러리는 지금 이 시간에도 점점 커지고 있답니다. 새롭고도 흥미진진한 게임이 매일매일 올라오니까요. 언제 어디서나 함께 플레이하세요 Roblox는 다양한 플랫폼을 지원합니다. 컴퓨터나 휴대폰, Xbox One, VR 헤드셋 등 다양한 기기에서 수백만의 친구들과 함께 플레이하세요. 상상하던 모든 걸 이루세요 창의력을 한껏 발휘해 나만의 독특한 스타일을 완성하세요. 무진장 다양한 디자인의 모자, 셔츠, 얼굴, 장비 등으로 아바타를 멋지게 꾸미세요. Xbox One 버전 Roblox에서만 이용 가능한 특별 아바타 의상도 준비되어 있답니다. 친구들과 이야기하세요 Xbox Live 내장 음성 채팅이나 파티 채팅 기능을 이용해 온라인에서 친구들과 소통하세요. Xbox Live Gold 가입이 필요합니다. 나만의 세상 만들기: https://www.roblox.com/develop 도움말: https://en.help.roblox.com/hc/en-us 문의하기: https://corp.roblox.com/contact/ 개인정보 처리방침: https://www.roblox.com/info/privacy 보호자 가이드: https://corp.roblox.com/parents/ 참고: 게임을 하려면 Xbox Live Gold와 192Kbps 이상의 인터넷 연결이 필요합니다. Roblox 게임 등급은 Roblox 앱에만 해당되며, 앱 내에서 사용자가 생성한 콘텐츠는 포함하지 않습니다. 사용자가 생성한 콘텐츠는 등급이 매겨지지 않습니다.
                        child name:전체 설명 표시
                        child name:등급 위원회 GRB, 전체 이용가. 등급: 전체 이용가.
                        child name:확률형 아이템
                        child name:사용자 상호 작용
                        child name:In-Game Purchases
                        child name:
                        child name:
                        child name:무료
                        child name:앱에서 바로 구매 기능 제공
                        child name:무료
                        child name:카트에 추가
                        child name:위시 리스트
                        child name:+ 앱에서 바로 구매 제공
                        child name:+ 앱에서 바로 구매 제공
                        child name:
                        child name:
                        child name:개요
                        child name:시스템 요구 사항
                        child name:리뷰
                        child name:관련 계정
                        child name:개요
                        child name:
                        child name:지원 플랫폼
                        child name:PC에서 사용 가능한 제품
                        child name:설명
                        child name:
                        child name:* 기간 한정 이벤트(4월 7일~28일): 에그 헌트 이벤트가 새로운 보상과 함께 돌아왔어요! 40개가 넘는 시크릿 에그가 Roblox 유니버스에서 사라졌답니다. 이 모든 에그들을 되찾는 건 E.G.G. 에이전트인 여러분에게 달려 있죠. 동료 요원들과 협력해 시크릿 미션을 수행하고 특별 아이템을 잠금 해제하세요! * 무한히 다양한 궁극의 가상 세계 Roblox. 이곳에서 게임을 플레이하고, 제작하며, 상상하던 모든 걸 이루어 보세요. 수백만의 플레이어와 함께 어울리며, 글로벌 커뮤니티의 멤버들이 손수 만든 몰입형 세상을 탐험해 보세요. 이미 Roblox에 가입하셨나요? 내 계정에 로그인하고 지금 바로 플레이하세요! 수백만 개의 세상을 체험하세요 여러분은 어떤 게임을 좋아하나요? 장대한 스토리가 있는 롤플레잉 어드벤처 게임? 세상의 모든 라이벌과 맞서 싸우는 게임? 아니면 그저 친구들과 여유로이 어울리며 이야기할 수 있는 게임? Roblox의 커뮤니티가 직접 만들어 가는 이 세상의 라이브러리는 지금 이 시간에도 점점 커지고 있답니다. 새롭고도 흥미진진한 게임이 매일매일 올라오니까요. 언제 어디서나 함께 플레이하세요 Roblox는 다양한 플랫폼을 지원합니다. 컴퓨터나 휴대폰, Xbox One, VR 헤드셋 등 다양한 기기에서 수백만의 친구들과 함께 플레이하세요. 상상하던 모든 걸 이루세요 창의력을 한껏 발휘해 나만의 독특한 스타일을 완성하세요. 무진장 다양한 디자인의 모자, 셔츠, 얼굴, 장비 등으로 아바타를 멋지게 꾸미세요. Xbox One 버전 Roblox에서만 이용 가능한 특별 아바타 의상도 준비되어 있답니다. 친구들과 이야기하세요 Xbox Live 내장 음성 채팅이나 파티 채팅 기능을 이용해 온라인에서 친구들과 소통하세요. Xbox Live Gold 가입이 필요합니다. 나만의 세상 만들기: https://www.roblox.com/develop 도움말: https://en.help.roblox.com/hc/en-us 문의하기: https://corp.roblox.com/contact/ 개인정보 처리방침: https://www.roblox.com/info/privacy 보호자 가이드: https://corp.roblox.com/parents/ 참고: 게임을 하려면 Xbox Live Gold와 192Kbps 이상의 인터넷 연결이 필요합니다. Roblox 게임 등급은 Roblox 앱에만 해당되며, 앱 내에서 사용자가 생성한 콘텐츠는 포함하지 않습니다. 사용자가 생성한 콘텐츠는 등급이 매겨지지 않습니다.
                        child name:자세히 표시
                        child name:스크린샷
                        child name:스크린샷 1 확대
                        child name:스크린샷 2 확대
                        child name:스크린샷 3 확대
                        child name:스크린샷 4 확대
                        child name:스크린샷 5 확대
                        child name:피플 추천
                        child name:모두 보기 피플 추천
                        child name:피플 추천
                        child name:American Block Sniper Survival 1 / 10 무료
                        child name:American Block Sniper Survival
                        child name:₩28,425 절약 Hello Neighbor 2 / 10 원래 가격: ₩37,900 현재 ₩9,475
                        child name:Hello Neighbor
                        child name:Cops Vs Robbers: Jail Break 3 / 10 평점: 별 5개 중 5개 There are 1 reviews 무료
                        child name:Cops Vs Robbers: Jail Break
                        child name:Block Wars Survival Games 4 / 10 무료
                        child name:Block Wars Survival Games
                        child name:Cops Vs Robbers Prison Escape 5 / 10 무료
                        child name:Cops Vs Robbers Prison Escape
                        child name:Zombs Royale Game 6 / 10 무료
                        child name:Zombs Royale Game
                        child name:₩8,925 절약 Goat Simulator Windows 10 7 / 10 원래 가격: ₩11,900 현재 ₩2,975 앱에서 바로 구매 기능 제공
                        child name:Goat Simulator Windows 10
                        child name:앱에서 바로 구매 기능 제공
                        child name:Human Fall Flat 8 / 10 평점: 별 5개 중 3개 There are 3 reviews ₩18,900
                        child name:Human Fall Flat
                        child name:
                        child name:Granny Emergency Stretcher 9 / 10 평점: 별 5개 중 5개 There are 1 reviews 무료
                        child name:Granny Emergency Stretcher
                        child name:Toon Cup: 2018 10 / 10 평점: 별 5개 중 4.5개 There are 9 reviews 무료
                        child name:Toon Cup: 2018
                        child name:모두 보기 피플 추천
                        child name:새 소식 및 기능
                        child name:이 버전의 새로운 기능
                        child name:Roblox에서는 보다 수준 높은 플레이 환경을 조성하기 위해 정기적으로 업데이트를 수행합니다. 여기에는 버그 수정 및 속도와 안정성 개선이 포함됩니다.
                        child name:기능
                        child name:
                        child name:수백만 개의 세상을 체험하세요
                        child name:언제 어디서나 함께 플레이하세요
                        child name:상상하던 모든 걸 이루세요
                        child name:친구들과 이야기하세요
                        child name:추가 정보
                        child name:추가 정보
                        child name:
                        child name:게시자
                        child name:ROBLOX Corporation
                        child name:
                        child name:저작권
                        child name:ROBLOX Corporation, ©2019
                        child name:
                        child name:출시일
                        child name:2016-01-21
                        child name:
                        child name:대략적인 크기
                        child name:171.65MB
                        child name:
                        child name:연령별 등급
                        child name:전체 이용가
                        child name:
                        child name:범주
                        child name:액션 및 어드벤처
                        child name:
                        child name:이 앱에는 다음과 같은 기능에 대한 권한이 있습니다.
                        child name:인터넷 연결에 액세스
                        child name:홈 또는 회사 네트워크에 액세스
                        child name:자세히
                        child name:사용 권한 정보
                        child name:설치
                        child name:Microsoft 계정에 로그인한 상태에서 이 앱을 다운로드한 후 최대 10대의 Windows 10 디바이스에 설치할 수 있습니다.
                        child name:이 제품은 내부 하드 드라이브에 설치해야 합니다.
                        child name:
                        child name:지원되는 언어
                        child name:English (United States)
                        child name:
                        child name:판매자 정보
                        child name:ROBLOX 웹 사이트
                        child name:ROBLOX 지원
                        child name:
                        child name:서비스 계약 추가 내용
                        child name:ROBLOX 개인 정보 취급 방침
                        child name:거래 계약
                        child name:이 제품 보고
                        child name:
                        child name:Microsoft에 이 게임 신고
                 * 




















                //Xpath Code는 정상동작하지 않음...
                //UI Recorder에서 찾아낸 xpath를 C#코드로 변환시킨 것
                ////Console.WriteLine("LeftClick on \"모두 표시 99/+  무료 인기 게임\" at (61,9)");
                //string xp2 = "/Pane[@Name=\"데스크톱 1\"][@ClassName=\"#32769\"]/Window[@Name=\"Microsoft Store\"][@ClassName=\"ApplicationFrameWindow\"]/Window[@Name=\"Microsoft Store\"][@ClassName=\"Windows.UI.Core.CoreWindow\"]/Custom[@AutomationId=\"NavigationChrome\"]/Button[@AutomationId=\"NavigationControl\"]/Pane[@AutomationId=\"_scrollViewer\"]/Custom[@AutomationId=\"topfreegames\"]/Hyperlink[@AutomationId=\"SectionViewAllButton\"][@Name=\"모두 표시 99/+  무료 인기 게임\"]";
                //var winElem2 = MyDesktopSession.FindElementByXPath(xp2);
                //if (winElem2 != null)
                //{
                //    winElem2.Click();
                //}




                //AppiumWebElement searchBtn = _deskTopSessoin.FindElementByClassName("Button");
                //Thread.Sleep(3000);
                //if (/*alarm_button*/
                searchBtn != null)
                //{
                //    System.Diagnostics.Debug.WriteLine(string.Format("Find SearchBtn"));
                //    _deskTopSessoin.Mouse.Click(searchBtn.Coordinates);
                //    //_deskTopSessoin.Mouse.MouseDown(searchBtn.Coordinates);
                //    //_deskTopSessoin.Mouse.MouseDown(searchBtn.Coordinates);
                //    //session.Mouse.MouseMove(appNameTitle.Coordinates);
                //    // _deskTopSessoin.Mouse.ContextClick(currElement.Coordinates);
                //    // searchBtn.Click();

                //}

                //AppiumWebElement searchBox =  _deskTopSessoin.FindElementByAccessibilityId("SearchTextBox");

                // if (searchBox != null)
                // {
                //     //alarm_button.Click();
                //     System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: Find SearchBox"));
                //     searchBox.SendKeys("store");
                // }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
            }
            finally
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _storeManager = MStoreManager.Instance;
            _myUtility = CUtility.Instance;
            _keyList = KeyList.Instance;

            // _settingManager.connectUI(this);
            this.composeCategory_combo();
            string categoryName = this.cboCategory.SelectedItem.ToString();
            this.composeSubclass_combo(categoryName);
        }

        public void composeCategory_combo()
        {
            //cboCategory.Items.Add(currObj.ToString());
            cboCategory.Items.Add("게임");
            cboCategory.Items.Add("엔터테인먼트");
            cboCategory.Items.Add("생산성");
            cboCategory.SelectedIndex = 0;
        }

        public void composeSubclass_combo(string name)
        {
            //Category Combo값에 따라 combo-box구성이 틀려진다.
            switch (name)
            {
                case "게임":
                    {
                        cboSubclass.Items.Add("무료인기게임");
                        cboSubclass.Items.Add("유료인기게임");
                        cboSubclass.SelectedIndex = 0;
                        break;
                    }
                case "엔터테인먼트":
                    {

                        break;
                    }
                case "생산성":
                    {
                        break;
                    }
                default:
                    break;
            }

        }
        public void HeyConnect()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Hey Connect"));
        }

        private void BtnStoreSession_Click(object sender, EventArgs e)
        {

        }

        private void CmdRun_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> sendInfo = new Dictionary<string, string>();

            string categoryName = this.cboCategory.SelectedItem.ToString();
            string subclassName = this.cboSubclass.SelectedItem.ToString();

            string workerMode = EnumSet.ActionMode.STORE_AUTOMATION_TEST.ToString();
            //string platformName = "Windows";
            //string deviceName = "WindowsPC";
            //k_store_category = "k_store_category";   //store대분류 (게임,엔터테인먼트,생산성,특가)
            //k_store_subclass = "k_store_subclass";

            sendInfo.Add(_keyList.k_worker_mode, workerMode);
            sendInfo.Add(_keyList.k_store_category, categoryName);
            sendInfo.Add(_keyList.k_store_subclass, subclassName);
          
            _storeManager.worker.RunWorkerAsync(sendInfo);
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void CboSubclass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void TxtStartDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtEndDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void CboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.composeSubclass_combo
            string categoryName = "";
            categoryName = this.cboCategory.SelectedItem.ToString();

        }
    }
}