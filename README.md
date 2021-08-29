# SabAI_Kiosk
Seoul Hackathon 2021 SabAI Team Kiosk Project

## 팀명 및 팀원
* SabAI(싸바이), 최재훈, 박세문
* 최재훈: 라즈베리파이-타이젠 NUI 앱 코딩, 발표
* 박세문: 클라우드와 인터넷 관련 구현, 기획, 디자인

## 프로젝트 제목
* 코로나 시대 사회적 약자를 위한 정신건강 자가진단 도우미

## 프로젝트 배경 혹은 목적
* 요약: 노인 분들이 본인의 치매 정도를 진단하고, 치매 가능성이 높으면 유관 기관의 도움을 받을 수 있도록 하고, 치매 가능성이 낮으면 치매 예방의 정보를 제공하는 치매 자가진단 키오스크입니다.
* 목적: 본 프로젝트는 치매 진단 초기 phase의 스크리닝 문항을 이용하여 자가 진단을 통해 전문기관의 도움을 빨리 받도록 하는 것이 목적입니다.
* 배경: 얼마전 저희 어머니와 장모님이 치매 초기 소견으로 집안이 모두 큰 충격을 받은바 있습니다. 알아보니 치매로 비롯된 사회적 비용이 엄청난 것을 알수 있었습니다. 모두가 조금만 더 관심을 가지고 치매가 일찍 발현되는 것을 인지하고 적절한 약물 치료를 병행한다면 가족의 아픔과 사회적 비용이 상당수 줄어들 것 같습니다. 노인 분들은 병원에 스스로 잘 안가시는 경향이 있습니다. 노인 분들의 접근이 용이한 주민센터나 공공기관에 설치하여 많은 분들이 자유롭게 사용할 수 있기를 바랍니다.

## 파일 리스트
  * VideoPopup.xaml.cs
  * VideoPopup.xaml
  * Scene3Page.xaml.cs
  * Scene3Page.xaml
  * Scene2Page.xaml.cs
  * Scene2Page.xaml
  * Scene1Page.xaml.cs
  * Scene1Page.xaml
  * Scene1.cs
  * ResultPage.xaml.cs
  * ResultPage.xaml
  * QuestionPage.xaml.cs
  * QuestionPage.xaml
  * Program.cs
  * output_STDKTESTJx1NtvQ1 smartthings device key

## 코드 기여자
  * VideoPopup.xaml.cs 최재훈
  * VideoPopup.xaml 최재훈
  * Scene3Page.xaml.cs 최재훈
  * Scene3Page.xaml 최재훈
  * Scene2Page.xaml.cs 최재훈
  * Scene2Page.xaml 최재훈
  * Scene1Page.xaml.cs 최재훈
  * Scene1Page.xaml 최재훈
  * Scene1.cs 최재훈
  * ResultPage.xaml.cs 최재훈 박세문
  * ResultPage.xaml 최재훈 박세문
  * QuestionPage.xaml.cs 최재훈 박세문
  * QuestionPage.xaml 최재훈 박세문
  * Program.cs 최재훈
  * output_STDKTESTJx1NtvQ1 박세문

## 보드
  * RPI4 : 타이젠앱 구동(자가진단키오스크/멀티미디어 등) / 모션센싱(모션센서) / 결과를 웹서버로 전달, https://github.com/jaydenchoe/SabAI_Kiosk
  * Windows PC : (Smarthings가 동작을 안해서 이 대신) 간단한 웹 서버(node.js)를 구동하여 자가진단 결과 데이터 수신

## 구현사항(가산점)
* Peripheral GPIO로 모션 센싱 구현함. 노인분들의 편의를 위해 처음 페이지에서 모션센싱을 통해서도 두번째 페이지로 갈 수 있도록 구현함

## 프로젝트 관련 스터디 내용 이력과 프로젝트 기획/설계한 이력 (구글 공유 문서)
* https://docs.google.com/document/d/1LDKpRqoPyIhb1ev4btUGKfQts9jO1jCl954wjDeyvW8/edit?usp=sharing
