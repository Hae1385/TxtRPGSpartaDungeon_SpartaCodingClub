using System.ComponentModel.Design;
using System.Diagnostics;
using System.Net.Security;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static TxtRPGSpartaDungeon.Program;

namespace TxtRPGSpartaDungeon
{
    internal class Program
    {

        public class EquementItem
        {
            public string Name { get; }
            public int State { get; }
            public string ItemType { get; }
            public string Description { get; }
        }
        public class EquementItems
        {
            public string Name { get; set; }
            public int State { get; set; }
            public string ItemType { get; set; }
            public string Description { get; set; }
            public bool OnEqument;
            public int EquementType;
            public int EquementPrice;
            public bool HaveItem;

            public EquementItems(string name, string itemType, int state, string description, bool onEqument, int weoponOramor, int price, bool have)
            {
                Name = name;
                State = state;
                ItemType = itemType;
                Description = description;
                OnEqument = onEqument;
                EquementType = weoponOramor;
                EquementPrice = price;
                HaveItem = have;
            }
        }

        public class Inventory
        {
            public List<EquementItems> EqumentList;
            public Inventory()
            {
                EqumentList = new List<EquementItems>();
            }

            public void AddEqument(EquementItems equementItems)
            {
                EqumentList.Add(equementItems);
            }
            public void RemoveEqument(EquementItems equementItems)
            {
                EqumentList.Remove(equementItems);
            }
            public void EqumentWindow()
            {
                for (int i = 0; i < EqumentList.Count; i++)
                {
                    if (EqumentList[i].OnEqument == true)
                    {
                        Console.Write($"장비{i + 1}");
                        Console.Write("[E] ");
                        Console.WriteLine($" \\ {EqumentList[i].Name} \\ {EqumentList[i].ItemType} \\ {EqumentList[i].State} \\ {EqumentList[i].Description}");
                    }
                    else
                    {
                        Console.Write($"장비{i + 1}");
                        Console.WriteLine($" \\ {EqumentList[i].Name} \\ {EqumentList[i].ItemType} \\ {EqumentList[i].State} \\ {EqumentList[i].Description}");
                    }

                }
            }

        }

        public class Equementshop
        {
            public List<EquementItems> equementshop;
            public Equementshop()
            {
                equementshop = new List<EquementItems>();
            }

            public void AddShop(EquementItems equementshopitem)
            {
                equementshop.Add(equementshopitem);
            }


            public void ShopWindow()
            {
                Inventory inventory = new Inventory();
                for (int i = 0; i < equementshop.Count; i++)
                {
                    if (equementshop[i].HaveItem == true)
                        Console.WriteLine($"판매중 {i + 1}. \\ {equementshop[i].Name} \\ {equementshop[i].ItemType} \\ {equementshop[i].State} \\ {equementshop[i].Description} \\ " + "구매됨");
                    else
                        Console.WriteLine($"판매중 {i + 1}. \\ {equementshop[i].Name} \\ {equementshop[i].ItemType} \\ {equementshop[i].State} \\ {equementshop[i].Description} \\ {equementshop[i].EquementPrice}");
                }

            }
        }





        static void Main(string[] args)
        {
            int level = 0;
            double attackPoint = 0 + ((level-1) * 0.5);
            int shieldPoint = 0 + (level - 1);
            int playerHP = 0;
            int money = 0;

            level++;
            attackPoint += 13;
            shieldPoint += 10;
            playerHP += 100;
            money += 1500;

            Inventory inventory = new Inventory();
            Equementshop shop = new Equementshop();

            //장비 종류추가

            //무기
            EquementItems weapon1 = new EquementItems("낡은 검", "공격력", 2, "쉽게 볼 수 있는 낡은 검 입니다.", true, 1, 600, false);
            EquementItems weapon2 = new EquementItems("청동 도끼", "공격력", 5, "어디선가 사용됐던거 같은 도끼입니다.", false, 1, 1500, false);
            EquementItems weapon3 = new EquementItems("스파르타의 창", "공격력", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", false, 1, 3000, false);

            //방어구
            EquementItems amor1 = new EquementItems("수련자의 갑옷", "방어력", 5, "수련에 도움을 주는 갑옷입니다.", true, 2, 1000, false);
            EquementItems amor2 = new EquementItems("무쇠갑옷", "방어력", 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", false, 2, 2000, false);
            EquementItems amor3 = new EquementItems("스파르타의 창", "방어력", 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", false, 2, 3500, false);

            //상점추가
            shop.AddShop(weapon1);
            shop.AddShop(weapon2);
            shop.AddShop(weapon3);
            shop.AddShop(amor1);
            shop.AddShop(amor2);
            shop.AddShop(amor3);

            //시작아이템
            inventory.AddEqument(weapon1);
            weapon1.HaveItem = true;
            inventory.AddEqument(amor1);
            amor1.HaveItem = true;

            Console.WriteLine("촌장: 어서오게나 모험가여!");
            Console.WriteLine("촌장: 여기는 스파르타 마을이라고하네!");
            Console.WriteLine("촌장: 그대의 이름을 알려주겠나!");
            Console.WriteLine("이름을 입력하면 수정할 수 없습니다.");
            Console.WriteLine("이름을 입력해주세요");
            Console.Write("이름: ");
            string PlayerName = Console.ReadLine();


            for (int i = 3; i > 2; i++)
            {
                //인트로
                Console.Clear();
                Console.WriteLine($"스파르타 마을에 오신 여러분 환영합니다.{PlayerName}님");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                Console.WriteLine("1. 상태보기  2. 인벤토리  3.상점 4.휴식하기 5.던전입장");
                Console.WriteLine("원하시는 행동을 입력해주세요.");

                string action = Console.ReadLine();

                switch (action)
                {

                    case "1":
                        //상태창
                        Console.Clear();
                        Console.WriteLine("상태보기를 선택하셨습니다.");
                        Console.WriteLine("Lv." + level);
                        Console.WriteLine("공격력 " + attackPoint);
                        Console.WriteLine("방어력 " + shieldPoint);
                        Console.WriteLine("체력 " + playerHP);
                        Console.WriteLine("Gold: " + money);
                        Console.WriteLine();
                        {
                            for (int j = 3; j > 2; j++)
                            {
                                Console.WriteLine("0 나가기");

                                string SelWinOut = Console.ReadLine();

                                int OnSelWinOut = int.Parse(SelWinOut);

                                if (OnSelWinOut == 0)
                                {
                                    Console.WriteLine("나가기");
                                    Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                    Console.ReadLine();
                                    j = 0;
                                }
                                else
                                {
                                    Console.WriteLine("올바른 값을 입력해주세요");
                                    Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                    Console.ReadLine();
                                }
                            }

                        }
                        break;
                    case "2":
                        //인벤토리
                        Console.Clear();
                        Console.WriteLine("인벤토리를 선택하셨습니다.");
                        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                        Console.WriteLine("/[아이템 목록/]");
                        inventory.EqumentWindow();


                        for (int j = 3; j > 2; j++)
                        {
                            Console.Clear();
                            inventory.EqumentWindow();
                            Console.WriteLine("1. 장착관리");
                            Console.WriteLine("0. 나가기");
                            Console.WriteLine("원하시는 행동을 입력해주세요.");

                            string SelWinOut = Console.ReadLine();

                            int OnSelWinOut = int.Parse(SelWinOut);

                            if (OnSelWinOut == 0)
                            {
                                Console.WriteLine("나가기");
                                Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                Console.ReadLine();
                                j = 0;
                            }
                            else if (OnSelWinOut == 1)
                            {
                                //장비장착
                                Console.Clear();
                                Console.WriteLine("장착할 장비를 선택해 주세요");
                                Console.WriteLine("0. 나가기");
                                inventory.EqumentWindow();
                                int EquementSetting = int.Parse(Console.ReadLine());

                                if (EquementSetting > 0 && EquementSetting <= inventory.EqumentList.Count && inventory.EqumentList[EquementSetting - 1] != null)
                                {
                                    if (inventory.EqumentList[EquementSetting - 1].EquementType == 1) //내가 장착한 장비가 무기라면
                                    {
                                        for (int AtkP = 0; AtkP < inventory.EqumentList.Count; AtkP++) //AtkP의 값을 카운트만큼만들어서
                                        {
                                            if (inventory.EqumentList[EquementSetting - 1].OnEqument == true)  //장착하려고 한 장비가 장착중이라면
                                            {
                                                attackPoint -= inventory.EqumentList[EquementSetting - 1].State;  //공격력을 빼주고
                                                inventory.EqumentList[EquementSetting - 1].OnEqument = false;  //장착장비를 비활성화
                                            }
                                            else if (inventory.EqumentList[AtkP].EquementType == 1 && inventory.EqumentList[AtkP].OnEqument == true)// 활성화된 무기장비가있으면
                                            {
                                                attackPoint -= inventory.EqumentList[AtkP].State;  //공격력을 빼주고
                                                inventory.EqumentList[AtkP].OnEqument = false;  //무기아이템은 모두 비활성화
                                                attackPoint += inventory.EqumentList[EquementSetting - 1].State; //선택한 장비의 스테이터스를 더해주고
                                                inventory.EqumentList[EquementSetting - 1].OnEqument = true; //선택한 장비를 활성화한다
                                            }
                                            else
                                            {
                                                attackPoint += inventory.EqumentList[EquementSetting - 1].State; //선택한 장비의 스테이터스를 더해주고
                                                inventory.EqumentList[EquementSetting - 1].OnEqument = true; //선택한 장비를 활성화한다
                                            }
                                        }
                                    }
                                    else if (inventory.EqumentList[EquementSetting - 1].EquementType == 2) //내가 장착한 무기가 방어구라면
                                    {
                                        for (int DfsP = 0; DfsP < inventory.EqumentList.Count; DfsP++) //DfsP의 값을 카운트만큼만들어서
                                        {
                                            if (inventory.EqumentList[EquementSetting - 1].OnEqument == true)
                                            {
                                                shieldPoint -= inventory.EqumentList[EquementSetting - 1].State; //선택한 방어구의 스테이터스를 더해주고
                                                inventory.EqumentList[EquementSetting - 1].OnEqument = false; //선택한 장비를 활성화한다
                                            }
                                            else if (inventory.EqumentList[DfsP].EquementType == 2 && inventory.EqumentList[DfsP].OnEqument == true)// 활성화된 방어구장비가있으면
                                            {
                                                shieldPoint -= inventory.EqumentList[DfsP].State;  //방어력을 빼주고
                                                inventory.EqumentList[DfsP].OnEqument = false;  //방어구아이템은 모두 비활성화
                                                shieldPoint += inventory.EqumentList[EquementSetting - 1].State; //선택한 방어구의 스테이터스를 더해주고
                                                inventory.EqumentList[EquementSetting - 1].OnEqument = true; //선택한 장비를 활성화한다
                                            }
                                            else //아니라면
                                            {
                                                shieldPoint += inventory.EqumentList[EquementSetting - 1].State; //선택한 방어구의 스테이터스를 더해주고
                                                inventory.EqumentList[EquementSetting - 1].OnEqument = true; //선택한 장비를 활성화한다
                                            }
                                        }

                                    }

                                }
                                else
                                {
                                    Console.WriteLine("올바른 값을 입력해주세요");
                                    Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                    Console.ReadLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("올바른 값을 입력해주세요");
                                Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                Console.ReadLine();
                            }
                        }
                        break;
                    case "3":
                        //상점
                        Console.WriteLine("상점를 선택하셨습니다.");
                        Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                        Console.WriteLine("Gold: " + money);
                        Console.WriteLine("[아이템목록]");
                        shop.ShopWindow();
                        for (int j = 3; j > 2; j++)
                        {
                            Console.Clear();
                            Console.WriteLine("Gold : " + money);
                            shop.ShopWindow();
                            Console.WriteLine("1. 아이템 구매");
                            Console.WriteLine("2. 아이템 판매");
                            Console.WriteLine("0. 나가기");
                            Console.WriteLine("원하시는 행동을 입력해주세요.");

                            string SelWinOut = Console.ReadLine();

                            int OnSelWinOut = int.Parse(SelWinOut);

                            if (OnSelWinOut == 0)
                            {
                                Console.WriteLine("나가기");
                                j = 0;
                            }
                            else if (OnSelWinOut == 1)
                            {
                                for (int k = 3; k > 2; k++)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Gold : " + money);
                                    Console.WriteLine("구매를 원하시는 아이템을 선택해주세요.");
                                    shop.ShopWindow();
                                    Console.WriteLine("0. 나가기");
                                    string buy = Console.ReadLine();
                                    int buyitem = int.Parse(buy);
                                    if (buyitem == 0)
                                    {
                                        k = 0;
                                    }
                                    else
                                    {
                                        if (buyitem >= 1 && buyitem <= shop.equementshop.Count && shop.equementshop[buyitem - 1] != null)
                                        {
                                            if (shop.equementshop[buyitem - 1].HaveItem == true)
                                            {
                                                Console.WriteLine("이미 구입한 상품입니다.");
                                                Console.WriteLine("아무 숫자나 입력해주세요.");
                                                Console.ReadLine();
                                                k = 0;
                                            }
                                            else if (money >= shop.equementshop[buyitem - 1].EquementPrice)
                                            {
                                                shop.equementshop[buyitem - 1].HaveItem = true;
                                                inventory.AddEqument(shop.equementshop[buyitem - 1]);
                                                money -= shop.equementshop[buyitem - 1].EquementPrice;
                                                Console.WriteLine("구매가 완료되었습니다.");
                                                Console.WriteLine("아무 숫자나 입력해주세요.");
                                                Console.ReadLine();
                                                k = 0;
                                            }
                                            else if (money <= shop.equementshop[buyitem - 1].EquementPrice)
                                            {
                                                Console.WriteLine("골드가 모자랍니다.");
                                                Console.WriteLine("계속하시려면 아무숫자나 입력해주세요.");
                                                Console.ReadLine();
                                                k = 0;
                                            }
                                            else
                                            {
                                                Console.WriteLine("올바른 값을 입력해주세요");
                                                Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                                Console.ReadLine();
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("올바른 값을 입력해주세요");
                                            Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                            Console.ReadLine();
                                        }
                                    }
                                }

                            }
                            else if (OnSelWinOut == 2)
                            {
                                for (int k = 3; k > 2; k++)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Gold : " + money);
                                    Console.WriteLine("판매를 원하시는 아이템을 선택해주세요.");
                                    inventory.EqumentWindow();
                                    Console.WriteLine("0. 나가기");
                                    string sell = Console.ReadLine();
                                    int sellitem = int.Parse(sell);
                                    if (sellitem == 0)
                                    {
                                        k = 0;
                                    }
                                    else
                                    {
                                        if (sellitem >= 1 && sellitem <= inventory.EqumentList.Count && inventory.EqumentList[sellitem - 1] != null)
                                        {
                                           
                                            inventory.EqumentList[sellitem - 1].HaveItem = false;
                                            money += (inventory.EqumentList[sellitem - 1].EquementPrice * 85 / 100);
                                            inventory.RemoveEqument(inventory.EqumentList[sellitem - 1]);
                                            Console.WriteLine("판매가 완료되었습니다.");
                                            Console.WriteLine("Gold : " + money);
                                            Console.WriteLine("계속하시려면 아무숫자나 입력해주세요.");
                                            Console.ReadLine();
                                            k = 0;
                                        }
                                        else
                                        {
                                            Console.WriteLine("올바른 값을 입력해주세요");
                                            Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                            Console.ReadLine();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("올바른 값을 입력해주세요");
                                Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                Console.ReadLine();
                            }
                        }
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("휴식하기를 선택하셨습니다.");
                        Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다. 보유골드 : {money} G");
                        Console.WriteLine("1. 휴식하기");
                        Console.WriteLine("0. 나가기");
                        string Bed = Console.ReadLine();

                        int Bedout = int.Parse(Bed);

                        for (int j = 3; j > 2; j++)
                        {
                            if (Bedout == 0)
                            {
                                Console.WriteLine("나가기");
                                Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                Console.ReadLine();
                                j = 0;
                            }
                            else if (Bedout == 1)
                            {
                                if (money >= 500)
                                {
                                    money -= 500;
                                    playerHP = 100;
                                    Console.WriteLine($"휴식을 완료했습니다. 남은골드 : {money}");
                                    Console.WriteLine("아무 숫자나 입력해주세요.");
                                    Console.ReadLine();
                                    j = 0;
                                }
                                else
                                {
                                    Console.WriteLine("Gold가 부족합니다.");
                                    Console.WriteLine("아무 숫자나 입력해주세요.");
                                    Console.ReadLine();
                                    j = 0;
                                }
                            }
                            else
                            {

                                Console.WriteLine("올바른 값을 입력해주세요.");
                                Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                Console.ReadLine();
                                j = 0;
                            }
                        }
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("던전입장을 선택하셨습니다.");
                        Console.WriteLine("던전의 난이도를 설정해주세요");
                        Console.WriteLine($"남은 체력: {playerHP} Gold : {money}");
                        Console.WriteLine("1.쉬움 권장방어력: 없음");
                        Console.WriteLine("2.보통 권장방어력: 5");
                        Console.WriteLine("3.어려움 권장방어력: 7");
                        Console.WriteLine("0. 나가기");
                        Console.WriteLine("경고 : 던전입장시 권장 방어력보다 낮다면 실패할 수 있습니다.");
                        
                        string dungeon = Console.ReadLine();
                        int Indungeon = int.Parse(dungeon);

                        for (int k = 3; k > 2; k++)
                        {
                            if (Indungeon == 0)
                            {
                                k = 0;
                            }
                            else if (Indungeon == 1)
                            {
                                int Easy = new Random().Next(20 - shieldPoint, 35 - shieldPoint);
                                playerHP -= Easy;
                                if (playerHP > 0)
                                {
                                    int BonusGold = new Random().Next(10, 21);
                                    money += 1000 + (1000 *(BonusGold/100));
                                    level++;
                                    Console.WriteLine("던전을 클리어 하셨습니다");
                                    Console.WriteLine($"레벨업! Lv.{level} 남은 체력: {playerHP} Gold : {money}");
                                    Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                    Console.ReadLine();
                                    k = 0;
                                }
                                else
                                {
                                    playerHP = 1;
                                    Console.WriteLine("던전에 실패하셨습니다.");
                                    Console.WriteLine($"남은 체력: {playerHP} Gold : {money}");
                                    Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                    k = 0;
                                }
                            }
                            else if (Indungeon == 2)
                            {
                                if (shieldPoint >= 5)
                                {
                                    int Nomal = new Random().Next(20 + (5 - shieldPoint), 35 + (5 - shieldPoint));
                                    playerHP -= Nomal;
                                    if (playerHP > 0)
                                    {
                                        int BonusGold = new Random().Next(15, 31);
                                        money += 1700 + (1700 * (BonusGold / 100));
                                        level++;
                                        Console.WriteLine("던전을 클리어 하셨습니다");
                                        Console.WriteLine($"레벨업! Lv.{level} 남은 체력: {playerHP} Gold : {money}");
                                        Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                        Console.ReadLine();
                                        k = 0;
                                    }
                                    else
                                    {
                                        playerHP = 1;
                                        Console.WriteLine("던전에 실패하셨습니다.");
                                        Console.WriteLine($"남은 체력: {playerHP} Gold : {money}");
                                        Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                        k = 0;
                                    }
                                }
                                else
                                {
                                    int DungeonFail = new Random().Next(1, 101);
                                    if (DungeonFail > 60)
                                    {
                                        playerHP = 1;
                                        Console.WriteLine("던전에 실패하셨습니다.");
                                        Console.WriteLine($"남은 체력: {playerHP} Gold : {money}");
                                        Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                        k = 0;
                                    }
                                    else
                                    {
                                        int Nomal = new Random().Next(20 + (5 - shieldPoint), 35 + (5 - shieldPoint));
                                        playerHP -= Nomal;
                                        if (playerHP > 0)
                                        {
                                            int BonusGold = new Random().Next(15, 31);
                                            money += 1700 + (1700 * (BonusGold / 100));
                                            level++;
                                            Console.WriteLine("던전을 클리어 하셨습니다");
                                            Console.WriteLine($"레벨업! Lv. {level}  남은 체력: {playerHP} Gold : {money}");
                                            Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                            Console.ReadLine();
                                            k = 0;
                                        }
                                        else
                                        {
                                            playerHP = 1;
                                            Console.WriteLine("던전에 실패하셨습니다.");
                                            Console.WriteLine($"남은 체력: {playerHP} Gold : {money}");
                                            Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                            k = 0;
                                        }
                                    }
                                }
                            }
                            else if (Indungeon == 3)
                            {
                                if (shieldPoint > 7)
                                {
                                    int Hard = new Random().Next(20 + (7 - shieldPoint), 35 + (7 - shieldPoint));
                                    playerHP -= Hard;
                                    if (playerHP > 0)
                                    {
                                        int BonusGold = new Random().Next(20, 41);
                                        money += 2500 + (2500 * (BonusGold / 100));
                                        level++;
                                        Console.WriteLine("던전을 클리어 하셨습니다");
                                        Console.WriteLine($"레벨업! Lv. {level}  남은 체력: {playerHP} Gold : {money}");
                                        Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                        Console.ReadLine();
                                        k = 0;
                                    }
                                    else
                                    {
                                        playerHP = 1;
                                        Console.WriteLine("던전에 실패하셨습니다.");
                                        Console.WriteLine($"남은 체력: {playerHP} Gold : {money}");
                                        Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                        k = 0;
                                    }
                                }
                                else
                                {
                                    int DungeonFail = new Random().Next(1, 101);
                                    if (DungeonFail > 60)
                                    {
                                        playerHP = 1;
                                        Console.WriteLine("던전에 실패하셨습니다.");
                                        Console.WriteLine($"남은 체력: {playerHP} Gold : {money}");
                                        Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                        k = 0;
                                    }
                                    else
                                    {
                                        int Nomal = new Random().Next(20 + (7 - shieldPoint), 35 + (7 - shieldPoint));
                                        playerHP -= Nomal;
                                        if (playerHP > 0)
                                        {
                                            int BonusGold = new Random().Next(20, 41);
                                            money += 2500 + (2500 * (BonusGold / 100));
                                            level++;
                                            Console.WriteLine("던전을 클리어 하셨습니다");
                                            Console.WriteLine($"레벨업! Lv. {level}  남은 체력: {playerHP} Gold : {money}");
                                            Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                            Console.ReadLine();
                                            k = 0;
                                        }
                                        else
                                        {
                                            playerHP = 1;
                                            Console.WriteLine("던전에 실패하셨습니다.");
                                            Console.WriteLine($"남은 체력: {playerHP} Gold : {money}");
                                            Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                            k = 0;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("올바른 값을 입력해주세요.");
                                Console.WriteLine("계속하시려면 아무숫자나 입력해주세요");
                                Console.ReadLine();
                                k = 0;
                            }


                        }


                            break;
                    default:
                        Console.WriteLine("올바른 값을 입력해주세요.");
                        break;
                }


            }



        }





    }
}
