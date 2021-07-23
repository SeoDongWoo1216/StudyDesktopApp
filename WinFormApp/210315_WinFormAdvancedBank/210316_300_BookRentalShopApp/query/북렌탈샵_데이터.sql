-- 회원테이블
INSERT INTO membertbl VALUES 
('이동걸', 'A', '부산시 사하구', '010-2967-1016', 'ldw@naver.com'), 
('방혁용', 'B', '부산시 남구', '010-9291-4419', 'byh@daum.com'),
('동황주', 'B', '부산시 북구', '010-8956-7423', 'hdj@gmail.com'),
('김영효', 'D', '부산시 영도구', '010-8736-2919', 'khy@hotmail.com'),
('현수박', 'A', '부산시 강서구', '010-9295-6600', 'phs@yahoo.co.kr'),
('우동서', 'C', '부산시 동래구', '010-5341-0128', 'sdw@naver.com'),
('김은서', 'A', '부산시 중구', '010-2244-0675', 'kde@empal.com'),
('박은성', 'D', '부산시 수영구', '010-6318-2590', 'kms@hotmail.com'),
('김환영', 'A', '부산시 강서구', '010-5615-1344', 'kyh@nate.com'),
('최영원', 'C', '김해시 삼안동', '010-9291-0882', 'cwy@dreamwiz.com'),
('전한대', 'D', '부산시 남구', '010-8956-6008', 'jdh@korea.com'),
('이준호', 'B', '부산시 부산진구', '010-9295-5718', 'ljh@gmail.com'),
('이창수', 'D', '부산시 동구', '010-9341-0128', 'lcs@naver.com'),
('이하응', 'A', '부산시 사상구', '010-5436-0675', 'lhe@hotmail.com'),
('장국빈', 'C', '부산시 남구', '010-6318-4654', 'jgb@freechal.com'),
('김종훈', 'A', '부산시 남구', '010-5615-7437', 'kjh@nate.com'),
('김한진', 'B', '부산시 수영구', '010-6566-4419', 'khj@daum.com'),
('박지윤', 'C', '부산시 사상구', '010-8956-1508', 'pjy@gmail.com'),
('김효정', 'B', '부산시 연제구', '010-5667-2919', 'kimhj@hotmail.com'),
('박효민', 'A', '부산시 해운대구', '010-9295-0341', 'phm@yahoo.com'),
('정재민', 'A', '부산시 사하구', '010-5341-4736', 'jjm@naver.com'),
('정성권', 'A', '부산시 금정구', '010-2244-5121', 'jsg@empal.com'),
('유혜진', 'B', '부산시 수영구', '010-6318-3734', 'yhj@hotmail.com');

INSERT INTO membertbl VALUES 
('성명건', 'D', '부산시 해운대구', '010-7625-0677', 'smg@naver.com');

-- 책 구분
INSERT INTO divtbl VALUES ('B001', '공포/스릴러'), ('B002', '로맨스'), ('B003', '무협'), ('B004', '전쟁/역사'),
('B005', '추리'), ('B006', 'SF/판타지');

-- 책정보
INSERT INTO bookstbl VALUES
('넬레 노이하우스', 'B001', '잔혹한 어머니의 날 1', '2019-10-07', '9791158791179', 11520),
('넬레 노이하우스', 'B001', '잔혹한 어머니의 날 2', '2019-10-07', '9791158791186', 11520),
('매뉴 라인하트', 'B006', '월드 오브 워크래프트 팝업북', '2019-10-21', '9788959527779', 52200),
('묵향동후', 'B003', '마도조사 2', '2019-09-03', '9791127852122', 12600),
('오코제키 다이', 'B005', '루팡의 딸', '2019-09-25', '9788998274412', 13500),
('조엘 디케르', 'B001', '스테파니 메일러 실종사건', '2019-08-12', '9788984373761', 16200),
('이지환', 'B002', '닥터 퀸 1-2세트', '2019-09-20', '9791164664122', 27000),
('김수지', 'B002', '희란국 연가', '2019-11-01', '9791131594100', 14000),
('알파타르트', 'B002', '재혼 황후 1', '2019-10-18', '9791164790289', 14000),
('안나 토드', 'B002', '애프터 7', '2019-08-30', '9791188253166', 14000),
('안타 토드', 'B002', '애프터 8', '2019-08-30', '9791188253173', 14000),
('남혜인', 'B002', '아도니스 11', '2019-08-26', '9791163022237', 11800),
('안드레아스 빙겔만', 'B001', '쉐어하우스', '2019-09-27', '9791186809792', 13320),
('비프케 로렌츠', 'B001', '너도 곧 쉬게 될 거야', '2019-09-18', '9791162834930', 12600),
('전건우', 'B001', '어위크', '2019-09-02', '9791188660353', 12600),
('토머스 해리스', 'B005', '카리 모라', '2019-09-11', '9791158511470', 15000),
('토머스 해리스', 'B005', '한니발', '2019-09-11', '9791158511500', 15000),
('정준', 'B003', '화산전생 17', '2019-08-23', '9791128394683', 8000),
('묵향동후', 'B003', '마도조사 1', '2019-07-30', '9791127851446', 14000),
('용대운', 'B003', '군림천사 35', '2019-07-26', '9788926706763', 9000),
('정준', 'B003', '화산전생 15', '2019-04-30', '9791128394669', 8000),
('김석진', 'B003', '삼류무사 2부16', '2019-04-02', '9791135413698', 8000),
('히가시노 게이고', 'B006', '기도의 막이 내릴 때', '2019-08-06', '9788990982780', 16800),
('히가시노 게이고', 'B006', '악의', '2019-07-25', '9788972750031', 14000),
('서철원', 'B004', '최후의 만찬', '2019-09-25', '9791130625843', 15000),
('마이 셰발, 페르 발뢰', 'B004', '어느 끔찍한 남자', '2019-09-20', '9788954657648', 12800),
('마이 셰발, 페르 발뢰', 'B004', '폴리스, 폴리스, 포타티스모스!', '2019-09-20', '9788954656535', 13800),
('김진명', 'B004', '살수 1', '2019-09-16', '9788925567716', 14800),
('김진명', 'B004', '살수 2', '2019-09-16', '9788925567723', 14800),
('손정미', 'B004', '도공 서란', '2019-09-16', '9788965708575', 14000),
('요안나', 'B002', '순수하지 않은 감각', '2019-10-02', '9791135445705', 12500),
('노승아', 'B002', '오늘부터 천생연분 1', '2019-09-18', '9791130039480', 12800),
('노승아', 'B002', '오늘부터 선생연분 2', '2019-09-18', '9791130039497', 12800),
('김이랑', 'B002', '조선혼담공작소 꽃파당', '2019-09-06', '9791159099724', 138000),
('전민석', 'B004', '감치', '2019-08-15', '9788947545075', 15000),
('나관중', 'B004', '삼국지 세크', '2019-07-25', '9788936479497', 60000),
('에리크 뷔야르', 'B004', '그날의 비밀', '2019-07-20', '9788932919751', 12800),
('요 네스뵈', 'B004', '폴리스', '2019-07-08', '9788934996699', 16000),
('T. M. 로건', 'B005', '29초', '2019-09-18', '9788950983208', 15000),
('토머스 해리스', 'B005', '양들의 침묵', '2019-09-11', '9791158511494', 15000),
('송시우', 'B005', '대나무가 우는 섬', '2019-09-06', '9788952739087', 14000),
('A. J. 핀', 'B005', '우먼 인 윈도', '2019-09-03', '9788934998952', 15800),
('이정명', 'B005', '밤의 양들 1', '2019-08-30', '9791189982461', 11500),
('이정명', 'B005', '밤의 양들 2', '2019-08-30', '9791189982478', 11500),
('정해연', 'B005', '내가 죽였다', '2019-08-21', '9791160748604', 14000),
('정준', 'B003', '화산전생 16', '2019-07-19', '9791128394676', 8000),
('무공진', 'B003', '화중매 상하 세트', '2019-07-15', '9791162764428', 32000),
('촌부', 'B003', '천애협로 10', '2019-06-03', '9791104920066', 8000),
('손선영', 'B003', '소암, 바람의 노래', '2019-05-17', '9791187440475', 13800),
('전민희', 'B006', '룬의 아이들 블러디드 2', '2019-09-25', '9788954657556', 14500),
('요나스 요나손', 'B006', '핵을 들고 도망친 101세 노인', '2019-09-25', '9788932919874', 14800),
('닐 셔스터먼, 재러드 셔스터먼', 'B006', '드라이', '2019-09-20', '9788936477783', 15800),
('스테파니 버지스', 'B006', '초콜릿 하트 드래곤', '2019-09-04', '9791135443947', 14800),
('브누아 필리퐁', 'B001', '루거 총을 든 할머니', '2019-07-30', '9791190182591', 13500),
('캐서린 스테드먼', 'B001', '썸씽 인 더 워터', '2019-07-24', '9788950982164', 13500),
('에이미 몰로이', 'B001', '퍼펙트 마더', '2019-07-22', '9791130623177', 14220),
('지건, 콕콕', 'B001', '잔혹동화', '2019-07-20', '9791161950938', 12420),
('류츠신', 'B006', '삼체 3', '2019-09-25', '9788954439923', 17500),
('히가시노 게이고', 'B006', '방과 후', '2019-07-10', '9791163898078', 14800)
;

-- 대여 목록
INSERT INTO rentaltbl VALUES
(22, 30, '2020-01-03', '2020-01-15'),
(10, 10, '2020-02-01', NULL),
(1, 12, '2020-02-01', '2020-02-03'),
(25, 34, '2020-02-02', NULL),
(23, 22, '2020-02-11', '2020-02-17'),
(7, 30, '2020-02-14', NULL),
(9, 31, '2020-02-14', '2020-02-17'),
(21, 15, '2020-02-18', '2020-02-18'),
(22, 17, '2020-02-20', '2020-02-25'),
(14, 7, '2020-02-26', '2020-02-28'),
(15, 9, '2020-03-01', '2020-03-05'),
(19, 44, '2020-03-02', NULL),
(20, 59, '2020-03-03', '2020-03-08'),
(24, 24, '2020-03-08', '2020-03-09')
;
