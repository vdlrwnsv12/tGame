﻿using System;
using System.Threading;
using System.Threading.Tasks;
static class Game
{
    static Random random = new Random();
    static string playerName;
    static string npcName = "???";
    static int hp = 100;
    static int power = 1;
    static int aglity = 1;
    static int guard = 1;
    static int gold = 10;
    static string playerClass = "개백수";
    static int playerLevel = 1;
    static string mName;
    static int mHp;
    static bool isFirstVillage = true;
    static int mPower;
    static int mGuard;
    static List<string> playerSkills = new List<string> { "공", "방" };
    static CancellationTokenSource timerCts;
    static bool isMonsterDie = false;
    static void Main()
    {
        int selectedOption = 0; // 0: 게임 시작, 1: 종료
        string[] options = { " 게임 시작", "   종료" }; // 선택된 항목 표시

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== 대충 이세계물 소설 읽다가 그 소설의 주인공이 되는 게임 ====");

            Console.WriteLine("방향키로 선택하세요");

            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine(i == selectedOption ? $"▶ {options[i].TrimStart('▶', ' ')}" : $"  {options[i]}");
            }

            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.UpArrow) // 위 방향키
                selectedOption = (selectedOption - 1 + options.Length) % options.Length;
            else if (key.Key == ConsoleKey.DownArrow) // 아래 방향키
                selectedOption = (selectedOption + 1) % options.Length;
            else if (key.Key == ConsoleKey.Enter) // 엔터 키
            {
                if (selectedOption == 0) // "게임 시작" 선택
                {

                    //StartGame();
                    // InsideBook();
                    //TutorialFight();
                    Village();
                    return;
                }

                else
                {
                    Console.Clear();
                    string exitMessage = "게임을 종료합니다 ...";

                    foreach (char c in exitMessage)
                    {
                        Console.Write(c);
                        Thread.Sleep(100);
                    }
                    Thread.Sleep(500);
                    break;
                }
            }
        }
    }

    static void StartGame()
    {
        Console.Clear();  // 게임 시작 전 화면 초기화
        do
        {
            NpcrText("당신의 이름은 무엇입니까나리? ");
            playerName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(playerName))
            {
                NpcrText("이름이 뭐냐고 .");
            }
        }
        while (string.IsNullOrWhiteSpace(playerName));
        Console.Clear();
        NpcrText($"환영합니다, {playerName}님!\n");

        PlayerText("아 심심한데 책이나 봐야지..");
        PlayerText(" [대충 이세계로 떠나는 책]이거 재밌는데 보는 사람이 없단말이야");

        Console.WriteLine(@"
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
:::::::::::::::::::::::::::::::::::::::::::::-=+**##+-::::::::::::::::::::::::::
:::::::::::::::::::::::::::::::::::::::-=+*##%%%%###%%#+-:::::::::::::::::::::::
::::::::::::::::::::::::::::::::--=+*##%%%%%%#%%%#%#%#%%#*=:::::::::::::::::::::
::::::::::::::::::::::::::--=+*##%%%%%%###%%%%#%%%%%%##%%%%#*-::::::::::::::::::
::::::::::::::::::::-=+**#%%%%%###################%#%#######%%#+-:::::::::::::::
::::::::::::::-=+*###%%%%%############################%#######%%%*=-::::::::::::
::::::::-=+*##%%%%%##############################%%%#%%#%#########%#*=::::::::::
:::::::+=*%%#%##########################%%%%%%#%%%%%%%%##%%%#%########*=::::::::
:::::::*-:=*###%#########%%####%###%%#####%%%%%%%%%%%%%%%%%%%%%%#%%####*+:::::::
:::::::==::-+####%%%##%%#%%%%%%%%#%%%%#%#%#%####%%%%%%%%%%%%%%%%###***+:::::::::
:::::::-+::::=+###%#%%%%##%%%%%##%%%%%%%%%%%%#####%%%%%%%%%%%%#***++++-:::::::::
::::::::*=::::-=*#%%%%%%#%%%%####%#%%%%%%%%%%%%%%%%%%%%%%##**+++++++**=:::::::::
:::::::::++-:-::-=*%%%%%%%%############%%%%%%%%%%%%%###**++++++***+++**=::::::::
::::::::::=*+-:-::-+#%%%%%%%%####%#%##%%%%%%%%####*******+*********####=::::::::
::::::::::::+*=:::::-+#%%%%%%%%%#%%%%%%%%%%###****************#####*=-::::::::::
:::::::::::::-*+-:--::=*#%%%%%%%%%%%%%%###****************#%%##+=--:::::::::::::
:::::::::::::::=*=-:-::-=#%#%%%%%%###***************###%%#*+=--:::::::::::::::::
:::::::::::::::::+*-::-::-+####******##******#####%%%#*=---------:::::::::::::::
::::::::::::::::::-*+-::--+******#######*####%%%%#+=---------:::::::::::::::::::
::::::::::::::::::::+*=:::+*****#########%%%#*+=----------::::::::::::::::::::::
:::::::::::::::::::::-+*-:+#*****###%%%%#*+=-----------:::::::::::::::::::::::::
:::::::::::::::::::::::-*+=*###%%%%#*+=------------:::::::::::::::::::::::::::::
:::::::::::::::::::::::::=+*%%%#*=--::::::::::::::::::::::::::::::::::::::::::::
:::::::::::::::::::::::::::-==-:::::::::::::::::::::::::::::::::::::::::::::::::
        ");

        Console.WriteLine("\n(아무 키나 눌러 책 보기...)");
        Console.ReadKey();
        OpenBook();
    }

    static void OpenBook()
    {
        Console.Clear();

        Console.WriteLine(@"
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::::::::::::::::::----------::::::::::::----------::::::::::::::::::::::::
::::::::::::::+=---------::::::::--=-::::::-=--:::::::::--------=+::::::::::::::
:::::::::::::=#:::::::::::::::::::::-=-::-=-:::::::::::::::::::::#=:::::::::::::
::::::::::::=*+::::::::::::::::::::::::++::::::::::::::::::::::::+*=::::::::::::
:::::::::=+***+::::::::::::::::::::::::++::::::::::::::::::::::::+***+=:::::::::
:::::::::#%#+*=::::::::::::::::::::::::++::::::::::::::::::::::::=*+#@#:::::::::
::::::::-%%*+*:::::::::::::::::::::::::++:::::::::::::::::::::::::*+*%%-::::::::
::::::::=%%++*:::::::::::::::::::::::::++:::::::::::::::::::::::::*++%%=::::::::
::::::::*%#+++:::::::::::::::::::::::::++:::::::::::::::::::::::::+++#%*::::::::
::::::::#%*+*=:::::::::::::::::::::::::++:::::::::::::::::::::::::=*+*%#::::::::
:::::::-%%*+*-:::::::::::::::::::::::::++:::::::::::::::::::::::::-*++%%-:::::::
:::::::+%%++*::::::::::::::::::::::::::++::::::::::::::::::::::::::*++%%+:::::::
:::::::#%#+++::::::::::::::::::::::::::++::::::::::::::::::::::::::+++#%#:::::::
::::::-%%*+*+::::::::::::::::::::::::::++::::::::::::::::::::::::::+*+*%%-::::::
::::::=%%*+*-::::::::::::::::::::::::::++::::::::::::::::::::::::::-*++%%=::::::
::::::*%#++*::::::::::::::::----:::::::++::::::::----:::::::::::::::*++%%*::::::
::::::##*++*=======+=+++++++++++++=-:::++:::-=+++++++++++++=+=======*++#%#::::::
:::::-%%***+++++++++++++++=======++++=:++:=+++=======++++++++++++++++***%#-:::::
:::::+%%**++++++++++==============+++++**+++++==============+==+++++++**%%+:::::
:::::#%%##############################%%%%##############################%%#:::::
:::::#%%%%%%%%%%%%%%%%%%%%%%%%%%%%#%@@@@@@@%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#:::::
::::::::::::::::::::::::::::::::::::-==++==-::::::::::::::::::::::::::::::::::::
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");

        PlayerText(":역시 이책은 재밌어 ");
        PlayerText("근데 뭔가 책이 빛나는거 같은..?....!!");
        Console.WriteLine("\n(아무 키나 눌러 계속 진행...)");
        Console.ReadKey();
        InsideBook();

    }

    static void PlayerText(string message)
    {
        foreach (char c in $"{playerName}: {message}")
        {
            Console.Write(c);
            Thread.Sleep(10);
        }
        Console.WriteLine();
        Thread.Sleep(100);
    }
    static void NpcrText(string message)
    {
        foreach (char c in $"{npcName}: {message}")
        {
            Console.Write(c);
            Thread.Sleep(10);
        }
        Console.WriteLine();
        Thread.Sleep(100);
    }
    static void InsideBook()
    {
        string[] options = { "암살자(민첩하고 딜이 강하지만  유리몸)", "기사(딜 준수, 탱 준수, 민첩 준수)", "전사(힘쎄고 강한 아침)!" };
        int selectedOption = 0;

        Console.Clear();
        Console.WriteLine();
        PlayerText("아 잠깐 기절했네 요즘 너무 게임만 했나");
        PlayerText("근데 왜 아무것도 안보이지...");

        NpcrText($"야야...{playerName}");

        PlayerText("....누구세여??");
        NpcrText("알빠노 ");
        NpcrText("이거 책 엔딩 개망해서 너를 내 책 속으로 소환했음 ");
        NpcrText("너가 하는 행동에 따라서 엔딩이 정해질거야 그럼 화이팅 ");
        PlayerText("잠시만요!");
        NpcrText("왜 귀찮게...");
        PlayerText("그럼 주인공이 저인건가요?");
        NpcrText("ㅇㅇ 맞음 대충 직업 정하고 알아서 해");
        NpcrText("너 이책 좋아하잖아 결말이 좀 아쉽지 않냐");
        PlayerText("ㅇㅇ 그렇긴해요 개 쓰레기 엔딩 그러니까 평점이 1점이지");
        NpcrText("ㅅㅂㄹ....");
        PlayerText("님 그럼 이 책 작가세요?");
        NpcrText("ㅇㅇ앞으로 뭐 필요 할 떄 가끔 말 걸어서 도와줄게 잘 해보셈");
        PlayerText("제가 님을 뭐라고 부르면 되나요 ?");
        NpcrText("알아서.");
        Console.WriteLine("작가 이름을 정하세요:");
        npcName = Console.ReadLine();
        PlayerText($"오케이 {npcName}(이)라고 부를게요");
        NpcrText($"{npcName}......그래 뭐 맘대로 해...간다 화이팅해라 결말 잘 써서 재출판 하면 수익 10퍼 줄게.");
        PlayerText("확인");

        Console.Clear();

        Console.Clear();
        Console.WriteLine("==== 직업 선택 ====");
        Console.WriteLine("방향키로 선택하세요");


        while (true)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine(i == selectedOption ? $"▶ {options[i]}" : $"  {options[i]}");
            }

            ConsoleKeyInfo key = Console.ReadKey(intercept: true);

            if (key.Key == ConsoleKey.UpArrow) // 위 방향키
                selectedOption = (selectedOption - 1 + options.Length) % options.Length;
            else if (key.Key == ConsoleKey.DownArrow) // 아래 방향키
                selectedOption = (selectedOption + 1) % options.Length;
            else if (key.Key == ConsoleKey.Enter) // 엔터 키
            {
                if (selectedOption == 0)
                {
                    Console.Clear();
                    Console.WriteLine("암살자를 선택하셨습니다!");
                    aglity += 5;
                    guard -= 1;
                    power += 5;
                    playerClass = "암살자";
                    Console.WriteLine("");
                    playerSkills.Add("개쩌는공격");
                    DisplayStats();
                    break;
                }
                else if (selectedOption == 1)
                {
                    Console.Clear();
                    Console.WriteLine("기사를 선택하셨습니다!");
                    aglity += 3;
                    guard += 3;
                    power += 3;
                    playerClass = "기사";
                    Console.WriteLine("");
                    playerSkills.Add("개쩌는스킬");
                    DisplayStats();
                    break;
                }
                else if (selectedOption == 2)
                {
                    Console.Clear();
                    Console.WriteLine("전사를 선택하셨습니다!");
                    aglity -= 1;
                    guard += 5;
                    power += 5;
                    playerClass = "전사";
                    Console.WriteLine("");
                    playerSkills.Add("개쩌는회복");
                    DisplayStats();
                    break;
                }
            }
            Console.SetCursorPosition(0, 2);
        }
        Console.WriteLine("아무키나 눌러 다음");
        Console.ReadLine();
        TutorialFight();
    }

    static void TutorialFight()
    {
        NpcrText($"좋아 {playerClass}로 전직했네 좋은 선택이다.. 이제 저기 샌드백 때려보자");
        PlayerText("ㅇㅋ");
        Console.ReadLine();

        TutoMoster();

        Console.WriteLine($"연습 전투 시작! 상대는 {mName}입니다.");
        Console.WriteLine("5초 안에 '공' 또는 '방'을 입력하세요!");
        Console.WriteLine("5초 안에 입력을 못하거나 오타가 나면 아무 행동도 취할 수 없습니다");

        Fight();

    }

    static void DisplayStats()
    {

        Console.WriteLine($"이름: {playerName}");
        Console.WriteLine($"직업: {playerClass}");
        Console.WriteLine($"레벨: {playerLevel}");
        Console.WriteLine("현재 스킬 목록: " + string.Join(", ", playerSkills));
        Console.WriteLine($"HP: {hp}");
        Console.WriteLine($"Power: {power}");
        Console.WriteLine($"Agility: {aglity}");
        Console.WriteLine($"Guard: {guard}");
        Console.WriteLine($"Gold: {gold}");


    }
    static void Fight()
    {

        Console.Write("사용 가능한 스킬: ");
        foreach (string skill in playerSkills)
        {
            Console.Write(skill + " ");
        }
        Console.WriteLine();

        while (hp > 0 && mHp > 0)
        {
            StartNewTurn();
        }
    }

    static void StartNewTurn()
    {
        timerCts?.Cancel(); // 이전 타이머 중지
        timerCts = new CancellationTokenSource();

        Task.Run(() => StartTimer(5, timerCts.Token)); // 새로운 타이머 시작

        while (true)
        {
            string playerAction = Console.ReadLine();
            timerCts.Cancel(); // 입력 시 타이머 취소

            if (playerAction == playerSkills[0]) // 공격
            {
                mHp -= power;
                Console.WriteLine($"{mName}를 공격! 남은 HP: {mHp}");
            }
            else if (playerAction == playerSkills[1]) // 방어
            {
                Console.WriteLine("가드를 올렸습니다");
            }
            else // 오타 입력
            {
                Console.WriteLine("잘못된 입력! 아무 행동도 하지 못했습니다.");
                hp -= mPower;
                Console.WriteLine($"개같이 맞았습니다! 남은 HP: {hp}");
            }

            if (mHp <= 0)
            {
                Console.WriteLine($"{mName}를 쓰러뜨렸다!");
                isMonsterDie = true;
                NpcrText("굿 그런식으로 싸우면 됨 그럼 화이팅해라 엔터 눌러서 마을로 가 이제 너 맘대로 해");
                Console.ReadKey();
                Village();
                return

                ;
            }
            if (hp <= 0)
            {
                Console.WriteLine("죽었네 에휴...");
                return;
            }
            StartNewTurn(); // 새로운 턴 시작 (타이머 초기화)
        }
    }

    static void Village()
    {
        Console.Clear();
        Console.WriteLine(@"

##@@@@@$$###@##@#$$:,-------,.----:=$$#*=##@#~---#@=$##@##$$$$$@#$$$$$###$$$$$##
####@@@=$$##$#@@$$;;!::~~~~~----~~-!$#=$=#@#:----#@##@####$$$$$##$$===$##$$$$$##
###$$#$$$$####@#$$:!!!*~~~~~- ,----~*$*$$=$!-----#@#$#$#$##$$$$$#$$$$=$##$=$$$$@
#####$$$$$$###@###~--!*~~~~~~-, ,-----$$$!-------#@##==#$$##$$=$#$=$$=$$#$$=$$$#
#@######$$$###@#$=!;*@~~~~~~~-..... ,----------,,###@=*#$$$##$=$##$=$==$#$=$$$$$
##############@$$$:=@@~~~~~~---,  ...,,,,,,,,,...@##@**#$==$##$$##$==$$$##$=$$$$
$####@@##$####@$$$!*$#:~~~~-----,--- ...,,,......@#$@**#$$$$$##$##$==$$$##$$$$$$
#####@@@@#$$#@#$$$#;##;~~~~---------  .- .-...,..@$##**##$$$$$####$$$$$$##$$===$
$#####@@@$##$$#=$$@$@$!~~~~--------- -~~-~-   - ,@###**$#$$$$$$####$$$$$###$$$#$
$$$###@@@$$$#$##$=#@$$=~~~~---------.,-~~-~- -...@##$**###$$################$$$$
$$######@$$$#$##$$##@*~~;!-~-------, .-------;!~-@#$#=$#$$$##@====$$$$$==$======
$$#######$$##$#$$$##@=;*$=:--------.-.,-----!::~,@###=!!=#*##@#$=====$=======*==
$#########$#$$==$$###@=$@!-~-------,-~-~~---:;~~.##@#$;:~*######=====$========**
$$#######$$$=$=$$$$#$@*$@*~;-----,,---~~~~--~;~--#=##$;~~:!$#####=============*$
$$$####@#$$#$$$=$#=#$$@$$$~$#--~~-,,---:----~;~==#=##*:-~$!;######============$=
$$$######$#$$$$==#=##=@$$$#$=*!;;,,,,--;:::::!!$$$=##;~-;$;;####@@@$=====$=$====
$$################=##*$$$#====*;!~--,--!-,--*#;#$#$$*;~~=;;!$####@@@#=====$$=$$=
#$#####$##@@@@@@@$$##*=@#@*=**$;*::.~ :$-;:;==~#$#$$!~~!=;!!=####@@@@@#$$$===$==
######@###@@@@@@@#$#$==$@@=**!:;:~..  ~$.-;*=*:@$$$$=**#!;!$*@##$@@@@@@@@@*#$$$=
$#####@$##@@@@@@@#@@=$==@##=*!;.~;~,,-,:-:!***~#$$#$$=#$!!!!;@##$@@@@@@@@*@@##$$
#######$##@@#####@#@##==$@@@$$$, .:~~!~.:!**==~##@#$==#$**;*;##$$#@@@@#@*@@@#@##
$#########@######@#@$#=*=#$!-:~. ~;::*!-!*==$*~$#$#$=#=$*=;*~###$#@@@@#*@@@@####
$####@####@##@@@###@@$$*=#$!~::  -:: :::!;##$!==$#####===*;!~=####@@@@=#@@@####@
#####@####@###@####@@$==##$!=~:. --.,=;!!;$$$==#$$=$#$===!-;~*####@##$#@@@#@@@@@
########$@#$@##$$##@@@=#=#$=:~:~#*:;.-~;;$==$*:$$!;;;;;::*-*!!######$#####@@@@@@
#####$$#$@$$@@@$$##@@@$=$@#$=;@*=;!; .-:;=*$$!-=$##$#$*;:*-*;;;##@@@#@@@@@@@@@@@
####@#$$$@$#@@@$$#@@@@@=$#$***##*;~,~:;~;!=!$:!!;~::::;!-:*:;~*=#@$##########@@@
####@##$#@#$#####@@@@@@#$#$*!=@!=*:-,-=*!*:*!.=$*~~-,!!!-!;~:=*!#@=#$$$$$$$###@#
########@@@@@@#@#@@@#@@@$=#*!#$*$:~-~-,~!=-;~~;#;::~~~~!!;:*$$$===$#$$$$$$$#####
#######@@@@@@@@@##@@#@@#@$$$==#=!:~~-.!!;;==.!:#:~;*!*!!!~*=;-:*!####$$$######@#
###@####@@##$##$$$$@@@@#@@====#*:~-,,.=- -*: ~$#;;:$=#*!;!. :,-*;##############@
###@#####$$$$$====**$#@#@@###$$*~;---,~..*=~!*=#@*=#$#*==;. ;,:~~$####@@@@@####@
#######=#====$====$$$=@####$#$=*:!:---!..$$**$$@######=*:;~;;~*=-#####@##@@####@
##@######@@@@$@@@@@@#@$@####$#==~=*~~-.~=*==#@@@###@##$*:;::;,;;,$@##$####@####@
##@###@####@#$@@@#@##@$@@@##=$$,~:~;;*@#;$#####@@@@@#$$*;;:!!-~;.*###$##@#@@###@
##@$##@##@#@$$@@@#@@#@@@@@##==$-~:~*!!@~;$$######@#@#$$*!;:~;~~!.;###$$#@#@@####
#@@###@####@$$@@@#@@###@@@#@=$;~~:$=*;$:!$*#@@@#@@$#@#$$;!;-;:-!~:####$@@@@@#$##
@@####@#@##@$#@@@#@@$##@@@#@==:!!$$##:!$=$$#@@@#@@@#@###;*!~!!~;;-@#$$$@@@@###$#
@@###@@@#@@#$#@@@@@@####@@##$*=*!*$###@###$##@@@@@@@@###***~**-:!,#@$#$@@@@@@###
@@###@@@@@@@###@@@@@@@#######=*:~:==$$$$$$$$#@@@@##@@@#@!;!:**-;!,=@#$$#@@@@@###
@@###@@@##@@@########@@@#$$#$$$*==$$#$$$$$$#$$$###@@@@@@*:*;**~~*,*#####@@@@@###
@####@@@#@@@@#$##**#$$$#####$$#$##$#$=$$$$$$$$$#$$$$==*#*$!;=*-;;~;#####@@@@@###
@#####@@####@@#$#@#$==$#########$#$$$$$$$$=#$$$$#=#$#*!#$$*!**!;~~;@@@#====$$$$$
@####$####@@@####@#=#@##$$$$##$##$$$$$$#$#$$$$=$$$$==#$$$=$*=!!*!;;=$@@@@@@@@@@@
@##$##$$#$$$$$$$$#$$==========$$*$$=$$==$=#****!!;!;;;;;!*****===**#@@@@@@##@@##
@@#$$$$$$$$$==========**=****=*!===********$#=*!:::~:~;:~::*==*==*=#@@@#$##@@@@@
$$$$$#$$$$=$$=====*==****!!**#=**!*!!;;;;!;!;*$=##*;::~~~:~:;:;;**=$@@@#$#*#@@#$
#$##$$$$$$$=========***=*!!!**$$*;!!;;!;!!;!!;*$!=$###$$$$*!~-::~:::!=$#$$@#@@@#
####$$$$$$$$$$=======***=*****!*=##$=!;!;!;;;*!!!::;;~:*=@##$##$$#$$=!!!!;;*=$#@
####$$$=$$$==$$$==*=*=*******!!**!**$##=*;;;;;;;;~;:;;:;:!;;!;!$##@##$$$##$=$=;;
####$$$$$==$$====$==***==*!**=**!;;!*!**=##$*!!;;;;!!;;!;::;;:;;;!!!$!=#######$$
######$=$=***=$=====*===!**!==*!=*=*=!*!****=$##$$*!;;;!*!::;;;::;!!!*;*!**;!=#@
##$$$=======$*==*===$*****==*******=!****=!*!!*=!=$$#$$=$==****$*:!!=!!!*!;!!!;!
");
        if (isFirstVillage == true)
        {
            PlayerText("칙칙한 마을이네...");
            PlayerText("일단 상점부터 가볼까");
        }
        else
        {
            PlayerText("언제봐도 칙칙한 마을이야");
        }
        isFirstVillage = false;
        Console.WriteLine("원하는 행동을 입력하세요. 1. 상태보기, 2. 인벤토리, 3. 상점 방문");
        int playerAct = int.Parse(Console.ReadLine());
        if (playerAct == 1)
        {
            DisplayStats();
            string s = Console.ReadLine();
            if (s == "돌아가기")
            {
                Village();
            }
        }
        else if (playerAct == 2)
        {
            //OpenInventory();
        }
        else
        {
            //OpenStore();
        }


    }
    static void TutoMoster()
    {
        Console.Clear();

        mHp = 20;
        mPower = 0;
        mName = "샌드백";
        mGuard = 0;

        Console.WriteLine(@"
██████████████████████████▒░─░▒███████████████████
██████████████████████████░░▒▒████████████████████
███████████████████████████▒▓▓████████████████████
████████████████████████████▒─████████████████████
███████████████████████████▓▓█████████████████████
███████████████████████████▒▓█████████████████████
██████████████████████████████████████████████████
█████████████████████████▒▒░░░████████████████████
█████████████████████████▒▒▒▒░░░██████████████████
█████████████████████████▓▓▒▒▒░░░─████████████████
████████████████████████▒▓▓▓▓▒░░░░░███████████████
████████████████████████▒▓▓▓▓▓▒▒▒░░███████████████
████████████████████████▓▓▒░▓▓▓▓▓▒─███████████████
███████████████████████▒▓▓░░▒▓▓▒░░████████████████
███████████████████████▒▓▓▓▒▒▒▒░░░████████████████
██████████████████████▒▒▓▓▓▓▓▒▒░░─████████████████
█████████████████░▒▒▒░░▓▓▓▓▓▓▒▒▒─█████████████████
████████████████▒▒▒▒░░░▒▓▓▓▓▓▓▓▒██████████████████
████████████████▓▓▒▒░░▒▒▓▓▓▓█▓▓░██████████░░░█████
███████████████░░▓▓▓▒░░▒▒▒▒▒▒▒▓▒████████▒▒▒▒░░████
███████████████▒▒▓▓▓▓▒▒░▒▓▒▒▒▒▓▒▒─██████▓▓▒▒░▒░███
██████████████▓▓▒▓▓▓▓▓▒▒▓▒▒▒▒▒▓▓▒▒█████▓▓▓▓▒▒▒░─██
█████████████▒▓▓▓▓███▓▓▓▓▒▒▒▒▒▓▓▓▓▒████▓▓▓▓▓▓▒▒─██
████████████▓▓▓▓█▓███▓▓▓▓▓▒▒▒▒▒▓▓▓▓▓▓▒█▓██▓▓▓▒▒███
██████████─▓▓▓█████▓███▓▓▓▓▒▒▒▓▓▓██▓▓▓▒█▓███▓▓░███
██████████▓▓▓▓████▓████▓▓▓▒▒▒▒▓▓▓████▓██████▓░████
██████████▓▓████████████▓▓▒▒▒▒▓▓▓██████████▓██████
██████████▓██████▒▓█████▓▓▒▒▒▒▓▓▓█████████▓█░█████
██████████▒███████▓█████▓▓▓▒▒▓▓▓▓▒████▓██▓▓█░█████
██████████▒▓▓█████▓████▓▓▓▒▒▒▓▓▓▓▒─███▒▓██▓█▒█████
██████████▓▓▓█████▓▓███▓▓▓▒▒▒▒▓▓▓▒▒████████▓▒█████
██████████▒▒▓▒████▓▓▓██▓▓▓▓▒▒▒▓▓▓▒░████████▓▓▒████
██████████▒▓▓▒████▓▓▓▓▓▓▓▓▒▒▒▒▒▓▓▒░████████▓▓█▒███
██████████▓▓▒▒████▓▓▓█▓▓▓▓▒▒▒▒▒▓▓░░█████████▓█▒░██
███████████▓▒▒████▒▓▓▓▓▓▓▓▓▒▒▒▒▓▒▒░██████████▓▒░██
██████████▓▓▓▒████▒▓▓▓▓▓▓▓▒▒▒▒▒▒▓▒░██████████▓▓▓░█
██████████▓▓█▓████▒▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒██████████▓█▒░█
██████████▒▓▓─████▒▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒██████████▒▓░░█
██████████▓▓▓█████▒▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒██████████▒█▓▒█
███████████▒██████▒▓▓▓▓▓▓▓▓▒▒▒▒▓▒▒▒██████████▓▓▓─█
████████████████▒▓█▓▓▓▓▓▓▓▒▒▒░▒▒▒▓▓██████████▓▓███
███████████████▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▓▓▓█████████▓▓▓██
███████████████▓█▓▓▓▓▓▓███████▓█▓▓▓▓▓████████▓▓▒██
██████████████─▓█▓▓▓▓▓▓▒▓████████▓▓▓▓▓███████▓▓███
██████████████▒▓▓█▓▓▓▓▓▒▒▓─█████▓▓▓▓▓▓▓▒██████████
██████████████▒▓█▓▓▓▓▓▒▒▓▒████▓██▓▓▓▓▒▒▒▒█████████
██████████████▓▓█▓▓▓▓▓▒▓▓▓████████▓▓▓▓▒▒▒▒████████
█████████████▒▓▓▓▓▓▓▓▓▓▓▓▓█████████▓▓▓▒▒▒▒▒███████
█████████████▓▓█▓▓▓▓▒▒▓▓▓███████▓▓███▓▓▒▒▒▒▓██████
███████████▒▓▓▓▓▓▓▓▓▒▒▓▓▓████████▓▓▓██▓▓▒▓▓▓██████
██████████▒▓▓█▓▓▓▓▓▒▒▓▓▓█████████▓▓▓███▓▓▓▒▒─█████
█████████▓▓▓▓██▒▓▓▓▒▒▓▓▓████████▓▓▓████▓█▓▒▒▒█████
█████████▓▓▓██▓▓▓▒▒▓▒▓▓█████████▓▓▓██████▓▓▒▒─████
████████▒▒▓██▒▓▓▓▓▓▒▓▓▓████████▓▓▓███▓▓▓▓▓▒▒▒█████
█████████▓██▒▒▓▓▓▓▓▓▓████████████████▓▓▓▓▓▓▓▓█████
███████████▒▒▓▓▓▓▓▓█▓████████████████▓▓▓▓▓▓▓▓█████
██████████▒▒▓▓▓▓▓▓▓▓█████████████████▓▓▓▓▓▓▓▓█████
██████████▓▓▓▓█▓▓▓▓▓█████████████████▓▓▓▓▓▓▓▓█████
█████████─▒▓▓▓███▓▓██████████████████▓▓▓▓▓▓▓▓█████
████████▒▒▓▓▓████▓███████████████████▓▓▓▓▓▓▓▓█████
███████▒▒▓▓▓█████▓█████████████████▓█▓▓▓▓▓▓▓▓█████
███████▒▓▓▓█████████████████████████▓▓▓▓▓▓▓▓▓█████
██████▒▒▓▓▓████▓─██████████████████▒█▓▓▓▓▓▓▓▓█████
██████▓▓▓▓█████▓██████████████████▓▓█▓▓▓▓▓▓▓▓█████
██████▓▓▓▓████▓██████████████████▓▓▓█▓▓▓▓▓▓▓▓█████
██████▓▓█████▓▓█████████████████─▓█▒▓██▓▓███▓▓▓▒░░
█████▓▓██████▓▓█████████████████▓▓▓█▓▓██████▓▓▓▒░░
███─▓▓▓███▓▓▓▓▓█████████████████▓▓▓─▓▓▓▓▓▓▓▓▓▓▓▒░░
██▒▒▒▒▓▓▓▓▓▓▓▓▓████████████████████▓▓▓▓▓▓▓▓▓▓▓▓▒░░
▒▒▒▒▒▒▒▒▓▒▒▒▒▒█████████████████████▒▓▓▓▓▓▓▓▓▓▓▓▒░░
▒▒▒▒▒▒▒▒▒▒▒▒▒▒██████████████████████▓▓▓▓▓▓▓▓▓▓▓▒░▒
▒▒▒▒▒▒▒▒▒▒▒▒▒███████████████████████████▓▓▓▓▓▓▓▒░█
▒▒▒▒▒▒▒▒▒▒▓██████████████████████████████████▓▓▒██
▓█▓▓▓▓▒▒▒▒████████████████████████████████████████
");

    }
    static void StartTimer(double timeLimit, CancellationToken token)
    {
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < timeLimit)
        {
            if (token.IsCancellationRequested) return; // 타이머 취소 시 종료
            double remainingTime = timeLimit - (DateTime.Now - startTime).TotalSeconds;
            Console.Write($"\r남은 시간: {remainingTime:F2}초  ");
            Thread.Sleep(50);
        }

        Console.WriteLine("\n시간 초과! 행동을 하지 못했습니다.");
        StartNewTurn(); // 시간 초과 후 자동으로 새 턴 시작
    }
}



