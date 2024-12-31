using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class Program
    {

        static void Main(string[] args)
        {
        //            동영상
        //{
        //                메인화면
        //                기본배팅
        //카드분배돼면
        //폴드로지는거보여주고
        //콜로 이기는거 보여주고
        //올인을박고
        //다음배팅때 하프를 눌르면안되는거 보여주고
        //콜박고
        //38광떙으로 이기고 마무리

        //추가로멍터구리구사
        //예외처리 땡잡이 보야주면댐
        //}


//        사이트: https://meta9th.notion.site/9-1354f59458fc80408e99f00618b5b808



//        회의사이트: https://us02web.zoom.us/j/4292165758?pwd=Qk9EdUc4SnNBWUtFNFc0MFplNWUyZz09


//            ctrl + f : https://record5555.tistory.com/11



//            마인드맵 제작 사이트: 깃마인드 https://gitmind.com/kr/


//한게임 섯다 설명: https://gostop.hangame.com/gameGuide/gssudda/guide_gssudda01_03.html


            //            파워포인트
            //            주요한코드, 많이쓰이는메서드, static을 이용할려는마음을 처음부터 가졋으면
            //            마인드랩


            /////기본배팅 => 카드1장분배 => 배팅 => 카드1장분배 => 배팅 => 승판결
            //1.섯다게임설명 족보로 승패결정나고 돈없으면 끝
            //2.카드에 int숫자와 광은bool값으로 덱을 넣고 덱을 피셔예이츠셔플로 섞음
            //3.player,ai 각각의 가지고있을 패를 리스트로 만들었고, 드로우메서드사용하면 덱의마지막부터 추가하고 삭제함
            //4.또한 카드이미지를 만들어 시각화를 하였는데 3차원 배열 사용: [카드번호, 이미지1, 이미지2]
            //            5.player, ai의 betting을 관리할 클래스를 만들어 배팅(기본, 하프.콜, 다이, 올인)관련된걸 넣었고, 베팅 금액 초과 방지 예외처리도 만들어넣음
            //6.다형성족보 반환 , 반환값으로 각각의 점수비교로 이기는걸 string으로 반환, 특수규칙 넣음
            //7.static변수를 사용해 draw를 관리했다
            //8.마지막으로 게임리셋메서드 만들어 리셋하고 다시 돌리게함
            //9.시각화를 위해 타이머메서드를 만듬

            //10.아쉬운부분 , static이용할려는마음을 처음부터가졋으면, 애먹은코드, 많이쓰는코드
            //11.문제점 - static, sidepot, ai배팅난이도




            //player,ai, betting, winnersystem, main, master,deck,card, cardimage

            //── GameMaster
            //│   ├── 초기 설정
            //│   ├── 게임 시작
            //│   ├── 게임 종료
            //│   └── 흐름 제어
            //├── Player
            //│   ├── 초기 자본
            //│   ├── 배팅
            //│   └── 금액 관리
            //├── AI: Player
            //│   ├── 초기 자본
            //│   ├── 배팅 로직
            //│   └── 금액 관리
            //├── Betting System
            //│   ├── 플레이어 배팅
            //│   ├── AI 배팅
            //│   └── 사이드팟 계산
            //└── Card System
            //    ├── 카드 배분
            //    ├── 점수 계산
            //    └── 특수 카드 조합 처리






            //사이드팟, ai배팅
            GameMaster gameMaster = new GameMaster();
            Player myplayer = new Player(100000);
            Ai ai = new Ai(100000);


            gameMaster.first(myplayer, ai);//player,ai의 값을 할당
            gameMaster.fristmainbackground();
            while (true)
            {
                gameMaster.gamestart();

                if (GameMaster.isdraw == false)
                {
                    if (gameMaster.gamefinish() == true)
                    {
                        break;
                    }
                }
            }











        }
    }
}
