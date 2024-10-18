using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class GameControl : MonoBehaviour
{
    public Camera MyCamera;
    public Transform A4, A5, A6, B4, B5, B6, C4, C5, C6, D4, D5, D6, E4, E5, E6, F4, F5, F6, G4, G5, G6, H4, H5, H6;
    public Transform A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z;
    public List<Transform> Col1 = new List<Transform>();
    public List<Transform> Col2 = new List<Transform>();
    public List<Transform> Col3 = new List<Transform>();
    public List<Transform> Col4 = new List<Transform>();
    public List<Transform> Col5 = new List<Transform>();
    public List<Transform> Col6 = new List<Transform>();
    public List<Transform> Col7 = new List<Transform>();
    public List<Transform> Col8 = new List<Transform>();
    public List<List<Transform>> Cols = new List<List<Transform>>();
    public List<Transform> Row1 = new List<Transform>();
    public List<Transform> Row2 = new List<Transform>();
    public List<Transform> Row3 = new List<Transform>();
    public List<List<Transform>> Rows = new List<List<Transform>>();
    List<Sprite> currentWordSprites = new List<Sprite>();
    List<Sprite> currentBackgroundWordSprites = new List<Sprite>();
    public static List<string> currentWordFairyAnimations = new List<string>();
    List<string> currentWords = new List<string>();
    List<string> currentEffectsWords = new List<string>();
    string currentWord;
    IDictionary<string, Sprite> wordImages = new Dictionary<string, Sprite>();
    public static List<DictionaryLookup> dictionaryLookupsList = new List<DictionaryLookup>();

    string word;
    char[] board;

    // public Image centerWordImage, leftWordImage, rightWordImage, backgroundWordImage;

    public SpriteRenderer foregroundImage, backgroundImage;

    Sprite catSprite, dogSprite, bearSprite, frogSprite, goatSprite, duckSprite, snakeSprite, mouseSprite, horseSprite, tigerSprite, zebraSprite, lizardSprite, donkeySprite, monkeySprite, wolfSprite, batSprite, camelSprite, chickenSprite, dolphinSprite, sharkSprite, forestSprite;
    Sprite motherSprite, sisterSprite, familySprite;

    // prefabs for word elements

    public GameObject fairy;
    public List<GameObject> prefabs = new List<GameObject>();

    public Animator fairyAnimator;

    public ParticleSystem weatherCreator;
    List<DictionaryLookup> dictionaryLookups = new List<DictionaryLookup>();


    void Start()
    {
        Col1.Add(A4);
        Col1.Add(A5);
        Col1.Add(A6);
        Col2.Add(B4);
        Col2.Add(B5);
        Col2.Add(B6);
        Col3.Add(C4);
        Col3.Add(C5);
        Col3.Add(C6);
        Col4.Add(D4);
        Col4.Add(D5);
        Col4.Add(D6);
        Col5.Add(E4);
        Col5.Add(E5);
        Col5.Add(E6);
        Col6.Add(F4);
        Col6.Add(F5);
        Col6.Add(F6);
        Col7.Add(G4);
        Col7.Add(G5);
        Col7.Add(G6);
        Col8.Add(H4);
        Col8.Add(H5);
        Col8.Add(H6);

        Cols.Add(Col1);
        Cols.Add(Col2);
        Cols.Add(Col3);
        Cols.Add(Col4);
        Cols.Add(Col5);
        Cols.Add(Col6);
        Cols.Add(Col7);
        Cols.Add(Col8);

        Row1.Add(A4);
        Row1.Add(B4);
        Row1.Add(C4);
        Row1.Add(D4);
        Row1.Add(E4);
        Row1.Add(F4);
        Row1.Add(G4);
        Row1.Add(H4);

        Row2.Add(A5);
        Row2.Add(B5);
        Row2.Add(C5);
        Row2.Add(D5);
        Row2.Add(E5);
        Row2.Add(F5);
        Row2.Add(G5);
        Row2.Add(H5);

        Row3.Add(A6);
        Row3.Add(B6);
        Row3.Add(C6);
        Row3.Add(D6);
        Row3.Add(E6);
        Row3.Add(F6);
        Row3.Add(G6);
        Row3.Add(H6);

        Rows.Add(Row1);
        Rows.Add(Row2);
        Rows.Add(Row3);

        // ClearImage(centerWordImage);
        // ClearImage(leftWordImage);
        // ClearImage(rightWordImage);     

        // Load wordImages list from the database lookup table. Maybe remove this step sometime
        // foreach (var dictionaryLookup in dictionaryLookups)
        // {
        //     wordImages.Add(dictionaryLookup.Key, Resources.Load<Sprite>("Images/Animals/" + dictionaryLookup.Value));
        // }

        //   foreach (var dictionaryLookup in dictionaryLookupsList)
        //  {
        //      wordImages.Add(dictionaryLookup.Name, Resources.Load<Sprite>("Images/Animals/" + dictionaryLookup.Sprite));
        //  }

        var cat = new DictionaryLookup
        {
            Id = 1,
            Name = "CAT",
            Sprite = "catSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(cat);

        var dog = new DictionaryLookup
        {
            Id = 2,
            Name = "DOG",
            Sprite = "dogSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(dog);

        var bear = new DictionaryLookup
        {
            Id = 3,
            Name = "BEAR",
            Sprite = "bearSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(bear);

        var frog = new DictionaryLookup
        {
            Id = 4,
            Name = "FROG",
            Sprite = "frogSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(frog);

        var mouse = new DictionaryLookup
        {
            Id = 5,
            Name = "MOUSE",
            Sprite = "mouseSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(mouse);

        var horse = new DictionaryLookup
        {
            Id = 6,
            Name = "HORSE",
            Sprite = "horseSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(horse);

        var bat = new DictionaryLookup
        {
            Id = 7,
            Name = "BAT",
            Sprite = "batSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(bat);

        var duck = new DictionaryLookup
        {
            Id = 8,
            Name = "DUCK",
            Sprite = "duckSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(duck);

        var snake = new DictionaryLookup
        {
            Id = 9,
            Name = "SNAKE",
            Sprite = "snakeSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(snake);

        var camel = new DictionaryLookup
        {
            Id = 10,
            Name = "CAMEL",
            Sprite = "camelSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(camel);

        var dolphin = new DictionaryLookup
        {
            Id = 11,
            Name = "DOLPHIN",
            Sprite = "dolphinSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(dolphin);

        var donkey = new DictionaryLookup
        {
            Id = 12,
            Name = "DONKEY",
            Sprite = "donkeySprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(donkey);

        var goat = new DictionaryLookup
        {
            Id = 13,
            Name = "GOAT",
            Sprite = "goatSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(goat);

        var lizard = new DictionaryLookup
        {
            Id = 14,
            Name = "LIZARD",
            Sprite = "lizardSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(lizard);

        var shark = new DictionaryLookup
        {
            Id = 15,
            Name = "SHARK",
            Sprite = "sharkSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(shark);

        var tiger = new DictionaryLookup
        {
            Id = 16,
            Name = "TIGER",
            Sprite = "tigerSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(tiger);

        var wolf = new DictionaryLookup
        {
            Id = 17,
            Name = "WOLF",
            Sprite = "wolfSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(wolf);

        var zebra = new DictionaryLookup
        {
            Id = 18,
            Name = "ZEBRA",
            Sprite = "zebraSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(zebra);

        var hi = new DictionaryLookup
        {
            Id = 19,
            Name = "HI",
            Sprite = "isHi",
            isFairy = true,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(hi);

        var jump = new DictionaryLookup
        {
            Id = 20,
            Name = "JUMP",
            Sprite = "isJump",
            isFairy = true,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(jump);

        var chicken = new DictionaryLookup
        {
            Id = 21,
            Name = "CHICKEN",
            Sprite = "chickenSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(chicken);

        var pepper = new DictionaryLookup
        {
            Id = 22,
            Name = "PEPPER",
            Sprite = "pepperSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(pepper);

        var sister = new DictionaryLookup
        {
            Id = 23,
            Name = "SISTER",
            Sprite = "sisterSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(sister);

        var family = new DictionaryLookup
        {
            Id = 24,
            Name = "FAMILY",
            Sprite = "familySprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(family);

        var mother = new DictionaryLookup
        {
            Id = 25,
            Name = "MOTHER",
            Sprite = "motherSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(mother);

        var planet = new DictionaryLookup
        {
            Id = 26,
            Name = "PLANET",
            Sprite = "planetSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(planet);

        var avocado = new DictionaryLookup
        {
            Id = 27,
            Name = "AVOCADO",
            Sprite = "avocadoSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(avocado);

        var peas = new DictionaryLookup
        {
            Id = 28,
            Name = "PEAS",
            Sprite = "peasSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(peas);

        var eggplant = new DictionaryLookup
        {
            Id = 29,
            Name = "EGGPLANT",
            Sprite = "eggplantSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(eggplant);

        var garlic = new DictionaryLookup
        {
            Id = 30,
            Name = "GARLIC",
            Sprite = "garlicSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(garlic);

        var mushrooms = new DictionaryLookup
        {
            Id = 31,
            Name = "MUSHROOMS",
            Sprite = "mushroomsSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(mushrooms);

        var pumpkin = new DictionaryLookup
        {
            Id = 32,
            Name = "MUSHROOMS",
            Sprite = "pumpkinSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(pumpkin);

        var tomato = new DictionaryLookup
        {
            Id = 33,
            Name = "TOMATO",
            Sprite = "tomatoSprite",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(tomato);

        var academy = new DictionaryLookup
        {
            Id = 34,
            Name = "ACADEMY",
            Sprite = "academySprite",
            isFairy = false,
            isBackground = true,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(academy);

        var hello = new DictionaryLookup
        {
            Id = 35,
            Name = "HELLO",
            Sprite = "isHello",
            isFairy = true,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(hello);

        var tree = new DictionaryLookup
        {
            Id = 36,
            Name = "TREE",
            Sprite = "treeSprite",
            isFairy = false,
            isBackground = true,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(tree);

        var flip = new DictionaryLookup
        {
            Id = 37,
            Name = "FLIP",
            Sprite = "isFlip",
            isFairy = false,
            isBackground = false,
            isCommand = true,
            isEffect = false
        };
        dictionaryLookups.Add(flip);

        var rain = new DictionaryLookup
        {
            Id = 38,
            Name = "RAIN",
            Sprite = "isRain",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = true
        };
        dictionaryLookups.Add(rain);

        var delete = new DictionaryLookup
        {
            Id = 39,
            Name = "DELETE",
            Sprite = "isDelete",
            isFairy = false,
            isBackground = false,
            isCommand = true,
            isEffect = false
        };
        dictionaryLookups.Add(delete);

        var down = new DictionaryLookup
        {
            Id = 40,
            Name = "DOWN",
            Sprite = "isDown",
            isFairy = false,
            isBackground = false,
            isCommand = true,
            isEffect = false
        };
        dictionaryLookups.Add(down);

        var up = new DictionaryLookup
        {
            Id = 41,
            Name = "UP",
            Sprite = "isUp",
            isFairy = false,
            isBackground = false,
            isCommand = true,
            isEffect = false
        };
        dictionaryLookups.Add(up);

        var candle = new DictionaryLookup
        {
            Id = 42,
            Name = "CANDLE",
            Sprite = "isCandle",
            isFairy = false,
            isBackground = false,
            isCommand = false,
            isEffect = false
        };
        dictionaryLookups.Add(candle);










    }

    private void ClearImage(Image image)
    {
        var tempColor = image.color;
        tempColor.a = 0f;
        image.color = tempColor;
    }

    private void ClearSprite(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.sprite = null;
    }

    private void AddSprite(SpriteRenderer spriteRenderer, Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

     public void UpdateStage()
    {
        FairyScript fairyScript = fairy.GetComponent<FairyScript>();

        // reset Fairy animation
        fairyScript.NoAnimation();

        // currentWords = words that have been made
        // currentWordSprites = current sprites that should be showing on the stage
        // wordImages = the db of the dictionary, that is loaded into memory in this class

        // load current board
        // for 3 rows
        // Row 1
        char[] board1 = new char[8];
        for (int i = 0; i < 8; i++)
        {
            if (Row1[i].childCount > 0)
            {
                board1[i] = Row1[i].GetChild(0).gameObject.name[0];
            }
        }

        // // Row 2
        char[] board2 = new char[8];
        for (int i = 0; i < 8; i++)
        {
            if (Row2[i].childCount > 0)
            {
                board2[i] = Row2[i].GetChild(0).gameObject.name[0];
            }
        }

        // Row 3
        // char[] board3 = new char[8];
        // for (int i = 0; i < 8; i++)
        // {
        //     if (Row3[i].childCount > 0)
        //     {
        //         board3[i] = Row3[i].GetChild(0).gameObject.name[0];
        //     }
        // }


        // for 3 rows
        // run the function      
        Search(board1, dictionaryLookups);
        Search(board2, dictionaryLookups);
        // Search(board3, dictionaryLookupsList);

        // for this string in Current Words, use this
        for (int i = 0; i < currentWords.Count; i++)
        {
            // if (!currentWordSprites.Contains(wordImages[currentWords[i]]))
            //     currentWordSprites.Add(wordImages[currentWords[i]]);

            foreach (var lookup in dictionaryLookups)
            {
                if (currentWords[i] == lookup.Name)
                {
                    if (lookup.isFairy)
                    {
                        currentWordFairyAnimations.Add(lookup.Sprite);
                    }
                    else if (lookup.isBackground)
                    {
                        currentBackgroundWordSprites.Add(Resources.Load<Sprite>("Images/Backgrounds/" + lookup.Sprite));
                    }
                    else if (lookup.isCommand)
                    {
                        Commands(lookup.Name);
                    }
                    else if (lookup.isEffect)
                    {
                        currentEffectsWords.Add(lookup.Name);
                    }
                    else
                    {
                        currentWordSprites.Add(Resources.Load<Sprite>("Images/Sprites/" + lookup.Sprite));
                    }

                }
            }            
        }



        // //RULES ----------------     

        // if (currentWordSprites.Count > 1)
        // {
        //     ClearImage(centerWordImage);
        //     AddImage(leftWordImage, currentWordSprites[0]);
        //     AddImage(rightWordImage, currentWordSprites[1]);
        //     // ClearImage(backgroundWordImage);
        // }
        if (currentWordSprites.Count == 1)
        {
            AddSprite(foregroundImage, currentWordSprites[0]);
        }
        else
        {
            ClearSprite(foregroundImage);
        }

        if (currentWordFairyAnimations.Count == 1)
        {
            fairyScript.Animation(currentWordFairyAnimations[0]);
        }

        if (currentBackgroundWordSprites.Count == 1)
        {
            AddSprite(backgroundImage, currentBackgroundWordSprites[0]);
        }
        else
        {
            ClearSprite(backgroundImage);
        }

        if (currentEffectsWords.Count == 1)
        {
            Effects(currentEffectsWords[0]);            
        }
        else
        {
            Effects("STOP");
        }


        // clear for next update
        currentWordFairyAnimations.Clear();
        currentWordSprites.Clear();
        currentBackgroundWordSprites.Clear();
        currentEffectsWords.Clear();
        currentWords.Clear();
    }


    private bool Search(char[] board, List<DictionaryLookup> dictionaryLookups)
    {
        for (int i = 0; i < board.Length; i++)
        {
            foreach (DictionaryLookup dictionaryLookup in dictionaryLookups)
            {
                if (board[i] == dictionaryLookup.Name[0] && dfs(board, i, 0, dictionaryLookup.Name))
                {
                    //print(words[h]);
                }
            }
        }
        return false;
    }

 
    public bool dfs(char[] board, int i, int count, string word)
    {       

        if (count == word.Length)
            return true;

        if (i < 0 || i >= board.Length || board[i] != word[count])
            return false;

        char temp = board[i];
        board[i] = ' ';

        bool found = dfs(board, i + 1, count + 1, word);

        board[i] = temp;

        if (found && !currentWords.Contains(word))
        {
            currentWords.Add(word);

            // for new one word only and permanent method
            currentWord = word;
            print(currentWord);
        }
        return found;
    }


    // optimise to a loop
    public void pressAButton()
    {
        GameObject aBlock = Instantiate(Resources.Load("Prefabs/Letters/a")) as GameObject;
        //aBlock.transform.SetParent(A4);
        setParent1(aBlock);
    }
    public void pressBButton()
    {
        GameObject bBlock = Instantiate(Resources.Load("Prefabs/Letters/b")) as GameObject;
        setParent1(bBlock);
    }
    public void pressCButton()
    {
        GameObject cBlock = Instantiate(Resources.Load("Prefabs/Letters/c")) as GameObject;
        setParent1(cBlock);
    }
    public void pressDButton()
    {
        GameObject dBlock = Instantiate(Resources.Load("Prefabs/Letters/d")) as GameObject;
        setParent1(dBlock);
    }
    public void pressEButton()
    {
        GameObject eBlock = Instantiate(Resources.Load("Prefabs/Letters/e")) as GameObject;
        setParent1(eBlock);
    }
    public void pressFButton()
    {
        GameObject fBlock = Instantiate(Resources.Load("Prefabs/Letters/f")) as GameObject;
        setParent1(fBlock);
    }
    public void pressGButton()
    {
        GameObject gBlock = Instantiate(Resources.Load("Prefabs/Letters/g")) as GameObject;
        setParent1(gBlock);
    }
    public void pressHButton()
    {
        GameObject hBlock = Instantiate(Resources.Load("Prefabs/Letters/h")) as GameObject;
        setParent1(hBlock);
    }
    public void pressIButton()
    {
        GameObject iBlock = Instantiate(Resources.Load("Prefabs/Letters/i")) as GameObject;
        setParent1(iBlock);
    }
    public void pressJButton()
    {
        GameObject jBlock = Instantiate(Resources.Load("Prefabs/Letters/j")) as GameObject;
        setParent1(jBlock);
    }
    public void pressKButton()
    {
        GameObject kBlock = Instantiate(Resources.Load("Prefabs/Letters/k")) as GameObject;
        setParent1(kBlock);
    }
    public void pressLButton()
    {
        GameObject lBlock = Instantiate(Resources.Load("Prefabs/Letters/l")) as GameObject;
        setParent1(lBlock);
    }
    public void pressMButton()
    {
        GameObject mBlock = Instantiate(Resources.Load("Prefabs/Letters/m")) as GameObject;
        setParent1(mBlock);
    }
    public void pressNButton()
    {
        GameObject nBlock = Instantiate(Resources.Load("Prefabs/Letters/n")) as GameObject;
        setParent2(nBlock);
    }
    public void pressOButton()
    {
        GameObject oBlock = Instantiate(Resources.Load("Prefabs/Letters/o")) as GameObject;
        setParent2(oBlock);
    }
    public void pressPButton()
    {
        GameObject pBlock = Instantiate(Resources.Load("Prefabs/Letters/p")) as GameObject;
        setParent2(pBlock);
    }
    public void pressQButton()
    {
        GameObject qBlock = Instantiate(Resources.Load("Prefabs/Letters/q")) as GameObject;
        setParent2(qBlock);
    }
    public void pressRButton()
    {
        GameObject rBlock = Instantiate(Resources.Load("Prefabs/Letters/r")) as GameObject;
        setParent2(rBlock);
    }
    public void pressSButton()
    {
        GameObject sBlock = Instantiate(Resources.Load("Prefabs/Letters/s")) as GameObject;
        setParent2(sBlock);
    }
    public void pressTButton()
    {
        GameObject tBlock = Instantiate(Resources.Load("Prefabs/Letters/t")) as GameObject;
        setParent2(tBlock);
    }
    public void pressUButton()
    {
        GameObject uBlock = Instantiate(Resources.Load("Prefabs/Letters/u")) as GameObject;
        setParent2(uBlock);
    }
    public void pressVButton()
    {
        GameObject vBlock = Instantiate(Resources.Load("Prefabs/Letters/v")) as GameObject;
        setParent2(vBlock);
    }
    public void pressWButton()
    {
        GameObject wBlock = Instantiate(Resources.Load("Prefabs/Letters/w")) as GameObject;
        setParent2(wBlock);
    }
    public void pressXButton()
    {
        GameObject xBlock = Instantiate(Resources.Load("Prefabs/Letters/x")) as GameObject;
        setParent2(xBlock);
    }
    public void pressYButton()
    {
        GameObject yBlock = Instantiate(Resources.Load("Prefabs/Letters/y")) as GameObject;
        setParent2(yBlock);
    }
    public void pressZButton()
    {
        GameObject zBlock = Instantiate(Resources.Load("Prefabs/Letters/z")) as GameObject;
        setParent2(zBlock);
    }


    // for 3 rows
    // private void setParent1(GameObject block)
    // {
    //     for (int i = 2; i < Rows.Count; i--)
    //     {
    //         for (int h = 0; h < Rows[i].Count; h++)
    //         {
    //             if (Rows[i][h].childCount == 0)
    //             {
    //                 block.transform.SetParent(Rows[i][h]);
    //                 break;
    //             }
    //             else
    //             {
    //                 continue;
    //             }
    //         }
    //     }
    // }

    // private void setParent2(GameObject block)
    // {
    //     for (int i = 2; i < Rows.Count; i--)
    //     {
    //         for (int h = 7; h < Rows[i].Count; h--)
    //         {
    //             if (Rows[i][h].childCount == 0)
    //             {
    //                 block.transform.SetParent(Rows[i][h]);
    //                 break;
    //             }
    //             else
    //             {
    //                 continue;
    //             }
    //         }
    //     }
    // }

    //1 ROW---------------------

    private void setParent1(GameObject block)
    {
        for (int h = 0; h < Row1.Count; h++)
        {
            if (Row1[h].childCount == 0)
            {
                block.transform.SetParent(Row1[h]);
                break;
            }
            else
            {
                continue;
            }
        }
    }

    private void setParent2(GameObject block)
    {
        for (int h = 7; h < Row1.Count; h--)
        {
            if (Row1[h].childCount == 0)
            {
                block.transform.SetParent(Row1[h]);
                break;
            }
            else
            {
                continue;
            }
        }
    }


    public void MoveRight()
    {
        fairy.transform.position = new Vector2(fairy.transform.position.x + 1, fairy.transform.position.y);
    }

    public void MoveLeft()
    {
        fairy.transform.position = new Vector2(fairy.transform.position.x - 1, fairy.transform.position.y);
    }

    public void SaveWord()
    {
        Debug.Log("test");
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        currentWord = textInfo.ToLower(currentWord);
        currentWord = textInfo.ToTitleCase(currentWord);
        print(currentWord);

        for (int i = 0; i < prefabs.Count; i++)
        {
            if (currentWord == prefabs[i].name)
            {
                Instantiate(prefabs[i], new Vector3(fairy.transform.position.x - 5, 0, 0), Quaternion.identity);
            }
            // currentWord = null;
        }
        ClearBlocks();
        //ClearImage(centerWordImage);
        ClearSprite(foregroundImage);
        ClearSprite(backgroundImage);
    }

    public void ClearBlocks()
    {
        for (int i = 0; i < Row1.Count; i++)
        {
            if (Row1[i].childCount > 0)
            {
                Destroy(Row1[i].transform.GetChild(0).gameObject);
            }
        }
        for (int i = 0; i < Row2.Count; i++)
        {
            if (Row2[i].childCount > 0)
            {
                Destroy(Row2[i].transform.GetChild(0).gameObject);
            }
        }
    }

    private void Commands(string lookupName)
    {
        if (lookupName == "FLIP")
        {
            if (DragDrop.selected != null)
            {
                DragDrop.selected.transform.Rotate(new Vector3(0, 180, 0));
            }
        }

        if (lookupName == "DELETE")
        {
            if (DragDrop.selected != null)
            {
                Destroy(DragDrop.selected);
            }
        }

        if (lookupName == "DOWN")
        {
            fairy.transform.position = new Vector2(fairy.transform.position.x, fairy.transform.position.y - 2);
        }

        if (lookupName == "UP")
        {
            fairy.transform.position = new Vector2(fairy.transform.position.x, fairy.transform.position.y + 2);
        }
    }

    private void Effects(string lookupName)
    {
        if (lookupName == "RAIN")
        {
            weatherCreator.Play();
        }
        if (lookupName == "STOP")
        {
            weatherCreator.Stop();
        }
    }
}