- 조민상 -

1. 프로젝트 설명
-플랫포머 게임 캐릭터의 움직임을 구현하였습니다.
-움직임은 Run, Jump, Crouch, Slide 로 구분되어 있습니다.

2. 움직임 설명
-Run = 좌, 우 방향으로 움직입니다.
-Jump = 위로 점프하며, 점프 중, 움직임이 제한됩니다.
-Crouch = 몸을 웅크리고, 웅크린 시간에 비례하여 점프 파워가 올라갑니다. 웅크리기 중, 움직임이 제한됩니다.
-Slide = 움직임이 제한되며, 이동 방향으로 빠르게 슬라이딩 합니다.

3. 조작키
-조작키는 키보드 버튼으로 구성되어 있습니다.
-Run = 좌, 우 화살표
-Jump = V / 
-Crouch = C
-Slide = Z

4. 프로젝트 기획 초점
기본적인 플랫포머 캐릭터의 움직임을 구현하고, 캐릭터의 State에 따라 움직임과 애니메이션을 관리하는 FSM을 만들려 했습니다.
전체적인 틀을 어떻게 잡아야할지 감이 오지 않아서, 기능부터 무작정 구현해 보았습니다.
만들다 보니, 캐릭터의 상태에 따라 움직임을 작동시키는게 아닌, 움직임에 조건을 덕지덕지 붙여서 만들게 되었고, 결국 FSM은 만들지 못했습니다;;
