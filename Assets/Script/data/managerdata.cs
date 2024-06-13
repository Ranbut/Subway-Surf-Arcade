using UnityEngine;
using System.Collections;
/// <summary>
///  class quản toàn bộ lý dữ liệu
///  các item bua bán 
///  
/// </summary>
public class managerdata : MonoBehaviour {
   public static int play;
    public static int key; // key hồi sinh
    public static int coin;
    public static int coinmoney; // điểm đường đi
	public static int credits;

	public static string highscoreName1;
	public static string highscoreName2;
	public static string highscoreName3;
	public static string highscoreName4;
	public static string highscoreName5;
	public static string highscoreName6;
	public static int highscoreScore1;
	public static int highscoreScore2;
	public static int highscoreScore3;
	public static int highscoreScore4;
	public static int highscoreScore5;
	public static int highscoreScore6;
	public static int registryIN;
	public static int registryOUT;

    public static managerdata manager;
    void Awake()
    {
      //  PlayerPrefs.DeleteAll();
        loaddata();
        play = 1;
        manager = this;
        loadatalvitem();
        loaditemvan();
        Datacharacter();
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("coinmuving", 0);
        PlayerPrefs.Save();
		manager.setkey(3);
    }

    private void GetAllachievement()
    {

    }
    /// <summary>
    /// kiểm tra và load lưu key dữ liệu cho lần chơi đầu tiên tên các key điểm
    /// </summary>
    private void loaddata()
    {
        if (PlayerPrefs.HasKey("key") == false)
        {
            PlayerPrefs.SetInt("key", 0);
            PlayerPrefs.Save();
        }
      
        if (PlayerPrefs.HasKey("coin") == false)
        {
            PlayerPrefs.SetInt("coin", 0);
            PlayerPrefs.Save();
        }
       
        if (PlayerPrefs.HasKey("coinmuving") == false)
        {
            PlayerPrefs.SetInt("coinmuving", 0);
            PlayerPrefs.Save();
        }

		if (PlayerPrefs.HasKey("credits") == false)
		{
			PlayerPrefs.SetInt("credits", 0);
			PlayerPrefs.Save();
		}

		if (PlayerPrefs.HasKey("highscoreName1") == false)
		{
			PlayerPrefs.SetString("highscoreName1", "ANDRE");
			PlayerPrefs.Save();
		}

		if (PlayerPrefs.HasKey("highscoreName2") == false)
		{
			PlayerPrefs.SetString("highscoreName2", "PAULO");
			PlayerPrefs.Save();
		}

		if (PlayerPrefs.HasKey("highscoreName3") == false)
		{
			PlayerPrefs.SetString("highscoreName3", "ANA");
			PlayerPrefs.Save();
		}

		if (PlayerPrefs.HasKey("highscoreName4") == false)
		{
			PlayerPrefs.SetString("highscoreName4", "PEDRO");
			PlayerPrefs.Save();
		}

		if (PlayerPrefs.HasKey("highscoreName5") == false)
		{
			PlayerPrefs.SetString("highscoreName5", "CARLOS");
			PlayerPrefs.Save();
		}

		if (PlayerPrefs.HasKey("highscoreName6") == false)
		{
			PlayerPrefs.SetString("highscoreName6", "MATHEUS");
			PlayerPrefs.Save();
		}

		if (PlayerPrefs.HasKey("highscoreScore1") == false)
		{
			PlayerPrefs.SetInt("highscoreScore1", 1500);
			PlayerPrefs.Save();
		}

		if (PlayerPrefs.HasKey("highscoreScore2") == false)
		{
			PlayerPrefs.SetInt("highscoreScore2", 1400);
			PlayerPrefs.Save();
		}

		if (PlayerPrefs.HasKey("highscoreScore3") == false)
		{
			PlayerPrefs.SetInt("highscoreScore3", 1300);
			PlayerPrefs.Save();
		}

		if (PlayerPrefs.HasKey("highscoreScore4") == false)
		{
			PlayerPrefs.SetInt("highscoreScore4", 1200);
			PlayerPrefs.Save();
		}

		if (PlayerPrefs.HasKey("highscoreScore5") == false)
		{
			PlayerPrefs.SetInt("highscoreScore5", 1100);
			PlayerPrefs.Save();
		}

		if (PlayerPrefs.HasKey("highscoreScore6") == false)
		{
			PlayerPrefs.SetInt("highscoreScore6", 1000);
			PlayerPrefs.Save();
		}

		if (PlayerPrefs.HasKey("registryIN") == false)
		{
			PlayerPrefs.SetInt("registry", 0);
			PlayerPrefs.Save();
		}
			
		if (PlayerPrefs.HasKey("registryOUT") == false)
		{
			PlayerPrefs.SetInt("registryOUT", 0);
			PlayerPrefs.Save();
		}

        if (PlayerPrefs.HasKey("van") == false)
        {
            PlayerPrefs.SetInt("van", 0);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("setting") == false)
        {
            PlayerPrefs.SetInt("setting", 1);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("fly") == false)
        {
            PlayerPrefs.SetInt("fly", 0);
            PlayerPrefs.Save();
        }
       
    }
    /// <summary>
    /// tên các item mua
    /// </summary>
    private void loadatalvitem()
    {
        //  lv item bay
        if (PlayerPrefs.HasKey("itemfly") == false)
        {
            PlayerPrefs.SetInt("itemfly", 0);
            PlayerPrefs.Save();
        }
        //  lv item giày
        if (PlayerPrefs.HasKey("giay") == false)
        {
            PlayerPrefs.SetInt("giay", 0);
            PlayerPrefs.Save();
        }
        //  lv item hút coin
        if (PlayerPrefs.HasKey("magnet") == false)
        {
            PlayerPrefs.SetInt("magnet", 0);
            PlayerPrefs.Save();
        }
        //  lv item hút coin
        if (PlayerPrefs.HasKey("x2") == false)
        {
            PlayerPrefs.SetInt("x2", 0);
            PlayerPrefs.Save();
        }
    }
    /// <summary>
    /// tên các key ván trượt mua
    /// </summary>
    private void loaditemvan()
    {
        if (PlayerPrefs.HasKey("vanchinh") == false)
        {
            PlayerPrefs.SetInt("vanchinh", 1);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("vantron") == false)
        {
            PlayerPrefs.SetInt("vantron", 0);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("vancamap") == false)
        {
            PlayerPrefs.SetInt("vancamap", 0);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("selectedvan") == false)
        {
            PlayerPrefs.SetString("selectedvan", "vanchinh");
            PlayerPrefs.Save();
           
        }
    }

    /// <summary>
    /// lưu các character đang sử dụng và đẻ mua bán
    /// </summary>
    private void Datacharacter()
    {
        if (PlayerPrefs.HasKey("nvchinh") == false)
        {
            PlayerPrefs.SetInt("nvchinh", 0);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("nvgirl") == false)
        {
            PlayerPrefs.SetInt("nvgirl", 1);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("nvgau") == false)
        {
            PlayerPrefs.SetInt("nvgau", 0);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("nowcharacter") == false)
        {
            PlayerPrefs.SetString("nowcharacter", "nvgirl");
            PlayerPrefs.Save();
        }
    }

    // các hàm truy vấn dữ liệu mua bán character
    //-------------------------------------------------------------------------------------------
   
    /// <summary>
    /// lấy dữ liệu tên character đang sử dụng
    /// </summary>
    /// <returns></returns>
      public string Getnowcharacter()
    {
        return PlayerPrefs.GetString("nowcharacter");
    }
    /// <summary>
    /// lưu dữ liệu character đang sử dụng
    /// </summary>
    /// <param name="value"></param>
    public void Setnowcharacter(string value)
    {
        PlayerPrefs.SetString("nowcharacter", value);
        PlayerPrefs.Save();
    }
    /// <summary>
    /// lấy dữ liệu character chính
    /// </summary>
    /// <returns></returns>
    public int GetCharacternvchinh()
    {
        return PlayerPrefs.GetInt("nvchinh");
    }
    /// <summary>
    /// lưu dữ liệu character chính
    /// </summary>
    /// <param name="value"></param>
    public void SetCharacternvchinh(int value)
    {
         PlayerPrefs.SetInt("nvchinh", value);
         PlayerPrefs.Save();
    }

    /// <summary>
    /// lấy dữ liệu character nữ
    /// </summary>
    /// <returns></returns>
    public int GetCharacternvgirl()
    {
        return PlayerPrefs.GetInt("nvgirl");
    }
    /// <summary>
    /// lưu dữ liệu character nữ
    /// </summary>
    /// <param name="value"></param>
    public void SetCharacternvgirl(int value)
    {
        PlayerPrefs.SetInt("nvgirl", value);
        PlayerPrefs.Save();
    }
    /// <summary>
    /// lấy dữ liệu character gấu
    /// </summary>
    /// <returns></returns>
    public int GetCharacternvGau()
    {
        return PlayerPrefs.GetInt("nvgau");
    }
    /// <summary>
    /// lưu dữ liệu character nữ
    /// </summary>
    /// <param name="value"></param>
    public void SetCharacternvGau(int value)
    {
        PlayerPrefs.SetInt("nvgau", value);
        PlayerPrefs.Save();
    }

    //-------------------------------------------------------------------------------------------



    // các hàm truy vấn dữ liệu mua bán ván trượt
    //-------------------------------------------------------------------------------------------

    /// <summary>
    /// lấy dữ liệ ván hiện t
    /// </summary>
    /// <returns></returns>
    public string Getvanuser()
    {
        return PlayerPrefs.GetString("selectedvan");
    }
    /// <summary>
    /// lưu dữ liệu ván hiện tại
    /// </summary>
    /// <returns></returns>
    public void Savevanuser(string value)
    {
        PlayerPrefs.SetString("selectedvan", value);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// lấy dữ liệu ván chính
    /// </summary>
    /// <returns></returns>
    public int Getvanchinh()
    {
        return PlayerPrefs.GetInt("vanchinh");
    }
    /// <summary>
    /// lưu dữ liệu ván chính
    /// </summary>
    /// <returns></returns>
    public void Savevanchinh(int value)
    {
        PlayerPrefs.SetInt("vanchinh", value);
        PlayerPrefs.Save();
    }
    /// <summary>
    /// lấy dữ liệu ván hình tròn
    /// </summary>
    /// <returns></returns>
    public int Getvantron()
    {
        return PlayerPrefs.GetInt("vantron");
    }
    /// <summary>
    /// lưu dữ liệu ván tròn
    /// </summary>
    /// <returns></returns>
    public void Savevantron(int value)
    {
        PlayerPrefs.SetInt("vantron", value);
        PlayerPrefs.Save();
    }
    /// <summary>
    /// lấy dữ liệu ván hình cá mập
    /// </summary>
    /// <returns></returns>
    public int Getvancamap()
    {
        return PlayerPrefs.GetInt("vancamap");
    }
    /// <summary>
    /// lưu dữ liệu ván cá mập
    /// </summary>
    /// <returns></returns>
    public void Savevancamap(int value)
    {
        PlayerPrefs.SetInt("vancamap", value);
        PlayerPrefs.Save();
    }

    //-------------------------------------------------------------------------------------------


    //--------------------------------------------------------------------------------------------------



    /// <summary>
    ///  lưu mua dữ liệu lvitem x2 coin
    /// </summary>
    /// <returns></returns>
    public void SaveDataItemX2(int value)
    {
        PlayerPrefs.SetInt("x2", (PlayerPrefs.GetInt("x2") + value));
        PlayerPrefs.Save();
    }

    /// <summary>
    ///  lấy dữ liệu lvitem x2  coin
    /// </summary>
    /// <returns></returns>
    public int GetDataItemX2()
    {

        return PlayerPrefs.GetInt("x2");
    }




    //--------------------------------------------------------------------------------------------------



    /// <summary>
    ///  lưu mua dữ liệu lvitem hút coin
    /// </summary>
    /// <returns></returns>
    public void SaveDataItemMagnet(int value)
    {
        // return PlayerPrefs.GetInt("itemfly");
        PlayerPrefs.SetInt("magnet", (PlayerPrefs.GetInt("magnet") + value));
        PlayerPrefs.Save();
    }

    /// <summary>
    ///  lấy dữ liệu lvitem hút coin
    /// </summary>
    /// <returns></returns>
    public int GetDataItemMagnet()
    {
        return PlayerPrefs.GetInt("magnet");
    }





    //--------------------------------------------------------------------------------------------------



    /// <summary>
    ///  lưu mua dữ liệu lvitem giày
    /// </summary>
    /// <returns></returns>
    public void SaveDataItemGiay(int value)
    {
        // return PlayerPrefs.GetInt("itemfly");
        PlayerPrefs.SetInt("giay", (PlayerPrefs.GetInt("giay") + value));
        PlayerPrefs.Save();
    }

    /// <summary>
    ///  lấy dữ liệu lvitem giày
    /// </summary>
    /// <returns></returns>
    public int GetDataItemGiay()
    {
        return PlayerPrefs.GetInt("giay");
    }




    //--------------------------------------------------------------------------------------------------

    /// <summary>
    ///  lưu mua dữ liệu lvitem bay
    /// </summary>
    /// <returns></returns>
    public void SaveDataItemFly(int value)
    {
       // return PlayerPrefs.GetInt("itemfly");
        PlayerPrefs.SetInt("itemfly", (PlayerPrefs.GetInt("itemfly") + value));
        PlayerPrefs.Save();
    }

    /// <summary>
    ///  lấy dữ liệu lvitem bay
    /// </summary>
    /// <returns></returns>
    public int GetDataItemFly()
    {
        return PlayerPrefs.GetInt("itemfly");
    }

    //----------------------------------------------------------------------------------------------------

    /// <summary>
    /// lấy dữ liệu giá bán item 
    /// </summary>
    /// <returns></returns>
    public int Getprice(int valuelv)
    {
        int price = 0;

        switch (valuelv)
        {
            case 0:
                price = 500;
                break;
            case 1:
                price = 1500;
                break;
            case 2:
                price = 3000;
                break;
            case 3:
                price = 10000;
                break;
            case 4:
                price = 30000;
                break;
            case 5:
                price = 100000;
                break;

            default:
                break;
        }
        return price;

    }


    //----------------------------------------------------------------------------------------------------
    /// <summary>
    /// lấy item fly
    /// </summary>
    /// <returns></returns>
    public int GetFly()
    {
        return PlayerPrefs.GetInt("fly");

    }

    /// <summary>
    /// lưu item bay
    /// </summary>
    /// <param name="value"></param>
    public void SaveFly(int value)
    {
        PlayerPrefs.SetInt("fly", (PlayerPrefs.GetInt("fly") + value));
        PlayerPrefs.Save();
    }


    //----------------------------------------------------------------------------------------------------
    /// <summary>
    ///  lưu cài đặt
    /// </summary>
    /// <param name="value"> </param>
    public void savesetting(int value)
    {
        PlayerPrefs.SetInt("setting", value);
        PlayerPrefs.Save();
    }


    /// <summary>
    ///  lấy lưu cài đặt
    /// </summary>
    /// <param name="value"> </param>
    public int getsetting()
    {
        return PlayerPrefs.GetInt("setting");

    }

    //----------------------------------------------------------------------------------------------------

    /// <summary>
    ///  lưu số ván trượt
    /// </summary>
    /// <param name="value"></param>
    public void savevan(int value)
    {
        PlayerPrefs.SetInt("van", (PlayerPrefs.GetInt("van") + value));
        PlayerPrefs.Save();
    }

    /// <summary>
    /// lấy ván trượt
    /// </summary>
    /// <returns></returns>
    public int getvan()
    {
        return PlayerPrefs.GetInt("van");
    }

    //----------------------------------------------------------------------------------------------------

    /// <summary>
    /// lưu key khi va chạm có thêm key
    /// </summary>
    /// <param name="value"></param>
    public void savekey(int value)
    {
        PlayerPrefs.SetInt("key", (PlayerPrefs.GetInt("key") + value));
        PlayerPrefs.Save();

    }

	public void saveCredits(int value)
	{
		PlayerPrefs.SetInt("credits", (PlayerPrefs.GetInt("credits") + value));
		PlayerPrefs.Save();

	}

	public void saveHighscoreName(int index, string value)
	{
		PlayerPrefs.SetString("highscoreName" + index, value);
		PlayerPrefs.Save();

	}

	public void saveHighscoreScore(int index, int value)
	{
		PlayerPrefs.SetInt("highscoreScore" + index, (PlayerPrefs.GetInt("highscoreScore" + index) + value));
		PlayerPrefs.Save();
	}

	public void saveRegistryIN(int value)
	{
		PlayerPrefs.SetInt("registryIN", (PlayerPrefs.GetInt("registryIN") + value));
		PlayerPrefs.Save();
	}

	public void saveRegistryOUT(int value)
	{
		PlayerPrefs.SetInt("registryOUT", (PlayerPrefs.GetInt("registryOUT") + value));
		PlayerPrefs.Save();
	}

    /// <summary>
    /// lấy key
    /// </summary>
    /// <returns></returns>
    public int getkey()
    {
        return PlayerPrefs.GetInt("key");
    }

	public int getCredits()
	{
		return PlayerPrefs.GetInt("credits");
	}
		
	public string getHighscoreName(int index)
	{
		return PlayerPrefs.GetString ("highscoreName" + index);
	}
		
	public int getHighscoreScore(int index)
	{
		return PlayerPrefs.GetInt ("highscoreScore" + index);
	}
		
	public int getRegistryIN()
	{
		return PlayerPrefs.GetInt ("registryIN");
	}

	public int getRegistryOUT()
	{
		return PlayerPrefs.GetInt ("registryOUT");
	}

	public void setkey(int quantity)
	{
		PlayerPrefs.SetInt("key", quantity);
	}

	public void setCredits(int quantity)
	{
		PlayerPrefs.SetInt("credits", quantity);
	}

	public void setHighscoreName(int index, string value)
	{
		PlayerPrefs.SetString("highscoreName" + index, value);
	}
		
	public void setHighscoreScore(int index, int value)
	{
		PlayerPrefs.SetInt("highscoreScore" + index, value);
	}

    //----------------------------------------------------------------------------------------------------


    /// <summary>
    /// lưu điểm coin
    /// </summary>
    /// <param name="coin"></param>
    public void savecoin(int coin)
    {
        PlayerPrefs.SetInt("coin", (PlayerPrefs.GetInt("coin")+ coin));
        PlayerPrefs.Save();
    }


    /// <summary>
    /// lấy điểm coin
    /// </summary>
    /// <returns></returns>
    public int Getcoin()
    {
        return PlayerPrefs.GetInt("coin");
    }

    //----------------------------------------------------------------------------------------------------

    /// <summary>
    /// lưu điểm quãng đường đã đi nếu điểm hiện tại lớn hơn điểm max
    /// </summary>
    /// <param name="maxmuving"></param>
    public void savemuving(int maxmuving)
    {
        if (maxmuving >PlayerPrefs.GetInt("coinmuving"))
        {
            PlayerPrefs.SetInt("coinmuving", maxmuving);
            PlayerPrefs.Save();
        }
    }



    /// <summary>
    /// lấy điểm đường đi
    /// </summary>
    /// <returns></returns>
    public int getmuving()
    {
        return PlayerPrefs.GetInt("coinmuving");
    }
 
	public void deleteHighscoreScore(int index)
	{
		PlayerPrefs.DeleteKey("highscoreScore" + index);
		PlayerPrefs.Save();
	}

}


